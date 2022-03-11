using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldBigInteger : TField
    {
        public TFieldBigInteger()
            : base()
        {
            base.type = System.Data.SqlDbType.BigInt;
        }

        public TFieldBigInteger(String name, Int64 value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.BigInt;
        }

        internal override Object internalValue
        {
            set { base.internalValue = value; }
        }

        public new Int64 value
        {
            get { return base.isNull ? 0 : Convert.ToInt64(base.value); }
            set { base.value = value; }
        }
    }
}
