using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [
        TClassAttributeBusinessIdField("m_IdContaPagamento.m_IdEmpresa")
    ]
    public class ContaPagamentoMovimento : Base
    {
        public ContaPagamentoMovimento()
            : base()
        {
            this.m_NumeroDocumento = "";
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdContaPagamentoMovimento;
        public int idContaPagamentoMovimento
        {
            get { return this.m_IdContaPagamentoMovimento; }
            set { this.m_IdContaPagamentoMovimento = value; }
        }

        [
            TFieldAttributeGridDisplay("Dt. Movimento", 108)
        ]
        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 275)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private String m_Observacao;
        public String observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 100),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private double m_ValorMulta;
        public double valorMulta
        {
            get { return this.m_ValorMulta; }
            set { this.m_ValorMulta = value; }
        }

        public bool origemTerminalPdv { get; set; }

        private double m_ValorJuros;
        public double valorJuros
        {
            get { return this.m_ValorJuros; }
            set { this.m_ValorJuros = value; }
        }

        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private double m_ValorCM;
        public double valorCM
        {
            get { return this.m_ValorCM; }
            set { this.m_ValorCM = value; }
        }

        private double m_ValorINSSRetido;
        public double valorINSSRetido
        {
            get { return this.m_ValorINSSRetido; }
            set { this.m_ValorINSSRetido = value; }
        }

        private double m_ValorISSRetido;
        public double valorISSRetido
        {
            get { return this.m_ValorISSRetido; }
            set { this.m_ValorISSRetido = value; }
        }

        private double m_ValorIRRetido;
        public double valorIRRetido
        {
            get { return this.m_ValorIRRetido; }
            set { this.m_ValorIRRetido = value; }
        }

        private double m_ValorPISRetido;
        public double valorPISRetido
        {
            get { return this.m_ValorPISRetido; }
            set { this.m_ValorPISRetido = value; }
        }

        private double m_ValorCOFINSRetido;
        public double valorCOFINSRetido
        {
            get { return this.m_ValorCOFINSRetido; }
            set { this.m_ValorCOFINSRetido = value; }
        }

        private int m_IdFuncionario;
        public int idFuncionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }

        private double m_ValorCSLLRetido;
        public double valorCSLLRetido
        {
            get { return this.m_ValorCSLLRetido; }
            set { this.m_ValorCSLLRetido = value; }
        }

        private bool m_IgnorarRecibo;
        public bool ignorarRecibo
        {
            get { return this.m_IgnorarRecibo; }
            set { this.m_IgnorarRecibo = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Num. Doc.", 103)
        ]
        private String m_NumeroDocumento;
        public String numeroDocumento
        {
            get
            {
                return
                (
                    (
                        ((this.m_IdDocumentoPagamento != null) || (this.m_IdDocumentoRecebimento != null)) ?
                        (
                            (this.m_IdDocumentoPagamento != null) ?
                            this.m_IdDocumentoPagamento.numeroDocumento :
                            this.m_IdDocumentoRecebimento.numeroDocumento
                        ) :
                        this.m_NumeroDocumento
                    )
                );
            }

            set { this.m_NumeroDocumento = value; }
        }

        [
            TFieldAttributeGridDisplay("Dt. Vencto.", 100)
        ]
        private DateTime m_DataVencimento;
        public DateTime dataVencimento
        {
            get
            {
                return
                (
                    (
                        (this.m_IdDocumentoRecebimento != null) ?
                        this.m_IdDocumentoRecebimento.dataVencimento :
                        new DateTime(0)
                    )
                );
            }

            set { this.m_DataVencimento = value; }
        }

        private DocumentoPagamento m_IdDocumentoPagamento;
        public DocumentoPagamento documentoPagamento
        {
            get { return this.m_IdDocumentoPagamento; }
            set { this.m_IdDocumentoPagamento = value; }
        }

        private DocumentoRecebimento m_IdDocumentoRecebimento;
        public DocumentoRecebimento documentoRecebimento
        {
            get { return this.m_IdDocumentoRecebimento; }
            set { this.m_IdDocumentoRecebimento = value; }
        }

        private DateTime m_DataConciliacao;
        public DateTime dataConciliacao
        {
            get { return this.m_DataConciliacao; }
            set { this.m_DataConciliacao = value; }
        }

        private DocumentoTransferencia m_IdDocumentoTransferenciaEntrada;
        public DocumentoTransferencia documentoTransferenciaEntrada
        {
            get { return this.m_IdDocumentoTransferenciaEntrada; }
            set { this.m_IdDocumentoTransferenciaEntrada = value; }
        }

        private DocumentoTransferencia m_IdDocumentoTransferenciaSaida;
        public DocumentoTransferencia documentoTransferenciaSaida
        {
            get { return this.m_IdDocumentoTransferenciaSaida; }
            set { this.m_IdDocumentoTransferenciaSaida = value; }
        }

        private int m_IdDocumentoTransferenciaItem;
        public int idDocumentoTransferenciaItem
        {
            get { return this.m_IdDocumentoTransferenciaItem; }
            set { this.m_IdDocumentoTransferenciaItem = value; }
        }

        private int m_IdPdvEstacao;
        public int idPdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        private int m_IdPdvCompraTaxaServico;
        public int idPdvCompraTaxaServico
        {
            get { return this.m_IdPdvCompraTaxaServico; }
            set { this.m_IdPdvCompraTaxaServico = value; }
        }

        private int m_IdPdvCompra;
        public int idPdvCompra
        {
            get { return this.m_IdPdvCompra; }
            set { this.m_IdPdvCompra = value; }
        }

        private bool m_IgnoraBaixa;
        public bool ignoraBaixa { get; set; }
    }
}
