using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TituloSocioLancamentoContabil")]
	public class TituloSocioLancamentoContabil: TTableBase
	{
		[TColumn("idTituloSocioLancamentoContabil", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idTituloSocioLancamentoContabil = new TFieldInteger();
		public TFieldInteger idTituloSocioLancamentoContabil
		{
			get{return this.m_idTituloSocioLancamentoContabil;}
		}

		[TColumn("fator", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_fator = new TFieldDouble();
		public TFieldDouble fator
		{
			get{return this.m_fator;}
		}

		[
			TColumn("idTituloSocio", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idTituloSocio->idTituloSocio"})
		]
		private TituloSocio m_idTituloSocio = null;
		public TituloSocio tituloSocio
		{
			get
			{
				if(this.m_idTituloSocio == null)
				{
					this.m_idTituloSocio = new TituloSocio();

					foreach (TJoin attribute in this.m_idTituloSocio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTituloSocio.connectionString = this.connectionString;
							this.m_idTituloSocio.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTituloSocio.selfFill();

				return this.m_idTituloSocio;
			}
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

		[
			TColumn("idTipoLancamentoContabil", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoLancamentoContabil->idTipoLancamentoContabil"})
		]
		private TipoLancamentoContabil m_idTipoLancamentoContabil = null;
		public TipoLancamentoContabil tipoLancamentoContabil
		{
			get
			{
				if(this.m_idTipoLancamentoContabil == null)
				{
                    this.m_idTipoLancamentoContabil = new TipoLancamentoContabil();

					foreach (TJoin attribute in this.m_idTipoLancamentoContabil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoLancamentoContabil.connectionString = this.connectionString;
							this.m_idTipoLancamentoContabil.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoLancamentoContabil.selfFill();

				return this.m_idTipoLancamentoContabil;
			}
		}
	}
}
