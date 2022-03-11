using System;

namespace Data
{
    //[Serializable]
    public class ContratoTipoItemValor : Base
    {

        public ContratoTipoItemValor() : base()
        {
        }

        private int m_IdContratoTipoItemValor;
        public int idContratoTipoItemValor
        {
            get { return this.m_IdContratoTipoItemValor; }
            set { this.m_IdContratoTipoItemValor = value; }
        }

        private ContratoTipoItem m_IdContratoTipoItem;
        public ContratoTipoItem contratoTipoItem
        {
            get { return this.m_IdContratoTipoItem; }
            set { this.m_IdContratoTipoItem = value; }
        }

        private DateTime m_PeriodoInicial;
        public DateTime periodoInicial
        {
            get { return this.m_PeriodoInicial; }
            set { this.m_PeriodoInicial = value; }
        }

        private DateTime m_PeriodoFinal;
        public DateTime periodoFinal
        {
            get { return this.m_PeriodoFinal; }
            set { this.m_PeriodoFinal = value; }
        }

        private decimal m_Valor;
        public decimal valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

    }
}
