using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaContato")]
	public class PessoaContato: TTableBase
	{
		[TColumn("nome", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_nome = new TFieldString();
		public TFieldString nome
		{
			get{return this.m_nome;}
		}

		[
			TColumn("idPessoaEnderecoContato", System.Data.SqlDbType.BigInt, true, false),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private PessoaEnderecoContato m_idPessoaEnderecoContato = null;
		public PessoaEnderecoContato pessoaEnderecoContato
		{
			get
			{
				if(this.m_idPessoaEnderecoContato == null)
				{
					this.m_idPessoaEnderecoContato = new PessoaEnderecoContato();

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
			TColumn("idPessoaContato", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoaContato->idPessoa"})
		]
		private Pessoa m_idPessoaContato = null;
		public Pessoa pessoaContato
		{
			get
			{
				if(this.m_idPessoaContato == null)
				{
                    this.m_idPessoaContato = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoaContato.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoaContato.connectionString = this.connectionString;
							this.m_idPessoaContato.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoaContato.selfFill();

				return this.m_idPessoaContato;
			}
		}
		[
			TList(typeof(PessoaContatoAcesso)),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private Object m_PessoaContatoAcessos = null;
		public System.Collections.Generic.List<PessoaContatoAcesso> pessoaContatoAcessos
		{
			get
			{
				if(this.m_PessoaContatoAcessos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaContatoAcesso) }
						).IsInstanceOfType(this.m_PessoaContatoAcessos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaContatoAcessos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaContatoAcessos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaContatoAcessos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaContatoAcessos)[i]);

						this.m_PessoaContatoAcessos = em.list(typeof(PessoaContatoAcesso), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaContatoAcesso>)this.m_PessoaContatoAcessos;
			}
		}
	}
}
