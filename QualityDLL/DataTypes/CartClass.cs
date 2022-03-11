using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls
{
    public class GridInfo
    {
        private Data.PdvCompraCupomItem m_PdvCompraCupomItem;
        public Data.PdvCompraCupomItem pdvCompraCupomItem
        {
            get { return this.m_PdvCompraCupomItem; }
            set { this.m_PdvCompraCupomItem = value; }
        }

        private int m_indexGrid;
        public int indexGrid
        {
            get { return this.m_indexGrid; }
            set { this.m_indexGrid = value; }
        }
    }

    public class CartPdvCompraCupomItem
    {
        private Data.ProdutoServico m_ProdutoServico;
        public Data.ProdutoServico produtoServico
        {
            get { return this.m_ProdutoServico; }
            set { this.m_ProdutoServico = value; }
        }

        private double m_Qtd;
        public double qtd
        {
            get { return this.m_Qtd; }
            set { this.m_Qtd = value; }
        }

        private double m_Preco;
        public double preco
        {
            get { return this.m_Preco; }
            set { this.m_Preco = value; }
        }

        private double m_Desconto;
        public double desconto
        {
            get { return this.m_Desconto; }
            set { this.m_Desconto = value; }
        }

        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }
    }

    public class CartClass
    {

        private int m_CartId;
        public int cartId
        {
            get { return this.m_CartId; }
            set { this.m_CartId = value; }
        }

        private List<CartProdutos> m_Produtos;
        public List<CartProdutos> produtos
        {
            get { return this.m_Produtos; }
            set { this.m_Produtos = value; }
        }

        private Double m_ValorTotal;
        public Double valorTotal
        {
            get { return this.m_ValorTotal; }
            set { this.m_ValorTotal = value; }
        }

        private Double m_valorPago;
        public Double valorPago
        {
            get { return this.m_valorPago; }
            set { this.m_valorPago = value; }
        }

        private List<Pagamentos> m_Pagamentos = new List<Pagamentos>();
        public List<Pagamentos> pagamentos
        {
            get { return this.m_Pagamentos; }
            set { this.m_Pagamentos = value; }
        }

        private PagamentosInicial m_PgtoInicial;
        public PagamentosInicial pgtoInicial
        {
            get { return this.m_PgtoInicial; }
            set { this.m_PgtoInicial = value; }
        }

        private string m_CpfCnpj;
        public string cpfCnpj
        {
            get { return this.m_CpfCnpj; }
            set { this.m_CpfCnpj = value; }
        }

        private Data.PdvCompra m_PdvCompra;
        public Data.PdvCompra pdvCompra
        {
            get { return this.m_PdvCompra; }
            set { this.m_PdvCompra = value; }
        }

    }

    public class PagamentosInicial
    {
        private Data.ContaPagamento m_formaPgto;
        public Data.ContaPagamento formaPgto
        {
            get { return this.m_formaPgto; }
            set { this.m_formaPgto = value; }
        }

        private bool m_PrePago;
        public bool prePago
        {
            get { return this.m_PrePago; }
            set { this.m_PrePago = value; }
        }
        private bool m_PosPago;
        public bool posPago
        {
            get { return this.m_PosPago; }
            set { this.m_PosPago = value; }
        }

    }

    public class PagamentosFechamento
    {
        private Data.ContaPagamento m_formaPgto;
        public Data.ContaPagamento formaPgto
        {
            get { return this.m_formaPgto; }
            set { this.m_formaPgto = value; }
        }

        private List<Pagamentos> m_pagamentos;
        public List<Pagamentos> pagamentos
        {
            get { return this.m_pagamentos; }
            set { this.m_pagamentos = value; }
        }

        private Double m_ValorPago;
        public Double valorPago
        {
            get { return this.m_ValorPago; }
            set { this.m_ValorPago = value; }
        }

    }

    public class Pagamentos
    {

        private int _id;
        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        private Data.ContaPagamento m_formaPgto;
        public Data.ContaPagamento formaPgto
        {
            get { return this.m_formaPgto; }
            set { this.m_formaPgto = value; }
        }

        private Double m_ValorPago;
        public Double valorPago
        {
            get { return this.m_ValorPago; }
            set { this.m_ValorPago = value; }
        }

        private Double m_Desconto;
        public Double desconto
        {
            get { return this.m_Desconto; }
            set { this.m_Desconto = value; }
        }

        private bool m_pago;
        public bool pago
        {
            get { return this.m_pago; }
            set { this.m_pago = value; }
        }

        private bool m_PrePago;
        public bool prePago
        {
            get { return this.m_PrePago; }
            set { this.m_PrePago = value; }
        }

        private bool m_PosPago;
        public bool posPago
        {
            get { return this.m_PosPago; }
            set { this.m_PosPago = value; }
        }

        private bool m_Estorno;
        public bool estorno
        {
            get { return this.m_Estorno; }
            set { this.m_Estorno = value; }
        }

        private Double m_Troco;
        public Double troco
        {
            get { return this.m_Troco; }
            set { this.m_Troco = value; }
        }

        private Double m_TaxaServico;
        public Double taxaServico
        {
            get { return this.m_TaxaServico; }
            set { this.m_TaxaServico = value; }
        }

        private bool m_Avista;
        public bool avista
        {
            get { return this.m_Avista; }
            set { this.m_Avista = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }


    }

    public class CartProdutos
    {
        private Data.ProdutoServico m_produtoServico;
        public Data.ProdutoServico produtoServico
        {
            get { return this.m_produtoServico; }
            set { this.m_produtoServico = value; }
        }

        private Data.PdvCompraCupomItem m_pdvCompraCupomItem;
        public Data.PdvCompraCupomItem pdvCompraCupomItem
        {
            get { return this.m_pdvCompraCupomItem; }
            set { this.m_pdvCompraCupomItem = value; }
        }

        /*private Data.RequisicaoInternaProdutoServico m_requisicaoInternaPS;
        public Data.RequisicaoInternaProdutoServico requisicaoInternaPS
        {
            get { return this.m_requisicaoInternaPS; }
            set { this.m_requisicaoInternaPS = value; }
        }*/

        private Double m_Quantidade;
        public Double quantidade
        {
            get { return this.m_Quantidade; }
            set { this.m_Quantidade = value; }
        }

        private Double m_Valor;
        public Double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private Double m_Desconto;
        public Double desconto
        {
            get { return this.m_Desconto; }
            set { this.m_Desconto = value; }
        }

        private String m_Observacao;
        public String observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private bool m_taxaServico;
        public bool taxaServico
        {
            get { return this.m_taxaServico; }
            set { this.m_taxaServico = value; }
        }
    }
}
