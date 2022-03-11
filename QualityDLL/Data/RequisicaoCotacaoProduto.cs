using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [TClassAttributeEdit(2)]
	public class RequisicaoCotacaoProdutoServico: Base
	{
		public RequisicaoCotacaoProdutoServico(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoCotacaoProdutoServico;
		public int idRequisicaoCotacaoProdutoServico
		{
			get{return this.m_IdRequisicaoCotacaoProdutoServico;}
			set{this.m_IdRequisicaoCotacaoProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("ProdutoServico", 260),
            TFieldAttributeData(6, true, false),
            TFieldAttributeKey(false, false),
            TFieldAttributeSubfield("idProdutoServico:@ProdutoServico.idProdutoServico.descricao")
        ]
        private int m_IdProdutoServico;
        public int idProdutoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        private ProdutoServico m_ProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_ProdutoServico; }
            set { this.m_ProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Qtd. Pedida", 100),
            TFieldAttributeData(13, true),
            TFieldAttributeKey(false, true),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_QuantidadePedida;
        public double quantidadePedida
		{
            get { return this.m_QuantidadePedida; }
            set { this.m_QuantidadePedida = value; }
		}

        [
            TFieldAttributeGridDisplay("Qtd. Atendida", 100),
            TFieldAttributeData(13, false),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_QuantidadeAtendida;
        public double quantidadeAtendida
        {
            get { return this.m_QuantidadeAtendida; }
            set { this.m_QuantidadeAtendida = value; }
        }

        [
            TFieldAttributeGridDisplay("Vlr. Unitário", 100),
            TFieldAttributeData(18, false),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private int m_IdRequisicaoCotacao;
		public int idRequisicaoCotacao
		{
			get{return this.m_IdRequisicaoCotacao;}
			set{this.m_IdRequisicaoCotacao = value;}
		}

        [
            TFieldAttributeGridDisplay("Qtd. Aprovada", 100),
            TFieldAttributeData(13, false),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_QuantidadeAprovada;
        public double quantidadeAprovada
        {
            get { return this.m_QuantidadeAprovada; }
            set { this.m_QuantidadeAprovada = value; }
        }

        [
            TFieldAttributeGridDisplay("Unidade", 100),
            TFieldAttributeData(6, true, false),
            TFieldAttributeSubfield("idUnidadeProdutoServico:descricao")
        ]
        private UnidadeProdutoServico m_IdUnidadeProdutoServico;
		public UnidadeProdutoServico unidadeProdutoServico
		{
			get{return this.m_IdUnidadeProdutoServico;}
			set{this.m_IdUnidadeProdutoServico = value;}
		}

        private Fornecedor m_Fornecedor;
        public Fornecedor Fornecedor
        {
            get { return this.m_Fornecedor; }
            set { this.m_Fornecedor = value; }
        }

        public override string ToString()
        {
            return this.m_IdRequisicaoCotacaoProdutoServico.ToString();
        }
    }
}
