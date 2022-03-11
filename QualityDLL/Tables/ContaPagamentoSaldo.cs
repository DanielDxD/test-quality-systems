using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContaPagamentoSaldo")]
    public class ContaPagamentoSaldo : TTableBase
    {
        [TColumn("idContaPagamentoSaldo", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContaPagamentoSaldo= new TFieldInteger();
        public TFieldInteger idContaPagamentoSaldo
        {
            get { return this.m_idContaPagamentoSaldo; }
        }

        [TColumn("data", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_data = new TFieldDatetime();
        public TFieldDatetime data
        {
            get { return this.m_data; }
        }

        [TColumn("saldo", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_saldo = new TFieldDouble();
        public TFieldDouble saldo
        {
            get { return this.m_saldo; }
        }

        [TColumn("pagamentoVinculado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_pagamentoVinculado = new TFieldDouble();
        public TFieldDouble pagamentoVinculado
        {
            get { return this.m_pagamentoVinculado; }
        }

        [TColumn("recebimentoVinculado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_recebimentoVinculado = new TFieldDouble();
        public TFieldDouble recebimentoVinculado
        {
            get { return this.m_recebimentoVinculado; }
        }

        [TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idContaPagamento = new TFieldInteger();
        public TFieldInteger idContaPagamento
        {
            get {return this.m_idContaPagamento;}
        }
    }
}