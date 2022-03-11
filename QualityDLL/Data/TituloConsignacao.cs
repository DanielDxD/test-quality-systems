using System;

namespace Data
{
	//[Serializable]
	public class TituloConsignacao: Base
	{
		public TituloConsignacao(): base()
		{
		}

		private int m_IdTituloConsignacao;
		public int idTituloConsignacao
		{
			get{return this.m_IdTituloConsignacao;}
			set{this.m_IdTituloConsignacao = value;}
		}

		private DateTime m_DataConsignacao;
		public DateTime dataConsignacao
		{
			get{return this.m_DataConsignacao;}
			set{this.m_DataConsignacao = value;}
		}

		private DateTime m_DataDevolucao;
		public DateTime dataDevolucao
		{
			get{return this.m_DataDevolucao;}
			set{this.m_DataDevolucao = value;}
		}

		private int m_Motivo;
		public int motivo
		{
			get{return this.m_Motivo;}
			set{this.m_Motivo = value;}
		}

		private String m_Observacao;
		public String observacao
		{
			get{return this.m_Observacao;}
			set{this.m_Observacao = value;}
		}

		private Titulo m_IdTitulo;
		public Titulo titulo
		{
			get{return this.m_IdTitulo;}
			set{this.m_IdTitulo = value;}
		}

		private EmpresaRelacionamento m_IdEmpresaRelacionamentoCorretor;
		public EmpresaRelacionamento corretorEmpresaRelacionamento
		{
			get{return this.m_IdEmpresaRelacionamentoCorretor;}
			set{this.m_IdEmpresaRelacionamentoCorretor = value;}
		}

        //idTituloConsignacaoVenda
        private TituloConsignacaoVenda[] m_TituloConsignacaoVendas;
        public TituloConsignacaoVenda[] tituloConsignacaoVendas
        {
            get{return this.m_TituloConsignacaoVendas;}
            set{this.m_TituloConsignacaoVendas = value;}
        }

        public override string ToString()
        {
            return this.m_IdTituloConsignacao.ToString();
        }
    }
}
