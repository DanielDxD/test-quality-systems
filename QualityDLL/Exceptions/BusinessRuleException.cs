using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utils
{
    public class BusinessRuleException: Exception
    {
        public BusinessRuleException() : base() { }

        public BusinessRuleException(String message) : base(message) { }

        public BusinessRuleException(String message, Exception innerException) : base(message, innerException) { }

        public BusinessRuleException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}