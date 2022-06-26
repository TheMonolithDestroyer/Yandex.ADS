using System;

namespace Yandex.Exceptions
{
    public class UnderflowException : Exception
    {
        public UnderflowException(string message): base(message)
        {
        }
    }
}