using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class PedidoCompra: Base
	{
		public PedidoCompra(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdPedidoCompra;
		public int idPedidoCompra
		{
			get{return this.m_IdPedidoCompra;}
			set{this.m_IdPedidoCompra = value;}
		}

        [
            TFieldAttributeGridDisplay("Fornecedor", 200),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idFornecedor:pessoa.nomeRazaoSocial")
        ]
        private Fornecedor m_IdFornecedor;
        public Fornecedor fornecedor
        {
            get { return this.m_IdFornecedor; }
            set { this.m_IdFornecedor = value; }
        }

        [
            TFieldAttributeGridDisplay("Data", 120)
        ]
        private DateTime m_DataPedido;
		public DateTime dataPedido
		{
			get{return this.m_DataPedido;}
			set{this.m_DataPedido = value;}
        }

        private DateTime m_DataAprovacao;
        public DateTime dataAprovacao
        {
            get { return this.m_DataAprovacao; }
            set { this.m_DataAprovacao = value; }
        }

        private DateTime m_DataPrevisaoPagamento;
        public DateTime dataPrevisaoPagamento
        {
            get { return this.m_DataPrevisaoPagamento; }
            set { this.m_DataPrevisaoPagamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 100),
            TFieldAttributeFormat("C2", "")
        ]
		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
        }

        private double m_valorFrete;
        public double valorFrete
        {
            get { return this.m_valorFrete; }
            set { this.m_valorFrete = value; }
        }

        private double m_valorDesconto;
        public double valorDesconto
        {
            get { return this.m_valorDesconto; }
            set { this.m_valorDesconto = value; }
        }

        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        private CondicaoPagamento m_IdCondicaoPagamento;
		public CondicaoPagamento condicaoPagamento
		{
			get{return this.m_IdCondicaoPagamento;}
			set{this.m_IdCondicaoPagamento = value;}
		}

        private Funcionario m_IdAprovadorFuncionario;
        public Funcionario aprovador
        {
            get { return this.m_IdAprovadorFuncionario; }
            set { this.m_IdAprovadorFuncionario = value; }
        }

        private Funcionario m_IdCompradorFuncionario;
        public Funcionario comprador
        {
            get { return this.m_IdCompradorFuncionario; }
            set { this.m_IdCompradorFuncionario = value; }
        }

        private int m_IdAprovador;
		public int idAprovador
		{
			get{return this.m_IdAprovador;}
			set{this.m_IdAprovador = value;}
        }

        private int m_IdComprador;
        public int idComprador
        {
            get { return this.m_IdComprador; }
            set { this.m_IdComprador = value; }
        }

        private int m_IdRequisicaoCompra;
		public int idRequisicaoCompra
		{
			get{return this.m_IdRequisicaoCompra;}
			set{this.m_IdRequisicaoCompra = value;}
		}

        private int m_IdNotaFiscal;
        public int idNotaFiscal
        {
            get { return this.m_IdNotaFiscal; }
            set { this.m_IdNotaFiscal = value; }
        }

        //idPedidoCompra
        private PedidoCompraProdutoServico[] m_PedidoCompraProdutoServicos;
        public PedidoCompraProdutoServico[] pedidoCompraProdutoServicos
        {
            get{return this.m_PedidoCompraProdutoServicos;}
            set{this.m_PedidoCompraProdutoServicos = value;}
        }

        [
            TFieldAttributeData(100, true)
        ]
        private string m_descricao;
        public string descricao
        {
            get { return this.m_descricao; }
            set { this.m_descricao = value; }
        }

        private string m_observacao;
        public string observacao
        {
            get { return this.m_observacao; }
            set { this.m_observacao = value; }
        }

        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        public override string ToString()
        {
            return this.m_IdPedidoCompra.ToString();
        }
    }
}
