using System;

namespace Data
{
    //[Serializable]
    public class CstIpi : Base
    {

        public CstIpi() : base()
        {
        }

        private int m_Idcstipi;
        public int idcstipi
        {
            get { return this.m_Idcstipi; }
            set { this.m_Idcstipi = value; }
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
