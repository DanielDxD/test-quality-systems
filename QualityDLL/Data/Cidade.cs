using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Cidade: Base
	{
		public Cidade(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdCidade;
		public int idCidade
		{
			get{return this.m_IdCidade;}
			set{this.m_IdCidade = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 200 + 155),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Codigo IBGE", 115),
            TFieldAttributeData(8, false)
        ]
        private int m_CodigoIBGE;
		public int codigoIBGE
		{
			get{return this.m_CodigoIBGE;}
			set{this.m_CodigoIBGE = value;}
		}

        [
            TFieldAttributeGridDisplay("", 0),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idEstado:descricao")
        ]
        private Estado m_IdEstado;
		public Estado estado
		{
			get{return this.m_IdEstado;}
			set{this.m_IdEstado = value;}
		}
        
        public override string ToString()
        {
            return this.m_IdCidade.ToString();
        }
    }
}
