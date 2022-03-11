using System;

namespace Data
{
	//[Serializable]
	public class AtendimentoProdutoServico: Base
	{
		public AtendimentoProdutoServico(): base()
		{
		}

		private int m_IdAtendimentoProdutoServico;
		public int idAtendimentoProdutoServico
		{
			get{return this.m_IdAtendimentoProdutoServico;}
			set{this.m_IdAtendimentoProdutoServico = value;}
		}

		private Atendimento m_IdAtendimento;
		public Atendimento atendimento
		{
			get{return this.m_IdAtendimento;}
			set{this.m_IdAtendimento = value;}
		}

		private ProdutoServico m_IdProdutoServico;
		public ProdutoServico produtoServico
		{
			get{return this.m_IdProdutoServico;}
			set{this.m_IdProdutoServico = value;}
		}

        public override string ToString()
        {
            return this.m_IdAtendimentoProdutoServico.ToString();
        }
    }
}
