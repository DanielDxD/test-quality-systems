using System;

namespace Data
{
    //[Serializable]
    public class DocumentoRecebimentoContasAReceber : Base
    {
        public DocumentoRecebimentoContasAReceber()
            : base()
        {
        }

        private int m_IdDocumentoRecebimentoContasAReceber;
        public int idDocumentoRecebimentoContasAReceber
        {
            get { return this.m_IdDocumentoRecebimentoContasAReceber; }
            set { this.m_IdDocumentoRecebimentoContasAReceber = value; }
        }

        private double m_ValorBase;
        public double valorBase
        {
            get { return this.m_ValorBase; }
            set { this.m_ValorBase = value; }
        }

        private double m_ValorRecebido;
        public double valorRecebido
        {
            get { return this.m_ValorRecebido; }
            set { this.m_ValorRecebido = value; }
        }

        private double m_ValorMulta;
        public double valorMulta
        {
            get { return this.m_ValorMulta; }
            set { this.m_ValorMulta = value; }
        }

        private double m_ValorJuros;
        public double valorJuros
        {
            get { return this.m_ValorJuros; }
            set { this.m_ValorJuros = value; }
        }

        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private double m_ValorCM;
        public double valorCM
        {
            get { return this.m_ValorCM; }
            set { this.m_ValorCM = value; }
        }

        private double m_ValorINSSRetido;
        public double valorINSSRetido
        {
            get { return this.m_ValorINSSRetido; }
            set { this.m_ValorINSSRetido = value; }
        }

        private double m_ValorISSRetido;
        public double valorISSRetido
        {
            get { return this.m_ValorISSRetido; }
            set { this.m_ValorISSRetido = value; }
        }

        private double m_ValorIRRetido;
        public double valorIRRetido
        {
            get { return this.m_ValorIRRetido; }
            set { this.m_ValorIRRetido = value; }
        }

        private double m_ValorPISRetido;
        public double valorPISRetido
        {
            get { return this.m_ValorPISRetido; }
            set { this.m_ValorPISRetido = value; }
        }

        private double m_ValorCOFINSRetido;
        public double valorCOFINSRetido
        {
            get { return this.m_ValorCOFINSRetido; }
            set { this.m_ValorCOFINSRetido = value; }
        }

        private double m_ValorCSLLRetido;
        public double valorCSLLRetido
        {
            get { return this.m_ValorCSLLRetido; }
            set { this.m_ValorCSLLRetido = value; }
        }

        private int m_IdDocumentoRecebimento;
        public int idDocumentoRecebimento
        {
            get { return this.m_IdDocumentoRecebimento; }
            set { this.m_IdDocumentoRecebimento = value; }
        }

        private ContasAReceber m_IdContasAReceber;
        public ContasAReceber contasAReceber
        {
            get { return this.m_IdContasAReceber; }
            set { this.m_IdContasAReceber = value; }
        }
    }
}
