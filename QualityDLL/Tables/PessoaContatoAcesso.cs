using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaContatoAcesso")]
	public class PessoaContatoAcesso: TTableBase
	{
		[TColumn("idPessoaContatoAcesso", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPessoaContatoAcesso = new TFieldInteger();
		public TFieldInteger idPessoaContatoAcesso
		{
			get{return this.m_idPessoaContatoAcesso;}
		}

		[TColumn("informacao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_informacao = new TFieldString();
		public TFieldString informacao
		{
			get{return this.m_informacao;}
		}

		[
			TColumn("idPessoaEnderecoContato", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private PessoaContato m_idPessoaEnderecoContato = null;
		public PessoaContato pessoaEnderecoContato
		{
			get
			{
				if(this.m_idPessoaEnderecoContato == null)
				{
					this.m_idPessoaEnderecoContato = new PessoaContato();

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
			TColumn("idTipoAcessoContato", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoAcessoContato->idTipoAcessoContato"})
		]
		private TipoAcessoContato m_idTipoAcessoContato = null;
		public TipoAcessoContato tipoAcessoContato
		{
			get
			{
				if(this.m_idTipoAcessoContato == null)
				{
                    this.m_idTipoAcessoContato = new TipoAcessoContato();

					foreach (TJoin attribute in this.m_idTipoAcessoContato.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoAcessoContato.connectionString = this.connectionString;
							this.m_idTipoAcessoContato.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoAcessoContato.selfFill();

				return this.m_idTipoAcessoContato;
			}
		}
	}
}
