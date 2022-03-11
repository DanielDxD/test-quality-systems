using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class RequisicaoInternaProdutoServico: Base
	{
		public RequisicaoInternaProdutoServico(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoInternaProdutoServico;
		public int idRequisicaoInternaProdutoServico
		{
			get{return this.m_IdRequisicaoInternaProdutoServico;}
			set{this.m_IdRequisicaoInternaProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("Produto/Serviço", 200),
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
            TFieldAttributeGridDisplay("Unidade", 100),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idUnidadeProdutoServico:descricao")
        ]
        private UnidadeProdutoServico m_IdUnidadeProdutoServico;
        public UnidadeProdutoServico unidadeProdutoServico
        {
            get { return this.m_IdUnidadeProdutoServico; }
            set { this.m_IdUnidadeProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Solicitado", 90),
            TFieldAttributeData(13, false),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_QuantidadeSolicitada;
		public double quantidadeSolicitada
		{
			get{return this.m_QuantidadeSolicitada;}
			set{this.m_QuantidadeSolicitada = value;}
		}


        [
            TFieldAttributeGridDisplay("Atendido", 90),
            TFieldAttributeData(13, false),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_QuantidadeAtendida;
		public double quantidadeAtendida
		{
			get{return this.m_QuantidadeAtendida;}
			set{this.m_QuantidadeAtendida = value;}
		}

        [
            TFieldAttributeGridDisplay("Saldo", 90),
            TFieldAttributeData(13, false, false),
            TFieldAttributeFormat("0.0000", "!00000000,0000")
        ]
        private double m_SaldoProdutoDepartamento;
        public double saldoProdutoDepartamento
        {
            get { return this.m_SaldoProdutoDepartamento; }
            set { this.m_SaldoProdutoDepartamento = value; }
        }

        private double m_Fator;
        public double fator
        {
            get { return this.m_Fator; }
            set { this.m_Fator = value; }
        }
        
        private RequisicaoInterna m_IdRequisicaoInterna;
		public RequisicaoInterna requisicaoInterna
		{
			get{return this.m_IdRequisicaoInterna;}
			set{this.m_IdRequisicaoInterna = value;}
		}

        private int m_IdRequisicaoInterna2;
        public int idRequisicaoInterna
        {
            get { return this.m_IdRequisicaoInterna2; }
            set { this.m_IdRequisicaoInterna2 = value; }
        }

        public override string ToString()
        {
            return this.m_IdRequisicaoInternaProdutoServico.ToString();
        }
    }
}
