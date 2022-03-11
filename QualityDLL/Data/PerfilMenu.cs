using System;

namespace Data
{
	//[Serializable]
	public class PerfilMenu: Menu
	{
		public PerfilMenu(): base()
		{
		}

		private int m_IdPerfilMenu;
		public int idPerfilMenu
		{
			get{return this.m_IdPerfilMenu;}
			set{this.m_IdPerfilMenu = value;}
		}

		private bool m_Consultar;
		public bool consultar
		{
			get{return this.m_Consultar;}
			set{this.m_Consultar = value;}
		}

		private bool m_Incluir;
		public bool incluir
		{
			get{return this.m_Incluir;}
			set{this.m_Incluir = value;}
		}

		private bool m_Alterar;
		public bool alterar
		{
			get{return this.m_Alterar;}
			set{this.m_Alterar = value;}
		}

		private bool m_Excluir;
		public bool excluir
		{
			get{return this.m_Excluir;}
			set{this.m_Excluir = value;}
		}

		private Perfil m_IdPerfil;
		public Perfil perfil
		{
			get{return this.m_IdPerfil;}
			set{this.m_IdPerfil = value;}
		}

        private String m_Sequence;
        public String sequence
        {
            get { return this.m_Sequence; }
            set { this.m_Sequence = value; }
        }

        private bool m_Ativo;
        public bool ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

        public override string ToString()
        {
            return this.m_IdPerfilMenu.ToString();
        }
    }
}
