using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Evento")]
	public class Evento: TTableBase
	{
		[TColumn("idEvento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEvento = new TFieldInteger();
		public TFieldInteger idEvento
		{
			get{return this.m_idEvento;}
		}

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("periodoEventoInicio", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_periodoEventoInicio = new TFieldDatetime();
        public TFieldDatetime periodoEventoInicio
        {
            get { return this.m_periodoEventoInicio; }
        }

        [TColumn("periodoEventoFim", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_periodoEventoFim = new TFieldDatetime();
        public TFieldDatetime periodoEventoFim
        {
            get { return this.m_periodoEventoFim; }
        }

        [TColumn("periodoInscricaoInicio", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_periodoInscricaoInicio = new TFieldDatetime();
        public TFieldDatetime periodoInscricaoInicio
        {
            get { return this.m_periodoInscricaoInicio; }
        }

        [TColumn("periodoInscricaoFim", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_periodoInscricaoFim = new TFieldDatetime();
        public TFieldDatetime periodoInscricaoFim
        {
            get { return this.m_periodoInscricaoFim; }
        }

        [
           TColumn("idEmpresaRelacionamentoHotel", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEmpresaRelacionamentoHotel->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamento = null;
        public EmpresaRelacionamento empresaRelacionamentoHotel
        {
            get
            {
                if (this.m_idEmpresaRelacionamento == null)
                {
                    this.m_idEmpresaRelacionamento = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresaRelacionamento.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamento.selfFill();

                return this.m_idEmpresaRelacionamento;
            }
        }

        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idNaturezaOperacao = new TFieldInteger();
        public TFieldInteger idNaturezaOperacao
        {
            get { return this.m_idNaturezaOperacao; }
        }

        [TColumn("quantidadePernoite", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_quantidadePernoite = new TFieldInteger();
        public TFieldInteger quantidadePernoite
        {
            get { return this.m_quantidadePernoite; }
        }

        [TColumn("valorExtra", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorExtra = new TFieldDouble();
        public TFieldDouble valorExtra
        {
            get { return this.m_valorExtra; }
        }

    }
}
