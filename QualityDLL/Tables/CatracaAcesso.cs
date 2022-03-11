using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("CatracaAcesso")]
	public class CatracaAcesso: TTableBase
	{
		[TColumn("idCatracaAcesso", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idCatracaAcesso = new TFieldInteger();
		public TFieldInteger idCatracaAcesso
		{
			get{return this.m_idCatracaAcesso;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
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
