using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PedidoCompraServico")]
	public class PedidoCompra: TTableBase
	{
		[TColumn("idPedidoCompra", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPedidoCompra = new TFieldInteger();
		public TFieldInteger idPedidoCompra
		{
			get{return this.m_idPedidoCompra;}
		}

        [TColumn("dataPedido", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataPedido = new TFieldDatetime();
        public TFieldDatetime dataPedido
        {
            get { return this.m_dataPedido; }
        }

        [TColumn("dataPrevisaoPagamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataPrevisaoPagamento = new TFieldDatetime();
        public TFieldDatetime dataPrevisaoPagamento
        {
            get { return this.m_dataPrevisaoPagamento; }
        }

        [TColumn("dataAprovacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataAprovacao = new TFieldDatetime();
        public TFieldDatetime dataAprovacao
        {
            get { return this.m_dataAprovacao; }
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

        [TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idNotaFiscal = new TFieldInteger();
        public TFieldInteger idNotaFiscal
        {
            get { return this.m_idNotaFiscal; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [
         TColumn("idFornecedor", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idFornecedor->idFornecedor" })
        ]
        private Fornecedor m_idFornecedor = null;
        public Fornecedor fornecedor
        {
            get
            {
                if (this.m_idFornecedor == null)
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
         //TColumn("idAprovador", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idAprovador->idFuncionario" })
        ]
        private Funcionario m_IdAprovadorFuncionario = null;
        public Funcionario aprovador
        {
            get
            {
                if (this.m_IdAprovadorFuncionario == null)
                {
                    this.m_IdAprovadorFuncionario = new Funcionario();

                    foreach (TJoin attribute in this.m_IdAprovadorFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdAprovadorFuncionario.connectionString = this.connectionString;
                            this.m_IdAprovadorFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdAprovadorFuncionario.selfFill();

                return this.m_IdAprovadorFuncionario;
            }
        }

        [
         //TColumn("idComprador", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idComprador->idFuncionario" })
        ]
        private Funcionario m_IdCompradorFuncionario = null;
        public Funcionario comprador
        {
            get
            {
                if (this.m_IdCompradorFuncionario == null)
                {
                    this.m_IdCompradorFuncionario = new Funcionario();

                    foreach (TJoin attribute in this.m_IdCompradorFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCompradorFuncionario.connectionString = this.connectionString;
                            this.m_IdCompradorFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdCompradorFuncionario.selfFill();

                return this.m_IdCompradorFuncionario;
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

		[TColumn("idAprovador", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idAprovador = new TFieldInteger();
        public TFieldInteger idAprovador
		{
			get{ return this.m_idAprovador;}
        }

        [TColumn("idComprador", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idComprador = new TFieldInteger();
        public TFieldInteger idComprador
        {
            get { return this.m_idComprador; }
        }

        [TColumn("idRequisicaoCompra", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idRequisicaoCompra = new TFieldInteger();
        public TFieldInteger idRequisicaoCompra
		{
			get{return  this.m_idRequisicaoCompra;}
        }

		[
			TList(typeof(PedidoCompraProdutoServico)),
			TJoin(new String[]{"idPedidoCompra->idPedidoCompra"})
		]
		private Object m_PedidoCompraProdutoServicos = null;
		public System.Collections.Generic.List<PedidoCompraProdutoServico> pedidoCompraProdutoServicos
		{
			get
			{
				if(this.m_PedidoCompraProdutoServicos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PedidoCompraProdutoServico) }
						).IsInstanceOfType(this.m_PedidoCompraProdutoServicos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PedidoCompraProdutoServicos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PedidoCompraProdutoServicos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PedidoCompraProdutoServicos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PedidoCompraProdutoServicos)[i]);

						this.m_PedidoCompraProdutoServicos = em.list(typeof(PedidoCompraProdutoServico), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PedidoCompraProdutoServico>)this.m_PedidoCompraProdutoServicos;
			}
		}

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }
    }
}
