using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("OperacaoFiscal")]
    public class OperacaoFiscal : TTableBase
    {
        [TColumn("idOperacaoFiscal", System.Data.SqlDbType.Int, true, false)]
        private TFieldInteger m_idOperacaoFiscal = new TFieldInteger();
        public TFieldInteger idOperacaoFiscal
        {
            get { return this.m_idOperacaoFiscal; }
        }

        [TColumn("comentario", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_comentario = new TFieldString();
        public TFieldString comentario
        {
            get { return this.m_comentario; }
        }

        [TColumn("produtoServico", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_produtoServico = new TFieldString();
        public TFieldString produtoServico
        {
            get { return this.m_produtoServico; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }
    }
}