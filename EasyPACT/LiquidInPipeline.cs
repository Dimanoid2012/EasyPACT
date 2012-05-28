using System;

namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает поведение жидкости в трубопроводе.
    /// </summary>
    public class LiquidInPipeline
    {
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
        /// Данный класс описывает поведение жидкости в трубопроводе.
        /// </summary>
        /// <param name="Liq">Жидкость, текущая по трубопроводу.</param>
        /// <param name="Pip">Трубопровод, по которому течет жидкость.</param>
        public LiquidInPipeline(Liquid Liq, Pipeline Pip)
        {
            this._Liquid = Liq;
            this._Pipeline = Pip;
        }
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
            set { this._MassFlow = value; }
        }
        public double Nu
        {
            get
            {
                if (this.Re >= 10000)
                {
                    return 0.021 * Math.Pow(this.Re, 0.8) * Math.Pow(this.Liquid.Pr, 0.43);
                }
                return 1.55 * Math.Pow(this.Re * this.Pipeline.Diameter / this.Pipeline.Length, 1 / 3);
            }
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
        /// Суммарные потери давления на трение и местные сопротивления, Па.
        /// </summary>
        /// <returns>Суммарные потери давления на трение и местные сопротивления, Па.</returns>
        public double LossOfPressureSummary()
        {
            return this.LossOfPressureUponAFriction() + this.LossOfPressureUponLocalResistances();
        }
        /// <summary>
        /// Потеря давления на трение, Па.
        /// </summary>
        /// <returns>Возвращает потерю давления на трение, Па.</returns>
        public double LossOfPressureUponAFriction()
        {
            return this.FactorOfAFriction * this.Pipeline.Length / this.Pipeline.Diameter * this.Liquid.Density *
                   Math.Pow(this.Speed, 2) / 2;
        }

        /// <summary>
        /// Затраты давления на создание скорости потока на выходе из сети, Па.
        /// </summary>
        /// <returns>Возвращает потерю давления на создание скорости потока на выходе из сети, Па.</returns>
        public double LossOfPressureUponCreationOfSpeed()
        {
            return this.Liquid.Density * Math.Pow(this.Speed, 2) / 2;
        }
        /// <summary>
        /// Потеря давления на подъем жидкости, Па.
        /// </summary>
        /// <param name="h">Высота подачи жидкости.</param>
        /// <returns>Возвращает потерю давления на подъем жидкости, Па.</returns>
        public double LossOfPressureUponLifting(double h)
        {
            return this.Liquid.Density*9.81*h;
        }
        /// <summary>
        /// Разность давлений в пространстве всасывания и нагнетания, Па.
        /// </summary>
        /// <param name="lip">Жидкость во всасывающем трубопроводе.</param>
        /// <returns>Возвращает разность давлений в пространстве всасывания и нагнетания, Па.</returns>
        public double LossOfPressureUponLifting(LiquidInPipeline lip)
        {
            return this.Liquid.Pressure - lip.Liquid.Pressure;
        }
        /// <summary>
        /// Потеря давления на преодоление местных сопротивлений, Па.
        /// </summary>
        ///<returns>Возвращает потерю давления на преодоление местных сопротивлений, Па.</returns>
        public double LossOfPressureUponLocalResistances()
        {
            return this.Pipeline.FactorOfLocalResistance * this.Liquid.Density * Math.Pow(this.Speed, 2) / 2;
        }
    }
}
