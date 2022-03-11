
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContratoTipoItem")]
    public class ContratoTipoItem : TTableBase
    {
        [TColumn("idContratoTipoItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdContratoTipoItem = new TFieldInteger();
        public TFieldInteger idContratoTipoItem
        {
            get { return this.m_IdContratoTipoItem; }
        }

        [TColumn("idContratoTipo", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idContratoTipo->idContratoTipo" })]
        private ContratoTipo m_IdContratoTipo = null;
        public ContratoTipo contratoTipo
        {
            get
            {
                if (this.m_IdContratoTipo == null)
                {
                    this.m_IdContratoTipo = new ContratoTipo();
                    foreach (TJoin attribute in this.m_IdContratoTipo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContratoTipo.connectionString = this.connectionString;
                            this.m_IdContratoTipo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContratoTipo.selfFill();
                return this.m_IdContratoTipo;
            }
        }

        [TColumn("idTipoRelacionamento", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idTipoRelacionamento->idTipoRelacionamento" })]
        private TipoRelacionamento m_IdTipoRelacionamento = null;
        public TipoRelacionamento tipoRelacionamento
        {
            get
            {
                if (this.m_IdTipoRelacionamento == null)
                {
                    this.m_IdTipoRelacionamento = new TipoRelacionamento();
                    foreach (TJoin attribute in this.m_IdTipoRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdTipoRelacionamento.connectionString = this.connectionString;
                            this.m_IdTipoRelacionamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdTipoRelacionamento.selfFill();
                return this.m_IdTipoRelacionamento;
            }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [
            TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
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

        [TColumn("genero", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_Genero = new TFieldString();
        public TFieldString genero
        {
            get { return this.m_Genero; }
        }

        [TColumn("dtAdmissaoInicial", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DtAdmissaoInicial = new TFieldDatetime();
        public TFieldDatetime dtAdmissaoInicial
        {
            get { return this.m_DtAdmissaoInicial; }
        }

        [TColumn("dtAdmissaoFinal", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DtAdmissaoFinal = new TFieldDatetime();
        public TFieldDatetime dtAdmissaoFinal
        {
            get { return this.m_DtAdmissaoFinal; }
        }

        [TColumn("idadeInicial", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdadeInicial = new TFieldInteger();
        public TFieldInteger idadeInicial
        {
            get { return this.m_IdadeInicial; }
        }

        [TColumn("idadeFinal", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdadeFinal = new TFieldInteger();
        public TFieldInteger idadeFinal
        {
            get { return this.m_IdadeFinal; }
        }

        [
        TList(typeof(ContratoTipoItemValor)),
        TJoin(new String[] { "idContratoTipoItem->idContratoTipoItem" })
       ]
        private Object m_ContratoTipoItemValores = null;
        public System.Collections.Generic.List<ContratoTipoItemValor> contratoTipoItemValor
        {
            get
            {
                if (this.m_ContratoTipoItemValores != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContratoTipoItemValor) }
                     ).IsInstanceOfType(this.m_ContratoTipoItemValores)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItemValores)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItemValores).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItemValores).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContratoTipoItemValores)[i]);

                        this.m_ContratoTipoItemValores = em.list(typeof(ContratoTipoItemValor), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContratoTipoItemValor>)this.m_ContratoTipoItemValores;
            }
        }

    }
}
