using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("CaixaMovimento")]
	public class CaixaMovimento: TTableBase
	{
		[TColumn("idCaixaMovimento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idCaixaMovimento = new TFieldInteger();
		public TFieldInteger idCaixaMovimento
		{
			get{return this.m_idCaixaMovimento;}
		}

		[TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataMovimento = new TFieldDatetime();
		public TFieldDatetime dataMovimento
		{
			get{return this.m_dataMovimento;}
		}

		[TColumn("recebimentoPagamento", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_recebimentoPagamento = new TFieldString();
		public TFieldString recebimentoPagamento
		{
			get{return this.m_recebimentoPagamento;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("formaPagamento", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_formaPagamento = new TFieldString();
		public TFieldString formaPagamento
		{
			get{return this.m_formaPagamento;}
		}

		[
			TColumn("idCaixa", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCaixa->idCaixa"})
		]
		private Caixa m_idCaixa = null;
		public Caixa caixa
		{
			get
			{
				if(this.m_idCaixa == null)
				{
					this.m_idCaixa = new Caixa();

					foreach (TJoin attribute in this.m_idCaixa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCaixa.connectionString = this.connectionString;
							this.m_idCaixa.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCaixa.selfFill();

				return this.m_idCaixa;
			}
		}

		[
			TColumn("idCliente", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCliente->idEmpresaRelacionamento"})
		]
		private EmpresaRelacionamento m_idCliente = null;
		public EmpresaRelacionamento cliente
		{
			get
			{
				if(this.m_idCliente == null)
				{
                    this.m_idCliente = new EmpresaRelacionamento();

					foreach (TJoin attribute in this.m_idCliente.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCliente.connectionString = this.connectionString;
							this.m_idCliente.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCliente.selfFill();

				return this.m_idCliente;
			}
		}
		[
			TList(typeof(CaixaMovimentoAtendimento)),
			TJoin(new String[]{"idCaixaMovimento->idCaixaMovimento"})
		]
		private Object m_CaixaMovimentoAtendimentos = null;
		public System.Collections.Generic.List<CaixaMovimentoAtendimento> caixaMovimentoAtendimentos
		{
			get
			{
				if(this.m_CaixaMovimentoAtendimentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(CaixaMovimentoAtendimento) }
						).IsInstanceOfType(this.m_CaixaMovimentoAtendimentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoAtendimentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoAtendimentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoAtendimentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoAtendimentos)[i]);

						this.m_CaixaMovimentoAtendimentos = em.list(typeof(CaixaMovimentoAtendimento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<CaixaMovimentoAtendimento>)this.m_CaixaMovimentoAtendimentos;
			}
		}

		[
			TList(typeof(CaixaMovimentoLancamento)),
			TJoin(new String[]{"idCaixaMovimento->idCaixaMovimento"})
		]
		private Object m_CaixaMovimentoLancamentos = null;
		public System.Collections.Generic.List<CaixaMovimentoLancamento> caixaMovimentoLancamentos
		{
			get
			{
				if(this.m_CaixaMovimentoLancamentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(CaixaMovimentoLancamento) }
						).IsInstanceOfType(this.m_CaixaMovimentoLancamentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentoLancamentos)[i]);

						this.m_CaixaMovimentoLancamentos = em.list(typeof(CaixaMovimentoLancamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<CaixaMovimentoLancamento>)this.m_CaixaMovimentoLancamentos;
			}
		}
	}
}
