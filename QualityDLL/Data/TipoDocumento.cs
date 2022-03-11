using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class TipoDocumento : Base
    {
        public TipoDocumento()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdTipoDocumento;
        public int idTipoDocumento
        {
            get { return this.m_IdTipoDocumento; }
            set { this.m_IdTipoDocumento = value; }
        }

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("Descrição", 270)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeData(5, false),
            TFieldAttributeGridDisplay("Cheque", 80)
        ]
        private Boolean m_Cheque;
        public Boolean cheque
        {
            get { return this.m_Cheque; }
            set { this.m_Cheque = value; }
        }

        [
            TFieldAttributeData(5, false),
            TFieldAttributeGridDisplay("Dinheiro", 80)
        ]
        private Boolean m_Dinheiro;
        public Boolean dinheiro
        {
            get { return this.m_Dinheiro; }
            set { this.m_Dinheiro = value; }
        }

        public override string ToString()
        {
            return this.m_IdTipoDocumento.ToString();
        }
    }
}
