using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class TipoImagem : Base
    {
        public TipoImagem()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdTipoImagem;
        public int idTipoImagem
        {
            get { return this.m_IdTipoImagem; }
            set { this.m_IdTipoImagem = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 320),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        public override string ToString()
        {
            return this.m_IdTipoImagem.ToString();
        }
    }
}