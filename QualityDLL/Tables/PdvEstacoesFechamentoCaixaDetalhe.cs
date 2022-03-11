using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvEstacoesFechamentoCaixaDetalhe")]
    public class PdvEstacoesFechamentoCaixaDetalhe : TTableBase
    {
        [TColumn("idPdvEstacaoFechamentoCaixaDetalhe", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvEstacaoFechamentoCaixaDetalhe = new TFieldInteger();
        public TFieldInteger idPdvEstacaoFechamentoCaixaDetalhe
        {
            get { return this.m_idPdvEstacaoFechamentoCaixaDetalhe; }
        }

        [
         TColumn("idPdvEstacaoFechamentoCaixa", System.Data.SqlDbType.DateTime, false, false),
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
         TColumn("idContaPagamento", System.Data.SqlDbType.DateTime, false, false),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private ContaPagamento m_contaPagamento = null;
        public ContaPagamento contaPagamento
        {
            get
            {
                if (this.m_contaPagamento == null)
                {
                    this.m_contaPagamento = new ContaPagamento();

                    foreach (TJoin attribute in this.m_contaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_contaPagamento.connectionString = this.connectionString;
                            this.m_contaPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_contaPagamento.selfFill();

                return this.m_contaPagamento;
            }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("valorDigitado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDigitado = new TFieldDouble();
        public TFieldDouble valorDigitado
        {
            get { return this.m_valorDigitado; }
        }
    }
}
