using System;

namespace Data
{
	//[Serializable]
	public class PdvEstacoesSangria: Base
	{
		public PdvEstacoesSangria(): base()
		{
		}

		private int m_IdPdvEstacaoSangria;
		public int idPdvEstacaoSangria
        {
			get{return this.m_IdPdvEstacaoSangria; }
			set{this.m_IdPdvEstacaoSangria = value;}
		}

		private DateTime m_DataSangria;
		public DateTime dataSangria
		{
			get{return this.m_DataSangria; }
			set{this.m_DataSangria = value;}
		}

        private Double m_Valor;
        public Double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private String m_Observacao;
        public String observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private PdvEstacao m_IdPdvEstacao;
		public PdvEstacao pdvEstacao
		{
			get{return this.m_IdPdvEstacao; }
			set{this.m_IdPdvEstacao = value;}
		}

		private Funcionario m_IdFuncionario;
		public Funcionario funcionario
		{
			get{return this.m_IdFuncionario; }
			set{this.m_IdFuncionario = value;}
		}
        
        public override string ToString()
        {
            return this.m_IdPdvEstacaoSangria.ToString();
        }
	}
}
