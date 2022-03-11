using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("BoletoItem")]
	public class BoletoItem: TTableBase
	{
		[TColumn("idBoletoItem", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idBoletoItem = new TFieldInteger();
		public TFieldInteger idBoletoItem
		{
			get{return this.m_idBoletoItem;}
		}

		[
			TColumn("idBoleto", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idBoleto->idBoleto" })
		]
		private Boleto m_idBoleto = null;
		public Boleto boleto
		{
			get
			{
				if (this.m_idBoleto == null)
				{
					this.m_idBoleto = new Boleto();

					foreach (TJoin attribute in this.m_idBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idBoleto.connectionString = this.connectionString;
							this.m_idBoleto.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idBoleto.selfFill();

				return this.m_idBoleto;
			}
		}

		[
			TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idContasAReceber->idContasAReceber" })
		]
		private ContasAReceber m_idContasAReceber = null;
		public ContasAReceber contasAReceber
		{
			get
			{
				if (this.m_idContasAReceber == null)
				{
					this.m_idContasAReceber = new ContasAReceber();

					foreach (TJoin attribute in this.m_idContasAReceber.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idContasAReceber.connectionString = this.connectionString;
							this.m_idContasAReceber.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idContasAReceber.selfFill();

				return this.m_idContasAReceber;
			}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get { return this.m_valor; }
		}

		[TColumn("juros", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_juros = new TFieldDouble();
		public TFieldDouble juros
		{
			get { return this.m_juros; }
		}

		[TColumn("multa", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_multa = new TFieldDouble();
		public TFieldDouble multa
		{
			get { return this.m_multa; }
		}

	}
}
