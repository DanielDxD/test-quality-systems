using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("FormaPagamento")]
    public class FormaPagamento : TTableBase
    {
        [TColumn("idFormaPagamento", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idFormaPagamento = new TFieldInteger();
        public TFieldInteger idFormaPagamento
        {
            get { return this.m_idFormaPagamento; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("tipo", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_tipo = new TFieldInteger();
        public TFieldInteger tipo
        {
            get { return this.m_tipo; }
        }

        [TColumn("codigoFiscal", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_codigoFiscal = new TFieldInteger();
        public TFieldInteger codigoFiscal
        {
            get { return this.m_codigoFiscal; }
        }


        [TColumn("idBandeiraCartao", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idBandeiraCartao = new TFieldInteger();
        public TFieldInteger idBandeiraCartao
        {
            get { return this.m_idBandeiraCartao; }
        }


        [TColumn("habilitarValorDigitadoFechamento", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_habilitarValorDigitadoFechamento = new TFieldBoolean();
        public TFieldBoolean habilitarValorDigitadoFechamento
        {
            get { return this.m_habilitarValorDigitadoFechamento; }
        }

    }
}
