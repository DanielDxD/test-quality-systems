using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class EstadoCivil: Base
	{
		public EstadoCivil(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdEstadoCivil;
		public int idEstadoCivil
		{
			get{return this.m_IdEstadoCivil;}
			set{this.m_IdEstadoCivil = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 255),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Tem Conjuge?", 125),
            TFieldAttributeData(6, true)
        ]
        private bool m_TemConjuge;
		public bool temConjuge
		{
			get{return this.m_TemConjuge;}
			set{this.m_TemConjuge = value;}
		}

        public override string ToString()
        {
            return this.m_IdEstadoCivil.ToString();
        }
	}
}
