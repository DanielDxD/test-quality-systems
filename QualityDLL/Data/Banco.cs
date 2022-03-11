using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Banco: Base
	{
		public Banco(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdBanco;
		public int idBanco
		{
			get{return this.m_IdBanco;}
			set{this.m_IdBanco = value;}
		}

        [
            TFieldAttributeGridDisplay("Banco", 80),
            TFieldAttributeEditDisplay("Banco", 80),
            TFieldAttributeData(3, true),
            TFieldAttributeFormat("000", "!999")
        ]
        private int m_CodigoBanco;
		public int codigoBanco
		{
			get{return this.m_CodigoBanco;}
			set{this.m_CodigoBanco = value;}
		}

        [
            TFieldAttributeGridDisplay("Agência", 80),
            TFieldAttributeEditDisplay("Agência", 80),
            TFieldAttributeData(4, true),
            TFieldAttributeFormat("0000", "!9999")
        ]
        private int m_CodigoAgencia;
		public int codigoAgencia
		{
			get{return this.m_CodigoAgencia;}
			set{this.m_CodigoAgencia = value;}
		}

        [
            TFieldAttributeGridDisplay("Digito", 0),
            TFieldAttributeEditDisplay("Digito", 80),
            TFieldAttributeData(1, false)
        ]
        private String m_DigitoAgencia;
		public String digitoAgencia
		{
			get{return this.m_DigitoAgencia;}
			set{this.m_DigitoAgencia = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 230),
            TFieldAttributeEditDisplay("Descrição", 80),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        public override string ToString()
        {
            return this.m_IdBanco.ToString();
        }
	}
}
