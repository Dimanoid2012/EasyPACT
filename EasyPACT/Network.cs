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
    sealed class Network
    {
        /// <summary>
        /// Единственный объект класса Network.
        /// </summary>
        private static readonly Network UniqueSystem = new Network();

        /// <summary>
        /// Всасывающая линия.
        /// </summary>
        private Pipeline _vacuumLine;
        /// <summary>
        /// Нагнетающая линия.
        /// </summary>
        private Pipeline _forcingLine;
        /// <summary>
        /// Насос.
        /// </summary>
        private CentrifugalPump _pump;


        private Network() { }

        public static Network Get()
        {
            return UniqueSystem;
        }
    }
}
