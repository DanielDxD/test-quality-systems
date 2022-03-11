using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("RelatorioBandas")]
    public class RelatorioBandas : TTableBase
    {
        [TColumn("idRelatorioBanda", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idRelatorioBanda = new TFieldInteger();
        public TFieldInteger idRelatorioBanda
        {
            get { return this.m_idRelatorioBanda; }
        }

        [TColumn("nome", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nome = new TFieldString();
        public TFieldString nome
        {
            get { return this.m_nome; }
        }

        [TColumn("tipo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipo = new TFieldString();
        public TFieldString tipo
        {
            get { return this.m_tipo; }
        }

        [TColumn("largura", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_largura = new TFieldInteger();
        public TFieldInteger largura
        {
            get { return this.m_largura; }
        }

        [TColumn("altura", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_altura = new TFieldInteger();
        public TFieldInteger altura
        {
            get { return this.m_altura; }
        }

        [TColumn("novaPagina", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_novaPagina = new TFieldString();
        public TFieldString novaPagina
        {
            get { return this.m_novaPagina; }
        }

        [
         TColumn("idRelatorio", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idRelatorio->idRelatorio" })
        ]
        private Relatorios m_idRelatorio = null;
        public Relatorios idRelatorio
        {
            get
            {
                if (this.m_idRelatorio == null)
                {
                    this.m_idRelatorio = new Relatorios();

                    foreach (TJoin attribute in this.m_idRelatorio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRelatorio.connectionString = this.connectionString;
                            this.m_idRelatorio.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRelatorio.selfFill();

                return this.m_idRelatorio;
            }
        }

        [
         TColumn("idRelatorioBandaPai", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idRelatorioBandaPai->idRelatorioBanda" })
        ]
        private RelatorioBandas m_idRelatorioBandaPai = null;
        public RelatorioBandas idRelatorioBandaPai
        {
            get
            {
                if (this.m_idRelatorioBandaPai == null)
                {
                    this.m_idRelatorioBandaPai = new RelatorioBandas();

                    foreach (TJoin attribute in this.m_idRelatorioBandaPai.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRelatorioBandaPai.connectionString = this.connectionString;
                            this.m_idRelatorioBandaPai.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRelatorioBandaPai.selfFill();

                return this.m_idRelatorioBandaPai;
            }
        }

        [
         TList(typeof(RelatorioBandas)),
         TJoin(new String[] { "idRelatorioBanda->idRelatorioBandaPai" })
        ]
        private Object m_RelatorioBandass = null;
        public System.Collections.Generic.List<RelatorioBandas> relatorioBandass
        {
            get
            {
                if (this.m_RelatorioBandass != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(RelatorioBandas) }
                     ).IsInstanceOfType(this.m_RelatorioBandass)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass)[i]);

                        this.m_RelatorioBandass = em.list(typeof(RelatorioBandas), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<RelatorioBandas>)this.m_RelatorioBandass;
            }
        }

        [
         TList(typeof(RelatorioCampos)),
         TJoin(new String[] { "idRelatorioBanda->idRelatorioBanda" })
        ]
        private Object m_RelatorioCamposs = null;
        public System.Collections.Generic.List<RelatorioCampos> relatorioCamposs
        {
            get
            {
                if (this.m_RelatorioCamposs != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(RelatorioCampos) }
                     ).IsInstanceOfType(this.m_RelatorioCamposs)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioCamposs)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RelatorioCamposs).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RelatorioCamposs).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioCamposs)[i]);

                        this.m_RelatorioCamposs = em.list(typeof(RelatorioCampos), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<RelatorioCampos>)this.m_RelatorioCamposs;
            }
        }
        
        [TColumn("imagemFundo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_imagemFundo = new TFieldString();
        public TFieldString imagemFundo
        {
            get { return this.m_imagemFundo; }
        }
    }
}
