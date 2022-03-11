using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class CondicaoPagamento : Base
    {
        public CondicaoPagamento()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdCondicaoPagamento;
        public int idCondicaoPagamento
        {
            get { return this.m_IdCondicaoPagamento; }
            set { this.m_IdCondicaoPagamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 230),
            TFieldAttributeEditDisplay("Descrição", 80),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Condições", 160),
            TFieldAttributeEditDisplay("Condições", 80),
            TFieldAttributeData(50, true)
        ]
        private String m_Condicoes;
        public String condicoes
        {
            get { return this.m_Condicoes; }
            set { this.m_Condicoes = value; }
        }

        [
            TFieldAttributeEditDisplay("Dias Corridos", 80),
            TFieldAttributeData(50, true)
        ]
        private Boolean m_DiasCorridos;
        public Boolean diasCorridos
        {
            get { return this.m_DiasCorridos; }
            set { this.m_DiasCorridos = value; }
        }

        [
            TFieldAttributeEditDisplay("Customizado", 80),
            TFieldAttributeData(50, true)
        ]
        private Boolean m_DefinidoPeloUsuario;
        public Boolean definidoPeloUsuario
        {
            get { return this.m_DefinidoPeloUsuario; }
            set { this.m_DefinidoPeloUsuario = value; }
        }

        public override string ToString()
        {
            return this.m_IdCondicaoPagamento.ToString();
        }
    }
}