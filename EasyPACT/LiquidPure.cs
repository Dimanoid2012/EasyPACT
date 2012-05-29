using System;

namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает физические свойства 
    /// жидкостей, их зависимости друг от друга
    /// </summary>
    public class LiquidPure: Liquid
    {
        
        /// <summary>
        /// Чистая жидкость.
        /// </summary>
        /// <param name="id">Идентификационный номер жидкости.</param>
        /// <param name="t">Температура жидкости, в градусах Цельсия.</param>
        /// <param name="p">Давление, оказываемое на жидкость, в мм рт. ст.</param>
        public LiquidPure(string id, double t, double p)
            : base(id, t, p)
        {
            this.SetMolarMass();
            this.SetPressure(p);
            this.SetTemperature(t);
        }
        /// <summary>
        /// Фазовый переход.
        /// </summary>
        private int PhaseChange
        {
            get { return this._PhaseChange; }
            set
            {
                switch(value)
                {
                    case 21:
                        this.ModularCondition = 1;
                        break;
                    case 12:
                        this.ModularCondition = 2;
                        break;
                    default:
                        return;
                }
                this.SetTemperature(this.Temperature);
                this.SetPressure(this.Pressure);
            }
        }
        public override void Condence()
        {
            this.PhaseChange = 21;
        }
        public override void Evaporate()
        {
            this.PhaseChange = 12;
        }
        protected override sealed void SetMolarMass()
        {
            this._MolarMass = Calculation.MolarMass(this);
        }
        protected override void SetPressure(double pressure)
        {
            this._Pressure = pressure;
            this._BoilingPoint = Calculation.BoilingPoint(this);
        }
        protected override void SetTemperature(double temperature)
        {
            this._Temperature = temperature;
            if (this.ModularCondition == 0)
                this.ModularCondition = this.Temperature <= this.BoilingPoint ? 1 : 2;
            else
                if (this.Temperature == this.BoilingPoint)
                    this._PhaseChange = this.ModularCondition == 1 ? 12 : 21;
            this._Density = Calculation.Density(this);
            this.ThermalCapacity = Calculation.ThermalCapacity(this);
            this._ViscosityDynamic = Calculation.ViscosityDynamic(this)/1000;
            this.VaporizationHeat = Calculation.VaporizationHeat(this);
            //this.ThermalConductivity = Calculation.ThermalConductivity(this);
            this.SetThermalConductivity();
        }
        /// <summary>
        /// Теплопроводность жидкости при 30 градусах Цельсия.
        /// </summary>
        protected double ThermalConductivity30
        {
            get { return 4.22e-8 * this.ThermalCapacity * this.Density * Math.Pow(this.Density / this.MolarMass, 0.33); }
        }
        /// <summary>
        /// Теплопроводность жидкости при текущей температура.
        /// </summary>
        public void SetThermalConductivity()
        {
            this.ThermalConductivity = this.ThermalConductivity30 * (1 - 0.002 * (this.Temperature - 30));
        }
    }
}
