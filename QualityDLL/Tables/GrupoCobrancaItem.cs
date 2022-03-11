
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("GrupoCobrancaItem")]
    public class GrupoCobrancaItem : TTableBase
    {
        [TColumn("idGrupoCobrancaItem", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdGrupoCobrancaItem = new TFieldInteger();
        public TFieldInteger idGrupoCobrancaItem
        {
            get { return this.m_IdGrupoCobrancaItem; }
        }

        [TColumn("idGrupoCobranca", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idGrupoCobranca->idGrupoCobranca" })]
        private GrupoCobranca m_IdGrupoCobranca = null;
        public GrupoCobranca grupoCobranca
        {
            get
            {
                if (this.m_IdGrupoCobranca == null)
                {
                    this.m_IdGrupoCobranca = new GrupoCobranca();
                    foreach (TJoin attribute in this.m_IdGrupoCobranca.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdGrupoCobranca.connectionString = this.connectionString;
                            this.m_IdGrupoCobranca.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdGrupoCobranca.selfFill();
                return this.m_IdGrupoCobranca;
            }
        }

        [TColumn("idParametroBoletoDesconto", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idParametroBoletoDesconto->idParametroBoletoDesconto" })]
        private ParametroBoletoDesconto m_IdParametroBoletoDesconto = null;
        public ParametroBoletoDesconto parametroBoletoDesconto
        {
            get
            {
                if (this.m_IdParametroBoletoDesconto == null)
                {
                    this.m_IdParametroBoletoDesconto = new ParametroBoletoDesconto();
                    foreach (TJoin attribute in this.m_IdParametroBoletoDesconto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdParametroBoletoDesconto.connectionString = this.connectionString;
                            this.m_IdParametroBoletoDesconto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdParametroBoletoDesconto.selfFill();
                return this.m_IdParametroBoletoDesconto;
            }
        }

        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idNaturezaOperacao->idNaturezaOperacao" })]
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

    }
}
