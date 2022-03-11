using System;

namespace Data
{
    //[Serializable]
    public class Ncm : Base
    {

        public Ncm() : base()
        {
        }

        private int m_IdNcm;
        public int idNcm
        {
            get { return this.m_IdNcm; }
            set { this.m_IdNcm = value; }
        }

        private Estado m_IdEstado;
        public Estado estado
        {
            get { return this.m_IdEstado; }
            set { this.m_IdEstado = value; }
        }

        private string m_Codigo;
        public string codigo
        {
            get { return this.m_Codigo; }
            set { this.m_Codigo = value; }
        }

        private double m_Ex;
        public double ex
        {
            get { return this.m_Ex; }
            set { this.m_Ex = value; }
        }

        private double m_Tipo;
        public double tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private double m_NacionalFederal;
        public double nacionalFederal
        {
            get { return this.m_NacionalFederal; }
            set { this.m_NacionalFederal = value; }
        }

        private double m_ImportadosFederal;
        public double importadosFederal
        {
            get { return this.m_ImportadosFederal; }
            set { this.m_ImportadosFederal = value; }
        }

        private double m_Estadual;
        public double estadual
        {
            get { return this.m_Estadual; }
            set { this.m_Estadual = value; }
        }

        private double m_Municipal;
        public double municipal
        {
            get { return this.m_Municipal; }
            set { this.m_Municipal = value; }
        }

        private DateTime m_VigenciaInicio;
        public DateTime vigenciaInicio
        {
            get { return this.m_VigenciaInicio; }
            set { this.m_VigenciaInicio = value; }
        }

        private DateTime m_VigenciaFim;
        public DateTime vigenciaFim
        {
            get { return this.m_VigenciaFim; }
            set { this.m_VigenciaFim = value; }
        }

        private string m_Chave;
        public string chave
        {
            get { return this.m_Chave; }
            set { this.m_Chave = value; }
        }

        private string m_Versao;
        public string versao
        {
            get { return this.m_Versao; }
            set { this.m_Versao = value; }
        }

        private string m_Fonte;
        public string fonte
        {
            get { return this.m_Fonte; }
            set { this.m_Fonte = value; }
        }

    }
}
