using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Boleto")]
    public class Boleto : TTableBase
    {
        [TColumn("idBoleto", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idBoleto = new TFieldInteger();
        public TFieldInteger idBoleto
        {
            get { return this.m_idBoleto; }
        }

        [
            TColumn("idParametroBoleto", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idParametroBoleto->idParametroBoleto" })
        ]
        private ParametroBoleto m_idParametroBoleto = null;
        public ParametroBoleto parametroBoleto
        {
            get
            {
                if (this.m_idParametroBoleto == null)
                {
                    this.m_idParametroBoleto = new ParametroBoleto();

                    foreach (TJoin attribute in this.m_idParametroBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idParametroBoleto.connectionString = this.connectionString;
                            this.m_idParametroBoleto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idParametroBoleto.selfFill();

                return this.m_idParametroBoleto;
            }
        }

        [TColumn("dataEmissao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataEmissao = new TFieldDatetime();
        public TFieldDatetime dataEmissao
        {
            get { return this.m_dataEmissao; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("dataVencimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataVencimento = new TFieldDatetime();
        public TFieldDatetime dataVencimento
        {
            get { return this.m_dataVencimento; }
        }

        [TColumn("nossoNumero", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nossoNumero = new TFieldString();
        public TFieldString nossoNumero
        {
            get { return this.m_nossoNumero; }
        }

        [TColumn("codigoBarras", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoBarras = new TFieldString();
        public TFieldString codigoBarras
        {
            get { return this.m_codigoBarras; }
        }

        [TColumn("valorTaxa", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorTaxa = new TFieldDouble();
        public TFieldDouble valorTaxa
        {
            get { return this.m_valorTaxa; }
        }

        [TColumn("dataRegistro", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataRegistro = new TFieldDatetime();
        public TFieldDatetime dataRegistro
        {
            get { return this.m_dataRegistro; }
        }

        [TColumn("statusBoleto", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_statusBoleto = new TFieldString();
        public TFieldString statusBoleto
        {
            get { return this.m_statusBoleto; }
        }

        [TColumn("codigoRetorno", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_codigoRetorno = new TFieldInteger();
        public TFieldInteger codigoRetorno
        {
            get { return this.m_codigoRetorno; }
        }

        [
            TList(typeof(BoletoItem)),
            TJoin(new String[] { "idBoleto->idBoleto" })
        ]

        [TColumn("nossoNumeroDigito", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nossoNumeroDigito = new TFieldString();
        public TFieldString nossoNumeroDigito
        {
            get { return this.m_nossoNumeroDigito; }
        }

        [
         TList(typeof(BoletoItem)),
         TJoin(new String[] { "idBoleto->idBoleto" })
        ]
        private Object m_BoletoItems = null;
        public System.Collections.Generic.List<BoletoItem> boletoItems
        {
            get
            {
                if (this.m_BoletoItems != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(BoletoItem) }
                        ).IsInstanceOfType(this.m_BoletoItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_BoletoItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_BoletoItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_BoletoItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_BoletoItems)[i]);

                        this.m_BoletoItems = em.list(typeof(BoletoItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<BoletoItem>)this.m_BoletoItems;
            }
        }
    }
}
