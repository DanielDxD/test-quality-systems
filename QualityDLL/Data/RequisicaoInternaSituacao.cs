using System;

namespace Data
{
	//[Serializable]
	public class RequisicaoInternaSituacao: Base
	{
		public RequisicaoInternaSituacao(): base()
		{
		}

		private int m_IdRequisicaoInternaSituacao;
		public int idRequisicaoInternaSituacao
		{
			get{return this.m_IdRequisicaoInternaSituacao;}
			set{this.m_IdRequisicaoInternaSituacao = value;}
		}

		private String m_Situacao;
		public String situacao
		{
			get{return this.m_Situacao;}
			set{this.m_Situacao = value;}
		}

		private DateTime m_DataSituacao;
		public DateTime dataSituacao
		{
			get{return this.m_DataSituacao;}
			set{this.m_DataSituacao = value;}
		}

		private int m_IdRequisicaoInterna;
		public int idRequisicaoInterna
		{
			get{return this.m_IdRequisicaoInterna;}
			set{this.m_IdRequisicaoInterna = value;}
		}

		private Funcionario m_IdFuncionario;
		public Funcionario funcionario
		{
			get{return this.m_IdFuncionario;}
			set{this.m_IdFuncionario = value;}
		}

        public override string ToString()
        {
            return this.m_IdRequisicaoInternaSituacao.ToString();
        }
    }
}
