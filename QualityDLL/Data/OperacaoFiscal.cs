using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class OperacaoFiscal : Base
    {
        public OperacaoFiscal()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, false)
        ]
        private int m_IdOperacaoFiscal;
        public int idOperacaoFiscal
        {
            get { return this.m_IdOperacaoFiscal; }
            set { this.m_IdOperacaoFiscal = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 350),
            TFieldAttributeEditDisplay("Descrição", 80),
            TFieldAttributeData(350, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeEditDisplay("Serviço", 80),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:S_Sim;P_Não")
        ]
        private String m_ProdutoServico;
        public String produtoServico
        {
            get { return this.m_ProdutoServico; }
            set { this.m_ProdutoServico = value; }
        }

        [
            TFieldAttributeEditDisplay("Comentario", 80),
            TFieldAttributeData(1024, false)
        ]
        private String m_Comentario;
        public String comentario
        {
            get { return this.m_Comentario; }
            set { this.m_Comentario = value; }
        }

        public override string ToString()
        {
            return this.m_IdOperacaoFiscal.ToString();
        }
    }
}