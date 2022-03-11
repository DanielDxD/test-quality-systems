using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TituloSocioDependente")]
	public class TituloSocioDependente: TTableBase
	{

        [
            TColumn("idTituloSocioDependente", System.Data.SqlDbType.BigInt, true, true),
        ]
        private TFieldInteger m_idTituloSocioDependente = new TFieldInteger();
        public TFieldInteger idTituloSocioDependente
        {
            get { return this.m_idTituloSocioDependente; }
            set { this.m_idTituloSocioDependente = value; }
        }


        [
            TColumn("idTituloSocio", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idTituloSocio->idTituloSocio" })
        ]
        private TituloSocio m_idTituloSocio = null;
        public TituloSocio tituloSocio
        {
            get
            {
                if (this.m_idTituloSocio == null)
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
			TColumn("idTipoRelacionamento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{ "idTipoRelacionamento->idTipoRelacionamento" })
		]
		private TipoRelacionamento m_idTipoRelacionamento = null;
		public TipoRelacionamento tipoRelacionamento
		{
			get
			{
				if(this.m_idTipoRelacionamento == null)
				{
					this.m_idTipoRelacionamento = new TipoRelacionamento();

					foreach (TJoin attribute in this.m_idTipoRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoRelacionamento.connectionString = this.connectionString;
							this.m_idTipoRelacionamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoRelacionamento.selfFill();

				return this.m_idTipoRelacionamento;
			}
		}
	}
}
