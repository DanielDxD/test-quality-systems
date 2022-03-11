using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("FornecedorLancamentoContabil")]
	public class FornecedorLancamentoContabil: TTableBase
	{
		[TColumn("idFornecedorLancamentoContabil", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idFornecedorLancamentoContabil = new TFieldInteger();
		public TFieldInteger idFornecedorLancamentoContabil
		{
			get{return this.m_idFornecedorLancamentoContabil;}
		}

		[TColumn("fator", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_fator = new TFieldDouble();
		public TFieldDouble fator
		{
			get{return this.m_fator;}
		}

		[
			TColumn("idFornecedor", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idFornecedor->idFornecedor"})
		]
		private Fornecedor m_idFornecedor = null;
		public Fornecedor fornecedor
		{
			get
			{
				if(this.m_idFornecedor == null)
				{
					this.m_idFornecedor = new Fornecedor();

					foreach (TJoin attribute in this.m_idFornecedor.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idFornecedor.connectionString = this.connectionString;
							this.m_idFornecedor.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idFornecedor.selfFill();

				return this.m_idFornecedor;
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
