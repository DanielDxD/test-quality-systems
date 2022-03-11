using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvCompraPagamentos : Base
    {
        public PdvCompraPagamentos() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 70),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvPagamento;
        public int idPdvPagamento
        {
            get { return this.m_IdPdvPagamento; }
            set { this.m_IdPdvPagamento = value; }
        }

        private int m_IdPdvCompra;
        public int idvPdvCompra
        {
            get { return this.m_IdPdvCompra; }
            set { this.m_IdPdvCompra = value; }
        }

        [
            TFieldAttributeGridDisplay("Data do Pagamento", 100),
            TFieldAttributeFormat("dd/MM/yyyy HH:mm", "date")
        ]
        private DateTime m_DataPagamento;
        public DateTime dataPagamento
        {
            get { return this.m_DataPagamento; }
            set { this.m_DataPagamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 55),
            TFieldAttributeFormat("C", "money")
        ]
        private Double m_Valor;
        public Double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        [
            TFieldAttributeGridDisplay("Descontos", 55),
            TFieldAttributeFormat("C", "money")
        ]
        private Double m_Descontos;
        public Double descontos
        {
            get { return this.m_Descontos; }
            set { this.m_Descontos = value; }
        }

        [
            TFieldAttributeGridDisplay("Taxa de Serviço", 55),
            TFieldAttributeFormat("C", "money")
        ]
        private Double m_TaxaServico;
        public Double taxaServico
        {
            get { return this.m_TaxaServico; }
            set { this.m_TaxaServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Forma de Pagamento", 55)
        ]
        private string m_FormaPagamento;
        public string formaPagamento
        {
            get { return this.m_FormaPagamento; }
            set { this.m_FormaPagamento = value; }
        }

        private bool m_PrePago;
        public bool prePago
        {
            get { return this.m_PrePago; }
            set { this.m_PrePago = value; }
        }
    }
}
