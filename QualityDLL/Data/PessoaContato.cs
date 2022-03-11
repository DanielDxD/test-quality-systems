using System;

namespace Data
{
	//[Serializable]
	public class PessoaContato: Base
	{
		public PessoaContato(): base()
		{
		}

        private int m_IdPessoaEnderecoContato;
        public int idPessoaEnderecoContato
        {
            get { return this.m_IdPessoaEnderecoContato; }
            set { this.m_IdPessoaEnderecoContato = value; }
        }

        private String m_Nome;
		public String nome
		{
			get{return this.m_Nome;}
			set{this.m_Nome = value;}
		}

		private Pessoa m_IdPessoaContato;
		public Pessoa pessoaContato
		{
			get{return this.m_IdPessoaContato;}
			set{this.m_IdPessoaContato = value;}
		}

        private PessoaContatoAcesso[] m_PessoaContatoAcessos;
        public PessoaContatoAcesso[] pessoaContatoAcessos
        {
            get{return this.m_PessoaContatoAcessos;}
            set{this.m_PessoaContatoAcessos = value;}
        }

        public override string ToString()
        {
            return this.m_IdPessoaContato.ToString();
        }
    }
}
