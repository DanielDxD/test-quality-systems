using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class UnidadeProdutoServico: Base
	{
		public UnidadeProdutoServico(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdUnidadeProdutoServico;
		public int idUnidadeProdutoServico
		{
			get{return this.m_IdUnidadeProdutoServico;}
			set{this.m_IdUnidadeProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 280),
            TFieldAttributeData(50, true),
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Sigla", 85),
            TFieldAttributeData(5, true),
        ]
        private String m_Sigla;
		public String sigla
		{
			get{return this.m_Sigla;}
			set{this.m_Sigla = value;}
		}

        public override string ToString()
        {
            return this.m_IdUnidadeProdutoServico.ToString();
        }
    }
}
