using System;

namespace Data
{
    //[Serializable]
    public class ProdutoServicoPatrimonioHistorico : Base
    {
        public ProdutoServicoPatrimonioHistorico() : base()
        {
        }

        private int m_IdProdutoServicoPatrimonioHistorico;
        public int idProdutoServicoPatrimonioHistorico
        {
            get { return this.m_IdProdutoServicoPatrimonioHistorico; }
            set { this.m_IdProdutoServicoPatrimonioHistorico = value; }
        }

        private DateTime m_DataHistorico;
        public DateTime dataHistorico
        {
            get { return this.m_DataHistorico; }
            set { this.m_DataHistorico = value; }
        }

        private String m_DataReferencia;
        public String dataReferencia
        {
            get { return this.m_DataReferencia; }
            set { this.m_DataReferencia = value; }
        }

        private ProdutoServicoPatrimonio m_IdProdutoServicoPatrimonio;
        public ProdutoServicoPatrimonio produtoServicoPatrimonio
        {
            get { return this.m_IdProdutoServicoPatrimonio; }
            set { this.m_IdProdutoServicoPatrimonio = value; }
        }

        private Double m_ValorDepreciado;
        public Double valorDepreciado
        {
            get { return this.m_ValorDepreciado; }
            set { this.m_ValorDepreciado = value; }
        }

        private Double m_ValorAtual;
        public Double valorAtual
        {
            get { return this.m_ValorAtual; }
            set { this.m_ValorAtual = value; }
        }

        private String m_Observacao;
        public String observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        public override string ToString()
        {
            return this.m_IdProdutoServicoPatrimonioHistorico.ToString();
        }
    }
}
