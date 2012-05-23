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
        private int PhaseChange
        {
            get { return this._PhaseChange; }
            set
            {
                switch(value)
                {
                    case 21:
                        this._ModularCondition = 1;
                        break;
                    case 12:
                        this._ModularCondition = 2;
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
        public override sealed void SetMolarMass()
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
            this._Density = Calculation.Density(this);
            this.ThermalCapacity = Calculation.ThermalCapacity(this);
            this._ViscosityDynamic = Calculation.ViscosityDynamic(this)/1000;
            if (this._ModularCondition == 0)
                this._ModularCondition = this.Temperature <= this.BoilingPoint ? 1 : 2;
            else
                if (this.Temperature == this.BoilingPoint)
                    this._PhaseChange = this._ModularCondition == 1 ? 12 : 21;
            this.VaporizationHeat = Calculation.VaporizationHeat(this);

        }
    }
}
