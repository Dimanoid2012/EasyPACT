using System;

namespace EasyPACT.Exceptions
{
    class InvalidDatabaseConnectionOpenException : Exception
    {
        public InvalidDatabaseConnectionOpenException(string message) : base(message) { }
    }
}
