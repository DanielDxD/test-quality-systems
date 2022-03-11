using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TituloSocioSituacao: Base
	{
		public TituloSocioSituacao(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdTituloSocioSituacao;
		public int idTituloSocioSituacao
		{
			get{return this.m_IdTituloSocioSituacao;}
			set{this.m_IdTituloSocioSituacao = value;}
		}


        private TituloSocio m_IdTituloSocio;
		public TituloSocio tituloSocio
		{
			get{return this.m_IdTituloSocio;}
			set{this.m_IdTituloSocio = value;}
		}

        [
            TFieldAttributeGridDisplay("Data Início", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataInicio;
		public DateTime dataInicio
		{
			get{return this.m_DataInicio; }
			set{this.m_DataInicio = value;}
        }

        [
            TFieldAttributeGridDisplay("Data Fim", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataFim;
        public DateTime dataFim
        {
            get { return this.m_DataFim; }
            set { this.m_DataFim = value; }
        }

        [
            TFieldAttributeGridDisplay("Situação", 120),
            TFieldAttributeSubfield("idSituacao:descricao")
        ]
        private Situacao m_IdSituacao;
		public Situacao situacao
		{
			get{return this.m_IdSituacao; }
			set{this.m_IdSituacao = value;}
		}

        [
            TFieldAttributeGridDisplay("Observação", 120),
        ]
        private String m_observacao;
        public String observacao
        {
            get { return this.m_observacao; }
            set { this.m_observacao = value; }
        }

        public override string ToString()
        {
            return this.m_IdTituloSocioSituacao.ToString();
        }
    }
}
