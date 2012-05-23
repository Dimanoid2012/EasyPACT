using System;
using System.Linq;

namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает физические свойства 
    /// смесей жидкостей, их зависимости друг от друга
    /// </summary>
    public class LiquidMix:Liquid
    {
        /// <summary>
        /// Массив компонентов смеси, упорядоченный по возрастанию их температур кипения.
        /// </summary>
        protected LiquidPure[] _Components = new LiquidPure[2];
        /// <summary>
        /// Массовая доля низкокипящего компонента.
        /// </summary>
        protected double _MassFraction;
        /// <summary>
        /// Молярная доля низкокипящего компонента смеси.
        /// </summary>
        protected double _MolarFraction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Идентификационный номер смеси.</param>
        /// <param name="molarFraction">Молярная доля низкокипящего компонента.</param>
        /// <param name="t">Температура жидкости, в градусах Цельсия.</param>
        /// <param name="p">Давление, оказываемое на жидкость, в мм рт. ст.</param>
        public LiquidMix(string id, double molarFraction, double t, double p)
            : base(id, t, p)
        {
            var liq1 = new LiquidPure(id.Split(',')[0], t, p);
            var liq2 = new LiquidPure(id.Split(',')[1], t, p);
            if (liq1.BoilingPoint <= liq2.BoilingPoint)
            {
                this._Components[0] = liq1;
                this._Components[1] = liq2;
            }
            else
            {
                this._Components[0] = liq2;
                this._Components[1] = liq1;
            }
            this._MolarFraction = molarFraction;
            this.SetMolarMass();
            this.MolarFraction = molarFraction;
            this.SetPressure(p);
            this.SetTemperature(t);
        }
        public override void Condence()
        {
            
        }
        public override void Evaporate()
        {
            
        }
        /// <summary>
        /// Низкокипящий компонент смеси.
        /// </summary>
        public LiquidPure LB
        {
            get { return this._Components[0]; }
        }
        /// <summary>
        /// Высококипящий компонент смеси.
        /// </summary>
        public LiquidPure HB
        {
            get { return this._Components[1]; }
        }    
        /// <summary>
        /// Массовая доля низкокипящего компонента смеси.
        /// </summary>
        public double MassFraction
        {
            get { return this._MassFraction; }
            protected set { this.SetMassFraction(value); }
        }
        /// <summary>
        /// Молярная доля низкокипящего компонента смеси.
        /// </summary>
        public double MolarFraction
        {
            get { return this._MolarFraction; }
            protected set { this.SetMolarFraction(value); }
        }

        /// <summary>
        /// Задает молярную долю низкокипящего компонента смеси.
        /// </summary>
        /// <param name="MassFraction">Массовая доля низкокипящего компонента смеси.</param>
        protected void SetMassFraction(double MassFraction)
        {
            this._MassFraction = MassFraction;
            this._MolarFraction = this.MassFraction * this.MolarMass / this._Components[0].MolarMass;
        }
        /// <summary>
        /// Задает молярную долю низкокипящего компонента смеси.
        /// </summary>
        /// <param name="MolarFraction">Молярная доля низкокипящего компонента смеси.</param>
        protected void SetMolarFraction(double MolarFraction)
        {
            this._MolarFraction = MolarFraction;
            this._MassFraction = MolarFraction * this._Components[0].MolarMass / this.MolarMass;
        }
        public override void SetMolarMass()
        {
            this._MolarMass = this.MolarFraction * this._Components[0].MolarMass + (1 - this.MolarFraction) * this._Components[1].MolarMass;
        }
        /// <summary>
        /// Вычисляет плотность смеси.
        /// </summary>
        protected void SetDensity()
        {
            this._Density = 1 / (this.MassFraction / this._Components[0].Density + (1 - this.MassFraction) / this._Components[1].Density);
        }
        /// <summary>
        /// Вычисляет динамическую вязкость смеси.
        /// </summary>
        protected void SetViscosity()
        {
            this._ViscosityDynamic = Math.Pow(10,
                this.MolarFraction * Math.Log10(this._Components[0].ViscosityDynamic)
                + (1 - this.MolarFraction) * Math.Log10(this._Components[1].ViscosityDynamic));
        }

        protected override void SetPressure(double pressure)
        {
            if (this._Pressure == 0)
            {
                this._Pressure = 0.01;
            return;
            }
            this._Pressure = pressure;
            this._BoilingPoint = Calculation.BoilingPointMix(this);
        }
        protected override void SetTemperature(double temperature)
        {
            this._Components.Select(a => a.Temperature = temperature);
            this._Temperature = temperature;
            this.SetDensity();
            this.SetViscosity();
            this.ThermalCapacity = Calculation.ThermalCapacity(this);
        }
    }
}
