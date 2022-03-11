using System;

namespace Data
{
    //[Serializable]
    public class CfOp : Base
    {

        public CfOp() : base()
        {
        }

        private int m_Idcfop;
        public int idCfop
        {
            get { return this.m_Idcfop; }
            set { this.m_Idcfop = value; }
        }

        private int m_Codigo;
        public int codigo
        {
            get { return this.m_Codigo; }
            set { this.m_Codigo = value; }
        }

        private int m_Tipo;
        public int tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_Ativo;
        public string ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

    }
}
