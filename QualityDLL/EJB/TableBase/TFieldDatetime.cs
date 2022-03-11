using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldDatetime : TField
    {
        public TFieldDatetime()
            : base()
        {
            base.type = System.Data.SqlDbType.DateTime;
        }

        public TFieldDatetime(String name, DateTime value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.DateTime;
        }

        internal override Object internalValue
        {
            set { base.internalValue = value; }
        }

        public new DateTime value
        {
            get { return base.isNull ? new DateTime(0) : Convert.ToDateTime(base.value); }
            set
            {
                if (value.Ticks <= 0)
                    base.isNull = true;
                else
                    base.value = value;
            }
        }
    }
}
