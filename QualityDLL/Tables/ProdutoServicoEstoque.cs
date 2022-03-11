using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ProdutoServicoEstoque")]
    public class ProdutoServicoEstoque : TTableBase
    {
        [TColumn("idProdutoServicoEstoque", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idProdutoServicoEstoque = new TFieldInteger();
        public TFieldInteger idProdutoServicoEstoque
        {
            get { return this.m_idProdutoServicoEstoque; }
        }

        [TColumn("dataFabricacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataFabricacao = new TFieldDatetime();
        public TFieldDatetime dataFabricacao
        {
            get { return this.m_dataFabricacao; }
        }

        [TColumn("dataValidade", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataValidade = new TFieldDatetime();
        public TFieldDatetime dataValidade
        {
            get { return this.m_dataValidade; }
        }

        [TColumn("numeroLote", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroLote = new TFieldString();
        public TFieldString numeroLote
        {
            get { return this.m_numeroLote; }
        }

        [TColumn("quantidade", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_quantidade = new TFieldDouble();
        public TFieldDouble quantidade
        {
            get { return this.m_quantidade; }
        }

        [TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idProdutoServico = new TFieldInteger();
        public TFieldInteger idProdutoServico
        {
            get { return this.m_idProdutoServico; }
        }

        [TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idDepartamento = new TFieldInteger();
        public TFieldInteger idDepartamento
        {
            get { return this.m_idDepartamento; }
        }

        [TColumn("patrimonio", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_patrimonio = new TFieldBoolean();
        public TFieldBoolean patrimonio
        {
            get { return this.m_patrimonio; }
        }

        [
         TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_departamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_departamento == null)
                {
                    this.m_departamento = new Departamento();

                    foreach (TJoin attribute in this.m_departamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_departamento.connectionString = this.connectionString;
                            this.m_departamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_departamento.selfFill();

                return this.m_departamento;
            }
        }

        [
         TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
            private ProdutoServico m_produtoServico = null;
        public ProdutoServico produtoServico
        {
            get
            {
                if (this.m_produtoServico == null)
                {
                    this.m_produtoServico = new ProdutoServico();

                    foreach (TJoin attribute in this.m_produtoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_produtoServico.connectionString = this.connectionString;
                            this.m_produtoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_produtoServico.selfFill();

                return this.m_produtoServico;
            }
        }
    }
}
