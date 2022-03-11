using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvEstacoes")]
    public class PdvEstacao : TTableBase
    {
        [TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvEstacao = new TFieldInteger();
        public TFieldInteger idPdvEstacao
        {
            get { return this.m_idPdvEstacao; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("confirmacaoGerente", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_confirmacaoGerente = new TFieldBoolean();
        public TFieldBoolean confirmacaoGerente
        {
            get { return this.m_confirmacaoGerente; }
        }

        [TColumn("habilitarNotaPromissoria", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_habilitarNotaPromissoria = new TFieldBoolean();
        public TFieldBoolean habilitarNotaPromissoria
        {
            get { return this.m_habilitarNotaPromissoria; }
        }

        [TColumn("habilitarDescontoTotal", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_habilitarDescontoTotal = new TFieldBoolean();
        public TFieldBoolean habilitarDescontoTotal
        {
            get { return this.m_habilitarDescontoTotal; }
        }

        [TColumn("habilitarPrePago", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_habilitarPrePago = new TFieldBoolean();
        public TFieldBoolean habilitarPrePago
        {
            get { return this.m_habilitarPrePago; }
        }

        [TColumn("agruparProdutosCupom", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_agruparProdutosCupom = new TFieldBoolean();
        public TFieldBoolean agruparProdutosCupom
        {
            get { return this.m_agruparProdutosCupom; }
        }

        [TColumn("idContaPagamentoDesconto", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idContaPagamentoDescontol = new TFieldInteger();
        public TFieldInteger idContaPagamentoDesconto
        {
            get { return this.m_idContaPagamentoDescontol; }
        }

        [TColumn("pos", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_pos = new TFieldBoolean();
        public TFieldBoolean pos
        {
            get { return this.m_pos; }
        }

        private bool m_aberto;
        public bool aberto
        {
            get { return this.m_aberto; }
        }

        [TColumn("aplicarTaxaServico", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aplicarTaxaServico = new TFieldDouble();
        public TFieldDouble aplicarTaxaServico
        {
            get { return this.m_aplicarTaxaServico; }
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

        [
            TColumn("idAparelhoSat", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idAparelhoSat->idAparelhoSat" })
        ]
        private AparelhoSat m_IdAparelhoSat = null;
        public AparelhoSat aparelhoSat
        {
            get
            {
                if (this.m_IdAparelhoSat == null)
                {
                    this.m_IdAparelhoSat = new AparelhoSat();

                    foreach (TJoin attribute in this.m_IdAparelhoSat.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdAparelhoSat.connectionString = this.connectionString;
                            this.m_IdAparelhoSat.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdAparelhoSat.selfFill();

                return this.m_IdAparelhoSat;
            }
        }

        [
            TColumn("prePagoDepartamento", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "prePagoDepartamento->idDepartamento" })
        ]
        private Departamento m_IdPrePagoDepartamento = null;
        public Departamento prePagoDepartamento
        {
            get
            {
                if (this.m_IdPrePagoDepartamento == null)
                {
                    this.m_IdPrePagoDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_IdPrePagoDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPrePagoDepartamento.connectionString = this.connectionString;
                            this.m_IdPrePagoDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdPrePagoDepartamento.selfFill();

                return this.m_IdPrePagoDepartamento;
            }
        }

        [
            TColumn("posPagoNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "posPagoNaturezaOperacao->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_IdPosPagoNaturezaOperacao = null;
        public NaturezaOperacao posPagoNaturezaOperacao
        {
            get
            {
                if (this.m_IdPosPagoNaturezaOperacao == null)
                {
                    this.m_IdPosPagoNaturezaOperacao = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_IdPosPagoNaturezaOperacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPosPagoNaturezaOperacao.connectionString = this.connectionString;
                            this.m_IdPosPagoNaturezaOperacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdPosPagoNaturezaOperacao.selfFill();

                return this.m_IdPosPagoNaturezaOperacao;
            }
        }

        [
            TColumn("prePagoNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "prePagoNaturezaOperacao->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_IdPrePagoNaturezaOperacao = null;
        public NaturezaOperacao prePagoNaturezaOperacao
        {
            get
            {
                if (this.m_IdPrePagoNaturezaOperacao == null)
                {
                    this.m_IdPrePagoNaturezaOperacao = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_IdPrePagoNaturezaOperacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPrePagoNaturezaOperacao.connectionString = this.connectionString;
                            this.m_IdPrePagoNaturezaOperacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdPrePagoNaturezaOperacao.selfFill();

                return this.m_IdPrePagoNaturezaOperacao;
            }
        }

        [
            TColumn("prePagoNaturezaOperacaoEstorno", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "prePagoNaturezaOperacaoEstorno->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_IdPrePagoNaturezaOperacaoEstorno = null;
        public NaturezaOperacao prePagoNaturezaOperacaoEstorno
        {
            get
            {
                if (this.m_IdPrePagoNaturezaOperacaoEstorno == null)
                {
                    this.m_IdPrePagoNaturezaOperacaoEstorno = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_IdPrePagoNaturezaOperacaoEstorno.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPrePagoNaturezaOperacaoEstorno.connectionString = this.connectionString;
                            this.m_IdPrePagoNaturezaOperacaoEstorno.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdPrePagoNaturezaOperacaoEstorno.selfFill();

                return this.m_IdPrePagoNaturezaOperacaoEstorno;
            }
        }

        [
            TColumn("idDepartamentoOrigem", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idDepartamentoOrigem->idDepartamento" })
        ]
        private Departamento m_IdDepartamentoOrigem = null;
        public Departamento departamentoOrigem
        {
            get
            {
                if (this.m_IdDepartamentoOrigem == null)
                {
                    this.m_IdDepartamentoOrigem = new Departamento();

                    foreach (TJoin attribute in this.m_IdDepartamentoOrigem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdDepartamentoOrigem.connectionString = this.connectionString;
                            this.m_IdDepartamentoOrigem.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdDepartamentoOrigem.selfFill();

                return this.m_IdDepartamentoOrigem;
            }
        }

        [
            TColumn("idPdvEstacaoAberturaCaixaAtual", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idPdvEstacaoAberturaCaixaAtual->idPdvEstacaoAberturaCaixa" })
        ]
        private PdvEstacoesAberturaCaixa m_aberturaCaixaAtual = null;
        public PdvEstacoesAberturaCaixa aberturaCaixaAtual
        {
            get
            {
                if (this.m_aberturaCaixaAtual == null)
                {
                    this.m_aberturaCaixaAtual = new PdvEstacoesAberturaCaixa();

                    foreach (TJoin attribute in this.m_aberturaCaixaAtual.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_aberturaCaixaAtual.connectionString = this.connectionString;
                            this.m_aberturaCaixaAtual.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_aberturaCaixaAtual.selfFill();

                return this.m_aberturaCaixaAtual;
            }
        }

        [
         TList(typeof(PdvEstacoesAberturaCaixa)),
         TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
        ]
        private Object m_pdvEstacoesAberturaCaixa = null;
        public System.Collections.Generic.List<PdvEstacoesAberturaCaixa> pdvEstacoesAberturaCaixa
        {
            get
            {
                if (this.m_pdvEstacoesAberturaCaixa != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvEstacoesAberturaCaixa) }
                     ).IsInstanceOfType(this.m_pdvEstacoesAberturaCaixa)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixa)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixa).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixa).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixa)[i]);

                        this.m_pdvEstacoesAberturaCaixa = em.list(typeof(PdvEstacoesAberturaCaixa), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvEstacoesAberturaCaixa>)this.m_pdvEstacoesAberturaCaixa;
            }
        }


        [
         TList(typeof(PdvEstacoesFechamentoCaixa)),
         TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
        ]
        private Object m_pdvEstacoesFechamentoCaixa = null;
        public System.Collections.Generic.List<PdvEstacoesFechamentoCaixa> pdvEstacoesFechamentoCaixa
        {
            get
            {
                if (this.m_pdvEstacoesFechamentoCaixa != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvEstacoesFechamentoCaixa) }
                     ).IsInstanceOfType(this.m_pdvEstacoesFechamentoCaixa)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixa)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixa).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixa).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixa)[i]);

                        this.m_pdvEstacoesFechamentoCaixa = em.list(typeof(PdvEstacoesFechamentoCaixa), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvEstacoesFechamentoCaixa>)this.m_pdvEstacoesFechamentoCaixa;
            }
        }

        [
            TColumn("pos", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "pos->idPos" })
        ]
        private Pos m_Pos = null;
        public Pos Pos
        {
            get
            {
                if (this.m_Pos == null)
                {
                    this.m_Pos = new Pos();

                    foreach (TJoin attribute in this.m_Pos.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_Pos.connectionString = this.connectionString;
                            this.m_Pos.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_Pos.selfFill();

                return this.m_Pos;
            }
        }

        [
         TList(typeof(PdvEstacoesConfig)),
         TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
        ]
        private Object m_PdvEstacaoConfig = null;
        public System.Collections.Generic.List<PdvEstacoesConfig> pdvEstacaoConfig
        {
            get
            {
                if (this.m_PdvEstacaoConfig != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvEstacoesConfig) }
                     ).IsInstanceOfType(this.m_PdvEstacaoConfig)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvEstacaoConfig)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PdvEstacaoConfig).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PdvEstacaoConfig).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvEstacaoConfig)[i]);

                        this.m_PdvEstacaoConfig = em.list(typeof(PdvEstacoesConfig), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvEstacoesConfig>)this.m_PdvEstacaoConfig;
            }
        }


        [TColumn("habilitarPosPago", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_habilitarPosPago = new TFieldBoolean();
        public TFieldBoolean habilitarPosPago
        {
            get { return this.m_habilitarPosPago; }
        }

        [
            TColumn("idNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idNaturezaOperacao->idNaturezaOperacao" })
        ]
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

        [
            TColumn("idCliente", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idCliente->idCliente" })
        ]
        private Cliente m_IdCliente = null;
        public Cliente cliente
        {
            get
            {
                if (this.m_IdCliente == null)
                {
                    this.m_IdCliente = new Cliente();

                    foreach (TJoin attribute in this.m_IdCliente.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCliente.connectionString = this.connectionString;
                            this.m_IdCliente.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdCliente.selfFill();

                return this.m_IdCliente;
            }
        }
    }
}
