using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("NotaFiscalEEntradaMercadoria")]
    public class NotaFiscalEEntradaMercadoria : TTableBase
    {
        [TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idNotaFiscal = new TFieldInteger();
        public TFieldInteger idNotaFiscal
        {
            get { return this.m_idNotaFiscal; }
        }

        [TColumn("idEntradaMercadoria", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idEntradaMercadoria = new TFieldInteger();
        public TFieldInteger idEntradaMercadoria
        {
            get { return this.m_idEntradaMercadoria; }
        }
    }
}