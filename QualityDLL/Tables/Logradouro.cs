using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Logradouro")]
	public class Logradouro: TTableBase
	{
		[TColumn("idLogradouro", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idLogradouro = new TFieldInteger();
		public TFieldInteger idLogradouro
		{
			get{return this.m_idLogradouro;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[
			TColumn("idTipoLogradouro", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoLogradouro->idTipoLogradouro"})
		]
		private TipoLogradouro m_idTipoLogradouro = null;
		public TipoLogradouro tipoLogradouro
		{
			get
			{
				if(this.m_idTipoLogradouro == null)
				{
					this.m_idTipoLogradouro = new TipoLogradouro();

					foreach (TJoin attribute in this.m_idTipoLogradouro.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoLogradouro.connectionString = this.connectionString;
							this.m_idTipoLogradouro.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoLogradouro.selfFill();

				return this.m_idTipoLogradouro;
			}
		}

		[
			TColumn("idCidade", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCidade->idCidade"})
		]
		private Cidade m_idCidade = null;
		public Cidade cidade
		{
			get
			{
				if(this.m_idCidade == null)
				{
                    this.m_idCidade = new Cidade();

					foreach (TJoin attribute in this.m_idCidade.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCidade.connectionString = this.connectionString;
							this.m_idCidade.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCidade.selfFill();

				return this.m_idCidade;
			}
		}
	}
}
