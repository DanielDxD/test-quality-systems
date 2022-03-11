using System;

namespace Data
{
	//[Serializable]
	public class PessoaContatoAcesso: Base
	{
		public PessoaContatoAcesso(): base()
		{
		}

		private int m_IdPessoaContatoAcesso;
		public int idPessoaContatoAcesso
		{
			get{return this.m_IdPessoaContatoAcesso;}
			set{this.m_IdPessoaContatoAcesso = value;}
		}

		private String m_Informacao;
		public String informacao
		{
			get{return this.m_Informacao;}
			set{this.m_Informacao = value;}
		}

		private PessoaContato m_IdPessoaEnderecoContato;
		public PessoaContato pessoaEnderecoContato
		{
			get{return this.m_IdPessoaEnderecoContato;}
			set{this.m_IdPessoaEnderecoContato = value;}
		}

		private TipoAcessoContato m_IdTipoAcessoContato;
		public TipoAcessoContato tipoAcessoContato
		{
			get{return this.m_IdTipoAcessoContato;}
			set{this.m_IdTipoAcessoContato = value;}
		}

        public override string ToString()
        {
            return this.m_IdPessoaContatoAcesso.ToString();
        }
    }
}
