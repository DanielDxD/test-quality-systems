using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TituloSocioSituacao")]
	public class TituloSocioSituacao: TTableBase
	{
		[TColumn("idTituloSocioSituacao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idTituloSocioSituacao = new TFieldInteger();
		public TFieldInteger idTituloSocioSituacao
		{
			get{return this.m_idTituloSocioSituacao;}
		}

        [TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataInicio = new TFieldDatetime();
        public TFieldDatetime dataInicio
        {
            get { return this.m_DataInicio; }
        }

        [TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataFim = new TFieldDatetime();
        public TFieldDatetime dataFim
        {
            get { return this.m_DataFim; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }        

		[
			TColumn("idTituloSocio", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idTituloSocio->idTituloSocio"})
		]
		private TituloSocio m_idTituloSocio = null;
		public TituloSocio tituloSocio
		{
			get
			{
				if(this.m_idTituloSocio == null)
				{
					this.m_idTituloSocio = new TituloSocio();

					foreach (TJoin attribute in this.m_idTituloSocio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTituloSocio.connectionString = this.connectionString;
							this.m_idTituloSocio.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTituloSocio.selfFill();

				return this.m_idTituloSocio;
			}
		}

		[
			TColumn("idSituacao", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{ "idSituacao->idSituacao" })
		]
		private Situacao m_idSituacao = null;
		public Situacao situacao
		{
			get
			{
				if(this.m_idSituacao == null)
				{
                    this.m_idSituacao = new Situacao();

					foreach (TJoin attribute in this.m_idSituacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idSituacao.connectionString = this.connectionString;
							this.m_idSituacao.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idSituacao.selfFill();

				return this.m_idSituacao;
			}
		}
	}
}
