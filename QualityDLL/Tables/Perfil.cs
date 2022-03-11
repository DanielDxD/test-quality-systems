using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Perfil")]
	public class Perfil: TTableBase
	{
		[TColumn("idPerfil", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idPerfil = new TFieldInteger();
		public TFieldInteger idPerfil
		{
			get{return this.m_idPerfil;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("administrador", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_administrador = new TFieldBoolean();
		public TFieldBoolean administrador
		{
			get{return this.m_administrador;}
		}

        [
			TList(typeof(PerfilMenu)),
			TJoin(new String[]{"idPerfil->idPerfil"})
		]
		private Object m_PerfilMenus = null;
		public System.Collections.Generic.List<PerfilMenu> perfilMenus
		{
			get
			{
				if(this.m_PerfilMenus != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PerfilMenu) }
						).IsInstanceOfType(this.m_PerfilMenus)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PerfilMenus)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PerfilMenus).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PerfilMenus).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PerfilMenus)[i]);

						this.m_PerfilMenus = em.list(typeof(PerfilMenu), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PerfilMenu>)this.m_PerfilMenus;
			}
		}

        [
            TList(typeof(RelatorioPerfil)),
            TJoin(new String[] { "idPerfil->idPerfil" })
        ]
        private Object m_RelatorioPerfil = null;
        public System.Collections.Generic.List<RelatorioPerfil> relatorioPerfil
        {
            get
            {
                if (this.m_RelatorioPerfil != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(RelatorioPerfil) }
                        ).IsInstanceOfType(this.m_RelatorioPerfil)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioPerfil)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RelatorioPerfil).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RelatorioPerfil).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioPerfil)[i]);

                        this.m_RelatorioPerfil = em.list(typeof(RelatorioPerfil), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<RelatorioPerfil>)this.m_RelatorioPerfil;
            }
        }

    }
}
