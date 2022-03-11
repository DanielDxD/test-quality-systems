using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class AtividadeEconomica: Base
	{
		public AtividadeEconomica(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdAtividadeEconomica;
		public int idAtividadeEconomica
		{
			get{return this.m_IdAtividadeEconomica;}
			set{this.m_IdAtividadeEconomica = value;}
		}

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("Descrição", 270)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeData(8, true),
            TFieldAttributeGridDisplay("CNAE", 145)
        ]
        private String m_CodigoCNAE;
		public String codigoCNAE
		{
			get{return this.m_CodigoCNAE;}
			set{this.m_CodigoCNAE = value;}
		}

        public override string ToString()
        {
            return this.m_IdAtividadeEconomica.ToString();
        }
	}
}
