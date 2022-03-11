using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class PermissionDenied : Exception
    {
        public PermissionDenied()
        {
        }

        public PermissionDenied(string message) : base(message)
        {
        }

        public PermissionDenied(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PermissionDenied(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}