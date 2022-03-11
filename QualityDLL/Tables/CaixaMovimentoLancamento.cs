using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("CaixaMovimentoLancamento")]
	public class CaixaMovimentoLancamento: TTableBase
	{
		[TColumn("idCaixaMovimentoLancamento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idCaixaMovimentoLancamento = new TFieldInteger();
		public TFieldInteger idCaixaMovimentoLancamento
		{
			get{return this.m_idCaixaMovimentoLancamento;}
		}

		[
			TColumn("idCaixaMovimento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCaixaMovimento->idCaixaMovimento"})
		]
		private CaixaMovimento m_idCaixaMovimento = null;
		public CaixaMovimento caixaMovimento
		{
			get
			{
				if(this.m_idCaixaMovimento == null)
				{
					this.m_idCaixaMovimento = new CaixaMovimento();

					foreach (TJoin attribute in this.m_idCaixaMovimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCaixaMovimento.connectionString = this.connectionString;
							this.m_idCaixaMovimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCaixaMovimento.selfFill();

				return this.m_idCaixaMovimento;
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

		[
			TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idContasAReceber->idContasAReceber"})
		]
		private ContasAReceber m_idContasAReceber = null;
		public ContasAReceber contasAReceber
		{
			get
			{
				if(this.m_idContasAReceber == null)
				{
                    this.m_idContasAReceber = new ContasAReceber();

					foreach (TJoin attribute in this.m_idContasAReceber.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idContasAReceber.connectionString = this.connectionString;
							this.m_idContasAReceber.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idContasAReceber.selfFill();

				return this.m_idContasAReceber;
			}
		}
	}
}
