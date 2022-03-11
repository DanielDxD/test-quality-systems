using System;

namespace Data
{
	//[Serializable]
	public class ParametroBoletoNossoNumero: Base
	{
		public ParametroBoletoNossoNumero(): base()
		{
		}

		private int m_IdParametroBoletoNossoNumero;
		public int idParametroBoletoNossoNumero
		{
			get{return this.m_IdParametroBoletoNossoNumero;}
			set{this.m_IdParametroBoletoNossoNumero = value;}
		}

		private DateTime m_DataInicio;
		public DateTime dataInicio
		{
			get { return this.m_DataInicio; }
			set { this.m_DataInicio = value; }
		}

		private DateTime m_DataFim;
		public DateTime dataFim
		{
			get { return this.m_DataFim; }
			set { this.m_DataFim = value; }
		}

		private Int64 m_NumeroInicial;
		public Int64 numeroInicial
		{
			get{return this.m_NumeroInicial;}
			set{this.m_NumeroInicial = value;}
		}

		private Int64 m_NumeroFinal;
		public Int64 numeroFinal
		{
			get{return this.m_NumeroFinal;}
			set{this.m_NumeroFinal = value;}
		}

		private bool m_Ativo;
		public bool ativo
		{
			get{return this.m_Ativo;}
			set{this.m_Ativo = value;}
		}

		private ParametroBoleto m_IdParametroBoleto;
		public ParametroBoleto parametroBoleto
		{
			get{return this.m_IdParametroBoleto;}
			set{this.m_IdParametroBoleto = value;}
		}

        public override string ToString()
        {
            return this.m_IdParametroBoletoNossoNumero.ToString();
        }
    }
}
