using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ContasAPagarItem : Base
    {
        public ContasAPagarItem()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdContasAPagarItem;
        public int idContasAPagarItem
        {
            get { return this.m_IdContasAPagarItem; }
            set { this.m_IdContasAPagarItem = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 200),
            TFieldAttributeData(100, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 120),
            TFieldAttributeData(18, true),
            TFieldAttributeFormat("C2", "money")
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

        private int m_IdMovimentoManual;
        public int idMovimentoManual
        {
            get { return this.m_IdMovimentoManual; }
            set { this.m_IdMovimentoManual = value; }
        }

        private int m_IdNotaFiscal;
        public int idNotaFiscal
        {
            get { return this.m_IdNotaFiscal; }
            set { this.m_IdNotaFiscal = value; }
        }

        private int m_IdContasAPagar;
        public int idContasAPagar
        {
            get { return this.m_IdContasAPagar; }
            set { this.m_IdContasAPagar = value; }
        }

        [
            TFieldAttributeGridDisplay("Nat. Operação", 130),
            TFieldAttributeData(6, false, true, false),
            TFieldAttributeSubfield("idNaturezaOperacao:@NaturezaOperacao.idNaturezaOperacao.descricao")
        ]
        private int m_IdNaturezaOperacao;
        public int idNaturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Centro de Custo", 130),
            TFieldAttributeData(6, false, true, false),
            TFieldAttributeSubfield("idDepartamento:@Departamento.idDepartamento.descricao")
        ]
        private int m_IdDepartamento;
        public int idDepartamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }
    }
}