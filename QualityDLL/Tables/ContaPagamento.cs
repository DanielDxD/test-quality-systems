using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContaPagamento")]
    public class ContaPagamento : TTableBase
    {
        [TColumn("idContaPagamento", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idContaPagamento = new TFieldInteger();
        public TFieldInteger idContaPagamento
        {
            get { return this.m_idContaPagamento; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("codigoExportacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoExportacao = new TFieldString();
        public TFieldString codigoExportacao
        {
            get { return this.m_codigoExportacao; }
        }

        [TColumn("numeroConta", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroConta = new TFieldString();
        public TFieldString numeroConta
        {
            get { return this.m_numeroConta; }
        }

        [TColumn("tipoConta", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipoConta = new TFieldString();
        public TFieldString tipoConta
        {
            get { return this.m_tipoConta; }
        }

        [TColumn("saldoAtual", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_saldoAtual = new TFieldDouble();
        public TFieldDouble saldoAtual
        {
            get { return this.m_saldoAtual; }
        }

        [TColumn("recebimentoVinculado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_recebimentoVinculado = new TFieldDouble();
        public TFieldDouble recebimentoVinculado
        {
            get { return this.m_recebimentoVinculado; }
        }

        [TColumn("pagamentoVinculado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_pagamentoVinculado = new TFieldDouble();
        public TFieldDouble pagamentoVinculado
        {
            get { return this.m_pagamentoVinculado; }
        }

        [
            TColumn("idBanco", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idBanco->idBanco" })
        ]
        private Banco m_idBanco = null;
        public Banco banco
        {
            get
            {
                if (this.m_idBanco == null)
                {
                    this.m_idBanco = new Banco();

                    foreach (TJoin attribute in this.m_idBanco.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idBanco.connectionString = this.connectionString;
                            this.m_idBanco.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idBanco.selfFill();

                return this.m_idBanco;
            }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("numeroChequeInicial", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_numeroChequeInicial = new TFieldInteger();
        public TFieldInteger numeroChequeInicial
        {
            get { return this.m_numeroChequeInicial; }
        }

        [TColumn("numeroChequeFinal", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_numeroChequeFinal = new TFieldInteger();
        public TFieldInteger numeroChequeFinal
        {
            get { return this.m_numeroChequeFinal; }
        }
        
        [TColumn("idUsuario", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idUsuario = new TFieldInteger();
        public TFieldInteger idUsuario
        {
            get { return this.m_idUsuario; }
        }

        [TColumn("agencia", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_agencia = new TFieldString();
        public TFieldString agencia
        {
            get { return this.m_agencia; }
        }

        [TColumn("agenciaDigito", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_agenciaDigito = new TFieldString();
        public TFieldString agenciaDigito
        {
            get { return this.m_agenciaDigito; }
        }


        [TColumn("numeroContaDigito", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroContaDigito = new TFieldString();
        public TFieldString numeroContaDigito
        {
            get { return this.m_numeroContaDigito; }
        }

        [
         TColumn("idPlanoContas", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPlanoContas->idPlanoContas" })
        ]
        private PlanoContas m_idPlanoContas = null;
        public PlanoContas planoContas
        {
            get
            {
                if (this.m_idPlanoContas == null)
                {
                    this.m_idPlanoContas = new PlanoContas();

                    foreach (TJoin attribute in this.m_idPlanoContas.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idPlanoContas.connectionString = this.connectionString;
                            this.m_idPlanoContas.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPlanoContas.selfFill();

                return this.m_idPlanoContas;
            }
        }

        [
         TList(typeof(ContaPagamentoSaldo)),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private Object m_ContaPagamentoSaldos = null;
        public System.Collections.Generic.List<ContaPagamentoSaldo> contaPagamentoSaldos
        {
            get
            {
                if (this.m_ContaPagamentoSaldos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContaPagamentoSaldo) }
                     ).IsInstanceOfType(this.m_ContaPagamentoSaldos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoSaldos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoSaldos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoSaldos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoSaldos)[i]);

                        this.m_ContaPagamentoSaldos = em.list(typeof(ContaPagamentoSaldo), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContaPagamentoSaldo>)this.m_ContaPagamentoSaldos;
            }
        }

        [
            TColumn("idFormaPagamento", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idFormaPagamento->idFormaPagamento" })
        ]
        private FormaPagamento m_idFormaPagamento = null;
        public FormaPagamento formaPagamento
        {
            get
            {
                if (this.m_idFormaPagamento == null)
                {
                    this.m_idFormaPagamento = new FormaPagamento();

                    foreach (TJoin attribute in this.m_idFormaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idFormaPagamento.connectionString = this.connectionString;
                            this.m_idFormaPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idBanco.selfFill();

                return this.m_idFormaPagamento;
            }
        }
    }
}