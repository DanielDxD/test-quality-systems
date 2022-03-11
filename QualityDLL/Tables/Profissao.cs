using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Profissao")]
	public class Profissao: TTableBase
	{
		[TColumn("idProfissao", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idProfissao = new TFieldInteger();
		public TFieldInteger idProfissao
		{
			get{return this.m_idProfissao;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("cbo", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_cbo = new TFieldString();
		public TFieldString cbo
		{
			get{return this.m_cbo;}
		}
		[
			TList(typeof(PessoaFisica)),
			TJoin(new String[]{"idProfissao->idProfissao"})
		]
		private Object m_PessoaFisicas = null;
		public System.Collections.Generic.List<PessoaFisica> pessoaFisicas
		{
			get
			{
				if(this.m_PessoaFisicas != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaFisica) }
						).IsInstanceOfType(this.m_PessoaFisicas)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaFisicas)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaFisicas).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaFisicas).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaFisicas)[i]);

						this.m_PessoaFisicas = em.list(typeof(PessoaFisica), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaFisica>)this.m_PessoaFisicas;
			}
		}
	}
}
