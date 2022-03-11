using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [TClassAttributeEdit(2)]
	public class ContaPagamento: Base
	{
		public ContaPagamento(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 123),
            TFieldAttributeData(6, true),
        ]
        private int m_IdContaPagamento;
		public int idContaPagamento
		{
			get{return this.m_IdContaPagamento;}
			set{this.m_IdContaPagamento = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 403),
            TFieldAttributeEditDisplay("Descrição", 123),
            TFieldAttributeData(100, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeEditDisplay("Código de Exportação", 220),
            TFieldAttributeData(120, false)
        ]
        private String m_CodigoExportacao;
        public String codigoExportacao
        {
            get { return this.m_CodigoExportacao; }
            set { this.m_CodigoExportacao = value; }
        }

        [
            TFieldAttributeEditDisplay("Tipo", 123),
            TFieldAttributeData(1, true, true, false),
            TFieldAttributeSubfield("ItemGenerico:C_Caixa;B_Banco")
        ]
        private String m_TipoConta;
        public String tipoConta
        {
            get { return this.m_TipoConta; }
            set { this.m_TipoConta = value; }
        }

        [
            TFieldAttributeEditDisplay("Plano de Contas", 123),
            TFieldAttributeData(6, false, true, false),
            TFieldAttributeSubfield("idPlanoContas:descricao")
        ]
        private PlanoContas m_IdPlanoContas;
        public PlanoContas planoContas
        {
            get { return this.m_IdPlanoContas; }
            set { this.m_IdPlanoContas = value; }
        }

        [
            TFieldAttributeEditDisplay("Banco", 123),
            TFieldAttributeData(6, false, true, false),
            TFieldAttributeSubfield("idBanco:descricao")
        ]
        private Banco m_IdBanco;
        public Banco banco
        {
            get { return this.m_IdBanco; }
            set { this.m_IdBanco = value; }
        }

        [
            TFieldAttributeEditDisplay("Conta", 123),
            TFieldAttributeData(20, false)
        ]
        private String m_NumeroConta;
		public String numeroConta
		{
			get{return this.m_NumeroConta;}
			set{this.m_NumeroConta = value;}
		}

        [
            TFieldAttributeEditDisplay("Usuário", 123),
            TFieldAttributeData(6, false, true, false),
            TFieldAttributeSubfield("idUsuario:@Usuario.idUsuario.pessoa.nomeRazaoSocial")
        ]
        private int m_IdUsuario;
        public int idUsuario
        {
            get { return this.m_IdUsuario; }
            set { this.m_IdUsuario = value; }
        }

        [
            TFieldAttributeEditDisplay("Saldo", 123),
            TFieldAttributeData(12, false),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeKey(false, true)
        ]
        private double m_SaldoAtual;
        public double saldoAtual
        {
            get { return this.m_SaldoAtual; }
            set { this.m_SaldoAtual = value; }
        }

        [
            TFieldAttributeEditDisplay("Recebido(Vinculado)", 123),
            TFieldAttributeData(12, false),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeKey(false, true)
        ]
        private double m_RecebimentoVinculado;
        public double recebimentoVinculado
        {
            get { return this.m_RecebimentoVinculado; }
            set { this.m_RecebimentoVinculado = value; }
        }

        [
            TFieldAttributeEditDisplay("Pago(Vinculado)", 123),
            TFieldAttributeData(12, false),
            TFieldAttributeFormat("C2", "money"),
            TFieldAttributeKey(false, true)
        ]
        private double m_PagamentoVinculado;
        public double pagamentoVinculado
        {
            get { return this.m_PagamentoVinculado; }
            set { this.m_PagamentoVinculado = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private string m_Agencia;
        public string agencia
        {
            get { return this.m_Agencia; }
            set { this.m_Agencia = value; }
        }

        private string m_AgenciaDigito;
        public string agenciaDigito
        {
            get { return this.m_AgenciaDigito; }
            set { this.m_AgenciaDigito = value; }
        }

        private string m_numeroContaDigito;
        public string numeroContaDigito
        {
            get { return this.m_numeroContaDigito; }
            set { this.m_numeroContaDigito = value; }
        }

        [
            TFieldAttributeEditDisplay("Inicial", 123),
            TFieldAttributeData(6, false)
        ]
        private int m_NumeroChequeInicial;
        public int numeroChequeInicial
        {
            get { return this.m_NumeroChequeInicial; }
            set { this.m_NumeroChequeInicial = value; }
        }

        [
            TFieldAttributeEditDisplay("Final", 123),
            TFieldAttributeData(6, false)
        ]
        private int m_NumeroChequeFinal;
        public int numeroChequeFinal
        {
            get { return this.m_NumeroChequeFinal; }
            set { this.m_NumeroChequeFinal = value; }
        }

        //idContaPagamento
        private ContaPagamentoSaldo[] m_ContaPagamentoSaldos;
        public ContaPagamentoSaldo[] contaPagamentoSaldos
        {
            get { return this.m_ContaPagamentoSaldos; }
            set { this.m_ContaPagamentoSaldos = value; }
        }

        [
            TFieldAttributeEditDisplay("Forma de Pagamento", 123),
            TFieldAttributeData(6, false, true, false),
            TFieldAttributeSubfield("idFormaPagamento:@FormaPagamento.descricao")
        ]
        private FormaPagamento m_FormaPagamento;
        public FormaPagamento formaPagamento
        {
            get { return this.m_FormaPagamento; }
            set { this.m_FormaPagamento = value; }
        }

        public override string ToString()
        {
            return this.m_IdContaPagamento.ToString();
        }
    }
}
