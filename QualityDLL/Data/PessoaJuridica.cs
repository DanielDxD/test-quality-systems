using System;

namespace Data
{
	//[Serializable]
	public class PessoaJuridica: Pessoa
	{
		public PessoaJuridica(): base()
		{
            this.pfpj = "J";
		}

		private DateTime m_DataFundacao;
		public DateTime dataFundacao
		{
			get{return this.m_DataFundacao;}
			set{this.m_DataFundacao = value;}
		}

		private String m_InscricaoEstadual;
		public String inscricaoEstadual
		{
			get{return this.m_InscricaoEstadual;}
			set{this.m_InscricaoEstadual = value;}
		}

		private String m_InscricaoMunicipal;
		public String inscricaoMunicipal
		{
			get{return this.m_InscricaoMunicipal;}
			set{this.m_InscricaoMunicipal = value;}
		}

		private AtividadeEconomica m_IdAtividadeEconomicaPrimaria;
		public AtividadeEconomica atividadeEconomicaPrimaria
		{
			get{return this.m_IdAtividadeEconomicaPrimaria;}
			set{this.m_IdAtividadeEconomicaPrimaria = value;}
		}

		private AtividadeEconomica m_IdAtividadeEconomicaSecundaria;
		public AtividadeEconomica atividadeEconomicaSecundaria
		{
			get{return this.m_IdAtividadeEconomicaSecundaria;}
			set{this.m_IdAtividadeEconomicaSecundaria = value;}
		}

        private String m_InscricaoEstadualST;
        public String inscricaoEstadualST
        {
            get { return this.m_InscricaoEstadualST; }
            set { this.m_InscricaoEstadualST = value; }
        }

        public override string ToString()
        {
            return this.idPessoa.ToString();
        }
    }
}
