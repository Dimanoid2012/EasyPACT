using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPACT
{
    /// <summary>
    /// Класс, описывающий центробежный насос.
    /// </summary>
    public class CentrifugalPump
    {
        /// <summary>
        /// Марка насоса.
        /// </summary>
        public readonly string Brand;
        /// <summary>
        /// Оптимальная производительность насоса в м3/с.
        /// </summary>
        protected double _OptimalProductivity;
        /// <summary>
        /// Оптимальный напор насоса в м столба жидкости.
        /// </summary>
        protected double _OptimalPressure;
        /// <summary>
        /// Оптимальная частота вращения вала в об/с.
        /// </summary>
        protected double _OptimalFrequencyOfRotation;

        /// <summary>
        /// КПД насоса.
        /// </summary>
        public double Efficiency { get; private set; }
        /// <summary>
        /// Производительность насоса в м3/с.
        /// </summary>
        public double Productivity { get; private set; }
        /// <summary>
        /// Напор насоса в м столба жидкости.
        /// </summary>
        public double Pressure { get; private set; }
        /// <summary>
        /// Частота вращения вала в об/с.
        /// </summary>
        public double FrequencyOfRotation { get; private set; }
        /// <summary>
        /// Тип электродвигателя.
        /// </summary>
        public string MotorType { get; private set; }
        /// <summary>
        /// Номинальная мощность электродвигателя в кВт.
        /// </summary>
        protected double _MotorCapacity;
        /// <summary>
        /// КПД электродвигателя.
        /// </summary>
        public double MotorEfficiency { get; private set; }

        public double Capacity
        {
            get
            {
                return _MotorCapacity / Efficiency;
            }
        }

        /// <summary>
        /// Центробежный насос.
        /// </summary>
        /// <param name="id">Идентификатор насоса.</param>
        public CentrifugalPump (int id)
        {
            var list =
                Database.Query(
                    String.Format(
                        "SELECT brand,productivity,pressure,frequency,efficiency,motor_type,motor_capacity,motor_efficiency FROM centrifugal_pumps WHERE id={0}",
                        id));
            this.Brand = list[0][0];
            this._OptimalProductivity = Convert.ToDouble(list[1][0]);
            this._OptimalPressure = Convert.ToDouble(list[2][0]);
            this._OptimalFrequencyOfRotation = Convert.ToDouble(list[3][0]);
            this.Efficiency = Convert.ToDouble(list[4][0]);
            this.MotorType = list[5][0];
            this._MotorCapacity = Convert.ToDouble(list[6][0]);
            this.MotorEfficiency = Convert.ToDouble(list[7][0]);
        }
        /*/// <summary>
        /// Пуск насоса с заданной частотой вращения.
        /// </summary>
        /// <param name="frequency">Частота вращения в об/мин.</param>
        private void Run(double frequency)
        {
            frequency /= 60;
            this._FrequencyOfRotation = frequency;
            this._Productivity = this._OptimalProductivity*frequency/this._OptimalFrequencyOfRotation;
            this._Pressure = this._OptimalPressure*Math.Pow(frequency/this._OptimalFrequencyOfRotation, 2);
            Network.Get().SetProductivity(this._Productivity);
        }*/
        /// <summary>
        /// Настраивает насос на заданную подачу.
        /// </summary>
        /// <param name="V">Необходимая подача в м3/с.</param>
        public void SetProductivity(double V)
        {
            this.Productivity = V;
            this.FrequencyOfRotation = this.Productivity*this._OptimalFrequencyOfRotation/this._OptimalProductivity;
            this.Pressure = this._OptimalPressure*
                             Math.Pow(this.FrequencyOfRotation/this._OptimalFrequencyOfRotation, 2);
        }
        public override string ToString()
        {
            return "Насос " + Brand + " производительностью " + _OptimalProductivity.ToString()  + " м3/с и напором " + _OptimalPressure.ToString() + " м.";
        }
    }
}
