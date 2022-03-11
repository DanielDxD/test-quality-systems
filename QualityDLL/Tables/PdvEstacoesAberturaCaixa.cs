using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvEstacoesAberturaCaixa")]
    public class PdvEstacoesAberturaCaixa : TTableBase
    {
        [TColumn("idPdvEstacaoAberturaCaixa", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvEstacaoAberturaCaixa = new TFieldInteger();
        public TFieldInteger idPdvEstacaoAberturaCaixa
        {
            get { return this.m_idPdvEstacaoAberturaCaixa; }
        }

        [TColumn("dataAbertura", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataAbertura = new TFieldDatetime();
        public TFieldDatetime dataAbertura
        {
            get { return this.m_dataAbertura; }
        }

        [TColumn("valorTotal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorTotal = new TFieldDouble();
        public TFieldDouble valorTotal
        {
            get { return this.m_valorTotal; }
        }

        [
         TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
        ]
        private PdvEstacao  m_pdvEstacao = null;
        public PdvEstacao  pdvEstacao
        {
            get
            {
                if (this.m_pdvEstacao == null)
                {
                    this.m_pdvEstacao = new PdvEstacao ();

                    foreach (TJoin attribute in this.m_pdvEstacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvEstacao.connectionString = this.connectionString;
                            this.m_pdvEstacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvEstacao.selfFill();

                return this.m_pdvEstacao;
            }
        }

        [
         TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idFuncionario->idFuncionario" })
        ]
        private Funcionario m_funcionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_funcionario == null)
                {
                    this.m_funcionario = new Funcionario();

                    foreach (TJoin attribute in this.m_funcionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_funcionario.connectionString = this.connectionString;
                            this.m_funcionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_funcionario.selfFill();

                return this.m_funcionario;
            }
        }

        [
         TColumn("idPdvEstacaoFechamentoCaixa", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPdvEstacaoFechamentoCaixa->idPdvEstacaoFechamentoCaixa" })
        ]
        private PdvEstacoesFechamentoCaixa m_pdvEstacaoFechamentoCaixa = null;
        public PdvEstacoesFechamentoCaixa pdvEstacaoFechamentoCaixa
        {
            get
            {
                if (this.m_pdvEstacaoFechamentoCaixa == null)
                {
                    this.m_pdvEstacaoFechamentoCaixa = new PdvEstacoesFechamentoCaixa();

                    foreach (TJoin attribute in this.m_pdvEstacaoFechamentoCaixa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvEstacaoFechamentoCaixa.connectionString = this.connectionString;
                            this.m_pdvEstacaoFechamentoCaixa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvEstacaoFechamentoCaixa.selfFill();

                return this.m_pdvEstacaoFechamentoCaixa;
            }
        }

        [
         TList(typeof(PdvEstacoesAberturaCaixaDetalhe)),
         TJoin(new String[] { "idPdvEstacaoAberturaCaixa->idPdvEstacaoAberturaCaixa" })
        ]
        private Object m_pdvEstacoesAberturaCaixaDetalhe = null;
        public System.Collections.Generic.List<PdvEstacoesAberturaCaixaDetalhe> pdvEstacoesAberturaCaixaDetalhe
        {
            get
            {
                if (this.m_pdvEstacoesAberturaCaixaDetalhe != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvEstacoesAberturaCaixaDetalhe) }
                     ).IsInstanceOfType(this.m_pdvEstacoesAberturaCaixaDetalhe)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixaDetalhe)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixaDetalhe).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixaDetalhe).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesAberturaCaixaDetalhe)[i]);

                        this.m_pdvEstacoesAberturaCaixaDetalhe = em.list(typeof(PdvEstacoesAberturaCaixaDetalhe), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvEstacoesAberturaCaixaDetalhe>)this.m_pdvEstacoesAberturaCaixaDetalhe;
            }
        }

    }
}
