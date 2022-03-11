using System;

namespace Data
{
    //[Serializable]
    public class ParametroBoletoDesconto : Base
    {

        public ParametroBoletoDesconto() : base()
        {
        }

        private int m_IdParametroBoletoDesconto;
        public int idParametroBoletoDesconto
        {
            get { return this.m_IdParametroBoletoDesconto; }
            set { this.m_IdParametroBoletoDesconto = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_TipoDesconto;
        public string tipoDesconto
        {
            get { return this.m_TipoDesconto; }
            set { this.m_TipoDesconto = value; }
        }

        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        private CategoriaTitulo m_IdCategoriaTitulo;
        public CategoriaTitulo categoriaTitulo
        {
            get { return this.m_IdCategoriaTitulo; }
            set { this.m_IdCategoriaTitulo = value; }
        }

        private Situacao m_IdSituacao;
        public Situacao situacao
        {
            get { return this.m_IdSituacao; }
            set { this.m_IdSituacao = value; }
        }

        private ParametroBoleto m_IdParametroBoleto;
        public ParametroBoleto parametroBoleto
        {
            get { return this.m_IdParametroBoleto; }
            set { this.m_IdParametroBoleto = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private int m_DiasAVencer;
        public int diasAVencer
        {
            get { return this.m_DiasAVencer; }
            set { this.m_DiasAVencer = value; }
        }

        private int m_DiaFixo;
        public int diaFixo
        {
            get { return this.m_DiaFixo; }
            set { this.m_DiaFixo = value; }
        }

        private DateTime m_DataInicio;
        public DateTime dataInicio
        {
            get { return this.m_DataInicio; }
            set { this.m_DataInicio = value; }
        }

        private DateTime m_DataFim;
        public DateTime dataFim
        {
            get { return this.m_DataFim; }
            set { this.m_DataFim = value; }
        }

    }
}
