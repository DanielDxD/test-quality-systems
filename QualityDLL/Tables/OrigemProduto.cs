
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("OrigemProduto")]
    public class OrigemProduto : TTableBase
    {
        [TColumn("idOrigemProduto", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdOrigemProduto = new TFieldInteger();
        public TFieldInteger idOrigemProduto
        {
            get { return this.m_IdOrigemProduto; }
        }

        [TColumn("codigo", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Codigo = new TFieldInteger();
        public TFieldInteger codigo
        {
            get { return this.m_Codigo; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

    }
}
