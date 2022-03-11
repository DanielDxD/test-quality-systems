using System;
using System.Text;

namespace EJB.TableBase
{
    public class TFieldBlob : TField
	{
        public TFieldBlob(): base()
		{
            base.type = System.Data.SqlDbType.Image;
        }

        public TFieldBlob(String name, int value): base()
        {
            base.name = name;
            base.value = value;
            base.type = System.Data.SqlDbType.Image;
        }

        internal override Object internalValue
        {
            set 
            {
                if (value.GetType().IsInstanceOfType(typeof(System.Drawing.Image)))
                    base.internalValue = value;
                else
                {
                    System.IO.MemoryStream msImage = new System.IO.MemoryStream((Byte[])value);
                    base.internalValue = System.Drawing.Image.FromStream(msImage);
                }
            }
        }

        public new System.Drawing.Image value
        {
            get { return base.isNull ? null : (System.Drawing.Image)base.value; }
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
