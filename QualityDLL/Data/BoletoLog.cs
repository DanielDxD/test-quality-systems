using System;

namespace Data
{
    //[Serializable]
    public class BoletoLog : Base
    {

        public BoletoLog() : base()
        {
        }

        private int m_IdBoletoLog;
        public int idBoletoLog
        {
            get { return this.m_IdBoletoLog; }
            set { this.m_IdBoletoLog = value; }
        }

        private Usuario m_IdUsuario;
        public Usuario usuario
        {
            get { return this.m_IdUsuario; }
            set { this.m_IdUsuario = value; }
        }

        private DateTime m_DataInicio;
        public DateTime dataInicio
        {
            get { return this.m_DataInicio; }
            set { this.m_DataInicio = value; }
        }

        private DateTime m_DataFim;
        public DateTime dataFim
        {
            get { return this.m_DataFim; }
            set { this.m_DataFim = value; }
        }

        private int m_IdBoletoInicial;
        public int idBoletoInicial
        {
            get { return this.m_IdBoletoInicial; }
            set { this.m_IdBoletoInicial = value; }
        }

        private int m_IdBoletoFinal;
        public int idBoletoFinal
        {
            get { return this.m_IdBoletoFinal; }
            set { this.m_IdBoletoFinal = value; }
        }

        private int m_QtdBoletos;
        public int qtdBoletos
        {
            get { return this.m_QtdBoletos; }
            set { this.m_QtdBoletos = value; }
        }

        private int m_QtdBoletosProcessados;
        public int qtdBoletosProcessados
        {
            get { return this.m_QtdBoletosProcessados; }
            set { this.m_QtdBoletosProcessados = value; }
        }

        private string m_ArquivoCNAB;
        public string arquivoCNAB
        {
            get { return this.m_ArquivoCNAB; }
            set { this.m_ArquivoCNAB = value; }
        }

        private string m_ArquivoPDF;
        public string arquivoPDF
        {
            get { return this.m_ArquivoPDF; }
            set { this.m_ArquivoPDF = value; }
        }

        private string m_StatusProcesso;
        public string statusProcesso
        {
            get { return this.m_StatusProcesso; }
            set { this.m_StatusProcesso = value; }
        }

        private double m_Percentual;
        public double percentual
        {

            get { return this.m_Percentual; }
            set { this.m_Percentual = value; }
        }

    }
}
