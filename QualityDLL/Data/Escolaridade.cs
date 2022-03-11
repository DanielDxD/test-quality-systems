using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Escolaridade: Base
	{
		public Escolaridade(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdEscolaridade;
		public int idEscolaridade
		{
			get{return this.m_IdEscolaridade;}
			set{this.m_IdEscolaridade = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 320),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        public override string ToString()
        {
            return this.m_IdEscolaridade.ToString();
        }
	}
}
