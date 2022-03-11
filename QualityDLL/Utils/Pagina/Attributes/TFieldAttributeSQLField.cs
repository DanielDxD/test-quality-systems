using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TFieldAttributeSQLField : System.Attribute
    {
        private String m_SQLField;

        public TFieldAttributeSQLField(String sqlField)
        {
            this.m_SQLField = sqlField;
        }

        public String sqlField
        {
            get { return this.m_SQLField; }
        }
    }
}