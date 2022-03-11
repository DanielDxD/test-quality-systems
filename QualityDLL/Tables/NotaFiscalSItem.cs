using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("NotaFiscalSItem")]
	public class NotaFiscalSItem: TTableBase
	{
		[TColumn("idNotaFiscalSItem", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idNotaFiscalSItem = new TFieldInteger();
		public TFieldInteger idNotaFiscalSItem
		{
			get{return this.m_idNotaFiscalSItem;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("aliquotaIss", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_aliquotaIss = new TFieldDouble();
		public TFieldDouble aliquotaIss
		{
			get{return this.m_aliquotaIss;}
		}

		[TColumn("valorIss", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valorIss = new TFieldDouble();
		public TFieldDouble valorIss
		{
			get{return this.m_valorIss;}
		}

		[
			TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idNotaFiscal->idNotaFiscalS"})
		]
		private NotaFiscalS m_idNotaFiscal = null;
		public NotaFiscalS notaFiscal
		{
			get
			{
				if(this.m_idNotaFiscal == null)
				{
					this.m_idNotaFiscal = new NotaFiscalS();

					foreach (TJoin attribute in this.m_idNotaFiscal.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idNotaFiscal.connectionString = this.connectionString;
							this.m_idNotaFiscal.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idNotaFiscal.selfFill();

				return this.m_idNotaFiscal;
			}
		}

		[
			TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idContasAReceber->idContasAReceber"})
		]
		private ContasAReceber m_idContasAReceber = null;
		public ContasAReceber contasAReceber
		{
			get
			{
				if(this.m_idContasAReceber == null)
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
	}
}
