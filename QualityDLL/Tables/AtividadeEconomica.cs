using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("AtividadeEconomica")]
	public class AtividadeEconomica: TTableBase
	{
		[TColumn("idAtividadeEconomica", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idAtividadeEconomica = new TFieldInteger();
		public TFieldInteger idAtividadeEconomica
		{
			get{return this.m_idAtividadeEconomica;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("codigoCNAE", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoCNAE = new TFieldString();
		public TFieldString codigoCNAE
		{
			get{return this.m_codigoCNAE;}
		}
	}
}
