using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoProdutoServico")]
	public class TipoProdutoServico: TTableBase
	{
		[TColumn("idTipoProdutoServico", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoProdutoServico = new TFieldInteger();
		public TFieldInteger idTipoProdutoServico
		{
			get{return this.m_idTipoProdutoServico;}
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
