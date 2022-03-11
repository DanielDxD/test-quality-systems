using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTypes
{
    public class Colunas
    {

        private string m_Descricao;
        public string descricao
        {
            get { return m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private int m_index;
        public int index
        {
            get { return m_index; }
            set { this.m_index = value; }
        }
    }
}