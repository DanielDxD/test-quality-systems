using System;

namespace Data
{
    //[Serializable]
    public class UsuarioLogado : Base
    {

        public UsuarioLogado() : base()
        {
        }

        private Usuario m_IdUsuario;
        public Usuario usuario
        {
            get { return this.m_IdUsuario; }
            set { this.m_IdUsuario = value; }
        }

        private string m_Modulo;
        public string modulo
        {
            get { return this.m_Modulo; }
            set { this.m_Modulo = value; }
        }

        private DateTime m_DataLogin;
        public DateTime dataLogin
        {
            get { return this.m_DataLogin; }
            set { this.m_DataLogin = value; }
        }

        private string m_Token;
        public string token
        {
            get { return this.m_Token; }
            set { this.m_Token = value; }
        }

        private string m_SessionId;
        public string sessionId
        {
            get { return this.m_SessionId; }
            set { this.m_SessionId = value; }
        }

    }
}
