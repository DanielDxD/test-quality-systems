using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TituloConsignacao")]
	public class TituloConsignacao: TTableBase
	{
		[TColumn("idTituloConsignacao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idTituloConsignacao = new TFieldInteger();
		public TFieldInteger idTituloConsignacao
		{
			get{return this.m_idTituloConsignacao;}
		}

		[TColumn("dataConsignacao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataConsignacao = new TFieldDatetime();
		public TFieldDatetime dataConsignacao
		{
			get{return this.m_dataConsignacao;}
		}

		[TColumn("dataDevolucao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataDevolucao = new TFieldDatetime();
		public TFieldDatetime dataDevolucao
		{
			get{return this.m_dataDevolucao;}
		}

		[TColumn("motivo", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_motivo = new TFieldInteger();
		public TFieldInteger motivo
		{
			get{return this.m_motivo;}
		}

		[TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_observacao = new TFieldString();
		public TFieldString observacao
		{
			get{return this.m_observacao;}
		}

		[
			TColumn("idTitulo", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idTitulo->idTitulo"})
		]
		private Titulo m_idTitulo = null;
		public Titulo titulo
		{
			get
			{
				if(this.m_idTitulo == null)
				{
					this.m_idTitulo = new Titulo();

					foreach (TJoin attribute in this.m_idTitulo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTitulo.connectionString = this.connectionString;
							this.m_idTitulo.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTitulo.selfFill();

				return this.m_idTitulo;
			}
		}

		[
			TColumn("idEmpresaRelacionamentoCorretor", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idEmpresaRelacionamentoCorretor->idEmpresaRelacionamento"})
		]
		private EmpresaRelacionamento m_idEmpresaRelacionamentoCorretor = null;
		public EmpresaRelacionamento corretorEmpresaRelacionamento
		{
			get
			{
				if(this.m_idEmpresaRelacionamentoCorretor == null)
				{
                    this.m_idEmpresaRelacionamentoCorretor = new EmpresaRelacionamento();

					foreach (TJoin attribute in this.m_idEmpresaRelacionamentoCorretor.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEmpresaRelacionamentoCorretor.connectionString = this.connectionString;
							this.m_idEmpresaRelacionamentoCorretor.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEmpresaRelacionamentoCorretor.selfFill();

				return this.m_idEmpresaRelacionamentoCorretor;
			}
		}

		[
			TList(typeof(TituloConsignacaoVenda)),
			TJoin(new String[]{"idTituloConsignacao->idTituloConsignacaoVenda"})
		]
		private Object m_TituloConsignacaoVendas = null;
		public System.Collections.Generic.List<TituloConsignacaoVenda> tituloConsignacaoVendas
		{
			get
			{
				if(this.m_TituloConsignacaoVendas != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(TituloConsignacaoVenda) }
						).IsInstanceOfType(this.m_TituloConsignacaoVendas)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendas)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendas).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendas).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaoVendas)[i]);

						this.m_TituloConsignacaoVendas = em.list(typeof(TituloConsignacaoVenda), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<TituloConsignacaoVenda>)this.m_TituloConsignacaoVendas;
			}
		}
	}
}
