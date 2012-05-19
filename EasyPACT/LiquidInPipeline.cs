using System;

namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает поведение жидкости в трубопроводе.
    /// </summary>
    public class LiquidInPipeline
    {
        /// <summary>
        /// Режим течения жидкости:
        /// 1 - ламинарный
        /// 2 - переходный
        /// 3 - турбулентный
        /// </summary>
        //protected int _CurrentMode;
        /// <summary>
        /// Коэффициент трения
        /// </summary>
        //protected double _Friction;
        /// <summary>
        /// Жидкость, текущая по трубопроводу.
        /// </summary>
        protected Liquid _Liquid;
        /// <summary>
        /// Трубопровод, по которому течет жидкость.
        /// </summary>
        protected Pipeline _Pipeline;
        /// <summary>
        /// Массовый расход жидкости в кг/с.
        /// </summary>
        protected double _MassFlow;
        /// <summary>
        /// Критерий Рейнольдса.
        /// </summary>
        //protected double _Re;
        /// <summary>
        /// Средняя скорость потока жидкости в м/с.
        /// </summary>
        //protected double _Speed;
        /// <summary>
        /// Объемный расход жидкости в м3/с.
        /// </summary>
        //protected double _VolumeFlow;
        /// <summary>
        /// Данный класс описывает поведение жидкости в трубопроводе.
        /// </summary>
        /// <param name="Liq">Жидкость, текущая по трубопроводу.</param>
        /// <param name="Pip">Трубопровод, по которому течет жидкость.</param>
        public LiquidInPipeline(Liquid Liq, Pipeline Pip)
        {
            this._Liquid = Liq;
            this._Pipeline = Pip;
        }
        /*public int CurrentMode
        {
            get { return this._CurrentMode; }
        }*/
        /// <summary>
        /// Коэффициент трения жидкости.
        /// </summary>
        public double FactorOfAFriction
        {
            get
            {
                if (this.Re <= 2300)
                    return this.Pipeline.CoefficientA/this.Re;
                if (this.Pipeline.Type == 6 & this.Re < 100000)
                    return 0.316/Math.Pow(this.Re, 0.25);
                return 1/
                       Math.Pow(
                           Math.Log10(Math.Pow(this.Pipeline.RelativeRoughness/3.7 + Math.Pow(6.81/this.Re, 0.9), -2)),
                           2);
            }
        }
        /// <summary>
        /// Жидкость, текущая по трубопроводу.
        /// </summary>
        public Liquid Liquid
        {
            get { return this._Liquid; }
        }
        /// <summary>
        /// Массовый расход жидкости в кг/с.
        /// </summary>
        public double MassFlow
        {
            get { return this._MassFlow; }
            //set { this.SetMassFlow(value); }
            set { this._MassFlow = value; }
        }
        /// <summary>
        /// Трубопровод, по которому течет жидкость.
        /// </summary>
        public Pipeline Pipeline
        {
            get { return this._Pipeline; }
        }
        /// <summary>
        /// Критерий Рейнольдса
        /// </summary>
        public double Re
        {
            get { return this.Speed*this.Pipeline.Diameter*this.Liquid.Density/this.Liquid.ViscosityDynamic; }
        }
        /// <summary>
        /// Средняя скорость потока жидкости в м/с.
        /// </summary>
        public double Speed
        {
            get { return 4*this.MassFlow/(this.Liquid.Density*Math.PI*Math.Pow(this.Pipeline.Diameter, 2)); }
        }
        /// <summary>
        /// Объемный расход жидкости в м3/с.
        /// </summary>
        public double VolumeFlow
        {
            get { return this._MassFlow/this.Liquid.Density; }
        }
        /// <summary>
        /// Устанавливает массовый расход жидкости в трубопроводе.
        /// </summary>
        /// <param name="G">Массовый расход жидкости в кг/с.</param>
        /*protected void SetMassFlow(double G)
        {
            this._MassFlow = G;
            //this._VolumeFlow = this._MassFlow / this.Liquid.Density;
            //this.SetSpeed();
        }*/
        /// <summary>
        /// Вычисляет критерий Рейнольдса для жидкости.
        /// </summary>
        /*protected void SetRe()
        {
            this._Re = this.Speed * this.Pipeline.Diameter * this.Liquid.Density / (this.Liquid.ViscosityDynamic / 1000);
            this._CurrentMode = (this._Re <= 2300) ? 1 : (this._Re >= 10000) ? 3 : 2;
            this.SetFriction();
        }*/
        /// <summary>
        /// Вычисляет среднюю скорость потока жидкости в трубопроводе.
        /// </summary>
        /*protected void SetSpeed()
        {
            this._Speed = 4 * this.MassFlow / (this.Liquid.Density*Math.PI * Math.Pow(this.Pipeline.Diameter, 2));
            //this.SetRe();
        }*/
        /// <summary>
        /// Устанавливает среднюю скорость потока жидкости в трубопроводе.
        /// </summary>
        /// <param name="G">Средняя скорость потока жидкости в м/с.</param>
        /*protected void SetSpeed(double w)
        {
            this._Speed = w;
            this.VolumeFlow = w * Math.PI * Math.Pow(this.Pipeline.Diameter, 2) / 4;
            //this.SetRe();
        }*/
        /// <summary>
        /// Устанавливает объемный расход жидкости в трубопроводе.
        /// </summary>
        /// <param name="G">Объемный расход жидкости в м3/с.</param>
        /*protected void SetVolumeFlow(double V)
        {
            this._VolumeFlow = V;
            this._MassFlow = this._VolumeFlow * this.Liquid.Density;
            //this.SetSpeed();
        }*/
        /// <summary>
        /// Потеря давления на трение.
        /// </summary>
        /// <returns>Возвращает потерю давления на трение.</returns>
        public double LossOfPressureUponAFriction()
        {
            return this.FactorOfAFriction * this.Pipeline.Length / this.Pipeline.Diameter * this.Liquid.Density *
                   Math.Pow(this.Speed, 2) / 2;
        }

        /// <summary>
        /// Затраты давления на создание скорости потока на выходе из сети.
        /// </summary>
        /// <returns>Возвращает потерю давления на создание скорости потока на выходе из сети.</returns>
        public double LossOfPressureUponCreationOfSpeed()
        {
            return this.Liquid.Density * Math.Pow(this.Speed, 2) / 2;
        }
        /// <summary>
        /// Потеря давления на подъем жидкости.
        /// </summary>
        /// <param name="h">Высота подачи жидкости.</param>
        /// <returns>Возвращает потерю давления на подъем жидкости.</returns>
        public double LossOfPressureUponLifting(double h)
        {
            return this.Liquid.Density*9.81*h;
        }
        /// <summary>
        /// Разность давлений в пространстве всасывания и нагнетания.
        /// </summary>
        /// <param name="lip">Жидкость во всасывающем трубопроводе.</param>
        /// <returns>Возвращает разность давлений в пространстве всасывания и нагнетания.</returns>
        public double LossOfPressureUponLifting(LiquidInPipeline lip)
        {
            return this.Liquid.Pressure - lip.Liquid.Pressure;
        }
        /// <summary>
        /// Потеря давления на преодоление местных сопротивлений.
        /// </summary>
        ///<returns>Возвращает потерю давления на преодоление местных сопротивлений.</returns>
        public double LossOfPressureUponLocalResistances()
        {
            return this.Pipeline.FactorOfLocalResistance * this.Liquid.Density * Math.Pow(this.Speed, 2) / 2;
        }
    }
}
