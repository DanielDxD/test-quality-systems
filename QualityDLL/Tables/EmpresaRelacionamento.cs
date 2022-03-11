using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EmpresaRelacionamento")]
	public class EmpresaRelacionamento: TTableBase
	{
		[TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEmpresaRelacionamento = new TFieldInteger();
		public TFieldInteger idEmpresaRelacionamento
		{
			get{return this.m_idEmpresaRelacionamento;}
		}

		[TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataInicio = new TFieldDatetime();
		public TFieldDatetime dataInicio
		{
			get{return this.m_dataInicio;}
		}

		[TColumn("dataTermino", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataTermino = new TFieldDatetime();
		public TFieldDatetime dataTermino
		{
			get{return this.m_dataTermino;}
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
		}

		[TColumn("codigoExportacao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoExportacao = new TFieldString();
		public TFieldString codigoExportacao
		{
			get { return this.m_codigoExportacao; }
		}

		[TColumn("senha", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_senha = new TFieldString();
		public TFieldString senha
		{
			get { return this.m_senha; }
		}

		[TColumn("dadosBancarios", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_dadosBancarios = new TFieldString();
		public TFieldString dadosBancarios
		{
			get { return this.m_dadosBancarios; }
		}

		[TColumn("limitePosPago", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_limitePosPago = new TFieldDouble();
		public TFieldDouble limitePosPago
		{
			get { return this.m_limitePosPago; }
		}

		[
			TColumn("idTipoRelacionamentoEmpresa", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoRelacionamentoEmpresa->idTipoRelacionamentoEmpresa"})
		]
		private TipoRelacionamentoEmpresa m_idTipoRelacionamentoEmpresa = null;
		public TipoRelacionamentoEmpresa tipoRelacionamentoEmpresa
		{
			get
			{
				if(this.m_idTipoRelacionamentoEmpresa == null)
				{
					this.m_idTipoRelacionamentoEmpresa = new TipoRelacionamentoEmpresa();

					foreach (TJoin attribute in this.m_idTipoRelacionamentoEmpresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoRelacionamentoEmpresa.connectionString = this.connectionString;
							this.m_idTipoRelacionamentoEmpresa.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoRelacionamentoEmpresa.selfFill();

				return this.m_idTipoRelacionamentoEmpresa;
			}
		}

        [
			TColumn("idPessoaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoaRelacionamento->idPessoa"})
		]
		private Pessoa m_idPessoaRelacionamento = null;
		public Pessoa pessoaRelacionamento
		{
			get
			{
				if(this.m_idPessoaRelacionamento == null)
				{
					this.m_idPessoaRelacionamento = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoaRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaRelacionamento.connectionString = this.connectionString;
							this.m_idPessoaRelacionamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaRelacionamento.selfFill();

				return this.m_idPessoaRelacionamento;
			}
		}

		[
			TColumn("idPessoaRelacionadaEmpresa", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoaRelacionadaEmpresa->idEmpresaRelacionamento"})
		]
		private EmpresaRelacionamento m_idPessoaRelacionadaEmpresa = null;
		public EmpresaRelacionamento pessoaRelacionadaEmpresa
		{
			get
			{
				if(this.m_idPessoaRelacionadaEmpresa == null)
				{
                    this.m_idPessoaRelacionadaEmpresa = new EmpresaRelacionamento();

					foreach (TJoin attribute in this.m_idPessoaRelacionadaEmpresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaRelacionadaEmpresa.connectionString = this.connectionString;
							this.m_idPessoaRelacionadaEmpresa.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaRelacionadaEmpresa.selfFill();

				return this.m_idPessoaRelacionadaEmpresa;
			}
		}

		[
			TList(typeof(EmpresaRelacionamento)),
			TJoin(new String[]{"idEmpresaRelacionamento->idPessoaRelacionadaEmpresa"})
		]
		private Object m_EmpresaRelacionamentos = null;
		public System.Collections.Generic.List<EmpresaRelacionamento> empresaRelacionamentos
		{
			get
			{
				if(this.m_EmpresaRelacionamentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(EmpresaRelacionamento) }
						).IsInstanceOfType(this.m_EmpresaRelacionamentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos)[i]);

						this.m_EmpresaRelacionamentos = em.list(typeof(EmpresaRelacionamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<EmpresaRelacionamento>)this.m_EmpresaRelacionamentos;
			}
		}

		[
			TList(typeof(EmpresaRelacionamentoCartao)),
			TJoin(new String[]{"idEmpresaRelacionamento->idEmpresaRelacionamento"})
		]
		private Object m_Comandas = null;
		public System.Collections.Generic.List<EmpresaRelacionamentoCartao> comandas
        {
			get
			{
				if(this.m_Comandas != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(EmpresaRelacionamentoCartao) }
						).IsInstanceOfType(this.m_Comandas)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Comandas)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Comandas).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Comandas).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Comandas)[i]);

						this.m_Comandas = em.list(typeof(EmpresaRelacionamentoCartao), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<EmpresaRelacionamentoCartao>)this.m_Comandas;
			}
		}

        [
            TList(typeof(Cartao)),
            TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })
        ]
        private Object m_Cartoes = null;
        public System.Collections.Generic.List<Cartao> cartoes
        {
            get
            {
                if (this.m_Cartoes != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(Cartao) }
                        ).IsInstanceOfType(this.m_Cartoes)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Cartoes)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Cartoes).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Cartoes).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Cartoes)[i]);

                        this.m_Cartoes = em.list(typeof(Cartao), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<Cartao>)this.m_Cartoes;
            }
        }
         

        [
			TList(typeof(ExameEmpresaRelacionamento)),
			TJoin(new String[]{"idEmpresaRelacionamento->idEmpresaRelacionamento"})
		]
		private Object m_ExameEmpresaRelacionamentos = null;
		public System.Collections.Generic.List<ExameEmpresaRelacionamento> exameEmpresaRelacionamentos
		{
			get
			{
				if(this.m_ExameEmpresaRelacionamentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(ExameEmpresaRelacionamento) }
						).IsInstanceOfType(this.m_ExameEmpresaRelacionamentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ExameEmpresaRelacionamentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ExameEmpresaRelacionamentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ExameEmpresaRelacionamentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ExameEmpresaRelacionamentos)[i]);

						this.m_ExameEmpresaRelacionamentos = em.list(typeof(ExameEmpresaRelacionamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<ExameEmpresaRelacionamento>)this.m_ExameEmpresaRelacionamentos;
			}
		}

        [
             TList(typeof(ExportacaoContabil)),
             TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })
         ]
        private Object m_ExportacaoContabil = null;
        public System.Collections.Generic.List<ExportacaoContabil> exportacaoContabil
        {
            get
            {
                if (this.m_ExportacaoContabil != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(ExportacaoContabil) }
                        ).IsInstanceOfType(this.m_ExportacaoContabil)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ExportacaoContabil)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ExportacaoContabil).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ExportacaoContabil).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ExportacaoContabil)[i]);

                        this.m_ExportacaoContabil = em.list(typeof(ExportacaoContabil), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ExportacaoContabil>)this.m_ExportacaoContabil;
            }
        }
    }
}
