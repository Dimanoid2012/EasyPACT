using System;
using System.Linq;

namespace EasyPACT
{
    /// <summary>
    /// Класс, описывающий систему целиком и обеспечивающий
    /// взаимодействие между объектами. Одиночка.
    /// </summary>
    public sealed class Network
    {
        /// <summary>
        /// Единственный объект класса Network.
        /// </summary>
        private static Network _network;
        /// <summary>
        /// Флаг проверки, существует ли уже сеть.
        /// </summary>
        private static bool _isExist;

        /// <summary>
        /// Всасывающая линия.
        /// </summary>
        public LiquidInPipeline VacuumLine { get; private set; }

        /// <summary>
        /// Нагнетающая линия.
        /// </summary>
        public LiquidInPipeline ForcingLine { get; private set; }

        /// <summary>
        /// Насос.
        /// </summary>
        public CentrifugalPump Pump { get; private set; }

        /// <summary>
        /// Теплообменник.
        /// </summary>
        public HeatExchangerPipe HeatExchanger { get; private set; }
        /// <summary>
        /// Производительность сети в кг/с.
        /// </summary>
        public double Productivity { get; private set; }

        private Network() { }

        /// <summary>
        /// Пытается создать объект сети, если его не существует, иначе возвращает существующий объект.
        /// </summary>
        /// <param name="vacuumLine">Всасывающая линия.</param>
        /// <param name="forcingLine">Нагнетающая линия.</param>
        /// <returns>Возвращает новый или существующий объект сети.</returns>
        public static Network Create(LiquidInPipeline vacuumLine, LiquidInPipeline forcingLine)
        {
            if (_isExist)
                return _network;
            var network = new Network {VacuumLine = vacuumLine, ForcingLine = forcingLine};
            _network = network;
            _isExist = true;
            return network;
        }
        /// <summary>
        /// Возвращает объект сети, если он уже создан, либо null, если его нет.
        /// </summary>
        /// <returns>Возвращает объект сети, если он уже создан, либо null, если его нет.</returns>
        public static Network Get()
        {
            return _isExist ? _network : null;
        }
        /// <summary>
        /// Устанавливает производительность сети. Вызвать может только насос, установленный в сети.
        /// </summary>
        /// <param name="productivity">Новая производительность, кг/с.</param>
        public bool SetProductivity(double productivity)
        {
            this.Productivity = productivity;
            if (this.Pump != null)
                this.Pump.SetProductivity(productivity/this.VacuumLine.Liquid.Density);
            if (this.HeatExchanger != null)
                this.HeatExchanger.LiquidInPipeline.MassFlow = productivity*this.HeatExchanger.NumberOfCourses/
                                                               this.HeatExchanger.NumberOfPipes;
            this.VacuumLine.MassFlow = productivity;
            this.ForcingLine.MassFlow = productivity;

            return true;
        }
        /// <summary>
        /// Подобрать насос к заданной сети.
        /// </summary>
        /// <param name="liftingHeight">Высота подъема жидкости.</param>
        public void ChooseCentrifugalPump(double liftingHeight)
        {
            var massFlow = this.Productivity;
            var Hvac = (this.VacuumLine.LossOfPressureUponAFriction() +
                        this.VacuumLine.LossOfPressureUponLocalResistances())/this.VacuumLine.Liquid.Density/9.81;
            var Hfor = (this.ForcingLine.LossOfPressureUponAFriction() +
                        this.ForcingLine.LossOfPressureUponLocalResistances()) / this.ForcingLine.Liquid.Density / 9.81;
            var Hhe = (this.HeatExchanger.LiquidInCase.LossOfPressureUponAFriction() +
                       this.HeatExchanger.LiquidInCase.LossOfPressureUponLocalResistances())/
                      this.HeatExchanger.LiquidInCase.Liquid.Density/9.81;
            var H = Hvac + Hfor + Hhe + liftingHeight;
            var N = massFlow*9.81*H/0.6;
            var list =
                Database.Query(
                    String.Format("SELECT id FROM centrifugal_pumps WHERE productivity>={0} AND pressure>={1}",
                                  massFlow/this.VacuumLine.Liquid.Density, H));
            var id = list[0].First();
            this.Pump = new CentrifugalPump(Convert.ToInt32(id));
            this.SetProductivity(massFlow);

        }
        /// <summary>
        /// Подобрать теплообменник к заданной сети.
        /// </summary>
        /// <param name="temperatureLiquid">Требуемая на выходе температура.</param>
        /// <param name="temperatureSteam">Температура греющего пара.</param>
        public void ChooseHeatExchanger(double temperatureLiquid,double temperatureSteam)
        {
            var t = (temperatureLiquid + this.ForcingLine.Liquid.Temperature)/2; // Средняя температура
            //this.HeatExchanger.SetLiquidInPipes(this.ForcingLine.Liquid);
            Liquid liq;
            if (this.ForcingLine.Liquid.GetType().ToString().IndexOf("Pure") != -1)
                liq = new LiquidPure(this.ForcingLine.Liquid.Id, t, this.ForcingLine.Liquid.Pressure);
            else
            {
                var l = this.ForcingLine.Liquid as LiquidMix;
                liq = new LiquidMix(l.Id, l.MolarFraction, t, l.Pressure);
            }
            var steam = new LiquidPure("10", temperatureSteam, Calculation.Pressure(10, temperatureSteam));
            steam.Evaporate();
            liq.Temperature = t;
            //this.Productivity = 32 * 1000 / 3600 / liq.Density; // УДАЛИТЬ
            var Q = this.Productivity*liq.ThermalCapacity/1000*
                    (temperatureLiquid - this.ForcingLine.Liquid.Temperature);
            var G1 = Q/steam.VaporizationHeat;
            var V1 = G1/steam.Density;
            var V2 = this.Productivity/liq.Density;
            var dtMax = steam.Temperature - this.ForcingLine.Liquid.Temperature;
            var dtMin = steam.Temperature - temperatureLiquid;
            var dt = (dtMax - dtMin)/Math.Log(dtMax/dtMin);
            var Kor = 120;
            var For = Q*1000/Kor/dt;
            var Re2min = 10000;
            var w2min = Re2min*liq.ViscosityDynamic/liq.Density/0.021;
            var nmax = Math.Ceiling(V2/0.785/0.021/0.021/w2min);
            var list =
                Database.Query(string.Format("SELECT id FROM XXXIV WHERE surface_area < {0} AND pipes_per_course < {1}",
                                             For, nmax))[0];
            var id = list.First();
            var he = new HeatExchangerPipe(Convert.ToInt32(id));
            he.SetLiquidInCase(steam);
            he.SetLiquidInPipes(this.ForcingLine.Liquid);
            double F = 0;
            while(true )
            {
                var Re2 = Re2min*(nmax*he.NumberOfCourses/he.NumberOfPipes);
                var Pr2 = liq.Pr;
                var Nu2 = 0.021*Math.Pow(Re2, 0.8)*Math.Pow(Pr2, 0.43);
                var a2 = Nu2*liq.ThermalConductivity/0.021;
                var q = Q/he.SurfaceArea;
                steam.Condence();
                var a1 = 1.21*steam.ThermalConductivity*
                         Math.Pow(
                             Math.Pow(steam.Density, 2)*steam.VaporizationHeat*9.81/steam.ViscosityDynamic/
                             he.PipesLength, 0.33)*Math.Pow(q, -0.33);
                var d = 0.002;
                var r = d/he.Pipeline.ThermalConductivity;
                var r1 = 1/1600.0;
                var r2 = 1/5800.0;
                r = r + r1 + r2;
                var K = 1/(1/a1 + r + 1/a2);
                F = Q*1000/K/dt;
                var zap = (he.SurfaceArea - F)/he.SurfaceArea;
                if((zap < 0.1 | zap > 0.3) & list.Count > 0)
                {
                    list.RemoveAt(0);
                    id = list.First();
                    he = new HeatExchangerPipe(Convert.ToInt32(id));
                    he.SetLiquidInCase(steam);
                    he.SetLiquidInPipes(this.ForcingLine.Liquid);
                }
                else
                {
                    break;
                }
            }
            he.LiquidInCase.MassFlow = G1;
            this.HeatExchanger = he;

        }
    }
}
