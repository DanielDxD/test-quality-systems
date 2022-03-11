using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Logradouro: Base
	{
		public Logradouro(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdLogradouro;
		public int idLogradouro
		{
			get{return this.m_IdLogradouro;}
			set{this.m_IdLogradouro = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 100),
            TFieldAttributeData(50, true),
            TFieldAttributeSubfield("idTipoLogradouro:descricao")
        ]
        private TipoLogradouro m_IdTipoLogradouro;
        public TipoLogradouro tipoLogradouro
        {
            get { return this.m_IdTipoLogradouro; }
            set { this.m_IdTipoLogradouro = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 305),
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
            TFieldAttributeData(100, true),
            TFieldAttributeSubfield("idCidade:descricao")
        ]
        private Cidade m_IdCidade;
        public Cidade cidade
		{
            get { return this.m_IdCidade; }
            set { this.m_IdCidade = value; }
		}

        public override string ToString()
        {
            return this.m_IdLogradouro.ToString();
        }
	}
}
