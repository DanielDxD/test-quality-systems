using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class TClassAttributeEdit : System.Attribute
    {
        private int m_Columns;

        public TClassAttributeEdit(int columns)
        {
            this.m_Columns = columns;
        }

        public int columns
        {
            get { return this.m_Columns; }
        }
    }
}
