using System;

namespace Data
{
	//[Serializable]
	public class RequisicaoCompraSituacao: Base
	{
		public RequisicaoCompraSituacao(): base()
		{
		}

		private int m_IdRequisicaoCompraSituacao;
		public int idRequisicaoCompraSituacao
		{
			get{return this.m_IdRequisicaoCompraSituacao;}
			set{this.m_IdRequisicaoCompraSituacao = value;}
		}

		private String m_Situacao;
		public String situacao
		{
			get{return this.m_Situacao;}
			set{this.m_Situacao = value;}
		}

		private DateTime m_DataSituacao;
		public DateTime dataSituacao
		{
			get{return this.m_DataSituacao;}
			set{this.m_DataSituacao = value;}
		}

		private int m_IdRequisicaoCompra;
		public int idRequisicaoCompra
		{
			get{return this.m_IdRequisicaoCompra;}
			set{this.m_IdRequisicaoCompra = value;}
		}

		private int m_IdFuncionario;
		public int idFuncionario
		{
			get{return this.m_IdFuncionario;}
			set{this.m_IdFuncionario = value;}
		}

        public override string ToString()
        {
            return this.m_IdRequisicaoCompraSituacao.ToString();
        }
    }
}
