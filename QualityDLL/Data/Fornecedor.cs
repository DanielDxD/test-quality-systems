using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [
        TClassAttributeFields
        (
            new String[] 
                {
                    ".m_IdEmpresaRelacionamento",
                    ".m_IdPessoa"
                }
        ),
        TClassAttributeBusinessIdField("m_IdEmpresa")
    ]
    public class Fornecedor : EmpresaRelacionamento
	{
		public Fornecedor(): base()
		{
		}

		private DateTime m_DataContrato;
		public DateTime dataContrato
		{
			get{return this.m_DataContrato;}
			set{this.m_DataContrato = value;}
        }

        private bool m_RetemISS;
        public bool retemISS
        {
            get { return this.m_RetemISS; }
            set { this.m_RetemISS = value; }
        }

        private RegraContabilizacao m_IdRegraContabilizacao;
        public RegraContabilizacao regraContabilizacao
        {
            get { return this.m_IdRegraContabilizacao; }
            set { this.m_IdRegraContabilizacao = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        private PlanoContas m_IdPlanoContas;
        public PlanoContas planoContas
        {
            get { return this.m_IdPlanoContas; }
            set { this.m_IdPlanoContas = value; }
        }
        
        //idFornecedor
        private ProdutoServicoFornecedor[] m_ProdutoServicoFornecedors;
        public ProdutoServicoFornecedor[] produtoServicoFornecedors
        {
            get{return this.m_ProdutoServicoFornecedors;}
            set{this.m_ProdutoServicoFornecedors = value;}
        }

        //idFornecedor
        private FornecedorLancamentoContabil[] m_FornecedorLancamentoContabils;
        public FornecedorLancamentoContabil[] fornecedorLancamentoContabils
        {
            get{return this.m_FornecedorLancamentoContabils;}
            set{this.m_FornecedorLancamentoContabils = value;}
        }

        public override string ToString()
        {
            return this.idEmpresaRelacionamento.ToString();
        }
    }
}
