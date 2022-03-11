using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("NotaFiscalEPedidoCompra")]
    public class NotaFiscalEPedidoCompra : TTableBase
    {
        [TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idNotaFiscal = new TFieldInteger();
        public TFieldInteger idNotaFiscal
        {
            get{return this.m_idNotaFiscal;}
        }

        [TColumn("idPedidoCompra", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idPedidoCompra = new TFieldInteger();
        public TFieldInteger idPedidoCompra
        {
            get{return this.m_idPedidoCompra;}
        }
    }
}