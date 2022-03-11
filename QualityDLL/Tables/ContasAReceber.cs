using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContasAReceber")]
    public class ContasAReceber : TTableBase
    {
        [TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContasAReceber = new TFieldInteger();
        public TFieldInteger idContasAReceber
        {
            get { return this.m_idContasAReceber; }
        }

        [TColumn("dataLancamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataLancamento = new TFieldDatetime();
        public TFieldDatetime dataLancamento
        {
            get { return this.m_dataLancamento; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        [TColumn("dataVencimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataVencimento = new TFieldDatetime();
        public TFieldDatetime dataVencimento
        {
            get { return this.m_dataVencimento; }
        }

        [TColumn("dataLancamentoEfetivo", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataLancamentoEfetivo = new TFieldDatetime();
        public TFieldDatetime dataLancamentoEfetivo
        {
            get { return this.m_dataLancamentoEfetivo; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("numeroDocumento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroDocumento = new TFieldString();
        public TFieldString numeroDocumento
        {
            get { return this.m_numeroDocumento; }
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

        [TColumn("valorRecebido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorRecebido = new TFieldDouble();
        public TFieldDouble valorRecebido
        {
            get { return this.m_valorRecebido; }
        }

        [TColumn("dataUltimoRecebimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataUltimoRecebimento = new TFieldDatetime();
        public TFieldDatetime dataUltimoRecebimento
        {
            get { return this.m_dataUltimoRecebimento; }
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

        /*
        [
         TColumn("idPessoa", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPessoa->idPessoa" })
        ]
        private Pessoa m_idPessoa = null;
        public Pessoa pessoa
        {
            get
            {
                if (this.m_idPessoa == null)
                {
                    this.m_idPessoa = new Pessoa();

                    foreach (TJoin attribute in this.m_idPessoa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPessoa.connectionString = this.connectionString;
                            this.m_idPessoa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPessoa.selfFill();

                return this.m_idPessoa;
            }
        }
        */

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
         TList(typeof(BoletoItem)),
         TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private Object m_BoletoItems = null;
        public System.Collections.Generic.List<BoletoItem> boletoItems
        {
            get
            {
                if (this.m_BoletoItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(BoletoItem) }
                     ).IsInstanceOfType(this.m_BoletoItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_BoletoItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_BoletoItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_BoletoItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_BoletoItems)[i]);

                        this.m_BoletoItems = em.list(typeof(BoletoItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<BoletoItem>)this.m_BoletoItems;
            }
        }

        [
         TList(typeof(CaixaMovimentoLancamento)),
         TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private Object m_CaixaMovimentoLancamentos = null;
        public System.Collections.Generic.List<CaixaMovimentoLancamento> caixaMovimentoLancamentos
        {
            get
            {
                if (this.m_CaixaMovimentoLancamentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(CaixaMovimentoLancamento) }
                     ).IsInstanceOfType(this.m_CaixaMovimentoLancamentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos)[i]);

                        this.m_CaixaMovimentoLancamentos = em.list(typeof(CaixaMovimentoLancamento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<CaixaMovimentoLancamento>)this.m_CaixaMovimentoLancamentos;
            }
        }

        [
         TList(typeof(ContasAReceberItem)),
         TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private Object m_ContasAReceberItems = null;
        public System.Collections.Generic.List<ContasAReceberItem> contasAReceberItems
        {
            get
            {
                if (this.m_ContasAReceberItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContasAReceberItem) }
                     ).IsInstanceOfType(this.m_ContasAReceberItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAReceberItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContasAReceberItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContasAReceberItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAReceberItems)[i]);

                        this.m_ContasAReceberItems = em.list(typeof(ContasAReceberItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContasAReceberItem>)this.m_ContasAReceberItems;
            }
        }

        [
         TList(typeof(ContasAReceberPagamento)),
         TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private Object m_ContasAReceberPagamentos = null;
        public System.Collections.Generic.List<ContasAReceberPagamento> contasAReceberPagamentos
        {
            get
            {
                if (this.m_ContasAReceberPagamentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContasAReceberPagamento) }
                     ).IsInstanceOfType(this.m_ContasAReceberPagamentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos)[i]);

                        this.m_ContasAReceberPagamentos = em.list(typeof(ContasAReceberPagamento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContasAReceberPagamento>)this.m_ContasAReceberPagamentos;
            }
        }

        [
         TList(typeof(NotaFiscalSItem)),
         TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private Object m_NotaFiscalSItems = null;
        public System.Collections.Generic.List<NotaFiscalSItem> notaFiscalSItems
        {
            get
            {
                if (this.m_NotaFiscalSItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(NotaFiscalSItem) }
                     ).IsInstanceOfType(this.m_NotaFiscalSItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems)[i]);

                        this.m_NotaFiscalSItems = em.list(typeof(NotaFiscalSItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<NotaFiscalSItem>)this.m_NotaFiscalSItems;
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