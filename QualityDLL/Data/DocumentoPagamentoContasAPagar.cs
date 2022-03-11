using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [
        TClassAttributeFields
        (
            new String[]
            {
                "m_IdDocumentoPagamentoContasAPagar",
                "m_IdContasAPagar.m_IdEmpresaRelacionamento",
                "m_IdContasAPagar.m_Valor",
                "m_IdContasAPagar.m_DataVencimento",
//                "m_ValorABaixar",
                "m_ValorBase",
                "m_ValorPago",
                "m_ValorMulta",
                "m_ValorJuros",
                "m_ValorDesconto",
                "m_ValorCM",
                "m_ValorINSSRetido",
                "m_ValorISSRetido",
                "m_ValorIRRetido",
                "m_ValorPISRetido",
                "m_ValorCOFINSRetido",
                "m_ValorCSLLRetido"
            }
        ),
        TClassAttributeEdit(2)
    ]
    public class DocumentoPagamentoContasAPagar : Base
    {
        public DocumentoPagamentoContasAPagar()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdDocumentoPagamentoContasAPagar;
        public int idDocumentoPagamentoContasAPagar
        {
            get { return this.m_IdDocumentoPagamentoContasAPagar; }
            set { this.m_IdDocumentoPagamentoContasAPagar = value; }
        }

        [
            TFieldAttributeEditDisplay("Base", 123),
            TFieldAttributeData(12, false),
            TFieldAttributeKey(false, true)
        ]
        private double m_ValorBase;
        public double valorBase
        {
            get { return this.m_ValorBase; }
            set { this.m_ValorBase = value; }
        }

        [
            TFieldAttributeGridDisplay("À Baixar", 123),
            TFieldAttributeEditDisplay("À Baixar", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorPago;
        public double valorPago
        {
            get { return this.m_ValorPago; }
            set { this.m_ValorPago = value; }
        }

        [
            TFieldAttributeEditDisplay("Multa", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorMulta;
        public double valorMulta
        {
            get { return this.m_ValorMulta; }
            set { this.m_ValorMulta = value; }
        }

        [
            TFieldAttributeEditDisplay("Juros", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorJuros;
        public double valorJuros
        {
            get { return this.m_ValorJuros; }
            set { this.m_ValorJuros = value; }
        }

        [
            TFieldAttributeEditDisplay("Desconto", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        [
            TFieldAttributeEditDisplay("C. Monetária", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorCM;
        public double valorCM
        {
            get { return this.m_ValorCM; }
            set { this.m_ValorCM = value; }
        }

        [
            TFieldAttributeEditDisplay("INSS Retido", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorINSSRetido;
        public double valorINSSRetido
        {
            get { return this.m_ValorINSSRetido; }
            set { this.m_ValorINSSRetido = value; }
        }

        [
            TFieldAttributeEditDisplay("ISS Retido", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorISSRetido;
        public double valorISSRetido
        {
            get { return this.m_ValorISSRetido; }
            set { this.m_ValorISSRetido = value; }
        }

        [
            TFieldAttributeEditDisplay("IR Retido", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorIRRetido;
        public double valorIRRetido
        {
            get { return this.m_ValorIRRetido; }
            set { this.m_ValorIRRetido = value; }
        }

        [
            TFieldAttributeEditDisplay("PIS Retido", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorPISRetido;
        public double valorPISRetido
        {
            get { return this.m_ValorPISRetido; }
            set { this.m_ValorPISRetido = value; }
        }

        [
            TFieldAttributeEditDisplay("COFINS Retido", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorCOFINSRetido;
        public double valorCOFINSRetido
        {
            get { return this.m_ValorCOFINSRetido; }
            set { this.m_ValorCOFINSRetido = value; }
        }

        [
            TFieldAttributeEditDisplay("CSLL Retido", 123),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeData(12, false)
        ]
        private double m_ValorCSLLRetido;
        public double valorCSLLRetido
        {
            get { return this.m_ValorCSLLRetido; }
            set { this.m_ValorCSLLRetido = value; }
        }

        //[
        //    TFieldAttributeGridDisplay("A Baixar", 80),
        //    TFieldAttributeFormat("C2", "money"),
        //    TFieldAttributeData(12, false)
        //]
        //private double m_ValorABaixar;
        //public double valorABaixar
        //{
        //    get { return this.m_ValorABaixar; }
        //    set { this.m_ValorABaixar = value; }
        //}

        private int m_IdDocumentoPagamento;
        public int idDocumentoPagamento
        {
            get { return this.m_IdDocumentoPagamento; }
            set { this.m_IdDocumentoPagamento = value; }
        }

        private ContasAPagar m_IdContasAPagar;
        public ContasAPagar contasAPagar
        {
            get { return this.m_IdContasAPagar; }
            set { this.m_IdContasAPagar = value; }
        }
    }
}