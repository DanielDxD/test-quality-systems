using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PrevisaoOrcamentaria")]
	public class PrevisaoOrcamentaria: TTableBase
	{
		[TColumn("idPrevisaoOrcamentaria", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPrevisaoOrcamentaria = new TFieldInteger();
		public TFieldInteger idPrevisaoOrcamentaria
		{
			get{return this.m_idPrevisaoOrcamentaria;}
        }

        [TColumn("dataReferencia", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_dataReferencia = new TFieldString();
        public TFieldString dataReferencia
        {
            get { return this.m_dataReferencia; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [
			TColumn("idNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{ "idNaturezaOperacao->idNaturezaOperacao" })
		]
		private NaturezaOperacao m_idNaturezaOperacao = null;
		public NaturezaOperacao naturezaOperacao
		{
			get
			{
				if(this.m_idNaturezaOperacao == null)
				{
					this.m_idNaturezaOperacao = new NaturezaOperacao();

					foreach (TJoin attribute in this.m_idNaturezaOperacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idNaturezaOperacao.connectionString = this.connectionString;
							this.m_idNaturezaOperacao.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idNaturezaOperacao.selfFill();

				return this.m_idNaturezaOperacao;
			}
		}

		[
			TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{ "idDepartamento->idDepartamento" })
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
	}
}
