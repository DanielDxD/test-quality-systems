using System;

namespace Data
{
    //[Serializable]
    public class NotaFiscalEEntradaMercadoria : Base
    {
        public NotaFiscalEEntradaMercadoria()
            : base()
        {
        }


        private int m_IdNotaFiscal;
        public int idNotaFiscal
        {
            get { return this.m_IdNotaFiscal; }
            set { this.m_IdNotaFiscal = value; }
        }

        private int m_IdEntradaMercadoria;
        public int idEntradaMercadoria
        {
            get { return this.m_IdEntradaMercadoria; }
            set { this.m_IdEntradaMercadoria = value; }
        }
    }
}