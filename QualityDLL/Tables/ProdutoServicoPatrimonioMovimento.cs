using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ProdutoServicoPatrimonioMovimento")]
	public class ProdutoServicoPatrimonioMovimento : TTableBase
	{
		[TColumn("idProdutoServicoPatrimonioMovimento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idProdutoServicoPatrimonioMovimento = new TFieldInteger();
		public TFieldInteger idProdutoServicoPatrimonioMovimento
        {
			get{return this.m_idProdutoServicoPatrimonioMovimento; }
		}

		[TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataMovimento = new TFieldDatetime();
		public TFieldDatetime dataMovimento
        {
			get{return this.m_dataMovimento; }
        }

        [TColumn("tipoOperacao", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_tipoOperacao = new TFieldString();
        public TFieldString tipoOperacao
        {
            get { return this.m_tipoOperacao; }
        }

        [TColumn("valorMovimento", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorMovimento = new TFieldDouble();
        public TFieldDouble valorMovimento
        {
            get { return this.m_valorMovimento; }
        }

        [
            TColumn("idProdutoServicoPatrimonio", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idProdutoServicoPatrimonio->idProdutoServicoPatrimonio" })
        ]
        private ProdutoServicoPatrimonio m_idProdutoServicoPatrimonio = null;
        public ProdutoServicoPatrimonio produtoServicoPatrimonio
        {
            get
            {
                if (this.m_idProdutoServicoPatrimonio == null)
                {
                    this.m_idProdutoServicoPatrimonio = new ProdutoServicoPatrimonio();

                    foreach (TJoin attribute in this.m_idProdutoServicoPatrimonio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idProdutoServicoPatrimonio.connectionString = this.connectionString;
                            this.m_idProdutoServicoPatrimonio.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idProdutoServicoPatrimonio.selfFill();

                return this.m_idProdutoServicoPatrimonio;
            }
        }

        [
			TColumn("idDepartamentoOrigem", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{ "idDepartamentoOrigem->idDepartamento" })
		]
		private Departamento m_idDepartamentoOrigem = null;
		public Departamento departamentoOrigem
		{
			get
			{
				if(this.m_idDepartamentoOrigem == null)
				{
					this.m_idDepartamentoOrigem = new Departamento();

					foreach (TJoin attribute in this.m_idDepartamentoOrigem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idDepartamentoOrigem.connectionString = this.connectionString;
							this.m_idDepartamentoOrigem.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idDepartamentoOrigem.selfFill();

				return this.m_idDepartamentoOrigem;
			}
		}

		[
			TColumn("idDepartamentoDestino", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{ "idDepartamentoDestino->idDepartamento" })
		]
		private Departamento m_idDepartamentoDestino = null;
		public Departamento departamentoDestino
		{
			get
			{
				if(this.m_idDepartamentoDestino == null)
				{
                    this.m_idDepartamentoDestino = new Departamento();

					foreach (TJoin attribute in this.m_idDepartamentoDestino.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idDepartamentoDestino.connectionString = this.connectionString;
							this.m_idDepartamentoDestino.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idDepartamentoDestino.selfFill();

				return this.m_idDepartamentoDestino;
			}
		}        
	}
}
