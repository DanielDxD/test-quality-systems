using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ExameEmpresaRelacionamento")]
	public class ExameEmpresaRelacionamento: TTableBase
	{
		[TColumn("idExameEmpresaRelacionamento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idExameEmpresaRelacionamento = new TFieldInteger();
		public TFieldInteger idExameEmpresaRelacionamento
		{
			get{return this.m_idExameEmpresaRelacionamento;}
		}

		[TColumn("dataValidade", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataValidade = new TFieldDatetime();
		public TFieldDatetime dataValidade
		{
			get{return this.m_dataValidade;}
		}

		[TColumn("dataCadastramento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataCadastramento = new TFieldDatetime();
		public TFieldDatetime dataCadastramento
		{
			get{return this.m_dataCadastramento;}
		}

		[TColumn("usuarioCadastramento", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldInteger m_usuarioCadastramento = new TFieldInteger();
		public TFieldInteger usuarioCadastramento
		{
			get{return this.m_usuarioCadastramento;}
		}

		[
			TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idEmpresaRelacionamento->idEmpresaRelacionamento"})
		]
		private EmpresaRelacionamento m_idEmpresaRelacionamento = null;
		public EmpresaRelacionamento empresaRelacionamento
		{
			get
			{
				if(this.m_idEmpresaRelacionamento == null)
				{
                    this.m_idEmpresaRelacionamento = new EmpresaRelacionamento();

					foreach (TJoin attribute in this.m_idEmpresaRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idEmpresaRelacionamento.connectionString = this.connectionString;
							this.m_idEmpresaRelacionamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idEmpresaRelacionamento.selfFill();

				return this.m_idEmpresaRelacionamento;
			}
		}
	}
}
