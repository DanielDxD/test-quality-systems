using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("NotaFiscalEItem")]
    public class NotaFiscalEItem : TTableBase
    {
        [TColumn("idNotaFiscalEItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idNotaFiscalEItem = new TFieldInteger();
        public TFieldInteger idNotaFiscalEItem
        {
            get { return this.m_idNotaFiscalEItem; }
        }

        [TColumn("quantidade", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_quantidade = new TFieldDouble();
        public TFieldDouble quantidade
        {
            get { return this.m_quantidade; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("iss", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_iss = new TFieldDouble();
        public TFieldDouble iss
        {
            get { return this.m_iss; }
        }

        [TColumn("icms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_icms = new TFieldDouble();
        public TFieldDouble icms
        {
            get { return this.m_icms; }
        }

        [TColumn("ipi", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ipi = new TFieldDouble();
        public TFieldDouble ipi
        {
            get { return this.m_ipi; }
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

        [TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idNotaFiscal = new TFieldInteger();
        public TFieldInteger idNotaFiscal
        {
            get { return this.m_idNotaFiscal; }
        }

        [TColumn("idPedidoCompraProdutoServico", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idPedidoCompraProdutoServico = new TFieldInteger();
        public TFieldInteger idPedidoCompraProdutoServico
        {
            get { return this.m_idPedidoCompraProdutoServico; }
        }

        [TColumn("idEntradaMercadoriaItem", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idEntradaMercadoriaItem = new TFieldInteger();
        public TFieldInteger idEntradaMercadoriaItem
        {
            get { return this.m_idEntradaMercadoriaItem; }
        }

        [
         TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private ProdutoServico m_idProdutoServico = null;
        public ProdutoServico produtoServico
        {
            get
            {
                if (this.m_idProdutoServico == null)
                {
                    this.m_idProdutoServico = new ProdutoServico();

                    foreach (TJoin attribute in this.m_idProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idProdutoServico.connectionString = this.connectionString;
                            this.m_idProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idProdutoServico.selfFill();

                return this.m_idProdutoServico;
            }
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

        [TColumn("idOperacaoFiscal", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idOperacaoFiscal = new TFieldInteger();
        public TFieldInteger idOperacaoFiscal
        {
            get { return this.m_idOperacaoFiscal; }
        }

        [TColumn("complemento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_complemento = new TFieldString();
        public TFieldString complemento
        {
            get { return this.m_complemento; }
        }

        [TColumn("movimentaEstoque", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_movimentaEstoque = new TFieldBoolean();
        public TFieldBoolean movimentaEstoque
        {
            get { return this.m_movimentaEstoque; }
        }
    }
}