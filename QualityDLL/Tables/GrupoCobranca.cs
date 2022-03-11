
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("GrupoCobranca")]
    public class GrupoCobranca : TTableBase
    {
        [TColumn("idGrupoCobranca", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdGrupoCobranca = new TFieldInteger();
        public TFieldInteger idGrupoCobranca
        {
            get { return this.m_IdGrupoCobranca; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("idParametroBoleto", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idParametroBoleto->idParametroBoleto" })]
        private ParametroBoleto m_IdParametroBoleto = null;
        public ParametroBoleto parametroBoleto
        {
            get
            {
                if (this.m_IdParametroBoleto == null)
                {
                    this.m_IdParametroBoleto = new ParametroBoleto();
                    foreach (TJoin attribute in this.m_IdParametroBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdParametroBoleto.connectionString = this.connectionString;
                            this.m_IdParametroBoleto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdParametroBoleto.selfFill();
                return this.m_IdParametroBoleto;
            }
        }


        [TColumn("idParametroAcrescimo", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idParametroAcrescimo->idParametroAcrescimo" })]
        private ParametroAcrescimo m_IdParametroAcrescimo = null;
        public ParametroAcrescimo parametroAcrescimo
        {
            get
            {
                if (this.m_IdParametroAcrescimo == null)
                {
                    this.m_IdParametroAcrescimo = new ParametroAcrescimo();
                    foreach (TJoin attribute in this.m_IdParametroAcrescimo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdParametroAcrescimo.connectionString = this.connectionString;
                            this.m_IdParametroAcrescimo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdParametroAcrescimo.selfFill();
                return this.m_IdParametroAcrescimo;
            }
        }

        [TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataInicio = new TFieldDatetime();
        public TFieldDatetime dataInicio
        {
            get { return this.m_DataInicio; }
        }

        [TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataFim = new TFieldDatetime();
        public TFieldDatetime dataFim
        {
            get { return this.m_DataFim; }
        }

        [TColumn("diaCobranca", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_DiaCobranca = new TFieldInteger();
        public TFieldInteger diaCobranca
        {
            get { return this.m_DiaCobranca; }
        }

        [TColumn("agruparDebitosTitulo", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_agruparDebitosTitulo = new TFieldBoolean();
        public TFieldBoolean agruparDebitosTitulo
        {
            get { return this.m_agruparDebitosTitulo; }
        }

        [TColumn("dataInicioAgrupamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataInicioAgrupamento = new TFieldDatetime();
        public TFieldDatetime dataInicioAgrupamento
        {
            get { return this.m_DataInicioAgrupamento; }
        }

        [
         TList(typeof(GrupoCobrancaItem)),
         TJoin(new String[] { "idGrupoCobranca->idGrupoCobranca" })
        ]
        private Object m_GrupoCobrancaItem = null;
        public System.Collections.Generic.List<GrupoCobrancaItem> grupoCobrancaItems
        {
            get
            {
                if (this.m_GrupoCobrancaItem != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(GrupoCobrancaItem) }
                     ).IsInstanceOfType(this.m_GrupoCobrancaItem)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_GrupoCobrancaItem)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_GrupoCobrancaItem).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_GrupoCobrancaItem).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_GrupoCobrancaItem)[i]);

                        this.m_GrupoCobrancaItem = em.list(typeof(GrupoCobrancaItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<GrupoCobrancaItem>)this.m_GrupoCobrancaItem;
            }
        }

    }
}
