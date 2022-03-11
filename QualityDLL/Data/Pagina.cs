using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Pagina: Base
	{
		public Pagina(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPagina;
		public int idPagina
		{
			get{return this.m_IdPagina;}
			set{this.m_IdPagina = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 390),
            TFieldAttributeEditDisplay("Descrição", 80),
            TFieldAttributeData(50, true),
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Página", 0),
            TFieldAttributeEditDisplay("Página", 80),
            TFieldAttributeData(100, true),
        ]
        private String m_Pagina;
		public String pagina
		{
			get{return this.m_Pagina;}
			set{this.m_Pagina = value;}
		}

        [
            TFieldAttributeGridDisplay("Altura", 0),
            TFieldAttributeEditDisplay("Altura", 80),
            TFieldAttributeData(6, true),
        ]
        private int m_Altura;
		public int altura
		{
			get{return this.m_Altura;}
			set{this.m_Altura = value;}
		}

        [
            TFieldAttributeGridDisplay("Largura", 0),
            TFieldAttributeEditDisplay("Largura", 80),
            TFieldAttributeData(6, true),
        ]
        private int m_Largura;
		public int largura
		{
			get{return this.m_Largura;}
			set{this.m_Largura = value;}
        }

        [
            TFieldAttributeGridDisplay("Layout Novo", 0),
            TFieldAttributeEditDisplay("Layout Novo", 80),
            TFieldAttributeData(6, false),
        ]
        private bool m_NewLayout;
        public bool newLayout
        {
            get { return this.m_NewLayout; }
            set { this.m_NewLayout = value; }
        }

        [
            TFieldAttributeGridDisplay("Gestão Novo", 0),
            TFieldAttributeEditDisplay("Gestão Novo", 80),
            TFieldAttributeData(6, false),
        ]
        private bool m_GestaoNovo;
        public bool gestaoNovo
        {
            get { return this.m_GestaoNovo; }
            set { this.m_GestaoNovo = value; }
        }

        public override string ToString()
        {
            return this.m_IdPagina.ToString();
        }
	}
}
