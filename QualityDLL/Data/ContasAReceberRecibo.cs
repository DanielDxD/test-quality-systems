using System;

namespace Data
{
    //[Serializable]
    public class ContasAReceberRecibo : Base
    {

        public ContasAReceberRecibo() : base()
        {
        }

        private int m_IdContasAReceberRecibo;
        public int idContasAReceberRecibo
        {
            get { return this.m_IdContasAReceberRecibo; }
            set { this.m_IdContasAReceberRecibo = value; }
        }

        private DateTime m_DataRecibo;
        public DateTime dataRecibo
        {
            get { return this.m_DataRecibo; }
            set { this.m_DataRecibo = value; }
        }

        private double m_ValorTotal;
        public double valorTotal
        {
            get { return this.m_ValorTotal; }
            set { this.m_ValorTotal = value; }
        }

        private double m_JurosTotal;
        public double jurosTotal
        {
            get { return this.m_JurosTotal; }
            set { this.m_JurosTotal = value; }
        }

        private double m_MultaTotal;
        public double multaTotal
        {
            get { return this.m_MultaTotal; }
            set { this.m_MultaTotal = value; }
        }

        private double m_DescontoTotal;
        public double descontoTotal
        {
            get { return this.m_DescontoTotal; }
            set { this.m_DescontoTotal = value; }
        }

        private ContasAReceberPagamento[] m_contasAReceberPagamentos;
        public ContasAReceberPagamento[] contasAReceberPagamentos
        {

            get { return this.m_contasAReceberPagamentos; }
            set { this.m_contasAReceberPagamentos = value; }
        }

    }
}
