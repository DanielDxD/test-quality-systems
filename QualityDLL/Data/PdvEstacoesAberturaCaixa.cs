using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacoesAberturaCaixa : Base
    {
        public PdvEstacoesAberturaCaixa() : base()
        {
        }

        private int m_idPdvEstacaoAberturaCaixa;
        public int idPdvEstacaoAberturaCaixa
        {
            get { return this.m_idPdvEstacaoAberturaCaixa; }
            set { this.m_idPdvEstacaoAberturaCaixa = value; }
        }

        private DateTime m_dataAbertura;
        public DateTime dataAbertura
        {
            get { return this.m_dataAbertura; }
            set { this.m_dataAbertura = value; }
        }

        private double m_valorTotal;
        public double valorTotal
        {
            get { return this.m_valorTotal; }
            set { this.m_valorTotal = value; }
        }

        private PdvEstacao  m_pdvEstacao;
        public PdvEstacao  pdvEstacao
        {
            get { return this.m_pdvEstacao; }
            set { this.m_pdvEstacao = value; }
        }

        private Funcionario m_funcionario;
        public Funcionario funcionario
        {
            get { return this.m_funcionario; }
            set { this.m_funcionario = value; }
        }

        private PdvEstacoesFechamentoCaixa m_pdvEstacaoFechamentoCaixa;
        public PdvEstacoesFechamentoCaixa pdvEstacaoFechamentoCaixa
        {
            get { return this.m_pdvEstacaoFechamentoCaixa; }
            set { this.m_pdvEstacaoFechamentoCaixa = value; }
        }

        private PdvEstacoesAberturaCaixaDetalhe[] m_pdvEstacoesAberturaCaixaDetalhe;
        public PdvEstacoesAberturaCaixaDetalhe[] pdvEstacoesAberturaCaixaDetalhe
        {
            get { return this.m_pdvEstacoesAberturaCaixaDetalhe; }
            set { this.m_pdvEstacoesAberturaCaixaDetalhe = value; }
        }

        public override string ToString()
        {
            return this.m_idPdvEstacaoAberturaCaixa.ToString();
        }
    }
}
