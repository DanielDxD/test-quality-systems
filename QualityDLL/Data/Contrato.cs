using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Contrato : Base
    {

        public Contrato() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdContrato;
        public int idContrato
        {
            get { return this.m_IdContrato; }
            set { this.m_IdContrato = value; }
        }

        [
            TFieldAttributeGridDisplay("Tipo de Contrato", 200),
            TFieldAttributeSubfield("idContratoTipo:descricao")
        ]
        private ContratoTipo m_IdContratoTipo;
        public ContratoTipo contratoTipo
        {
            get { return this.m_IdContratoTipo; }
            set { this.m_IdContratoTipo = value; }
        }

        [
            TFieldAttributeGridDisplay("Contratante", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial")
        ]
        private EmpresaRelacionamento m_IdEmpresaRelacionamento;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        private Funcionario m_IdFuncionario;
        public Funcionario funcionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }


        [
            TFieldAttributeGridDisplay("Valor", 95),
            TFieldAttributeFormat("C2", "")
        ]
        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private int m_Recorrencia;
        public int recorrencia
        {
            get { return this.m_Recorrencia; }
            set { this.m_Recorrencia = value; }
        }
        [
            TFieldAttributeGridDisplay("Dt. Inicial", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataInicial;
        public DateTime dataInicial
        {
            get { return this.m_DataInicial; }
            set { this.m_DataInicial = value; }
        }
        [
            TFieldAttributeGridDisplay("Dt. Final", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataFinal;
        public DateTime dataFinal
        {
            get { return this.m_DataFinal; }
            set { this.m_DataFinal = value; }
        }
        [
            TFieldAttributeGridDisplay("Dt. Cancelamento", 90),
            TFieldAttributeFormat("dd/MM/yyyy", "date")
        ]
        private DateTime m_DataCancelamento;
        public DateTime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
            set { this.m_DataCancelamento = value; }
        }

        private string m_ObservacaoCancelamento;
        public string observacaoCancelamento
        {
            get { return this.m_ObservacaoCancelamento; }
            set { this.m_ObservacaoCancelamento = value; }
        }

        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        private string m_gerarCobranca;
        public string gerarCobranca
        {
            get { return this.m_gerarCobranca; }
            set { this.m_gerarCobranca = value; }
        }
        [
            TFieldAttributeGridDisplay("Status", 90),
        ]

        private string m_Status;
        private string status
        {
            get
            {
                if (((DateTime?)m_DataCancelamento)?.Ticks > 0)
                    return "Cancelado";
                else if (((DateTime?)m_DataCancelamento)?.Ticks == 0 && (m_DataFinal.Ticks == 0 || (m_DataFinal.Ticks > 0 && (m_DataFinal.Date - DateTime.Now.Date).TotalSeconds >= 0)))
                    return "Ativo";
                else
                    return "Finalizado";
            }

        }

    }
}
