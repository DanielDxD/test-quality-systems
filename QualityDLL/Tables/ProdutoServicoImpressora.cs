using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ProdutoServicoImpressora")]
	public class ProdutoServicoImpressora: TTableBase
	{
		[TColumn("idProdutoServicoImpressora", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idProdutoServicoImpressora = new TFieldInteger();
		public TFieldInteger idProdutoServicoImpressora
		{
			get{return this.m_idProdutoServicoImpressora;}
		}
        

		[
			TColumn("idPdvEstacao", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{ "idPdvEstacao->idPdvEstacao" })
		]
		private PdvEstacao  m_idPdvEstacao = null;
		public PdvEstacao  pdvEstacao
		{
			get
			{
				if(this.m_idPdvEstacao == null)
				{
					this.m_idPdvEstacao = new PdvEstacao ();

					foreach (TJoin attribute in this.m_idPdvEstacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPdvEstacao.connectionString = this.connectionString;
							this.m_idPdvEstacao.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPdvEstacao.selfFill();

				return this.m_idPdvEstacao;
			}
		}

		[
			TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{ "idProdutoServico->idProdutoServico" })
		]
		private ProdutoServico m_idProdutoServico = null;
		public ProdutoServico produtoServico
		{
			get
			{
				if(this.m_idProdutoServico == null)
				{
                    this.m_idProdutoServico = new ProdutoServico();

					foreach (TJoin attribute in this.m_idProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idProdutoServico.connectionString = this.connectionString;
							this.m_idProdutoServico.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idProdutoServico.selfFill();

				return this.m_idProdutoServico;
			}
		}

        [
            TColumn("idPdvImpressora", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvImpressora->idPdvImpressora" })
        ]
        private PdvImpressora m_idPdvImpressora = null;
        public PdvImpressora pdvImpressora
        {
            get
            {
                if (this.m_idPdvImpressora == null)
                {
                    this.m_idPdvImpressora = new PdvImpressora();

                    foreach (TJoin attribute in this.m_idPdvImpressora.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPdvImpressora.connectionString = this.connectionString;
                            this.m_idPdvImpressora.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPdvImpressora.selfFill();

                return this.m_idPdvImpressora;
            }
        }
    }
}
