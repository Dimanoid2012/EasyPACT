using System;

namespace EasyPACT.Exceptions
{
    class InvalidPressureException : Exception
    {
        public InvalidPressureException(string message) : base(message) { }
    }
}

