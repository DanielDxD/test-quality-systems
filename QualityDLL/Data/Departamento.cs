using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Departamento: Base
	{
		public Departamento(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true)
        ]
        private int m_IdDepartamento;
		public int idDepartamento
		{
			get{return this.m_IdDepartamento;}
			set{this.m_IdDepartamento = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 250),
            TFieldAttributeEditDisplay("Descrição", 250),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Alçada", 120),
            TFieldAttributeEditDisplay("Alçada", 120),
            TFieldAttributeData(15, true),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_Alcada;
		public double alcada
		{
			get{return this.m_Alcada;}
			set{this.m_Alcada = value;}
		}

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        /*[
            TFieldAttributeGridDisplay("Armazém", 100)
        ]*/
        private Boolean m_Armazem;
        public Boolean armazem
        {
            get { return this.m_Armazem; }
            set { this.m_Armazem = value; }
        }

        private int m_IdDepartamentoPai;
        public int idDepartamentoPai
        {
            get { return this.m_IdDepartamentoPai; }
            set { this.m_IdDepartamentoPai = value; }
        }
        
        private PlanoContas m_IdPlanoContas;
        public PlanoContas planoContas
        {
            get { return this.m_IdPlanoContas; }
            set { this.m_IdPlanoContas = value; }
        }

        //idDepartamentoPai
        private Departamento[] m_Departamentos;
        public Departamento[] departamentos
        {
            get { return this.m_Departamentos; }
            set { this.m_Departamentos = value; }
        }

        private String m_Ativo;
        public String ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

        public override string ToString()
        {
            return this.m_IdDepartamento.ToString();
        }
    }
}
