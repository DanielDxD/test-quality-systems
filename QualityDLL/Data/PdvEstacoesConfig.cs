using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacoesConfig : Base
    {
        public PdvEstacoesConfig() : base()
        {
        }

        private int m_pdvEstacao;
        public int idPdvEstacao
        {
            get { return this.m_pdvEstacao; }
            set { this.m_pdvEstacao = value; }
        }

        private string m_nomeConfig;
        public string nomeConfig
        {
            get { return this.m_nomeConfig; }
            set { this.m_nomeConfig = value; }
        }

        private string m_valor;
        public string valor
        {
            get { return this.m_valor; }
            set { this.m_valor = value; }
        }




        public override string ToString()
        {
            return this.m_pdvEstacao.ToString();
        }
    }
}
