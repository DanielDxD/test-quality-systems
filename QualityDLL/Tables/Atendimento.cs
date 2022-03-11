using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Atendimento")]
	public class Atendimento: TTableBase
	{
		[TColumn("idAtendimento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idAtendimento = new TFieldInteger();
		public TFieldInteger idAtendimento
		{
			get{return this.m_idAtendimento;}
		}

		[TColumn("dataAtendimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataAtendimento = new TFieldDatetime();
		public TFieldDatetime dataAtendimento
		{
			get{return this.m_dataAtendimento;}
		}

		[TColumn("numeroComanda", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldInteger m_numeroComanda = new TFieldInteger();
		public TFieldInteger numeroComanda
		{
			get{return this.m_numeroComanda;}
		}

		[
			TColumn("idPontoAtendimento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idPontoAtendimento->idPontoAtendimento"})
		]
		private PontoAtendimento m_idPontoAtendimento = null;
		public PontoAtendimento pontoAtendimento
		{
			get
			{
				if(this.m_idPontoAtendimento == null)
				{
					this.m_idPontoAtendimento = new PontoAtendimento();

					foreach (TJoin attribute in this.m_idPontoAtendimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPontoAtendimento.connectionString = this.connectionString;
							this.m_idPontoAtendimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPontoAtendimento.selfFill();

				return this.m_idPontoAtendimento;
			}
		}

		[
			TColumn("idAtendente", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idAtendente->idFuncionario"})
		]
		private Funcionario m_idAtendente = null;
		public Funcionario atendente
		{
			get
			{
				if(this.m_idAtendente == null)
				{
                    this.m_idAtendente = new Funcionario();

					foreach (TJoin attribute in this.m_idAtendente.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idAtendente.connectionString = this.connectionString;
							this.m_idAtendente.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idAtendente.selfFill();

				return this.m_idAtendente;
			}
		}

        [
			TList(typeof(AtendimentoPagamento)),
			TJoin(new String[]{"idAtendimento->idAtendimento"})
		]
		private Object m_AtendimentoPagamentos = null;
		public System.Collections.Generic.List<AtendimentoPagamento> atendimentoPagamentos
		{
			get
			{
				if(this.m_AtendimentoPagamentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(AtendimentoPagamento) }
						).IsInstanceOfType(this.m_AtendimentoPagamentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_AtendimentoPagamentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_AtendimentoPagamentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_AtendimentoPagamentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_AtendimentoPagamentos)[i]);

						this.m_AtendimentoPagamentos = em.list(typeof(AtendimentoPagamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<AtendimentoPagamento>)this.m_AtendimentoPagamentos;
			}
		}

		[
			TList(typeof(AtendimentoProdutoServico)),
			TJoin(new String[]{"idAtendimento->idAtendimento"})
		]
		private Object m_AtendimentoProdutoServicos = null;
		public System.Collections.Generic.List<AtendimentoProdutoServico> atendimentoProdutoServicos
		{
			get
			{
				if(this.m_AtendimentoProdutoServicos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(AtendimentoProdutoServico) }
						).IsInstanceOfType(this.m_AtendimentoProdutoServicos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_AtendimentoProdutoServicos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_AtendimentoProdutoServicos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_AtendimentoProdutoServicos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_AtendimentoProdutoServicos)[i]);

						this.m_AtendimentoProdutoServicos = em.list(typeof(AtendimentoProdutoServico), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<AtendimentoProdutoServico>)this.m_AtendimentoProdutoServicos;
			}
		}
	}
}
