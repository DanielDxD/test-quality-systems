using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EmpresaRelacionamentoCartao")]
	public class EmpresaRelacionamentoCartao: TTableBase
	{
		[TColumn("idEmpresaRelacionamentoCartao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idEmpresaRelacionamentoCartao = new TFieldInteger();
		public TFieldInteger idEmpresaRelacionamentoCartao
		{
			get{return this.m_idEmpresaRelacionamentoCartao;}
		}

        [TColumn("saldoAtual", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_saldoAtual = new TFieldDouble();
        public TFieldDouble saldoAtual
        {
            get { return this.m_saldoAtual; }
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
