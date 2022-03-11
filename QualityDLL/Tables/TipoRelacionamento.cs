using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoRelacionamento")]
	public class TipoRelacionamento: TTableBase
	{
		[TColumn("idTipoRelacionamento", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoRelacionamento = new TFieldInteger();
		public TFieldInteger idTipoRelacionamento
		{
			get{return this.m_idTipoRelacionamento;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("pfpj", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_pfpj = new TFieldString();
		public TFieldString pfpj
		{
			get{return this.m_pfpj;}
		}

		[
			TColumn("idEstadoCivil", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idEstadoCivil->idEstadoCivil"})
		]
		private EstadoCivil m_idEstadoCivil = null;
		public EstadoCivil estadoCivil
		{
			get
			{
				if(this.m_idEstadoCivil == null)
				{
                    this.m_idEstadoCivil = new EstadoCivil();

					foreach (TJoin attribute in this.m_idEstadoCivil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEstadoCivil.connectionString = this.connectionString;
							this.m_idEstadoCivil.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEstadoCivil.selfFill();

				return this.m_idEstadoCivil;
			}
		}

        [TColumn("presidente", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_presidente = new TFieldBoolean();
        public TFieldBoolean presidente
        {
            get { return this.m_presidente; }
        }
    }
}
