using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Caixa")]
	public class Caixa: TTableBase
	{
		[TColumn("idCaixa", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idCaixa = new TFieldInteger();
		public TFieldInteger idCaixa
		{
			get{return this.m_idCaixa;}
		}

		[TColumn("dataCaixa", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataCaixa = new TFieldDatetime();
		public TFieldDatetime dataCaixa
		{
			get{return this.m_dataCaixa;}
		}

		[TColumn("saldo", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_saldo = new TFieldDouble();
		public TFieldDouble saldo
		{
			get{return this.m_saldo;}
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

		[
			TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
		]
		private Funcionario m_idFuncionario = null;
		public Funcionario funcionario
		{
			get
			{
				if(this.m_idFuncionario == null)
				{
                    this.m_idFuncionario = new Funcionario();

					foreach (TJoin attribute in this.m_idFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idFuncionario.connectionString = this.connectionString;
							this.m_idFuncionario.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idFuncionario.selfFill();

				return this.m_idFuncionario;
			}
		}
		[
			TList(typeof(CaixaMovimento)),
			TJoin(new String[]{"idCaixa->idCaixa"})
		]
		private Object m_CaixaMovimentos = null;
		public System.Collections.Generic.List<CaixaMovimento> caixaMovimentos
		{
			get
			{
				if(this.m_CaixaMovimentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(CaixaMovimento) }
						).IsInstanceOfType(this.m_CaixaMovimentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CaixaMovimentos)[i]);

						this.m_CaixaMovimentos = em.list(typeof(CaixaMovimento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<CaixaMovimento>)this.m_CaixaMovimentos;
			}
		}
	}
}
