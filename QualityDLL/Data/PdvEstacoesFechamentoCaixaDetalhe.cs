using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacoesFechamentoCaixaDetalhe : Base
    {
        public PdvEstacoesFechamentoCaixaDetalhe() : base()
        {
        }

        private int m_idPdvEstacaoFechamentoCaixaDetalhe;
        public int idPdvEstacaoFechamentoCaixaDetalhe
        {
            get { return this.m_idPdvEstacaoFechamentoCaixaDetalhe; }
            set { this.m_idPdvEstacaoFechamentoCaixaDetalhe = value; }
        }

        private Data.PdvEstacoesFechamentoCaixa m_pdvEstacaoFechamentoCaixa;
        public Data.PdvEstacoesFechamentoCaixa pdvEstacaoFechamentoCaixa
        {
            get { return this.m_pdvEstacaoFechamentoCaixa; }
            set { this.m_pdvEstacaoFechamentoCaixa = value; }
        }

        private Data.ContaPagamento m_contaPagamento;
        public Data.ContaPagamento contaPagamento
        {
            get { return this.m_contaPagamento; }
            set { this.m_contaPagamento = value; }
        }

        private double m_valor;
        public double valor
        {
            get { return this.m_valor; }
            set { this.m_valor = value; }
        }

        private double m_valorDigitado;
        public double valorDigitado
        {
            get { return this.m_valorDigitado; }
            set { this.m_valorDigitado = value; }
        }

        public override string ToString()
        {
            return this.m_idPdvEstacaoFechamentoCaixaDetalhe.ToString();
        }
    }
}
