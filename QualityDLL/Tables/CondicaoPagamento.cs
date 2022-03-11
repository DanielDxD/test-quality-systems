using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("CondicaoPagamento")]
	public class CondicaoPagamento: TTableBase
	{
		[TColumn("idCondicaoPagamento", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idCondicaoPagamento = new TFieldInteger();
		public TFieldInteger idCondicaoPagamento
		{
			get{return this.m_idCondicaoPagamento;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("condicoes", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_condicoes = new TFieldString();
		public TFieldString condicoes
		{
			get{return this.m_condicoes;}
		}

        [TColumn("diasCorridos", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_diasCorridos = new TFieldBoolean();
        public TFieldBoolean diasCorridos
        {
            get { return this.m_diasCorridos; }
        }

        [TColumn("definidoPeloUsuario", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_definidoPeloUsuario = new TFieldBoolean();
        public TFieldBoolean definidoPeloUsuario
        {
            get { return this.m_definidoPeloUsuario; }
        }
    }
}
