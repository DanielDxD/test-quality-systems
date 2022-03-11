using System;

namespace Data
{
    //[Serializable]
    public class ContasAPagarPagamento : Base
    {
        public ContasAPagarPagamento()
            : base()
        {
        }

        private int m_IdContasAPagarPagamento;
        public int idContasAPagarPagamento
        {
            get { return this.m_IdContasAPagarPagamento; }
            set { this.m_IdContasAPagarPagamento = value; }
        }

        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private double m_ValorPrincipal;
        public double valorPrincipal
        {
            get { return this.m_ValorPrincipal; }
            set { this.m_ValorPrincipal = value; }
        }

        private double m_ValorMulta;
        public double valorMulta
        {
            get { return this.m_ValorMulta; }
            set { this.m_ValorMulta = value; }
        }

        private double m_ValorJuros;
        public double valorJuros
        {
            get { return this.m_ValorJuros; }
            set { this.m_ValorJuros = value; }
        }

        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private double m_ValorCM;
        public double valorCM
        {
            get { return this.m_ValorCM; }
            set { this.m_ValorCM = value; }
        }

        private int m_IdContasAPagar;
        public int idContasAPagar
        {
            get { return this.m_IdContasAPagar; }
            set { this.m_IdContasAPagar = value; }
        }

        private int m_IdFuncionario;
        public int idFuncionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        private double m_ValorINSSRetido;
        public double valorINSSRetido
        {
            get { return this.m_ValorINSSRetido; }
            set { this.m_ValorINSSRetido = value; }
        }

        private double m_ValorISSRetido;
        public double valorISSRetido
        {
            get { return this.m_ValorISSRetido; }
            set { this.m_ValorISSRetido = value; }
        }

        private double m_ValorIRRetido;
        public double valorIRRetido
        {
            get { return this.m_ValorIRRetido; }
            set { this.m_ValorIRRetido = value; }
        }

        private double m_ValorPISRetido;
        public double valorPISRetido
        {
            get { return this.m_ValorPISRetido; }
            set { this.m_ValorPISRetido = value; }
        }

        private double m_ValorCOFINSRetido;
        public double valorCOFINSRetido
        {
            get { return this.m_ValorCOFINSRetido; }
            set { this.m_ValorCOFINSRetido = value; }
        }

        private double m_ValorCSLLRetido;
        public double valorCSLLRetido
        {
            get { return this.m_ValorCSLLRetido; }
            set { this.m_ValorCSLLRetido = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        private int m_IdDocumentoPagamento2;
        public int idDocumentoPagamento
        {
            get { return this.m_IdDocumentoPagamento2; }
            set { this.m_IdDocumentoPagamento2 = value; }
        }

        private DocumentoPagamento m_IdDocumentoPagamento;
        public DocumentoPagamento documentoPagamento
        {
            get { return this.m_IdDocumentoPagamento; }
            set { this.m_IdDocumentoPagamento = value; }
        }

        public override string ToString()
        {
            return this.m_IdContasAPagarPagamento.ToString();
        }
    }
}
