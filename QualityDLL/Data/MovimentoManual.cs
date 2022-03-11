using System;

namespace Data
{
    //[Serializable]
    public class MovimentoManual : Base
    {
        public MovimentoManual()
            : base()
        {
        }

        private int m_IdMovimentoManual;
        public int idMovimentoManual
        {
            get { return this.m_IdMovimentoManual; }
            set { this.m_IdMovimentoManual = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private int m_Ocorrencias;
        public int ocorrencias
        {
            get { return this.m_Ocorrencias; }
            set { this.m_Ocorrencias = value; }
        }

        private String m_PagarReceber;
        public String pagarReceber
        {
            get { return this.m_PagarReceber; }
            set { this.m_PagarReceber = value; }
        }

        private Pessoa m_IdPessoa;
        public Pessoa idPessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        //idMovimentoManual
        private ContasAPagarItem[] m_ContasAPagarItems;
        public ContasAPagarItem[] contasAPagarItems
        {
            get { return this.m_ContasAPagarItems; }
            set { this.m_ContasAPagarItems = value; }
        }

        //idMovimentoManual
        private MovimentoManualItem[] m_MovimentoManualItems;
        public MovimentoManualItem[] movimentoManualItems
        {
            get { return this.m_MovimentoManualItems; }
            set { this.m_MovimentoManualItems = value; }
        }

        //idMovimentoManual
        private ContasAReceberItem[] m_ContasAReceberItems;
        public ContasAReceberItem[] contasAReceberItems
        {
            get { return this.m_ContasAReceberItems; }
            set { this.m_ContasAReceberItems = value; }
        }
    }
}