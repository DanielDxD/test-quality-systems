using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PerfilMenu")]
	public class PerfilMenu: TTableBase
	{
		[TColumn("idPerfilMenu", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idPerfilMenu = new TFieldInteger();
		public TFieldInteger idPerfilMenu
		{
			get{return this.m_idPerfilMenu;}
		}

		[TColumn("consultar", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_consultar = new TFieldBoolean();
		public TFieldBoolean consultar
		{
			get{return this.m_consultar;}
		}

		[TColumn("incluir", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_incluir = new TFieldBoolean();
		public TFieldBoolean incluir
		{
			get{return this.m_incluir;}
		}

		[TColumn("alterar", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_alterar = new TFieldBoolean();
		public TFieldBoolean alterar
		{
			get{return this.m_alterar;}
		}

		[TColumn("excluir", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_excluir = new TFieldBoolean();
		public TFieldBoolean excluir
		{
			get{return this.m_excluir;}
		}

		[
			TColumn("idMenu", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idMenu->idMenu"})
		]
		private Menu m_idMenu = null;
		public Menu menu
		{
			get
			{
				if(this.m_idMenu == null)
				{
					this.m_idMenu = new Menu();

					foreach (TJoin attribute in this.m_idMenu.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idMenu.connectionString = this.connectionString;
							this.m_idMenu.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idMenu.selfFill();

				return this.m_idMenu;
			}
		}

		[
			TColumn("idPerfil", System.Data.SqlDbType.Int, false, false),
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
