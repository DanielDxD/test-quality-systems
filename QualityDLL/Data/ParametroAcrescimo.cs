using System;

namespace Data
{
    //[Serializable]
    public class ParametroAcrescimo : Base
    {

        public ParametroAcrescimo() : base()
        {
        }

        private int m_IdParametroAcrescimo;
        public int idParametroAcrescimo
        {
            get { return this.m_IdParametroAcrescimo; }
            set { this.m_IdParametroAcrescimo = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_TipoJuro;
        public string tipoJuro
        {
            get { return this.m_TipoJuro; }
            set { this.m_TipoJuro = value; }
        }

        private string m_TipoMulta;
        public string tipoMulta
        {
            get { return this.m_TipoMulta; }
            set { this.m_TipoMulta = value; }
        }

        private double m_ValorJuros;
        public double valorJuros
        {
            get { return this.m_ValorJuros; }
            set { this.m_ValorJuros = value; }
        }

        private double m_ValorMulta;
        public double valorMulta
        {
            get { return this.m_ValorMulta; }
            set { this.m_ValorMulta = value; }
        }

        private string m_TipoCarenciaJuros;
        public string tipoCarenciaJuros
        {
            get { return this.m_TipoCarenciaJuros; }
            set { this.m_TipoCarenciaJuros = value; }
        }

        private int m_DiasCarenciaJuros;
        public int diasCarenciaJuros
        {
            get { return this.m_DiasCarenciaJuros; }
            set { this.m_DiasCarenciaJuros = value; }
        }

        private string m_TipoCarenciaMulta;
        public string tipoCarenciaMulta
        {
            get { return this.m_TipoCarenciaMulta; }
            set { this.m_TipoCarenciaMulta = value; }
        }

        private int m_DiasCarenciaMulta;
        public int diasCarenciaMulta
        {
            get { return this.m_DiasCarenciaMulta; }
            set { this.m_DiasCarenciaMulta = value; }
        }

        private string m_JurosMesesAnteriores;
        public string jurosMesesAnteriores
        {
            get { return this.m_JurosMesesAnteriores; }
            set { this.m_JurosMesesAnteriores = value; }
        }

    }
}
