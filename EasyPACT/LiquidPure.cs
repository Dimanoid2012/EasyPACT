namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает физические свойства 
    /// жидкостей, их зависимости друг от друга
    /// </summary>
    class LiquidPure: Liquid
    {
        /// <summary>
        /// 
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
            this._ViscosityDynamic = Calculation.ViscosityDynamic(this)/1000;
        }
    }
}
