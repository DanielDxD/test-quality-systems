using System;

namespace Data
{
    //[Serializable]
    public class ContaPagamentoSaldo : Base
    {
        public ContaPagamentoSaldo()
            : base()
        {
        }

        private int m_IdContaPagamentoSaldo;
        public int idContaPagamentoSaldo
        {
            get { return this.m_IdContaPagamentoSaldo; }
            set { this.m_IdContaPagamentoSaldo = value; }
        }

        private DateTime m_Data;
        public DateTime data
        {
            get { return this.m_Data; }
            set { this.m_Data = value; }
        }

        private double m_Saldo;
        public double saldo
        {
            get { return this.m_Saldo; }
            set { this.m_Saldo = value; }
        }

        private double m_PagamentoVinculado;
        public double pagamentoVinculado
        {
            get { return this.m_PagamentoVinculado; }
            set { this.m_PagamentoVinculado = value; }
        }

        private double m_RecebimentoVinculado;
        public double recebimentoVinculado
        {
            get { return this.m_RecebimentoVinculado; }
            set { this.m_RecebimentoVinculado = value; }
        }

        private int m_IdContaPagamento;
        public int idContaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        private double m_Saldo_Anterior;
        public double saldoAnterior
        {
            get { return this.m_Saldo_Anterior; }
            set { this.m_Saldo_Anterior = value; }
        }

        private double m_PagamentoVinculado_Anterior;
        public double pagamentoVinculadoAnterior
        {
            get { return this.m_PagamentoVinculado_Anterior; }
            set { this.m_PagamentoVinculado_Anterior = value; }
        }

        private double m_RecebimentoVinculado_Anterior;
        public double recebimentoVinculadoAnterior
        {
            get { return this.m_RecebimentoVinculado_Anterior; }
            set { this.m_RecebimentoVinculado_Anterior = value; }
        }
    }
}