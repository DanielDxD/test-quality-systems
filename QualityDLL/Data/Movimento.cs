using System;

namespace Data
{
	//[Serializable]
	public class Movimento: Base
	{
		public Movimento(): base()
		{
		}

		private int m_IdMovimento;
		public int idMovimento
		{
			get{return this.m_IdMovimento;}
			set{this.m_IdMovimento = value;}
		}

		private DateTime m_DataMovimento;
		public DateTime dataMovimento
		{
			get{return this.m_DataMovimento;}
			set{this.m_DataMovimento = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private EmpresaRelacionamento m_IdEmpresaRelacionamento;
		public EmpresaRelacionamento empresaRelacionamento
		{
			get{return this.m_IdEmpresaRelacionamento;}
			set{this.m_IdEmpresaRelacionamento = value;}
		}

		private TipoMovimento m_IdTipoMovimento;
		public TipoMovimento tipoMovimento
		{
			get{return this.m_IdTipoMovimento;}
			set{this.m_IdTipoMovimento = value;}
		}

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        public override string ToString()
        {
            return this.m_IdMovimento.ToString();
        }
    }
}
