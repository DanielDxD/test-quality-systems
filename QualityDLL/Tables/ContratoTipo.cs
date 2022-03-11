
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContratoTipo")]
    public class ContratoTipo : TTableBase
    {
        [TColumn("idContratoTipo", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdContratoTipo = new TFieldInteger();
        public TFieldInteger idContratoTipo
        {
            get { return this.m_IdContratoTipo; }
        }

        [
            TColumn("idContratoTipoRecorrencia", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idContratoTipoRecorrencia->idContratoTipoRecorrencia" })
        ]
        private ContratoTipoRecorrencia m_IdContratoTipoRecorrencia = null;
        public ContratoTipoRecorrencia contratoTipoRecorrencia
        {
            get
            {
                if (this.m_IdContratoTipoRecorrencia == null)
                {
                    this.m_IdContratoTipoRecorrencia = new ContratoTipoRecorrencia();
                    foreach (TJoin attribute in this.m_IdContratoTipoRecorrencia.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContratoTipoRecorrencia.connectionString = this.connectionString;
                            this.m_IdContratoTipoRecorrencia.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContratoTipoRecorrencia.selfFill();
                return this.m_IdContratoTipoRecorrencia;
            }
        }

        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idNaturezaOperacao->idNaturezaOperacao" })]
        private NaturezaOperacao m_IdNaturezaOperacao = null;
        public NaturezaOperacao naturezaOperacao
        {
            get
            {
                if (this.m_IdNaturezaOperacao == null)
                {
                    this.m_IdNaturezaOperacao = new NaturezaOperacao();
                    foreach (TJoin attribute in this.m_IdNaturezaOperacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdNaturezaOperacao.connectionString = this.connectionString;
                            this.m_IdNaturezaOperacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdNaturezaOperacao.selfFill();
                return this.m_IdNaturezaOperacao;
            }
        }

        [TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idDepartamento->idDepartamento" })]
        private Departamento m_IdDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_IdDepartamento == null)
                {
                    this.m_IdDepartamento = new Departamento();
                    foreach (TJoin attribute in this.m_IdDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdDepartamento.connectionString = this.connectionString;
                            this.m_IdDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdDepartamento.selfFill();
                return this.m_IdDepartamento;
            }
        }

        [TColumn("idCategoriaTitulo", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idCategoriaTitulo->idCategoriaTitulo" })]
        private CategoriaTitulo m_IdCategoriaTitulo = null;
        public CategoriaTitulo categoriaTitulo
        {
            get
            {
                if (this.m_IdCategoriaTitulo == null)
                {
                    this.m_IdCategoriaTitulo = new CategoriaTitulo();
                    foreach (TJoin attribute in this.m_IdCategoriaTitulo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCategoriaTitulo.connectionString = this.connectionString;
                            this.m_IdCategoriaTitulo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCategoriaTitulo.selfFill();
                return this.m_IdCategoriaTitulo;
            }
        }

        [TColumn("diaVencimento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_DiaVencimento = new TFieldInteger();
        public TFieldInteger diaVencimento
        {
            get { return this.m_DiaVencimento; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("valorBase", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorBase = new TFieldDouble();
        public TFieldDouble valorBase
        {
            get { return this.m_ValorBase; }
        }

        [
        TList(typeof(ContratoTipoItem)),
        TJoin(new String[] { "idContratoTipo->idContratoTipo" })
       ]
        private Object m_ContratoTipoItems = null;
        public System.Collections.Generic.List<ContratoTipoItem> contratoTipoItem
        {
            get
            {
                if (this.m_ContratoTipoItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContratoTipoItem) }
                     ).IsInstanceOfType(this.m_ContratoTipoItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItems)[i]);

                        this.m_ContratoTipoItems = em.list(typeof(ContratoTipoItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContratoTipoItem>)this.m_ContratoTipoItems;
            }
        }

    }
}
