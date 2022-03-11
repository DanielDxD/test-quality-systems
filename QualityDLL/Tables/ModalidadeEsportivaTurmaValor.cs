
using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ModalidadeEsportivaTurmaValor")]
	public class ModalidadeEsportivaTurmaValor : TTableBase
	{
		public ModalidadeEsportivaTurmaValor() : base() {}

		[
			TColumn("idModalidadeEsportivaTurmaValor", System.Data.SqlDbType.BigInt, true, true)
		]
		private TFieldInteger m_idModalidadeEsportivaTurmaValor = new TFieldInteger();
		public TFieldInteger idModalidadeEsportivaTurmaValor 
		{ 
			get { return this.m_idModalidadeEsportivaTurmaValor; }
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
			TColumn("tipoIntervaloVencimento", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_tipoIntervaloVencimento = new TFieldInteger();
		public TFieldInteger tipoIntervaloVencimento 
		{ 
			get { return this.m_tipoIntervaloVencimento; }
		}

		[
			TColumn("valorSocio", System.Data.SqlDbType.Decimal, false, false)
		]
		private TFieldDouble m_valorSocio = new TFieldDouble();
		public TFieldDouble valorSocio 
		{ 
			get { return this.m_valorSocio; }
		}

		[
			TColumn("valorNaoSocio", System.Data.SqlDbType.Decimal, false, false)
		]
		private TFieldDouble m_valorNaoSocio = new TFieldDouble();
		public TFieldDouble valorNaoSocio 
		{ 
			get { return this.m_valorNaoSocio; }
		}

	}
}
