using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class RequisicaoCompra: Base
	{
		public RequisicaoCompra(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoCompra;
		public int idRequisicaoCompra
		{
			get{return this.m_IdRequisicaoCompra;}
			set{this.m_IdRequisicaoCompra = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 200),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Data", 120),
            TFieldAttributeData(50, false)
        ]
        private DateTime m_DataRequisicao;
		public DateTime dataRequisicao
		{
			get{return this.m_DataRequisicao;}
			set{this.m_DataRequisicao = value;}
		}

		private Departamento m_IdDepartamento;
		public Departamento departamento
		{
			get{return this.m_IdDepartamento;}
			set{this.m_IdDepartamento = value;}
		}

        private String m_Observacao;
        public String observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        //idRequisicaoCompra
        private RequisicaoCompraSituacao[] m_RequisicaoCompraSituacaos;
        public RequisicaoCompraSituacao[] requisicaoCompraSituacaos
        {
            get{return this.m_RequisicaoCompraSituacaos;}
            set{this.m_RequisicaoCompraSituacaos = value;}
        }

        //idRequisicaoCompra
        private RequisicaoCompraProdutoServico[] m_RequisicaoCompraProdutoServicos;
        public RequisicaoCompraProdutoServico[] requisicaoCompraProdutoServicos
        {
            get{return this.m_RequisicaoCompraProdutoServicos;}
            set{this.m_RequisicaoCompraProdutoServicos = value;}
        }

        //idRequisicaoCompra
        private RequisicaoCotacao[] m_RequisicaoCotacaos;
        public RequisicaoCotacao[] requisicaoCotacaos
        {
            get{return this.m_RequisicaoCotacaos;}
            set{this.m_RequisicaoCotacaos = value;}
        }

        //idRequisicaoCompra
        private PedidoCompra[] m_PedidoCompras;
        public PedidoCompra[] pedidoCompras
        {
            get{return this.m_PedidoCompras;}
            set{this.m_PedidoCompras = value;}
        }

        //Usuario Requisicao
        [
            TFieldAttributeGridDisplay("Usuário", 220)
        ]
        private String m_UsuarioRequisicao;
        public String usuarioRequisicao
        {
            get { return this.m_UsuarioRequisicao; }
            set { this.m_UsuarioRequisicao = value; }
        }

        public override string ToString()
        {
            return this.m_IdRequisicaoCompra.ToString();
        }
    }
}
