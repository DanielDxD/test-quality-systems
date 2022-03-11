using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldVarbinary : TField
    {
        public TFieldVarbinary()
            : base()
        {
            base.type = System.Data.SqlDbType.VarBinary;
        }

        public TFieldVarbinary(String name, byte[] value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.VarBinary;
        }

        internal override Object internalValue
        {
            set { base.internalValue = value; }
        }

        public new byte[] value
        {
            get { return base.isNull ? new byte[0] : (byte[])base.value; }
            set { base.value = value; }
        }
    }
}

