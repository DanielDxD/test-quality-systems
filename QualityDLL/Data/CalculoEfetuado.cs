using System;

namespace Data
{
    //[Serializable]
    public class CalculoEfetuado : Base
    {

        public CalculoEfetuado() : base()
        {
        }

        private int m_IdCalculoEfetuado;
        public int idCalculoEfetuado
        {
            get { return this.m_IdCalculoEfetuado; }
            set { this.m_IdCalculoEfetuado = value; }
        }

        private DateTime m_DataCalculo;
        public DateTime dataCalculo
        {
            get { return this.m_DataCalculo; }
            set { this.m_DataCalculo = value; }
        }

        private Funcionario m_IdFuncionario;
        public Funcionario funcionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }

        private double m_ValorApurado;
        public double valorApurado
        {
            get { return this.m_ValorApurado; }
            set { this.m_ValorApurado = value; }
        }

    }
}
