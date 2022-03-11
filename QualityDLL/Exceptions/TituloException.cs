using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class TituloException : Exception
    {
        public TituloException()
        {
        }

        public TituloException(string message) : base(message)
        {
        }

        public TituloException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TituloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}