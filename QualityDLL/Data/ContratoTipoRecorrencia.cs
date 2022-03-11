using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ContratoTipoRecorrencia : Base
    {

        public ContratoTipoRecorrencia() : base()
        {
        }

        [
           TFieldAttributeGridDisplay("ID", 55),
           TFieldAttributeData(6, true),
           TFieldAttributeKey(true, true)
       ]
        private int m_IdContratoTipoRecorrencia;
        public int idContratoTipoRecorrencia
        {
            get { return this.m_IdContratoTipoRecorrencia; }
            set { this.m_IdContratoTipoRecorrencia = value; }
        }

        [
           TFieldAttributeGridDisplay("Descrição", 100),
           TFieldAttributeData(20, false)
       ]
        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Recorrência (Dias)", 100),
            TFieldAttributeData(20, false)
        ]
        private int m_Recorrencia;
        public int recorrencia
        {
            get { return this.m_Recorrencia; }
            set { this.m_Recorrencia = value; }
        }

        [
           TFieldAttributeGridDisplay("Observação", 100),
           TFieldAttributeData(20, false)
       ]
        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

    }
}
