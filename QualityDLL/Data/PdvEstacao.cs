using System;
using System.Data;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvEstacao : Base
    {
        public PdvEstacao() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvEstacao;
        public int idPdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 200)
        ]
        private string m_descricao;
        public string descricao
        {
            get { return this.m_descricao; }
            set { this.m_descricao = value; }
        }

        private bool m_confirmacaoGerente;
        public bool confirmacaoGerente
        {
            get { return this.m_confirmacaoGerente; }
            set { this.m_confirmacaoGerente = value; }
        }

        private bool m_habilitarDescontoTotal;
        public bool habilitarDescontoTotal
        {
            get { return this.m_habilitarDescontoTotal; }
            set { this.m_habilitarDescontoTotal = value; }
        }

        private string m_pdvLiberado;
        public string pdvLiberado
        {
            get { return this.m_pdvLiberado; }
            set { this.m_pdvLiberado = value; }
        }

        private string m_pos;
        public string pos
        {
            get { return this.m_pos; }
            set { this.m_pos = value; }
        }

        private Data.Pos m_Pos;
        public Data.Pos Pos
        {
            get { return this.m_Pos; }
            set { this.m_Pos = value; }
        }

        private Cliente m_IdCliente;
        public Cliente cliente
        {

            get { return this.m_IdCliente; }
            set { this.m_IdCliente = value; }
        }

        private bool m_habilitarPrePago;
        public bool habilitarPrePago
        {
            get { return this.m_habilitarPrePago; }
            set { this.m_habilitarPrePago = value; }
        }

        private bool m_habilitarPosPago;
        public bool habilitarPosPago
        {
            get { return this.m_habilitarPosPago; }
            set { this.m_habilitarPosPago = value; }
        }


        private bool m_habilitarNotaPromissoria;
        public bool habilitarNotaPromissoria
        {
            get { return this.m_habilitarNotaPromissoria; }
            set { this.m_habilitarNotaPromissoria = value; }
        }

        private bool m_agruparProdutosCupom;
        public bool agruparProdutosCupom
        {
            get { return this.m_agruparProdutosCupom; }
            set { this.m_agruparProdutosCupom = value; }
        }

        private int m_IdContaPagamentoDesconto;
        public int idContaPagamentoDesconto
        {
            get { return this.m_IdContaPagamentoDesconto; }
            set { this.m_IdContaPagamentoDesconto = value; }
        }

        private bool m_aberto;
        public bool aberto
        {
            get { return this.m_aberto; }
            set { this.m_aberto = value; }
        }

        private double m_aplicarTaxaServico;
        public double aplicarTaxaServico
        {
            get { return this.m_aplicarTaxaServico; }
            set { this.m_aplicarTaxaServico = value; }
        }

        private int m_idEmpresaRelacionamentoGerente;
        public int idEmpresaRelacionamentoGerente
        {
            get { return this.m_idEmpresaRelacionamentoGerente; }
            set { this.m_idEmpresaRelacionamentoGerente = value; }
        }

        [
            TFieldAttributeGridDisplay("Departamento", 200),
            TFieldAttributeSubfield("idDepartamento:descricao")
        ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        private Departamento m_departamentoOrigem;
        public Departamento departamentoOrigem
        {
            get { return this.m_departamentoOrigem; }
            set { this.m_departamentoOrigem = value; }
        }

        private Departamento m_prePagoDepartamento;
        public Departamento prePagoDepartamento
        {
            get { return this.m_prePagoDepartamento; }
            set { this.m_prePagoDepartamento = value; }
        }

        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        private NaturezaOperacao m_IdPosPagoNaturezaOperacao;
        public NaturezaOperacao posPagoNaturezaOperacao
        {
            get { return this.m_IdPosPagoNaturezaOperacao; }
            set { this.m_IdPosPagoNaturezaOperacao = value; }
        }

        private NaturezaOperacao m_IdPrePagoNaturezaOperacao;
        public NaturezaOperacao prePagoNaturezaOperacao
        {
            get { return this.m_IdPrePagoNaturezaOperacao; }
            set { this.m_IdPrePagoNaturezaOperacao = value; }
        }

        private NaturezaOperacao m_IdPrePagoNaturezaOperacaoEstorno;
        public NaturezaOperacao prePagoNaturezaOperacaoEstorno
        {
            get { return this.m_IdPrePagoNaturezaOperacaoEstorno; }
            set { this.m_IdPrePagoNaturezaOperacaoEstorno = value; }
        }


        private PdvEstacoesAberturaCaixa m_aberturaCaixaAtual;
        public PdvEstacoesAberturaCaixa aberturaCaixaAtual
        {
            get { return this.m_aberturaCaixaAtual; }
            set { this.m_aberturaCaixaAtual = value; }
        }

        private PdvEstacoesAberturaCaixa[] m_pdvEstacoesAberturaCaixa;
        public PdvEstacoesAberturaCaixa[] pdvEstacoesAberturaCaixa
        {
            get { return this.m_pdvEstacoesAberturaCaixa; }
            set { this.m_pdvEstacoesAberturaCaixa = value; }
        }

        private PdvEstacoesFechamentoCaixa[] m_pdvEstacoesFechamentoCaixa;
        public PdvEstacoesFechamentoCaixa[] pdvEstacoesFechamentoCaixa
        {
            get { return this.m_pdvEstacoesFechamentoCaixa; }
            set { this.m_pdvEstacoesFechamentoCaixa = value; }
        }

        private bool m_habilitarBalanca;
        public bool habilitarBalanca
        {
            get { return this.m_habilitarBalanca; }
            set { this.m_habilitarBalanca = value; }
        }

        private AparelhoSat m_IdAparelhoSat;
        public AparelhoSat aparelhoSat
        {
            get { return this.m_IdAparelhoSat; }
            set { this.m_IdAparelhoSat = value; }
        }

        private bool m_IgnorarAberturaCaixa;
        public bool ignorarAberturaCaixa
        {
            get { return this.m_IgnorarAberturaCaixa; }
            set { this.m_IgnorarAberturaCaixa = value; }
        }

        private PdvEstacoesConfig[] m_PdvEstacaoConfig;
        public PdvEstacoesConfig[] pdvEstacaoConfig
        {
            get { return this.m_PdvEstacaoConfig; }
            set { this.m_PdvEstacaoConfig = value; }
        }

        public override string ToString()
        {
            return this.m_IdPdvEstacao.ToString();
        }
    }
}
