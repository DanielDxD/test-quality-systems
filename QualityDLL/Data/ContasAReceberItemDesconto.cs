using System;

namespace Data
{
    //[Serializable]
    public class ContasAReceberItemDesconto : Base
    {

        public ContasAReceberItemDesconto() : base()
        {
        }

        private int m_IdContasAReceberItemDesconto;
        public int idContasAReceberItemDesconto
        {
            get { return this.m_IdContasAReceberItemDesconto; }
            set { this.m_IdContasAReceberItemDesconto = value; }
        }

        private ContasAReceberItem m_IdContasAReceberItem;
        public ContasAReceberItem contasAReceberItem
        {
            get { return this.m_IdContasAReceberItem; }
            set { this.m_IdContasAReceberItem = value; }
        }

        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private DateTime m_DataLimite;
        public DateTime dataLimite
        {
            get { return this.m_DataLimite; }
            set { this.m_DataLimite = value; }
        }

    }
}
