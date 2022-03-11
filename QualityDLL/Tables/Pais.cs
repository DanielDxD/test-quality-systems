using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Pais")]
	public class Pais: TTableBase
	{
		[TColumn("idPais", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idPais = new TFieldInteger();
		public TFieldInteger idPais
		{
			get{return this.m_idPais;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}
		[
			TList(typeof(Estado)),
			TJoin(new String[]{"idPais->idPais"})
		]
		private Object m_Estados = null;
		public System.Collections.Generic.List<Estado> estados
		{
			get
			{
				if(this.m_Estados != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(Estado) }
						).IsInstanceOfType(this.m_Estados)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Estados)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Estados).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Estados).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Estados)[i]);

						this.m_Estados = em.list(typeof(Estado), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<Estado>)this.m_Estados;
			}
		}
	}
}
