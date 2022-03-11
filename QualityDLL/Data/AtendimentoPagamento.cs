using System;

namespace Data
{
	//[Serializable]
	public class AtendimentoPagamento: Base
	{
		public AtendimentoPagamento(): base()
		{
		}

		private int m_IdAtendimentoPagamento;
		public int idAtendimentoPagamento
		{
			get{return this.m_IdAtendimentoPagamento;}
			set{this.m_IdAtendimentoPagamento = value;}
		}

		private DateTime m_DataPagamento;
		public DateTime dataPagamento
		{
			get{return this.m_DataPagamento;}
			set{this.m_DataPagamento = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private Atendimento m_IdAtendimento;
		public Atendimento atendimento
		{
			get{return this.m_IdAtendimento;}
			set{this.m_IdAtendimento = value;}
		}

        public override string ToString()
        {
            return this.idAtendimentoPagamento.ToString();
        }
    }
}
