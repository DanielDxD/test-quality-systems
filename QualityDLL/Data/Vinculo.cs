using System;

namespace Data
{
	//[Serializable]
	public class Vinculo: Base
	{
		public Vinculo(): base()
		{
		}

		private int m_IdVinculo;
		public int idVinculo
		{
			get{return this.m_IdVinculo;}
			set{this.m_IdVinculo = value;}
		}

		private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        public override string ToString()
        {
            return this.m_IdVinculo.ToString();
        }
    }
}
