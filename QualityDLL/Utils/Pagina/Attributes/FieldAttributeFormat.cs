using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TFieldAttributeFormat : System.Attribute
    {
        private String m_ViewFormat;
        private String m_EditFormat;
        private Boolean m_UseDecimalPlaces;
        private Boolean m_ShowField;

        public TFieldAttributeFormat(String viewFormat, String editFormat = null, string showField = "s")
        {
            this.m_ViewFormat = viewFormat;
            this.m_EditFormat = editFormat;
            this.m_UseDecimalPlaces = true;
            this.m_ShowField = showField.ToLower() == "s";
        }

        public TFieldAttributeFormat(String viewFormat, String editFormat, Boolean useDecimalPlaces)
        {
            this.m_ViewFormat = viewFormat;
            this.m_EditFormat = editFormat;
            this.m_UseDecimalPlaces = useDecimalPlaces;
            this.m_ShowField = true;
        }

        public String viewFormat
        {
            get { return this.m_ViewFormat; }
        }

        public String editFormat
        {
            get { return this.m_EditFormat; }
        }

        public Boolean useDecimalPlaces
        {
            get { return this.m_UseDecimalPlaces; }
        }

        public Boolean showField
        {
            get { return this.m_ShowField; }
        }
    }
}
