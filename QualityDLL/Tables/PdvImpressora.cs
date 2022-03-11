using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PdvImpressora")]
	public class PdvImpressora: TTableBase
    {
        [TColumn("idPdvImpressora", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvImpressora = new TFieldInteger();
        public TFieldInteger idPdvImpressora
        {
            get { return this.m_idPdvImpressora; }
        }

        [TColumn("ip", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_ip = new TFieldString();
        public TFieldString ip
        {
            get { return this.m_ip; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }
    }
}
