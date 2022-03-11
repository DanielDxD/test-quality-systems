using System;

namespace Data
{
    //[Serializable]
    public class Terminal : Base
    {

        public Terminal() : base()
        {
        }

        private int m_IdTerminal;
        public int idTerminal
        {
            get { return this.m_IdTerminal; }
            set { this.m_IdTerminal = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private int m_NumeroTerminal;
        public int numeroTerminal
        {
            get { return this.m_NumeroTerminal; }
            set { this.m_NumeroTerminal = value; }
        }

        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

    }
}
