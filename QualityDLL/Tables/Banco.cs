using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Banco")]
	public class Banco: TTableBase
	{
		[TColumn("idBanco", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idBanco = new TFieldInteger();
		public TFieldInteger idBanco
		{
			get{return this.m_idBanco;}
		}

		[TColumn("codigoBanco", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_codigoBanco = new TFieldInteger();
		public TFieldInteger codigoBanco
		{
			get{return this.m_codigoBanco;}
		}

		[TColumn("codigoAgencia", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_codigoAgencia = new TFieldInteger();
		public TFieldInteger codigoAgencia
		{
			get{return this.m_codigoAgencia;}
		}

		[TColumn("digitoAgencia", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_digitoAgencia = new TFieldString();
		public TFieldString digitoAgencia
		{
			get{return this.m_digitoAgencia;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }
    }
}
