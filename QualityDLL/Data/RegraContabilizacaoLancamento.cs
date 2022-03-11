using System;

namespace Data
{
    //[Serializable]
    public class RegraContabilizacaoLancamento : Base
    {
        public RegraContabilizacaoLancamento()
            : base()
        {
        }

        private int m_IdRegraContabilizacaoLancamento;
        public int idRegraContabilizacaoLancamento
        {
            get { return this.m_IdRegraContabilizacaoLancamento; }
            set { this.m_IdRegraContabilizacaoLancamento = value; }
        }

        private String m_OrigemIdPlanoContas;
        public String origemIdPlanoContas
        {
            get { return this.m_OrigemIdPlanoContas; }
            set { this.m_OrigemIdPlanoContas = value; }
        }

        private String m_DebitoCredito;
        public String debitoCredito
        {
            get { return this.m_DebitoCredito; }
            set { this.m_DebitoCredito = value; }
        }

        private String m_Formula;
        public String formula
        {
            get { return this.m_Formula; }
            set { this.m_Formula = value; }
        }

        private String m_AgrupaLancamento;
        public String agrupaLancamento
        {
            get { return this.m_AgrupaLancamento; }
            set { this.m_AgrupaLancamento = value; }
        }

        private int m_OrdemProcessamento;
        public int ordemProcessamento
        {
            get { return this.m_OrdemProcessamento; }
            set { this.m_OrdemProcessamento = value; }
        }

        private RegraContabilizacao m_IdRegraContabilizacaoPrimaria;
        public RegraContabilizacao regraContabilizacaoPrimaria
        {
            get { return this.m_IdRegraContabilizacaoPrimaria; }
            set { this.m_IdRegraContabilizacaoPrimaria = value; }
        }

        private RegraContabilizacao m_IdRegraContabilizacao;
        public RegraContabilizacao regraContabilizacao
        {
            get { return this.m_IdRegraContabilizacao; }
            set { this.m_IdRegraContabilizacao = value; }
        }
    }
}
