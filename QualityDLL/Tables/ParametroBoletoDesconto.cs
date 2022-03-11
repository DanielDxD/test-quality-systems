
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ParametroBoletoDesconto")]
    public class ParametroBoletoDesconto : TTableBase
    {
        [TColumn("idParametroBoletoDesconto", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdParametroBoletoDesconto = new TFieldInteger();
        public TFieldInteger idParametroBoletoDesconto
        {
            get { return this.m_IdParametroBoletoDesconto; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("tipoDesconto", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_TipoDesconto = new TFieldString();
        public TFieldString tipoDesconto
        {
            get { return this.m_TipoDesconto; }
        }

        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
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

        [TColumn("idParametroBoleto", System.Data.SqlDbType.Int, false, false),
        TJoin(new String[] { "idParametroBoleto->idParametroBoleto" })]
        private ParametroBoleto m_IdParametroBoleto = null;
        public ParametroBoleto parametroBoleto
        {
            get
            {
                if (this.m_IdParametroBoleto == null)
                {
                    this.m_IdParametroBoleto = new ParametroBoleto();
                    foreach (TJoin attribute in this.m_IdParametroBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdParametroBoleto.connectionString = this.connectionString;
                            this.m_IdParametroBoleto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdParametroBoleto.selfFill();
                return this.m_IdParametroBoleto;
            }
        }

        [TColumn("idCategoriaTitulo", System.Data.SqlDbType.Int, false, false),
        TJoin(new String[] { "idCategoriaTitulo->idCategoriaTitulo" })]
        private CategoriaTitulo m_IdCategoriaTitulo = null;
        public CategoriaTitulo categoriaTitulo
        {
            get
            {
                if (this.m_IdCategoriaTitulo == null)
                {
                    this.m_IdCategoriaTitulo = new CategoriaTitulo();
                    foreach (TJoin attribute in this.m_IdCategoriaTitulo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCategoriaTitulo.connectionString = this.connectionString;
                            this.m_IdCategoriaTitulo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCategoriaTitulo.selfFill();
                return this.m_IdCategoriaTitulo;
            }
        }

        [TColumn("idSituacao", System.Data.SqlDbType.Int, false, false),
        TJoin(new String[] { "idSituacao->idSituacao" })]
        private Situacao m_IdSituacao = null;
        public Situacao situacao
        {
            get
            {
                if (this.m_IdSituacao == null)
                {
                    this.m_IdSituacao = new Situacao();
                    foreach (TJoin attribute in this.m_IdSituacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdSituacao.connectionString = this.connectionString;
                            this.m_IdSituacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdSituacao.selfFill();
                return this.m_IdSituacao;
            }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_Valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_Valor; }
        }

        [TColumn("diasAVencer", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_DiasAVencer = new TFieldInteger();
        public TFieldInteger diasAVencer
        {
            get { return this.m_DiasAVencer; }
        }

        [TColumn("diaFixo", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_DiaFixo = new TFieldInteger();
        public TFieldInteger diaFixo
        {
            get { return this.m_DiaFixo; }
        }

        [TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataInicio = new TFieldDatetime();
        public TFieldDatetime dataInicio
        {
            get { return this.m_DataInicio; }
        }

        [TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataFim = new TFieldDatetime();
        public TFieldDatetime dataFim
        {
            get { return this.m_DataFim; }
        }

    }
}
