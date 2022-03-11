using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class PrevisaoOrcamentaria: Base
	{
		public PrevisaoOrcamentaria(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPrevisaoOrcamentaria;
		public int idPrevisaoOrcamentaria
		{
			get{return this.m_IdPrevisaoOrcamentaria;}
			set{this.m_IdPrevisaoOrcamentaria = value;}
		}

        [
            TFieldAttributeGridDisplay("Data", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
		private String m_DataReferencia;
		public String dataReferencia
		{
			get{return this.m_DataReferencia; }
			set{this.m_DataReferencia = value;}
        }

        [
            TFieldAttributeGridDisplay("Valor", 95),
            TFieldAttributeFormat("C2", "")
        ]
        private double m_Valor;
		public double valor
		{
			get{return this.m_Valor; }
			set{this.m_Valor = value;}
		}

        [
            TFieldAttributeGridDisplay("Natureza de Operação", 200),
            TFieldAttributeSubfield("idNaturezaOperacao:descricao")
        ]
        private NaturezaOperacao m_IdNaturezaOperacao;
		public NaturezaOperacao naturezaOperacao
		{
			get{return this.m_IdNaturezaOperacao; }
			set{this.m_IdNaturezaOperacao = value;}
		}

        [
            TFieldAttributeGridDisplay("Departamento", 200),
            TFieldAttributeSubfield("idDepartamento:descricao")
        ]
        private Departamento m_IdDepartamento;
		public Departamento departamento
		{
			get{return this.m_IdDepartamento; }
			set{this.m_IdDepartamento = value;}
		}        

        public override string ToString()
        {
            return this.m_IdPrevisaoOrcamentaria.ToString();
        }
	}
}
