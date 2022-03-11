using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaJuridica")]
	public class PessoaJuridica: TTableBase
	{
		[TColumn("dataFundacao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataFundacao = new TFieldDatetime();
		public TFieldDatetime dataFundacao
		{
			get{return this.m_dataFundacao;}
		}

		[TColumn("inscricaoEstadual", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_inscricaoEstadual = new TFieldString();
		public TFieldString inscricaoEstadual
		{
			get{return this.m_inscricaoEstadual;}
		}

		[TColumn("inscricaoMunicipal", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_inscricaoMunicipal = new TFieldString();
		public TFieldString inscricaoMunicipal
		{
			get{return this.m_inscricaoMunicipal;}
		}

        [TColumn("inscricaoEstadualST", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_inscricaoEstadualST = new TFieldString();
        public TFieldString inscricaoEstadualST
        {
            get { return this.m_inscricaoEstadualST; }
        }
        
        [
			TColumn("idPessoaJuridica", System.Data.SqlDbType.BigInt, true, false),
			TJoin(new String[]{"idPessoaJuridica->idPessoa"})
		]
		private Pessoa m_idPessoaJuridica = null;
		public Pessoa pessoa
		{
			get
			{
				if(this.m_idPessoaJuridica == null)
				{
					this.m_idPessoaJuridica = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoaJuridica.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaJuridica.connectionString = this.connectionString;
							this.m_idPessoaJuridica.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaJuridica.selfFill();

				return this.m_idPessoaJuridica;
			}
		}

		[
			TColumn("idAtividadeEconomicaPrimaria", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idAtividadeEconomicaPrimaria->idAtividadeEconomica"})
		]
		private AtividadeEconomica m_idAtividadeEconomicaPrimaria = null;
		public AtividadeEconomica atividadeEconomicaPrimaria
		{
			get
			{
				if(this.m_idAtividadeEconomicaPrimaria == null)
				{
					this.m_idAtividadeEconomicaPrimaria = new AtividadeEconomica();

					foreach (TJoin attribute in this.m_idAtividadeEconomicaPrimaria.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idAtividadeEconomicaPrimaria.connectionString = this.connectionString;
							this.m_idAtividadeEconomicaPrimaria.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idAtividadeEconomicaPrimaria.selfFill();

				return this.m_idAtividadeEconomicaPrimaria;
			}
		}

		[
			TColumn("idAtividadeEconomicaSecundaria", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idAtividadeEconomicaSecundaria->idAtividadeEconomica"})
		]
		private AtividadeEconomica m_idAtividadeEconomicaSecundaria = null;
		public AtividadeEconomica atividadeEconomicaSecundaria
		{
			get
			{
				if(this.m_idAtividadeEconomicaSecundaria == null)
				{
                    this.m_idAtividadeEconomicaSecundaria = new AtividadeEconomica();

					foreach (TJoin attribute in this.m_idAtividadeEconomicaSecundaria.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idAtividadeEconomicaSecundaria.connectionString = this.connectionString;
							this.m_idAtividadeEconomicaSecundaria.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idAtividadeEconomicaSecundaria.selfFill();

				return this.m_idAtividadeEconomicaSecundaria;
			}
		}
	}
}
