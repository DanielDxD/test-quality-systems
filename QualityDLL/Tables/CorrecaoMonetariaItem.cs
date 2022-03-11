
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("CorrecaoMonetariaItem")]
    public class CorrecaoMonetariaItem : TTableBase
    {
        [TColumn("idCorrecaoMonetariaItem", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdCorrecaoMonetariaItem = new TFieldInteger();
        public TFieldInteger idCorrecaoMonetariaItem
        {
            get { return this.m_IdCorrecaoMonetariaItem; }
        }

        [TColumn("idCorrecaoMonetaria", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idCorrecaoMonetaria->idCorrecaoMonetaria" })]
        private CorrecaoMonetaria m_IdCorrecaoMonetaria = null;
        public CorrecaoMonetaria correcaoMonetaria
        {
            get
            {
                if (this.m_IdCorrecaoMonetaria == null)
                {
                    this.m_IdCorrecaoMonetaria = new CorrecaoMonetaria();
                    foreach (TJoin attribute in this.m_IdCorrecaoMonetaria.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCorrecaoMonetaria.connectionString = this.connectionString;
                            this.m_IdCorrecaoMonetaria.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCorrecaoMonetaria.selfFill();
                return this.m_IdCorrecaoMonetaria;
            }
        }

        [TColumn("mesReferencia", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_MesReferencia = new TFieldString();
        public TFieldString mesReferencia
        {
            get { return this.m_MesReferencia; }
        }

        [TColumn("valorIndice", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorIndice = new TFieldDouble();
        public TFieldDouble valorIndice
        {
            get { return this.m_ValorIndice; }
        }

    }
}
