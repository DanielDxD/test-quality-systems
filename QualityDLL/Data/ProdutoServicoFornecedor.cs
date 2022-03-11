using System;

namespace Data
{
	//[Serializable]
	public class ProdutoServicoFornecedor: Base
	{
		public ProdutoServicoFornecedor(): base()
		{
		}

		private int m_IdProdutoServicoFornecedor;
		public int idProdutoServicoFornecedor
		{
			get{return this.m_IdProdutoServicoFornecedor;}
			set{this.m_IdProdutoServicoFornecedor = value;}
		}

		private double m_PrazoEntrega;
		public double prazoEntrega
		{
			get{return this.m_PrazoEntrega;}
			set{this.m_PrazoEntrega = value;}
		}

		private DateTime m_DataUltimaCompra;
		public DateTime dataUltimaCompra
		{
			get{return this.m_DataUltimaCompra;}
			set{this.m_DataUltimaCompra = value;}
		}

		private double m_CustoUltimaCompra;
		public double custoUltimaCompra
		{
			get{return this.m_CustoUltimaCompra;}
			set{this.m_CustoUltimaCompra = value;}
		}

		private int m_IdProdutoServico;
		public int idProdutoServico
		{
			get{return this.m_IdProdutoServico;}
			set{this.m_IdProdutoServico = value;}
		}

        private ProdutoServico m_IdProdutoServicoClass;
        public ProdutoServico produtoServico
        {
            get { return m_IdProdutoServicoClass; }
            set { this.m_IdProdutoServicoClass = value; }
		}

		private Fornecedor m_IdFornecedor;
		public Fornecedor fornecedor
		{
			get { return this.m_IdFornecedor; }
			set { this.m_IdFornecedor = value; }
		}

		private string m_CodigoNfe;
		public string codigoNfe
		{
			get { return this.m_CodigoNfe; }
			set { this.m_CodigoNfe = value; }
		}

		public override string ToString()
        {
            return this.m_IdProdutoServicoFornecedor.ToString();
        }
    }
}
