
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Nacionalidade")]
    public class Nacionalidade : TTableBase
    {
        [TColumn("idNacionalidade", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdNacionalidade = new TFieldInteger();
        public TFieldInteger idNacionalidade
        {
            get { return this.m_IdNacionalidade; }
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
