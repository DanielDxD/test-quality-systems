
using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class ModalidadeEsportivaTurmaValor : Base
	{
		public ModalidadeEsportivaTurmaValor() : base() {}

		[
			TFieldAttributeKey(true, true)
		]
		private int m_IdModalidadeEsportivaTurmaValor;
		public int idModalidadeEsportivaTurmaValor 
		{ 
			get { return this.m_IdModalidadeEsportivaTurmaValor; } 
			set { this.m_IdModalidadeEsportivaTurmaValor = value; } 
		}

		private ModalidadeEsportivaTurma m_IdModalidadeEsportivaTurma;
		public ModalidadeEsportivaTurma modalidadeEsportivaTurma 
		{ 
			get { return this.m_IdModalidadeEsportivaTurma; } 
			set { this.m_IdModalidadeEsportivaTurma = value; } 
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

		private int m_TipoIntervaloVencimento;
		public int tipoIntervaloVencimento 
		{ 
			get { return this.m_TipoIntervaloVencimento; } 
			set { this.m_TipoIntervaloVencimento = value; } 
		}

		private Double m_ValorSocio;
		public Double valorSocio 
		{ 
			get { return this.m_ValorSocio; } 
			set { this.m_ValorSocio = value; } 
		}

		private Double m_ValorNaoSocio;
		public Double valorNaoSocio 
		{ 
			get { return this.m_ValorNaoSocio; } 
			set { this.m_ValorNaoSocio = value; } 
		}

	}
}
