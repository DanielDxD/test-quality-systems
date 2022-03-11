using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PontoAtendimento")]
	public class PontoAtendimento: TTableBase
	{
		[TColumn("idPontoAtendimento", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idPontoAtendimento = new TFieldInteger();
		public TFieldInteger idPontoAtendimento
		{
			get{return this.m_idPontoAtendimento;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("tipo", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_tipo = new TFieldString();
		public TFieldString tipo
		{
			get{return this.m_tipo;}
		}

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

		[
			TList(typeof(Atendimento)),
			TJoin(new String[]{"idPontoAtendimento->idPontoAtendimento"})
		]
		private Object m_Atendimentos = null;
		public System.Collections.Generic.List<Atendimento> atendimentos
		{
			get
			{
				if(this.m_Atendimentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(Atendimento) }
						).IsInstanceOfType(this.m_Atendimentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Atendimentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Atendimentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Atendimentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Atendimentos)[i]);

						this.m_Atendimentos = em.list(typeof(Atendimento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<Atendimento>)this.m_Atendimentos;
			}
		}
	}
}
