
using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ContratoTurma")]
	public class ContratoTurma : TTableBase
	{
		public ContratoTurma() : base() {}

		[
			TColumn("idContratoTurma", System.Data.SqlDbType.BigInt, true, true)
		]
		private TFieldInteger m_idContratoTurma = new TFieldInteger();
		public TFieldInteger idContratoTurma 
		{ 
			get { return this.m_idContratoTurma; }
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
			TColumn("idModalidadeEsportivaTurma", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idModalidadeEsportivaTurma->idModalidadeEsportivaTurma" })
		]
		private ModalidadeEsportivaTurma m_idModalidadeEsportivaTurma;
		public ModalidadeEsportivaTurma modalidadeEsportivaTurma 
		{ 
			get {
				if (this.m_idModalidadeEsportivaTurma == null)
                {
                    this.m_idModalidadeEsportivaTurma = new ModalidadeEsportivaTurma();

                    foreach (TJoin attribute in this.m_idModalidadeEsportivaTurma.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idModalidadeEsportivaTurma.connectionString = this.connectionString;
                            this.m_idModalidadeEsportivaTurma.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idModalidadeEsportivaTurma.selfFill();

                return this.m_idModalidadeEsportivaTurma;
			} 
		}

	}
}
