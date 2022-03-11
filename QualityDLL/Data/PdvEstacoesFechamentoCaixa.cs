using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacoesFechamentoCaixa : Base
    {
        public PdvEstacoesFechamentoCaixa() : base()
        {
        }

        private int m_idPdvEstacaoFechamentoCaixa;
        public int idPdvEstacaoFechamentoCaixa
        {
            get { return this.m_idPdvEstacaoFechamentoCaixa; }
            set { this.m_idPdvEstacaoFechamentoCaixa = value; }
        }

        private DateTime m_dataFechamento;
        public DateTime dataFechamento
        {
            get { return this.m_dataFechamento; }
            set { this.m_dataFechamento = value; }
        }

        private double m_valorTotal;
        public double valorTotal
        {
            get { return this.m_valorTotal; }
            set { this.m_valorTotal = value; }
        }

        private PdvEstacao m_pdvEstacao;
        public PdvEstacao pdvEstacao
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

        private PdvEstacoesAberturaCaixa m_pdvEstacaoAberturaCaixa;
        public PdvEstacoesAberturaCaixa pdvEstacaoAberturaCaixa
        {
            get { return this.m_pdvEstacaoAberturaCaixa; }
            set { this.m_pdvEstacaoAberturaCaixa = value; }
        }

        private PdvEstacoesFechamentoCaixaDetalhe[] m_pdvEstacoesFechamentoCaixaDetalhe;
        public PdvEstacoesFechamentoCaixaDetalhe[] pdvEstacoesFechamentoCaixaDetalhe
        {
            get { return this.m_pdvEstacoesFechamentoCaixaDetalhe; }
            set { this.m_pdvEstacoesFechamentoCaixaDetalhe = value; }
        }

        public override string ToString()
        {
            return this.m_idPdvEstacaoFechamentoCaixa.ToString();
        }
    }
}
