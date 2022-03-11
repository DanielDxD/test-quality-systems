using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacaoCategoriaProduto : Base
    {

        public PdvEstacaoCategoriaProduto() : base()
        {
        }

        private int m_IdPdvEstacaoCategoriaProduto;
        public int idPdvEstacaoCategoriaProduto
        {
            get { return this.m_IdPdvEstacaoCategoriaProduto; }
            set { this.m_IdPdvEstacaoCategoriaProduto = value; }
        }

        private PdvEstacaoCategoria m_IdPdvEstacaoCategoria;
        public PdvEstacaoCategoria pdvEstacaoCategoria
        {
            get { return this.m_IdPdvEstacaoCategoria; }
            set { this.m_IdPdvEstacaoCategoria = value; }
        }

        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        private int m_Ordem;
        public int ordem
        {
            get { return this.m_Ordem; }
            set { this.m_Ordem = value; }
        }

    }
}
