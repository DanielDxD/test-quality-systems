
using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class ContratoTurma : Base
	{
		public ContratoTurma() : base() {}

		[
			TFieldAttributeKey(true, true)
		]
		private int m_IdContratoTurma;
		public int idContratoTurma 
		{ 
			get { return this.m_IdContratoTurma; } 
			set { this.m_IdContratoTurma = value; } 
		}

		private Contrato m_IdContrato;
		public Contrato contrato 
		{ 
			get { return this.m_IdContrato; } 
			set { this.m_IdContrato = value; } 
		}

		private ModalidadeEsportivaTurma m_IdModalidadeEsportivaTurma;
		public ModalidadeEsportivaTurma modalidadeEsportivaTurma 
		{ 
			get { return this.m_IdModalidadeEsportivaTurma; } 
			set { this.m_IdModalidadeEsportivaTurma = value; } 
		}

	}
}
