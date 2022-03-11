using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvEstacoesConfig")]
    public class PdvEstacoesConfig : TTableBase
    {
        [TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, true, false)]
        private TFieldInteger m_idPdvEstacao = new TFieldInteger();
        public TFieldInteger idPdvEstacao
        {
            get { return this.m_idPdvEstacao; }
        }

        [TColumn("nomeConfig", System.Data.SqlDbType.VarChar, true, false)]
        private TFieldString m_nomeConfig = new TFieldString();
        public TFieldString nomeConfig
        {
            get { return this.m_nomeConfig; }
        }

        [TColumn("valor", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_valor = new TFieldString();
        public TFieldString valor
        {
            get { return this.m_valor; }
        }
    }
}
