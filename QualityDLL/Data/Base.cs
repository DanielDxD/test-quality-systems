using System;
using System.Linq;

/// <summary>
/// Summary description for Base
/// </summary>

namespace Data
{
    //[Serializable]
    public class Base
    {
        private ENum.eOperacao m_Operacao;
        private string m_SqlRetorno;
        private bool m_IsPos;

        public Base()
        {
        }

        public ENum.eOperacao operacao
        {
            get { return this.m_Operacao; }
            set { this.m_Operacao = value; }
        }

        public string sqlRetorno
        {
            get { return this.m_SqlRetorno; }
            set { this.m_SqlRetorno = value; }
        }

        public bool isPos
        {
            get { return this.m_IsPos; }
            set { this.m_IsPos = value; }
        }  
    }
}
