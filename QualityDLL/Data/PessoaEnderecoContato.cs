using System;
using System.Linq;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PessoaEnderecoContato : Base
    {
        public PessoaEnderecoContato()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdPessoaEnderecoContato;
        public int idPessoaEnderecoContato
        {
            get { return this.m_IdPessoaEnderecoContato; }
            set { this.m_IdPessoaEnderecoContato = value; }
        }

        private int m_IdPessoa;
        public int idPessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        [
            TFieldAttributeGridDisplay("Tipo Endereco/Contato", 80),
            TFieldAttributeSubfield("tipoEnderecoContato:descricao")
        ]
        private TipoEnderecoContato m_IdTipoEnderecoContato;
        public TipoEnderecoContato tipoEnderecoContato
        {
            get { return this.m_IdTipoEnderecoContato; }
            set { this.m_IdTipoEnderecoContato = value; }
        }

        private PessoaContato m_PessoaContato;
        public PessoaContato pessoaContato
        {
            get { return this.m_PessoaContato; }
            set { this.m_PessoaContato = value; }
        }

        [
            TFieldAttributeGridDisplay("Contato", 80)
        ]
        private String m_Contato;
        public String contato
        {
            get
            {
                String result = this.m_Contato;

                if ((result == null) && (this.m_PessoaContato != null))
                {
                    result =
                    (
                        this.m_PessoaContato.pessoaContato != null ?
                        this.m_PessoaContato.pessoaContato.nomeRazaoSocial :
                        this.m_PessoaContato.nome
                    );

                    if (this.m_PessoaContato.pessoaContatoAcessos != null)
                        result +=
                        (
                            (String.IsNullOrWhiteSpace(result) ? "" : "<br />") +
                            String.Join
                            (
                                ", ",
                                this.m_PessoaContato.pessoaContatoAcessos.Select(X => X.tipoAcessoContato.descricao + " " + X.informacao).ToList<String>()
                            )
                        );
                    else { }
                }
                else { }

                return result;
            }
            set { this.m_Contato = value; }
        }

        private PessoaEndereco m_PessoaEndereco;
        public PessoaEndereco pessoaEndereco
        {
            get { return this.m_PessoaEndereco; }
            set { this.m_PessoaEndereco = value; }
        }

        [
            TFieldAttributeGridDisplay("Endereço", 80)
        ]
        private String m_Endereco;
        public String endereco
        {
            get
            {
                String result = this.m_Endereco;

                if ((result == null) && (this.m_PessoaEndereco != null))
                {
                    Data.Logradouro logradouro = this.m_PessoaEndereco.logradouro != null && this.m_PessoaEndereco.logradouro.idLogradouro > 0 ? this.m_PessoaEndereco.logradouro : this.m_PessoaEndereco.endereco.logradouro;
                    try
                    {
                        result =
                        (
                            logradouro.tipoLogradouro.tipo + " " +
                            logradouro.descricao +
                            (!String.IsNullOrWhiteSpace(this.m_PessoaEndereco.numero) ? ", " + this.m_PessoaEndereco.numero : "") +
                            "<br />" +
                            logradouro?.cidade?.descricao + "/" +
                            logradouro?.cidade?.estado.uf
                        );
                    }
                    catch { }
                }
                else { }

                return result;
            }
            set { this.m_Endereco = value; }
        }

        public override string ToString()
        {
            return this.m_IdPessoaEnderecoContato.ToString();
        }
    }
}