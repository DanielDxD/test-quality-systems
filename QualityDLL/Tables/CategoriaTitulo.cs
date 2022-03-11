using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("CategoriaTitulo")]
    public class CategoriaTitulo : TTableBase
    {
        [TColumn("idCategoriaTitulo", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idCategoriaTitulo = new TFieldInteger();
        public TFieldInteger idCategoriaTitulo
        {
            get { return this.m_idCategoriaTitulo; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("descricaoReduzida", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricaoReduzida = new TFieldString();
        public TFieldString descricaoReduzida
        {
            get { return this.m_descricaoReduzida; }
        }

        [TColumn("familiar", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_familiar = new TFieldBoolean();
        public TFieldBoolean familiar
        {
            get { return this.m_familiar; }
        }

        [TColumn("mesesVigencia", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_mesesVigencia = new TFieldInteger();
        public TFieldInteger mesesVigencia
        {
            get { return this.m_mesesVigencia; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("numero", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_numero = new TFieldInteger();
        public TFieldInteger numero
        {
            get { return this.m_numero; }
        }
    }
}
