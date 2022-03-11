using System;

namespace Data
{
	//[Serializable]
	public class TipoRelacionamentoEmpresa: Base
	{
		public TipoRelacionamentoEmpresa(): base()
		{
		}

		private int m_IdTipoRelacionamentoEmpresa;
		public int idTipoRelacionamentoEmpresa
		{
			get{return this.m_IdTipoRelacionamentoEmpresa;}
			set{this.m_IdTipoRelacionamentoEmpresa = value;}
		}

		private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

		private String m_EmpresaSocio;
		public String empresaSocio
		{
			get{return this.m_EmpresaSocio;}
			set{this.m_EmpresaSocio = value;}
		}

		private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

        public override string ToString()
        {
            return this.m_IdTipoRelacionamentoEmpresa.ToString();
        }
    }
}
