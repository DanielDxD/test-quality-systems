using System;

namespace Data
{
    //[Serializable]
    public class CorrecaoMonetariaItem : Base
    {

        public CorrecaoMonetariaItem() : base()
        {
        }

        private int m_IdCorrecaoMonetariaItem;
        public int idCorrecaoMonetariaItem
        {
            get { return this.m_IdCorrecaoMonetariaItem; }
            set { this.m_IdCorrecaoMonetariaItem = value; }
        }

        private CorrecaoMonetaria m_IdCorrecaoMonetaria;
        public CorrecaoMonetaria correcaoMonetaria
        {
            get { return this.m_IdCorrecaoMonetaria; }
            set { this.m_IdCorrecaoMonetaria = value; }
        }

        private string m_MesReferencia;
        public string mesReferencia
        {
            get { return this.m_MesReferencia; }
            set { this.m_MesReferencia = value; }
        }

        private double m_ValorIndice;
        public double valorIndice
        {
            get { return this.m_ValorIndice; }
            set { this.m_ValorIndice = value; }
        }

    }
}
