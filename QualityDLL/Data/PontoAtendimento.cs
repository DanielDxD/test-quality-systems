using System;

namespace Data
{
	//[Serializable]
	public class PontoAtendimento: Base
	{
		public PontoAtendimento(): base()
		{
		}

		private int m_IdPontoAtendimento;
		public int idPontoAtendimento
		{
			get{return this.m_IdPontoAtendimento;}
			set{this.m_IdPontoAtendimento = value;}
		}

		private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

		private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

        private int m_Empresa;
        public int empresa
        {
            get { return this.m_Empresa; }
            set { this.m_Empresa = value; }
        }

        //idPontoAtendimento
        private Atendimento[] m_Atendimentos;
        public Atendimento[] atendimentos
        {
            get{return this.m_Atendimentos;}
            set{this.m_Atendimentos = value;}
        }

        public override string ToString()
        {
            return this.m_IdPontoAtendimento.ToString();
        }
    }
}
