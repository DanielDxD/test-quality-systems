using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldBoolean : TField
    {
        public TFieldBoolean()
            : base()
        {
            base.type = System.Data.SqlDbType.Bit;
        }

        public TFieldBoolean(String name, Boolean value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.Bit;
        }

        internal override Object internalValue
        {
            set { base.internalValue = value; }
        }

        public new bool value
        {
            get { return base.isNull ? false : Convert.ToBoolean(base.value); }
            set { base.value = value; }
        }
    }
}
