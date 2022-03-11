using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("UsuarioPerfil")]
	public class UsuarioPerfil: TTableBase
	{
        [TColumn("idUsuario", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idUsuario = new TFieldInteger();
        public TFieldInteger idUsuario
        {
            get { return this.m_idUsuario; }
        }

		[
			TColumn("idPerfil", System.Data.SqlDbType.Int, true, false),
			TJoin(new String[]{"idPerfil->idPerfil"})
		]
		private Perfil m_idPerfil = null;
		public Perfil perfil
		{
			get
			{
				if(this.m_idPerfil == null)
				{
                    this.m_idPerfil = new Perfil();

					foreach (TJoin attribute in this.m_idPerfil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPerfil.connectionString = this.connectionString;
							this.m_idPerfil.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPerfil.selfFill();

				return this.m_idPerfil;
			}
		}
	}
}
