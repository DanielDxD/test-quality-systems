using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ExportacaoContabil : Base
    {
        public ExportacaoContabil() : base()
        {
        }


        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 55),
            TFieldAttributeData(20, false)
        ]
        private int m_IdExportacaoContabil;
        public int idExportacaoContabil
        {
            get { return this.m_IdExportacaoContabil; }
            set { this.m_IdExportacaoContabil = value; }
        }


        [
            TFieldAttributeGridDisplay("Código Contábil", 125),
            TFieldAttributeEditDisplay("Código Contábil", 125),
            TFieldAttributeData(20, true),
            TFieldAttributeKey(false, false)
        ]
        private string m_CodigoContabil;
        public string codigoContabil
        {
            get { return this.m_CodigoContabil; }
            set { this.m_CodigoContabil = value; }
        }

        [
            TFieldAttributeGridDisplay("Natureza de Operação", 165),
            TFieldAttributeEditDisplay("Natureza de Operação", 165),
            TFieldAttributeSubfield("idNaturezaOperacao:descricao"),
            TFieldAttributeData(10, false, true, true)
        ]
        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Departamento", 145),
            TFieldAttributeEditDisplay("Departamento", 145),
            TFieldAttributeSubfield("idDepartamento:descricao"),
            TFieldAttributeData(10, false, true, true)
        ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        private string m_Provisiona;
        public string provisiona
        {
            get { return this.m_Provisiona; }
            set { this.m_Provisiona = value; }
        }


        [
            TFieldAttributeGridDisplay("Provisiona", 85),
            TFieldAttributeEditDisplay("Provisiona", 85),
            TFieldAttributeKey(false, false)
        ]
        private bool m_ProvisionaBool;
        public bool provisionaBool
        {
            get { return this.m_ProvisionaBool; }
            set { this.m_ProvisionaBool = value; }
        }
              
        [
            TFieldAttributeGridDisplay("Pessoa", 200),
            TFieldAttributeEditDisplay("Pessoa", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial:3"),
            TFieldAttributeData(10, false, true, true)
        ]
        private EmpresaRelacionamento m_IdEmpresaRelacionamento;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        private int m_IdEmpresaRelacionamento1;
        public int idEmpresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento1; }
            set { this.m_IdEmpresaRelacionamento1 = value; }
        }

        [
            TFieldAttributeGridDisplay("Conta", 145),
            TFieldAttributeEditDisplay("Conta", 145),
            TFieldAttributeSubfield("idContaPagamento:descricao"),
            TFieldAttributeData(10, false, true, true)
        ]
        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Retenções", 145),
            TFieldAttributeSubfield("ItemGenerico:multaP_Pagamento - Multa;jurosP_Pagamento - Juros;cmP_Pagamento - Correção Monetária;descontoP_Pagamento - Desconto;inssP_Pagamento - INSS;issP_Pagamento - ISS;irP_Pagamento - IR;pisP_Pagamento - PIS;cofinsP_Pagamento - COFINS;csllP_Pagamento - CSLL;multaR_Recebimento - Multa;jurosR_Recebimento - Juros;cmR_Recebimento - Correção Monetária;descontoR_Recebimento - Desconto;inssR_Recebimento - INSS;issR_Recebimento - ISS;irR_Recebimento - IR;pisR_Recebimento - PIS;cofinsR_Recebimento - COFINS;csllR_Recebimento - CSLL"),
            TFieldAttributeData(20, false, true, true)
        ]
        private string m_TipoRetencao;
        public string tipoRetencao
        {
            get { return this.m_TipoRetencao; }
            set { this.m_TipoRetencao = value; }
        }

        public override string ToString()
        {
            return this.m_IdExportacaoContabil.ToString();
        }
    }
}
