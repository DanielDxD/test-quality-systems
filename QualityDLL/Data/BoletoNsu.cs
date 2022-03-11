using System;

namespace Data
{
    //[Serializable]
    public class BoletoNsu : Base
    {

        public BoletoNsu() : base()
        {
        }

        private int m_IdBoletoNsu;
        public int idBoletoNsu
        {
            get { return this.m_IdBoletoNsu; }
            set { this.m_IdBoletoNsu = value; }
        }

        private Boleto m_IdBoleto;
        public Boleto boleto
        {
            get { return this.m_IdBoleto; }
            set { this.m_IdBoleto = value; }
        }

        private string m_Nsu;
        public string nsu
        {
            get { return this.m_Nsu; }
            set { this.m_Nsu = value; }
        }

        private DateTime m_DataRegistro;
        public DateTime dataRegistro
        {
            get { return this.m_DataRegistro; }
            set { this.m_DataRegistro = value; }
        }

    }
}
