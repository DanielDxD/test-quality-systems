using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaEnderecoFinalidadeEndereco")]
	public class PessoaEnderecoFinalidadeEndereco: TTableBase
	{
		[
			TColumn("idPessoaEnderecoContato", System.Data.SqlDbType.BigInt, true, false),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private PessoaEndereco m_idPessoaEnderecoContato = null;
		public PessoaEndereco pessoaEnderecoContatoFinalidade
		{
			get
			{
				if(this.m_idPessoaEnderecoContato == null)
				{
					this.m_idPessoaEnderecoContato = new PessoaEndereco();

					foreach (TJoin attribute in this.m_idPessoaEnderecoContato.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaEnderecoContato.connectionString = this.connectionString;
							this.m_idPessoaEnderecoContato.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaEnderecoContato.selfFill();

				return this.m_idPessoaEnderecoContato;
			}
		}

		[
			TColumn("idFinalidadeEndereco", System.Data.SqlDbType.Int, true, false),
			TJoin(new String[]{"idFinalidadeEndereco->idFinalidadeEndereco"})
		]
		private FinalidadeEndereco m_idFinalidadeEndereco = null;
		public FinalidadeEndereco finalidadeEndereco
		{
			get
			{
				if(this.m_idFinalidadeEndereco == null)
				{
                    this.m_idFinalidadeEndereco = new FinalidadeEndereco();

					foreach (TJoin attribute in this.m_idFinalidadeEndereco.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idFinalidadeEndereco.connectionString = this.connectionString;
							this.m_idFinalidadeEndereco.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idFinalidadeEndereco.selfFill();

				return this.m_idFinalidadeEndereco;
			}
		}
	}
}
