using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Pagina")]
	public class Pagina: TTableBase
	{
		[TColumn("idPagina", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idPagina = new TFieldInteger();
		public TFieldInteger idPagina
		{
			get{return this.m_idPagina;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("pagina", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_pagina = new TFieldString();
		public TFieldString pagina
		{
			get{return this.m_pagina;}
		}

		[TColumn("altura", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_altura = new TFieldInteger();
		public TFieldInteger altura
		{
			get{return this.m_altura;}
		}

		[TColumn("largura", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_largura = new TFieldInteger();
		public TFieldInteger largura
		{
			get{return this.m_largura;}
		}

		[TColumn("newLayout", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_newLayout = new TFieldBoolean();
		public TFieldBoolean newLayout
		{
			get { return this.m_newLayout; }
		}

		[TColumn("gestaoNovo", System.Data.SqlDbType.Bit, false, false)]
		private TFieldBoolean m_gestaoNovo = new TFieldBoolean();
		public TFieldBoolean gestaoNovo
		{
			get { return this.m_gestaoNovo; }
		}
	}
}
