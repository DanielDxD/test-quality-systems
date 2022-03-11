using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class FinalidadeEndereco: Base
	{
		public FinalidadeEndereco(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)

        ]
		private int m_IdFinalidadeEndereco;
		public int idFinalidadeEndereco
		{
			get{return this.m_IdFinalidadeEndereco;}
			set{this.m_IdFinalidadeEndereco = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 400),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 40),
            TFieldAttributeData(3, true)
        ]
        private String m_Tipo;
        public String tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        public override string ToString()
        {
            return this.m_IdFinalidadeEndereco.ToString();
        }
	}
}
