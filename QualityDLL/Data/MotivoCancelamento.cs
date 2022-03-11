
using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class MotivoCancelamento : Base
	{
		public MotivoCancelamento() : base() {}

		[
			TFieldAttributeKey(true, true)
		]
		private int m_IdMotivoCancelamento;
		public int idMotivoCancelamento 
		{ 
			get { return this.m_IdMotivoCancelamento; } 
			set { this.m_IdMotivoCancelamento = value; } 
		}

		private string m_Descricao;
		public string descricao 
		{ 
			get { return this.m_Descricao; } 
			set { this.m_Descricao = value; } 
		}

	}
}
