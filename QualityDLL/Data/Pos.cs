using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Pos : Base
    {
        public Pos() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPos;
        public int idPos
        {
            get { return this.m_IdPos; }
            set { this.m_IdPos = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 200)
        ]
        private string m_descricao;
        public string descricao
        {
            get { return this.m_descricao; }
            set { this.m_descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Estação", 200),
            TFieldAttributeSubfield("idPdvEstacao:descricao")
        ]
        private PdvEstacao m_IdPdvEstacao;
        public PdvEstacao pdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Impressora", 200)
        ]
        private string m_impressora;
        public string impressora
        {
            get { return this.m_impressora; }
            set { this.m_impressora = value; }
        }

        [
            TFieldAttributeGridDisplay("Fixar menu pré pago", 200)
        ]
        private string m_fixarMenuPrePago;
        public string fixarMenuPrePago
        {
            get { return this.m_fixarMenuPrePago; }
            set { this.m_fixarMenuPrePago = value; }
        }

        public override string ToString()
        {
            return this.m_IdPos.ToString();
        }
    }
}
