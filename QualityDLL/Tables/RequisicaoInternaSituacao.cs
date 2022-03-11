using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoInternaSituacao")]
	public class RequisicaoInternaSituacao: TTableBase
	{
		[TColumn("idRequisicaoInternaSituacao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoInternaSituacao = new TFieldInteger();
		public TFieldInteger idRequisicaoInternaSituacao
		{
			get{return this.m_idRequisicaoInternaSituacao;}
		}

		[TColumn("situacao", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_situacao = new TFieldString();
		public TFieldString situacao
		{
			get{return this.m_situacao;}
		}

		[TColumn("dataSituacao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataSituacao = new TFieldDatetime();
		public TFieldDatetime dataSituacao
		{
			get{return this.m_dataSituacao;}
		}

		[TColumn("idRequisicaoInterna", System.Data.SqlDbType.BigInt, false, false)]
		private TFieldInteger m_idRequisicaoInterna = new TFieldInteger();
        public TFieldInteger idRequisicaoInterna
		{
			get{return this.m_idRequisicaoInterna;}
        }

		[
			TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{"idFuncionario->idFuncionario"})
		]
		private Funcionario m_idFuncionario = null;
		public Funcionario funcionario
		{
			get
			{
				if(this.m_idFuncionario == null)
				{
                    this.m_idFuncionario = new Funcionario();

					foreach (TJoin attribute in this.m_idFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idFuncionario.connectionString = this.connectionString;
							this.m_idFuncionario.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idFuncionario.selfFill();

				return this.m_idFuncionario;
			}
		}
	}
}
