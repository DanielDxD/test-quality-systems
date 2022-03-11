using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class ThrowIfCancellationRequested : Exception
    {
        public ThrowIfCancellationRequested()
        {
        }

        public ThrowIfCancellationRequested(string message) : base(message)
        {
        }

        public ThrowIfCancellationRequested(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThrowIfCancellationRequested(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}