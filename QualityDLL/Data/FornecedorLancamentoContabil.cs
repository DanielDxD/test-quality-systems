using System;

namespace Data
{
	//[Serializable]
	public class FornecedorLancamentoContabil: Base
	{
		public FornecedorLancamentoContabil(): base()
		{
		}

		private int m_IdFornecedorLancamentoContabil;
		public int idFornecedorLancamentoContabil
		{
			get{return this.m_IdFornecedorLancamentoContabil;}
			set{this.m_IdFornecedorLancamentoContabil = value;}
		}

		private double m_Fator;
		public double fator
		{
			get{return this.m_Fator;}
			set{this.m_Fator = value;}
		}

		private Fornecedor m_IdFornecedor;
		public Fornecedor fornecedor
		{
			get{return this.m_IdFornecedor;}
			set{this.m_IdFornecedor = value;}
		}

		private PlanoContas m_IdPlanoContas;
		public PlanoContas planoContas
		{
			get{return this.m_IdPlanoContas;}
			set{this.m_IdPlanoContas = value;}
		}

		private TipoLancamentoContabil m_IdTipoLancamentoContabil;
		public TipoLancamentoContabil tipoLancamentoContabil
		{
			get{return this.m_IdTipoLancamentoContabil;}
			set{this.m_IdTipoLancamentoContabil = value;}
		}

        public override string ToString()
        {
            return this.m_IdFornecedor.ToString();
        }
    }
}
