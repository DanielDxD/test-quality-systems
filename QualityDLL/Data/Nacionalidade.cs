using System;

namespace Data
{
    //[Serializable]
    public class Nacionalidade : Base
    {

        public Nacionalidade() : base()
        {
        }

        private int m_IdNacionalidade;
        public int idNacionalidade
        {
            get { return this.m_IdNacionalidade; }
            set { this.m_IdNacionalidade = value; }
        }

        private int m_Codigo;
        public int codigo
        {
            get { return this.m_Codigo; }
            set { this.m_Codigo = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

    }
}
