using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("DocumentoTransferenciaItem")]
    public class DocumentoTransferenciaItem : TTableBase
    {
        [TColumn("idDocumentoTransferenciaItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idDocumentoTransferenciaItem = new TFieldInteger();
        public TFieldInteger idDocumentoTransferenciaItem
        {
            get { return this.m_idDocumentoTransferenciaItem; }
        }

        [TColumn("idDocumentoTransferencia", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idDocumentoTransferencia = new TFieldInteger();
        public TFieldInteger idDocumentoTransferencia
        {
            get { return this.m_idDocumentoTransferencia; }
        }

        [TColumn("idDocumentoRecebimentoTransferido", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idDocumentoRecebimentoTransferido = new TFieldInteger();
        public TFieldInteger idDocumentoRecebimentoTransferido
        {
            get { return this.m_idDocumentoRecebimentoTransferido; }
        }

        [TColumn("idDocumentoTransferenciaTransferidoItem", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idDocumentoTransferenciaTransferidoItem = new TFieldInteger();
        public TFieldInteger idDocumentoTransferenciaTransferidoItem
        {
            get { return this.m_idDocumentoTransferenciaTransferidoItem; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }
    }
}
