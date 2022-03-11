using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class PessoaEnderecosContatos: Base
    {
        public PessoaEnderecosContatos() : base()
		{
		}

        private int m_IdPessoa;
        public int idPessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        private EnderecoContato[] m_EnderecosContatos;
        public EnderecoContato[] enderecosContatos
        {
            get { return this.m_EnderecosContatos; }
            set { this.m_EnderecosContatos = value; }
        }
    }
}