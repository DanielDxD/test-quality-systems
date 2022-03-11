using System;

namespace Data
{
    //[Serializable]
    public class RelatorioBandas : Base
    {
        public RelatorioBandas()
            : base()
        {
        }

        private int m_IdRelatorioBanda;
        public int idRelatorioBanda
        {
            get { return this.m_IdRelatorioBanda; }
            set { this.m_IdRelatorioBanda = value; }
        }

        private String m_Nome;
        public String nome
        {
            get { return this.m_Nome; }
            set { this.m_Nome = value; }
        }

        private String m_ImagemFundo;
        public String imagemFundo
        {
            get { return this.m_ImagemFundo; }
            set { this.m_ImagemFundo = value; }
        }

        private String m_Tipo;
        public String tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private int m_Largura;
        public int largura
        {
            get { return this.m_Largura; }
            set { this.m_Largura = value; }
        }

        private int m_Altura;
        public int altura
        {
            get { return this.m_Altura; }
            set { this.m_Altura = value; }
        }

        private int m_IdRelatorioBandaPai;
        public int idRelatorioBandaPai
        {
            get { return this.m_IdRelatorioBandaPai; }
            set { this.m_IdRelatorioBandaPai = value; }
        }

        private int m_IdRelatorio;
        public int idRelatorio
        {
            get { return this.m_IdRelatorio; }
            set { this.m_IdRelatorio = value; }
        }

        private String m_NovaPagina;
        public String novaPagina
        {
            get { return this.m_NovaPagina; }
            set { this.m_NovaPagina = value; }
        }

        private RelatorioBandas[] m_RelatorioBandass;
        public RelatorioBandas[] relatorioBandass
        {
            get { return this.m_RelatorioBandass; }
            set { this.m_RelatorioBandass = value; }
        }

        //idRelatorioBanda
        private RelatorioCampos[] m_RelatorioCamposs;
        public RelatorioCampos[] relatorioCamposs
        {
            get { return this.m_RelatorioCamposs; }
            set { this.m_RelatorioCamposs = value; }
        }
    }
}