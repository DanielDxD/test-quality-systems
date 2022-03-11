using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Endereco")]
	public class Endereco: TTableBase
	{
		[TColumn("idEndereco", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEndereco = new TFieldInteger();
		public TFieldInteger idEndereco
		{
			get{return this.m_idEndereco;}
		}

		[TColumn("cep", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldInteger m_cep = new TFieldInteger();
		public TFieldInteger cep
		{
			get{return this.m_cep;}
		}

        [
            TColumn("idCidade", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idCidade->idCidade" })
        ]
        private Cidade m_idCidade = null;
        public Cidade cidade
        {
            get
            {
                if (this.m_idCidade == null)
                {
                    this.m_idCidade = new Cidade();

                    foreach (TJoin attribute in this.m_idCidade.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idCidade.connectionString = this.connectionString;
                            this.m_idCidade.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idCidade.selfFill();

                return this.m_idCidade;
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
			TJoin(new String[]{"idLogradouro->idLogradouro"})
		]
		private Logradouro m_idLogradouro = null;
		public Logradouro logradouro
		{
			get
			{
				if(this.m_idLogradouro == null)
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
	}
}
