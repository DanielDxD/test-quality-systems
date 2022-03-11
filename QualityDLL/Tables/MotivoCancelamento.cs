
using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("MotivoCancelamento")]
	public class MotivoCancelamento : TTableBase
	{
		public MotivoCancelamento() : base() {}

		[
			TColumn("idMotivoCancelamento", System.Data.SqlDbType.Int, true, true)
		]
		private TFieldInteger m_idMotivoCancelamento = new TFieldInteger();
		public TFieldInteger idMotivoCancelamento 
		{ 
			get { return this.m_idMotivoCancelamento; }
		}

		[
			TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)
		]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao 
		{ 
			get { return this.m_descricao; }
		}

	}
}
