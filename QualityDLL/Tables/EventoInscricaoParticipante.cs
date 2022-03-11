using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EventoInscricaoParticipante")]
	public class EventoInscricaoParticipante: TTableBase
	{
		[TColumn("idEventoInscricaoParticipante", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEventoInscricaoParticipante = new TFieldInteger();
		public TFieldInteger idEventoInscricaoParticipante
		{
			get{return this.m_idEventoInscricaoParticipante;}
		}

        [TColumn("dataInscricao", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataInscricao = new TFieldDatetime();
        public TFieldDatetime dataInscricao
        {
            get { return this.m_dataInscricao; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        [TColumn("dataChegada", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataChegada = new TFieldDatetime();
        public TFieldDatetime dataChegada
        {
            get { return this.m_dataChegada; }
        }

        [TColumn("dataSaida", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataSaida = new TFieldDatetime();
        public TFieldDatetime dataSaida
        {
            get { return this.m_dataSaida; }
        }

        [TColumn("quantidadePernoite", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_quantidadePernoite = new TFieldInteger();
        public TFieldInteger quantidadePernoite
        {
            get { return this.m_quantidadePernoite; }
        }

        [TColumn("confirmado", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_confirmado = new TFieldBoolean();
        public TFieldBoolean confirmado
        {
            get { return this.m_confirmado; }
        }

        [TColumn("valorApartamento", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorApartamento = new TFieldDouble();
        public TFieldDouble valorApartamento
        {
            get { return this.m_valorApartamento; }
        }

        [TColumn("valorRefeicaoExtra", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorRefeicaoExtra = new TFieldDouble();
        public TFieldDouble valorRefeicaoExtra
        {
            get { return this.m_valorRefeicaoExtra; }
        }

        [TColumn("valorEvento", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorEvento = new TFieldDouble();
        public TFieldDouble valorEvento
        {
            get { return this.m_valorEvento; }
        }

        [TColumn("valorAcrescimo", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorAcrescimo = new TFieldDouble();
        public TFieldDouble valorAcrescimo
        {
            get { return this.m_valorAcrescimo; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [TColumn("funcaoConvidado", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_funcaoConvidado = new TFieldString();
        public TFieldString funcaoConvidado
        {
            get { return this.m_funcaoConvidado; }
        }

        [TColumn("vooNumeroChegada", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_vooNumeroChegada = new TFieldString();
        public TFieldString vooNumeroChegada
        {
            get { return this.m_vooNumeroChegada; }
        }

        [TColumn("vooNumeroSaida", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_vooNumeroSaida = new TFieldString();
        public TFieldString vooNumeroSaida
        {
            get { return this.m_vooNumeroSaida; }
        }

        [TColumn("vooDataHorarioChegada", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_vooDataHorarioChegada = new TFieldDatetime();
        public TFieldDatetime vooDataHorarioChegada
        {
            get { return this.m_vooDataHorarioChegada; }
        }

        [TColumn("vooDataHorarioSaida", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_vooDataHorarioSaida = new TFieldDatetime();
        public TFieldDatetime vooDataHorarioSaida
        {
            get { return this.m_vooDataHorarioSaida; }
        }

        [TColumn("vooETicketChegada", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_vooETicketChegada = new TFieldString();
        public TFieldString vooETicketChegada
        {
            get { return this.m_vooETicketChegada; }
        }

        [TColumn("vooETicketSaida", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_vooETicketSaida = new TFieldString();
        public TFieldString vooETicketSaida
        {
            get { return this.m_vooETicketSaida; }
        }


        [
           TColumn("idEventoInscricao", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEventoInscricao->idEventoInscricao" })
        ]
        private EventoInscricao m_idEventoInscricao = null;
        public EventoInscricao eventoInscricao
        {
            get
            {
                if (this.m_idEventoInscricao == null)
                {
                    this.m_idEventoInscricao = new EventoInscricao();

                    foreach (TJoin attribute in this.m_idEventoInscricao.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idEventoInscricao.connectionString = this.connectionString;
                            this.m_idEventoInscricao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEventoInscricao.selfFill();

                return this.m_idEventoInscricao;
            }
        }

        [
           TColumn("idEmpresaRelacionamentoHotel", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEmpresaRelacionamentoHotel->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamentoHotel = null;
        public EmpresaRelacionamento empresaRelacionamentoHotel
        {
            get
            {
                if (this.m_idEmpresaRelacionamentoHotel == null)
                {
                    this.m_idEmpresaRelacionamentoHotel = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamentoHotel.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idEmpresaRelacionamentoHotel.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamentoHotel.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamentoHotel.selfFill();

                return this.m_idEmpresaRelacionamentoHotel;
            }
        }

        [
           TColumn("idEmpresaRelacionamentoParticipante", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEmpresaRelacionamentoParticipante->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamentoParticipante = null;
        public EmpresaRelacionamento empresaRelacionamentoParticipante
        {
            get
            {
                if (this.m_idEmpresaRelacionamentoParticipante == null)
                {
                    this.m_idEmpresaRelacionamentoParticipante = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamentoParticipante.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idEmpresaRelacionamentoParticipante.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamentoParticipante.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamentoParticipante.selfFill();

                return this.m_idEmpresaRelacionamentoParticipante;
            }
        }

        

    }
}
