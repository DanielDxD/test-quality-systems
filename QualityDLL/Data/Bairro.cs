using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Bairro: Base
	{
		public Bairro(): base()
		{
		}

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdBairro;
		public int idBairro
		{
			get{return this.m_IdBairro;}
			set{this.m_IdBairro = value;}
		}

        [
            TFieldAttributeGridDisplay("Nome", 255 + 155),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("", 0),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idCidade:descricao")
        ]
        private Cidade m_IdCidade;
		public Cidade cidade
		{
			get{return this.m_IdCidade;}
			set{this.m_IdCidade = value;}
		}

        public override string ToString()
        {
            return this.m_IdBairro.ToString();
        }
	}
}
