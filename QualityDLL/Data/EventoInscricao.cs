using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class EventoInscricao: Base
	{
		public EventoInscricao(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdEventoInscricao;
		public int idEventoInscricao
		{
			get{return this.m_IdEventoInscricao;}
			set{this.m_IdEventoInscricao = value;}
		}

        private DateTime m_dataInscricao;
        public DateTime dataInscricao
        {
            get { return this.m_dataInscricao; }
            set { this.m_dataInscricao = value; }
        }


        [
            TFieldAttributeGridDisplay("Nome", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial")
        ]
        private EmpresaRelacionamento m_IdEmpresaRelacionamento;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Evento", 200),
            TFieldAttributeSubfield("idEvento:descricao")
        ]
        private Evento m_IdEvento;
        public Evento evento
        {
            get { return this.m_IdEvento; }
            set { this.m_IdEvento = value; }
        }


        public override string ToString()
        {
            return this.m_IdEventoInscricao.ToString();
        }
	}
}
