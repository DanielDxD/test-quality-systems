using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTypes
{
    public class Resultados
    {

        private int m_Index;
        public int index
        {
            get { return this.m_Index; }
            set { this.m_Index = value; }
        }

        private string m_Valor;
        public string valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }
    }
}