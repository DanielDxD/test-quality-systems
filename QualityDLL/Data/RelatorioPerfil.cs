using System;

namespace Data
{
    //[Serializable]
    public class RelatorioPerfil : Base
    {
        public RelatorioPerfil() : base()
        {
        }

        private int m_IdRelatorioPerfil;
        public int idRelatorioPerfil
        {
            get { return this.m_IdRelatorioPerfil; }
            set { this.m_IdRelatorioPerfil = value; }
        }

        private Perfil m_IdPerfil;
        public Perfil perfil
        {
            get { return this.m_IdPerfil; }
            set { this.m_IdPerfil = value; }
        }

        private Relatorios m_IdRelatorio;
        public Relatorios relatorio
        {
            get { return this.m_IdRelatorio; }
            set { this.m_IdRelatorio = value; }
        }

        private RelatorioSql m_IdRelatorioDinamico;
        public RelatorioSql relatorioDinamico
        {
            get { return this.m_IdRelatorioDinamico; }
            set { this.m_IdRelatorioDinamico = value; }
        }


        public override string ToString()
        {
            return this.m_IdRelatorioPerfil.ToString();
        }
    }
}
