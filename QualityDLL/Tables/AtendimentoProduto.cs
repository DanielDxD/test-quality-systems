using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("AtendimentoProdutoServico")]
	public class AtendimentoProdutoServico: TTableBase
	{
		[TColumn("idAtendimentoProdutoServico", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idAtendimentoProdutoServico = new TFieldInteger();
		public TFieldInteger idAtendimentoProdutoServico
		{
			get{return this.m_idAtendimentoProdutoServico;}
		}

		[
			TColumn("idAtendimento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idAtendimento->idAtendimento"})
		]
		private Atendimento m_idAtendimento = null;
		public Atendimento atendimento
		{
			get
			{
				if(this.m_idAtendimento == null)
				{
					this.m_idAtendimento = new Atendimento();

					foreach (TJoin attribute in this.m_idAtendimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idAtendimento.connectionString = this.connectionString;
							this.m_idAtendimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idAtendimento.selfFill();

				return this.m_idAtendimento;
			}
		}

		[
			TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idProdutoServico->idProdutoServico"})
		]
		private ProdutoServico m_idProdutoServico = null;
		public ProdutoServico produtoServico
		{
			get
			{
				if(this.m_idProdutoServico == null)
				{
                    this.m_idProdutoServico = new ProdutoServico();

					foreach (TJoin attribute in this.m_idProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idProdutoServico.connectionString = this.connectionString;
							this.m_idProdutoServico.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idProdutoServico.selfFill();

				return this.m_idProdutoServico;
			}
		}
	}
}
