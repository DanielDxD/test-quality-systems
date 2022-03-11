using System;

namespace Data
{
    //[Serializable]
    public class RegraContabilizacao : Base
    {
        public RegraContabilizacao()
            : base()
        {
        }

        private int m_IdRegraContabilizacao;
        public int idRegraContabilizacao
        {
            get { return this.m_IdRegraContabilizacao; }
            set { this.m_IdRegraContabilizacao = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private String m_TipoAgrupamento;
        public String tipoAgrupamento
        {
            get { return this.m_TipoAgrupamento; }
            set { this.m_TipoAgrupamento = value; }
        }

        //idRegraContabilizacao
        private RegraContabilizacaoLancamento[] m_RegraContabilizacaoLancamentos;
        public RegraContabilizacaoLancamento[] regraContabilizacaoLancamentos
        {
            get { return this.m_RegraContabilizacaoLancamentos; }
            set { this.m_RegraContabilizacaoLancamentos = value; }
        }
    }
}