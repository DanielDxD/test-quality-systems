using System;
using Utils.Pagina.Attributes;
using System.Runtime.Serialization;

namespace Data
{
    //[Serializable]
    [
            TClassAttributeBusinessIdField("m_IdEmpresa")
    ]
    public class ContasAPagar : Base
    {
        public ContasAPagar()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdContasAPagar;
        public int idContasAPagar
        {
            get { return this.m_IdContasAPagar; }
            set { this.m_IdContasAPagar = value; }
        }

        [
            TFieldAttributeGridDisplay("Nome", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial")
        ]
        private EmpresaRelacionamento m_IdEmpresaRelacionamento;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        /*[
            //TFieldAttributeGridDisplay("Nome", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial")
        ]
        private Fornecedor m_IdFornecedor;
        public Fornecedor fornecedor
        {
            get { return this.m_IdFornecedor; }
            set { this.m_IdFornecedor = value; }
        }*/

        [
            TFieldAttributeGridDisplay("N. Documento", 120),
            TFieldAttributeData(20, false)
        ]
        private String m_NumeroDocumento;
        public String numeroDocumento
        {
            get { return this.m_NumeroDocumento; }
            set { this.m_NumeroDocumento = value; }
        }

        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        [
            TFieldAttributeGridDisplay("Vencto", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataVencimento;
        public DateTime dataVencimento
        {
            get { return this.m_DataVencimento; }
            set { this.m_DataVencimento = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 95),
            TFieldAttributeFormat("C2", "")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private double m_ValorPago;
        public double valorPago
        {
            get { return this.m_ValorPago; }
            set { this.m_ValorPago = value; }
        }

        private double m_Iss;
        public double iss
        {
            get { return this.m_Iss; }
            set { this.m_Iss = value; }
        }

        private double m_Desconto;
        public double desconto
        {
            get { return this.m_Desconto; }
            set { this.m_Desconto = value; }
        }

        private double m_Pago;
        public double pago
        {
            get { return this.m_Pago; }
            set { this.m_Pago = value; }
        }

        [
            TFieldAttributeGridDisplay("Data Baixa", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataUltimoPagamento;
        public DateTime dataUltimoPagamento
        {
            get { return this.m_DataUltimoPagamento; }
            set { this.m_DataUltimoPagamento = value; }
        }
        private DateTime m_DataLancamento;
        public DateTime dataLancamento
        {
            get { return this.m_DataLancamento; }
            set { this.m_DataLancamento = value; }
        }

        [
            TFieldAttributeFormat("checkbox", "checkbox", showField: "n")
        ]
        private String m_EmAberto;
        public String emAberto
        {
            get { return this.m_EmAberto; }
            set { this.m_EmAberto = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        [
            TFieldAttributeGridDisplay("Parcela", 70)
        ]
        private String m_Parcela;
        public String parcela
        {
            get { return this.m_Parcela; }
            set { this.m_Parcela = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        private int m_IdEvento2;
        public int idEvento
        {
            get { return this.m_IdEvento2; }
            set { this.m_IdEvento2 = value; }
        }

        [
            TFieldAttributeGridDisplay("Evento", 200),
            TFieldAttributeSubfield("idEvento:descricao")
        ]
        private Evento m_IdEvento;
        public Evento evento
        {
            get { return this.m_IdEvento; }
            set { this.m_IdEvento = value; }
        }


        [
            TFieldAttributeGridDisplay("Cancelamento", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        //idContasAPagar
        private ContasAPagarPagamento[] m_ContasAPagarPagamentos;
        public ContasAPagarPagamento[] contasAPagarPagamentos
        {
            get { return this.m_ContasAPagarPagamentos; }
            set { this.m_ContasAPagarPagamentos = value; }
        }

        //idContasAPagar
        private ContasAPagarItem[] m_ContasAPagarItems;
        public ContasAPagarItem[] contasAPagarItems
        {
            get { return this.m_ContasAPagarItems; }
            set { this.m_ContasAPagarItems = value; }
        }

        private Parcela[] m_Parcelas;
        public Parcela[] parcelas
        {
            get { return this.m_Parcelas; }
            set { this.m_Parcelas = value; }
        }

        private OutrasInformacoes m_outrasInformacoes;
        public OutrasInformacoes outrasInformacoes
        {
            get { return this.m_outrasInformacoes; }
            set { this.m_outrasInformacoes = value; }
        }

        public class Parcela
        {
            public DateTime dataVencimento { get; set; }
            public Double valor { get; set; }

            public Parcela() { }
        }

        public class OutrasInformacoes
        {
            public int idNaturezaOperacao { get; set; }
            public int idDepartamento { get; set; }
            public string descricao { get; set; }
        }
    }
}