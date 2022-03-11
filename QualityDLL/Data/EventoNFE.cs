using System;

namespace Data
{
    //[Serializable]
    public class EventoNFe : Base
    {
        public EventoNFe() : base()
        {
        }

        private int m_IdEventoNFe;
        public int idEventoNFe
        {
            get { return this.m_IdEventoNFe; }
            set { this.m_IdEventoNFe = value; }
        }

        private MovimentoFiscal m_MovimentoFiscal;
        public MovimentoFiscal movimentoFiscal
        {
            get { return this.m_MovimentoFiscal; }
            set { this.m_MovimentoFiscal = value; }
        }

        private string m_NSeqEvento;
        public string nSeqEvento
        {
            get { return m_NSeqEvento; }
            set { this.m_NSeqEvento = value; }
        }

        private DateTime m_dhEvento;
        public DateTime dhEvento
        {
            get { return m_dhEvento; }
            set { this.m_dhEvento = value; }
        }

        private string m_descEvento;
        public string descEvento
        {
            get { return m_descEvento; }
            set { this.m_descEvento = value; }
        }

        private string m_nProt;
        public string nProt
        {
            get { return m_nProt; }
            set { this.m_nProt = value; }
        }

        private String m_xCorrecao;
        public String xCorrecao
        {
            get { return m_xCorrecao; }
            set { this.m_xCorrecao = value; }
        }

        private String m_xMotivo;
        public String xMotivo
        {
            get { return m_xMotivo; }
            set { this.m_xMotivo = value; }
        }

        private byte[] m_xml;
        public byte[] xml
        {
            get { return m_xml; }
            set { this.m_xml = value; }
        }

        private int m_cstat;
        public int cstat
        {
            get { return m_cstat; }
            set { this.m_cstat = value; }
        }

        private int m_inutilizacao_nnfini;
        public int inutilizacao_nnfini
        {
            get { return m_inutilizacao_nnfini; }
            set { this.m_inutilizacao_nnfini = value; }
        }

        private int m_inutilizacao_nnffin;
        public int inutilizacao_nnffin
        {
            get { return m_inutilizacao_nnffin; }
            set { this.m_inutilizacao_nnffin = value; }
        }

        private int m_inutilizacao_serie;
        public int inutilizacao_serie
        {
            get { return m_inutilizacao_serie; }
            set { this.m_inutilizacao_serie = value; }
        }

        private int m_tipoEvento;
        public int tipoEvento
        {
            get { return m_tipoEvento; }
            set { this.m_tipoEvento = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private int m_Ambiente;
        public int ambiente
        {
            get { return this.m_Ambiente; }
            set { this.m_Ambiente = value; }
        }

        private int m_tipoDocumento;
        public int tipoDocumento
        {
            get { return this.m_tipoDocumento; }
            set { this.m_tipoDocumento = value; }
        }

        public override string ToString()
        {
            return this.m_IdEventoNFe.ToString();
        }
    }
}
