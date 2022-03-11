using System;

namespace Data
{
	//[Serializable]
	public class PessoaEndereco: Base
	{
		public PessoaEndereco(): base()
		{
		}

        private int m_IdPessoaEnderecoContato;
        public int idPessoaEnderecoContato
        {
            get { return this.m_IdPessoaEnderecoContato; }
            set { this.m_IdPessoaEnderecoContato = value; }
        }

        private String m_Numero;
		public String numero
		{
			get{return this.m_Numero;}
			set{this.m_Numero = value;}
		}

		private String m_Complemento;
		public String complemento
		{
			get{return this.m_Complemento;}
			set{this.m_Complemento = value;}
		}

		private Endereco m_IdEndereco;
		public Endereco endereco
		{
			get{return this.m_IdEndereco;}
			set{this.m_IdEndereco = value;}
		}

        private Bairro m_IdBairro;
        public Bairro bairro
        {
            get { return this.m_IdBairro; }
            set { this.m_IdBairro = value; }
        }

        private Logradouro m_IdLogradouro;
        public Logradouro logradouro
        {
            get { return this.m_IdLogradouro; }
            set { this.m_IdLogradouro = value; }
        }

        private PessoaEnderecoFinalidadeEndereco[] m_PessoaEnderecoFinalidadeEnderecos;
        public PessoaEnderecoFinalidadeEndereco[] pessoaEnderecoFinalidadeEnderecos
        {
            get{return this.m_PessoaEnderecoFinalidadeEnderecos;}
            set{this.m_PessoaEnderecoFinalidadeEnderecos = value;}
        }

        public override string ToString()
        {
            return this.m_IdPessoaEnderecoContato.ToString();
        }
    }
}
