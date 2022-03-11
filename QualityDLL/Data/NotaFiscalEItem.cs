using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [TClassAttributeEdit(2)]
    public class NotaFiscalEItem : Base
    {
        public NotaFiscalEItem()
            : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdNotaFiscalEItem;
        public int idNotaFiscalEItem
        {
            get { return this.m_IdNotaFiscalEItem; }
            set { this.m_IdNotaFiscalEItem = value; }
        }

        [
            TFieldAttributeGridDisplay("Produto/Servico", 320),
            TFieldAttributeEditDisplay("Produto/Servico", 80),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idProdutoServico:descricao:3")
        ]
        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        [
            TFieldAttributeEditDisplay("Op Fiscal", 85),
            TFieldAttributeData(6, false)
        ]
        private int m_IdOperacaoFiscal;
        public int idOperacaoFiscal
        {
            get { return this.m_IdOperacaoFiscal; }
            set { this.m_IdOperacaoFiscal = value; }
        }

        [
            TFieldAttributeGridDisplay("Quantidade", 100),
            TFieldAttributeEditDisplay("Quantidade", 70),
            TFieldAttributeData(13, true),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_Quantidade;
        public double quantidade
        {
            get { return this.m_Quantidade; }
            set { this.m_Quantidade = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 90),
            TFieldAttributeEditDisplay("Valor", 90),
            TFieldAttributeData(18, true),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        [
            TFieldAttributeEditDisplay("Unidade", 85),
            TFieldAttributeData(6, true, true, false),
            TFieldAttributeSubfield("idUnidadeProdutoServico:descricao")
        ]
        private UnidadeProdutoServico m_IdUnidadeProdutoServico;
        public UnidadeProdutoServico unidadeProdutoServico
        {
            get { return this.m_IdUnidadeProdutoServico; }
            set { this.m_IdUnidadeProdutoServico = value; }
        }


        //[
        //    TFieldAttributeEditDisplay("ISS", 90),
        //    TFieldAttributeData(18, false),
        //    TFieldAttributeFormat("C2", "money")
        //]
        private double m_Iss;
        public double iss
        {
            get { return this.m_Iss; }
            set { this.m_Iss = value; }
        }

        [
            TFieldAttributeEditDisplay("ICMS Total", 90),
            TFieldAttributeData(18, false),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Icms;
        public double icms
        {
            get { return this.m_Icms; }
            set { this.m_Icms = value; }
        }

        [
            TFieldAttributeEditDisplay("IPI Total", 90),
            TFieldAttributeData(18, false),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Ipi;
        public double ipi
        {
            get { return this.m_Ipi; }
            set { this.m_Ipi = value; }
        }

        [
            TFieldAttributeEditDisplay("Fabricação", 90),
            TFieldAttributeData(10, false),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataFabricacao;
        public DateTime dataFabricacao
        {
            get { return this.m_DataFabricacao; }
            set { this.m_DataFabricacao = value; }
        }
        /*public String dataFabricacao
        {
            get { return this.m_DataFabricacao.ToString("dd/MM/yyyy"); }
            set { this.m_DataFabricacao = DateTime.Parse(value); }
        }*/

        [
            TFieldAttributeEditDisplay("Validade", 90),
            TFieldAttributeData(10, false),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataValidade;
        public DateTime dataValidade
        {
            get { return this.m_DataValidade; }
            set { this.m_DataValidade = value; }
        }
        /*public String dataValidade
        {
            get { return this.m_DataValidade.ToString("dd/MM/yyyy"); }
            set { this.m_DataValidade = DateTime.Parse(value); }
        }*/

        [
            TFieldAttributeEditDisplay("Lote", 90),
            TFieldAttributeData(15, false)

        ]
        private String m_NumeroLote;
        public String numeroLote
        {
            get { return this.m_NumeroLote; }
            set { this.m_NumeroLote = value; }
        }

        private int m_IdNotaFiscal;
        public int idNotaFiscal
        {
            get { return this.m_IdNotaFiscal; }
            set { this.m_IdNotaFiscal = value; }
        }

        private NotaFiscalE m_IdNotaFiscalE;
        public NotaFiscalE notaFiscal
        {
            get { return this.m_IdNotaFiscalE; }
            set { this.m_IdNotaFiscalE = value; }

        }

        private int m_IdEntradaPedido;
        public int idEntradaPedido
        {
            get { return this.m_IdEntradaPedido; }
            set { this.m_IdEntradaPedido = value; }
        }

        private int m_IdEntradaMercadoriaItem;
        public int idEntradaMercadoriaItem
        {
            get { return this.m_IdEntradaMercadoriaItem; }
            set { this.m_IdEntradaMercadoriaItem = value; }
        }

        [
           TFieldAttributeEditDisplay("Complemento", 80),
           TFieldAttributeData(255, false)

        ]
        private String m_Complemento;
        public String complemento
        {
            get { return this.m_Complemento; }
            set { this.m_Complemento = value; }
        }

        [
           TFieldAttributeEditDisplay("ID (Não Alterar)", 50),
           TFieldAttributeData(5, false),
           TFieldAttributeKey(false, true)
        ]
        private int m_IdPedidoCompraProdutoServico;
        public int idPedidoCompraProdutoServico
        {
            get { return this.m_IdPedidoCompraProdutoServico; }
            set { this.m_IdPedidoCompraProdutoServico = value; }
        }

        private bool m_MovimentaEstoque;
        public bool movimentaEstoque
        {
            get { return this.m_MovimentaEstoque; }
            set { this.m_MovimentaEstoque = value; }
        }
    }
}