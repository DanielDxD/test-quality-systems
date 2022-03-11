using System;

namespace Data
{
	//[Serializable]
	public class Atendimento: Base
	{
		public Atendimento(): base()
		{
		}

		private int m_IdAtendimento;
		public int idAtendimento
		{
			get{return this.m_IdAtendimento;}
			set{this.m_IdAtendimento = value;}
		}

		private DateTime m_DataAtendimento;
		public DateTime dataAtendimento
		{
			get{return this.m_DataAtendimento;}
			set{this.m_DataAtendimento = value;}
		}

		private int m_NumeroComanda;
		public int numeroComanda
		{
			get{return this.m_NumeroComanda;}
			set{this.m_NumeroComanda = value;}
		}

		private PontoAtendimento m_IdPontoAtendimento;
		public PontoAtendimento pontoAtendimento
		{
			get{return this.m_IdPontoAtendimento;}
			set{this.m_IdPontoAtendimento = value;}
		}

		private Funcionario m_IdAtendente;
		public Funcionario atendente
		{
			get{return this.m_IdAtendente;}
			set{this.m_IdAtendente = value;}
		}

        //idAtendimento
        private AtendimentoProdutoServico[] m_AtendimentoProdutoServicos;
        public AtendimentoProdutoServico[] atendimentoProdutoServicos
        {
            get{return this.m_AtendimentoProdutoServicos;}
            set{this.m_AtendimentoProdutoServicos = value;}
        }

        //idAtendimento
        private AtendimentoPagamento[] m_AtendimentoPagamentos;
        public AtendimentoPagamento[] atendimentoPagamentos
        {
            get{return this.m_AtendimentoPagamentos;}
            set{this.m_AtendimentoPagamentos = value;}
        }

        public override string ToString()
        {
            return this.m_IdAtendimento.ToString();
        }
	}
}
