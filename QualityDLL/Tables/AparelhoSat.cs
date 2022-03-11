
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("AparelhoSat")]
    public class AparelhoSat : TTableBase
    {
        [TColumn("idAparelhoSat", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdAparelhoSat = new TFieldInteger();
        public TFieldInteger idAparelhoSat
        {
            get { return this.m_IdAparelhoSat; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("ip", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Ip = new TFieldString();
        public TFieldString ip
        {
            get { return this.m_Ip; }
        }

        [TColumn("porta", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Porta = new TFieldInteger();
        public TFieldInteger porta
        {
            get { return this.m_Porta; }
        }

        [TColumn("tipoAmbiente", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_tipoAmbiente = new TFieldInteger();
        public TFieldInteger tipoAmbiente
        {
            get { return this.m_tipoAmbiente; }
        }

        [TColumn("codigoAtivacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_CodigoAtivacao = new TFieldString();
        public TFieldString codigoAtivacao
        {
            get { return this.m_CodigoAtivacao; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_IdEmpresa; }
        }

        [TColumn("modeloDll", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_modeloDll = new TFieldInteger();
        public TFieldInteger modeloDll
        {
            get { return this.m_modeloDll; }
        }

        [TColumn("signAc", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_signAc = new TFieldString();
        public TFieldString signAc
        {
            get { return this.m_signAc; }
        }

    }
}
