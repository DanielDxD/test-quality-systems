using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoEnderecoContato")]
	public class TipoEnderecoContato: TTableBase
	{
		[TColumn("idTipoEnderecoContato", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoEnderecoContato = new TFieldInteger();
		public TFieldInteger idTipoEnderecoContato
		{
			get{return this.m_idTipoEnderecoContato;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("enderecoContato", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_enderecoContato = new TFieldString();
		public TFieldString enderecoContato
		{
			get{return this.m_enderecoContato;}
		}
	}
}
