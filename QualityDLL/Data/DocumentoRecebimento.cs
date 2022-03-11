using System;

namespace Data
{
    //[Serializable]
    public class DocumentoRecebimento : Base
    {
        public DocumentoRecebimento()
            : base()
        {
        }

        private int m_IdDocumentoRecebimento;
        public int idDocumentoRecebimento
        {
            get { return this.m_IdDocumentoRecebimento; }
            set { this.m_IdDocumentoRecebimento = value; }
        }
        private ContaPagamentoMovimento m_IdContaPagamentoMovimento;
        public ContaPagamentoMovimento contaPagamentoMovimento
        {
            get { return this.m_IdContaPagamentoMovimento; }
            set { this.m_IdContaPagamentoMovimento = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

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

        private double m_ValorRecebido;
        public double valorRecebido
        {
            get { return this.m_ValorRecebido; }
            set { this.m_ValorRecebido = value; }
        }

        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private DateTime m_DataVencimento;
        public DateTime dataVencimento
        {
            get { return this.m_DataVencimento; }
            set { this.m_DataVencimento = value; }
        }

        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento idContaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        //idDocumentoRecebimento
        private DocumentoRecebimentoContasAReceber[] m_DocumentoRecebimentoContasARecebers;
        public DocumentoRecebimentoContasAReceber[] documentoRecebimentoContasARecebers
        {
            get { return this.m_DocumentoRecebimentoContasARecebers; }
            set { this.m_DocumentoRecebimentoContasARecebers = value; }
        }

        //idDocumentoRecebimento
        private ContaPagamentoMovimento[] m_ContaPagamentoMovimentos;
        public ContaPagamentoMovimento[] contaPagamentoMovimentos
        {
            get { return this.m_ContaPagamentoMovimentos; }
            set { this.m_ContaPagamentoMovimentos = value; }
        }
    }
}
