using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("AtendimentoPagamento")]
	public class AtendimentoPagamento: TTableBase
	{
		[TColumn("idAtendimentoPagamento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idAtendimentoPagamento = new TFieldInteger();
		public TFieldInteger idAtendimentoPagamento
		{
			get{return this.m_idAtendimentoPagamento;}
		}

		[TColumn("dataPagamento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataPagamento = new TFieldDatetime();
		public TFieldDatetime dataPagamento
		{
			get{return this.m_dataPagamento;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[
			TColumn("idAtendimento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idAtendimento->idAtendimento"})
		]
		private Atendimento m_idAtendimento = null;
		public Atendimento atendimento
		{
			get
			{
				if(this.m_idAtendimento == null)
				{
                    this.m_idAtendimento = new Atendimento();

					foreach (TJoin attribute in this.m_idAtendimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idAtendimento.connectionString = this.connectionString;
							this.m_idAtendimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idAtendimento.selfFill();

				return this.m_idAtendimento;
			}
		}
	}
}
