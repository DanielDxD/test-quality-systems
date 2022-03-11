using System;

namespace Utils.Pagina.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TFieldAttributeSubfield : System.Attribute
    {
        private String m_SubFieldName;
        private Boolean m_CargaParcial;

        public TFieldAttributeSubfield(String subFieldName)
        {
            this.m_SubFieldName = subFieldName;
            this.m_CargaParcial = false;
        }

        public TFieldAttributeSubfield(String subFieldName, Boolean cargaParcial)
        {
            this.m_SubFieldName = subFieldName;
            this.m_CargaParcial = cargaParcial;
        }

        public String subFieldName
        {
            get { return this.m_SubFieldName; }
        }

        public Boolean cargaParcial
        {
            get { return this.m_CargaParcial; }
        }
    }
}
