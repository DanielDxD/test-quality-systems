using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Pais: Base
	{
		public Pais(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdPais;
		public int idPais
		{
			get{return this.m_IdPais;}
			set{this.m_IdPais = value;}
		}

        [
            TFieldAttributeGridDisplay("Nome", 400),
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
            return this.m_IdPais.ToString();
        }
    }
}
