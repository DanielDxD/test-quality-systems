using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class DocumentoPagamento : Base
    {
        public DocumentoPagamento()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdDocumentoPagamento;
        public int idDocumentoPagamento
        {
            get { return this.m_IdDocumentoPagamento; }
            set { this.m_IdDocumentoPagamento = value; }
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
            TFieldAttributeGridDisplay("Data Geração", 103)
        ]
        private DateTime m_DataGeracao;
        public DateTime dataGeracao
        {
            get { return this.m_DataGeracao; }
            set { this.m_DataGeracao = value; }
        }


        [
            TFieldAttributeGridDisplay("Núm. Documento", 120)
        ]
        private String m_NumeroDocumento;
        public String numeroDocumento
        {
            get { return this.m_NumeroDocumento; }
            set { this.m_NumeroDocumento = value; }
        }

        private String m_SerieDocumento;
        public String serieDocumento
        {
            get { return this.m_SerieDocumento; }
            set { this.m_SerieDocumento = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor Pago", 123),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_ValorPago;
        public double valorPago
        {
            get { return this.m_ValorPago; }
            set { this.m_ValorPago = value; }
        }

        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        private String m_MotivoCancelamento;
        public String motivoCancelamento
        {
            get { return this.m_MotivoCancelamento; }
            set { this.m_MotivoCancelamento = value; }
        }

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

        private TipoDocumento m_IdTipoDocumento;
        public TipoDocumento tipoDocumento
        {
            get { return this.m_IdTipoDocumento; }
            set { this.m_IdTipoDocumento = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        private int m_IdContaPagamento2;
        public int idContaPagamento
        {
            get { return this.m_IdContaPagamento2; }
            set { this.m_IdContaPagamento2 = value; }
        }
        //idDocumentoPagamento
        private DocumentoPagamentoContasAPagar[] m_DocumentoPagamentoContasAPagars;
        public DocumentoPagamentoContasAPagar[] documentoPagamentoContasAPagars
        {
            get { return this.m_DocumentoPagamentoContasAPagars; }
            set { this.m_DocumentoPagamentoContasAPagars = value; }
        }
    }
}