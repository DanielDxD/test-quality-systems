using System;

namespace Data
{
	//[Serializable]
	public class Caixa: Base
	{
		public Caixa(): base()
		{
		}

		private int m_IdCaixa;
		public int idCaixa
		{
			get{return this.m_IdCaixa;}
			set{this.m_IdCaixa = value;}
		}

		private DateTime m_DataCaixa;
		public DateTime dataCaixa
		{
			get{return this.m_DataCaixa;}
			set{this.m_DataCaixa = value;}
		}

		private double m_Saldo;
		public double saldo
		{
			get{return this.m_Saldo;}
			set{this.m_Saldo = value;}
		}

		private Departamento m_IdDepartamento;
		public Departamento departamento
		{
			get{return this.m_IdDepartamento;}
			set{this.m_IdDepartamento = value;}
		}

		private Funcionario m_IdFuncionario;
		public Funcionario funcionario
		{
			get{return this.m_IdFuncionario;}
			set{this.m_IdFuncionario = value;}
		}

        //idCaixa
        private CaixaMovimento[] m_CaixaMovimentos;
        public CaixaMovimento[] caixaMovimentos
        {
            get{return this.m_CaixaMovimentos;}
            set{this.m_CaixaMovimentos = value;}
        }

        public override string ToString()
        {
            return this.m_IdCaixa.ToString();
        }
    }
}
