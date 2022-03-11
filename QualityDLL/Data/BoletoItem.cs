using System;

namespace Data
{
	//[Serializable]
	public class BoletoItem: Base
	{
		public BoletoItem(): base()
		{
		}

		private int m_IdBoletoItem;
		public int idBoletoItem
		{
			get{return this.m_IdBoletoItem;}
			set{this.m_IdBoletoItem = value;}
		}

		private Boleto m_IdBoleto;
		public Boleto boleto
		{
			get { return this.m_IdBoleto; }
			set { this.m_IdBoleto = value; }
		}

		private ContasAReceber m_IdContasAReceber;
		public ContasAReceber contasAReceber
		{
			get { return this.m_IdContasAReceber; }
			set { this.m_IdContasAReceber = value; }
		}

		private double m_Valor;
		public double valor
		{
			get { return this.m_Valor; }
			set { this.m_Valor = value; }
		}

		private double m_juros;
		public double juros
		{
			get { return this.m_juros; }
			set { this.m_juros = value; }
		}

		private double m_multa;
		public double multa
		{
			get { return this.m_multa; }
			set { this.m_multa = value; }
		}

		public override string ToString()
        {
            return this.m_IdBoletoItem.ToString();
        }
    }
}
