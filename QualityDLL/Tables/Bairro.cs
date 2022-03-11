using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Bairro")]
	public class Bairro: TTableBase
	{
		[TColumn("idBairro", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idBairro = new TFieldInteger();
		public TFieldInteger idBairro
		{
			get{return this.m_idBairro;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
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
