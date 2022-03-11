
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("BoletoNsu")]
    public class BoletoNsu : TTableBase
    {
        [TColumn("idBoletoNsu", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdBoletoNsu = new TFieldInteger();
        public TFieldInteger idBoletoNsu
        {
            get { return this.m_IdBoletoNsu; }
        }

        [TColumn("idBoleto", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idBoleto->idBoleto" })]
        private Boleto m_IdBoleto = null;
        public Boleto boleto
        {
            get
            {
                if (this.m_IdBoleto == null)
                {
                    this.m_IdBoleto = new Boleto();
                    foreach (TJoin attribute in this.m_IdBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdBoleto.connectionString = this.connectionString;
                            this.m_IdBoleto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdBoleto.selfFill();
                return this.m_IdBoleto;
            }
        }

        [TColumn("nsu", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Nsu = new TFieldString();
        public TFieldString nsu
        {
            get { return this.m_Nsu; }
        }

        [TColumn("dataRegistro", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataRegistro = new TFieldDatetime();
        public TFieldDatetime dataRegistro
        {
            get { return this.m_DataRegistro; }
        }

    }
}
