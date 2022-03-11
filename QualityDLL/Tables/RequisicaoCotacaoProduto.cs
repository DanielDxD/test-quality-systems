using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoCotacaoProdutoServico")]
	public class RequisicaoCotacaoProdutoServico: TTableBase
	{
		[TColumn("idRequisicaoCotacaoProdutoServico", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoCotacaoProdutoServico = new TFieldInteger();
		public TFieldInteger idRequisicaoCotacaoProdutoServico
		{
			get{return this.m_idRequisicaoCotacaoProdutoServico;}
		}

		[TColumn("quantidadePedida", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_quantidadePedida = new TFieldDouble();
		public TFieldDouble quantidadePedida
		{
			get{return this.m_quantidadePedida;}
		}


        [TColumn("quantidadeAtendida", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_quantidadeAtendida = new TFieldDouble();
        public TFieldDouble quantidadeAtendida
        {
            get { return this.m_quantidadeAtendida; }
        }

        [TColumn("quantidadeAprovada", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_quantidadeAprovada = new TFieldDouble();
        public TFieldDouble quantidadeAprovada
        {
            get { return this.m_quantidadeAprovada; }
        }
        
        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("idRequisicaoCotacao", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idRequisicaoCotacao = new TFieldInteger();
        public TFieldInteger idRequisicaoCotacao
		{
			get{return this.m_idRequisicaoCotacao;}
        }

		[TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false)]
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
