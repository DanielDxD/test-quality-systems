using System;

namespace Data
{
	//[Serializable]
	public class PessoaEnderecoFinalidadeEndereco: Base
	{
		public PessoaEnderecoFinalidadeEndereco(): base()
		{
		}


		private int m_IdPessoaEnderecoContato;
		public int idPessoaEnderecoContato
		{
			get{return this.m_IdPessoaEnderecoContato;}
			set{this.m_IdPessoaEnderecoContato = value;}
		}

		private FinalidadeEndereco m_IdFinalidadeEndereco;
		public FinalidadeEndereco finalidadeEndereco
		{
			get{return this.m_IdFinalidadeEndereco;}
			set{this.m_IdFinalidadeEndereco = value;}
		}

        public override string ToString()
        {
            return this.m_IdPessoaEnderecoContato.ToString();
        }
    }
}
