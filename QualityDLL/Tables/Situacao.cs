using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Situacao")]
	public class Situacao: TTableBase
	{
		[TColumn("idSituacao", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idSituacao = new TFieldInteger();
		public TFieldInteger idSituacao
		{
			get{return this.m_idSituacao;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[
			TColumn("idTipoSituacao", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idTipoSituacao->idTipoSituacao" })
		]
		private TipoSituacao m_IdTipoSituacao = null;
		public TipoSituacao tipoSituacao
		{
			get
			{
				if (this.m_IdTipoSituacao == null)
				{
					this.m_IdTipoSituacao = new TipoSituacao();

					foreach (TJoin attribute in this.m_IdTipoSituacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_IdTipoSituacao.connectionString = this.connectionString;
							this.m_IdTipoSituacao.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_IdTipoSituacao.selfFill();

				return this.m_IdTipoSituacao;
			}
		}
	}
}
