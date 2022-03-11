using System;

namespace Data
{
	//[Serializable]
	public class CategoriaTitulo: Base
	{
		public CategoriaTitulo(): base()
		{
		}

		private int m_IdCategoriaTitulo;
		public int idCategoriaTitulo
		{
			get{return this.m_IdCategoriaTitulo;}
			set{this.m_IdCategoriaTitulo = value;}
		}

		private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

		private String m_DescricaoReduzida;
		public String descricaoReduzida
		{
			get{return this.m_DescricaoReduzida;}
			set{this.m_DescricaoReduzida = value;}
		}

		private bool m_Familiar;
		public bool familiar
		{
			get{return this.m_Familiar;}
			set{this.m_Familiar = value;}
        }

        private int m_MesesVigencia;
        public int mesesVigencia
        {
            get { return this.m_MesesVigencia; }
            set { this.m_MesesVigencia = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private int m_Numero;
        public int numero
        {
            get { return this.m_Numero; }
            set { this.m_Numero = value; }
        }

        public override string ToString()
        {
            return this.m_IdCategoriaTitulo.ToString();
        }
    }
}
