using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvCompraCupomItem : Base
    {
        public PdvCompraCupomItem() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID Item", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvCompraCupomItem;
        public int idPdvCompraCupomItem
        {
            get { return this.m_IdPdvCompraCupomItem; }
            set { this.m_IdPdvCompraCupomItem = value; }
        }

        [
            TFieldAttributeGridDisplay("Cupom", 25),
            TFieldAttributeSubfield("idPdvCompraCupom:sequenciaCupom")
        ]
        private PdvCompraCupom m_IdPdvCompraCupom;
        public PdvCompraCupom pdvCompraCupom
        {
            get { return m_IdPdvCompraCupom; }
            set { this.m_IdPdvCompraCupom = value; }
        }

        private RequisicaoInternaProdutoServico m_requisicaoInternaProdutoServico;
        public RequisicaoInternaProdutoServico requisicaoInternaProdutoServico
        {
            get { return this.m_requisicaoInternaProdutoServico; }
            set { this.m_requisicaoInternaProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Produto", 150),
            TFieldAttributeSubfield("idProdutoServico:descricao")
        ]
        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Qtd", 55)
        ]
        private Double m_quantidade;
        public Double quantidade
        {
            get { return this.m_quantidade; }
            set { this.m_quantidade = value; }
        }

        private Double m_Valor;
        public Double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 55),
            TFieldAttributeFormat("N2", "money")
        ]
        private string m_ValorUnidade;
        public string valorUnidade
        {
            get { return this.m_ValorUnidade; }
            set { this.m_ValorUnidade = value; }
        }

        [
            TFieldAttributeGridDisplay("Desconto", 55),
            TFieldAttributeFormat("N2", "money")
        ]
        private Double m_Desconto;
        public Double desconto
        {
            get { return this.m_Desconto; }
            set { this.m_Desconto = value; }
        }

        [
            TFieldAttributeGridDisplay("Total", 55),
            TFieldAttributeFormat("N2", "money")
        ]
        private Double m_Total;
        public Double total
        {
            get { return this.m_Total; }
            set { this.m_Total = value; }
        }

        [
            TFieldAttributeGridDisplay("Observação", 55)
        ]
        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private RequisicaoInterna m_IdRequisicaoInternaComposicao;
        public RequisicaoInterna requisicaoInternaComposicao
        {
            get { return this.m_IdRequisicaoInternaComposicao; }
            set { this.m_IdRequisicaoInternaComposicao = value; }
        }
    }
}
