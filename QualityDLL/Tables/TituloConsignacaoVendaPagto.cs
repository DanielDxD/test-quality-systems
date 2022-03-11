using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TituloConsignacaoVendaPagto")]
	public class TituloConsignacaoVendaPagto: TTableBase
	{
		[TColumn("idTituloConsignacaoVendaPagto", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idTituloConsignacaoVendaPagto = new TFieldInteger();
		public TFieldInteger idTituloConsignacaoVendaPagto
		{
			get{return this.m_idTituloConsignacaoVendaPagto;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("parcelas", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_parcelas = new TFieldInteger();
		public TFieldInteger parcelas
		{
			get{return this.m_parcelas;}
		}

		[TColumn("vencimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_vencimento = new TFieldDatetime();
		public TFieldDatetime vencimento
		{
			get{return this.m_vencimento;}
		}

		[
			TColumn("idTituloConsignacaoVenda", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idTituloConsignacaoVenda->idTituloConsignacaoVenda"})
		]
		private TituloConsignacaoVenda m_idTituloConsignacaoVenda = null;
		public TituloConsignacaoVenda tituloConsignacaoVenda
		{
			get
			{
				if(this.m_idTituloConsignacaoVenda == null)
				{
					this.m_idTituloConsignacaoVenda = new TituloConsignacaoVenda();

					foreach (TJoin attribute in this.m_idTituloConsignacaoVenda.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTituloConsignacaoVenda.connectionString = this.connectionString;
							this.m_idTituloConsignacaoVenda.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTituloConsignacaoVenda.selfFill();

				return this.m_idTituloConsignacaoVenda;
			}
		}

		[
			TColumn("idFormaPagamento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idFormaPagamento->idFormaPagamento"})
		]
		private FormaPagamento m_idFormaPagamento = null;
		public FormaPagamento formaPagamento
		{
			get
			{
				if(this.m_idFormaPagamento == null)
				{
                    this.m_idFormaPagamento = new FormaPagamento();

					foreach (TJoin attribute in this.m_idFormaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idFormaPagamento.connectionString = this.connectionString;
							this.m_idFormaPagamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idFormaPagamento.selfFill();

				return this.m_idFormaPagamento;
			}
		}
	}
}
