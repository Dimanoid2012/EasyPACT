using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPACT
{
    /// <summary>
    /// Класс, описывающий центробежный насос.
    /// </summary>
    class CentrifugalPump
    {
        /// <summary>
        /// Марка насоса.
        /// </summary>
        public readonly string Brand;
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
        /// КПД насоса.
        /// </summary>
        protected double _Efficiency;
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

        private CentrifugalPump() { }

        /// <summary>
        /// Центробежный насос.
        /// </summary>
        /// <param name="brand">Марка насоса.</param>
        /// <param name="Q">Производительность насоса в м3/с.</param>
        /// <param name="H">Напор насоса в м столба жидкости.</param>
        /// <param name="n">Частота вращения вала в об/с.</param>
        /// <param name="nPump">КПД насоса.</param>
        /// <param name="motorType">Тип электродвигателя.</param>
        /// <param name="N">Номинальная мощность электродвигателя в кВт.</param>
        /// <param name="nMotor">КПД электродвигателя.</param>
        public CentrifugalPump(string brand, double Q, double H, double n, double nPump, string motorType, double N, double nMotor)
        {
            this.Brand = brand;
            this._Productivity = Q;
            this._Pressure = H;
            this._FrequencyOfRotation = n;
            this._Efficiency = nPump;
            this.MotorType = motorType;
            this._MotorCapacity = N;
            this._MotorEfficiency = nMotor;
        }

    }
}
