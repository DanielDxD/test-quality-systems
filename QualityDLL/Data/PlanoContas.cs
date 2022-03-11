using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class PlanoContas: Base
	{
		public PlanoContas(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true)

        ]
        private int m_IdPlanoContas;
		public int idPlanoContas
		{
			get{return this.m_IdPlanoContas;}
			set{this.m_IdPlanoContas = value;}
		}

        [
            TFieldAttributeGridDisplay("Analíco/Sintético", 130),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;A_Analítico;S_Sintético")
        ]
        private String m_AnaliticoSintetico;
		public String analiticoSintetico
		{
			get{return this.m_AnaliticoSintetico;}
			set{this.m_AnaliticoSintetico = value;}
		}

        [
            TFieldAttributeGridDisplay("Código Contábil", 140),
            TFieldAttributeData(40, true),
            TFieldAttributeFormat("", "#currentBusiness.mascaraCodigoContabil")
        ]
        private String m_CodigoContabil;
		public String codigoContabil
		{
			get{return this.m_CodigoContabil;}
			set{this.m_CodigoContabil = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 250),
            TFieldAttributeData(100, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Cod. Reduzido", 120),
            TFieldAttributeData(20, false)
        ]
        private String m_CodigoContabilReduzido;
        public String codigoContabilReduzido
        {
            get { return this.m_CodigoContabilReduzido; }
            set { this.m_CodigoContabilReduzido = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        public override string ToString()
        {
            return this.idPlanoContas.ToString();
        }
	}
}
