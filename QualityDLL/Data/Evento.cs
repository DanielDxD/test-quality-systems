using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Evento: Base
	{
		public Evento(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdEvento;
		public int idEvento
		{
			get{return this.m_IdEvento;}
			set{this.m_IdEvento = value;}
		}

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("Descrição", 270)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao; }
			set{this.m_Descricao = value;}
		}

        private DateTime m_periodoEventoInicio;
        public DateTime periodoEventoInicio
        {
            get { return this.m_periodoEventoInicio; }
            set { this.m_periodoEventoInicio = value; }
        }

        private DateTime m_periodoEventoFim;
        public DateTime periodoEventoFim
        {
            get { return this.m_periodoEventoFim; }
            set { this.m_periodoEventoFim = value; }
        }

        private DateTime m_periodoInscricaoInicio;
        public DateTime periodoInscricaoInicio
        {
            get { return this.m_periodoInscricaoInicio; }
            set { this.m_periodoInscricaoInicio = value; }
        }

        private DateTime m_periodoInscricaoFim;
        public DateTime periodoInscricaoFim
        {
            get { return this.m_periodoInscricaoFim; }
            set { this.m_periodoInscricaoFim = value; }
        }

        private Double m_valorExtra;
        public Double valorExtra
        {
            get { return this.m_valorExtra; }
            set { this.m_valorExtra = value; }
        }

        private int m_quantidadePernoite;
        public int quantidadePernoite
        {
            get { return this.m_quantidadePernoite; }
            set { this.m_quantidadePernoite = value; }
        }
        private EmpresaRelacionamento m_IdEmpresaRelacionamento;
        public EmpresaRelacionamento empresaRelacionamentoHotel
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        private int m_IdNaturezaOperacao;
        public int idNaturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        public override string ToString()
        {
            return this.m_IdEvento.ToString();
        }
	}
}
