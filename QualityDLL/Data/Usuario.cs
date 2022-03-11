using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [
        TClassAttributeFields
        (
            new String[] 
            {
                "m_IdUsuario",
                "m_NomeUsuario",
                "..m_IdPessoa"
            }
        )
    ]
	public class Usuario: Funcionario
	{
		public Usuario(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdUsuario;
		public int idUsuario
		{
			get{return this.m_IdUsuario;}
			set{this.m_IdUsuario = value;}
		}

        [
            TFieldAttributeGridDisplay("Usuário", 100),
            TFieldAttributeData(50, true)
        ]
        private String m_NomeUsuario;
		public String nomeUsuario
		{
			get{return this.m_NomeUsuario;}
			set{this.m_NomeUsuario = value;}
		}

        private bool m_SenhaDinamica;
        public bool senhaDinamica
        {
            get { return this.m_SenhaDinamica; }
            set { this.m_SenhaDinamica = value; }
        }

		private String m_Senha;
		public String senha
		{
			get{return this.m_Senha;}
			set{this.m_Senha = value;}
		}

		private bool m_Ativo;
		public bool ativo
		{
			get{return this.m_Ativo;}
			set{this.m_Ativo = value;}
		}

        private String m_NomeCSS;
        public String nomeCSS
        {
            get { return this.m_NomeCSS; }
            set { this.m_NomeCSS = value; }
        }

        private Boolean m_Funcionario;
        public Boolean funcionario
        {
            get { return this.m_Funcionario; }
            set { this.m_Funcionario = value; }
        }

        //idUsuario
        private Perfil[] m_Perfils;
        public Perfil[] perfils
        {
            get{return this.m_Perfils;}
            set{this.m_Perfils = value;}
        }

        //idUsuario
        private UsuarioEmpresa[] m_UsuarioEmpresas;
        public UsuarioEmpresa[] usuarioEmpresas
        {
            get { return this.m_UsuarioEmpresas; }
            set { this.m_UsuarioEmpresas = value; }
        }
        
        public override string ToString()
        {
            return this.m_IdUsuario.ToString();
        }
	}
}
