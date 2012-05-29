namespace EasyPACT
{
    public abstract class Liquid
    {
        /// <summary>
        /// Температура кипения жидкости в градусах Цельсия.
        /// </summary>
        protected double _BoilingPoint;
        /// <summary>
        /// Плотность жидкости в килограммах на кубометр.
        /// </summary>
        protected double _Density;
        /// <summary>
        /// Идентификационный номер для поиска в БД.
        /// </summary>
        protected string _Id;

        /// <summary>
        /// Агрегатное состояние жидкости.
        /// </summary>
        public int ModularCondition { get; protected set; }
        /// <summary>
        /// Молярная масса жидкости в килограммах на киломоль.
        /// </summary>
        protected double _MolarMass;
        /// <summary>
        /// Название жидкости.
        /// </summary>
        protected string _Name;
        /// <summary>
        /// Направление фазового перехода.
        /// </summary>
        protected int _PhaseChange;
        /// <summary>
        /// Давление, оказываемое на жидкость, в мм рт. ст.
        /// </summary>
        protected double _Pressure;
        /// <summary>
        /// Температура жидкости в градусах Цельсия.
        /// </summary>
        protected double _Temperature;
        /// <summary>
        /// Теплоемкость, в Дж/(кг*К).
        /// </summary>
        public double ThermalCapacity { get; protected set; }
        /// <summary>
        /// Коэффициент теплопроводности, в Вт/(м*К).
        /// </summary>
        public double ThermalConductivity { get; protected set; }
        /// <summary>
        /// Удельная теплота парообразования, кДж/кг.
        /// </summary>
        public double VaporizationHeat { get; protected set; }
        /// <summary>
        /// Динамический коэффициент вязкости жидкости в Па*с
        /// </summary>
        protected double _ViscosityDynamic;

        /// <summary>
        /// Данный класс описывает физические свойства 
        /// жидкостей, их зависимости друг от друга.
        /// </summary>
        /// <param name="id">Идентификатор жидкости.</param>
        /// <param name="t">Температура жидкости, в градусах Цельсия.</param>
        /// <param name="p">Давление, оказываемое на жидкость, в мм рт. ст.</param>
        protected Liquid(string id, double t, double p)
        {
            if (t <= -273.15)
            {
                throw new Exceptions.InvalidTemperatureException("Температура не может быть ниже абсолютного нуля либо равна ему!");
            }
            if (p <= 0)
            {
                throw new Exceptions.InvalidPressureException("Давление не может быть ниже нуля либо равно ему!");
            }
            this._Id = id;
            this._Name = Calculation.Name(this);
            this._Temperature = t;
            this._Pressure = p;
        }

        /// <summary>
        /// Возвращает температуру кипения жидкости.
        /// </summary>
        public double BoilingPoint
        {
            get { return this._BoilingPoint; }
        }
        /// <summary>
        /// Плотность жидкости при текущей температуре.
        /// </summary>
        public double Density
        {
            get { return this._Density; }
        }
        /// <summary>
        /// Идентификационный номер жидкости. 
        /// </summary>
        public string Id
        {
            get { return this._Id; }
        }
        /// <summary>
        /// Молярная масса жидкости.
        /// </summary>
        public double MolarMass
        {
            get { return this._MolarMass; }
        }
        /// <summary>
        /// Название жидкости.
        /// </summary>
        public string Name
        {
            get { return this._Name; }
        }
        /// <summary>
        /// Критерий Прандтля.
        /// </summary>
        public double Pr
        {
            get { return this.ThermalCapacity*this.ViscosityDynamic/this.ThermalConductivity; }
        }
        /// <summary>
        /// Возвращает давление жидкости в мм рт. ст.
        /// </summary>
        public double Pressure
        {
            get { return this._Pressure; }
            set
            {
                this.SetPressure(value);
            }
        }
        /// <summary>
        /// Возвращает температуру жидкости в градусах Цельсия.
        /// </summary>
        public double Temperature
        {
            get { return this._Temperature; }
            set
            {
                this.SetTemperature(value);
            }
        }
        /// <summary>
        /// Возвращает динамический коэффициент вязкости жидкости при текущей температуре.
        /// </summary>
        public double ViscosityDynamic
        {
            get { return this._ViscosityDynamic; }
        }
        /// <summary>
        /// Возвращает динамический коэффициент вязкости жидкости при текущей температуре.
        /// </summary>
        public double ViscosityKinematic
        {
            get { return this._ViscosityDynamic / this._Density; }
        }
        /// <summary>
        /// Конденсироваться.
        /// </summary>
        public abstract void Condence();
        /// <summary>
        /// Испариться.
        /// </summary>
        public abstract void Evaporate();
        /// <summary>
        /// Вычисляет молярную массу жидкости.
        /// </summary>
        protected abstract void SetMolarMass();
        /// <summary>
        /// Задает давление на жидкость и пересчитывает ее параметры.
        /// </summary>
        /// <param name="pressure">Давление, действующее на жидкость, в мм рт. ст.</param>
        protected abstract void SetPressure(double pressure);
        /// <summary>
        /// Задает температуру жидкости и пересчитывает ее параметры.
        /// </summary>
        /// <param name="temperature">Температура жидкости, в мм рт. ст.</param>
        protected abstract void SetTemperature(double temperature);
    }
}
