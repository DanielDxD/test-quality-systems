using System;

namespace Data
{
    //[Serializable]
    public class DocumentoTransferenciaItem : Base
    {
        public DocumentoTransferenciaItem()
            : base()
        {
        }

        private int m_IdDocumentoTransferenciaItem;
        public int idDocumentoTransferenciaItem
        {
            get { return this.m_IdDocumentoTransferenciaItem; }
            set { this.m_IdDocumentoTransferenciaItem = value; }
        }

        private int m_IdDocumentoTransferencia;
        public int idDocumentoTransferencia
        {
            get { return this.m_IdDocumentoTransferencia; }
            set { this.m_IdDocumentoTransferencia = value; }
        }

        private int m_IdDocumentoRecebimentoTransferido;
        public int idDocumentoRecebimentoTransferido
        {
            get { return this.m_IdDocumentoRecebimentoTransferido; }
            set { this.m_IdDocumentoRecebimentoTransferido = value; }
        }

        private int m_IdDocumentoTransferenciaTransferidoItem;
        public int idDocumentoTransferenciaTransferidoItem
        {
            get { return this.m_IdDocumentoTransferenciaTransferidoItem; }
            set { this.m_IdDocumentoTransferenciaTransferidoItem = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }
    }
}
