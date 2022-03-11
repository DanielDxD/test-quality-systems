using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PlanoContasSaldo")]
	public class PlanoContasSaldo: TTableBase
	{
		[TColumn("idPlanoContasSaldo", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPlanoContasSaldo = new TFieldInteger();
		public TFieldInteger idPlanoContasSaldo
		{
			get{return this.m_idPlanoContasSaldo;}
		}

		[TColumn("anoMes", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_anoMes = new TFieldInteger();
		public TFieldInteger anoMes
		{
			get{return this.m_anoMes;}
		}

		[TColumn("saldo", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_saldo = new TFieldDouble();
		public TFieldDouble saldo
		{
			get{return this.m_saldo;}
		}

		[
			TColumn("idPlanoContas", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPlanoContas->idPlanoContas"})
		]
		private PlanoContas m_idPlanoContas = null;
		public PlanoContas planoContas
		{
			get
			{
				if(this.m_idPlanoContas == null)
				{
                    this.m_idPlanoContas = new PlanoContas();

					foreach (TJoin attribute in this.m_idPlanoContas.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPlanoContas.connectionString = this.connectionString;
							this.m_idPlanoContas.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPlanoContas.selfFill();

				return this.m_idPlanoContas;
			}
		}
	}
}
