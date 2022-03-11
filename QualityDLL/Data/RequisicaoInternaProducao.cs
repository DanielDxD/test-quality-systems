using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class RequisicaoInternaProducao : Base
    {

        public RequisicaoInternaProducao() : base()
        {
        }
        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoInternaProducao;
        public int idRequisicaoInternaProducao
        {
            get { return this.m_IdRequisicaoInternaProducao; }
            set { this.m_IdRequisicaoInternaProducao = value; }
        }

        [
            TFieldAttributeGridDisplay("Req. Entrada", 100),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idRequisicaoInterna:descricao")
        ]
        private RequisicaoInterna m_IdRequisicaoInternaEntrada;
        public RequisicaoInterna requisicaoInternaEntrada
        {
            get { return this.m_IdRequisicaoInternaEntrada; }
            set { this.m_IdRequisicaoInternaEntrada = value; }
        }

        [
            TFieldAttributeGridDisplay("Req. Saída", 100),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idRequisicaoInterna:descricao")
        ]
        private RequisicaoInterna m_IdRequisicaoInternaSaida;
        public RequisicaoInterna requisicaoInternaSaida
        {
            get { return this.m_IdRequisicaoInternaSaida; }
            set { this.m_IdRequisicaoInternaSaida = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

    }
}
