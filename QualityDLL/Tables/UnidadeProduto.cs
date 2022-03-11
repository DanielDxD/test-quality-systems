using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("UnidadeProdutoServico")]
	public class UnidadeProdutoServico: TTableBase
	{
		[TColumn("idUnidadeProdutoServico", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idUnidadeProdutoServico = new TFieldInteger();
		public TFieldInteger idUnidadeProdutoServico
		{
			get{return this.m_idUnidadeProdutoServico;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("sigla", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_sigla = new TFieldString();
		public TFieldString sigla
		{
			get{return this.m_sigla;}
		}
	}
}
