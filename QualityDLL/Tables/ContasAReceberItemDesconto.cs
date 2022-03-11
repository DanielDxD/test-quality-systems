using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContasAReceberItemDesconto")]
    public class ContasAReceberItemDesconto : TTableBase
    {
        [TColumn("idContasAReceberItemDesconto", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdContasAReceberItemDesconto = new TFieldInteger();
        public TFieldInteger idContasAReceberItemDesconto
        {
            get { return this.m_IdContasAReceberItemDesconto; }
        }

        [TColumn("idContasAReceberItem", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idContasAReceberItem->idContasAReceberItem" })]
        private ContasAReceberItem m_IdContasAReceberItem = null;
        public ContasAReceberItem contasAReceberItem
        {
            get
            {
                if (this.m_IdContasAReceberItem == null)
                {
                    this.m_IdContasAReceberItem = new ContasAReceberItem();
                    foreach (TJoin attribute in this.m_IdContasAReceberItem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContasAReceberItem.connectionString = this.connectionString;
                            this.m_IdContasAReceberItem.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContasAReceberItem.selfFill();
                return this.m_IdContasAReceberItem;
            }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_ValorDesconto; }
        }

        [TColumn("dataLimite", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataLimite = new TFieldDatetime();
        public TFieldDatetime dataLimite
        {
            get { return this.m_DataLimite; }
        }

    }
}
