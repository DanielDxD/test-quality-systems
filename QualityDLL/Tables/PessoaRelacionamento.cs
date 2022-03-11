using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaRelacionamento")]
	public class PessoaRelacionamento: TTableBase
	{
		[TColumn("idPessoaRelacionamento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPessoaRelacionamento = new TFieldInteger();
		public TFieldInteger idPessoaRelacionamento
		{
			get{return this.m_idPessoaRelacionamento;}
		}

		[TColumn("nome", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_nome = new TFieldString();
		public TFieldString nome
		{
			get{return this.m_nome;}
		}

		[TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataInicio = new TFieldDatetime();
		public TFieldDatetime dataInicio
		{
			get{return this.m_dataInicio;}
		}

		[TColumn("dataTermino", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataTermino = new TFieldDatetime();
		public TFieldDatetime dataTermino
		{
			get{return this.m_dataTermino;}
		}

		[
			TColumn("idPessoa", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoa->idPessoa"})
		]
		private Pessoa m_idPessoa = null;
		public Pessoa pessoa
		{
			get
			{
				if(this.m_idPessoa == null)
				{
					this.m_idPessoa = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoa.connectionString = this.connectionString;
							this.m_idPessoa.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoa.selfFill();

				return this.m_idPessoa;
			}
		}

		[
			TColumn("idTipoRelacionamento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoRelacionamento->idTipoRelacionamento"})
		]
		private TipoRelacionamento m_idTipoRelacionamento = null;
		public TipoRelacionamento tipoRelacionamento
		{
			get
			{
				if(this.m_idTipoRelacionamento == null)
				{
					this.m_idTipoRelacionamento = new TipoRelacionamento();

					foreach (TJoin attribute in this.m_idTipoRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoRelacionamento.connectionString = this.connectionString;
							this.m_idTipoRelacionamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoRelacionamento.selfFill();

				return this.m_idTipoRelacionamento;
			}
		}

		[
			TColumn("idPessoaRelacionada", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoaRelacionada->idPessoa"})
		]
		private Pessoa m_idPessoaRelacionada = null;
		public Pessoa pessoaRelacionada
		{
			get
			{
				if(this.m_idPessoaRelacionada == null)
				{
                    this.m_idPessoaRelacionada = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoaRelacionada.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaRelacionada.connectionString = this.connectionString;
							this.m_idPessoaRelacionada.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaRelacionada.selfFill();

				return this.m_idPessoaRelacionada;
			}
		}
	}
}
