using System;

namespace Data
{
	//[Serializable]
	public class NotaFiscalSItem: Base
	{
		public NotaFiscalSItem(): base()
		{
		}

		private int m_IdNotaFiscalSItem;
		public int idNotaFiscalSItem
		{
			get{return this.m_IdNotaFiscalSItem;}
			set{this.m_IdNotaFiscalSItem = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private double m_AliquotaIss;
		public double aliquotaIss
		{
			get{return this.m_AliquotaIss;}
			set{this.m_AliquotaIss = value;}
		}

		private double m_ValorIss;
		public double valorIss
		{
			get{return this.m_ValorIss;}
			set{this.m_ValorIss = value;}
		}

		private NotaFiscalS m_IdNotaFiscal;
		public NotaFiscalS notaFiscal
		{
			get{return this.m_IdNotaFiscal;}
			set{this.m_IdNotaFiscal = value;}
		}

		private ContasAReceber m_IdContasAReceber;
		public ContasAReceber contasAReceber
		{
			get{return this.m_IdContasAReceber;}
			set{this.m_IdContasAReceber = value;}
		}

        public override string ToString()
        {
            return this.m_IdNotaFiscalSItem.ToString();
        }
    }
}
