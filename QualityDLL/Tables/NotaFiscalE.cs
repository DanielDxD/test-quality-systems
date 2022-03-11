using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("NotaFiscalE")]
    public class NotaFiscalE : TTableBase
    {
        [TColumn("idNotaFiscalE", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idNotaFiscalE = new TFieldInteger();
        public TFieldInteger idNotaFiscalE
        {
            get { return this.m_idNotaFiscalE; }
        }

        [TColumn("numero", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numero = new TFieldString();
        public TFieldString numero
        {
            get { return this.m_numero; }
        }

        [TColumn("naturezaOperacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_naturezaOperacao = new TFieldString();
        public TFieldString naturezaOperacao
        {
            get { return this.m_naturezaOperacao; }
        }

        [TColumn("dataEntrada", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataEntrada = new TFieldDatetime();
        public TFieldDatetime dataEntrada
        {
            get { return this.m_dataEntrada; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("dataEmissao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataEmissao = new TFieldDatetime();
        public TFieldDatetime dataEmissao
        {
            get { return this.m_dataEmissao; }
        }

        [TColumn("dataVencimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataVencimento = new TFieldDatetime();
        public TFieldDatetime dataVencimento
        {
            get { return this.m_dataVencimento; }
        }

        [TColumn("iss", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_iss = new TFieldDouble();
        public TFieldDouble iss
        {
            get { return this.m_iss; }
        }

        [TColumn("pis", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_pis = new TFieldDouble();
        public TFieldDouble pis
        {
            get { return this.m_pis; }
        }

        [TColumn("cofins", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_cofins = new TFieldDouble();
        public TFieldDouble cofins
        {
            get { return this.m_cofins; }
        }

        [TColumn("icms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_icms = new TFieldDouble();
        public TFieldDouble icms
        {
            get { return this.m_icms; }
        }

        [TColumn("icmsST", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_icmsST = new TFieldDouble();
        public TFieldDouble icmsST
        {
            get { return this.m_icmsST; }
        }

        [TColumn("ir", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ir = new TFieldDouble();
        public TFieldDouble ir
        {
            get { return this.m_ir; }
        }

        [TColumn("ipi", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ipi = new TFieldDouble();
        public TFieldDouble ipi
        {
            get { return this.m_ipi; }
        }

        [TColumn("frete", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_frete = new TFieldDouble();
        public TFieldDouble frete
        {
            get { return this.m_frete; }
        }

        [TColumn("icmsFrete", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_icmsFrete = new TFieldDouble();
        public TFieldDouble icmsFrete
        {
            get { return this.m_icmsFrete; }
        }

        [TColumn("desconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_desconto = new TFieldDouble();
        public TFieldDouble desconto
        {
            get { return this.m_desconto; }
        }

        [TColumn("icmsIncluso", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_icmsIncluso = new TFieldBoolean();
        public TFieldBoolean icmsIncluso
        {
            get { return this.m_icmsIncluso; }
        }

        [TColumn("freteIncluso", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_freteIncluso = new TFieldBoolean();
        public TFieldBoolean freteIncluso
        {
            get { return this.m_freteIncluso; }
        }

        [TColumn("outrasDespesas", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_outrasDespesas = new TFieldDouble();
        public TFieldDouble outrasDespesas
        {
            get { return this.m_outrasDespesas; }
        }

        [TColumn("valorTotal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorTotal = new TFieldDouble();
        public TFieldDouble valorTotal
        {
            get { return this.m_valorTotal; }
        }

        [TColumn("parcelas", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_parcelas = new TFieldInteger();
        public TFieldInteger parcelas
        {
            get { return this.m_parcelas; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [
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
        }

        [
         TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_idDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_idDepartamento == null)
                {
                    this.m_idDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_idDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDepartamento.connectionString = this.connectionString;
                            this.m_idDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDepartamento.selfFill();

                return this.m_idDepartamento;
            }
        }

        [
         TColumn("idCondicaoPagamento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idCondicaoPagamento->idCondicaoPagamento" })
        ]
        private CondicaoPagamento m_idCondicaoPagamento = null;
        public CondicaoPagamento condicaoPagamento
        {
            get
            {
                if (this.m_idCondicaoPagamento == null)
                {
                    this.m_idCondicaoPagamento = new CondicaoPagamento();

                    foreach (TJoin attribute in this.m_idCondicaoPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idCondicaoPagamento.connectionString = this.connectionString;
                            this.m_idCondicaoPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idCondicaoPagamento.selfFill();

                return this.m_idCondicaoPagamento;
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
         TList(typeof(NotaFiscalEEntradaMercadoria)),
         TJoin(new String[] { "idNotaFiscalE->idNotaFiscal" })
        ]
        private Object m_NotaFiscalEEntradaMercadorias = null;
        public System.Collections.Generic.List<NotaFiscalEEntradaMercadoria> notaFiscalEEntradaMercadorias
        {
            get
            {
                if (this.m_NotaFiscalEEntradaMercadorias != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(NotaFiscalEEntradaMercadoria) }
                     ).IsInstanceOfType(this.m_NotaFiscalEEntradaMercadorias)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEEntradaMercadorias)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEEntradaMercadorias).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEEntradaMercadorias).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEEntradaMercadorias)[i]);

                        this.m_NotaFiscalEEntradaMercadorias = em.list(typeof(NotaFiscalEEntradaMercadoria), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<NotaFiscalEEntradaMercadoria>)this.m_NotaFiscalEEntradaMercadorias;
            }
        }

        [
         TList(typeof(NotaFiscalEItem)),
         TJoin(new String[] { "idNotaFiscalE->idNotaFiscal" })
        ]
        private Object m_NotaFiscalEItems = null;
        public System.Collections.Generic.List<NotaFiscalEItem> notaFiscalEItems
        {
            get
            {
                if (this.m_NotaFiscalEItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(NotaFiscalEItem) }
                     ).IsInstanceOfType(this.m_NotaFiscalEItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEItems)[i]);

                        this.m_NotaFiscalEItems = em.list(typeof(NotaFiscalEItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<NotaFiscalEItem>)this.m_NotaFiscalEItems;
            }
        }

        [
         TList(typeof(NotaFiscalEPedidoCompra)),
         TJoin(new String[] { "idNotaFiscalE->idNotaFiscal" })
        ]
        private Object m_NotaFiscalEPedidoCompras = null;
        public System.Collections.Generic.List<NotaFiscalEPedidoCompra> notaFiscalEPedidoCompras
        {
            get
            {
                if (this.m_NotaFiscalEPedidoCompras != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(NotaFiscalEPedidoCompra) }
                     ).IsInstanceOfType(this.m_NotaFiscalEPedidoCompras)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEPedidoCompras)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEPedidoCompras).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEPedidoCompras).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalEPedidoCompras)[i]);

                        this.m_NotaFiscalEPedidoCompras = em.list(typeof(NotaFiscalEPedidoCompra), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<NotaFiscalEPedidoCompra>)this.m_NotaFiscalEPedidoCompras;
            }
        }
    }


}