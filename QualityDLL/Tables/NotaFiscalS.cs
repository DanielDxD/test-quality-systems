using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("NotaFiscalS")]
	public class NotaFiscalS: TTableBase
	{
		[TColumn("idNotaFiscalS", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idNotaFiscalS = new TFieldInteger();
		public TFieldInteger idNotaFiscalS
		{
			get{return this.m_idNotaFiscalS;}
		}

		[TColumn("dataFaturamento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataFaturamento = new TFieldDatetime();
		public TFieldDatetime dataFaturamento
		{
			get{return this.m_dataFaturamento;}
		}

		[TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_valor = new TFieldDouble();
		public TFieldDouble valor
		{
			get{return this.m_valor;}
		}

		[TColumn("iss", System.Data.SqlDbType.Decimal, false, false)]
		private TFieldDouble m_iss = new TFieldDouble();
		public TFieldDouble iss
		{
			get{return this.m_iss;}
		}

		[TColumn("dataVencimento", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataVencimento = new TFieldDatetime();
		public TFieldDatetime dataVencimento
		{
			get{return this.m_dataVencimento;}
		}

		[TColumn("numeroLote", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_numeroLote = new TFieldInteger();
		public TFieldInteger numeroLote
		{
			get{return this.m_numeroLote;}
		}

		[TColumn("numeroRPS", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_numeroRPS = new TFieldInteger();
		public TFieldInteger numeroRPS
		{
			get{return this.m_numeroRPS;}
		}

		[TColumn("numeroNFSE", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_numeroNFSE = new TFieldInteger();
		public TFieldInteger numeroNFSE
		{
			get{return this.m_numeroNFSE;}
		}

		[TColumn("codigoValidacaoNFSE", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoValidacaoNFSE = new TFieldString();
		public TFieldString codigoValidacaoNFSE
		{
			get{return this.m_codigoValidacaoNFSE;}
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
         TColumn("idTipoMovimentoContabil", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoMovimentoContabil->idTipoMovimentoContabil" })
        ]
        private TipoMovimentoContabil m_idTipoMovimentoContabil = null;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get
            {
                if (this.m_idTipoMovimentoContabil == null)
                {
                    this.m_idTipoMovimentoContabil = new TipoMovimentoContabil();

                    foreach (TJoin attribute in this.m_idTipoMovimentoContabil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoMovimentoContabil.connectionString = this.connectionString;
                            this.m_idTipoMovimentoContabil.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoMovimentoContabil.selfFill();

                return this.m_idTipoMovimentoContabil;
            }
        }

        [
			TList(typeof(NotaFiscalSItem)),
			TJoin(new String[]{"idNotaFiscalS->idNotaFiscal"})
		]
		private Object m_NotaFiscalSItems = null;
		public System.Collections.Generic.List<NotaFiscalSItem> notaFiscalSItems
		{
			get
			{
				if(this.m_NotaFiscalSItems != null)
				{
					if
					(
						!typeof(System.Collections.Generic.List<>).MakeGenericType
						(
							new Type[] { typeof(NotaFiscalSItem) }
						).IsInstanceOfType(this.m_NotaFiscalSItems)
					)
					{
						EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems)[0])).value;

						EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems).Count - 1];

						for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems).Count; i++)
							_keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_NotaFiscalSItems)[i]);

						this.m_NotaFiscalSItems = em.list(typeof(NotaFiscalSItem), _keys);
					}
					else { }
                }
				else{}

				return (System.Collections.Generic.List<NotaFiscalSItem>)this.m_NotaFiscalSItems;
			}
		}
	}
}
