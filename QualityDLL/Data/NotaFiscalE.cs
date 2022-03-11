using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class NotaFiscalE : Base
    {
        public NotaFiscalE()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdNotaFiscalE;
        public int idNotaFiscalE
        {
            get { return this.m_IdNotaFiscalE; }
            set { this.m_IdNotaFiscalE = value; }
        }

        private String m_Numero;
        public String numero
        {
            get { return this.m_Numero; }
            set { this.m_Numero = value; }
        }

        private String m_NaturezaOperacao;
        public String naturezaOperacao
        {
            get { return this.m_NaturezaOperacao; }
            set { this.m_NaturezaOperacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Fornecedor", 240),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idFornecedor:pessoa.nomeRazaoSocial")
        ]
        private Fornecedor m_IdFornecedor;
        public Fornecedor fornecedor
        {
            get { return this.m_IdFornecedor; }
            set { this.m_IdFornecedor = value; }
        }

        private DateTime m_DataEntrada;
        public DateTime dataEntrada
        {
            get { return this.m_DataEntrada; }
            set { this.m_DataEntrada = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 85),
            TFieldAttributeData(10, false),
            TFieldAttributeFormat("C2", "")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }
        

        [
            TFieldAttributeGridDisplay("Data de Emissão", 130),
            TFieldAttributeData(10, false)
        ]
        private DateTime m_DataEmissao;
        public DateTime dataEmissao
        {
            get { return this.m_DataEmissao; }
            set { this.m_DataEmissao = value; }
        }

        private DateTime m_DataVencimento;
        public DateTime dataVencimento
        {
            get { return this.m_DataVencimento; }
            set { this.m_DataVencimento = value; }
        }

        private double m_Iss;
        public double iss
        {
            get { return this.m_Iss; }
            set { this.m_Iss = value; }
        }

        private double m_Pis;
        public double pis
        {
            get { return this.m_Pis; }
            set { this.m_Pis = value; }
        }

        private double m_Cofins;
        public double cofins
        {
            get { return this.m_Cofins; }
            set { this.m_Cofins = value; }
        }

        private double m_Icms;
        public double icms
        {
            get { return this.m_Icms; }
            set { this.m_Icms = value; }
        }

        private double m_IcmsST;
        public double icmsST
        {
            get { return this.m_IcmsST; }
            set { this.m_IcmsST = value; }
        }

        private double m_Ir;
        public double ir
        {
            get { return this.m_Ir; }
            set { this.m_Ir = value; }
        }

        private double m_Ipi;
        public double ipi
        {
            get { return this.m_Ipi; }
            set { this.m_Ipi = value; }
        }

        private double m_Frete;
        public double frete
        {
            get { return this.m_Frete; }
            set { this.m_Frete = value; }
        }

        private double m_IcmsFrete;
        public double icmsFrete
        {
            get { return this.m_IcmsFrete; }
            set { this.m_IcmsFrete = value; }
        }

        private double m_Desconto;
        public double desconto
        {
            get { return this.m_Desconto; }
            set { this.m_Desconto = value; }
        }

        private bool m_IcmsIncluso;
        public bool icmsIncluso
        {
            get { return this.m_IcmsIncluso; }
            set { this.m_IcmsIncluso = value; }
        }

        private bool m_FreteIncluso;
        public bool freteIncluso
        {
            get { return this.m_FreteIncluso; }
            set { this.m_FreteIncluso = value; }
        }

        private double m_OutrasDespesas;
        public double outrasDespesas
        {
            get { return this.m_OutrasDespesas; }
            set { this.m_OutrasDespesas = value; }
        }

        private double m_ValorTotal;
        public double valorTotal
        {
            get { return this.m_ValorTotal; }
            set { this.m_ValorTotal = value; }
        }

        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private CondicaoPagamento m_IdCondicaoPagamento;
        public CondicaoPagamento condicaoPagamento
        {
            get { return this.m_IdCondicaoPagamento; }
            set { this.m_IdCondicaoPagamento = value; }
        }

        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        private int m_Parcelas;
        public int parcelas
        {
            get { return this.m_Parcelas; }
            set { this.m_Parcelas = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }
        
        //idNotaFiscal
        private NotaFiscalEEntradaMercadoria[] m_NotaFiscalEEntradaMercadorias;
        public NotaFiscalEEntradaMercadoria[] notaFiscalEEntradaMercadorias
        {
            get { return this.m_NotaFiscalEEntradaMercadorias; }
            set { this.m_NotaFiscalEEntradaMercadorias = value; }
        }

        //idNotaFiscal
        private NotaFiscalEPedidoCompra[] m_NotaFiscalEPedidoCompras;
        public NotaFiscalEPedidoCompra[] notaFiscalEPedidoCompras
        {
            get { return this.m_NotaFiscalEPedidoCompras; }
            set { this.m_NotaFiscalEPedidoCompras = value; }
        }

        //idNotaFiscal
        private NotaFiscalEItem[] m_NotaFiscalEItems;
        public NotaFiscalEItem[] notaFiscalEItems
        {
            get { return this.m_NotaFiscalEItems; }
            set { this.m_NotaFiscalEItems = value; }
        }

        private ContasAPagar[] m_ContasAPagar;
        public ContasAPagar[] contasAPagar
        {
            get { return this.m_ContasAPagar; }
            set { this.m_ContasAPagar = value; }
        }

    }
}