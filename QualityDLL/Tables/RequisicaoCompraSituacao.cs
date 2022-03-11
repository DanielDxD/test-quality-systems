using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("RequisicaoCompraSituacao")]
	public class RequisicaoCompraSituacao: TTableBase
	{
		[TColumn("idRequisicaoCompraSituacao", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idRequisicaoCompraSituacao = new TFieldInteger();
		public TFieldInteger idRequisicaoCompraSituacao
		{
			get{return this.m_idRequisicaoCompraSituacao;}
		}

		[TColumn("situacao", System.Data.SqlDbType.Char, false, false)]
		private TFieldString m_situacao = new TFieldString();
		public TFieldString situacao
		{
			get{return this.m_situacao;}
		}

		[TColumn("dataSituacao", System.Data.SqlDbType.DateTime, false, false)]
		private TFieldDatetime m_dataSituacao = new TFieldDatetime();
		public TFieldDatetime dataSituacao
		{
			get{return this.m_dataSituacao;}
		}

		[TColumn("idRequisicaoCompra", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idRequisicaoCompra = new TFieldInteger();
        public TFieldInteger idRequisicaoCompra
		{
			get{return this.m_idRequisicaoCompra;}
        }

		[TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idFuncionario = new TFieldInteger();
        public TFieldInteger idFuncionario
		{
			get{return this.m_idFuncionario;}
		}
	}
}
