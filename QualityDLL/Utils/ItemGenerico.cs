using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utils
{
    public class ItemGenerico
    {
        private String m_Id;
        public String id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }
    }
}