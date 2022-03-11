using System;

namespace Data
{
	//[Serializable]
	public class ExameEmpresaRelacionamento: Base
	{
		public ExameEmpresaRelacionamento(): base()
		{
		}

		private int m_IdExameEmpresaRelacionamento;
		public int idExameEmpresaRelacionamento
		{
			get{return this.m_IdExameEmpresaRelacionamento;}
			set{this.m_IdExameEmpresaRelacionamento = value;}
		}

		private DateTime m_DataValidade;
		public DateTime dataValidade
		{
			get{return this.m_DataValidade;}
			set{this.m_DataValidade = value;}
		}

		private DateTime m_DataCadastramento;
		public DateTime dataCadastramento
		{
			get{return this.m_DataCadastramento;}
			set{this.m_DataCadastramento = value;}
		}

		private int m_UsuarioCadastramento;
		public int usuarioCadastramento
		{
			get{return this.m_UsuarioCadastramento;}
			set{this.m_UsuarioCadastramento = value;}
		}

		private EmpresaRelacionamento m_IdEmpresaRelacionamento;
		public EmpresaRelacionamento empresaRelacionamento
		{
			get{return this.m_IdEmpresaRelacionamento;}
			set{this.m_IdEmpresaRelacionamento = value;}
		}

        public override string ToString()
        {
            return this.m_IdExameEmpresaRelacionamento.ToString();
        }
    }
}
