using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoLogradouro")]
	public class TipoLogradouro: TTableBase
	{
		[TColumn("idTipoLogradouro", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoLogradouro = new TFieldInteger();
		public TFieldInteger idTipoLogradouro
		{
			get{return this.m_idTipoLogradouro;}
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
			get{return this.m_tipo;}
		}
	}
}
