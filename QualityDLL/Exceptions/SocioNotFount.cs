using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class SocioNotFount : Exception
    {
        public SocioNotFount()
        {
        }

        public SocioNotFount(string message) : base(message)
        {
        }

        public SocioNotFount(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SocioNotFount(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}