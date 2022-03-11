
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("CstIcms")]
    public class CstIcms : TTableBase
    {
        [TColumn("idcstIcms", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdcstIcms = new TFieldInteger();
        public TFieldInteger idcstIcms
        {
            get { return this.m_IdcstIcms; }
        }

        [TColumn("cstCsosn", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_CstCsosn = new TFieldInteger();
        public TFieldInteger cstCsosn
        {
            get { return this.m_CstCsosn; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

    }
}
