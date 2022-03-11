using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EntradaMercadoriaItem")]
	public class EntradaMercadoriaItem: TTableBase
	{
		[TColumn("idEntradaMercadoriaItem", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEntradaMercadoriaItem = new TFieldInteger();
		public TFieldInteger idEntradaMercadoriaItem
		{
			get{return this.m_idEntradaMercadoriaItem;}
		}

		[TColumn("quantidade", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_quantidade = new TFieldDouble();
		public TFieldDouble quantidade
		{
			get{return this.m_quantidade;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("idEntradaMercadoria", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idEntradaMercadoria = new TFieldInteger();
        public TFieldInteger idEntradaMercadoria
		{
			get{return this.m_idEntradaMercadoria;}
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

        [TColumn("dataFabricacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataFabricacao = new TFieldDatetime();
        public TFieldDatetime dataFabricacao
        {
            get { return this.m_dataFabricacao; }
        }

        [TColumn("dataValidade", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataValidade = new TFieldDatetime();
        public TFieldDatetime dataValidade
        {
            get { return this.m_dataValidade; }
        }

        [TColumn("numeroLote", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroLote = new TFieldString();
        public TFieldString numeroLote
        {
            get { return this.m_numeroLote; }
        }
    }
}
