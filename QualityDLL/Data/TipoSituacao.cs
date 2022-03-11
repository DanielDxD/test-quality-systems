using System;

namespace Data
{
    //[Serializable]
    public class TipoSituacao : Base
    {

        public TipoSituacao() : base()
        {
        }

        private int m_IdTipoSituacao;
        public int idTipoSituacao
        {
            get { return this.m_IdTipoSituacao; }
            set { this.m_IdTipoSituacao = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_BloqueioPortaria;
        public string bloqueioPortaria
        {
            get { return this.m_BloqueioPortaria; }
            set { this.m_BloqueioPortaria = value; }
        }

        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }
    }
}
