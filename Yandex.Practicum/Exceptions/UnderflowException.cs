using System;

namespace Yandex.Practicum.Exceptions
{
    public class UnderflowException : Exception
    {
        public UnderflowException(string message): base(message)
        {
        }
    }
}