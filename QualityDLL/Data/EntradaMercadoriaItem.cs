using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [TClassAttributeEdit(2)]
    public class EntradaMercadoriaItem : Base
	{
		public EntradaMercadoriaItem(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            //TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdEntradaMercadoriaItem;
		public int idEntradaMercadoriaItem
		{
			get{return this.m_IdEntradaMercadoriaItem;}
			set{this.m_IdEntradaMercadoriaItem = value;}
		}

        [
            TFieldAttributeGridDisplay("Produto/Serviço", 320),
            //TFieldAttributeEditDisplay("Produto/Serviço", 80),
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
            TFieldAttributeGridDisplay("Quantidade", 100),
            //TFieldAttributeEditDisplay("Quantidade", 100),
            TFieldAttributeData(13, true),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_Quantidade;
		public double quantidade
		{
			get{return this.m_Quantidade;}
			set{this.m_Quantidade = value;}
		}

        [
            TFieldAttributeGridDisplay("Valor", 90),
            //TFieldAttributeEditDisplay("Valor", 90),
            TFieldAttributeData(18, true),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private int m_IdEntradaMercadoria;
		public int idEntradaMercadoria
		{
			get{return this.m_IdEntradaMercadoria;}
			set{this.m_IdEntradaMercadoria = value;}
		}

        [
            TFieldAttributeGridDisplay("Unidade", 85),
            //TFieldAttributeEditDisplay("Unidade", 85),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idUnidadeProdutoServico:descricao")
        ]
        private UnidadeProdutoServico m_IdUnidadeProdutoServico;
		public UnidadeProdutoServico unidadeProdutoServico
		{
			get{return this.m_IdUnidadeProdutoServico;}
			set{this.m_IdUnidadeProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("Fabricação", 90),
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

        [
           TFieldAttributeGridDisplay("Validade", 90),
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

        [
            TFieldAttributeGridDisplay("Lote", 85),
            //TFieldAttributeEditDisplay("Lote", 85),
            TFieldAttributeData(10, false)
        ]
        private String m_NumeroLote;
        public String numeroLote
        {
            get { return this.m_NumeroLote; }
            set { this.m_NumeroLote = value; }
        }

        public override string ToString()
        {
            return this.m_IdEntradaMercadoriaItem.ToString();
        }
    }
}
