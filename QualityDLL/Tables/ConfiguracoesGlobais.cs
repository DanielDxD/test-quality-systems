using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ConfiguracoesGlobais")]
    public class ConfiguracoesGlobais : TTableBase
    {
        [TColumn("nmConfiguracao", System.Data.SqlDbType.VarChar, true, false)]
        private TFieldString m_nmConfiguracao = new TFieldString();
        public TFieldString nmConfiguracao
        {
            get { return this.m_nmConfiguracao; }
        }

        [TColumn("valorConfiguracao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_valorConfiguracao = new TFieldString();
        public TFieldString valorConfiguracao
        {
            get { return this.m_valorConfiguracao; }
        }
    }
}
