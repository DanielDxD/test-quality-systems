using System;

namespace EJB.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TTable : System.Attribute
    {
        private String m_Value;

        public TTable(String value)
        {
            this.m_Value = value;
        }

        public String value
        {
            get { return this.m_Value; }
        }
    }
}
