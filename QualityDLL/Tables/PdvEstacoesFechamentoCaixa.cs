using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvEstacoesFechamentoCaixa")]
    public class PdvEstacoesFechamentoCaixa : TTableBase
    {
        [TColumn("idPdvEstacaoFechamentoCaixa", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvEstacaoFechamentoCaixa = new TFieldInteger();
        public TFieldInteger idPdvEstacaoFechamentoCaixa
        {
            get { return this.m_idPdvEstacaoFechamentoCaixa; }
        }

        [TColumn("dataFechamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataFechamento = new TFieldDatetime();
        public TFieldDatetime dataFechamento
        {
            get { return this.m_dataFechamento; }
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
         TColumn("idPdvEstacaoAberturaCaixa", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPdvEstacaoAberturaCaixa->idPdvEstacaoAberturaCaixa" })
        ]
        private PdvEstacoesAberturaCaixa m_pdvEstacaoAberturaCaixa = null;
        public PdvEstacoesAberturaCaixa pdvEstacaoAberturaCaixa
        {
            get
            {
                if (this.m_pdvEstacaoAberturaCaixa == null)
                {
                    this.m_pdvEstacaoAberturaCaixa = new PdvEstacoesAberturaCaixa();

                    foreach (TJoin attribute in this.m_pdvEstacaoAberturaCaixa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvEstacaoAberturaCaixa.connectionString = this.connectionString;
                            this.m_pdvEstacaoAberturaCaixa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvEstacaoAberturaCaixa.selfFill();

                return this.m_pdvEstacaoAberturaCaixa;
            }
        }

        [
         TList(typeof(PdvEstacoesFechamentoCaixaDetalhe)),
         TJoin(new String[] { "idPdvEstacaoFechamentoCaixa->idPdvEstacaoFechamentoCaixa" })
        ]
        private Object m_pdvEstacoesFechamentoCaixaDetalhe = null;
        public System.Collections.Generic.List<PdvEstacoesFechamentoCaixaDetalhe> pdvEstacoesFechamentoCaixaDetalhe
        {
            get
            {
                if (this.m_pdvEstacoesFechamentoCaixaDetalhe != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvEstacoesFechamentoCaixaDetalhe) }
                     ).IsInstanceOfType(this.m_pdvEstacoesFechamentoCaixaDetalhe)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixaDetalhe)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixaDetalhe).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixaDetalhe).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_pdvEstacoesFechamentoCaixaDetalhe)[i]);

                        this.m_pdvEstacoesFechamentoCaixaDetalhe = em.list(typeof(PdvEstacoesFechamentoCaixaDetalhe), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvEstacoesFechamentoCaixaDetalhe>)this.m_pdvEstacoesFechamentoCaixaDetalhe;
            }
        }

    }
}
