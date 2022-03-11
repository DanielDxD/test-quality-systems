using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("TipoLancamentoContabil")]
    public class TipoLancamentoContabil : TTableBase
    {
        [TColumn("idTipoLancamentoContabil", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idTipoLancamentoContabil = new TFieldInteger();
        public TFieldInteger idTipoLancamentoContabil
        {
            get { return this.m_idTipoLancamentoContabil; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("debitoCredito", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_debitoCredito = new TFieldString();
        public TFieldString debitoCredito
        {
            get { return this.m_debitoCredito; }
        }
    }
}
