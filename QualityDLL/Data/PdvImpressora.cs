using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class PdvImpressora: Base
	{
		public PdvImpressora(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(20, false)
        ]
        private int m_IdPdvImpressora;
		public int idPdvImpressora
		{
			get{return this.m_IdPdvImpressora;}
			set{this.m_IdPdvImpressora = value;}
        }

        [
            TFieldAttributeGridDisplay("IP", 300),
            TFieldAttributeEditDisplay("IP", 300),
            TFieldAttributeData(200, false),
            TFieldAttributeKey(false, false)
        ]
        private string m_Ip;
        public string ip
        {
            get { return this.m_Ip; }
            set { this.m_Ip = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 300),
            TFieldAttributeEditDisplay("Descrição", 300),
            TFieldAttributeData(200, true),
            TFieldAttributeKey(false, false)
        ]
        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        public override string ToString()
        {
            return this.m_IdPdvImpressora.ToString();
        }
	}
}
