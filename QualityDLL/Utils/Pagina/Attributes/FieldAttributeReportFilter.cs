using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TFieldAttributeReportFilter : System.Attribute
    {
        private String m_FilterName;
        private int m_DisplaySize;
        private Boolean m_AllowInterval;
        private String m_Values;

        public TFieldAttributeReportFilter(String filterName, int displaySize)
        {
            this.m_FilterName = filterName;
            this.m_DisplaySize = displaySize;
            this.m_AllowInterval = false;
            this.m_Values = "";
        }

        public TFieldAttributeReportFilter(String filterName, int displaySize, Boolean allowInterval)
        {
            this.m_FilterName = filterName;
            this.m_DisplaySize = displaySize;
            this.m_AllowInterval = allowInterval;
            this.m_Values = "";
        }

        public TFieldAttributeReportFilter(String filterName, int displaySize, String values)
        {
            this.m_FilterName = filterName;
            this.m_DisplaySize = displaySize;
            this.m_AllowInterval = false;
            this.m_Values = values;
        }

        public String filterName
        {
            get { return this.m_FilterName; }
        }

        public int displaySize
        {
            get { return this.m_DisplaySize; }
        }

        public Boolean allowInterval
        {
            get { return this.m_AllowInterval; }
        }

        public String values
        {
            get { return this.m_Values; }
        }
    }
}
