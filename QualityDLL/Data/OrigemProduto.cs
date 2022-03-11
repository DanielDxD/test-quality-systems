using System;

namespace Data
{
    //[Serializable]
    public class OrigemProduto : Base
    {

        public OrigemProduto() : base()
        {
        }

        private int m_Idorigemproduto;
        public int idOrigemProduto
        {
            get { return this.m_Idorigemproduto; }
            set { this.m_Idorigemproduto = value; }
        }

        private int m_Codigo;
        public int codigo
        {
            get { return this.m_Codigo; }
            set { this.m_Codigo = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

    }
}
