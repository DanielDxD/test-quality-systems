using System;

namespace Data
{
	//[Serializable]
	public class NotaFiscalS: Base
	{
		public NotaFiscalS(): base()
		{
		}

		private int m_IdNotaFiscalS;
		public int idNotaFiscalS
		{
			get{return this.m_IdNotaFiscalS;}
			set{this.m_IdNotaFiscalS = value;}
		}

		private DateTime m_DataFaturamento;
		public DateTime dataFaturamento
		{
			get{return this.m_DataFaturamento;}
			set{this.m_DataFaturamento = value;}
		}

		private double m_Valor;
		public double valor
		{
			get{return this.m_Valor;}
			set{this.m_Valor = value;}
		}

		private double m_Iss;
		public double iss
		{
			get{return this.m_Iss;}
			set{this.m_Iss = value;}
		}

		private DateTime m_DataVencimento;
		public DateTime dataVencimento
		{
			get{return this.m_DataVencimento;}
			set{this.m_DataVencimento = value;}
		}

		private int m_NumeroLote;
		public int numeroLote
		{
			get{return this.m_NumeroLote;}
			set{this.m_NumeroLote = value;}
		}

		private int m_NumeroRPS;
		public int numeroRPS
		{
			get{return this.m_NumeroRPS;}
			set{this.m_NumeroRPS = value;}
		}

		private int m_NumeroNFSE;
		public int numeroNFSE
		{
			get{return this.m_NumeroNFSE;}
			set{this.m_NumeroNFSE = value;}
		}

		private String m_CodigoValidacaoNFSE;
		public String codigoValidacaoNFSE
		{
			get{return this.m_CodigoValidacaoNFSE;}
			set{this.m_CodigoValidacaoNFSE = value;}
		}

		private EmpresaRelacionamento m_IdEmpresaRelacionamento;
		public EmpresaRelacionamento empresaRelacionamento
		{
			get{return this.m_IdEmpresaRelacionamento;}
			set{this.m_IdEmpresaRelacionamento = value;}
		}

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        //idNotaFiscal
        private NotaFiscalSItem[] m_NotaFiscalSItems;
        public NotaFiscalSItem[] notaFiscalSItems
        {
            get{return this.m_NotaFiscalSItems;}
            set{this.m_NotaFiscalSItems = value;}
        }

        public override string ToString()
        {
            return this.m_IdNotaFiscalS.ToString();
        }
    }
}
