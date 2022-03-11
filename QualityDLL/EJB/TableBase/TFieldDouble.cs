using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldDouble : TField
    {
        public TFieldDouble()
            : base()
        {
            base.type = System.Data.SqlDbType.Decimal;
        }

        public TFieldDouble(String name, Double value)
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

        public new double value
        {
            get { return (base.isNull ? 0.0 : Convert.ToDouble(base.value)); }
            set { base.value = value; }
        }
    }
}
