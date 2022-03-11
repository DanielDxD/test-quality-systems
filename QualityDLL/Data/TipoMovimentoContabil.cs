using System;

namespace Data
{
    //[Serializable]
    public class TipoMovimentoContabil : Base
    {
        public TipoMovimentoContabil()
            : base()
        {
        }

        private int m_IdTipoMovimentoContabil;
        public int idTipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private bool m_ContabilizacaoPorCompetencia;
        public bool contabilizacaoPorCompetencia
        {
            get { return this.m_ContabilizacaoPorCompetencia; }
            set { this.m_ContabilizacaoPorCompetencia = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private PlanoContas m_IdPlanoContasResultado;
        public PlanoContas planoContasResultado
        {
            get { return this.m_IdPlanoContasResultado; }
            set { this.m_IdPlanoContasResultado = value; }
        }

        private PlanoContas m_IdPlanoContasProvisao;
        public PlanoContas planoContasProvisao
        {
            get { return this.m_IdPlanoContasProvisao; }
            set { this.m_IdPlanoContasProvisao = value; }
        }

        private PlanoContas m_IdPlanoContasAdiantamento;
        public PlanoContas planoContasAdiantamento
        {
            get { return this.m_IdPlanoContasAdiantamento; }
            set { this.m_IdPlanoContasAdiantamento = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabilPai;
        public TipoMovimentoContabil tipoMovimentoContabilPai
        {
            get { return this.m_IdTipoMovimentoContabilPai; }
            set { this.m_IdTipoMovimentoContabilPai = value; }
        }
    }
}