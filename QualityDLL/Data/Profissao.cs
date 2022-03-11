using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Profissao: Base
	{
		public Profissao(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
		private int m_IdProfissao;
		public int idProfissao
		{
			get{return this.m_IdProfissao;}
			set{this.m_IdProfissao = value;}
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
            TFieldAttributeData(20, false),
            TFieldAttributeGridDisplay("CBO", 145)
        ]
        private String m_Cbo;
		public String cbo
		{
			get{return this.m_Cbo;}
			set{this.m_Cbo = value;}
		}

        public override string ToString()
        {
            return this.m_IdProfissao.ToString();
        }
	}
}
