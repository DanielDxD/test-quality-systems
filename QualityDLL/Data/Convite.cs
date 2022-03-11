using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Convite : Base
    {

        public Convite() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdConvite;
        public int idConvite
        {
            get { return this.m_IdConvite; }
            set { this.m_IdConvite = value; }
        }

        [
            TFieldAttributeGridDisplay("Tipo de Convite", 200),
            TFieldAttributeSubfield("idTipoContrato:descricao")
        ]
        private TipoConvite m_IdTipoConvite;
        public TipoConvite tipoConvite
        {
            get { return this.m_IdTipoConvite; }
            set { this.m_IdTipoConvite = value; }
        }
  
        private TituloSocio m_TituloSocio;
        public TituloSocio tituloSocio
        {
            get { return this.m_TituloSocio; }
            set { this.m_TituloSocio = value; }
        }

        private Convidado m_Convidado;
        public Convidado convidado
        {
            get { return this.m_Convidado; }
            set { this.m_Convidado = value; }
        }

        [
           TFieldAttributeGridDisplay("Dt. de Criação do convite", 90),
           TFieldAttributeFormat("dd/MM/yyyy", "date")
       ]
        private DateTime m_DataCriacaoConvite;
        public DateTime dataCriacaoConvite
        {
            get { return this.m_DataCriacaoConvite; }
            set { this.m_DataCriacaoConvite = value; }
        }
        [
            TFieldAttributeGridDisplay("Dt. de Vencimento Inicial", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataVencimentoInicial;
        public DateTime dataVencimentoInicial
        {
            get { return this.m_DataVencimentoInicial; }
            set { this.m_DataVencimentoInicial = value; }
        }
        [
            TFieldAttributeGridDisplay("Dt. de Vencimento Final", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataVencimentoFinal;
        public DateTime dataVencimentoFinal
        {
            get { return this.m_DataVencimentoFinal; }
            set { this.m_DataVencimentoFinal = value; }
        }

        private string m_MetodoCriacao;
        public string metodoCriacao
        {
            get { return this.m_MetodoCriacao; }
            set { this.m_MetodoCriacao = value; }
        }

        private Funcionario m_Funcionario;
        public Funcionario funcionario
        {
            get { return this.m_Funcionario; }
            set { this.m_Funcionario = value; }
        }

        private ContasAReceber m_IdContasAReceber;
        public ContasAReceber contasAReceber
        {
            get { return this.m_IdContasAReceber; }
            set { this.m_IdContasAReceber = value; }
        }


    }
}
