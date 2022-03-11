using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PessoaEndereco")]
	public class PessoaEndereco: TTableBase
	{
		[TColumn("numero", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_numero = new TFieldString();
		public TFieldString numero
		{
			get{return this.m_numero;}
		}

		[TColumn("complemento", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_complemento = new TFieldString();
		public TFieldString complemento
		{
			get{return this.m_complemento;}
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
			TColumn("idEndereco", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idEndereco->idEndereco"})
		]
		private Endereco m_idEndereco = null;
		public Endereco endereco
		{
			get
			{
				if(this.m_idEndereco == null)
				{
                    this.m_idEndereco = new Endereco();

					foreach (TJoin attribute in this.m_idEndereco.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEndereco.connectionString = this.connectionString;
							this.m_idEndereco.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEndereco.selfFill();

				return this.m_idEndereco;
			}
		}

        [
            TColumn("idBairro", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idBairro->idBairro" })
        ]
        private Bairro m_idBairro = null;
        public Bairro bairro
        {
            get
            {
                if (this.m_idBairro == null)
                {
                    this.m_idBairro = new Bairro();

                    foreach (TJoin attribute in this.m_idBairro.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idBairro.connectionString = this.connectionString;
                            this.m_idBairro.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idBairro.selfFill();

                return this.m_idBairro;
            }
        }

        [
            TColumn("idLogradouro", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idLogradouro->idLogradouro" })
        ]
        private Logradouro m_idLogradouro = null;
        public Logradouro logradouro
        {
            get
            {
                if (this.m_idLogradouro == null)
                {
                    this.m_idLogradouro = new Logradouro();

                    foreach (TJoin attribute in this.m_idLogradouro.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idLogradouro.connectionString = this.connectionString;
                            this.m_idLogradouro.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idLogradouro.selfFill();

                return this.m_idLogradouro;
            }
        }

        [
			TList(typeof(PessoaEnderecoFinalidadeEndereco)),
			TJoin(new String[]{"idPessoaEnderecoContato->idPessoaEnderecoContato"})
		]
		private Object m_PessoaEnderecoFinalidadeEnderecos = null;
		public System.Collections.Generic.List<PessoaEnderecoFinalidadeEndereco> pessoaEnderecoFinalidadeEnderecos
		{
			get
			{
				if(this.m_PessoaEnderecoFinalidadeEnderecos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaEnderecoFinalidadeEndereco) }
						).IsInstanceOfType(this.m_PessoaEnderecoFinalidadeEnderecos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoFinalidadeEnderecos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoFinalidadeEnderecos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoFinalidadeEnderecos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoFinalidadeEnderecos)[i]);

						this.m_PessoaEnderecoFinalidadeEnderecos = em.list(typeof(PessoaEnderecoFinalidadeEndereco), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaEnderecoFinalidadeEndereco>)this.m_PessoaEnderecoFinalidadeEnderecos;
			}
		}
	}
}
