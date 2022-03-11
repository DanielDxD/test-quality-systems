using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    [TClassAttributeBusinessIdField("m_IdPlanoContas.m_IdEmpresa")]
	public class PlanoContasSaldo: Base
	{
		public PlanoContasSaldo(): base()
		{
		}

		private int m_IdPlanoContasSaldo;
		public int idPlanoContasSaldo
		{
			get{return this.m_IdPlanoContasSaldo;}
			set{this.m_IdPlanoContasSaldo = value;}
		}

		private int m_AnoMes;
		public int anoMes
		{
			get{return this.m_AnoMes;}
			set{this.m_AnoMes = value;}
		}

		private double m_Saldo;
		public double saldo
		{
			get{return this.m_Saldo;}
			set{this.m_Saldo = value;}
		}

		private PlanoContas m_IdPlanoContas;
		public PlanoContas planoContas
		{
			get{return this.m_IdPlanoContas;}
			set{this.m_IdPlanoContas = value;}
		}

        public override string ToString()
        {
            return this.m_IdPlanoContasSaldo.ToString();
        }
    }
}
