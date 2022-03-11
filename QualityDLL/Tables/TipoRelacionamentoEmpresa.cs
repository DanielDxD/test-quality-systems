using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("TipoRelacionamentoEmpresa")]
	public class TipoRelacionamentoEmpresa: TTableBase
	{
		[TColumn("idTipoRelacionamentoEmpresa", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idTipoRelacionamentoEmpresa = new TFieldInteger();
		public TFieldInteger idTipoRelacionamentoEmpresa
		{
			get{return this.m_idTipoRelacionamentoEmpresa;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("empresaSocio", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_empresaSocio = new TFieldString();
		public TFieldString empresaSocio
		{
			get{return this.m_empresaSocio;}
		}

		[TColumn("tipo", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_tipo = new TFieldString();
		public TFieldString tipo
		{
			get{return this.m_tipo;}
		}
	}
}
