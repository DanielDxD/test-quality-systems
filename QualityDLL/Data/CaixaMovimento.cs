using System;

namespace Data
{
	//[Serializable]
	public class CaixaMovimento: Base
	{
		public CaixaMovimento(): base()
		{
		}

		private int m_IdCaixaMovimento;
		public int idCaixaMovimento
		{
			get{return this.m_IdCaixaMovimento;}
			set{this.m_IdCaixaMovimento = value;}
		}

		private DateTime m_DataMovimento;
		public DateTime dataMovimento
		{
			get{return this.m_DataMovimento;}
			set{this.m_DataMovimento = value;}
		}

		private String m_RecebimentoPagamento;
		public String recebimentoPagamento
		{
			get{return this.m_RecebimentoPagamento;}
			set{this.m_RecebimentoPagamento = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private String m_FormaPagamento;
		public String formaPagamento
		{
			get{return this.m_FormaPagamento;}
			set{this.m_FormaPagamento = value;}
		}

		private Caixa m_IdCaixa;
		public Caixa caixa
		{
			get{return this.m_IdCaixa;}
			set{this.m_IdCaixa = value;}
		}

		private EmpresaRelacionamento m_IdCliente;
		public EmpresaRelacionamento cliente
		{
			get{return this.m_IdCliente;}
			set{this.m_IdCliente = value;}
		}

        //idCaixaMovimento
        private CaixaMovimentoLancamento[] m_CaixaMovimentoLancamentos;
        public CaixaMovimentoLancamento[] caixaMovimentoLancamentos
        {
            get{return this.m_CaixaMovimentoLancamentos;}
            set{this.m_CaixaMovimentoLancamentos = value;}
        }

        //idCaixaMovimento
        private CaixaMovimentoAtendimento[] m_CaixaMovimentoAtendimentos;
        public CaixaMovimentoAtendimento[] caixaMovimentoAtendimentos
        {
            get{return this.m_CaixaMovimentoAtendimentos;}
            set{this.m_CaixaMovimentoAtendimentos = value;}
        }

        public override string ToString()
        {
            return this.m_IdCaixaMovimento.ToString();
        }
    }
}
