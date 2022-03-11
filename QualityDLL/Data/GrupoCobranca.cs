using System;

namespace Data
{
    //[Serializable]
    public class GrupoCobranca : Base
    {

        public GrupoCobranca() : base()
        {
        }

        private int m_IdGrupoCobranca;
        public int idGrupoCobranca
        {
            get { return this.m_IdGrupoCobranca; }
            set { this.m_IdGrupoCobranca = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private ParametroBoleto m_IdParametroBoleto;
        public ParametroBoleto parametroBoleto
        {
            get { return this.m_IdParametroBoleto; }
            set { this.m_IdParametroBoleto = value; }
        }

        private DateTime m_DataInicio;
        public DateTime dataInicio
        {
            get { return this.m_DataInicio; }
            set { this.m_DataInicio = value; }
        }

        private int m_DiaCobranca;
        public int diaCobranca
        {
            get { return this.m_DiaCobranca; }
            set { this.m_DiaCobranca = value; }
        }

        private bool m_AgruparDebitosTitulo;
        public bool agruparDebitosTitulo
        {
            get { return this.m_AgruparDebitosTitulo; }
            set { this.m_AgruparDebitosTitulo = value; }
        }

        private DateTime m_DataFim;
        public DateTime dataFim
        {
            get { return this.m_DataFim; }
            set { this.m_DataFim = value; }
        }

        private DateTime m_DataInicioAgrupamento;
        public DateTime dataInicioAgrupamento
        {
            get { return this.m_DataInicioAgrupamento; }
            set { this.m_DataInicioAgrupamento = value; }
        }

        private GrupoCobrancaItem[] m_GrupoCobrancaItems;
        public GrupoCobrancaItem[] grupoCobrancaItems
        {
            get { return this.m_GrupoCobrancaItems; }
            set { this.m_GrupoCobrancaItems = value; }

        }

        private ParametroAcrescimo m_IdParametroAcrescimo;
        public ParametroAcrescimo parametroAcrescimo
        {
            get { return this.m_IdParametroAcrescimo; }
            set { this.m_IdParametroAcrescimo = value; }
        }

    }
}
