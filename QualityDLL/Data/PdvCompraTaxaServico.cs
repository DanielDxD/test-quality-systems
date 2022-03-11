using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvCompraTaxaServico : Base
    {
        public PdvCompraTaxaServico() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvCompraTaxaServico;
        public int idPdvCompraTaxaServico
        {
            get { return this.m_IdPdvCompraTaxaServico; }
            set { this.m_IdPdvCompraTaxaServico = value; }
        }

        private PdvCompra m_pdvCompra;
        public PdvCompra pdvCompra
        {
            get { return m_pdvCompra; }
            set { this.m_pdvCompra = value; }
        }

        [
            TFieldAttributeGridDisplay("Data", 255 + 155),
            TFieldAttributeData(50, true)
        ]
        private Double m_Valor;
        public Double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }        
    }
}
