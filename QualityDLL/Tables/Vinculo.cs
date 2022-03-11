using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Vinculo")]
	public class Vinculo: TTableBase
	{
		[TColumn("idVinculo", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idVinculo = new TFieldInteger();
		public TFieldInteger idVinculo
		{
			get{return this.m_idVinculo;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}
	}
}
