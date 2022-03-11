using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("MovimentoManual")]
    public class MovimentoManual : TTableBase
    {
        [TColumn("idMovimentoManual", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idMovimentoManual = new TFieldInteger();
        public TFieldInteger idMovimentoManual
        {
            get { return this.m_idMovimentoManual; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
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

        [TColumn("ocorrencias", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_ocorrencias = new TFieldInteger();
        public TFieldInteger ocorrencias
        {
            get { return this.m_ocorrencias; }
        }

        [TColumn("pagarReceber", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_pagarReceber = new TFieldString();
        public TFieldString pagarReceber
        {
            get { return this.m_pagarReceber; }
        }

        [
         TColumn("idPessoa", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPessoa->idPessoa" })
        ]
        private Pessoa m_idPessoa = null;
        public Pessoa idPessoa
        {
            get
            {
                this.m_idPessoa = new Pessoa();

                if (this.m_idPessoa == null)
                {
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
        [
         TList(typeof(ContasAPagarItem)),
         TJoin(new String[] { "idMovimentoManual->idMovimentoManual" })
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
         TList(typeof(ContasAReceberItem)),
         TJoin(new String[] { "idMovimentoManual->idMovimentoManual" })
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
         TList(typeof(MovimentoManualItem)),
         TJoin(new String[] { "idMovimentoManual->idMovimentoManual" })
        ]
        private Object m_MovimentoManualItems = null;
        public System.Collections.Generic.List<MovimentoManualItem> movimentoManualItems
        {
            get
            {
                if (this.m_MovimentoManualItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(MovimentoManualItem) }
                     ).IsInstanceOfType(this.m_MovimentoManualItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_MovimentoManualItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_MovimentoManualItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_MovimentoManualItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_MovimentoManualItems)[i]);

                        this.m_MovimentoManualItems = em.list(typeof(MovimentoManualItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<MovimentoManualItem>)this.m_MovimentoManualItems;
            }
        }
    }
}