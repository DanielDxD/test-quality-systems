using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("DocumentoPagamento")]
    public class DocumentoPagamento : TTableBase
    {
        [TColumn("idDocumentoPagamento", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idDocumentoPagamento = new TFieldInteger();
        public TFieldInteger idDocumentoPagamento
        {
            get { return this.m_idDocumentoPagamento; }
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

        [TColumn("serieDocumento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_serieDocumento = new TFieldString();
        public TFieldString serieDocumento
        {
            get { return this.m_serieDocumento; }
        }

        [TColumn("valorPago", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorPago = new TFieldDouble();
        public TFieldDouble valorPago
        {
            get { return this.m_valorPago; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        [TColumn("motivoCancelamento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_motivoCancelamento = new TFieldString();
        public TFieldString motivoCancelamento
        {
            get { return this.m_motivoCancelamento; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataMovimento = new TFieldDatetime();
        public TFieldDatetime dataMovimento
        {
            get { return this.m_dataMovimento; }
        }

        [TColumn("idTipoDocumento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idTipoDocumento = new TFieldInteger();
        public TFieldInteger idTipoDocumento
        {
            get { return this.m_idTipoDocumento; }
        }

        [
         TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private TFieldInteger m_IdContaPagamento2 = new TFieldInteger();
        public TFieldInteger idContaPagamento
        {
            get { return this.m_IdContaPagamento2; }
        }

        [
         TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private ContaPagamento m_IdContaPagamento = null;
        public ContaPagamento contaPagamento
        {
            get
            {
                if (this.m_IdContaPagamento == null)
                {
                    this.m_IdContaPagamento = new ContaPagamento();

                    foreach (TJoin attribute in this.m_IdContaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContaPagamento.connectionString = this.connectionString;
                            this.m_IdContaPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdContaPagamento.selfFill();

                return this.m_IdContaPagamento;
            }
        }

        [
         TList(typeof(DocumentoPagamentoContasAPagar)),
         TJoin(new String[] { "idDocumentoPagamento->idDocumentoPagamento" })
        ]
        private Object m_DocumentoPagamentoContasAPagars = null;
        public System.Collections.Generic.List<DocumentoPagamentoContasAPagar> documentoPagamentoContasAPagars
        {
            get
            {
                if (this.m_DocumentoPagamentoContasAPagars != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(DocumentoPagamentoContasAPagar) }
                     ).IsInstanceOfType(this.m_DocumentoPagamentoContasAPagars)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DocumentoPagamentoContasAPagars)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_DocumentoPagamentoContasAPagars).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_DocumentoPagamentoContasAPagars).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DocumentoPagamentoContasAPagars)[i]);

                        this.m_DocumentoPagamentoContasAPagars = em.list(typeof(DocumentoPagamentoContasAPagar), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<DocumentoPagamentoContasAPagar>)this.m_DocumentoPagamentoContasAPagars;
            }
        }
    }
}