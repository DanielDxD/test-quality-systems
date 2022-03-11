using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ContasAReceberItem : Base
    {
        public ContasAReceberItem()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdContasAReceberItem;
        public int idContasAReceberItem
        {
            get { return this.m_IdContasAReceberItem; }
            set { this.m_IdContasAReceberItem = value; }
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

        private double m_AliquotaIss;
        public double aliquotaIss
        {
            get { return this.m_AliquotaIss; }
            set { this.m_AliquotaIss = value; }
        }

        private double m_ValorIss;
        public double valorIss
        {
            get { return this.m_ValorIss; }
            set { this.m_ValorIss = value; }
        }

        private double m_AliquotaIcms;
        public double aliquotaIcms
        {
            get { return this.m_AliquotaIcms; }
            set { this.m_AliquotaIcms = value; }
        }

        private double m_ValorIcms;
        public double valorIcms
        {
            get { return this.m_ValorIcms; }
            set { this.m_ValorIcms = value; }
        }


        [
            TFieldAttributeGridDisplay("Desconto", 120),
            TFieldAttributeData(18, false),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_ValorDesconto;
        public double valorDesconto
        {
            get { return this.m_ValorDesconto; }
            set { this.m_ValorDesconto = value; }
        }

        private ContasAReceber m_IdContasAReceber;
        public ContasAReceber idContasAReceber
        {
            get { return this.m_IdContasAReceber; }
            set { this.m_IdContasAReceber = value; }
        }

        private Movimento m_IdMovimento;
        public Movimento idMovimento
        {
            get { return this.m_IdMovimento; }
            set { this.m_IdMovimento = value; }
        }

        private MovimentoManual m_IdMovimentoManual;
        public MovimentoManual idMovimentoManual
        {
            get { return this.m_IdMovimentoManual; }
            set { this.m_IdMovimentoManual = value; }
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


        private Departamento m_departamento;
        public Departamento departamento
        {
            get { return this.m_departamento; }
            set { this.m_departamento = value; }
        }

        private PdvCompraCupomItem m_IdPdvCompraCupomItem;
        public PdvCompraCupomItem pdvCompraCupomItem
        {
            get { return this.m_IdPdvCompraCupomItem; }
            set { this.m_IdPdvCompraCupomItem = value; }
        }

        private Financeiro.JurosMulta m_jurasMultaSugerido;
        public Financeiro.JurosMulta jurosMultaSugerido
        {
            get { return this.m_jurasMultaSugerido; }
            set { this.m_jurasMultaSugerido = value; }
        }

        private Convite m_IdConvite;
        public Convite convite
        {
            get { return this.m_IdConvite; }
            set { this.m_IdConvite = value; }
        }

        private double m_descontoSugerido;
        public double descontoSugerido
        {
            get { return this.m_descontoSugerido; }
            set { this.m_descontoSugerido = value; }
        }

    }
}