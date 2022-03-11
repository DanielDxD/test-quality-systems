using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaEnderecoContato")]
	public class PessoaEnderecoContato: TTableBase
	{
		[TColumn("idPessoaEnderecoContato", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPessoaEnderecoContato = new TFieldInteger();
		public TFieldInteger idPessoaEnderecoContato
		{
			get{return this.m_idPessoaEnderecoContato;}
		}

		[
			TColumn("idPessoa", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idPessoa->idPessoa"})
		]
		private Pessoa m_idPessoa = null;
		public Pessoa pessoa
		{
			get
			{
				if(this.m_idPessoa == null)
				{
					this.m_idPessoa = new Pessoa();

					foreach (TJoin attribute in this.m_idPessoa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPessoa.connectionString = this.connectionString;
							this.m_idPessoa.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPessoa.selfFill();

				return this.m_idPessoa;
			}
		}

		[
			TColumn("idTipoEnderecoContato", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoEnderecoContato->idTipoEnderecoContato"})
		]
		private TipoEnderecoContato m_idTipoEnderecoContato = null;
		public TipoEnderecoContato tipoEnderecoContato
		{
			get
			{
				if(this.m_idTipoEnderecoContato == null)
				{
                    this.m_idTipoEnderecoContato = new TipoEnderecoContato();

					foreach (TJoin attribute in this.m_idTipoEnderecoContato.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoEnderecoContato.connectionString = this.connectionString;
							this.m_idTipoEnderecoContato.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoEnderecoContato.selfFill();

				return this.m_idTipoEnderecoContato;
			}
		}

        [
			TList(typeof(PessoaContato)),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private Object m_PessoaContatos = null;
		public System.Collections.Generic.List<PessoaContato> pessoaContatos
		{
			get
			{
				if(this.m_PessoaContatos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaContato) }
						).IsInstanceOfType(this.m_PessoaContatos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaContatos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaContatos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaContatos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaContatos)[i]);

						this.m_PessoaContatos = em.list(typeof(PessoaContato), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaContato>)this.m_PessoaContatos;
			}
		}

		[
			TList(typeof(PessoaEndereco)),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private Object m_PessoaEnderecos = null;
		public System.Collections.Generic.List<PessoaEndereco> pessoaEnderecos
		{
			get
			{
				if(this.m_PessoaEnderecos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaEndereco) }
						).IsInstanceOfType(this.m_PessoaEnderecos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecos)[i]);

						this.m_PessoaEnderecos = em.list(typeof(PessoaEndereco), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaEndereco>)this.m_PessoaEnderecos;
			}
		}
	}
}
