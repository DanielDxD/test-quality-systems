using System;

namespace Data
{
	//[Serializable]
	public class PessoaRelacionamento: Base
	{
		public PessoaRelacionamento(): base()
		{
		}

		private int m_IdPessoaRelacionamento;
		public int idPessoaRelacionamento
		{
			get{return this.m_IdPessoaRelacionamento;}
			set{this.m_IdPessoaRelacionamento = value;}
		}

		private String m_Nome;
		public String nome
		{
			get{return this.m_Nome;}
			set{this.m_Nome = value;}
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

		private Pessoa m_IdPessoa;
		public Pessoa pessoa
		{
			get{return this.m_IdPessoa;}
			set{this.m_IdPessoa = value;}
		}

		private TipoRelacionamento m_IdTipoRelacionamento;
		public TipoRelacionamento tipoRelacionamento
		{
			get{return this.m_IdTipoRelacionamento;}
			set{this.m_IdTipoRelacionamento = value;}
		}

		private Pessoa m_IdPessoaRelacionada;
		public Pessoa pessoaRelacionada
		{
			get{return this.m_IdPessoaRelacionada;}
			set{this.m_IdPessoaRelacionada = value;}
		}

        public override string ToString()
        {
            return this.m_IdPessoaRelacionamento.ToString();
        }
    }
}
