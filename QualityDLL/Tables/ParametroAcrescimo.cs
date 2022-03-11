
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ParametroAcrescimo")]
    public class ParametroAcrescimo : TTableBase
    {
        [TColumn("idParametroAcrescimo", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdParametroAcrescimo = new TFieldInteger();
        public TFieldInteger idParametroAcrescimo
        {
            get { return this.m_IdParametroAcrescimo; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("tipoJuro", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_TipoJuro = new TFieldString();
        public TFieldString tipoJuro
        {
            get { return this.m_TipoJuro; }
        }

        [TColumn("tipoMulta", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_TipoMulta = new TFieldString();
        public TFieldString tipoMulta
        {
            get { return this.m_TipoMulta; }
        }

        [TColumn("valorJuros", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorJuros = new TFieldDouble();
        public TFieldDouble valorJuros
        {
            get { return this.m_ValorJuros; }
        }

        [TColumn("valorMulta", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorMulta = new TFieldDouble();
        public TFieldDouble valorMulta
        {
            get { return this.m_ValorMulta; }
        }

        [TColumn("tipoCarenciaJuros", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_TipoCarenciaJuros = new TFieldString();
        public TFieldString tipoCarenciaJuros
        {
            get { return this.m_TipoCarenciaJuros; }
        }

        [TColumn("diasCarenciaJuros", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_DiasCarenciaJuros = new TFieldInteger();
        public TFieldInteger diasCarenciaJuros
        {
            get { return this.m_DiasCarenciaJuros; }
        }

        [TColumn("tipoCarenciaMulta", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_TipoCarenciaMulta = new TFieldString();
        public TFieldString tipoCarenciaMulta
        {
            get { return this.m_TipoCarenciaMulta; }
        }

        [TColumn("diasCarenciaMulta", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_DiasCarenciaMulta = new TFieldInteger();
        public TFieldInteger diasCarenciaMulta
        {
            get { return this.m_DiasCarenciaMulta; }
        }

        [TColumn("jurosMesesAnteriores", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_jurosMesesAnteriores = new TFieldBoolean();
        public TFieldBoolean jurosMesesAnteriores
        {
            get { return this.m_jurosMesesAnteriores; }
        }

    }
}
