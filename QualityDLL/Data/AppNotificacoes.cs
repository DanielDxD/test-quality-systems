using System;

namespace Data
{
    //[Serializable]
    public class AppNotificacoes : Base
    {

        public AppNotificacoes() : base()
        {
        }

        private int m_IdAppNotificacao;
        public int idAppNotificacao
        {
            get { return this.m_IdAppNotificacao; }
            set { this.m_IdAppNotificacao = value; }
        }

        private Funcionario m_IdFuncionario;
        public Funcionario funcionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }

        private DateTime m_DataNotificacao;
        public DateTime dataNotificacao
        {
            get { return this.m_DataNotificacao; }
            set { this.m_DataNotificacao = value; }
        }

        private string m_TextoNotificacao;
        public string textoNotificacao
        {
            get { return this.m_TextoNotificacao; }
            set { this.m_TextoNotificacao = value; }
        }

        private string m_TextoConteudo;
        public string textoConteudo
        {
            get { return this.m_TextoConteudo; }
            set { this.m_TextoConteudo = value; }
        }

    }
}
