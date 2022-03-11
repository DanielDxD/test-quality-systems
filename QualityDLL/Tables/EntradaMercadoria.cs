using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EntradaMercadoria")]
	public class EntradaMercadoria: TTableBase
	{
		[TColumn("idEntradaMercadoria", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEntradaMercadoria = new TFieldInteger();
		public TFieldInteger idEntradaMercadoria
		{
			get{return this.m_idEntradaMercadoria;}
		}

		[TColumn("dataEntrada", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataEntrada = new TFieldDatetime();
		public TFieldDatetime dataEntrada
		{
			get{return this.m_dataEntrada;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("dataVencimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataVencimento = new TFieldDatetime();
		public TFieldDatetime dataVencimento
		{
			get{return this.m_dataVencimento;}
		}

		[TColumn("idPedidoCompra", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idPedidoCompra = new TFieldInteger();
        public TFieldInteger idPedidoCompra
		{
			get{return this.m_idPedidoCompra;}
        }

        [TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idNotaFiscal = new TFieldInteger();
        public TFieldInteger idNotaFiscal
        {
            get { return this.m_idNotaFiscal; }
        }

        [
			TColumn("idFornecedor", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idFornecedor->idFornecedor"})
		]
		private Fornecedor m_idFornecedor = null;
		public Fornecedor fornecedor
		{
			get
			{
				if(this.m_idFornecedor == null)
				{
					this.m_idFornecedor = new Fornecedor();

					foreach (TJoin attribute in this.m_idFornecedor.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idFornecedor.connectionString = this.connectionString;
							this.m_idFornecedor.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idFornecedor.selfFill();

				return this.m_idFornecedor;
			}
		}

        [
            TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_idDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_idDepartamento == null)
                {
                    this.m_idDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_idDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDepartamento.connectionString = this.connectionString;
                            this.m_idDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDepartamento.selfFill();

                return this.m_idDepartamento;
            }
        }

        [
			TColumn("idCondicaoPagamento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idCondicaoPagamento->idCondicaoPagamento"})
		]
		private CondicaoPagamento m_idCondicaoPagamento = null;
		public CondicaoPagamento condicaoPagamento
		{
			get
			{
				if(this.m_idCondicaoPagamento == null)
				{
                    this.m_idCondicaoPagamento = new CondicaoPagamento();

					foreach (TJoin attribute in this.m_idCondicaoPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCondicaoPagamento.connectionString = this.connectionString;
							this.m_idCondicaoPagamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCondicaoPagamento.selfFill();

				return this.m_idCondicaoPagamento;
			}
		}

		[
			TList(typeof(EntradaMercadoriaItem)),
			TJoin(new String[]{"idEntradaMercadoria->idEntradaMercadoria"})
		]
		private Object m_EntradaMercadoriaItems = null;
		public System.Collections.Generic.List<EntradaMercadoriaItem> entradaMercadoriaItems
		{
			get
			{
				if(this.m_EntradaMercadoriaItems != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(EntradaMercadoriaItem) }
						).IsInstanceOfType(this.m_EntradaMercadoriaItems)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_EntradaMercadoriaItems)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_EntradaMercadoriaItems).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_EntradaMercadoriaItems).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_EntradaMercadoriaItems)[i]);

						this.m_EntradaMercadoriaItems = em.list(typeof(EntradaMercadoriaItem), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<EntradaMercadoriaItem>)this.m_EntradaMercadoriaItems;
			}
		}
	}
}
