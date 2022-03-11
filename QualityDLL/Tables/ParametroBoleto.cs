using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ParametroBoleto")]
	public class ParametroBoleto: TTableBase
	{
		[TColumn("idParametroBoleto", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idParametroBoleto = new TFieldInteger();
		public TFieldInteger idParametroBoleto
		{
			get{return this.m_idParametroBoleto;}
		}

		[TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_idEmpresa = new TFieldInteger();
		public TFieldInteger idEmpresa
		{
			get { return this.m_idEmpresa; }
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get { return this.m_descricao; }
		}

		[TColumn("codigoEstacao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoEstacao = new TFieldString();
		public TFieldString codigoEstacao
		{
			get { return this.m_codigoEstacao; }
		}

		[TColumn("codigoConvenio", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoConvenio = new TFieldString();
		public TFieldString codigoConvenio
		{
			get { return this.m_codigoConvenio; }
		}

		[TColumn("codigoConvenioDigito", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoConvenioDigito = new TFieldString();
		public TFieldString codigoConvenioDigito
		{
			get { return this.m_codigoConvenioDigito; }
		}

		[TColumn("codigoCarteira", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoCarteira = new TFieldString();
		public TFieldString codigoCarteira
		{
			get { return this.m_codigoCarteira; }
		}

		[TColumn("valorTaxa", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valorTaxa = new TFieldDouble();
		public TFieldDouble valorTaxa
		{
			get { return this.m_valorTaxa; }
		}

		[TColumn("variacao", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_variacao = new TFieldInteger();
		public TFieldInteger variacao
		{
			get { return this.m_variacao; }
		}

		[TColumn("padraoArquivo", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_padraoArquivo = new TFieldString();
		public TFieldString padraoArquivo
		{
			get { return this.m_padraoArquivo; }
		}

		[TColumn("tipoCadastramento", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_tipoCadastramento = new TFieldInteger();
		public TFieldInteger tipoCadastramento
		{
			get { return this.m_tipoCadastramento; }
		}

		[TColumn("tipoDocumento", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_tipoDocumento = new TFieldInteger();
		public TFieldInteger tipoDocumento
		{
			get { return this.m_tipoDocumento; }
		}

		[TColumn("identificadorEmissao", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_identificadorEmissao = new TFieldInteger();
		public TFieldInteger identificadorEmissao
		{
			get { return this.m_identificadorEmissao; }
		}

		[TColumn("especieTitulo", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_especieTitulo = new TFieldInteger();
		public TFieldInteger especieTitulo
		{
			get { return this.m_especieTitulo; }
		}

		[TColumn("instrucaoCodificada1", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_instrucaoCodificada1 = new TFieldInteger();
		public TFieldInteger instrucaoCodificada1
		{
			get { return this.m_instrucaoCodificada1; }
		}

		[TColumn("instrucaoCodificada2", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_instrucaoCodificada2 = new TFieldInteger();
		public TFieldInteger instrucaoCodificada2
		{
			get { return this.m_instrucaoCodificada2; }
		}

		[TColumn("prazoProtesto", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_prazoProtesto = new TFieldInteger();
		public TFieldInteger prazoProtesto
		{
			get { return this.m_prazoProtesto; }
		}

		[TColumn("codigoDevolucao", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_codigoDevolucao = new TFieldInteger();
		public TFieldInteger codigoDevolucao
		{
			get { return this.m_codigoDevolucao; }
		}

		[TColumn("prazoDevolucao", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_prazoDevolucao = new TFieldInteger();
		public TFieldInteger prazoDevolucao
		{
			get { return this.m_prazoDevolucao; }
		}

		[TColumn("tipoJuro", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_tipoJuro = new TFieldInteger();
		public TFieldInteger tipoJuro
		{
			get { return this.m_tipoJuro; }
		}

		[TColumn("tipoMulta", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_tipoMulta = new TFieldInteger();
		public TFieldInteger tipoMulta
		{
			get { return this.m_tipoMulta; }
		}


		[
			TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idContaPagamento->idContaPagamento"})
		]
		private ContaPagamento m_idContaPagamento = null;
		public ContaPagamento contaPagamento
		{
			get
			{
				if(this.m_idContaPagamento == null)
				{
                    this.m_idContaPagamento = new ContaPagamento();

					foreach (TJoin attribute in this.m_idContaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idContaPagamento.connectionString = this.connectionString;
							this.m_idContaPagamento.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idContaPagamento.selfFill();

				return this.m_idContaPagamento;
			}
		}

		
		[
			TList(typeof(ParametroBoletoNossoNumero)),
			TJoin(new String[]{"idParametroBoleto->idParametroBoleto"})
		]
		private Object m_ParametroBoletoNossoNumeros = null;
		public System.Collections.Generic.List<ParametroBoletoNossoNumero> parametroBoletoNossoNumeros
		{
			get
			{
				if(this.m_ParametroBoletoNossoNumeros != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(ParametroBoletoNossoNumero) }
						).IsInstanceOfType(this.m_ParametroBoletoNossoNumeros)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ParametroBoletoNossoNumeros)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ParametroBoletoNossoNumeros).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ParametroBoletoNossoNumeros).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ParametroBoletoNossoNumeros)[i]);

						this.m_ParametroBoletoNossoNumeros = em.list(typeof(ParametroBoletoNossoNumero), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<ParametroBoletoNossoNumero>)this.m_ParametroBoletoNossoNumeros;
			}
		}
	}
}
