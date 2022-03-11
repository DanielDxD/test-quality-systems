using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TClassAttributeBusinessIdField : System.Attribute
    {
        private String m_Field;

        public TClassAttributeBusinessIdField(String field)
        {
            this.m_Field = field;
        }

        public String field
        {
            get { return this.m_Field; }
        }
    }
}
