using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Relatorios : Base
    {
        public Relatorios()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdRelatorio;
        public int idRelatorio
        {
            get { return this.m_IdRelatorio; }
            set { this.m_IdRelatorio = value; }
        }

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("Descrição", 270)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
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

        private int m_Colunas;
        public int colunas
        {
            get { return this.m_Colunas; }
            set { this.m_Colunas = value; }
        }

        private int m_Paginas;
        public int paginas
        {
            get { return this.m_Paginas; }
            set { this.m_Paginas = value; }
        }

        private int m_MargemTopo;
        public int margemTopo
        {
            get { return this.m_MargemTopo; }
            set { this.m_MargemTopo = value; }
        }

        private int m_MargemRodape;
        public int margemRodape
        {
            get { return this.m_MargemRodape; }
            set { this.m_MargemRodape = value; }
        }

        private int m_MargemEsquerda;
        public int margemEsquerda
        {
            get { return this.m_MargemEsquerda; }
            set { this.m_MargemEsquerda = value; }
        }

        private int m_MargemDireita;
        public int margemDireita
        {
            get { return this.m_MargemDireita; }
            set { this.m_MargemDireita = value; }
        }

        private String m_FonteNome;
        public String fonteNome
        {
            get { return this.m_FonteNome; }
            set { this.m_FonteNome = value; }
        }

        private int m_FonteTamanho;
        public int fonteTamanho
        {
            get { return this.m_FonteTamanho; }
            set { this.m_FonteTamanho = value; }
        }

        private String m_ClasseBase;
        public String classeBase
        {
            get { return this.m_ClasseBase; }
            set { this.m_ClasseBase = value; }
        }

        private String m_Tipo;
        public String tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private String m_Condicao;
        public String condicao
        {
            get { return this.m_Condicao; }
            set { this.m_Condicao = value; }
        }

        private RelatorioBandas m_Cabecalho;
        public RelatorioBandas cabecalho
        {
            get { return this.m_Cabecalho; }
            set { this.m_Cabecalho = value; }
        }

        private RelatorioBandas[] m_GrupoCabecalhos;
        public RelatorioBandas[] grupoCabecalhos
        {
            get { return this.m_GrupoCabecalhos; }
            set { this.m_GrupoCabecalhos = value; }
        }

        private RelatorioBandas m_Detalhe;
        public RelatorioBandas detalhe
        {
            get { return this.m_Detalhe; }
            set { this.m_Detalhe = value; }
        }

        private RelatorioBandas[] m_GrupoRodapes;
        public RelatorioBandas[] grupoRodapes
        {
            get { return this.m_GrupoRodapes; }
            set { this.m_GrupoRodapes = value; }
        }

        private RelatorioBandas m_Rodape;
        public RelatorioBandas rodape
        {
            get { return this.m_Rodape; }
            set { this.m_Rodape = value; }
        }
    }
}