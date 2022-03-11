using System;

namespace Data
{
    //[Serializable]
    public class NotaFiscalEPedidoCompra : Base
    {
        public NotaFiscalEPedidoCompra()
            : base()
        {
        }


        private int m_IdNotaFiscal;
        public int idNotaFiscal
        {
            get { return this.m_IdNotaFiscal; }
            set { this.m_IdNotaFiscal = value; }
        }

        private int m_IdPedidoCompra;
        public int idPedidoCompra
        {
            get { return this.m_IdPedidoCompra; }
            set { this.m_IdPedidoCompra = value; }
        }
    }
}