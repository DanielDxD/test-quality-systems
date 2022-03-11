using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ProdutoServicoEmpresa : Base
    {
        public ProdutoServicoEmpresa()
            : base()
        {
        }

        private double m_Custo;
        public double custo
        {
            get { return this.m_Custo; }
            set { this.m_Custo = value; }
        }

        private double m_CustoUltimaEntrada;
        public double custoUltimaEntrada
        {
            get { return this.m_CustoUltimaEntrada; }
            set { this.m_CustoUltimaEntrada = value; }
        }

        private double m_Preco;
        public double preco
        {
            get { return this.m_Preco; }
            set { this.m_Preco = value; }
        }

        private double m_Quantidade;
        public double quantidade
        {
            get { return this.m_Quantidade; }
            set { this.m_Quantidade = value; }
        }

        private DateTime m_DataUltimaCompra;
        public DateTime dataUltimaCompra
        {
            get { return this.m_DataUltimaCompra; }
            set { this.m_DataUltimaCompra = value; }
        }

        private string m_aplicarTaxaServico;
        public string aplicarTaxaServico
        {
            get { return this.m_aplicarTaxaServico; }
            set { this.m_aplicarTaxaServico = value; }
        }

        private String m_CodigoProduto;
        public String codigoProduto
        {
            get { return this.m_CodigoProduto; }
            set { this.m_CodigoProduto = value; }
        }

        private double m_EstoqueMinimo;
        public double estoqueMinimo
        {
            get { return this.m_EstoqueMinimo; }
            set { this.m_EstoqueMinimo = value; }
        }

        private double m_EstoqueMaximo;
        public double estoqueMaximo
        {
            get { return this.m_EstoqueMaximo; }
            set { this.m_EstoqueMaximo = value; }
        }

        private double m_AliquotaIcms;
        public double aliquotaIcms
        {
            get { return this.m_AliquotaIcms; }
            set { this.m_AliquotaIcms = value; }
        }

        private int m_IdProdutoServico;
        public int idProdutoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private int m_IdTipoProdutoServico2;
        public int idTipoProdutoServico
        {
            get { return this.m_IdTipoProdutoServico2; }
            set { this.m_IdTipoProdutoServico2 = value; }
        }

        private TipoProdutoServico m_IdTipoProdutoServico;
        public TipoProdutoServico tipoProdutoServico
        {
            get { return this.m_IdTipoProdutoServico; }
            set { this.m_IdTipoProdutoServico = value; }
        }

        private PerfilFiscal m_IdPerfilFiscal;
        public PerfilFiscal perfilFiscal
        {
            get { return this.m_IdPerfilFiscal; }
            set { this.m_IdPerfilFiscal = value; }
        }

        private PerfilFiscal m_IdPerfilFiscalNfe;
        public PerfilFiscal perfilFiscalNfe
        {
            get { return this.m_IdPerfilFiscalNfe; }
            set { this.m_IdPerfilFiscalNfe = value; }
        }

        private OrigemProduto m_IdOrigemProduto;
        public OrigemProduto origemProduto
        {
            get { return this.m_IdOrigemProduto; }
            set { this.m_IdOrigemProduto = value; }
        }

        private double m_TribRedBcIcms;
        public double TribRedBcIcms
        {
            get { return this.m_TribRedBcIcms; }
            set { this.m_TribRedBcIcms = value; }
        }

        private double m_TribAliqICMSDif;
        public double TribAliqICMSDif
        {
            get { return this.m_TribAliqICMSDif; }
            set { this.m_TribAliqICMSDif = value; }
        }

        private double m_TribAliqIpi;
        public double TribAliqIpi
        {
            get { return this.m_TribAliqIpi; }
            set { this.m_TribAliqIpi = value; }
        }

        private double m_TribAliqPis;
        public double TribAliqPis
        {
            get { return this.m_TribAliqPis; }
            set { this.m_TribAliqPis = value; }
        }

        private double m_TribAliqCofins;
        public double TribAliqCofins
        {
            get { return this.m_TribAliqCofins; }
            set { this.m_TribAliqCofins = value; }
        }
    }
}
