using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoCotacao")]
	public class RequisicaoCotacao: TTableBase
	{
		[TColumn("idRequisicaoCotacao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoCotacao = new TFieldInteger();
		public TFieldInteger idRequisicaoCotacao
		{
			get{return this.m_idRequisicaoCotacao;}
        }

        [TColumn("dataCotacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCotacao = new TFieldDatetime();
        public TFieldDatetime dataCotacao
        {
            get { return this.m_dataCotacao; }
        }

        [TColumn("dataPrevisaoPagamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataPrevisaoPagamento = new TFieldDatetime();
        public TFieldDatetime dataPrevisaoPagamento
        {
            get { return this.m_dataPrevisaoPagamento; }
        }

        [TColumn("dataRespostaCotacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataRespostaCotacao = new TFieldDatetime();
        public TFieldDatetime dataRespostaCotacao
        {
            get { return this.m_dataRespostaCotacao; }
        }
        
        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
        }

        [TColumn("valorFrete", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorFrete = new TFieldDouble();
        public TFieldDouble valorFrete
        {
            get { return this.m_valorFrete; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [TColumn("prazoEntrega", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_prazoEntrega = new TFieldString();
		public TFieldString prazoEntrega
		{
			get{return this.m_prazoEntrega;}
		}

		[TColumn("idRequisicaoCompra", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idRequisicaoCompra = new TFieldInteger();
        public TFieldInteger idRequisicaoCompra
		{
			get{return this.m_idRequisicaoCompra;}
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
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
			TList(typeof(RequisicaoCotacaoProdutoServico)),
			TJoin(new String[]{"idRequisicaoCotacao->idRequisicaoCotacao"})
		]
		private Object m_RequisicaoCotacaoProdutoServicos = null;
		public System.Collections.Generic.List<RequisicaoCotacaoProdutoServico> requisicaoCotacaoProdutoServicos
		{
			get
			{
				if(this.m_RequisicaoCotacaoProdutoServicos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(RequisicaoCotacaoProdutoServico) }
						).IsInstanceOfType(this.m_RequisicaoCotacaoProdutoServicos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaoProdutoServicos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaoProdutoServicos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaoProdutoServicos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaoProdutoServicos)[i]);

						this.m_RequisicaoCotacaoProdutoServicos = em.list(typeof(RequisicaoCotacaoProdutoServico), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<RequisicaoCotacaoProdutoServico>)this.m_RequisicaoCotacaoProdutoServicos;
			}
		}
	}
}
