using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class EntradaMercadoria: Base
	{
		public EntradaMercadoria(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdEntradaMercadoria;
		public int idEntradaMercadoria
		{
			get{return this.m_IdEntradaMercadoria;}
			set{this.m_IdEntradaMercadoria = value;}
		}

        [
            TFieldAttributeGridDisplay("Fornecedor", 200),
            TFieldAttributeSubfield("idFornecedor:pessoa.nomeRazaoSocial")
        ]
        private Fornecedor m_IdFornecedor;
        public Fornecedor fornecedor
        {
            get { return this.m_IdFornecedor; }
            set { this.m_IdFornecedor = value; }
        }

        [
            TFieldAttributeGridDisplay("Departamento", 200),
            TFieldAttributeSubfield("idDepartamento:descricao")
        ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Data", 110)
        ]
        private DateTime m_DataEntrada;
		public DateTime dataEntrada
		{
			get{return this.m_DataEntrada;}
			set{this.m_DataEntrada = value;}
		}

        [
            TFieldAttributeGridDisplay("Valor", 110),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private DateTime m_DataVencimento;
		public DateTime dataVencimento
		{
			get{return this.m_DataVencimento;}
			set{this.m_DataVencimento = value;}
		}

		private int m_IdPedidoCompra;
		public int idPedidoCompra
		{
			get{return this.m_IdPedidoCompra;}
			set{this.m_IdPedidoCompra = value;}
		}

		private CondicaoPagamento m_IdCondicaoPagamento;
		public CondicaoPagamento condicaoPagamento
		{
			get{return this.m_IdCondicaoPagamento;}
			set{this.m_IdCondicaoPagamento = value;}
		}

        private int m_IdNotaFiscal;
        public int idNotaFiscal
        {
            get { return this.m_IdNotaFiscal; }
            set { this.m_IdNotaFiscal = value; }
        }

        //idEntradaMercadoria
        private EntradaMercadoriaItem[] m_EntradaMercadoriaItems;
        public EntradaMercadoriaItem[] entradaMercadoriaItems
        {
            get{return this.m_EntradaMercadoriaItems;}
            set{this.m_EntradaMercadoriaItems = value;}
        }

        public override string ToString()
        {
            return this.m_IdEntradaMercadoria.ToString();
        }
    }
}
