using System;

namespace Data
{
    //[Serializable]
    public class ProdutoServicoEstoque : Base
    {
        public ProdutoServicoEstoque() : base()
        {
        }

        private int m_IdProdutoServicoEstoque;
        public int idProdutoServicoEstoque
        {
            get { return this.m_IdProdutoServicoEstoque; }
            set { this.m_IdProdutoServicoEstoque = value; }
        }

        private DateTime m_DataFabricacao;
        public DateTime dataFabricacao
        {
            get { return this.m_DataFabricacao; }
            set { this.m_DataFabricacao = value; }
        }

        private DateTime m_DataValidade;
        public DateTime dataValidade
        {
            get { return this.m_DataValidade; }
            set { this.m_DataValidade = value; }
        }

        private bool m_Patrimonio;
        public bool patrimonio
        {
            get { return this.m_Patrimonio; }
            set { this.m_Patrimonio = value; }
        }

        private String m_NumeroLote;
        public String numeroLote
        {
            get { return this.m_NumeroLote; }
            set { this.m_NumeroLote = value; }
        }

        private double m_Quantidade;
        public double quantidade
        {
            get { return this.m_Quantidade; }
            set { this.m_Quantidade = value; }
        }

        private int m_IdProdutoServico;
        public int idProdutoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        private int m_IdDepartamento2;
        public int idDepartamento
        {
            get { return this.m_IdDepartamento2; }
            set { this.m_IdDepartamento2 = value; }
        }

        private Departamento m_IdDepartamento;
        public Departamento departamento
        {

            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }
        private Data.ProdutoServico m_produtoServico;
        public Data.ProdutoServico produtoServico
        {
            get { return this.m_produtoServico; }
            set { this.m_produtoServico = value; }
        }

        public override string ToString()
        {
            return this.m_IdProdutoServicoEstoque.ToString();
        }
    }
}
