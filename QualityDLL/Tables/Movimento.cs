using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Movimento")]
	public class Movimento: TTableBase
	{
		[TColumn("idMovimento", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idMovimento = new TFieldInteger();
		public TFieldInteger idMovimento
		{
			get{return this.m_idMovimento;}
		}

		[TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataMovimento = new TFieldDatetime();
		public TFieldDatetime dataMovimento
		{
			get{return this.m_dataMovimento;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
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

		[
			TColumn("idTipoMovimento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idTipoMovimento->idTipoMovimento"})
		]
		private TipoMovimento m_idTipoMovimento = null;
		public TipoMovimento tipoMovimento
		{
			get
			{
				if(this.m_idTipoMovimento == null)
				{
                    this.m_idTipoMovimento = new TipoMovimento();

					foreach (TJoin attribute in this.m_idTipoMovimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idTipoMovimento.connectionString = this.connectionString;
							this.m_idTipoMovimento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idTipoMovimento.selfFill();

				return this.m_idTipoMovimento;
			}
		}
	}
}
