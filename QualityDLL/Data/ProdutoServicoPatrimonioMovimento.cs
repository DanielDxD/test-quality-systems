using System;

namespace Data
{
    //[Serializable]
    public class ProdutoServicoPatrimonioMovimento : Base
    {
        public ProdutoServicoPatrimonioMovimento() : base()
        {
        }

        private int m_IdProdutoServicoPatrimonioMovimento;
        public int idProdutoServicoPatrimonioMovimento
        {
            get { return this.m_IdProdutoServicoPatrimonioMovimento; }
            set { this.m_IdProdutoServicoPatrimonioMovimento = value; }
        }

        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private string m_TipoOperacao;
        public string tipoOperacao
        {
            get { return this.m_TipoOperacao; }
            set { this.m_TipoOperacao = value; }
        }

        private ProdutoServicoPatrimonio m_IdProdutoServicoPatrimonio;
        public ProdutoServicoPatrimonio produtoServicoPatrimonio
        {
            get { return this.m_IdProdutoServicoPatrimonio; }
            set { this.m_IdProdutoServicoPatrimonio = value; }
        }

        private Departamento m_IdDepartamentoOrigem;
        public Departamento departamentoOrigem
        {
            get { return this.m_IdDepartamentoOrigem; }
            set { this.m_IdDepartamentoOrigem = value; }
        }

        private Departamento m_IdDepartamentoDestino;
        public Departamento departamentoDestino
        {
            get { return this.m_IdDepartamentoDestino; }
            set { this.m_IdDepartamentoDestino = value; }
        }

        private Double m_ValorMovimento;
        public Double valorMovimento
        {
            get { return this.m_ValorMovimento; }
            set { this.m_ValorMovimento = value; }
        }

        public override string ToString()
        {
            return this.m_IdProdutoServicoPatrimonioMovimento.ToString();
        }
    }
}
