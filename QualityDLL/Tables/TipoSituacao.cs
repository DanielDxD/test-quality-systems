
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("TipoSituacao")]
    public class TipoSituacao : TTableBase
    {
        [TColumn("idTipoSituacao", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdTipoSituacao = new TFieldInteger();
        public TFieldInteger idTipoSituacao
        {
            get { return this.m_IdTipoSituacao; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("bloqueioPortaria", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_BloqueioPortaria = new TFieldBoolean();
        public TFieldBoolean bloqueioPortaria
        {
            get { return this.m_BloqueioPortaria; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_Observacao; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_IdEmpresa; }
        }


    }
}
