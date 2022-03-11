using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoAcessoContato")]
	public class TipoAcessoContato: TTableBase
	{
		[TColumn("idTipoAcessoContato", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoAcessoContato = new TFieldInteger();
		public TFieldInteger idTipoAcessoContato
		{
			get{return this.m_idTipoAcessoContato;}
		}

		[TColumn("tipo", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_tipo = new TFieldString();
		public TFieldString tipo
		{
			get{return this.m_tipo;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}
	}
}
