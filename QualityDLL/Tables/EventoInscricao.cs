using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EventoInscricao")]
	public class EventoInscricao: TTableBase
	{
		[TColumn("idEventoInscricao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEventoInscricao = new TFieldInteger();
		public TFieldInteger idEventoInscricao
		{
			get{return this.m_idEventoInscricao;}
		}

        [TColumn("dataInscricao", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataInscricao = new TFieldDatetime();
        public TFieldDatetime dataInscricao
        {
            get { return this.m_dataInscricao; }
        }        

        [
           TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamento = null;
        public EmpresaRelacionamento empresaRelacionamento
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

        [
           TColumn("idEvento", System.Data.SqlDbType.BigInt, false, false),
           TJoin(new String[] { "idEvento->idEvento" })
        ]
        private Evento m_idEvento = null;
        public Evento evento
        {
            get
            {
                if (this.m_idEvento == null)
                {
                    this.m_idEvento = new Evento();

                    foreach (TJoin attribute in this.m_idEvento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEvento.connectionString = this.connectionString;
                            this.m_idEvento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEvento.selfFill();

                return this.m_idEvento;
            }
        }

    }
}
