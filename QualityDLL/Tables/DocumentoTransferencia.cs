using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("DocumentoTransferencia")]
    public class DocumentoTransferencia : TTableBase
    {
        [TColumn("idDocumentoTransferencia", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idDocumentoTransferencia = new TFieldInteger();
        public TFieldInteger idDocumentoTransferencia
        {
            get { return this.m_idDocumentoTransferencia; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("dataGeracao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataGeracao = new TFieldDatetime();
        public TFieldDatetime dataGeracao
        {
            get { return this.m_dataGeracao; }
        }

        [TColumn("numeroDocumento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroDocumento = new TFieldString();
        public TFieldString numeroDocumento
        {
            get { return this.m_numeroDocumento; }
        }

        [TColumn("valorTransferido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorTransferido = new TFieldDouble();
        public TFieldDouble valorTransferido
        {
            get { return this.m_valorTransferido; }
        }

        [TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataMovimento = new TFieldDatetime();
        public TFieldDatetime dataMovimento
        {
            get { return this.m_dataMovimento; }
        }

        [
         TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idEmpresa->idEmpresa" })
        ]
        private Empresa m_idEmpresa = null;
        public Empresa idEmpresa
        {
            get
            {
                if (this.m_idEmpresa == null)
                {
                    this.m_idEmpresa = new Empresa();

                    foreach (TJoin attribute in this.m_idEmpresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresa.connectionString = this.connectionString;
                            this.m_idEmpresa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresa.selfFill();

                return this.m_idEmpresa;
            }
        }

        [
         TColumn("idContaPagamentoOrigem", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idContaPagamentoOrigem->idContaPagamento" })
        ]
        private ContaPagamento m_idContaPagamentoOrigem = null;
        public ContaPagamento idContaPagamentoOrigem
        {
            get
            {
                if (this.m_idContaPagamentoOrigem == null)
                {
                    this.m_idContaPagamentoOrigem = new ContaPagamento();

                    foreach (TJoin attribute in this.m_idContaPagamentoOrigem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContaPagamentoOrigem.connectionString = this.connectionString;
                            this.m_idContaPagamentoOrigem.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContaPagamentoOrigem.selfFill();

                return this.m_idContaPagamentoOrigem;
            }
        }

        [
         TColumn("idContaPagamentoDestino", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idContaPagamentoDestino->idContaPagamento" })
        ]
        private ContaPagamento m_idContaPagamentoDestino = null;
        public ContaPagamento idContaPagamentoDestino
        {
            get
            {
                if (this.m_idContaPagamentoDestino == null)
                {
                    this.m_idContaPagamentoDestino = new ContaPagamento();

                    foreach (TJoin attribute in this.m_idContaPagamentoDestino.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContaPagamentoDestino.connectionString = this.connectionString;
                            this.m_idContaPagamentoDestino.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContaPagamentoDestino.selfFill();

                return this.m_idContaPagamentoDestino;
            }
        }

        [
         TList(typeof(DocumentoTransferenciaItem)),
         TJoin(new String[] { "idDocumentoTransferencia->idDocumentoTransferencia" })
        ]
        private Object m_DocumentoTransferenciaItems = null;
        public System.Collections.Generic.List<DocumentoTransferenciaItem> documentoTransferenciaItems
        {
            get
            {
                if (this.m_DocumentoTransferenciaItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(DocumentoTransferenciaItem) }
                     ).IsInstanceOfType(this.m_DocumentoTransferenciaItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DocumentoTransferenciaItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_DocumentoTransferenciaItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_DocumentoTransferenciaItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DocumentoTransferenciaItems)[i]);

                        this.m_DocumentoTransferenciaItems = em.list(typeof(DocumentoTransferenciaItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<DocumentoTransferenciaItem>)this.m_DocumentoTransferenciaItems;
            }
        }
    }
}
