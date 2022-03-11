using System;

namespace Data
{
    //[Serializable]
    public class MovimentoManualItem : Base
    {
        public MovimentoManualItem()
            : base()
        {
        }

        private int m_IdMovimentoManualItem;
        public int idMovimentoManualItem
        {
            get { return this.m_IdMovimentoManualItem; }
            set { this.m_IdMovimentoManualItem = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private double m_AliquotaIss;
        public double aliquotaIss
        {
            get { return this.m_AliquotaIss; }
            set { this.m_AliquotaIss = value; }
        }

        private double m_ValorIss;
        public double valorIss
        {
            get { return this.m_ValorIss; }
            set { this.m_ValorIss = value; }
        }

        private double m_AliquotaIcms;
        public double aliquotaIcms
        {
            get { return this.m_AliquotaIcms; }
            set { this.m_AliquotaIcms = value; }
        }

        private double m_ValorIcms;
        public double valorIcms
        {
            get { return this.m_ValorIcms; }
            set { this.m_ValorIcms = value; }
        }

        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private MovimentoManual m_IdMovimentoManual;
        public MovimentoManual idMovimentoManual
        {
            get { return this.m_IdMovimentoManual; }
            set { this.m_IdMovimentoManual = value; }
        }

        private Servico m_IdServico;
        public Servico idServico
        {
            get { return this.m_IdServico; }
            set { this.m_IdServico = value; }
        }

        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico idProdutoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }
    }
}