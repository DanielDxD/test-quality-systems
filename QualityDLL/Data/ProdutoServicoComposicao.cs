using System;

namespace Data
{
	//[Serializable]
	public class ProdutoServicoComposicao: Base
	{
		public ProdutoServicoComposicao(): base()
		{
		}

		private int m_IdProdutoServicoComposicao;
		public int idProdutoServicoComposicao
		{
			get{return this.m_IdProdutoServicoComposicao;}
			set{this.m_IdProdutoServicoComposicao = value;}
		}

		private double m_Quantidade;
		public double quantidade
		{
			get{return this.m_Quantidade;}
			set{this.m_Quantidade = value;}
		}

		private int m_IdProdutoServico2;
		public int idProdutoServico
		{
			get{return this.m_IdProdutoServico2; }
			set{this.m_IdProdutoServico2 = value;}
		}

		private ProdutoServico m_IdProdutoServico;
		public ProdutoServico produtoServico
        {
			get { return this.m_IdProdutoServico; }
			set { this.m_IdProdutoServico = value; }
		}

		private int m_IdProdutoServicoBase;
		public int idProdutoServicoBase
		{
			get{return this.m_IdProdutoServicoBase;}
			set{this.m_IdProdutoServicoBase = value;}
		}

		private UnidadeProdutoServico m_IdUnidadeProdutoServico;
		public UnidadeProdutoServico unidadeProdutoServico
		{
			get{return this.m_IdUnidadeProdutoServico;}
			set{this.m_IdUnidadeProdutoServico = value;}
		}

        public override string ToString()
        {
            return this.m_IdProdutoServicoComposicao.ToString();
        }
    }
}
