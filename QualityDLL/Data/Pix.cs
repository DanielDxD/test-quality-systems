using System;

namespace Data
{
    //[Serializable]
    public class Pix : Base
    {

        public Pix() : base()
        {
        }

        private int m_IdPix;
        public int idPix
        {
            get { return this.m_IdPix; }
            set { this.m_IdPix = value; }
        }

        private string m_Status;
        public string status
        {
            get { return this.m_Status; }
            set { this.m_Status = value; }
        }

        private int m_Expiracao;
        public int expiracao
        {
            get { return this.m_Expiracao; }
            set { this.m_Expiracao = value; }
        }

        private DateTime m_Criacao;
        public DateTime criacao
        {
            get { return this.m_Criacao; }
            set { this.m_Criacao = value; }
        }

        private DateTime m_DataConciliacaoQuality;
        public DateTime dataConciliacaoQuality
        {
            get { return this.m_DataConciliacaoQuality; }
            set { this.m_DataConciliacaoQuality = value; }
        }

        private decimal m_Valor;
        public decimal valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private string m_Chave;
        public string chave
        {
            get { return this.m_Chave; }
            set { this.m_Chave = value; }
        }

        private string m_SolicitacaoPagador;
        public string solicitacaoPagador
        {
            get { return this.m_SolicitacaoPagador; }
            set { this.m_SolicitacaoPagador = value; }
        }

        private string m_Location;
        public string location
        {
            get { return this.m_Location; }
            set { this.m_Location = value; }
        }

        private string m_TextoImagemQRcode;
        public string textoImagemQRcode
        {
            get { return this.m_TextoImagemQRcode; }
            set { this.m_TextoImagemQRcode = value; }
        }

        private string m_Txid;
        public string txid
        {
            get { return this.m_Txid; }
            set { this.m_Txid = value; }
        }

        private int m_Revisao;
        public int revisao
        {
            get { return this.m_Revisao; }
            set { this.m_Revisao = value; }
        }

        private string m_DevedorNome;
        public string devedorNome
        {
            get { return this.m_DevedorNome; }
            set { this.m_DevedorNome = value; }
        }

        private string m_DevedorCpfCnpj;
        public string devedorCpfCnpj
        {
            get { return this.m_DevedorCpfCnpj; }
            set { this.m_DevedorCpfCnpj = value; }
        }

        private PixTransacao[] m_PixTransacoes;
        public PixTransacao[] pixTransacoes
        {
            get { return this.m_PixTransacoes; }
            set { this.m_PixTransacoes = value; }
        }

        public string ParseTxId(string modulo, string _txId = null)
        {
            if (String.IsNullOrEmpty(_txId))
                return String.Format("{1}{0}", m_Txid.ToString().PadLeft((32 - modulo.Length), '0'), modulo);
            else
                return String.Format("{1}{0}", _txId.ToString().PadLeft((32 - modulo.Length), '0'), modulo);
        }

    }
}
