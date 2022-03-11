using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoMovimento")]
	public class TipoMovimento: TTableBase
	{
		[TColumn("idTipoMovimento", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoMovimento = new TFieldInteger();
		public TFieldInteger idTipoMovimento
		{
			get{return this.m_idTipoMovimento;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("tipo", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_tipo = new TFieldString();
		public TFieldString tipo
		{
			get{return this.m_tipo;}
		}
	}
}
