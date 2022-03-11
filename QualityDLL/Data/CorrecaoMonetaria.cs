using System;

namespace Data
{
    //[Serializable]
    public class CorrecaoMonetaria : Base
    {

        public CorrecaoMonetaria() : base()
        {
        }

        private int m_IdCorrecaoMonetaria;
        public int idCorrecaoMonetaria
        {
            get { return this.m_IdCorrecaoMonetaria; }
            set { this.m_IdCorrecaoMonetaria = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_Ativo;
        public string ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

        private CorrecaoMonetariaItem[] m_CorrecaoMonetariaItems;
        public CorrecaoMonetariaItem[] correcaoMonetariaItems
        {

            get { return this.m_CorrecaoMonetariaItems; }
            set { this.m_CorrecaoMonetariaItems = value; }
        }

    }
}
