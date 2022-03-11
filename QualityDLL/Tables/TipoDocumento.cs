using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("TipoDocumento")]
    public class TipoDocumento : TTableBase
    {
        [TColumn("idTipoDocumento", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idTipoDocumento = new TFieldInteger();
        public TFieldInteger idTipoDocumento
        {
            get { return this.m_idTipoDocumento; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("cheque", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_cheque = new TFieldString();
        public TFieldString cheque
        {
            get { return this.m_cheque; }
        }

        [TColumn("dinheiro", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_dinheiro = new TFieldString();
        public TFieldString dinheiro
        {
            get { return this.m_dinheiro; }
        }
    }
}
