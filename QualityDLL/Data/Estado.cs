using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Estado: Base
	{
		public Estado(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ] 
		private int m_IdEstado;
		public int idEstado
		{
			get{return this.m_IdEstado;}
			set{this.m_IdEstado = value;}
		}

        [
            TFieldAttributeGridDisplay("UF", 55),
            TFieldAttributeData(2, true)
        ]
        private String m_Uf;
		public String uf
		{
			get{return this.m_Uf;}
			set{this.m_Uf = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 200 + 150),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
        }

        [
            TFieldAttributeGridDisplay("", 0),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idPais:descricao")
        ]
        private Pais m_IdPais;
        public Pais pais
        {
            get { return this.m_IdPais; }
            set { this.m_IdPais = value; }
        }

        [
            TFieldAttributeGridDisplay("Alíquota Inter Estadual", 150),
            TFieldAttributeData(6, false),
            TFieldAttributeFormat("0.00", "!00000000,00")
        ]
        private double m_AliquotaInter;
        public double aliquotaInter
        {
            get { return this.m_AliquotaInter; }
            set { this.m_AliquotaInter = value; }
        }

        [
            TFieldAttributeGridDisplay("Alíquota Intra Estadual", 150),
            TFieldAttributeData(6, false),
            TFieldAttributeFormat("0.00", "!00000000,00")
        ]
        private double m_AliquotaIntra;
        public double aliquotaIntra
        {
            get { return this.m_AliquotaIntra; }
            set { this.m_AliquotaIntra = value; }
        }

        [
            TFieldAttributeGridDisplay("FCP", 100),
            TFieldAttributeData(6, false),
            TFieldAttributeFormat("0.00", "!00000000,00")
        ]
        private double m_Fcp;
        public double fcp
        {
            get { return this.m_Fcp; }
            set { this.m_Fcp = value; }
        }

        public override string ToString()
        {
            return this.m_IdEstado.ToString();
        }
	}
}
