
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Feriado")]
    public class Feriado : TTableBase
    {
        [TColumn("idFeriado", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdFeriado = new TFieldInteger();
        public TFieldInteger idFeriado
        {
            get { return this.m_IdFeriado; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("dia", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Dia = new TFieldInteger();
        public TFieldInteger dia
        {
            get { return this.m_Dia; }
        }

        [TColumn("mes", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Mes = new TFieldInteger();
        public TFieldInteger mes
        {
            get { return this.m_Mes; }
        }

        [TColumn("ano", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Ano = new TFieldInteger();
        public TFieldInteger ano
        {
            get { return this.m_Ano; }
        }

    }
}
