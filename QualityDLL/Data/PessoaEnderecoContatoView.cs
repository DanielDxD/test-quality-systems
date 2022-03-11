using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class PessoaEnderecoContatoView: Base
	{
		public PessoaEnderecoContatoView(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdPessoaEnderecoContatoView;
		public int idPessoaEnderecoContatoView
		{
			get{return this.m_IdPessoaEnderecoContatoView; }
			set{this.m_IdPessoaEnderecoContatoView = value;}
        }

        private int m_IdPessoa;
        public int idPessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        [
            TFieldAttributeGridDisplay("TipoEnderecoContato", 80)
        ]
        private String m_TipoEnderecoContato;
        public String tipoEnderecoContato
        {
            get { return this.m_TipoEnderecoContato; }
            set { this.m_TipoEnderecoContato = value; }
        }

        [
            TFieldAttributeGridDisplay("Endereço", 80)
        ]
        private String m_Endereco;
        public String endereco
        {
            get { return this.m_Endereco; }
            set { this.m_Endereco = value; }
        }

        [
            TFieldAttributeGridDisplay("Contato", 80)
        ]
        private String m_Contato;
        public String contato
        {
            get { return this.m_Contato; }
            set { this.m_Contato = value; }
        }

        public override string ToString()
        {
            return this.m_IdPessoaEnderecoContatoView.ToString();
        }
	}
}
