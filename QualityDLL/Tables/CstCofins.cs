
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("CstCofins")]
    public class CstCofins : TTableBase
    {
        [TColumn("idcstCofins", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdcstCofins = new TFieldInteger();
        public TFieldInteger idcstCofins
        {
            get { return this.m_IdcstCofins; }
        }

        [TColumn("cst", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Cst = new TFieldInteger();
        public TFieldInteger cst
        {
            get { return this.m_Cst; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

    }
}
