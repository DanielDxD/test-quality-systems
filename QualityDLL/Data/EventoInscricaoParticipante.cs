using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class EventoInscricaoParticipante: Base
	{
		public EventoInscricaoParticipante(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdEventoInscricaoParticipante;
		public int idEventoInscricaoParticipante
		{
			get{return this.m_IdEventoInscricaoParticipante;}
			set{this.m_IdEventoInscricaoParticipante = value;}
		}

        private DateTime m_dataInscricao;
        public DateTime dataInscricao
        {
            get { return this.m_dataInscricao; }
            set { this.m_dataInscricao = value; }
        }

        private DateTime m_dataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
            set { this.m_dataCancelamento = value; }
        }

        private DateTime m_dataChegada;
        public DateTime dataChegada
        {
            get { return this.m_dataChegada; }
            set { this.m_dataChegada = value; }
        }

        private DateTime m_dataSaida;
        public DateTime dataSaida
        {
            get { return this.m_dataSaida; }
            set { this.m_dataSaida = value; }
        }

        private EventoInscricao m_IdEventoInscricao;
        public EventoInscricao eventoInscricao
        {
            get { return this.m_IdEventoInscricao; }
            set { this.m_IdEventoInscricao = value; }
        }

        private EmpresaRelacionamento m_IdEmpresaRelacionamentoParticipante;
        public EmpresaRelacionamento empresaRelacionamentoParticipante
        {
            get { return this.m_IdEmpresaRelacionamentoParticipante; }
            set { this.m_IdEmpresaRelacionamentoParticipante = value; }
        }

        private EmpresaRelacionamento m_IdEmpresaRelacionamentoHotel;
        public EmpresaRelacionamento empresaRelacionamentoHotel
        {
            get { return this.m_IdEmpresaRelacionamentoHotel; }
            set { this.m_IdEmpresaRelacionamentoHotel = value; }
        }

        
        private int m_quantidadePernoite;
        public int quantidadePernoite
        {
            get { return this.m_quantidadePernoite; }
            set { this.m_quantidadePernoite = value; }
        }

        private bool m_Confirmado;
        public bool confirmado
        {
            get { return this.m_Confirmado; }
            set { this.m_Confirmado = value; }
        }

        private double m_valorApartamento;
        public double valorApartamento
        {
            get { return this.m_valorApartamento; }
            set { this.m_valorApartamento = value; }
        }

        private double m_valorRefeicaoExtra;
        public double valorRefeicaoExtra
        {
            get { return this.m_valorRefeicaoExtra; }
            set { this.m_valorRefeicaoExtra = value; }
        }

        private double m_valorEvento;
        public double valorEvento
        {
            get { return this.m_valorEvento; }
            set { this.m_valorEvento = value; }
        }

        private double m_valorAcrescimo;
        public double valorAcrescimo
        {
            get { return this.m_valorAcrescimo; }
            set { this.m_valorAcrescimo = value; }
        }

        private double m_valorDesconto;
        public double valorDesconto
        {
            get { return this.m_valorDesconto; }
            set { this.m_valorDesconto = value; }
        }

        private string m_observacao;
        public string observacao
        {
            get { return this.m_observacao; }
            set { this.m_observacao = value; }
        }

        private string m_funcaoConvidado;
        public string funcaoConvidado
        {
            get { return this.m_funcaoConvidado; }
            set { this.m_funcaoConvidado = value; }
        }

        private string m_vooNumeroChegada;
        public string vooNumeroChegada
        {
            get { return this.m_vooNumeroChegada; }
            set { this.m_vooNumeroChegada = value; }
        }

        private string m_vooNumeroSaida;
        public string vooNumeroSaida
        {
            get { return this.m_vooNumeroSaida; }
            set { this.m_vooNumeroSaida = value; }
        }

        private DateTime m_vooDataHorarioChegada;
        public DateTime vooDataHorarioChegada
        {
            get { return this.m_vooDataHorarioChegada; }
            set { this.m_vooDataHorarioChegada = value; }
        }

        private DateTime m_vooDataHorarioSaida;
        public DateTime vooDataHorarioSaida
        {
            get { return this.m_vooDataHorarioSaida; }
            set { this.m_vooDataHorarioSaida = value; }
        }

        private string m_vooETicketChegada;
        public string vooETicketChegada
        {
            get { return this.m_vooETicketChegada; }
            set { this.m_vooETicketChegada = value; }
        }

        private string m_vooETicketSaida;
        public string vooETicketSaida
        {
            get { return this.m_vooETicketSaida; }
            set { this.m_vooETicketSaida = value; }
        }

        public override string ToString()
        {
            return this.m_IdEventoInscricaoParticipante.ToString();
        }
	}
}
