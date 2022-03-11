
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContratoTipoRecorrencia")]
    public class ContratoTipoRecorrencia : TTableBase
    {
        [TColumn("idContratoTipoRecorrencia", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdContratoTipoRecorrencia = new TFieldInteger();
        public TFieldInteger idContratoTipoRecorrencia
        {
            get { return this.m_IdContratoTipoRecorrencia; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("recorrencia", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Recorrencia = new TFieldInteger();
        public TFieldInteger recorrencia
        {
            get { return this.m_Recorrencia; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_Observacao; }
        }

    }
}
