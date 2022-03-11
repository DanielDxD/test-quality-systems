using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldInteger : TField
    {
        public TFieldInteger()
            : base()
        {
            base.type = System.Data.SqlDbType.Int;
        }

        public TFieldInteger(String name, int value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.Int;
        }

        internal override Object internalValue
        {
            set { base.internalValue = value; }
        }

        public new int value
        {
            get { return base.isNull ? 0 : Convert.ToInt32(base.value); }
            set { base.value = value; }
        }
    }
}
