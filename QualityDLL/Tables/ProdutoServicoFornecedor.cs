using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ProdutoServicoFornecedor")]
	public class ProdutoServicoFornecedor: TTableBase
	{
		[TColumn("idProdutoServicoFornecedor", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idProdutoServicoFornecedor = new TFieldInteger();
		public TFieldInteger idProdutoServicoFornecedor
		{
			get{return this.m_idProdutoServicoFornecedor;}
		}

		[TColumn("prazoEntrega", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_prazoEntrega = new TFieldDouble();
		public TFieldDouble prazoEntrega
		{
			get{return this.m_prazoEntrega;}
		}

		[TColumn("dataUltimaCompra", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataUltimaCompra = new TFieldDatetime();
		public TFieldDatetime dataUltimaCompra
		{
			get{return this.m_dataUltimaCompra;}
		}

		[TColumn("custoUltimaCompra", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_custoUltimaCompra = new TFieldDouble();
		public TFieldDouble custoUltimaCompra
		{
			get{return this.m_custoUltimaCompra;}
		}

		[TColumn("codigoNfe", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoNfe = new TFieldString();
		public TFieldString codigoNfe
		{
			get { return this.m_codigoNfe; }
		}

		[
            TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
                    ]
        
        private TFieldInteger m_idProdutoServico = new TFieldInteger();
        public TFieldInteger idProdutoServico
		{
			get {return  this.m_idProdutoServico;}
        }

        [TJoin(new String[] { "idProdutoServico->idProdutoServico" })]
        private ProdutoServico m_idProdutoServicoClass = null;
        public ProdutoServico produtoServico
        {
            get
            {
                if (this.m_idProdutoServicoClass == null)
                {
                    this.m_idProdutoServicoClass = new ProdutoServico();

                    foreach (TJoin attribute in this.m_idProdutoServicoClass.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idProdutoServicoClass.connectionString = this.connectionString;
                            this.m_idProdutoServicoClass.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idProdutoServicoClass.selfFill();

                return this.m_idProdutoServicoClass;
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
