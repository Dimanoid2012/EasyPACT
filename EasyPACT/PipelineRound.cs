using System;
namespace EasyPACT
{
    /// <summary>
    /// Данный класс описывает материал, размеры
    /// и прочие особенности трубопровода круглого сечения.
    /// </summary>
    class PipelineRound:Pipeline
    {
        /// <summary>
        /// Данный класс описывает материал, размеры
        /// и прочие особенности трубопровода круглого сечения.
        /// </summary>
        /// <param name="materialId">Материал, из которого изготовлен трубопровод.</param>
        /// <param name="type">Тип трубопровода.</param>
        /// <param name="diameter">Диаметр трубопровода в метрах.</param>
        /// <param name="width">Толщина стенок в метрах.</param>
        /// <param name="length">Длина трубопровода в метрах.</param>
        public PipelineRound(int materialId, int type, double diameter, double width, double length)
            : base(materialId, type, Math.PI * Math.Pow(diameter - 2 * width, 2) / 4.0, Math.PI * (diameter - 2 * width), width, length)
        {
            this._CoefficientA = 64;
        }
    }
}
