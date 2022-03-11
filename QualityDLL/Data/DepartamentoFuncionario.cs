using System;

namespace Data
{
	//[Serializable]
	public class DepartamentoFuncionario: Base
	{
		public DepartamentoFuncionario(): base()
		{
		}

		private int m_IdDepartamentoFuncionario;
		public int idDepartamentoFuncionario
		{
			get{return this.m_IdDepartamentoFuncionario;}
			set{this.m_IdDepartamentoFuncionario = value;}
		}

		private DateTime m_DataInicio;
		public DateTime dataInicio
		{
			get{return this.m_DataInicio;}
			set{this.m_DataInicio = value;}
		}

		private DateTime m_DataTermino;
		public DateTime dataTermino
		{
			get{return this.m_DataTermino;}
			set{this.m_DataTermino = value;}
		}

		private bool m_Responsavel;
		public bool responsavel
		{
			get{return this.m_Responsavel;}
			set{this.m_Responsavel = value;}
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

        public override string ToString()
        {
            return this.m_IdDepartamentoFuncionario.ToString();
        }
    }
}
