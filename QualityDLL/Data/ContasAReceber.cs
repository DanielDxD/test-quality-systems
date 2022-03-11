using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ContasAReceber : Base
    {
        public ContasAReceber()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdContasAReceber;
        public int idContasAReceber
        {
            get { return this.m_IdContasAReceber; }
            set { this.m_IdContasAReceber = value; }
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

        [
            TFieldAttributeGridDisplay("N. Documento", 100),
            TFieldAttributeData(20, false)
        ]
        private String m_NumeroDocumento;
        public String numeroDocumento
        {
            get { return this.m_NumeroDocumento; }
            set { this.m_NumeroDocumento = value; }
        }

        private DateTime m_DataLancamento;
        public DateTime dataLancamento
        {
            get { return this.m_DataLancamento; }
            set { this.m_DataLancamento = value; }
        }

        private DateTime m_DataLancamentoEfetivo;
        public DateTime dataLancamentoEfetivo
        {
            get { return this.m_DataLancamentoEfetivo; }
            set { this.m_DataLancamentoEfetivo = value; }
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

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
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

        [
            TFieldAttributeGridDisplay("Parcela", 70)
        ]
        private String m_Parcela;
        public String parcela
        {
            get { return this.m_Parcela; }
            set { this.m_Parcela = value; }
        }

        private Parcela[] m_Parcelas;
        public Parcela[] parcelas
        {
            get { return this.m_Parcelas; }
            set { this.m_Parcelas = value; }
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

        private double m_valorRecebido;
        public double valorRecebido
        {
            get { return this.m_valorRecebido; }
            set { this.m_valorRecebido = value; }
        }

        [
            TFieldAttributeGridDisplay("Data Baixa", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataUltimoRecebimento;
        public DateTime dataUltimoRecebimento
        {
            get { return this.m_DataUltimoRecebimento; }
            set { this.m_DataUltimoRecebimento = value; }
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

        [
            TFieldAttributeFormat("checkbox", "checkbox", showField: "n")
        ]
        private String m_EmAberto;
        public String emAberto
        {
            get { return this.m_EmAberto; }
            set { this.m_EmAberto = value; }
        }

        /*
        private Pessoa m_IdPessoa;
        public Pessoa pessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }
        */

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        //idContasAReceber
        private NotaFiscalSItem[] m_NotaFiscalSItems;
        public NotaFiscalSItem[] notaFiscalSItems
        {
            get { return this.m_NotaFiscalSItems; }
            set { this.m_NotaFiscalSItems = value; }
        }

        //idContasAReceber
        private ContasAReceberPagamento[] m_ContasAReceberPagamentos;
        public ContasAReceberPagamento[] contasAReceberPagamentos
        {
            get { return this.m_ContasAReceberPagamentos; }
            set { this.m_ContasAReceberPagamentos = value; }
        }

        //idContasAReceber
        private BoletoItem[] m_BoletoItems;
        public BoletoItem[] boletoItems
        {
            get { return this.m_BoletoItems; }
            set { this.m_BoletoItems = value; }
        }

        //idContasAReceber
        private CaixaMovimentoLancamento[] m_CaixaMovimentoLancamentos;
        public CaixaMovimentoLancamento[] caixaMovimentoLancamentos
        {
            get { return this.m_CaixaMovimentoLancamentos; }
            set { this.m_CaixaMovimentoLancamentos = value; }
        }

        //idContasAReceber
        private ContasAReceberItem[] m_ContasAReceberItems;
        public ContasAReceberItem[] contasAReceberItems
        {
            get { return this.m_ContasAReceberItems; }
            set { this.m_ContasAReceberItems = value; }
        }

        public class Parcela
        {
            public DateTime dataVencimento { get; set; }
            public Double valor { get; set; }

            public Parcela() { }
        }

        private double m_jurosSugerido;
        public double jurosSugerido
        {
            get { return this.m_jurosSugerido; }
            set { this.m_jurosSugerido = value; }
        }

        private double m_MultaSugerida;
        public double multaSugerida
        {
            get { return this.m_MultaSugerida; }
            set { this.m_MultaSugerida = value; }
        }

        private double m_DescontoSugerido;
        public double descontoSugerido
        {
            get { return this.m_DescontoSugerido; }
            set { this.m_DescontoSugerido = value; }
        }

        private bool m_ignorarBaixa;
        public bool ignorarBaixa
        {
            get { return this.m_ignorarBaixa; }
            set { this.m_ignorarBaixa = value; }
        }



        private double m_JurosQuitado;
        public double jurosQuitado
        {
            get { return this.m_JurosQuitado; }
            set { this.m_JurosQuitado = value; }
        }
    }
}