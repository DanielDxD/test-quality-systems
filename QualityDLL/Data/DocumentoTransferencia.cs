using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class DocumentoTransferencia : Base
    {
        public DocumentoTransferencia()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdDocumentoTransferencia;
        public int idDocumentoTransferencia
        {
            get { return this.m_IdDocumentoTransferencia; }
            set { this.m_IdDocumentoTransferencia = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 300)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Data Geração", 103),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataGeracao;
        public DateTime dataGeracao
        {
            get { return this.m_DataGeracao; }
            set { this.m_DataGeracao = value; }
        }

        private String m_NumeroDocumento;
        public String numeroDocumento
        {
            get { return this.m_NumeroDocumento; }
            set { this.m_NumeroDocumento = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 120),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_ValorTransferido;
        public double valorTransferido
        {
            get { return this.m_ValorTransferido; }
            set { this.m_ValorTransferido = value; }
        }

        [
            TFieldAttributeGridDisplay("Data Movimento", 103),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private ContaPagamento m_IdContaPagamentoOrigem;
        public ContaPagamento contaPagamentoOrigem
        {
            get { return this.m_IdContaPagamentoOrigem; }
            set { this.m_IdContaPagamentoOrigem = value; }
        }

        private ContaPagamento m_IdContaPagamentoDestino;
        public ContaPagamento contaPagamentoDestino
        {
            get { return this.m_IdContaPagamentoDestino; }
            set { this.m_IdContaPagamentoDestino = value; }
        }

        //idDocumentoTransferencia
        private DocumentoTransferenciaItem[] m_DocumentoTransferenciaItems;
        public DocumentoTransferenciaItem[] documentoTransferenciaItems
        {
            get { return this.m_DocumentoTransferenciaItems; }
            set { this.m_DocumentoTransferenciaItems = value; }
        }
    }
}
