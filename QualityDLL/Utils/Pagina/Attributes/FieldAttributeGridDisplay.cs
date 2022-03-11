using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TFieldAttributeGridDisplay : System.Attribute
    {
        private String m_DisplayText;
        private int m_DisplaySize;

        public TFieldAttributeGridDisplay(String displayText, int displaySize)
        {
            this.m_DisplayText = displayText;
            this.m_DisplaySize = displaySize;
        }

        public String displayText
        {
            get { return this.m_DisplayText; }
        }

        public int displaySize
        {
            get { return this.m_DisplaySize; }
        }
    }
}
