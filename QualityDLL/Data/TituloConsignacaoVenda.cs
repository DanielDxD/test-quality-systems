using System;

namespace Data
{
	//[Serializable]
	public class TituloConsignacaoVenda: Base
	{
		public TituloConsignacaoVenda(): base()
		{
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private double m_ValorComissao;
		public double valorComissao
		{
			get{return this.m_ValorComissao;}
			set{this.m_ValorComissao = value;}
		}

		private DateTime m_DataVenda;
		public DateTime dataVenda
		{
			get{return this.m_DataVenda;}
			set{this.m_DataVenda = value;}
		}

		private TituloConsignacao m_IdTituloConsignacaoVenda;
		public TituloConsignacao tituloConsignacaoVenda
		{
			get{return this.m_IdTituloConsignacaoVenda;}
			set{this.m_IdTituloConsignacaoVenda = value;}
		}

        //idTituloConsignacaoVenda
        private TituloConsignacaoVendaPagto[] m_TituloConsignacaoVendaPagtos;
        public TituloConsignacaoVendaPagto[] tituloConsignacaoVendaPagtos
        {
            get{return this.m_TituloConsignacaoVendaPagtos;}
            set{this.m_TituloConsignacaoVendaPagtos = value;}
        }

        public override string ToString()
        {
            return this.m_IdTituloConsignacaoVenda.ToString();
        }
    }
}
