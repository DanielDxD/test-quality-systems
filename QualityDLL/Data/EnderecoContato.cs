using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class EnderecoContato : Base
    {
        public EnderecoContato()
            : base()
        {
        }

        private TipoEnderecoContato m_Tipo;
        public TipoEnderecoContato tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private PessoaEndereco m_Endereco;
        public PessoaEndereco endereco
        {
            get { return this.m_Endereco; }
            set { this.m_Endereco = value; }
        }

        private PessoaContato m_Contato;
        public PessoaContato contato
        {
            get { return this.m_Contato; }
            set { this.m_Contato = value; }
        }
    }
}
