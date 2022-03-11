using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    //[Serializable]
    public class EmpresaRelacionamentoCartaoMovimento : Base
    {
        public EmpresaRelacionamentoCartaoMovimento(): base()
		{
        }

        private int m_IdEmpresaRelacionamentoCartaoMovimento;
        public int idEmpresaRelacionamentoCartaoMovimento
        {
            get { return this.m_IdEmpresaRelacionamentoCartaoMovimento; }
            set { this.m_IdEmpresaRelacionamentoCartaoMovimento = value; }
        }

        private EmpresaRelacionamentoCartaoMovimento m_IdEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao;
        public EmpresaRelacionamentoCartaoMovimento estornoDevolucao
        {
            get { return this.m_IdEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao; }
            set { this.m_IdEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao = value; }
        }

        private EmpresaRelacionamentoCartao m_IdEmpresaRelacionamentoCartao;
        public EmpresaRelacionamentoCartao empresaRelacionamentoCartao
        {
            get { return this.m_IdEmpresaRelacionamentoCartao; }
            set { this.m_IdEmpresaRelacionamentoCartao = value; }
        }

        private PdvEstacao  m_IdPdvEstacao;
        public PdvEstacao  pdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        private bool m_FlagEstorno;
        public bool flagEstornoDevolucao
        {
            get { return this.m_FlagEstorno; }
            set { this.m_FlagEstorno = value; }
        }

        private DateTime m_DataEstornoDevolucao;
        public DateTime dataEstornoDevolucao
        {
            get { return this.m_DataEstornoDevolucao; }
            set { this.m_DataEstornoDevolucao = value; }
        }

        private ContaPagamentoMovimento m_IdContaPagamentoMovimento;
        public ContaPagamentoMovimento contaPagamentoMovimento
        {
            get { return this.m_IdContaPagamentoMovimento; }
            set { this.m_IdContaPagamentoMovimento = value; }
        }

        private ContasAReceber m_IdContasAReceber;
        public ContasAReceber contasAReceber
        {
            get { return this.m_IdContasAReceber; }
            set { this.m_IdContasAReceber = value; }
        }

        private PdvCompra m_IdPdvCompra;
        public PdvCompra pdvCompra
        {
            get { return this.m_IdPdvCompra; }
            set { this.m_IdPdvCompra = value; }
        }

        private String m_tipoMovimento;
        public String tipoMovimento
        {
            get { return this.m_tipoMovimento; }
            set { this.m_tipoMovimento = value; }
        }

        private String m_tipoOperacao;
        public String tipoOperacao
        {
            get { return this.m_tipoOperacao; }
            set { this.m_tipoOperacao = value; }
        }

        private double m_valorMovimento;
        public double valorMovimento
        {
            get { return this.m_valorMovimento; }
            set { this.m_valorMovimento = value; }
        }

        private double m_valorDesconto;
        public double valorDesconto
        {
            get { return this.m_valorDesconto; }
            set { this.m_valorDesconto = value; }
        }

        private double m_TaxaServico;
        public double valorTaxaServico
        {
            get { return this.m_TaxaServico; }
            set { this.m_TaxaServico = value; }
        }

        private DateTime m_dataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_dataMovimento; }
            set { this.m_dataMovimento = value; }
        }
    }
}
