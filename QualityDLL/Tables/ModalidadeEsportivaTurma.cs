
using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ModalidadeEsportivaTurma")]
	public class ModalidadeEsportivaTurma : TTableBase
	{
		public ModalidadeEsportivaTurma() : base() {}

		[
			TColumn("idModalidadeEsportivaTurma", System.Data.SqlDbType.BigInt, true, true)
		]
		private TFieldInteger m_idModalidadeEsportivaTurma = new TFieldInteger();
		public TFieldInteger idModalidadeEsportivaTurma 
		{ 
			get { return this.m_idModalidadeEsportivaTurma; }
		}

		[
			TColumn("idModalidadeEsportiva", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idModalidadeEsportiva->idModalidadeEsportiva" })
		]
		private ModalidadeEsportiva m_idModalidadeEsportiva;
		public ModalidadeEsportiva modalidadeEsportiva 
		{ 
			get {
				if (this.m_idModalidadeEsportiva == null)
                {
                    this.m_idModalidadeEsportiva = new ModalidadeEsportiva();

                    foreach (TJoin attribute in this.m_idModalidadeEsportiva.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idModalidadeEsportiva.connectionString = this.connectionString;
                            this.m_idModalidadeEsportiva.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idModalidadeEsportiva.selfFill();

                return this.m_idModalidadeEsportiva;
			} 
		}

		[
			TColumn("horarioInicial", System.Data.SqlDbType.Time, false, false)
		]
		private TFieldDatetime m_horarioInicial = new TFieldDatetime();
		public TFieldDatetime horarioInicial 
		{ 
			get { return this.m_horarioInicial; }
		}

		[
			TColumn("horarioFinal", System.Data.SqlDbType.Time, false, false)
		]
		private TFieldDatetime m_horarioFinal = new TFieldDatetime();
		public TFieldDatetime horarioFinal 
		{ 
			get { return this.m_horarioFinal; }
		}

		[
			TColumn("toleranciaInicial", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_toleranciaInicial = new TFieldInteger();
		public TFieldInteger toleranciaInicial 
		{ 
			get { return this.m_toleranciaInicial; }
		}

		[
			TColumn("toleranciaFinal", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_toleranciaFinal = new TFieldInteger();
		public TFieldInteger toleranciaFinal 
		{ 
			get { return this.m_toleranciaFinal; }
		}

		[
			TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[] { "idFuncionario->idFuncionario" })
		]
		private Funcionario m_idFuncionario;
		public Funcionario funcionario 
		{ 
			get {
				if (this.m_idFuncionario == null)
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

		[
			TColumn("limiteAlunos", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_limiteAlunos = new TFieldInteger();
		public TFieldInteger limiteAlunos 
		{ 
			get { return this.m_limiteAlunos; }
		}

		[
			TColumn("nivelTurma", System.Data.SqlDbType.VarChar, false, false)
		]
		private TFieldString m_nivelTurma = new TFieldString();
		public TFieldString nivelTurma 
		{ 
			get { return this.m_nivelTurma; }
		}

		[
			TColumn("observacoes", System.Data.SqlDbType.VarChar, false, false)
		]
		private TFieldString m_observacoes = new TFieldString();
		public TFieldString observacoes 
		{ 
			get { return this.m_observacoes; }
		}

		[
			TColumn("tipoControleFrequencia", System.Data.SqlDbType.Char, false, false)
		]
		private TFieldString m_tipoControleFrequencia = new TFieldString();
		public TFieldString tipoControleFrequencia 
		{ 
			get { return this.m_tipoControleFrequencia; }
		}

		[
			TColumn("qtdLimite", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_qtdLimite = new TFieldInteger();
		public TFieldInteger qtdLimite 
		{ 
			get { return this.m_qtdLimite; }
		}

		[
			TColumn("domingo", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_domingo = new TFieldBoolean();
		public TFieldBoolean domingo 
		{ 
			get { return this.m_domingo; }
		}

		[
			TColumn("segunda", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_segunda = new TFieldBoolean();
		public TFieldBoolean segunda 
		{ 
			get { return this.m_segunda; }
		}

		[
			TColumn("terca", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_terca = new TFieldBoolean();
		public TFieldBoolean terca 
		{ 
			get { return this.m_terca; }
		}

		[
			TColumn("quarta", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_quarta = new TFieldBoolean();
		public TFieldBoolean quarta 
		{ 
			get { return this.m_quarta; }
		}

		[
			TColumn("quinta", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_quinta = new TFieldBoolean();
		public TFieldBoolean quinta 
		{ 
			get { return this.m_quinta; }
		}

		[
			TColumn("sexta", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_sexta = new TFieldBoolean();
		public TFieldBoolean sexta 
		{ 
			get { return this.m_sexta; }
		}

		[
			TColumn("sabado", System.Data.SqlDbType.Bit, false, false)
		]
		private TFieldBoolean m_sabado = new TFieldBoolean();
		public TFieldBoolean sabado 
		{ 
			get { return this.m_sabado; }
		}

		[
			TColumn("idNaturezaOperacaoMatricula", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[] { "idNaturezaOperacaoMatricula->idNaturezaOperacao" })
		]
		private NaturezaOperacao m_idNaturezaOperacaoMatricula;
		public NaturezaOperacao naturezaOperacaoMatricula 
		{ 
			get {
				if (this.m_idNaturezaOperacaoMatricula == null)
                {
                    this.m_idNaturezaOperacaoMatricula = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_idNaturezaOperacaoMatricula.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idNaturezaOperacaoMatricula.connectionString = this.connectionString;
                            this.m_idNaturezaOperacaoMatricula.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idNaturezaOperacaoMatricula.selfFill();

                return this.m_idNaturezaOperacaoMatricula;
			} 
		}

		[
			TColumn("valorMatriculaSocio", System.Data.SqlDbType.Decimal, false, false)
		]
		private TFieldDouble m_valorMatriculaSocio = new TFieldDouble();
		public TFieldDouble valorMatriculaSocio 
		{ 
			get { return this.m_valorMatriculaSocio; }
		}

		[
			TColumn("valorMatriculaNaoSocio", System.Data.SqlDbType.Decimal, false, false)
		]
		private TFieldDouble m_valorMatriculaNaoSocio = new TFieldDouble();
		public TFieldDouble valorMatriculaNaoSocio 
		{ 
			get { return this.m_valorMatriculaNaoSocio; }
		}

		[
			TColumn("situacao", System.Data.SqlDbType.Char, false, false)
		]
		private TFieldString m_situacao = new TFieldString();
		public TFieldString situacao 
		{ 
			get { return this.m_situacao; }
		}

        [
         TList(typeof(ModalidadeEsportivaTurmaValor)),
         TJoin(new String[] { "idModalidadeEsportivaTurma->idModalidadeEsportivaTurma" })
        ]
        private Object m_Valores = null;
        public System.Collections.Generic.List<ModalidadeEsportivaTurmaValor> valores
        {
            get
            {
                if (this.m_Valores != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ModalidadeEsportivaTurmaValor) }
                     ).IsInstanceOfType(this.m_Valores)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Valores)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Valores).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Valores).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Valores)[i]);

                        this.m_Valores = em.list(typeof(ModalidadeEsportivaTurmaValor), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ModalidadeEsportivaTurmaValor>)this.m_Valores;
            }
        }
    }
}
