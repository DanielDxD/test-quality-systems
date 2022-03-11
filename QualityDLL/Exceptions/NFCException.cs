using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class NFCException : Exception
    {
        public NFCException() : base() { }

        public NFCException(String message) : base(message) { }

        public NFCException(String message, Exception innerException) : base(message, innerException) { }

        public NFCException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class NFCContingencia : Exception
    {
        public NFCContingencia() : base() { }

        public NFCContingencia(String message) : base(message) { }

        public NFCContingencia(String message, Exception innerException) : base(message, innerException) { }

        public NFCContingencia(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
