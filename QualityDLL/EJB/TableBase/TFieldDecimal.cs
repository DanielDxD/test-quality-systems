using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldDecimal : TField
    {
        public TFieldDecimal()
            : base()
        {
            base.type = System.Data.SqlDbType.Decimal;
        }

        public TFieldDecimal(String name, Decimal value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.Decimal;
        }

        internal override Object internalValue
        {
            set { base.internalValue = value; }
        }

        public new decimal value
        {
            get { return (base.isNull ? (decimal)0.0 : Convert.ToDecimal(base.value)); }
            set { base.value = value; }
        }
    }
}
