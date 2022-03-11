
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContratoTipoItemValores")]
    public class ContratoTipoItemValor : TTableBase
    {
        [TColumn("idContratoTipoItemValor", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdContratoTipoItemValor = new TFieldInteger();
        public TFieldInteger idContratoTipoItemValor
        {
            get { return this.m_IdContratoTipoItemValor; }
        }

        [TColumn("idContratoTipoItem", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idContratoTipoItem->idContratoTipoItem" })]
        private ContratoTipoItem m_IdContratoTipoItem = null;
        public ContratoTipoItem contratoTipoItem
        {
            get
            {
                if (this.m_IdContratoTipoItem == null)
                {
                    this.m_IdContratoTipoItem = new ContratoTipoItem();
                    foreach (TJoin attribute in this.m_IdContratoTipoItem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContratoTipoItem.connectionString = this.connectionString;
                            this.m_IdContratoTipoItem.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContratoTipoItem.selfFill();
                return this.m_IdContratoTipoItem;
            }
        }

        [TColumn("periodoInicial", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_PeriodoInicial = new TFieldDatetime();
        public TFieldDatetime periodoInicial
        {
            get { return this.m_PeriodoInicial; }
        }

        [TColumn("periodoFinal", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_PeriodoFinal = new TFieldDatetime();
        public TFieldDatetime periodoFinal
        {
            get { return this.m_PeriodoFinal; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDecimal m_Valor = new TFieldDecimal();
        public TFieldDecimal valor
        {
            get { return this.m_Valor; }
        }

    }
}
