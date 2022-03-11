using System;

namespace Data
{
	//[Serializable]
	public class ProdutoServicoUnidade: Base
	{
		public ProdutoServicoUnidade(): base()
		{
		}

		private int m_IdProdutoServicoUnidade;
		public int idProdutoServicoUnidade
		{
			get{return this.m_IdProdutoServicoUnidade;}
			set{this.m_IdProdutoServicoUnidade = value;}
		}

		private double m_Fator;
		public double fator
		{
			get{return this.m_Fator;}
			set{this.m_Fator = value;}
		}

		private int m_IdProdutoServico;
		public int idProdutoServico
		{
			get{return this.m_IdProdutoServico;}
			set{this.m_IdProdutoServico = value;}
		}

		private UnidadeProdutoServico m_IdUnidadeProdutoServico;
		public UnidadeProdutoServico unidadeProdutoServico
		{
			get{return this.m_IdUnidadeProdutoServico;}
			set{this.m_IdUnidadeProdutoServico = value;}
		}

        public override string ToString()
        {
            return this.m_IdProdutoServicoUnidade.ToString();
        }
    }
}
