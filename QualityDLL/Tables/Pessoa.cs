using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Pessoa")]
	public class Pessoa: TTableBase
	{
		[TColumn("idPessoa", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPessoa = new TFieldInteger();
		public TFieldInteger idPessoa
		{
			get{return this.m_idPessoa;}
		}

		[TColumn("pfpj", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_pfpj = new TFieldString();
		public TFieldString pfpj
		{
			get{return this.m_pfpj;}
		}

		[TColumn("cpfCnpj", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_cpfCnpj = new TFieldString();
		public TFieldString cpfCnpj
		{
			get{return this.m_cpfCnpj;}
		}

		[TColumn("nomeRazaoSocial", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_nomeRazaoSocial = new TFieldString();
		public TFieldString nomeRazaoSocial
		{
			get{return this.m_nomeRazaoSocial;}
		}

		[TColumn("apelidoNomeComercial", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_apelidoNomeComercial = new TFieldString();
		public TFieldString apelidoNomeComercial
		{
			get{return this.m_apelidoNomeComercial;}
		}

		[
			TList(typeof(EmpresaRelacionamento)),
			TJoin(new String[]{"idPessoa->idPessoaRelacionamento"})
		]
		private Object m_EmpresaRelacionamentos = null;
		public System.Collections.Generic.List<EmpresaRelacionamento> empresaRelacionamentos
		{
			get
			{
				if(this.m_EmpresaRelacionamentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(EmpresaRelacionamento) }
						).IsInstanceOfType(this.m_EmpresaRelacionamentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_EmpresaRelacionamentos)[i]);

						this.m_EmpresaRelacionamentos = em.list(typeof(EmpresaRelacionamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<EmpresaRelacionamento>)this.m_EmpresaRelacionamentos;
			}
		}

		[
			TList(typeof(PessoaContato)),
			TJoin(new String[]{"idPessoa->idPessoaContato"})
		]
		private Object m_PessoaContatos = null;
		public System.Collections.Generic.List<PessoaContato> pessoaContatos
		{
			get
			{
				if(this.m_PessoaContatos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaContato) }
						).IsInstanceOfType(this.m_PessoaContatos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaContatos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaContatos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaContatos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaContatos)[i]);

						this.m_PessoaContatos = em.list(typeof(PessoaContato), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaContato>)this.m_PessoaContatos;
			}
		}

		[
			TList(typeof(PessoaEnderecoContato)),
			TJoin(new String[]{"idPessoa->idPessoa"})
		]
		private Object m_PessoaEnderecoContatos = null;
		public System.Collections.Generic.List<PessoaEnderecoContato> pessoaEnderecoContatos
		{
			get
			{
				if(this.m_PessoaEnderecoContatos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaEnderecoContato) }
						).IsInstanceOfType(this.m_PessoaEnderecoContatos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoContatos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoContatos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoContatos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaEnderecoContatos)[i]);

						this.m_PessoaEnderecoContatos = em.list(typeof(PessoaEnderecoContato), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaEnderecoContato>)this.m_PessoaEnderecoContatos;
			}
		}

		[
			TList(typeof(PessoaFisica)),
			TJoin(new String[]{"idPessoa->idPessoaFisica"})
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

		[
			TList(typeof(PessoaJuridica)),
			TJoin(new String[]{"idPessoa->idPessoaJuridica"})
		]
		private Object m_PessoaJuridicas = null;
		public System.Collections.Generic.List<PessoaJuridica> pessoaJuridicas
		{
			get
			{
				if(this.m_PessoaJuridicas != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaJuridica) }
						).IsInstanceOfType(this.m_PessoaJuridicas)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaJuridicas)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaJuridicas).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaJuridicas).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaJuridicas)[i]);

						this.m_PessoaJuridicas = em.list(typeof(PessoaJuridica), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaJuridica>)this.m_PessoaJuridicas;
			}
		}

		[
			TList(typeof(PessoaRelacionamento)),
			TJoin(new String[]{"idPessoa->idPessoa"})
		]
		private Object m_PessoaRelacionamentos = null;
		public System.Collections.Generic.List<PessoaRelacionamento> pessoaRelacionamentos
		{
			get
			{
				if(this.m_PessoaRelacionamentos != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaRelacionamento) }
						).IsInstanceOfType(this.m_PessoaRelacionamentos)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos)[i]);

						this.m_PessoaRelacionamentos = em.list(typeof(PessoaRelacionamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaRelacionamento>)this.m_PessoaRelacionamentos;
			}
		}

		[
			TList(typeof(PessoaRelacionamento)),
			TJoin(new String[]{"idPessoa->idPessoaRelacionada"})
		]
		private Object m_PessoaRelacionamentos1 = null;
		public System.Collections.Generic.List<PessoaRelacionamento> pessoaRelacionamentos1
		{
			get
			{
				if(this.m_PessoaRelacionamentos1 != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(PessoaRelacionamento) }
						).IsInstanceOfType(this.m_PessoaRelacionamentos1)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos1)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos1).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos1).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaRelacionamentos1)[i]);

						this.m_PessoaRelacionamentos = em.list(typeof(PessoaRelacionamento), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<PessoaRelacionamento>)this.m_PessoaRelacionamentos1;
			}
		}

        [
         TList(typeof(PessoaImagem)),
         TJoin(new String[] { "idPessoa->idPessoa" })
        ]
        private Object m_PessoaImagems = null;
        public System.Collections.Generic.List<PessoaImagem> pessoaImagems
        {
            get
            {
                if (this.m_PessoaImagems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PessoaImagem) }
                     ).IsInstanceOfType(this.m_PessoaImagems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaImagems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaImagems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaImagems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaImagems)[i]);

                        this.m_PessoaImagems = em.list(typeof(PessoaImagem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PessoaImagem>)this.m_PessoaImagems;
            }
        }
	}
}
