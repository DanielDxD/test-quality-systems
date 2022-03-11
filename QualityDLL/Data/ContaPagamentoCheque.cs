using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [TClassAttributeBusinessIdField("m_IdContaPagamento.m_IdEmpresa")]
    public class ContaPagamentoCheque : Base
    {
        public ContaPagamentoCheque()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)

        ]
        private int m_IdContaPagamentoCheque;
        public int idContaPagamentoCheque
        {
            get { return this.m_IdContaPagamentoCheque; }
            set { this.m_IdContaPagamentoCheque = value; }
        }

        [
            TFieldAttributeGridDisplay("Número", 90)
        ]
        private int m_Numero;
        public int numero
        {
            get { return this.m_Numero; }
            set { this.m_Numero = value; }
        }

        [
            TFieldAttributeGridDisplay("Emissão", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataEmissao;
        public DateTime dataEmissao
        {
            get { return this.m_DataEmissao; }
            set { this.m_DataEmissao = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 90),
            TFieldAttributeFormat("C2", "")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private String m_ValorExtenso;
        public String valorExtenso
        {
            get { return this.m_ValorExtenso; }
            set { this.m_ValorExtenso = value; }
        }

        [
            TFieldAttributeGridDisplay("Cancelamento", 120),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Doc Pagamento", 300),
            TFieldAttributeSubfield("idDocumentoPagamento:descricao")
        ]
        private DocumentoPagamento m_IdDocumentoPagamento;
        public DocumentoPagamento documentoPagamento
        {
            get { return this.m_IdDocumentoPagamento; }
            set { this.m_IdDocumentoPagamento = value; }
        }
                
        private DocumentoTransferencia m_IdDocumentoTransferencia;
        public DocumentoTransferencia documentoTransferencia
        {
            get { return this.m_IdDocumentoTransferencia; }
            set { this.m_IdDocumentoTransferencia = value; }
        }


    }
}
