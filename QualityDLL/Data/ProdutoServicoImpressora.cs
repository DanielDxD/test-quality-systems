using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class ProdutoServicoImpressora: Base
	{
		public ProdutoServicoImpressora(): base()
		{
		}


        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 70),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdProdutoServicoImpressora;
		public int idProdutoServicoImpressora
		{
			get{return this.m_IdProdutoServicoImpressora;}
			set{this.m_IdProdutoServicoImpressora = value;}
		}

        [
            TFieldAttributeGridDisplay("Estação", 200),
            TFieldAttributeSubfield("idPdvEstacao:descricao")
        ]
        private PdvEstacao  m_IdPdvEstacao;
		public PdvEstacao  pdvEstacao
		{
			get{return this.m_IdPdvEstacao; }
			set{this.m_IdPdvEstacao = value;}
        }
        
        [
            TFieldAttributeGridDisplay("Produto", 200),
            TFieldAttributeSubfield("idProdutoServico:descricao")
        ]
        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }


        [
            TFieldAttributeGridDisplay("Impressora", 200),
            TFieldAttributeSubfield("idPdvImpressora:descricao")
        ]
        private PdvImpressora m_IdPdvImpressora;
        public PdvImpressora pdvImpressora
        {
            get { return this.m_IdPdvImpressora; }
            set { this.m_IdPdvImpressora = value; }
        }       

        public override string ToString()
        {
            return this.m_IdProdutoServicoImpressora.ToString();
        }
	}
}
