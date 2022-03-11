using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("RegraContabilizacaoLancamento")]
    public class RegraContabilizacaoLancamento : TTableBase
    {
        [TColumn("idRegraContabilizacaoLancamento", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idRegraContabilizacaoLancamento = new TFieldInteger();
        public TFieldInteger idRegraContabilizacaoLancamento
        {
            get { return this.m_idRegraContabilizacaoLancamento; }
        }

        [TColumn("origemIdPlanoContas", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_origemIdPlanoContas = new TFieldString();
        public TFieldString origemIdPlanoContas
        {
            get { return this.m_origemIdPlanoContas; }
        }

        [TColumn("debitoCredito", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_debitoCredito = new TFieldString();
        public TFieldString debitoCredito
        {
            get { return this.m_debitoCredito; }
        }

        [TColumn("formula", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_formula = new TFieldString();
        public TFieldString formula
        {
            get { return this.m_formula; }
        }

        [TColumn("agrupaLancamento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_agrupaLancamento = new TFieldString();
        public TFieldString agrupaLancamento
        {
            get { return this.m_agrupaLancamento; }
        }

        [TColumn("ordemProcessamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_ordemProcessamento = new TFieldInteger();
        public TFieldInteger ordemProcessamento
        {
            get { return this.m_ordemProcessamento; }
        }

        [
         TColumn("idRegraContabilizacaoPrimaria", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idRegraContabilizacaoPrimaria->idRegraContabilizacao" })
        ]
        private RegraContabilizacao m_idRegraContabilizacaoPrimaria = null;
        public RegraContabilizacao regraContabilizacaoPrimaria
        {
            get
            {
                if (this.m_idRegraContabilizacaoPrimaria == null)
                {
                    this.m_idRegraContabilizacaoPrimaria = new RegraContabilizacao();

                    foreach (TJoin attribute in this.m_idRegraContabilizacaoPrimaria.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRegraContabilizacaoPrimaria.connectionString = this.connectionString;
                            this.m_idRegraContabilizacaoPrimaria.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRegraContabilizacaoPrimaria.selfFill();

                return this.m_idRegraContabilizacaoPrimaria;
            }
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
    }
}
