using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TipoLogradouro: Base
	{
		public TipoLogradouro(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdTipoLogradouro;
		public int idTipoLogradouro
		{
			get{return this.m_IdTipoLogradouro;}
			set{this.m_IdTipoLogradouro = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 300),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 100),
            TFieldAttributeData(15, true)
        ]
        private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

        public override string ToString()
        {
            return this.m_IdTipoLogradouro.ToString();
        }
	}
}
