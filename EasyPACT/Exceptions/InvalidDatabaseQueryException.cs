using System;

namespace EasyPACT.Exceptions
{
    class InvalidDatabaseQueryException : Exception
    {
        public InvalidDatabaseQueryException(string message) : base(message) { }
    }
}
