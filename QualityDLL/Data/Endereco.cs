using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Endereco : Base
    {
        public Endereco() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdEndereco;
        public int idEndereco
        {
            get { return this.m_IdEndereco; }
            set { this.m_IdEndereco = value; }
        }

        [
            TFieldAttributeGridDisplay("CEP", 100),
            TFieldAttributeData(9, true),
            TFieldAttributeFormat("cep", "cep")
        ]
        private int m_Cep;
        public int cep
        {
            get { return this.m_Cep; }
            set { this.m_Cep = value; }
        }

        [
            TFieldAttributeGridDisplay("Cidade", 0),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idCidade:descricao")
        ]
        private Cidade m_IdCidade;
        public Cidade cidade
        {
            get { return this.m_IdCidade; }
            set { this.m_IdCidade = value; }
        }

        [
            TFieldAttributeGridDisplay("Bairro", 120),
            TFieldAttributeData(6, false, true, true),
            TFieldAttributeSubfield("idBairro:descricao:3")
        ]
        private Bairro m_IdBairro;
        public Bairro bairro
        {
            get { return this.m_IdBairro; }
            set { this.m_IdBairro = value; }
        }

        [
            TFieldAttributeGridDisplay("Logradouro", 200),
            TFieldAttributeData(6, false, true, true),
            TFieldAttributeSubfield("idLogradouro:descricao:3")
        ]
        private Logradouro m_IdLogradouro;
        public Logradouro logradouro
        {
            get { return this.m_IdLogradouro; }
            set { this.m_IdLogradouro = value; }
        }


        [
            TFieldAttributeGridDisplay("CEP Único", 200),
            TFieldAttributeData(6, false, true, true),
            TFieldAttributeFormat("checkbox", "checkbox")
        ]
        private bool m_CepUnico;
        public bool cepUnico
        {
            get
            {
                if (
                    (m_IdLogradouro == null || (m_IdLogradouro != null && m_IdLogradouro.idLogradouro == 0)) &&
                    (m_IdBairro == null || (m_IdBairro != null && m_IdBairro.idBairro == 0))
                    )

                    m_CepUnico = true;
                else
                    m_CepUnico = false;

                return m_CepUnico;
            }
        }

        public override string ToString()
        {
            return this.m_IdEndereco.ToString();
        }
    }
}
