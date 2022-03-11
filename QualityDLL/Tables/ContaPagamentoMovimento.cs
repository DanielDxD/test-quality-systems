using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContaPagamentoMovimento")]
    public class ContaPagamentoMovimento : TTableBase
    {
        [TColumn("idContaPagamentoMovimento", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContaPagamentoMovimento = new TFieldInteger();
        public TFieldInteger idContaPagamentoMovimento
        {
            get { return this.m_idContaPagamentoMovimento; }
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

        [TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataMovimento = new TFieldDatetime();
        public TFieldDatetime dataMovimento
        {
            get { return this.m_dataMovimento; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("valorMulta", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorMulta = new TFieldDouble();
        public TFieldDouble valorMulta
        {
            get { return this.m_valorMulta; }
        }

        [TColumn("valorJuros", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorJuros = new TFieldDouble();
        public TFieldDouble valorJuros
        {
            get { return this.m_valorJuros; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [TColumn("valorCM", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorCM = new TFieldDouble();
        public TFieldDouble valorCM
        {
            get { return this.m_valorCM; }
        }

        [TColumn("valorINSSRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorINSSRetido = new TFieldDouble();
        public TFieldDouble valorINSSRetido
        {
            get { return this.m_valorINSSRetido; }
        }

        [TColumn("valorISSRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorISSRetido = new TFieldDouble();
        public TFieldDouble valorISSRetido
        {
            get { return this.m_valorISSRetido; }
        }

        [TColumn("valorIRRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorIRRetido = new TFieldDouble();
        public TFieldDouble valorIRRetido
        {
            get { return this.m_valorIRRetido; }
        }

        [TColumn("valorPISRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorPISRetido = new TFieldDouble();
        public TFieldDouble valorPISRetido
        {
            get { return this.m_valorPISRetido; }
        }

        [TColumn("valorCOFINSRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorCOFINSRetido = new TFieldDouble();
        public TFieldDouble valorCOFINSRetido
        {
            get { return this.m_valorCOFINSRetido; }
        }

        [TColumn("valorCSLLRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorCSLLRetido = new TFieldDouble();
        public TFieldDouble valorCSLLRetido
        {
            get { return this.m_valorCSLLRetido; }
        }

        [TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idContaPagamento = new TFieldInteger();
        public TFieldInteger idContaPagamento
        {
            get {return this.m_idContaPagamento;}
        }

        [TColumn("dataConciliacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataConciliacao = new TFieldDatetime();
        public TFieldDatetime dataConciliacao
        {
            get { return this.m_dataConciliacao; }
        }

        [
         TColumn("idDocumentoPagamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDocumentoPagamento->idDocumentoPagamento" })
        ]
        private DocumentoPagamento m_idDocumentoPagamento = null;
        public DocumentoPagamento documentoPagamento
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
         TColumn("idDocumentoRecebimento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDocumentoRecebimento->idDocumentoRecebimento" })
        ]
        private DocumentoRecebimento m_idDocumentoRecebimento = null;
        public DocumentoRecebimento documentoRecebimento
        {
            get
            {
                if (this.m_idDocumentoRecebimento == null)
                {
                    this.m_idDocumentoRecebimento = new DocumentoRecebimento();

                    foreach (TJoin attribute in this.m_idDocumentoRecebimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDocumentoRecebimento.connectionString = this.connectionString;
                            this.m_idDocumentoRecebimento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDocumentoRecebimento.selfFill();

                return this.m_idDocumentoRecebimento;
            }
        }

        [
         TColumn("idDocumentoTransferenciaEntrada", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDocumentoTransferenciaEntrada->idDocumentoTransferenciaEntrada" })
        ]
        private DocumentoTransferencia m_idDocumentoTransferenciaEntrada = null;
        public DocumentoTransferencia documentoTransferenciaEntrada
        {
            get
            {
                if (this.m_idDocumentoTransferenciaEntrada == null)
                {
                    this.m_idDocumentoTransferenciaEntrada = new DocumentoTransferencia();

                    foreach (TJoin attribute in this.m_idDocumentoTransferenciaEntrada.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDocumentoTransferenciaEntrada.connectionString = this.connectionString;
                            this.m_idDocumentoTransferenciaEntrada.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDocumentoTransferenciaEntrada.selfFill();

                return this.m_idDocumentoTransferenciaEntrada;
            }
        }

        [
         TColumn("idDocumentoTransferenciaSaida", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDocumentoTransferenciaSaida->idDocumentoTransferenciaSaida" })
        ]
        private DocumentoTransferencia m_idDocumentoTransferenciaSaida = null;
        public DocumentoTransferencia documentoTransferenciaSaida
        {
            get
            {
                if (this.m_idDocumentoTransferenciaSaida == null)
                {
                    this.m_idDocumentoTransferenciaSaida = new DocumentoTransferencia();

                    foreach (TJoin attribute in this.m_idDocumentoTransferenciaSaida.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDocumentoTransferenciaSaida.connectionString = this.connectionString;
                            this.m_idDocumentoTransferenciaSaida.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDocumentoTransferenciaSaida.selfFill();

                return this.m_idDocumentoTransferenciaSaida;
            }
        }

        [TColumn("idDocumentoTransferenciaItem", System.Data.SqlDbType.BigInt, false, false),]
        private TFieldInteger m_idDocumentoTransferenciaItem = new TFieldInteger();
        public TFieldInteger idDocumentoTransferenciaItem
        {
            get { return this.m_idDocumentoTransferenciaItem; }
        }
    }
}
