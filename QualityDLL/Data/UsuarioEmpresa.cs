using System;

namespace Data
{
    //[Serializable]
    public class UsuarioEmpresa : Base
    {
        public UsuarioEmpresa()
            : base()
        {
        }


        private Usuario m_IdUsuario;
        public Usuario idUsuario
        {
            get { return this.m_IdUsuario; }
            set { this.m_IdUsuario = value; }
        }

        private Empresa m_IdEmpresa;
        public Empresa idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }
    }
}