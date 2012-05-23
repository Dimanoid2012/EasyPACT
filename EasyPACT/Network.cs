using System;

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
        /// Производительность сети в м3/с.
        /// </summary>
        public double Productivity { get; private set; }

        private Network() { }

        /// <summary>
        /// Пытается создать объект сети, если его не существует, иначе возвращает существующий объект.
        /// </summary>
        /// <param name="vacuumLine">Всасывающая линия.</param>
        /// <param name="forcingLine">Нагнетающая линия.</param>
        /// <param name="pump">Насос.</param>
        /// <returns>Возвращает новый или существующий объект сети.</returns>
        public static Network Create(LiquidInPipeline vacuumLine, LiquidInPipeline forcingLine, CentrifugalPump pump)
        {
            if (_isExist)
                return _network;
            var network = new Network { VacuumLine = vacuumLine, ForcingLine = forcingLine, Pump = pump };
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
        /// <param name="pump">Насос.</param>
        /// <param name="productivity">Новая производительность.</param>
        public bool SetProductivity(CentrifugalPump pump, double productivity)
        {
            if (pump != this.Pump)
                return false;
            this.Productivity = productivity;
            return true;
        }
        public bool AddHeatExchanger(HeatExchangerPipe he)
        {
            this.HeatExchanger = he;
            this.ForcingLine.Pipeline.AddLocalResistance(2*1.5 + he.NumberOfPipes + 2.5*(he.NumberOfCourses - 1));
            return true;
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
            liq.Temperature = t;
            this.Productivity = 32 * 1000 / 3600 / liq.Density; // УДАЛИТЬ
            var Q = this.Productivity*liq.Density*liq.ThermalCapacity*
                    (temperatureLiquid - this.ForcingLine.Liquid.Temperature);
            var G1 = Q/steam.VaporizationHeat;
            var V1 = G1/steam.Density;
            var V2 = this.Productivity;
            var dtMax = steam.Temperature - this.ForcingLine.Liquid.Temperature;
            var dtMin = steam.Temperature - temperatureLiquid;
            var dt = (dtMax - dtMin)/Math.Log(dtMax - dtMin);
            var Kor = 120;
            var For = Q/Kor/dt;
            var Re2min = 10000;
            var w2min = Re2min*liq.ViscosityDynamic/liq.Density/0.021;
            var nmax = V2/0.785/0.021/0.021/w2min;
            var list =
                Database.Query(string.Format("SELECT * FROM XXXIV WHERE surface_area < {0} AND number_of_pipes < {1}",
                                             For, nmax));

        }
    }
}
