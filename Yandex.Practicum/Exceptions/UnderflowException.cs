using System;

namespace Yandex.Practicum.Exceptions
{
    public class ArgumentUnderflowException : Exception
    {
        public ArgumentUnderflowException(string message): base(message)
        {
        }
    }
}