using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Funcionario")]
	public class Funcionario: TTableBase
	{
		[TColumn("cargo", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_cargo = new TFieldString();
		public TFieldString cargo
		{
			get{return this.m_cargo;}
		}

		[TColumn("matricula", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_matricula = new TFieldString();
		public TFieldString matricula
		{
			get{return this.m_matricula;}
        }

        [TColumn("comissao", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_comissao = new TFieldDouble();
        public TFieldDouble comissao
        {
            get { return this.m_comissao; }
        }

        [TColumn("salarioBase", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_salarioBase = new TFieldDouble();
        public TFieldDouble salarioBase
        {
            get { return this.m_salarioBase; }
        }

        [
			TColumn("idFuncionario", System.Data.SqlDbType.BigInt, true, false),
			TJoin(new String[]{"idFuncionario->idEmpresaRelacionamento"})
		]
		private EmpresaRelacionamento m_idFuncionario = null;
		public EmpresaRelacionamento funcionarioEmpresaRelacionamento
		{
			get
			{
				if(this.m_idFuncionario == null)
				{
                    this.m_idFuncionario = new EmpresaRelacionamento();

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
			TList(typeof(Atendimento)),
			TJoin(new String[]{"idFuncionario->idAtendente"})
		]
		private Object m_Atendimentos = null;
		public System.Collections.Generic.List<Atendimento> atendimentos
		{
			get
			{
				if(this.m_Atendimentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(Atendimento) }
						).IsInstanceOfType(this.m_Atendimentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Atendimentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Atendimentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Atendimentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Atendimentos)[i]);

						this.m_Atendimentos = em.list(typeof(Atendimento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<Atendimento>)this.m_Atendimentos;
			}
		}

		[
			TList(typeof(Caixa)),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
		]
		private Object m_Caixas = null;
		public System.Collections.Generic.List<Caixa> caixas
		{
			get
			{
				if(this.m_Caixas != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(Caixa) }
						).IsInstanceOfType(this.m_Caixas)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Caixas)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Caixas).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Caixas).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Caixas)[i]);

						this.m_Caixas = em.list(typeof(Caixa), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<Caixa>)this.m_Caixas;
			}
		}

		[
			TList(typeof(DepartamentoFuncionario)),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
		]
		private Object m_DepartamentoFuncionarios = null;
		public System.Collections.Generic.List<DepartamentoFuncionario> departamentoFuncionarios
		{
			get
			{
				if(this.m_DepartamentoFuncionarios != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(DepartamentoFuncionario) }
						).IsInstanceOfType(this.m_DepartamentoFuncionarios)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DepartamentoFuncionarios)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_DepartamentoFuncionarios).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_DepartamentoFuncionarios).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_DepartamentoFuncionarios)[i]);

						this.m_DepartamentoFuncionarios = em.list(typeof(DepartamentoFuncionario), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<DepartamentoFuncionario>)this.m_DepartamentoFuncionarios;
			}
		}

		[
			TList(typeof(PedidoCompra)),
			TJoin(new String[]{"idFuncionario->idAprovador"})
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
			TList(typeof(RequisicaoCompraSituacao)),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
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
			TList(typeof(RequisicaoInternaSituacao)),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
		]
		private Object m_RequisicaoInternaSituacaos = null;
		public System.Collections.Generic.List<RequisicaoInternaSituacao> requisicaoInternaSituacaos
		{
			get
			{
				if(this.m_RequisicaoInternaSituacaos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(RequisicaoInternaSituacao) }
						).IsInstanceOfType(this.m_RequisicaoInternaSituacaos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaSituacaos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaSituacaos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaSituacaos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaSituacaos)[i]);

						this.m_RequisicaoInternaSituacaos = em.list(typeof(RequisicaoInternaSituacao), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<RequisicaoInternaSituacao>)this.m_RequisicaoInternaSituacaos;
			}
		}

		[
			TList(typeof(Usuario)),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
		]
		private Object m_Usuarios = null;
		public System.Collections.Generic.List<Usuario> usuarios
		{
			get
			{
				if(this.m_Usuarios != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(Usuario) }
						).IsInstanceOfType(this.m_Usuarios)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Usuarios)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Usuarios).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Usuarios).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Usuarios)[i]);

						this.m_Usuarios = em.list(typeof(Usuario), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<Usuario>)this.m_Usuarios;
			}
		}
	}
}
