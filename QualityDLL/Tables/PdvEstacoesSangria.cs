using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PdvEstacoesSangria")]
	public class PdvEstacoesSangria: TTableBase
	{
		[TColumn("idPdvEstacaoSangria", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPdvEstacaoSangriaa = new TFieldInteger();
		public TFieldInteger idPdvEstacaoSangria
        {
			get{return this.m_idPdvEstacaoSangriaa; }
		}

		[TColumn("dataSangria", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataSangria = new TFieldDatetime();
		public TFieldDatetime dataSangria
        {
			get{return this.m_dataSangria; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [
			TColumn("idFuncionario", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{ "idFuncionario->idFuncionario" })
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

		[
			TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, false, false),
			TJoin(new String[]{ "idPdvEstacao->idPdvEstacao" })
		]
		private PdvEstacao  m_idPdvEstacao = null;
		public PdvEstacao  pdvEstacao
		{
			get
			{
				if(this.m_idPdvEstacao == null)
				{
                    this.m_idPdvEstacao = new PdvEstacao ();

					foreach (TJoin attribute in this.m_idPdvEstacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPdvEstacao.connectionString = this.connectionString;
							this.m_idPdvEstacao.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPdvEstacao.selfFill();

				return this.m_idPdvEstacao;
			}		
		}
	}
}
