using System;

namespace Data
{
    //[Serializable]
    public class Boleto : Base
    {
        public Boleto() : base()
        {
        }

        private int m_IdBoleto;
        public int idBoleto
        {
            get { return this.m_IdBoleto; }
            set { this.m_IdBoleto = value; }
        }

        private ParametroBoleto m_IdParametroBoleto;
        public ParametroBoleto parametroBoleto
        {
            get { return this.m_IdParametroBoleto; }
            set { this.m_IdParametroBoleto = value; }
        }

        private DateTime m_DataEmissao;
        public DateTime dataEmissao
        {
            get { return this.m_DataEmissao; }
            set { this.m_DataEmissao = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private DateTime m_DataVencimento;
        public DateTime dataVencimento
        {
            get { return this.m_DataVencimento; }
            set { this.m_DataVencimento = value; }
        }

        private String m_NossoNumero;
        public String nossoNumero
        {
            get { return this.m_NossoNumero; }
            set { this.m_NossoNumero = value; }
        }

        private double m_ValorTaxa;
        public double valorTaxa
        {
            get { return this.m_ValorTaxa; }
            set { this.m_ValorTaxa = value; }
        }

        private DateTime m_DataRegistro;
        public DateTime dataRegistro
        {
            get { return this.m_DataRegistro; }
            set { this.m_DataRegistro = value; }
        }

        private String m_StatusBoleto;
        public String statusBoleto
        {
            get
            {
                switch (this.m_StatusBoleto)
                {
                    case "R": return "Rejeitado";
                    case "A": return "Registrado";
                    case "E": return "Emitido";
                }
                return this.m_StatusBoleto;
            }
            set { this.m_StatusBoleto = value; }
        }

        private String m_StatusBoletoQuery;
        public String statusBoletoQuery
        {
            get
            {
                return this.m_StatusBoletoQuery;
            }
            set { this.m_StatusBoletoQuery = value; }
        }

        private String m_CodigoBarras;
        public String codigoBarras
        {
            get { return this.m_CodigoBarras; }
            set { this.m_CodigoBarras = value; }
        }

        private int m_CodigoRetorno;
        public int codigoRetorno
        {
            get { return this.m_CodigoRetorno; }
            set { this.m_CodigoRetorno = value; }
        }

        private String m_NossoNumeroDigito;
        public String nossoNumeroDigito
        {
            get { return this.m_NossoNumeroDigito; }
            set { this.m_NossoNumeroDigito = value; }
        }

        //idBoleto
        private BoletoItem[] m_BoletoItems;
        public BoletoItem[] boletoItems
        {
            get { return this.m_BoletoItems; }
            set { this.m_BoletoItems = value; }
        }

        public override string ToString()
        {
            return this.m_IdBoleto.ToString();
        }
    }
}
