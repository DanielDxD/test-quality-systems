using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Menu: Base
	{
		public Menu(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdMenu;
		public int idMenu
		{
			get{return this.m_IdMenu;}
			set{this.m_IdMenu = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 380),
            TFieldAttributeEditDisplay("Descrição", 80),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeEditDisplay("Opção", 80),
            TFieldAttributeData(50, true)
        ]
        private String m_Opcao;
		public String opcao
		{
			get{return this.m_Opcao;}
			set{this.m_Opcao = value;}
		}

        [
            TFieldAttributeEditDisplay("Ordem", 80),
            TFieldAttributeData(6, false)
        ]
        private int m_Ordem;
		public int ordem
		{
			get{return this.m_Ordem;}
			set{this.m_Ordem = value;}
		}

        [
            TFieldAttributeEditDisplay("Imagem", 80),
            TFieldAttributeData(50, false)
        ]
        private String m_ArquivoImagem;
        public String arquivoImagem
        {
            get { return this.m_ArquivoImagem; }
            set { this.m_ArquivoImagem = value; }
        }

        [
            TFieldAttributeEditDisplay("Menu Pai", 80),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idMenu:descricao")
        ]
        private Menu m_IdMenuPai;
		public Menu menuPai
		{
			get{return this.m_IdMenuPai;}
			set{this.m_IdMenuPai = value;}
		}

        [
            TFieldAttributeEditDisplay("Página", 80),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idPagina:descricao")
        ]
        private Pagina m_IdPagina;
		public Pagina pagina
		{
			get{return this.m_IdPagina;}
			set{this.m_IdPagina = value;}
		}

        public override string ToString()
        {
            return this.m_IdMenu.ToString();
        }
	}
}
