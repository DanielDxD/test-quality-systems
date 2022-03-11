using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class TClassAttributeFields : System.Attribute
    {
        private String[] m_Fields;

        public TClassAttributeFields(String[] fields)
        {
            this.m_Fields = fields;
        }

        public String[] fields
        {
            get { return this.m_Fields; }
        }
    }
}
