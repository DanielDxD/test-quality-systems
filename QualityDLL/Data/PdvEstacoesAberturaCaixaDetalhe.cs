using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacoesAberturaCaixaDetalhe : Base
    {
        public PdvEstacoesAberturaCaixaDetalhe() : base()
        {
        }

        private int m_idPdvEstacaoAberturaCaixaDetalhe;
        public int idPdvEstacaoAberturaCaixaDetalhe
        {
            get { return this.m_idPdvEstacaoAberturaCaixaDetalhe; }
            set { this.m_idPdvEstacaoAberturaCaixaDetalhe = value; }
        }

        private Data.PdvEstacoesAberturaCaixa m_pdvEstacaoAberturaCaixa;
        public Data.PdvEstacoesAberturaCaixa pdvEstacaoAberturaCaixa
        {
            get { return this.m_pdvEstacaoAberturaCaixa; }
            set { this.m_pdvEstacaoAberturaCaixa = value; }
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

        public override string ToString()
        {
            return this.m_idPdvEstacaoAberturaCaixaDetalhe.ToString();
        }
    }
}
