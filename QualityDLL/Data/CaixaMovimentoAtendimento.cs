using System;

namespace Data
{
	//[Serializable]
	public class CaixaMovimentoAtendimento: Base
	{
		public CaixaMovimentoAtendimento(): base()
		{
		}

		private int m_IdCaixaMovimentoAtendimento;
		public int idCaixaMovimentoAtendimento
		{
			get{return this.m_IdCaixaMovimentoAtendimento;}
			set{this.m_IdCaixaMovimentoAtendimento = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private CaixaMovimento m_IdCaixaMovimento;
		public CaixaMovimento caixaMovimento
		{
			get{return this.m_IdCaixaMovimento;}
			set{this.m_IdCaixaMovimento = value;}
		}

		private Atendimento m_IdAtendimento;
		public Atendimento atendimento
		{
			get{return this.m_IdAtendimento;}
			set{this.m_IdAtendimento = value;}
		}

		private EmpresaRelacionamento m_IdCliente;
		public EmpresaRelacionamento cliente
		{
			get{return this.m_IdCliente;}
			set{this.m_IdCliente = value;}
		}

        public override string ToString()
        {
            return this.m_IdCaixaMovimentoAtendimento.ToString();
        }
    }
}
