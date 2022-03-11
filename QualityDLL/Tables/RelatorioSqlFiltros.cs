using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("RelatorioSqlFiltros")]
    public class RelatorioSqlFiltros : TTableBase
    {
        [TColumn("idRelatorioSqlFiltro", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idRelatorioSqlFiltro = new TFieldInteger();
        public TFieldInteger idRelatorioSqlFiltro
        {
            get { return this.m_idRelatorioSqlFiltro; }
        }

        [TColumn("idRelatorioSql", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idRelatorioSql = new TFieldInteger();
        public TFieldInteger idRelatorioSql
        {
            get { return this.m_idRelatorioSql; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }
        
        [TColumn("orderCampos", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_orderCampos = new TFieldString();
        public TFieldString orderCampos
        {
            get { return this.m_orderCampos; }
        }

        [TColumn("filterCampos", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_filterCampos = new TFieldString();
        public TFieldString filterCampos
        {
            get { return this.m_filterCampos; }
        }



        [TColumn("keyValue", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_keyValue = new TFieldString();
        public TFieldString keyValue
        {
            get { return this.m_keyValue; }
        }

        [TColumn("tipo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Tipo = new TFieldString();
        public TFieldString tipo
        {
            get { return this.m_Tipo; }
        }

        [TColumn("classBase", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_ClassBase = new TFieldString();
        public TFieldString classBase
        {
            get { return this.m_ClassBase; }
        }

        [TColumn("campos", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Campos = new TFieldString();
        public TFieldString campos
        {
            get { return this.m_Campos; }
        }

        [TColumn("required", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_Required = new TFieldBoolean();
        public TFieldBoolean required
        {
            get { return this.m_Required; }
        }
    }
}
