using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContaPagamentoCheque")]
    public class ContaPagamentoCheque : TTableBase
    {
        [TColumn("idContaPagamentoCheque", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idContaPagamentoCheque = new TFieldInteger();
        public TFieldInteger idContaPagamentoCheque
        {
            get { return this.m_idContaPagamentoCheque; }
        }

        [TColumn("numero", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_numero = new TFieldInteger();
        public TFieldInteger numero
        {
            get { return this.m_numero; }
        }

        [TColumn("dataEmissao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataEmissao = new TFieldDatetime();
        public TFieldDatetime dataEmissao
        {
            get { return this.m_dataEmissao; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("valorExtenso", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_valorExtenso = new TFieldString();
        public TFieldString valorExtenso
        {
            get { return this.m_valorExtenso; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        [
         TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private ContaPagamento m_idContaPagamento = null;
        public ContaPagamento idContaPagamento
        {
            get
            {
                if (this.m_idContaPagamento == null)
                {
                    this.m_idContaPagamento = new ContaPagamento();

                    foreach (TJoin attribute in this.m_idContaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContaPagamento.connectionString = this.connectionString;
                            this.m_idContaPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContaPagamento.selfFill();

                return this.m_idContaPagamento;
            }
        }

        [
         TColumn("idDocumentoPagamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDocumentoPagamento->idDocumentoPagamento" })
        ]
        private DocumentoPagamento m_idDocumentoPagamento = null;
        public DocumentoPagamento idDocumentoPagamento
        {
            get
            {
                if (this.m_idDocumentoPagamento == null)
                {
                    this.m_idDocumentoPagamento = new DocumentoPagamento();

                    foreach (TJoin attribute in this.m_idDocumentoPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDocumentoPagamento.connectionString = this.connectionString;
                            this.m_idDocumentoPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDocumentoPagamento.selfFill();

                return this.m_idDocumentoPagamento;
            }
        }

        [
         TColumn("idDocumentoTransferencia", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDocumentoTransferencia->idDocumentoTransferencia" })
        ]
        private DocumentoTransferencia m_idDocumentoTransferencia = null;
        public DocumentoTransferencia idDocumentoTransferencia
        {
            get
            {
                if (this.m_idDocumentoTransferencia == null)
                {
                    this.m_idDocumentoTransferencia = new DocumentoTransferencia();

                    foreach (TJoin attribute in this.m_idDocumentoTransferencia.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDocumentoTransferencia.connectionString = this.connectionString;
                            this.m_idDocumentoTransferencia.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDocumentoTransferencia.selfFill();

                return this.m_idDocumentoTransferencia;
            }
        }
    }
}
