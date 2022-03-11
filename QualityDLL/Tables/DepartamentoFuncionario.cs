using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("DepartamentoFuncionario")]
	public class DepartamentoFuncionario: TTableBase
	{
		[TColumn("idDepartamentoFuncionario", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idDepartamentoFuncionario = new TFieldInteger();
		public TFieldInteger idDepartamentoFuncionario
		{
			get{return this.m_idDepartamentoFuncionario;}
		}

		[TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataInicio = new TFieldDatetime();
		public TFieldDatetime dataInicio
		{
			get{return this.m_dataInicio;}
		}

		[TColumn("dataTermino", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataTermino = new TFieldDatetime();
		public TFieldDatetime dataTermino
		{
			get{return this.m_dataTermino;}
		}

		[TColumn("responsavel", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_responsavel = new TFieldBoolean();
		public TFieldBoolean responsavel
		{
			get{return this.m_responsavel;}
		}

		[
			TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idDepartamento->idDepartamento"})
		]
		private Departamento m_idDepartamento = null;
		public Departamento departamento
		{
			get
			{
				if(this.m_idDepartamento == null)
				{
					this.m_idDepartamento = new Departamento();

					foreach (TJoin attribute in this.m_idDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idDepartamento.connectionString = this.connectionString;
							this.m_idDepartamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idDepartamento.selfFill();

				return this.m_idDepartamento;
			}
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
