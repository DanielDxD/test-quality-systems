using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("PlanoContas")]
	public class PlanoContas: TTableBase
	{
		[TColumn("idPlanoContas", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idPlanoContas = new TFieldInteger();
		public TFieldInteger idPlanoContas
		{
			get{return this.m_idPlanoContas;}
		}

		[TColumn("analiticoSintetico", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_analiticoSintetico = new TFieldString();
		public TFieldString analiticoSintetico
		{
			get{return this.m_analiticoSintetico;}
		}

		[TColumn("codigoContabil", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_codigoContabil = new TFieldString();
		public TFieldString codigoContabil
		{
			get{return this.m_codigoContabil;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

        [TColumn("codigoContabilReduzido", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoContabilReduzido = new TFieldString();
        public TFieldString codigoContabilReduzido
        {
            get { return this.m_codigoContabilReduzido; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }
    }
}
