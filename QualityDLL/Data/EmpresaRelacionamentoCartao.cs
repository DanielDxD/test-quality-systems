using System;

namespace Data
{
	//[Serializable]
	public class EmpresaRelacionamentoCartao: Base
	{
		public EmpresaRelacionamentoCartao(): base()
		{
		}

		private int m_IdEmpresaRelacionamentoCartao;
		public int idEmpresaRelacionamentoCartao
		{
			get{return this.m_IdEmpresaRelacionamentoCartao;}
			set{this.m_IdEmpresaRelacionamentoCartao = value;}
		}

        private Double m_SaldoAtual;
        public Double saldoAtual
        {
            get { return this.m_SaldoAtual; }
            set { this.m_SaldoAtual = value; }
        }

		private EmpresaRelacionamento m_IdEmpresaRelacionamento;
		public EmpresaRelacionamento empresaRelacionamento
		{
			get{return this.m_IdEmpresaRelacionamento;}
			set{this.m_IdEmpresaRelacionamento = value;}
		}

        public override string ToString()
        {
            return this.m_IdEmpresaRelacionamentoCartao.ToString();
        }
    }
}
