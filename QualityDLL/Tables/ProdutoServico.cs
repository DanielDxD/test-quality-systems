using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ProdutoServico")]
    public class ProdutoServico : TTableBase
    {
        [TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idProdutoServico = new TFieldInteger();
        public TFieldInteger idProdutoServico
        {
            get { return this.m_idProdutoServico; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("cest", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_cest = new TFieldString();
        public TFieldString cest
        {
            get { return this.m_cest; }
        }

        [TColumn("extIpi", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_extIpi = new TFieldString();
        public TFieldString extIpi
        {
            get { return this.m_extIpi; }
        }

        [TColumn("perecivel", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_perecivel = new TFieldBoolean();
        public TFieldBoolean perecivel
        {
            get { return this.m_perecivel; }
        }

        [TColumn("estocavel", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_estocavel = new TFieldBoolean();
        public TFieldBoolean estocavel
        {
            get { return this.m_estocavel; }
        }

        [TColumn("taxaServico", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_taxaServico = new TFieldBoolean();
        public TFieldBoolean taxaServico
        {
            get { return this.m_taxaServico; }
        }

        [
            TColumn("idUnidadeProdutoServico", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idUnidadeProdutoServico->idUnidadeProdutoServico" })
        ]
        private UnidadeProdutoServico m_idUnidadeProdutoServico = null;
        public UnidadeProdutoServico unidadeProdutoServico
        {
            get
            {
                if (this.m_idUnidadeProdutoServico == null)
                {
                    this.m_idUnidadeProdutoServico = new UnidadeProdutoServico();

                    foreach (TJoin attribute in this.m_idUnidadeProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idUnidadeProdutoServico.connectionString = this.connectionString;
                            this.m_idUnidadeProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idUnidadeProdutoServico.selfFill();

                return this.m_idUnidadeProdutoServico;
            }
        }


        [
            TColumn("idNcm", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idNcm->idNcm" })
        ]
        private Ncm m_idNcm = null;
        public Ncm ncm
        {
            get
            {
                if (this.m_idNcm == null)
                {
                    this.m_idNcm = new Ncm();

                    foreach (TJoin attribute in this.m_idNcm.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idNcm.connectionString = this.connectionString;
                            this.m_idNcm.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idNcm.selfFill();

                return this.m_idNcm;
            }
        }

        [TColumn("EAN", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_EAN = new TFieldString();
        public TFieldString EAN
        {
            get { return this.m_EAN; }
        }

        [TColumn("marcaModelo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_marcaModelo = new TFieldString();
        public TFieldString marcaModelo
        {
            get { return this.m_marcaModelo; }
        }

        [
         TColumn("idRegraContabilizacao", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idRegraContabilizacao->idRegraContabilizacao" })
        ]
        private RegraContabilizacao m_idRegraContabilizacao = null;
        public RegraContabilizacao regraContabilizacao
        {
            get
            {
                if (this.m_idRegraContabilizacao == null)
                {
                    this.m_idRegraContabilizacao = new RegraContabilizacao();

                    foreach (TJoin attribute in this.m_idRegraContabilizacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRegraContabilizacao.connectionString = this.connectionString;
                            this.m_idRegraContabilizacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRegraContabilizacao.selfFill();

                return this.m_idRegraContabilizacao;
            }
        }

        [
            TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_idDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_idDepartamento == null)
                {
                    this.m_idDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_idDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDepartamento.connectionString = this.connectionString;
                            this.m_idDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDepartamento.selfFill();

                return this.m_idDepartamento;
            }
        }

        [
         TColumn("idTipoMovimentoContabil", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoMovimentoContabil->idTipoMovimentoContabil" })
        ]
        private TipoMovimentoContabil m_idTipoMovimentoContabil = null;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get
            {
                if (this.m_idTipoMovimentoContabil == null)
                {
                    this.m_idTipoMovimentoContabil = new TipoMovimentoContabil();

                    foreach (TJoin attribute in this.m_idTipoMovimentoContabil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoMovimentoContabil.connectionString = this.connectionString;
                            this.m_idTipoMovimentoContabil.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoMovimentoContabil.selfFill();

                return this.m_idTipoMovimentoContabil;
            }
        }

        [
         TColumn("idPlanoContas", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPlanoContas->idPlanoContas" })
        ]
        private PlanoContas m_idPlanoContas = null;
        public PlanoContas planoContas
        {
            get
            {
                if (this.m_idPlanoContas == null)
                {
                    this.m_idPlanoContas = new PlanoContas();

                    foreach (TJoin attribute in this.m_idPlanoContas.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPlanoContas.connectionString = this.connectionString;
                            this.m_idPlanoContas.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPlanoContas.selfFill();

                return this.m_idPlanoContas;
            }
        }

        [
         TList(typeof(ProdutoServicoEmpresa)),
         TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private Object m_ProdutoServicoEmpresas = null;
        public System.Collections.Generic.List<ProdutoServicoEmpresa> produtoServicoEmpresas
        {
            get
            {
                if (this.m_ProdutoServicoEmpresas != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ProdutoServicoEmpresa) }
                     ).IsInstanceOfType(this.m_ProdutoServicoEmpresas)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEmpresas)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEmpresas).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEmpresas).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEmpresas)[i]);

                        this.m_ProdutoServicoEmpresas = em.list(typeof(ProdutoServicoEmpresa), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ProdutoServicoEmpresa>)this.m_ProdutoServicoEmpresas;
            }
        }

        [
            TList(typeof(ProdutoServicoComposicao)),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private Object m_ProdutoServicoComposicaos = null;
        public System.Collections.Generic.List<ProdutoServicoComposicao> produtoServicoComposicaos
        {
            get
            {
                if (this.m_ProdutoServicoComposicaos != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(ProdutoServicoComposicao) }
                        ).IsInstanceOfType(this.m_ProdutoServicoComposicaos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoComposicaos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoComposicaos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoComposicaos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoComposicaos)[i]);

                        this.m_ProdutoServicoComposicaos = em.list(typeof(ProdutoServicoComposicao), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ProdutoServicoComposicao>)this.m_ProdutoServicoComposicaos;
            }
        }

        [
            TList(typeof(ProdutoServicoEstoque)),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private Object m_ProdutoServicoEstoques = null;
        public System.Collections.Generic.List<ProdutoServicoEstoque> produtoServicoEstoques
        {
            get
            {
                if (this.m_ProdutoServicoEstoques != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(ProdutoServicoEstoque) }
                        ).IsInstanceOfType(this.m_ProdutoServicoEstoques)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEstoques)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEstoques).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEstoques).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoEstoques)[i]);

                        this.m_ProdutoServicoEstoques = em.list(typeof(ProdutoServicoEstoque), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ProdutoServicoEstoque>)this.m_ProdutoServicoEstoques;
            }
        }

        [
            TList(typeof(ProdutoServicoFornecedor)),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private Object m_ProdutoServicoFornecedors = null;
        public System.Collections.Generic.List<ProdutoServicoFornecedor> produtoServicoFornecedors
        {
            get
            {
                if (this.m_ProdutoServicoFornecedors != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(ProdutoServicoFornecedor) }
                        ).IsInstanceOfType(this.m_ProdutoServicoFornecedors)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoFornecedors)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoFornecedors).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoFornecedors).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoFornecedors)[i]);

                        this.m_ProdutoServicoFornecedors = em.list(typeof(ProdutoServicoFornecedor), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ProdutoServicoFornecedor>)this.m_ProdutoServicoFornecedors;
            }
        }

        [
            TList(typeof(ProdutoServicoUnidade)),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private Object m_ProdutoServicoUnidades = null;
        public System.Collections.Generic.List<ProdutoServicoUnidade> produtoServicoUnidades
        {
            get
            {
                if (this.m_ProdutoServicoUnidades != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(ProdutoServicoUnidade) }
                        ).IsInstanceOfType(this.m_ProdutoServicoUnidades)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoUnidades)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoUnidades).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoUnidades).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoUnidades)[i]);

                        this.m_ProdutoServicoUnidades = em.list(typeof(ProdutoServicoUnidade), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ProdutoServicoUnidade>)this.m_ProdutoServicoUnidades;
            }
        }

        [
            TList(typeof(ProdutoServicoPatrimonio)),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private Object m_ProdutoServicoPatrimonio = null;
        public System.Collections.Generic.List<ProdutoServicoPatrimonio> produtoServicoPatrimonio
        {
            get
            {
                if (this.m_ProdutoServicoPatrimonio != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(ProdutoServicoPatrimonio) }
                        ).IsInstanceOfType(this.m_ProdutoServicoPatrimonio)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoPatrimonio)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoPatrimonio).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoPatrimonio).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ProdutoServicoPatrimonio)[i]);

                        this.m_ProdutoServicoPatrimonio = em.list(typeof(ProdutoServicoPatrimonio), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ProdutoServicoPatrimonio>)this.m_ProdutoServicoPatrimonio;
            }
        }
    }
}
