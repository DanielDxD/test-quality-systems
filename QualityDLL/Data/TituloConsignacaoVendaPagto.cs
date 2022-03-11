using System;

namespace Data
{
	//[Serializable]
	public class TituloConsignacaoVendaPagto: Base
	{
		public TituloConsignacaoVendaPagto(): base()
		{
		}

		private int m_IdTituloConsignacaoVendaPagto;
		public int idTituloConsignacaoVendaPagto
		{
			get{return this.m_IdTituloConsignacaoVendaPagto;}
			set{this.m_IdTituloConsignacaoVendaPagto = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private int m_Parcelas;
		public int parcelas
		{
			get{return this.m_Parcelas;}
			set{this.m_Parcelas = value;}
		}

		private DateTime m_Vencimento;
		public DateTime vencimento
		{
			get{return this.m_Vencimento;}
			set{this.m_Vencimento = value;}
		}

		private TituloConsignacaoVenda m_IdTituloConsignacaoVenda;
		public TituloConsignacaoVenda tituloConsignacaoVenda
		{
			get{return this.m_IdTituloConsignacaoVenda;}
			set{this.m_IdTituloConsignacaoVenda = value;}
		}

		private FormaPagamento m_IdFormaPagamento;
		public FormaPagamento formaPagamento
		{
			get{return this.m_IdFormaPagamento;}
			set{this.m_IdFormaPagamento = value;}
		}

        public override string ToString()
        {
            return this.m_IdTituloConsignacaoVendaPagto.ToString();
        }
    }
}
