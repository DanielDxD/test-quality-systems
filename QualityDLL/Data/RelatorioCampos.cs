using System;

namespace Data
{
    //[Serializable]
    public class RelatorioCampos : Base
    {
        public RelatorioCampos()
            : base()
        {
        }

        private int m_IdRelatorioCampo;
        public int idRelatorioCampo
        {
            get { return this.m_IdRelatorioCampo; }
            set { this.m_IdRelatorioCampo = value; }
        }

        private String m_Nome;
        public String nome
        {
            get { return this.m_Nome; }
            set { this.m_Nome = value; }
        }

        private String m_Tipo;
        public String tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private bool m_Campo;
        public bool campo
        {
            get { return this.m_Campo; }
            set { this.m_Campo = value; }
        }

        private int m_CantoBorda;
        public int cantoBorda
        {
            get { return this.m_CantoBorda; }
            set { this.m_CantoBorda = value; }
        }

        private String m_Linha;
        public String linha
        {
            get { return this.m_Linha; }
            set { this.m_Linha = value; }
        }

        private String m_Coluna;
        public String coluna
        {
            get { return this.m_Coluna; }
            set { this.m_Coluna = value; }
        }

        private String m_Largura;
        public String largura
        {
            get { return this.m_Largura; }
            set { this.m_Largura = value; }
        }

        private String m_Altura;
        public String altura
        {
            get { return this.m_Altura; }
            set { this.m_Altura = value; }
        }

        private String m_Valor;
        public String valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private String m_Formato;
        public String formato
        {
            get { return this.m_Formato; }
            set { this.m_Formato = value; }
        }

        private String m_Condicao;
        public String condicao
        {
            get { return this.m_Condicao; }
            set { this.m_Condicao = value; }
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

        private String m_FonteEstilo;
        public String fonteEstilo
        {
            get { return this.m_FonteEstilo; }
            set { this.m_FonteEstilo = value; }
        }

        private String m_FonteCor;
        public String fonteCor
        {
            get { return this.m_FonteCor; }
            set { this.m_FonteCor = value; }
        }

        private String m_Alinhamento;
        public String alinhamento
        {
            get { return this.m_Alinhamento; }
            set { this.m_Alinhamento = value; }
        }

        private int m_IdRelatorioBanda;
        public int idRelatorioBanda
        {
            get { return this.m_IdRelatorioBanda; }
            set { this.m_IdRelatorioBanda = value; }
        }
    }
}