using System;

namespace Data
{
    //[Serializable]
    public class CstPis : Base
    {

        public CstPis() : base()
        {
        }

        private int m_Idcstpis;
        public int idcstpis
        {
            get { return this.m_Idcstpis; }
            set { this.m_Idcstpis = value; }
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
