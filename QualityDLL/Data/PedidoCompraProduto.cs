using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [TClassAttributeEdit(2)]
    public class PedidoCompraProdutoServico : Base
	{
		public PedidoCompraProdutoServico(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdPedidoCompraProdutoServico;
		public int idPedidoCompraProdutoServico
		{
			get{return this.m_IdPedidoCompraProdutoServico;}
			set{this.m_IdPedidoCompraProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("Produto/Serviço", 320),
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

        [
            TFieldAttributeGridDisplay("Valor", 90),
            TFieldAttributeData(18, true),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
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
            TFieldAttributeGridDisplay("Valor última compra", 150),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_ValorUltimaCompra;
        public double valorUltimaCompra
        {
            get { return this.m_ValorUltimaCompra; }
            set { this.m_ValorUltimaCompra = value; }
        }

        private int m_IdPedidoCompra;
		public int idPedidoCompra
		{
			get{return this.m_IdPedidoCompra;}
			set{this.m_IdPedidoCompra = value;}
		}

		private int m_IdRequisicaoCotacaoProdutoServico;
		public int idRequisicaoCotacaoProdutoServico
		{
			get{return this.m_IdRequisicaoCotacaoProdutoServico;}
			set{this.m_IdRequisicaoCotacaoProdutoServico = value;}
		}

        public override string ToString()
        {
            return this.m_IdPedidoCompraProdutoServico.ToString();
        }
    }
}
