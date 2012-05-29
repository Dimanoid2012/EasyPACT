        using System;

namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает материал, размеры
    /// и прочие особенности трубопровода произвольного сечения.
    /// </summary>
    public class Pipeline
    {
        /// <summary>
        /// Коэффициент А.
        /// </summary>
        protected int _CoefficientA;
        /// <summary>
        /// Эффективный диаметр трубопровода в метрах.
        /// </summary>
        protected double _Diameter;
        /// <summary>
        /// Толщина стенок в метрах.
        /// </summary>
        protected double _Width;
        /// <summary>
        /// Суммарный коэффициент местных сопротивлений
        /// </summary>
        protected double _FactorOfLocalResistance;
        /// <summary>
        /// Длина трубопровода в метрах.
        /// </summary>
        protected double _Length;
        /// <summary>
        /// ID материала, из которого изготовен трубопровод.
        /// </summary>
        protected int _MaterialId;
        /// <summary>
        /// Среднее значение шероховатости стенок трубы в миллиметрах
        /// </summary>
        protected double _RoughnessOfWalls;
        /// <summary>
        /// Коэффициент теплопроводности стенок трубы в Вт / (м*К)
        /// </summary>
        protected double _ThermalConductivity;
        /// <summary>
        /// Тип трубопровода.
        /// </summary>
        protected int _Type;

        protected Pipeline() { } // Стандартный конструктор
        /// <summary>
        /// Данный класс описывает материал, размеры
        /// и прочие особенности трубопровода постоянного произвольного сечения.
        /// </summary>
        /// <param name="materialId">ID материала, из которого изготовлен трубопровод.</param>
        /// <param name="type">Тип трубопровода.</param>
        /// <param name="square">Площадь поперечного сечения трубопровода в квадратных метрах.</param>
        /// <param name="perimeter">Величина смоченного периметра трубопровода в метрах.</param>
        /// <param name="width">Толщина стенок в метрах.</param>
        /// <param name="length">Длина трубопровода в метрах.</param>
        public Pipeline(int materialId, int type, double square, double perimeter, double width, double length)
        {
            this.MaterialId = materialId;
            this._Type = type;
            this._Width = width;
            this.SetDiameter(square, perimeter);
            this.SetLength(length);
            this._ThermalConductivity = Calculation.ThermalConductivity(this);
            this._RoughnessOfWalls = Calculation.RoughnessOfWalls(this);
        }

        /// <summary>
        /// Коэффициент А.
        /// </summary>
        public int CoefficientA
        {
            get { return this._CoefficientA; }
        }
        /// <summary>
        /// Эффективный диаметр трубопровода в метрах.
        /// </summary>
        public double Diameter
        {
            get { return this._Diameter; }
        }
        /// <summary>
        /// Внешний диаметр трубопровода в метрах.
        /// </summary>
        public double ExternalDiameter
        {
            get { return this.Diameter + 2*this._Width; }
        }
        /// <summary>
        /// Суммарный коэффициент местных сопротивлений.
        /// </summary>
        public double FactorOfLocalResistance
        {
            get { return this._FactorOfLocalResistance; }
        }
        /// <summary>
        /// Длина трубопровода в метрах.
        /// </summary>
        public double Length
        {
            get { return this._Length; }
            protected set { this.SetLength(value); }
        }
        /// <summary>
        /// ID материала, из которого изготовен трубопровод.
        /// </summary>
        public int MaterialId
        {
            get { return this._MaterialId; }
            protected set { this.SetMaterial(value); }
        }
        /// <summary>
        /// Относительная шероховатость стенок трубопровода.
        /// </summary>
        public double RelativeRoughness
        {
            get { return this.RoughnessOfWalls/this.Diameter; }
        }
        /// <summary>
        /// Среднее значение шероховатости стенок трубы в миллиметрах.
        /// </summary>
        public double RoughnessOfWalls
        {
            get { return this._RoughnessOfWalls; }
        }
        /// <summary>
        /// Коэффициент теплопроводности трубопровода в Вт/(м*К).
        /// </summary>
        public double ThermalConductivity
        {
            get { return this._ThermalConductivity; }
        }
        /// <summary>
        /// Тип трубопровода.
        /// </summary>
        public int Type
        {
            get { return this._Type; }
        }
        /// <summary>
        /// Добавление местного сопротивления в трубопровод.
        /// </summary>
        /// <param name="argv">Список параметров. 1 элемент - тип местного сопротивления, 2 и 3 элементы - дополнительные параметры.</param>
        /// <returns>Возвращает логическое выражение: true - успешное добавление, иначе false.</returns>
        public bool AddLocalResistance(string argv)
        {
            var typeStr = argv.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var type = new double[typeStr.Length];
            for (var i = 0; i < typeStr.Length; i++)
            {
                type[i] = Convert.ToDouble(typeStr[i]);
            }
            if (type.Length == 0 | type.Length > 3)
                return false;
            this._FactorOfLocalResistance += Calculation.FactorOfLocalResistance(type);
            return true;
        }
        /// <summary>
        /// Добавление местного сопротивления в трубопровод по его коэффициенту.
        /// </summary>
        /// <param name="koef">Значение коэффициента местного сопротивления.</param>
        /// <returns>Возвращает логическое выражение: true - успешное добавление, иначе false.</returns>
        public bool AddLocalResistance(double koef)
        {
            if (koef <= 0)
                return false;
            this._FactorOfLocalResistance += koef;
            return true;
        }
        /// <summary>
        /// Задает диаметр трубопровода в метрах.
        /// </summary>
        /// <param name="square">Площадь поперечного сечения трубопровода в квадратных метрах.</param>
        /// <param name="perimeter">Величина смоченного периметра в метрах.</param>
        protected void SetDiameter(double square, double perimeter)
        {
            this._Diameter = 4 * square / perimeter;
        }
        /// <summary>
        /// Задает длину трубопровода в метрах.
        /// </summary>
        /// <param name="length">Длина трубопровода в метрах.</param>
        protected void SetLength(double length)
        {
            this._Length = length;
        }
        /// <summary>
        /// Задает материал, из которого изготовлен трубопровод.
        /// </summary>
        /// <param name="materialId">ID материала.</param>
        protected void SetMaterial(int materialId)
        {
            this._MaterialId = materialId;
        }
    }
}
