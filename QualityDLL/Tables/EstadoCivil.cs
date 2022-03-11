using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("EstadoCivil")]
	public class EstadoCivil: TTableBase
	{
		[TColumn("idEstadoCivil", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idEstadoCivil = new TFieldInteger();
		public TFieldInteger idEstadoCivil
		{
			get{return this.m_idEstadoCivil;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("temConjuge", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_temConjuge = new TFieldBoolean();
		public TFieldBoolean temConjuge
		{
			get{return this.m_temConjuge;}
		}
	}
}
