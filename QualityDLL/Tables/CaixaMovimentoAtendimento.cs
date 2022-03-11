using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("CaixaMovimentoAtendimento")]
	public class CaixaMovimentoAtendimento: TTableBase
	{
		[TColumn("idCaixaMovimentoAtendimento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idCaixaMovimentoAtendimento = new TFieldInteger();
		public TFieldInteger idCaixaMovimentoAtendimento
		{
			get{return this.m_idCaixaMovimentoAtendimento;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[
			TColumn("idCaixaMovimento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCaixaMovimento->idCaixaMovimento"})
		]
		private CaixaMovimento m_idCaixaMovimento = null;
		public CaixaMovimento caixaMovimento
		{
			get
			{
				if(this.m_idCaixaMovimento == null)
				{
					this.m_idCaixaMovimento = new CaixaMovimento();

					foreach (TJoin attribute in this.m_idCaixaMovimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCaixaMovimento.connectionString = this.connectionString;
							this.m_idCaixaMovimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCaixaMovimento.selfFill();

				return this.m_idCaixaMovimento;
			}
		}

		[
			TColumn("idAtendimento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idAtendimento->idAtendimento"})
		]
		private Atendimento m_idAtendimento = null;
		public Atendimento atendimento
		{
			get
			{
				if(this.m_idAtendimento == null)
				{
					this.m_idAtendimento = new Atendimento();

					foreach (TJoin attribute in this.m_idAtendimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idAtendimento.connectionString = this.connectionString;
							this.m_idAtendimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idAtendimento.selfFill();

				return this.m_idAtendimento;
			}
		}

		[
			TColumn("idCliente", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idCliente->idEmpresaRelacionamento"})
		]
		private EmpresaRelacionamento m_idCliente = null;
		public EmpresaRelacionamento cliente
		{
			get
			{
				if(this.m_idCliente == null)
				{
                    this.m_idCliente = new EmpresaRelacionamento();

					foreach (TJoin attribute in this.m_idCliente.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idCliente.connectionString = this.connectionString;
							this.m_idCliente.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idCliente.selfFill();

				return this.m_idCliente;
			}
		}
	}
}
