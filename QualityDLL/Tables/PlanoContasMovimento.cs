using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PlanoContasMovimento")]
	public class PlanoContasMovimento: TTableBase
	{
		[TColumn("idPlanoContasMovimento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPlanoContasMovimento = new TFieldInteger();
		public TFieldInteger idPlanoContasMovimento
		{
			get{return this.m_idPlanoContasMovimento;}
		}

		[TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataMovimento = new TFieldDatetime();
		public TFieldDatetime dataMovimento
		{
			get{return this.m_dataMovimento;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("historico", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_historico = new TFieldString();
		public TFieldString historico
		{
			get{return this.m_historico;}
		}

		[
			TColumn("idPlanoContasDebito", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPlanoContasDebito->idPlanoContas"})
		]
		private PlanoContas m_idPlanoContasDebito = null;
		public PlanoContas planoContasDebito
		{
			get
			{
				if(this.m_idPlanoContasDebito == null)
				{
					this.m_idPlanoContasDebito = new PlanoContas();

					foreach (TJoin attribute in this.m_idPlanoContasDebito.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPlanoContasDebito.connectionString = this.connectionString;
							this.m_idPlanoContasDebito.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPlanoContasDebito.selfFill();

				return this.m_idPlanoContasDebito;
			}
		}

		[
			TColumn("idPlanoContasCredito", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPlanoContasCredito->idPlanoContas"})
		]
		private PlanoContas m_idPlanoContasCredito = null;
		public PlanoContas planoContasCredito
		{
			get
			{
				if(this.m_idPlanoContasCredito == null)
				{
                    this.m_idPlanoContasCredito = new PlanoContas();

					foreach (TJoin attribute in this.m_idPlanoContasCredito.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPlanoContasCredito.connectionString = this.connectionString;
							this.m_idPlanoContasCredito.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPlanoContasCredito.selfFill();

				return this.m_idPlanoContasCredito;
			}
		}
	}
}
