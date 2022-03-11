using System;
using Utils.Pagina.Attributes;

namespace Data
{

    public class TipoConvite : Base
    {
        public TipoConvite() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_idTipoConvite;
        public int idTipoConvite
        {
            get { return this.m_idTipoConvite; }
            set { this.m_idTipoConvite = value; }
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

        private string m_ModeloTermo;
        public string modeloTermo
        {
            get { return this.m_ModeloTermo; }
            set { this.m_ModeloTermo = value; }
        }

        private int m_IdadeInicial;
        public int idadeInicial
        {
            get { return this.m_IdadeInicial; }
            set { this.m_IdadeInicial = value; }
        }

        private int m_IdadeFinal;
        public int idadeFinal
        {
            get { return this.m_IdadeFinal; }
            set { this.m_IdadeFinal = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor", 120),
            TFieldAttributeFormat("C2", "money")
        ]
        private double m_valor;
        public double valor
        {
            get { return this.m_valor; }
            set { this.m_valor = value; }
        }

        [
            TFieldAttributeGridDisplay("Nat. Operação", 130),
            TFieldAttributeSubfield("idNaturezaOperacao:descricao")
        ]
        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        [
           TFieldAttributeGridDisplay("Departamento", 130),
           TFieldAttributeSubfield("departamento:descricao")
       ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        [
            TFieldAttributeGridDisplay("Idade Inicial / Final", 100),
            TFieldAttributeData(20, false)
        ]
        private String m_idadeInicialFinalDisplay;
        public string idadeInicialFinalDisplay
        {
            get { return this.m_idadeInicialFinalDisplay; }
            set { this.m_idadeInicialFinalDisplay = value; }
        }
    }
}
