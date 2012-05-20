using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPACT
{
    /// <summary>
    /// Класс, описывающий систему целиком и обеспечивающий
    /// взаимодействие между объектами. Одиночка.
    /// </summary>
    public sealed class Network
    {
        /// <summary>
        /// Единственный объект класса Network.
        /// </summary>
        private static Network _network;
        /// <summary>
        /// Флаг проверки, существует ли уже сеть.
        /// </summary>
        private static bool _isExist;

        /// <summary>
        /// Всасывающая линия.
        /// </summary>
        public LiquidInPipeline VacuumLine { get; private set; }

        /// <summary>
        /// Нагнетающая линия.
        /// </summary>
        public LiquidInPipeline ForcingLine { get; private set; }

        /// <summary>
        /// Насос.
        /// </summary>
        public CentrifugalPump Pump { get; private set; }
        /// <summary>
        /// Производительность сети в м3/с.
        /// </summary>
        public double Productivity { get; private set; }

        private Network() { }

        /// <summary>
        /// Пытается создать объект сети, если его не существует, иначе возвращает существующий объект.
        /// </summary>
        /// <param name="vacuumLine">Всасывающая линия.</param>
        /// <param name="forcingLine">Нагнетающая линия.</param>
        /// <param name="pump">Насос.</param>
        /// <returns>Возвращает новый или существующий объект сети.</returns>
        public static Network Create(LiquidInPipeline vacuumLine, LiquidInPipeline forcingLine, CentrifugalPump pump)
        {
            if (_isExist)
                return _network;
            var network = new Network { VacuumLine = vacuumLine, ForcingLine = forcingLine, Pump = pump };
            _network = network;
            _isExist = true;
            return network;
        }
        /// <summary>
        /// Возвращает объект сети, если он уже создан, либо null, если его нет.
        /// </summary>
        /// <returns>Возвращает объект сети, если он уже создан, либо null, если его нет.</returns>
        public static Network Get()
        {
            return _isExist ? _network : null;
        }
        /// <summary>
        /// Устанавливает производительность сети. Вызвать может только насос, установленный в сети.
        /// </summary>
        /// <param name="pump">Насос.</param>
        /// <param name="productivity">Новая производительность.</param>
        public bool SetProductivity(CentrifugalPump pump, double productivity)
        {
            if (pump != this.Pump)
                return false;
            this.Productivity = productivity;
            return true;
        }
    }
}
