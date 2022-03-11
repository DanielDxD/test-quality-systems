using System;

namespace Data
{
	//[Serializable]
	public class CaixaMovimentoLancamento: Base
	{
		public CaixaMovimentoLancamento(): base()
		{
		}

		private int m_IdCaixaMovimentoLancamento;
		public int idCaixaMovimentoLancamento
		{
			get{return this.m_IdCaixaMovimentoLancamento;}
			set{this.m_IdCaixaMovimentoLancamento = value;}
		}

		private CaixaMovimento m_IdCaixaMovimento;
		public CaixaMovimento caixaMovimento
		{
			get{return this.m_IdCaixaMovimento;}
			set{this.m_IdCaixaMovimento = value;}
		}

		private ProdutoServico m_IdProdutoServico;
		public ProdutoServico produtoServico
		{
			get{return this.m_IdProdutoServico;}
			set{this.m_IdProdutoServico = value;}
		}

		private ContasAReceber m_IdContasAReceber;
		public ContasAReceber contasAReceber
		{
			get{return this.m_IdContasAReceber;}
			set{this.m_IdContasAReceber = value;}
		}

        public override string ToString()
        {
            return this.m_IdCaixaMovimentoLancamento.ToString();
        }
    }
}
