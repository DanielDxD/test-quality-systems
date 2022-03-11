using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ProdutoServicoUnidade")]
	public class ProdutoServicoUnidade: TTableBase
	{
		[TColumn("idProdutoServicoUnidade", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idProdutoServicoUnidade = new TFieldInteger();
		public TFieldInteger idProdutoServicoUnidade
		{
			get{return this.m_idProdutoServicoUnidade;}
		}

		[TColumn("fator", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_fator = new TFieldDouble();
		public TFieldDouble fator
		{
			get{return this.m_fator;}
		}

		[
			TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idProdutoServico->idProdutoServico"})
		]
        private TFieldInteger m_idProdutoServico = new TFieldInteger();
        public TFieldInteger idProdutoServico
		{
			get{return this.m_idProdutoServico;}
		}

		[
			TColumn("idUnidadeProdutoServico", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idUnidadeProdutoServico->idUnidadeProdutoServico"})
		]
		private UnidadeProdutoServico m_idUnidadeProdutoServico = null;
		public UnidadeProdutoServico unidadeProdutoServico
		{
			get
			{
				if(this.m_idUnidadeProdutoServico == null)
				{
                    this.m_idUnidadeProdutoServico = new UnidadeProdutoServico();

					foreach (TJoin attribute in this.m_idUnidadeProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idUnidadeProdutoServico.connectionString = this.connectionString;
							this.m_idUnidadeProdutoServico.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idUnidadeProdutoServico.selfFill();

				return this.m_idUnidadeProdutoServico;
			}
		}
	}
}
