using System;

namespace Data
{
	//[Serializable]
	public class CatracaAcesso: Base
	{
		public CatracaAcesso(): base()
		{
		}

		private int m_IdCatracaAcesso;
		public int idCatracaAcesso
		{
			get{return this.m_IdCatracaAcesso;}
			set{this.m_IdCatracaAcesso = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private Departamento m_IdDepartamento;
		public Departamento departamento
		{
			get{return this.m_IdDepartamento;}
			set{this.m_IdDepartamento = value;}
		}

		private TipoMovimento m_IdTipoMovimento;
		public TipoMovimento tipoMovimento
		{
			get{return this.m_IdTipoMovimento;}
			set{this.m_IdTipoMovimento = value;}
		}

        public override string ToString()
        {
            return this.m_IdCatracaAcesso.ToString();
        }
    }
}
