
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("CfOp")]
    public class CfOp : TTableBase
    {
        [TColumn("idCfop", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdCfop = new TFieldInteger();
        public TFieldInteger idCfop
        {
            get { return this.m_IdCfop; }
        }

        [TColumn("codigo", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Codigo = new TFieldInteger();
        public TFieldInteger codigo
        {
            get { return this.m_Codigo; }
        }

        [TColumn("tipo", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Tipo = new TFieldInteger();
        public TFieldInteger tipo
        {
            get { return this.m_Tipo; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("ativo", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_Ativo = new TFieldBoolean();
        public TFieldBoolean ativo
        {
            get { return this.m_Ativo; }
        }

    }
}
