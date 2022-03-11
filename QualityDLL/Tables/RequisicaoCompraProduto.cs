using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoCompraProdutoServico")]
	public class RequisicaoCompraProdutoServico: TTableBase
	{
		[TColumn("idRequisicaoCompraProdutoServico", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoCompraProdutoServico = new TFieldInteger();
		public TFieldInteger idRequisicaoCompraProdutoServico
		{
			get{return this.m_idRequisicaoCompraProdutoServico;}
		}

		[TColumn("quantidade", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_quantidade = new TFieldDouble();
		public TFieldDouble quantidade
		{
			get{return this.m_quantidade;}
		}

		[TColumn("idRequisicaoCompra", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idRequisicaoCompra = new TFieldInteger();
        public TFieldInteger idRequisicaoCompra
		{
			get{return this.m_idRequisicaoCompra;}
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
            TColumn("idUnidadeProdutoServico", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idUnidadeProdutoServico->idUnidadeProdutoServico" })
        ]
        private UnidadeProdutoServico m_idUnidadeProdutoServico = null;
        public UnidadeProdutoServico unidadeProdutoServico
        {
            get
            {
                if (this.m_idUnidadeProdutoServico == null)
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
	}
}
