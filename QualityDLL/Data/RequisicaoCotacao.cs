using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class RequisicaoCotacao: Base
	{
		public RequisicaoCotacao(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID Compra", 105),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoCompra;
        public int idRequisicaoCompra
        {
            get { return this.m_IdRequisicaoCompra; }
            set { this.m_IdRequisicaoCompra = value; }
        }

        [
            TFieldAttributeGridDisplay("ID Cotação", 105),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoCotacao;
		public int idRequisicaoCotacao
		{
			get{return this.m_IdRequisicaoCotacao;}
			set{this.m_IdRequisicaoCotacao = value;}
        }

        private DateTime m_DataCotacao;
        public DateTime dataCotacao
        {
            get { return this.m_DataCotacao; }
            set { this.m_DataCotacao = value; }
        }

        private DateTime m_DataPrevisaoPagamento;
        public DateTime dataPrevisaoPagamento
        {
            get { return this.m_DataPrevisaoPagamento; }
            set { this.m_DataPrevisaoPagamento = value; }
        }

        private DateTime m_DataRespostaCotacao;
        public DateTime dataRespostaCotacao
        {
            get { return this.m_DataRespostaCotacao; }
            set { this.m_DataRespostaCotacao = value; }
        }

        private double m_valorFrete;
        public double valorFrete
        {
            get { return this.m_valorFrete; }
            set { this.m_valorFrete = value; }
        }

        private string m_observacao;
        public string observacao
        {
            get { return this.m_observacao; }
            set { this.m_observacao = value; }
        }


        private double m_valorDesconto;
        public double valorDesconto
        {
            get { return this.m_valorDesconto; }
            set { this.m_valorDesconto = value; }
        }

        private string m_PrazoEntrega;
		public string prazoEntrega
		{
			get{return this.m_PrazoEntrega;}
			set{this.m_PrazoEntrega = value;}
		}

        [
            TFieldAttributeGridDisplay("Fornecedor", 260),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idFornecedor:pessoa.nomeRazaoSocial")
        ]
        private Fornecedor m_IdFornecedor;
		public Fornecedor fornecedor
		{
			get{return this.m_IdFornecedor;}
			set{this.m_IdFornecedor = value;}
		}

        [
            TFieldAttributeGridDisplay("CPF/CNPJ", 160),
            TFieldAttributeData(6, true),
        ]
        private string m_CpfCnpj;
        public string cpfCnpj
        {
            get { return this.m_CpfCnpj; }
            set { this.m_CpfCnpj = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 240)
        ]
        private String m_descricao;
        public String descricao
        {
            get { return this.m_descricao; }
            set { this.m_descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 100),
            TFieldAttributeData(6, true),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        [
            TFieldAttributeGridDisplay("Preenchida", 100)
        ]
        private bool m_Preenchida;
        public bool preenchida
        {
            get { return this.m_Preenchida; }
            set { this.m_Preenchida = value; }
        }

        private CondicaoPagamento m_IdCondicaoPagamento;
		public CondicaoPagamento condicaoPagamento
		{
			get{return this.m_IdCondicaoPagamento;}
			set{this.m_IdCondicaoPagamento = value;}
		}

        //idRequisicaoCotacao
        private RequisicaoCotacaoProdutoServico[] m_RequisicaoCotacaoProdutoServicos;
        public RequisicaoCotacaoProdutoServico[] requisicaoCotacaoProdutoServicos
        {
            get{return this.m_RequisicaoCotacaoProdutoServicos;}
            set{this.m_RequisicaoCotacaoProdutoServicos = value;}
        }

        public override string ToString()
        {
            return this.m_IdRequisicaoCotacao.ToString();
        }
    }
}
