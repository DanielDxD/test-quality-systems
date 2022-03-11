using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvCompraCupom")]
    public class PdvCompraCupom : TTableBase
    {
        [TColumn("idPdvCompraCupom", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvCompraCupom = new TFieldInteger();
        public TFieldInteger idPdvCompraCupom
        {
            get { return this.m_idPdvCompraCupom; }
        }

        [
            TColumn("idPdvCompra", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private PdvCompra m_pdvCompra = null;
        public PdvCompra pdvCompra
        {
            get
            {
                if (this.m_pdvCompra == null)
                {
                    this.m_pdvCompra = new PdvCompra();

                    foreach (TJoin attribute in this.m_pdvCompra.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvCompra.connectionString = this.connectionString;
                            this.m_pdvCompra.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvCompra.selfFill();
                return this.m_pdvCompra;
            }
        }

        [TColumn("data", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_data = new TFieldDatetime();
        public TFieldDatetime data
        {
            get { return this.m_data; }
        }

        [TColumn("sequenciaCupom", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_sequenciaCupom = new TFieldInteger();
        public TFieldInteger sequenciaCupom
        {
            get { return this.m_sequenciaCupom; }
        }


        [TColumn("impresso", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_impresso = new TFieldBoolean();
        public TFieldBoolean impresso
        {
            get { return this.m_impresso; }
        }

        [TColumn("statusCupom", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_statusCupom = new TFieldString();
        public TFieldString statusCupom
        {
            get { return this.m_statusCupom; }
        }

        [
            TColumn("idRequisicaoInterna", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idRequisicaoInterna->idRequisicaoInterna" })
        ]
        private RequisicaoInterna m_idRequisicaoInterna = null;
        public RequisicaoInterna requisicaoInterna
        {
            get
            {
                if (this.m_idRequisicaoInterna == null)
                {
                    this.m_idRequisicaoInterna = new RequisicaoInterna();

                    foreach (TJoin attribute in this.m_idRequisicaoInterna.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRequisicaoInterna.connectionString = this.connectionString;
                            this.m_idRequisicaoInterna.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRequisicaoInterna.selfFill();
                return this.m_idRequisicaoInterna;
            }
        }

        [
            TList(typeof(PdvCompraCupomItem)),
            TJoin(new String[] { "idPdvCompraCupom->idPdvCompraCupom" })
        ]
        private Object m_PdvCompraCupomItem = null;
        public System.Collections.Generic.List<PdvCompraCupomItem> pdvCompraCupomItem
        {
            get
            {
                if (this.m_PdvCompraCupomItem != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvCompraCupomItem) }
                     ).IsInstanceOfType(this.m_PdvCompraCupomItem)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupomItem)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupomItem).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupomItem).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupomItem)[i]);

                        this.m_PdvCompraCupomItem = em.list(typeof(PdvCompraCupomItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvCompraCupomItem>)this.m_PdvCompraCupomItem;
            }
        }

        [
            TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idFuncionario->idFuncionario" })
        ]
        private Funcionario m_idFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_idFuncionario == null)
                {
                    this.m_idFuncionario = new Funcionario();

                    foreach (TJoin attribute in this.m_idFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idFuncionario.connectionString = this.connectionString;
                            this.m_idFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idFuncionario.selfFill();
                return this.m_idFuncionario;
            }
        }

        [
             TColumn("idPos", System.Data.SqlDbType.BigInt, false, false),
             TJoin(new String[] { "idPos->idPos" })
         ]
        private Pos m_idPos = null;
        public Pos pos
        {
            get
            {
                if (this.m_idPos == null)
                {
                    this.m_idPos = new Pos();

                    foreach (TJoin attribute in this.m_idPos.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPos.connectionString = this.connectionString;
                            this.m_idPos.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPos.selfFill();
                return this.m_idPos;
            }
        }

    }
}
