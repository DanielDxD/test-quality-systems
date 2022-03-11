using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Servico : Base
    {
        public Servico()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdServico;
        public int idServico
        {
            get { return this.m_IdServico; }
            set { this.m_IdServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Nome", 255 + 155),
            TFieldAttributeEditDisplay("Nome", 230),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeEditDisplay("Aliquota ISS", 100),
            TFieldAttributeData(6, true),
            TFieldAttributeFormat("000.00", "!999,99")
        ]
        private double m_AliquotaIss;
        public double aliquotaIss
        {
            get { return this.m_AliquotaIss; }
            set { this.m_AliquotaIss = value; }
        }

        [
            TFieldAttributeEditDisplay("Tipo", 100),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idTipoMovimento:descricao")
        ]
        private TipoMovimento m_IdTipoMovimento;
        public TipoMovimento tipoMovimento
        {
            get { return this.m_IdTipoMovimento; }
            set { this.m_IdTipoMovimento = value; }
        }
    }
}