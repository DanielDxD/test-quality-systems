using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoCompra")]
	public class RequisicaoCompra: TTableBase
	{
		[TColumn("idRequisicaoCompra", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoCompra = new TFieldInteger();
		public TFieldInteger idRequisicaoCompra
		{
			get{return this.m_idRequisicaoCompra;}
		}

		[TColumn("dataRequisicao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataRequisicao = new TFieldDatetime();
		public TFieldDatetime dataRequisicao
		{
			get{return this.m_dataRequisicao;}
		}

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

		[
			TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idDepartamento->idDepartamento"})
		]
		private Departamento m_idDepartamento = null;
		public Departamento departamento
		{
			get
			{
				if(this.m_idDepartamento == null)
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

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

		[
			TList(typeof(PedidoCompra)),
			TJoin(new String[]{"idRequisicaoCompra->idRequisicaoCompra"})
		]
		private Object m_PedidoCompras = null;
		public System.Collections.Generic.List<PedidoCompra> pedidoCompras
		{
			get
			{
				if(this.m_PedidoCompras != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PedidoCompra) }
						).IsInstanceOfType(this.m_PedidoCompras)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PedidoCompras)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PedidoCompras).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PedidoCompras).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PedidoCompras)[i]);

						this.m_PedidoCompras = em.list(typeof(PedidoCompra), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PedidoCompra>)this.m_PedidoCompras;
			}
		}

		[
			TList(typeof(RequisicaoCompraProdutoServico)),
			TJoin(new String[]{"idRequisicaoCompra->idRequisicaoCompra"})
		]
		private Object m_RequisicaoCompraProdutoServicos = null;
		public System.Collections.Generic.List<RequisicaoCompraProdutoServico> requisicaoCompraProdutoServicos
		{
			get
			{
				if(this.m_RequisicaoCompraProdutoServicos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(RequisicaoCompraProdutoServico) }
						).IsInstanceOfType(this.m_RequisicaoCompraProdutoServicos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraProdutoServicos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraProdutoServicos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraProdutoServicos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraProdutoServicos)[i]);

						this.m_RequisicaoCompraProdutoServicos = em.list(typeof(RequisicaoCompraProdutoServico), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<RequisicaoCompraProdutoServico>)this.m_RequisicaoCompraProdutoServicos;
			}
		}

		[
			TList(typeof(RequisicaoCompraSituacao)),
			TJoin(new String[]{"idRequisicaoCompra->idRequisicaoCompra"})
		]
		private Object m_RequisicaoCompraSituacaos = null;
		public System.Collections.Generic.List<RequisicaoCompraSituacao> requisicaoCompraSituacaos
		{
			get
			{
				if(this.m_RequisicaoCompraSituacaos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(RequisicaoCompraSituacao) }
						).IsInstanceOfType(this.m_RequisicaoCompraSituacaos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraSituacaos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraSituacaos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraSituacaos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCompraSituacaos)[i]);

						this.m_RequisicaoCompraSituacaos = em.list(typeof(RequisicaoCompraSituacao), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<RequisicaoCompraSituacao>)this.m_RequisicaoCompraSituacaos;
			}
		}

		[
			TList(typeof(RequisicaoCotacao)),
			TJoin(new String[]{"idRequisicaoCompra->idRequisicaoCompra"})
		]
		private Object m_RequisicaoCotacaos = null;
		public System.Collections.Generic.List<RequisicaoCotacao> requisicaoCotacaos
		{
			get
			{
				if(this.m_RequisicaoCotacaos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(RequisicaoCotacao) }
						).IsInstanceOfType(this.m_RequisicaoCotacaos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoCotacaos)[i]);

						this.m_RequisicaoCotacaos = em.list(typeof(RequisicaoCotacao), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<RequisicaoCotacao>)this.m_RequisicaoCotacaos;
			}
		}
	}
}
