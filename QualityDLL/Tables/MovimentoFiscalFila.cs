
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("MovimentoFiscalFila")]
    public class MovimentoFiscalFila : TTableBase
    {
        [TColumn("idMovimentoFiscalFila", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdMovimentoFiscalFila = new TFieldInteger();
        public TFieldInteger idMovimentoFiscalFila
        {
            get { return this.m_IdMovimentoFiscalFila; }
        }

        [
            TColumn("idPdvCompra", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private PdvCompra m_IdPdvCompra = null;
        public PdvCompra pdvCompra
        {
            get
            {
                if (this.m_IdPdvCompra == null)
                {
                    this.m_IdPdvCompra = new PdvCompra();
                    foreach (TJoin attribute in this.m_IdPdvCompra.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPdvCompra.connectionString = this.connectionString;
                            this.m_IdPdvCompra.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdPdvCompra.selfFill();
                return this.m_IdPdvCompra;
            }
        }

        [TColumn("ordem", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Ordem = new TFieldInteger();
        public TFieldInteger ordem
        {
            get { return this.m_Ordem; }
        }

        [TColumn("status", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_StatusNfc = new TFieldString();
        public TFieldString statusNfc
        {
            get { return this.m_StatusNfc; }
        }

    }
}
