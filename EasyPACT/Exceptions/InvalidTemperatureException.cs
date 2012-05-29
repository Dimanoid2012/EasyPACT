using System;

namespace EasyPACT.Exceptions
{
    class InvalidTemperatureException:Exception
    {
        public InvalidTemperatureException(string message):base(message) {}
    }
}
