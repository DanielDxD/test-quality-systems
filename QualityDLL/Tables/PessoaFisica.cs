using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaFisica")]
	public class PessoaFisica: TTableBase
	{
		[TColumn("dataNascimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataNascimento = new TFieldDatetime();
		public TFieldDatetime dataNascimento
		{
			get{return this.m_dataNascimento;}
		}

		[TColumn("sexo", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_sexo = new TFieldString();
		public TFieldString sexo
		{
			get{return this.m_sexo;}
		}

		[TColumn("rgNumero", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_rgNumero = new TFieldString();
		public TFieldString rgNumero
		{
			get{return this.m_rgNumero;}
		}

		[TColumn("rgEmissor", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_rgEmissor = new TFieldString();
		public TFieldString rgEmissor
		{
			get{return this.m_rgEmissor;}
		}

		[TColumn("rgDataEmissao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_rgDataEmissao = new TFieldDatetime();
		public TFieldDatetime rgDataEmissao
		{
			get{return this.m_rgDataEmissao;}
		}

		[TColumn("teNumero", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_teNumero = new TFieldString();
		public TFieldString teNumero
		{
			get{return this.m_teNumero;}
		}

		[TColumn("teZona", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_teZona = new TFieldInteger();
		public TFieldInteger teZona
		{
			get{return this.m_teZona;}
		}

		[TColumn("teSecao", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_teSecao = new TFieldInteger();
		public TFieldInteger teSecao
		{
			get{return this.m_teSecao;}
		}

		[TColumn("cnhNumero", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_cnhNumero = new TFieldString();
		public TFieldString cnhNumero
		{
			get{return this.m_cnhNumero;}
		}

		[TColumn("reservistaNumero", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_reservistaNumero = new TFieldString();
		public TFieldString reservistaNumero
		{
			get{return this.m_reservistaNumero;}
		}

		[TColumn("profissaoNome", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_profissaoNome = new TFieldString();
		public TFieldString profissaoNome
		{
			get{return this.m_profissaoNome;}
		}

		[TColumn("ctps", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_ctps = new TFieldString();
		public TFieldString ctps
		{
			get{return this.m_ctps;}
		}

		[TColumn("pispasep", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_pispasep = new TFieldString();
		public TFieldString pispasep
		{
			get{return this.m_pispasep;}
		}

		[
			TColumn("idPessoaFisica", System.Data.SqlDbType.BigInt, true, false),
			TJoin(new String[]{"idPessoaFisica->idPessoa"})
		]
		private Pessoa m_idPessoaFisica = null;
		public Pessoa pessoa
		{
			get
			{
				if(this.m_idPessoaFisica == null)
				{
					this.m_idPessoaFisica = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoaFisica.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaFisica.connectionString = this.connectionString;
							this.m_idPessoaFisica.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaFisica.selfFill();

				return this.m_idPessoaFisica;
			}
		}

		[
			TColumn("idEstadoCivil", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idEstadoCivil->idEstadoCivil"})
		]
		private EstadoCivil m_idEstadoCivil = null;
		public EstadoCivil estadoCivil
		{
			get
			{
				if(this.m_idEstadoCivil == null)
				{
					this.m_idEstadoCivil = new EstadoCivil();

					foreach (TJoin attribute in this.m_idEstadoCivil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEstadoCivil.connectionString = this.connectionString;
							this.m_idEstadoCivil.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEstadoCivil.selfFill();

				return this.m_idEstadoCivil;
			}
		}

		[
			TColumn("idNacionalidade", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idNacionalidade->idNacionalidade"})
		]
		private Nacionalidade m_idNacionalidade = null;
		public Nacionalidade nacionalidade
		{
			get
			{
				if(this.m_idNacionalidade == null)
				{
					this.m_idNacionalidade = new Nacionalidade();

					foreach (TJoin attribute in this.m_idNacionalidade.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idNacionalidade.connectionString = this.connectionString;
							this.m_idNacionalidade.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idNacionalidade.selfFill();

				return this.m_idNacionalidade;
			}
		}

		[
			TColumn("idEscolaridade", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idEscolaridade->idEscolaridade"})
		]
		private Escolaridade m_idEscolaridade = null;
		public Escolaridade escolaridade
		{
			get
			{
				if(this.m_idEscolaridade == null)
				{
					this.m_idEscolaridade = new Escolaridade();

					foreach (TJoin attribute in this.m_idEscolaridade.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEscolaridade.connectionString = this.connectionString;
							this.m_idEscolaridade.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEscolaridade.selfFill();

				return this.m_idEscolaridade;
			}
		}

		[
			TColumn("idCidadeNaturalidade", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCidadeNaturalidade->idCidade"})
		]
		private Cidade m_idCidadeNaturalidade = null;
		public Cidade cidadeNaturalidade
		{
			get
			{
				if(this.m_idCidadeNaturalidade == null)
				{
					this.m_idCidadeNaturalidade = new Cidade();

					foreach (TJoin attribute in this.m_idCidadeNaturalidade.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCidadeNaturalidade.connectionString = this.connectionString;
							this.m_idCidadeNaturalidade.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCidadeNaturalidade.selfFill();

				return this.m_idCidadeNaturalidade;
			}
		}

		[
			TColumn("idProfissao", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idProfissao->idProfissao"})
		]
		private Profissao m_idProfissao = null;
		public Profissao profissao
		{
			get
			{
				if(this.m_idProfissao == null)
				{
                    this.m_idProfissao = new Profissao();

					foreach (TJoin attribute in this.m_idProfissao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idProfissao.connectionString = this.connectionString;
							this.m_idProfissao.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idProfissao.selfFill();

				return this.m_idProfissao;
			}
		}
	}
}
