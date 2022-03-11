using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ParametroBoletoNossoNumero")]
	public class ParametroBoletoNossoNumero: TTableBase
	{
		[TColumn("idParametroBoletoNossoNumero", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idParametroBoletoNossoNumero = new TFieldInteger();
		public TFieldInteger idParametroBoletoNossoNumero
		{
			get{return this.m_idParametroBoletoNossoNumero;}
		}

		[TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataInicio = new TFieldDatetime();
		public TFieldDatetime dataInicio
		{
			get { return this.m_dataInicio; }
		}

		[TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataFim = new TFieldDatetime();
		public TFieldDatetime dataFim
		{
			get { return this.m_dataFim; }
		}

		[TColumn("numeroInicial", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldBigInteger m_numeroInicial = new TFieldBigInteger();
		public TFieldBigInteger numeroInicial
		{
			get{return this.m_numeroInicial;}
		}

		[TColumn("numeroFinal", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldBigInteger m_numeroFinal = new TFieldBigInteger();
		public TFieldBigInteger numeroFinal
		{
			get{return this.m_numeroFinal;}
		}

		[TColumn("ativo", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_ativo = new TFieldBoolean();
		public TFieldBoolean ativo
		{
			get{return this.m_ativo;}
		}

		[
			TColumn("idParametroBoleto", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idParametroBoleto->idParametroBoleto"})
		]
		private ParametroBoleto m_idParametroBoleto = null;
		public ParametroBoleto parametroBoleto
		{
			get
			{
				if(this.m_idParametroBoleto == null)
				{
                    this.m_idParametroBoleto = new ParametroBoleto();

					foreach (TJoin attribute in this.m_idParametroBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idParametroBoleto.connectionString = this.connectionString;
							this.m_idParametroBoleto.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idParametroBoleto.selfFill();

				return this.m_idParametroBoleto;
			}
		}
	}
}
