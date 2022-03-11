using System;

namespace Data
{
    //[Serializable]
    public class CstCofins : Base
    {

        public CstCofins() : base()
        {
        }

        private int m_Idcstcofins;
        public int idcstCofins
        {
            get { return this.m_Idcstcofins; }
            set { this.m_Idcstcofins = value; }
        }

        private int m_Cst;
        public int cst
        {
            get { return this.m_Cst; }
            set { this.m_Cst = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

    }
}
