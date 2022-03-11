using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ProdutoServicoEmpresa")]
    public class ProdutoServicoEmpresa : TTableBase
    {
        [TColumn("custo", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_custo = new TFieldDouble();
        public TFieldDouble custo
        {
            get { return this.m_custo; }
        }

        [TColumn("preco", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_preco = new TFieldDouble();
        public TFieldDouble preco
        {
            get { return this.m_preco; }
        }

        [TColumn("quantidade", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_quantidade = new TFieldDouble();
        public TFieldDouble quantidade
        {
            get { return this.m_quantidade; }
        }

        [TColumn("dataUltimaCompra", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataUltimaCompra = new TFieldDatetime();
        public TFieldDatetime dataUltimaCompra
        {
            get { return this.m_dataUltimaCompra; }
        }

        [TColumn("estoqueMinimo", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_estoqueMinimo = new TFieldDouble();
        public TFieldDouble estoqueMinimo
        {
            get { return this.m_estoqueMinimo; }
        }

        [TColumn("estoqueMaximo", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_estoqueMaximo = new TFieldDouble();
        public TFieldDouble estoqueMaximo
        {
            get { return this.m_estoqueMaximo; }
        }

        [TColumn("aliquotaIcms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaIcms = new TFieldDouble();
        public TFieldDouble aliquotaIcms
        {
            get { return this.m_aliquotaIcms; }
        }

        [TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idProdutoServico = new TFieldInteger();
        public TFieldInteger idProdutoServico
        {
            get { return this.m_idProdutoServico; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, true, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("codigoProduto", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoProduto = new TFieldString();
        public TFieldString codigoProduto
        {
            get { return this.m_codigoProduto; }
        }

        [TColumn("aplicarTaxaServico", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_aplicarTaxaServico = new TFieldBoolean();
        public TFieldBoolean aplicarTaxaServico
        {
            get { return this.m_aplicarTaxaServico; }
        }

        [
            TColumn("idTipoProdutoServico", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idTipoProdutoServico->idTipoProdutoServico" })
        ]
        private TipoProdutoServico m_idTipoProdutoServico = null;
        public TipoProdutoServico tipoProdutoServico
        {
            get
            {
                if (this.m_idTipoProdutoServico == null)
                {
                    this.m_idTipoProdutoServico = new TipoProdutoServico();

                    foreach (TJoin attribute in this.m_idTipoProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoProdutoServico.connectionString = this.connectionString;
                            this.m_idTipoProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoProdutoServico.selfFill();

                return this.m_idTipoProdutoServico;
            }
        }

        [
            TColumn("idPerfilFiscalNfe", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPerfilFiscalNfe->idPerfilFiscal" })
        ]
        private PerfilFiscal m_idPerfilFiscalNfe = null;
        public PerfilFiscal perfilFiscalNfe
        {
            get
            {
                if (this.m_idPerfilFiscalNfe == null)
                {
                    this.m_idPerfilFiscalNfe = new PerfilFiscal();

                    foreach (TJoin attribute in this.m_idPerfilFiscalNfe.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPerfilFiscalNfe.connectionString = this.connectionString;
                            this.m_idPerfilFiscalNfe.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPerfilFiscalNfe.selfFill();

                return this.m_idPerfilFiscalNfe;
            }
        }

        [
            TColumn("idPerfilFiscal", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPerfilFiscal->idPerfilFiscal" })
        ]
        private PerfilFiscal m_idPerfilFiscal = null;
        public PerfilFiscal perfilFiscal
        {
            get
            {
                if (this.m_idPerfilFiscal == null)
                {
                    this.m_idPerfilFiscal = new PerfilFiscal();

                    foreach (TJoin attribute in this.m_idPerfilFiscal.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPerfilFiscal.connectionString = this.connectionString;
                            this.m_idPerfilFiscal.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPerfilFiscal.selfFill();

                return this.m_idPerfilFiscal;
            }
        }

        [
            TColumn("idOrigemProduto", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idOrigemProduto->idOrigemProduto" })
        ]
        private OrigemProduto m_idOrigemProduto = null;
        public OrigemProduto origemProduto
        {
            get
            {
                if (this.m_idOrigemProduto == null)
                {
                    this.m_idOrigemProduto = new OrigemProduto();

                    foreach (TJoin attribute in this.m_idOrigemProduto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idOrigemProduto.connectionString = this.connectionString;
                            this.m_idOrigemProduto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idOrigemProduto.selfFill();

                return this.m_idOrigemProduto;
            }
        }

        [TColumn("TribRedBcIcms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_TribRedBcIcms = new TFieldDouble();
        public TFieldDouble TribRedBcIcms
        {
            get { return this.m_TribRedBcIcms; }
        }

        [TColumn("TribAliqICMSDif", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_TribAliqICMSDif = new TFieldDouble();
        public TFieldDouble TribAliqICMSDif
        {
            get { return this.m_TribAliqICMSDif; }
        }

        [TColumn("TribAliqIpi", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_TribAliqIpi = new TFieldDouble();
        public TFieldDouble TribAliqIpi
        {
            get { return this.m_TribAliqIpi; }
        }

        [TColumn("TribAliqPis", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_TribAliqPis = new TFieldDouble();
        public TFieldDouble TribAliqPis
        {
            get { return this.m_TribAliqPis; }
        }

        [TColumn("TribAliqCofins", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_TribAliqCofins = new TFieldDouble();
        public TFieldDouble TribAliqCofins
        {
            get { return this.m_TribAliqCofins; }
        }


    }
}
