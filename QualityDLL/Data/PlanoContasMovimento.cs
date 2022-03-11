using System;

namespace Data
{
	//[Serializable]
	public class PlanoContasMovimento: Base
	{
		public PlanoContasMovimento(): base()
		{
		}

		private int m_IdPlanoContasMovimento;
		public int idPlanoContasMovimento
		{
			get{return this.m_IdPlanoContasMovimento;}
			set{this.m_IdPlanoContasMovimento = value;}
		}

		private DateTime m_DataMovimento;
		public DateTime dataMovimento
		{
			get{return this.m_DataMovimento;}
			set{this.m_DataMovimento = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private String m_Historico;
		public String historico
		{
			get{return this.m_Historico;}
			set{this.m_Historico = value;}
		}

		private PlanoContas m_IdPlanoContasDebito;
		public PlanoContas planoContasDebito
		{
			get{return this.m_IdPlanoContasDebito;}
			set{this.m_IdPlanoContasDebito = value;}
		}

		private PlanoContas m_IdPlanoContasCredito;
		public PlanoContas planoContasCredito
		{
			get{return this.m_IdPlanoContasCredito;}
			set{this.m_IdPlanoContasCredito = value;}
		}

        public override string ToString()
        {
            return this.m_IdPlanoContasMovimento.ToString();
        }
    }
}
