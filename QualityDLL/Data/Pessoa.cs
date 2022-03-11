using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Pessoa : Base
    {
        public Pessoa() : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true)
        ]
        private int m_IdPessoa;
        public int idPessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        private String m_Pfpj;
        public String pfpj
        {
            get { return this.m_Pfpj; }
            set { this.m_Pfpj = value; }
        }

        [
            TFieldAttributeGridDisplay("CPF/CNPJ", 120),
            TFieldAttributeData(14, false)

        ]
        private String m_CpfCnpj;
        public String cpfCnpj
        {
            get { return this.m_CpfCnpj; }
            set { this.m_CpfCnpj = value; }
        }

        private String m_CpfCnpjFormatado;
        public String cpfCnpjFormatado
        {
            get { return this.m_CpfCnpjFormatado; }
            set { this.m_CpfCnpjFormatado = value; }
        }

        [
            TFieldAttributeGridDisplay("Nome/Razão Social", 290),
            TFieldAttributeData(100, false)
        ]
        private String m_NomeRazaoSocial;
        public String nomeRazaoSocial
        {
            get { return this.m_NomeRazaoSocial; }
            set { this.m_NomeRazaoSocial = value; }
        }

        [
            //TFieldAttributeGridDisplay("Apelido/Nome Comercial", 120),
            TFieldAttributeData(100, false)
        ]
        private String m_ApelidoNomeComercial;
        public String apelidoNomeComercial
        {
            get { return this.m_ApelidoNomeComercial; }
            set { this.m_ApelidoNomeComercial = value; }
        }

        private PessoaEnderecoContato[] m_PessoaEnderecoContatos;
        public PessoaEnderecoContato[] pessoaEnderecoContatos
        {
            get { return this.m_PessoaEnderecoContatos; }
            set { this.m_PessoaEnderecoContatos = value; }
        }

        private string m_Foto;
        public string foto
        {
            get { return this.m_Foto; }
            set { this.m_Foto = value; }
        }

        private PessoaRelacionamento[] m_PessoaRelacionamentos;
        public PessoaRelacionamento[] pessoaRelacionamentos
        {
            get { return this.m_PessoaRelacionamentos; }
            set { this.m_PessoaRelacionamentos = value; }
        }

        private PessoaImagem[] m_PessoaImagems;
        public PessoaImagem[] pessoaImagems
        {
            get { return this.m_PessoaImagems; }
            set { this.m_PessoaImagems = value; }
        }

        public override string ToString()
        {
            return this.m_IdPessoa.ToString();
        }
    }
}
