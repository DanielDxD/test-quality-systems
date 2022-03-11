
using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class ContratoValor : Base
	{
		public ContratoValor() : base() {}

		[
			TFieldAttributeKey(true, true)
		]
		private int m_IdContratoValor;
		public int idContratoValor 
		{ 
			get { return this.m_IdContratoValor; } 
			set { this.m_IdContratoValor = value; } 
		}

		private Contrato m_IdContrato;
		public Contrato contrato 
		{ 
			get { return this.m_IdContrato; } 
			set { this.m_IdContrato = value; } 
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

		private Double m_Valor;
		public Double valor 
		{ 
			get { return this.m_Valor; } 
			set { this.m_Valor = value; } 
		}

	}
}
