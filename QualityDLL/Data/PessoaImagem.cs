using System;

namespace Data
{
    //[Serializable]
    public class PessoaImagem : Base
    {
        public PessoaImagem()
            : base()
        {
        }

        private int m_IdPessoaImagem;
        public int idPessoaImagem
        {
            get { return this.m_IdPessoaImagem; }
            set { this.m_IdPessoaImagem = value; }
        }

        private System.Drawing.Image m_Imagem;
        public System.Drawing.Image imagem
        {
            get { return this.m_Imagem; }
            set { this.m_Imagem = value; }
        }

        private Pessoa m_IdPessoa;
        public Pessoa pessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        private TipoImagem m_IdTipoImagem;
        public TipoImagem tipoImagem
        {
            get { return this.m_IdTipoImagem; }
            set { this.m_IdTipoImagem = value; }
        }

        public override string ToString()
        {
            return this.m_IdPessoaImagem.ToString();
        }
    }
}