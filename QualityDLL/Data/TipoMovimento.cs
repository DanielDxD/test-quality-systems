using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TipoMovimento: Base
	{
		public TipoMovimento(): base()
		{
		}

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdTipoMovimento;
		public int idTipoMovimento
		{
			get{return this.m_IdTipoMovimento;}
			set{this.m_IdTipoMovimento = value;}
		}

        [
            TFieldAttributeGridDisplay("Nome", 255),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 123),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;H_Histórico;A_Automático;M_Manual")
        ]
        private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

        public override string ToString()
        {
            return this.m_IdTipoMovimento.ToString();
        }
    }
}
