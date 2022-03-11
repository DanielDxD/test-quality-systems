using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("FinalidadeEndereco")]
	public class FinalidadeEndereco: TTableBase
	{
		[TColumn("idFinalidadeEndereco", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idFinalidadeEndereco = new TFieldInteger();
		public TFieldInteger idFinalidadeEndereco
		{
			get{return this.m_idFinalidadeEndereco;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

        [TColumn("tipo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipo = new TFieldString();
        public TFieldString tipo
        {
            get { return this.m_tipo; }
        }
    }
}
