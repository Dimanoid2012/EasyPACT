﻿using System;
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
        protected double _Efficiency;
        /// <summary>
        /// Производительность насоса в м3/с.
        /// </summary>
        protected double _Productivity;
        /// <summary>
        /// Напор насоса в м столба жидкости.
        /// </summary>
        protected double _Pressure;
        /// <summary>
        /// Частота вращения вала в об/с.
        /// </summary>
        protected double _FrequencyOfRotation;
        /// <summary>
        /// Тип электродвигателя.
        /// </summary>
        public readonly string MotorType;
        /// <summary>
        /// Номинальная мощность электродвигателя в кВт.
        /// </summary>
        protected double _MotorCapacity;
        /// <summary>
        /// КПД электродвигателя.
        /// </summary>
        protected double _MotorEfficiency;

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
            this._Efficiency = Convert.ToDouble(list[4][0]);
            this.MotorType = list[5][0];
            this._MotorCapacity = Convert.ToDouble(list[6][0]);
            this._MotorEfficiency = Convert.ToDouble(list[7][0]);
        }
        /// <summary>
        /// Пуск насоса с заданной частотой вращения.
        /// </summary>
        /// <param name="frequency">Частота вращения в об/мин.</param>
        public void Run(double frequency)
        {
            frequency /= 60;
            this._FrequencyOfRotation = frequency;
            this._Productivity = this._OptimalProductivity*frequency/this._OptimalFrequencyOfRotation;
            this._Pressure = this._OptimalPressure*Math.Pow(frequency/this._OptimalFrequencyOfRotation, 2);
            Network.Get().SetProductivity(this._Productivity);
        }
        public void SetProductivity(double V)
        {
            this._Productivity = V;
            this._FrequencyOfRotation = this._Productivity*this._OptimalFrequencyOfRotation/this._OptimalProductivity;
            this._Pressure = this._OptimalPressure*
                             Math.Pow(this._FrequencyOfRotation/this._OptimalFrequencyOfRotation, 2);
            //Network.Get().SetProductivity(this, this._Productivity);
        }
    }
}
