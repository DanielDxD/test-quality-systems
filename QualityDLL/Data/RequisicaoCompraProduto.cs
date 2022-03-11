using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [TClassAttributeEdit(2)]
    public class RequisicaoCompraProdutoServico : Base
	{
		public RequisicaoCompraProdutoServico(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoCompraProdutoServico;
		public int idRequisicaoCompraProdutoServico
		{
			get{return this.m_IdRequisicaoCompraProdutoServico;}
			set{this.m_IdRequisicaoCompraProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("Produto/Servico", 350),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idProdutoServico:descricao:3")
        ]
        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Quantidade", 100),
            TFieldAttributeData(13, true),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_Quantidade;
		public double quantidade
		{
			get{return this.m_Quantidade;}
			set{this.m_Quantidade = value;}
		}

		private int m_IdRequisicaoCompra;
		public int idRequisicaoCompra
		{
			get{return this.m_IdRequisicaoCompra;}
			set{this.m_IdRequisicaoCompra = value;}
		}

        [
            TFieldAttributeGridDisplay("Unidade", 85),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idUnidadeProdutoServico:descricao")
        ]
        private UnidadeProdutoServico m_IdUnidadeProdutoServico;
        public UnidadeProdutoServico unidadeProdutoServico
        {
            get { return this.m_IdUnidadeProdutoServico; }
            set { this.m_IdUnidadeProdutoServico = value; }
        }

        [
            //TFieldAttributeGridDisplay("Fornecedor", 280),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idEmpresaRelacionamento:pessoa.nomeRazaoSocial")
        ]
        private Fornecedor m_IdFornecedor;
		public Fornecedor fornecedor
		{
			get{return this.m_IdFornecedor;}
			set{this.m_IdFornecedor = value;}
		}

        public override string ToString()
        {
            return this.m_IdRequisicaoCompraProdutoServico.ToString();
        }
    }
}
