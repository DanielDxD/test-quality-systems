using System;

namespace Data
{
    //[Serializable]
    public class ContasAReceberPagamentoTef : Base
    {

        public ContasAReceberPagamentoTef() : base()
        {
        }

        private int m_IdContasAReceberPagamentoTef;
        public int idContasAReceberPagamentoTef
        {
            get { return this.m_IdContasAReceberPagamentoTef; }
            set { this.m_IdContasAReceberPagamentoTef = value; }
        }

        private ContasAReceberPagamento m_IdContasAReceberPagamento;
        public ContasAReceberPagamento contasAReceberPagamento
        {
            get { return this.m_IdContasAReceberPagamento; }
            set { this.m_IdContasAReceberPagamento = value; }
        }

        private DateTime m_DataTransacao;
        public DateTime dataTransacao
        {
            get { return this.m_DataTransacao; }
            set { this.m_DataTransacao = value; }
        }

        private string m_CodigoAutorizacao;
        public string codigoAutorizacao
        {
            get { return this.m_CodigoAutorizacao; }
            set { this.m_CodigoAutorizacao = value; }
        }

        private int m_ServiceType;
        public int serviceType
        {
            get { return this.m_ServiceType; }
            set { this.m_ServiceType = value; }
        }

        private string m_Bandeira;
        public string bandeira
        {
            get { return this.m_Bandeira; }
            set { this.m_Bandeira = value; }
        }

        private string m_CartaoNumero;
        public string cartaoNumero
        {
            get { return this.m_CartaoNumero; }
            set { this.m_CartaoNumero = value; }
        }

        private string m_TransacaoId;
        public string transacaoId
        {
            get { return this.m_TransacaoId; }
            set { this.m_TransacaoId = value; }
        }

        private int m_TipoPagamento;
        public int tipoPagamento
        {
            get { return this.m_TipoPagamento; }
            set { this.m_TipoPagamento = value; }
        }

        private int m_Parcelas;
        public int parcelas
        {
            get { return this.m_Parcelas; }
            set { this.m_Parcelas = value; }
        }

        private int m_TipoParcelamento;
        public int tipoParcelamento
        {
            get { return this.m_TipoParcelamento; }
            set { this.m_TipoParcelamento = value; }
        }

        private string m_Funcionario;
        public string funcionario
        {
            get { return this.m_Funcionario; }
            set { this.m_Funcionario = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private bool m_IsApproved;
        public bool isApproved
        {
            get { return this.m_IsApproved; }
            set { this.m_IsApproved = value; }
        }

    }
}
