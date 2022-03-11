using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldString : TField
    {
        public TFieldString()
            : base()
        {
            base.type = System.Data.SqlDbType.VarChar;
        }

        public TFieldString(String name, String value)
            : base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.VarChar;
        }

        internal override Object internalValue
        {
            set 
            {
                if (value != null)
                    value = ((string)value).TrimEnd(new char[] { '\0' }).Trim().TrimEnd(new char[] { '\0' });
                else { }

                base.internalValue = value;
            }
        }

        public new String value
        {
            get { return base.isNull ? null : (String)base.value; }
            set
            {
                if (value == null)
                {
                    base.value = null;
                    base.isNull = true;
                }
                else
                    base.value = value;
            }
        }
    }
}
