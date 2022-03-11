
using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ContratoValor")]
	public class ContratoValor : TTableBase
	{
		public ContratoValor() : base() {}

		[
			TColumn("idContratoValor", System.Data.SqlDbType.BigInt, true, true)
		]
		private TFieldInteger m_idContratoValor = new TFieldInteger();
		public TFieldInteger idContratoValor 
		{ 
			get { return this.m_idContratoValor; }
		}

		[
			TColumn("idContrato", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idContrato->idContrato" })
		]
		private Contrato m_idContrato;
		public Contrato contrato 
		{ 
			get {
				if (this.m_idContrato == null)
                {
                    this.m_idContrato = new Contrato();

                    foreach (TJoin attribute in this.m_idContrato.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContrato.connectionString = this.connectionString;
                            this.m_idContrato.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContrato.selfFill();

                return this.m_idContrato;
			} 
		}

		[
			TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)
		]
		private TFieldDatetime m_dataInicio = new TFieldDatetime();
		public TFieldDatetime dataInicio 
		{ 
			get { return this.m_dataInicio; }
		}

		[
			TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)
		]
		private TFieldDatetime m_dataFim = new TFieldDatetime();
		public TFieldDatetime dataFim 
		{ 
			get { return this.m_dataFim; }
		}

		[
			TColumn("valor", System.Data.SqlDbType.Decimal, false, false)
		]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor 
		{ 
			get { return this.m_valor; }
		}

	}
}
