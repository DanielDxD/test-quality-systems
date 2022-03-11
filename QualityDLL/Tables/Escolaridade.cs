using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Escolaridade")]
	public class Escolaridade: TTableBase
	{
		[TColumn("idEscolaridade", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idEscolaridade = new TFieldInteger();
		public TFieldInteger idEscolaridade
		{
			get{return this.m_idEscolaridade;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}
	}
}
