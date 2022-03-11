using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TFieldAttributeData : System.Attribute
    {
        private int m_Length;
        private bool m_Required;
        private bool m_Enabled;
        private bool m_OboutDropbox;

        public TFieldAttributeData(int length, bool required)
        {
            this.m_Length = length;
            this.m_Required = required;
            this.m_Enabled = true;
            this.m_OboutDropbox = true;
        }

        public TFieldAttributeData(int length, bool required, bool enabled, bool oboutDropBox = true)
        {
            this.m_Length = length;
            this.m_Required = required;
            this.m_Enabled = enabled;
            this.m_OboutDropbox = oboutDropBox;
        }

        public int length
        {
            get { return this.m_Length; }
        }

        public bool required
        {
            get { return this.m_Required; }
        }

        public bool enabled
        {
            get { return this.m_Enabled; }
        }

        public bool oboutDropBox
        {
            get { return this.m_OboutDropbox; }
        }
    }
}
