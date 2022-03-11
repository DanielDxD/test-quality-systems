using System;

namespace EJB.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class TList : System.Attribute
    {
        private System.Type m_Value;

        public TList(System.Type value)
        {
            this.m_Value = value;
        }

        public System.Type value
        {
            get { return this.m_Value; }
        }
    }
}
