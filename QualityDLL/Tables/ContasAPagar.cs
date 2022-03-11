using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContasAPagar")]
    public class ContasAPagar : TTableBase
    {
        [TColumn("idContasAPagar", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContasAPagar = new TFieldInteger();
        public TFieldInteger idContasAPagar
        {
            get { return this.m_idContasAPagar; }
        }

        [TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataMovimento = new TFieldDatetime();
        public TFieldDatetime dataMovimento
        {
            get { return this.m_dataMovimento; }
        }

        [TColumn("dataVencimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataVencimento = new TFieldDatetime();
        public TFieldDatetime dataVencimento
        {
            get { return this.m_dataVencimento; }
        }

        [TColumn("dataLancamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataLancamento = new TFieldDatetime();
        public TFieldDatetime dataLancamento
        {
            get { return this.m_dataLancamento; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("iss", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_iss = new TFieldDouble();
        public TFieldDouble iss
        {
            get { return this.m_iss; }
        }

        [TColumn("desconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_desconto = new TFieldDouble();
        public TFieldDouble desconto
        {
            get { return this.m_desconto; }
        }

        [TColumn("valorPago", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorPago = new TFieldDouble();
        public TFieldDouble valorPago
        {
            get { return this.m_valorPago; }
        }

        [TColumn("dataUltimoPagamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataUltimoPagamento = new TFieldDatetime();
        public TFieldDatetime dataUltimoPagamento
        {
            get { return this.m_dataUltimoPagamento; }
        }

        [TColumn("emAberto", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_emAberto = new TFieldBoolean();
        public TFieldBoolean emAberto
        {
            get { return this.m_emAberto; }
        }

        [TColumn("parcela", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_parcela = new TFieldString();
        public TFieldString parcela
        {
            get { return this.m_parcela; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        private string m_outrasInformacoes = null;
        public string outrasInformacoes
        {
            get { return this.m_outrasInformacoes; }
        }

        /*[
         TColumn("idFornecedor", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idFornecedor->idFornecedor" })
        ]
        private Fornecedor m_idFornecedor = null;
        public Fornecedor fornecedor
        {
            get
            {
                if (this.m_idFornecedor == null)
                {
                    this.m_idFornecedor = new Fornecedor();

                    foreach (TJoin attribute in this.m_idFornecedor.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idFornecedor.connectionString = this.connectionString;
                            this.m_idFornecedor.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idFornecedor.selfFill();

                return this.m_idFornecedor;
            }
        }*/


        [TColumn("numeroDocumento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroDocumento = new TFieldString();
        public TFieldString numeroDocumento
        {
            get { return this.m_numeroDocumento; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get
            {
                return this.m_idEmpresa;
            }
        }

        [
         TColumn("idEvento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idEvento->idEvento" })
        ]
        private Evento m_IdEvento = null;
        public Evento evento
        {
            get
            {
                if (this.m_IdEvento == null)
                {
                    this.m_IdEvento = new Evento();

                    foreach (TJoin attribute in this.m_IdEvento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdEvento.connectionString = this.connectionString;
                            this.m_IdEvento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdEvento.selfFill();

                return this.m_IdEvento;
            }
        }

        [
         TColumn("idEvento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idEvento->idEvento" })
        ]
        private TFieldInteger m_IdEvento2 = new TFieldInteger();
        public TFieldInteger idEvento
        {
            get { return this.m_IdEvento2; }
        }

        [
         TColumn("idTipoMovimentoContabil", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoMovimentoContabil->idTipoMovimentoContabil" })
        ]
        private TipoMovimentoContabil m_idTipoMovimentoContabil = null;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get
            {
                if (this.m_idTipoMovimentoContabil == null)
                {
                    this.m_idTipoMovimentoContabil = new TipoMovimentoContabil();

                    foreach (TJoin attribute in this.m_idTipoMovimentoContabil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoMovimentoContabil.connectionString = this.connectionString;
                            this.m_idTipoMovimentoContabil.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoMovimentoContabil.selfFill();

                return this.m_idTipoMovimentoContabil;
            }
        }

        [
         TList(typeof(ContasAPagarItem)),
         TJoin(new String[] { "idContasAPagar->idContasAPagar" })
        ]
        private Object m_ContasAPagarItems = null;
        public System.Collections.Generic.List<ContasAPagarItem> contasAPagarItems
        {
            get
            {
                if (this.m_ContasAPagarItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContasAPagarItem) }
                     ).IsInstanceOfType(this.m_ContasAPagarItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAPagarItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContasAPagarItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContasAPagarItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAPagarItems)[i]);

                        this.m_ContasAPagarItems = em.list(typeof(ContasAPagarItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContasAPagarItem>)this.m_ContasAPagarItems;
            }
        }

        [
         TList(typeof(ContasAPagarPagamento)),
         TJoin(new String[] { "idContasAPagar->idContasAPagar" })
        ]
        private Object m_ContasAPagarPagamentos = null;
        public System.Collections.Generic.List<ContasAPagarPagamento> contasAPagarPagamentos
        {
            get
            {
                if (this.m_ContasAPagarPagamentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContasAPagarPagamento) }
                     ).IsInstanceOfType(this.m_ContasAPagarPagamentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAPagarPagamentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContasAPagarPagamentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContasAPagarPagamentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAPagarPagamentos)[i]);

                        this.m_ContasAPagarPagamentos = em.list(typeof(ContasAPagarPagamento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContasAPagarPagamento>)this.m_ContasAPagarPagamentos;
            }
        }

        [
           TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamento = null;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get
            {
                if (this.m_idEmpresaRelacionamento == null)
                {
                    this.m_idEmpresaRelacionamento = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresaRelacionamento.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamento.selfFill();

                return this.m_idEmpresaRelacionamento;
            }
        }
    }
}