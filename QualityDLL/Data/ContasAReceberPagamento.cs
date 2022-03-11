using System;

namespace Data
{
    //[Serializable]
    public class ContasAReceberPagamento : Base
    {
        public ContasAReceberPagamento() : base()
        {
        }

        private int m_IdContasAReceberPagamento;
        public int idContasAReceberPagamento
        {
            get { return this.m_IdContasAReceberPagamento; }
            set { this.m_IdContasAReceberPagamento = value; }
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

        private bool m_Conciliar;
        public bool conciliar
        {
            get { return this.m_Conciliar; }
            set { this.m_Conciliar = value; }
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

        private int m_IdContasAReceber;
        public int idContasAReceber
        {
            get { return this.m_IdContasAReceber; }
            set { this.m_IdContasAReceber = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private bool m_IgnorarRecibo;
        public bool ignorarRecibo
        {
            get { return this.m_IgnorarRecibo; }
            set { this.m_IgnorarRecibo = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        private PdvCompraTaxaServico m_IdPdvCompraTaxaServico;
        public PdvCompraTaxaServico pdvCompraTaxaServico
        {
            get { return this.m_IdPdvCompraTaxaServico; }
            set { this.m_IdPdvCompraTaxaServico = value; }
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

        private int m_IdDocumentoRecebimento2;
        public int idDocumentoRecebimento
        {
            get { return this.m_IdDocumentoRecebimento2; }
            set { this.m_IdDocumentoRecebimento2 = value; }
        }

        private Data.DocumentoRecebimento m_IdDocumentoRecebimento;
        public DocumentoRecebimento documentoRecebimento
        {
            get { return this.m_IdDocumentoRecebimento; }
            set { this.m_IdDocumentoRecebimento = value; }
        }

        private int m_IdPdvEstacao;
        public int idPdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        private PdvCompra m_IdPdvCompra;
        public PdvCompra pdvCompra
        {
            get { return this.m_IdPdvCompra; }
            set { this.m_IdPdvCompra = value; }
        }

        private int m_IdFuncionario;
        public int idFuncionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }

        private ContasAReceberRecibo m_IdContasAReceberRecibo;
        public ContasAReceberRecibo contasAReceberRecibo
        {

            get { return this.m_IdContasAReceberRecibo; }
            set { this.m_IdContasAReceberRecibo = value; }
        }

        public override string ToString()
        {
            return this.m_IdContasAReceberPagamento.ToString();
        }
    }
}
