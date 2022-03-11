using System;

namespace Data
{
	//[Serializable]
	public class TituloSocioLancamentoContabil: Base
	{
		public TituloSocioLancamentoContabil(): base()
		{
		}

		private int m_IdTituloSocioLancamentoContabil;
		public int idTituloSocioLancamentoContabil
		{
			get{return this.m_IdTituloSocioLancamentoContabil;}
			set{this.m_IdTituloSocioLancamentoContabil = value;}
		}

		private double m_Fator;
		public double fator
		{
			get{return this.m_Fator;}
			set{this.m_Fator = value;}
		}

		private TituloSocio m_IdTituloSocio;
		public TituloSocio tituloSocio
		{
			get{return this.m_IdTituloSocio;}
			set{this.m_IdTituloSocio = value;}
		}

		private PlanoContas m_IdPlanoContas;
		public PlanoContas planoContas
		{
			get{return this.m_IdPlanoContas;}
			set{this.m_IdPlanoContas = value;}
		}

		private TipoLancamentoContabil m_IdTipoLancamentoContabil;
		public TipoLancamentoContabil tipoLancamentoContabil
		{
			get{return this.m_IdTipoLancamentoContabil;}
			set{this.m_IdTipoLancamentoContabil = value;}
		}

        public override string ToString()
        {
            return this.m_IdTituloSocioLancamentoContabil.ToString();
        }
    }
}
