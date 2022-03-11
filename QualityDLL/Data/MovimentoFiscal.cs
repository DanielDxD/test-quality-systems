using System;
using System.Collections.Generic;

namespace Data
{
    //[Serializable]
    public class MovimentoFiscal : Base
    {
        public MovimentoFiscal() : base()
        {
        }

        private int m_IdMovimentoFiscal;
        public int idMovimentoFiscal
        {
            get { return this.m_IdMovimentoFiscal; }
            set { this.m_IdMovimentoFiscal = value; }
        }

        private PdvCompra m_PdvCompra;
        public PdvCompra pdvCompra
        {
            get { return this.m_PdvCompra; }
            set { this.m_PdvCompra = value; }
        }

        private int m_Serie;
        public int serie
        {
            get { return m_Serie; }
            set { this.m_Serie = value; }
        }

        private byte[] m_xmlEnvio;
        public byte[] xmlEnvio
        {
            get { return m_xmlEnvio; }
            set { this.m_xmlEnvio = value; }
        }

        private byte[] m_xmlRetorno;
        public byte[] xmlRetorno
        {
            get { return m_xmlRetorno; }
            set { this.m_xmlRetorno = value; }
        }

        private string m_Emitida;
        public string emitida
        {
            get { return m_Emitida; }
            set { this.m_Emitida = value; }
        }

        private string m_Cancelada;
        public string cancelada
        {
            get { return m_Cancelada; }
            set { this.m_Cancelada = value; }
        }

        private DateTime m_dataEmissao;
        public DateTime dataEmissao
        {
            get { return m_dataEmissao; }
            set { this.m_dataEmissao = value; }
        }

        private String m_Chave;
        public String chave
        {
            get { return m_Chave; }
            set { this.m_Chave = value; }
        }

        private int m_cstat;
        public int cstat
        {
            get { return m_cstat; }
            set { this.m_cstat = value; }
        }

        private String m_xMotivo;
        public String xMotivo
        {
            get { return m_xMotivo; }
            set { this.m_xMotivo = value; }
        }

        private DateTime m_dhRecbto;
        public DateTime dhRecbto
        {
            get { return m_dhRecbto; }
            set { this.m_dhRecbto = value; }
        }

        private int m_ambiente;
        public int ambiente
        {
            get { return m_ambiente; }
            set { this.m_ambiente = value; }
        }

        private string m_contingencia;
        public string contingencia
        {
            get { return m_contingencia; }
            set { this.m_contingencia = value; }
        }

        private string m_formaPagamento;
        public string formaPagamento
        {
            get { return m_formaPagamento; }
            set { this.m_formaPagamento = value; }
        }

        private long m_numero;
        public long numero
        {
            get { return m_numero; }
            set { this.m_numero = value; }
        }

        private int m_tipoDocumento;
        public int tipoDocumento
        {
            get { return m_tipoDocumento; }
            set { this.m_tipoDocumento = value; }
        }

        private ENum.eMovimentoFiscalStatus[] m_StatusFiltro;
        public ENum.eMovimentoFiscalStatus[] statusFiltro
        {
            get { return m_StatusFiltro; }
            set { this.m_StatusFiltro = value; }
        }

        private ENum.eMovimentoFiscalStatus m_Status;
        public ENum.eMovimentoFiscalStatus status
        {
            get { return m_Status; }
            set { this.m_Status = value; }
        }

        public override string ToString()
        {
            return this.m_IdMovimentoFiscal.ToString();
        }

        public List<Data.EventoNFe> GetEventos()
        {
            if (this.m_IdMovimentoFiscal > 0)
            {
                EventoNFe ev = new EventoNFe
                {
                    movimentoFiscal = new MovimentoFiscal
                    {
                        idMovimentoFiscal = this.m_IdMovimentoFiscal
                    }
                };

                List<Data.EventoNFe> results = new List<EventoNFe>();
                foreach (Data.EventoNFe item in Utils.Utils.listaDados(0, ev, 0, null))
                    results.Add(item);

                return results;
            }
            return null;
        }
    }
}
