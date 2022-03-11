using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoInternaProdutoServico")]
	public class RequisicaoInternaProdutoServico: TTableBase
	{
		[TColumn("idRequisicaoInternaProdutoServico", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoInternaProdutoServico = new TFieldInteger();
		public TFieldInteger idRequisicaoInternaProdutoServico
		{
			get{return this.m_idRequisicaoInternaProdutoServico;}
		}

		[TColumn("quantidadeSolicitada", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_quantidadeSolicitada = new TFieldDouble();
		public TFieldDouble quantidadeSolicitada
		{
			get{return this.m_quantidadeSolicitada;}
		}

		[TColumn("quantidadeAtendida", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_quantidadeAtendida = new TFieldDouble();
		public TFieldDouble quantidadeAtendida
		{
			get{return this.m_quantidadeAtendida;}
		}

        [TColumn("fator", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_fator = new TFieldDouble();
        public TFieldDouble fator
        {
            get { return this.m_fator; }
        }

        [
			TColumn("idRequisicaoInterna", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idRequisicaoInterna->idRequisicaoInterna"})
		]
		private RequisicaoInterna m_idRequisicaoInterna = null;
		public RequisicaoInterna requisicaoInterna
		{
			get
			{
				if(this.m_idRequisicaoInterna == null)
				{
					this.m_idRequisicaoInterna = new RequisicaoInterna();

					foreach (TJoin attribute in this.m_idRequisicaoInterna.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idRequisicaoInterna.connectionString = this.connectionString;
							this.m_idRequisicaoInterna.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idRequisicaoInterna.selfFill();

				return this.m_idRequisicaoInterna;
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
