using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ProdutoServicoPatrimonio : Base
    {
        public ProdutoServicoPatrimonio() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdProdutoServicoPatrimonio;
        public int idProdutoServicoPatrimonio
        {
            get { return this.m_IdProdutoServicoPatrimonio; }
            set { this.m_IdProdutoServicoPatrimonio = value; }
        }

        private ProdutoServicoEmpresa m_IdProdutoServicoEmpresa;
        public ProdutoServicoEmpresa produtoServicoEmpresa
        {
            get { return this.m_IdProdutoServicoEmpresa; }
            set { this.m_IdProdutoServicoEmpresa = value; }
        }

        [
            TFieldAttributeGridDisplay("Produto", 120),
            TFieldAttributeSubfield("idProdutoServico:descricao"),
            TFieldAttributeData(20, false)
        ]
        private ProdutoServico m_IdProdutoServico;
        public ProdutoServico produtoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Departamento", 120),
            TFieldAttributeSubfield("idDepartamento:descricao"),
            TFieldAttributeData(20, false)
        ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Código Patrimonial", 120),
            TFieldAttributeData(20, false)
        ]
        private string m_CodigoPatrimonial;
        public string codigoPatrimonial
        {
            get { return this.m_CodigoPatrimonial; }
            set { this.m_CodigoPatrimonial = value; }
        }

        private string m_MotivoBaixa;
        public string motivoBaixa
        {
            get { return this.m_MotivoBaixa; }
            set { this.m_MotivoBaixa = value; }
        }

        private DateTime m_DataTombamento;
        public DateTime dataTombamento
        {
            get { return this.m_DataTombamento; }
            set { this.m_DataTombamento = value; }
        }

        private DateTime m_DataInclusao;
        public DateTime dataInclusao
        {
            get { return this.m_DataInclusao; }
            set { this.m_DataInclusao = value; }
        }

        private DateTime m_DataAquisicao;
        public DateTime dataAquisicao
        {
            get { return this.m_DataAquisicao; }
            set { this.m_DataAquisicao = value; }
        }

        [
            TFieldAttributeSubfield("ItemGenerico:cp_Compra;cv_Convênio;d_Doação")
        ]
        private string m_ModalidadeAquisicao;
        public string modalidadeAquisicao
        {
            get { return this.m_ModalidadeAquisicao; }
            set { this.m_ModalidadeAquisicao = value; }
        }

        [
            TFieldAttributeSubfield("ItemGenerico:b_Bom;i_Irrecuperável;r_Regular")
        ]
        private string m_EstadoConservacao;
        public string estadoConservacao
        {
            get { return this.m_EstadoConservacao; }
            set { this.m_EstadoConservacao = value; }
        }

        [
            TFieldAttributeSubfield("ItemGenerico:u_Em Uso;o_Ocioso;ae_Anti Econômico")
        ]
        private string m_SituacaoUtilitaria;
        public string situacaoUtilitaria
        {
            get { return this.m_SituacaoUtilitaria; }
            set { this.m_SituacaoUtilitaria = value; }
        }

        private Double m_ValorAquisicaoEstimado;
        public Double valorAquisicaoEstimado
        {
            get { return this.m_ValorAquisicaoEstimado; }
            set { this.m_ValorAquisicaoEstimado = value; }
        }

        private Double m_ValorResidual;
        public Double valorResidual
        {
            get { return this.m_ValorResidual; }
            set { this.m_ValorResidual = value; }
        }

        private Double m_ValorAtual;
        public Double valorAtual
        {
            get { return this.m_ValorAtual; }
            set { this.m_ValorAtual = value; }
        }

        [
            TFieldAttributeGridDisplay("Data da Baixa", 120),
            TFieldAttributeData(20, false),
            TFieldAttributeFormat("dd/MM/yyyy", "")
        ]
        private DateTime m_DataBaixa;
        public DateTime dataBaixa
        {
            get { return this.m_DataBaixa; }
            set { this.m_DataBaixa = value; }
        }

        private int m_VidaUtil;
        public int vidaUtil
        {
            get { return this.m_VidaUtil; }
            set { this.m_VidaUtil = value; }
        }

        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private string m_NumeroNotaFiscal;
        public string numeroNotaFiscal
        {
            get { return this.m_NumeroNotaFiscal; }
            set { this.m_NumeroNotaFiscal = value; }
        }

        private string m_NumeroSerie;
        public string numeroSerie
        {
            get { return this.m_NumeroSerie; }
            set { this.m_NumeroSerie = value; }
        }
        
        public override string ToString()
        {
            return this.m_IdProdutoServicoPatrimonio.ToString();
        }
    }
}
