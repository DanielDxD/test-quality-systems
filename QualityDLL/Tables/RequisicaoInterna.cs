using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoInterna")]
	public class RequisicaoInterna: TTableBase
	{
		[TColumn("idRequisicaoInterna", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoInterna = new TFieldInteger();
		public TFieldInteger idRequisicaoInterna
		{
			get{return this.m_idRequisicaoInterna;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("dataRequisicao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataRequisicao = new TFieldDatetime();
		public TFieldDatetime dataRequisicao
		{
			get{return this.m_dataRequisicao;}
		}

		[TColumn("tipo", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_tipo = new TFieldString();
		public TFieldString tipo
		{
			get{return this.m_tipo;}
		}

		[
			TColumn("idDepartamentoOrigem", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idDepartamentoOrigem->idDepartamento"})
		]
		private Departamento m_idDepartamentoOrigem = null;
		public Departamento departamentoOrigem
		{
			get
			{
				if(this.m_idDepartamentoOrigem == null)
				{
					this.m_idDepartamentoOrigem = new Departamento();

					foreach (TJoin attribute in this.m_idDepartamentoOrigem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idDepartamentoOrigem.connectionString = this.connectionString;
							this.m_idDepartamentoOrigem.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idDepartamentoOrigem.selfFill();

				return this.m_idDepartamentoOrigem;
			}
		}

		[
			TColumn("idDepartamentoDestino", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idDepartamentoDestino->idDepartamento"})
		]
		private Departamento m_idDepartamentoDestino = null;
		public Departamento departamentoDestino
		{
			get
			{
				if(this.m_idDepartamentoDestino == null)
				{
                    this.m_idDepartamentoDestino = new Departamento();

					foreach (TJoin attribute in this.m_idDepartamentoDestino.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idDepartamentoDestino.connectionString = this.connectionString;
							this.m_idDepartamentoDestino.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idDepartamentoDestino.selfFill();

				return this.m_idDepartamentoDestino;
			}
		}

        [
            TColumn("idFuncionarioSolicitante", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idFuncionarioSolicitante->idFuncionario" })
        ]
        private Funcionario m_idFuncionarioSolicitante = null;
        public Funcionario funcionarioSolicitante
        {
            get
            {
                if (this.m_idFuncionarioSolicitante == null)
                {
                    this.m_idFuncionarioSolicitante = new Funcionario();

                    foreach (TJoin attribute in this.m_idFuncionarioSolicitante.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idFuncionarioSolicitante.connectionString = this.connectionString;
                            this.m_idFuncionarioSolicitante.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idFuncionarioSolicitante.selfFill();

                return this.m_idFuncionarioSolicitante;
            }
        }

        [
			TList(typeof(RequisicaoInternaProdutoServico)),
			TJoin(new String[]{"idRequisicaoInterna->idRequisicaoInterna"})
		]
		private Object m_RequisicaoInternaProdutoServicos = null;
		public System.Collections.Generic.List<RequisicaoInternaProdutoServico> requisicaoInternaProdutoServicos
		{
			get
			{
				if(this.m_RequisicaoInternaProdutoServicos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(RequisicaoInternaProdutoServico) }
						).IsInstanceOfType(this.m_RequisicaoInternaProdutoServicos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaProdutoServicos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaProdutoServicos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaProdutoServicos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RequisicaoInternaProdutoServicos)[i]);

						this.m_RequisicaoInternaProdutoServicos = em.list(typeof(RequisicaoInternaProdutoServico), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<RequisicaoInternaProdutoServico>)this.m_RequisicaoInternaProdutoServicos;
			}
		}

		[
			TList(typeof(RequisicaoInternaSituacao)),
			TJoin(new String[]{"idRequisicaoInterna->idRequisicaoInterna"})
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
	}
}
