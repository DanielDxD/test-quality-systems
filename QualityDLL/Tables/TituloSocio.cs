using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("TituloSocio")]
    public class TituloSocio : TTableBase
    {
        [TColumn("idTituloSocio", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idTituloSocio = new TFieldInteger();
        public TFieldInteger idTituloSocio
        {
            get { return this.m_idTituloSocio; }
        }

        [TColumn("dataContrato", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataContrato = new TFieldDatetime();
        public TFieldDatetime dataContrato
        {
            get { return this.m_dataContrato; }
        }

        [TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataInicioTitulo = new TFieldDatetime();
        public TFieldDatetime dataInicioTitulo
        {
            get { return this.m_dataInicioTitulo; }
        }

        [TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataFimTitulo = new TFieldDatetime();
        public TFieldDatetime dataFimTitulo
        {
            get { return this.m_dataFimTitulo; }
        }

        [TColumn("dataCadastramento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCadastramento = new TFieldDatetime();
        public TFieldDatetime dataCadastramento
        {
            get { return this.m_dataCadastramento; }
        }

        [TColumn("usuarioCadastramento", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_usuarioCadastramento = new TFieldInteger();
        public TFieldInteger usuarioCadastramento
        {
            get { return this.m_usuarioCadastramento; }
        }

        [TColumn("dataAlteracao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataAlteracao = new TFieldDatetime();
        public TFieldDatetime dataAlteracao
        {
            get { return this.m_dataAlteracao; }
        }

        private TituloSocioSituacao m_situacaoAtual = new TituloSocioSituacao();
        public TituloSocioSituacao situacaoAtual
        {
            get { return this.m_situacaoAtual; }
        }

        [TColumn("usuarioAlteracao", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_usuarioAlteracao = new TFieldInteger();
        public TFieldInteger usuarioAlteracao
        {
            get { return this.m_usuarioAlteracao; }
        }

        [
            TColumn("idTitulo", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idTitulo->idTitulo" })
        ]
        private Titulo m_idTitulo = null;
        public Titulo titulo
        {
            get
            {
                if (this.m_idTitulo == null)
                {
                    this.m_idTitulo = new Titulo();

                    foreach (TJoin attribute in this.m_idTitulo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTitulo.connectionString = this.connectionString;
                            this.m_idTitulo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTitulo.selfFill();

                return this.m_idTitulo;
            }
        }

        [
            TColumn("idEmpresaRelacionamentoTitular", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idEmpresaRelacionamentoTitular->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamentoTitular = null;
        public EmpresaRelacionamento titularEmpresaRelacionamento
        {
            get
            {
                if (this.m_idEmpresaRelacionamentoTitular == null)
                {
                    this.m_idEmpresaRelacionamentoTitular = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamentoTitular.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresaRelacionamentoTitular.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamentoTitular.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamentoTitular.selfFill();

                return this.m_idEmpresaRelacionamentoTitular;
            }
        }

        [
            TColumn("idCategoriaTitulo", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idCategoriaTitulo->idCategoriaTitulo" })
        ]
        private CategoriaTitulo m_idCategoriaTitulo = null;
        public CategoriaTitulo categoriaTitulo
        {
            get
            {
                if (this.m_idCategoriaTitulo == null)
                {
                    this.m_idCategoriaTitulo = new CategoriaTitulo();

                    foreach (TJoin attribute in this.m_idCategoriaTitulo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idCategoriaTitulo.connectionString = this.connectionString;
                            this.m_idCategoriaTitulo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idCategoriaTitulo.selfFill();

                return this.m_idCategoriaTitulo;
            }
        }

        [
            TList(typeof(TituloSocioLancamentoContabil)),
            TJoin(new String[] { "idTituloSocio->idTituloSocio" })
        ]
        private Object m_TituloSocioLancamentoContabils = null;
        public System.Collections.Generic.List<TituloSocioLancamentoContabil> tituloSocioLancamentoContabils
        {
            get
            {
                if (this.m_TituloSocioLancamentoContabils != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(TituloSocioLancamentoContabil) }
                        ).IsInstanceOfType(this.m_TituloSocioLancamentoContabils)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocioLancamentoContabils)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloSocioLancamentoContabils).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloSocioLancamentoContabils).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocioLancamentoContabils)[i]);

                        this.m_TituloSocioLancamentoContabils = em.list(typeof(TituloSocioLancamentoContabil), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<TituloSocioLancamentoContabil>)this.m_TituloSocioLancamentoContabils;
            }
        }

        [
            TList(typeof(TituloSocioSituacao)),
            TJoin(new String[] { "idTituloSocio->idTituloSocio" })
        ]
        private Object m_TituloSocioSituacao = null;
        public System.Collections.Generic.List<TituloSocioSituacao> tituloSocioSituacao
        {
            get
            {
                if (this.m_TituloSocioSituacao != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(TituloSocioSituacao) }
                        ).IsInstanceOfType(this.m_TituloSocioSituacao)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocioSituacao)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloSocioSituacao).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloSocioSituacao).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocioSituacao)[i]);

                        this.m_TituloSocioSituacao = em.list(typeof(TituloSocioSituacao), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<TituloSocioSituacao>)this.m_TituloSocioSituacao;
            }
        }

        [
            TList(typeof(TituloSocioVinculo)),
            TJoin(new String[] { "idTituloSocio->idTituloSocio" })
        ]
        private Object m_TituloSocioVinculo = null;
        public System.Collections.Generic.List<TituloSocioVinculo> tituloSocioVinculo
        {
            get
            {
                if (this.m_TituloSocioVinculo != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(TituloSocioVinculo) }
                        ).IsInstanceOfType(this.m_TituloSocioVinculo)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocioVinculo)[0])).value;
                        
                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloSocioVinculo).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloSocioVinculo).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocioVinculo)[i]);

                        this.m_TituloSocioVinculo = em.list(typeof(TituloSocioVinculo), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<TituloSocioVinculo>)this.m_TituloSocioVinculo;
            }
        }

        [
            TList(typeof(Convite)),
            TJoin(new String[] { "idTituloSocio->idTituloSocio" })
        ]
        private Object m_Convite = null;
        public System.Collections.Generic.List<Convite> convite
        {
            get
            {
                if (this.m_Convite != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(Convite) }
                        ).IsInstanceOfType(this.m_Convite)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Convite)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Convite).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Convite).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Convite)[i]);

                        this.m_Convite = em.list(typeof(Convite), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<Convite>)this.m_Convite;
            }
        }

        [TColumn("agencia", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_agencia = new TFieldString();
        public TFieldString agencia
        {
            get { return this.m_agencia; }
        }

        [TColumn("conta", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_conta = new TFieldString();
        public TFieldString conta
        {
            get { return this.m_conta; }
        }

        [
            TColumn("idBanco", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idBanco->idBanco" })
        ]
        private Banco m_idBanco = null;
        public Banco banco
        {
            get
            {
                if (this.m_idBanco == null)
                {
                    this.m_idBanco = new Banco();

                    foreach (TJoin attribute in this.m_idBanco.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idBanco.connectionString = this.connectionString;
                            this.m_idBanco.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idBanco.selfFill();

                return this.m_idBanco;
            }
        }
    }
}
