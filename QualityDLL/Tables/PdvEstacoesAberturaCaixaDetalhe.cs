using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvEstacoesAberturaCaixaDetalhe")]
    public class PdvEstacoesAberturaCaixaDetalhe : TTableBase
    {
        [TColumn("idPdvEstacaoAberturaCaixaDetalhe", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvEstacaoAberturaCaixaDetalhe = new TFieldInteger();
        public TFieldInteger idPdvEstacaoAberturaCaixaDetalhe
        {
            get { return this.m_idPdvEstacaoAberturaCaixaDetalhe; }
        }

        [
         TColumn("idPdvEstacaoAberturaCaixa", System.Data.SqlDbType.DateTime, false, false),
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
         TColumn("idContaPagamento", System.Data.SqlDbType.DateTime, false, false),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private ContaPagamento m_IdContaPagamento = null;
        public ContaPagamento contaPagamento
        {
            get
            {
                if (this.m_IdContaPagamento == null)
                {
                    this.m_IdContaPagamento = new ContaPagamento();

                    foreach (TJoin attribute in this.m_IdContaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContaPagamento.connectionString = this.connectionString;
                            this.m_IdContaPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdContaPagamento.selfFill();

                return this.m_IdContaPagamento;
            }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }
    }
}
