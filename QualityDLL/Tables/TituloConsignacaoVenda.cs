using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TituloConsignacaoVenda")]
	public class TituloConsignacaoVenda: TTableBase
	{
		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("valorComissao", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valorComissao = new TFieldDouble();
		public TFieldDouble valorComissao
		{
			get{return this.m_valorComissao;}
		}

		[TColumn("dataVenda", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataVenda = new TFieldDatetime();
		public TFieldDatetime dataVenda
		{
			get{return this.m_dataVenda;}
		}

		[
			TColumn("idTituloConsignacaoVenda", System.Data.SqlDbType.BigInt, true, false),
			TJoin(new String[]{"idTituloConsignacaoVenda->idTituloConsignacao"})
		]
		private TituloConsignacao m_idTituloConsignacaoVenda = null;
		public TituloConsignacao tituloConsignacaoVenda
		{
			get
			{
				if(this.m_idTituloConsignacaoVenda == null)
				{
                    this.m_idTituloConsignacaoVenda = new TituloConsignacao();

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
			TList(typeof(TituloConsignacaoVendaPagto)),
			TJoin(new String[]{"idTituloConsignacaoVenda->idTituloConsignacaoVenda"})
		]
		private Object m_TituloConsignacaoVendaPagtos = null;
		public System.Collections.Generic.List<TituloConsignacaoVendaPagto> tituloConsignacaoVendaPagtos
		{
			get
			{
				if(this.m_TituloConsignacaoVendaPagtos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(TituloConsignacaoVendaPagto) }
						).IsInstanceOfType(this.m_TituloConsignacaoVendaPagtos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendaPagtos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendaPagtos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendaPagtos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendaPagtos)[i]);

						this.m_TituloConsignacaoVendaPagtos = em.list(typeof(TituloConsignacaoVendaPagto), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<TituloConsignacaoVendaPagto>)this.m_TituloConsignacaoVendaPagtos;
			}
		}
	}
}
