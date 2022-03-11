using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Cartao : Base
    {
        public Cartao() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
        ]
        private int m_IdCartao;
        public int idCartao
        {
            get { return this.m_IdCartao; }
            set { this.m_IdCartao = value; }
        }

        [
            TFieldAttributeGridDisplay("Número", 115),
        ]
        private string m_NumeroCartao;
        public string numeroCartao
        {
            get { return this.m_NumeroCartao; }
            set { this.m_NumeroCartao = value?.Trim(); }
        }

        [
            TFieldAttributeGridDisplay("Data de Emissão", 115),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataEmissao;
        public DateTime dataEmissao
        {
            get { return this.m_DataEmissao; }
            set { this.m_DataEmissao = value; }
        }

        [
            TFieldAttributeGridDisplay("Data de Validade", 120),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataValidade;
        public DateTime dataValidade
        {
            get { return this.m_DataValidade; }
            set { this.m_DataValidade = value; }
        }

        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Cancelado", 110)
        ]
        private bool m_Cancelado;
        public bool cancelado
        {
            get { return this.m_Cancelado; }
            set { this.m_Cancelado = value; }
        }

        private String m_CodigoBarras;
        public String codigoBarras
        {
            get { return this.m_CodigoBarras; }
            set { this.m_CodigoBarras = value; }
        }

        private String m_NumeroRFID;
        public String numeroRFID
        {
            get { return this.m_NumeroRFID; }
            set { this.m_NumeroRFID = value; }
        }

        private String m_Ativo;
        public String ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

        private EmpresaRelacionamento m_IdEmpresaRelacionamento;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        private string m_IdQuality;
        public string idQuality
        {
            get { return this.m_IdQuality; }
            set { this.m_IdQuality = value; }
        }

        public override string ToString()
        {
            return this.m_NumeroRFID.ToString();
        }
    }
}
