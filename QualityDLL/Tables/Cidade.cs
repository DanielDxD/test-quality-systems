using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Cidade")]
	public class Cidade: TTableBase
	{
		[TColumn("idCidade", System.Data.SqlDbType.BigInt, true, false)]
		private TFieldInteger m_idCidade = new TFieldInteger();
		public TFieldInteger idCidade
		{
			get{return this.m_idCidade;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("codigoIBGE", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldInteger m_codigoIBGE = new TFieldInteger();
		public TFieldInteger codigoIBGE
		{
			get{return this.m_codigoIBGE;}
		}

		[
			TColumn("idEstado", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idEstado->idEstado"})
		]
		private Estado m_idEstado = null;
		public Estado estado
		{
			get
			{
				if(this.m_idEstado == null)
				{
                    this.m_idEstado = new Estado();

					foreach (TJoin attribute in this.m_idEstado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEstado.connectionString = this.connectionString;
							this.m_idEstado.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEstado.selfFill();

				return this.m_idEstado;
			}
		}
	}
}
