using System;

namespace Data
{
    //[Serializable]
    public class CstIcms : Base
    {

        public CstIcms() : base()
        {
        }

        private int m_Idcsticms;
        public int idcstIcms
        {
            get { return this.m_Idcsticms; }
            set { this.m_Idcsticms = value; }
        }

        private int m_Cstcsosn;
        public int cstCsosn
        {
            get { return this.m_Cstcsosn; }
            set { this.m_Cstcsosn = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

    }
}
