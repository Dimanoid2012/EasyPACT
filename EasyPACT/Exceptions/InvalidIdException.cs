using System;

namespace EasyPACT.Exceptions
{
    class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message) { }
    }
}
