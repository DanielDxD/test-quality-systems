using System;

namespace Data
{
    //[Serializable]
    public class Feriado : Base
    {

        public Feriado() : base()
        {
        }

        private int m_IdFeriado;
        public int idFeriado
        {
            get { return this.m_IdFeriado; }
            set { this.m_IdFeriado = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private int m_Dia;
        public int dia
        {
            get { return this.m_Dia; }
            set { this.m_Dia = value; }
        }

        private int m_Mes;
        public int mes
        {
            get { return this.m_Mes; }
            set { this.m_Mes = value; }
        }

        private int m_Ano;
        public int ano
        {
            get { return this.m_Ano; }
            set { this.m_Ano = value; }
        }

    }
}
