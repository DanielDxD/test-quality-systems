using System;

namespace Data
{
	//[Serializable]
	public class UsuarioPerfil: Base
	{
		public UsuarioPerfil(): base()
		{
		}


		private int m_IdUsuario;
		public int idUsuario
		{
			get{return this.m_IdUsuario;}
			set{this.m_IdUsuario = value;}
		}

		private Perfil m_IdPerfil;
		public Perfil perfil
		{
			get{return this.m_IdPerfil;}
			set{this.m_IdPerfil = value;}
		}
	}
}
