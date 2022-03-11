using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("DocumentoRecebimento")]
    public class DocumentoRecebimento : TTableBase
    {
        [TColumn("idDocumentoRecebimento", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idDocumentoRecebimento = new TFieldInteger();
        public TFieldInteger idDocumentoRecebimento
        {
            get { return this.m_idDocumentoRecebimento; }
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

        [TColumn("valorRecebido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorRecebido = new TFieldDouble();
        public TFieldDouble valorRecebido
        {
            get { return this.m_valorRecebido; }
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

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
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
         TList(typeof(ContaPagamentoMovimento)),
         TJoin(new String[] { "idDocumentoRecebimento->idDocumentoRecebimento" })
        ]
        private Object m_ContaPagamentoMovimentos = null;
        public System.Collections.Generic.List<ContaPagamentoMovimento> contaPagamentoMovimentos
        {
            get
            {
                if (this.m_ContaPagamentoMovimentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContaPagamentoMovimento) }
                     ).IsInstanceOfType(this.m_ContaPagamentoMovimentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoMovimentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoMovimentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoMovimentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContaPagamentoMovimentos)[i]);

                        this.m_ContaPagamentoMovimentos = em.list(typeof(ContaPagamentoMovimento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContaPagamentoMovimento>)this.m_ContaPagamentoMovimentos;
            }
        }

        [
         TList(typeof(DocumentoRecebimentoContasAReceber)),
         TJoin(new String[] { "idDocumentoRecebimento->idDocumentoRecebimento" })
        ]
        private Object m_DocumentoRecebimentoContasARecebers = null;
        public System.Collections.Generic.List<DocumentoRecebimentoContasAReceber> documentoRecebimentoContasARecebers
        {
            get
            {
                if (this.m_DocumentoRecebimentoContasARecebers != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(DocumentoRecebimentoContasAReceber) }
                     ).IsInstanceOfType(this.m_DocumentoRecebimentoContasARecebers)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DocumentoRecebimentoContasARecebers)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_DocumentoRecebimentoContasARecebers).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_DocumentoRecebimentoContasARecebers).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DocumentoRecebimentoContasARecebers)[i]);

                        this.m_DocumentoRecebimentoContasARecebers = em.list(typeof(DocumentoRecebimentoContasAReceber), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<DocumentoRecebimentoContasAReceber>)this.m_DocumentoRecebimentoContasARecebers;
            }
        }
    }
}
