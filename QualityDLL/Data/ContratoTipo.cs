using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ContratoTipo : Base
    {

        public ContratoTipo() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdContratoTipo;
        public int idContratoTipo
        {
            get { return this.m_IdContratoTipo; }
            set { this.m_IdContratoTipo = value; }
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
            TFieldAttributeGridDisplay("Tipo de recorrência", 200),
            TFieldAttributeSubfield("idContratoTipoRecorrencia:descricao")
        ]
        private ContratoTipoRecorrencia m_IdContratoTipoRecorrencia;
        public ContratoTipoRecorrencia contratoTipoRecorrencia
        {
            get { return this.m_IdContratoTipoRecorrencia; }
            set { this.m_IdContratoTipoRecorrencia = value; }
        }

        [
            TFieldAttributeGridDisplay("Natureza de Operação", 200),
            TFieldAttributeSubfield("idNaturezaOperacao:descricao")
        ]
        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }


        [
            TFieldAttributeGridDisplay("Departamento", 200),
            TFieldAttributeSubfield("idDepartamento:descricao")
        ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }


        [
            TFieldAttributeGridDisplay("Categoria", 200),
            TFieldAttributeSubfield("idCategoriaTitulo:descricao")
        ]
        private CategoriaTitulo m_IdCategoriaTitulo;
        public CategoriaTitulo categoriaTitulo
        {
            get { return this.m_IdCategoriaTitulo; }
            set { this.m_IdCategoriaTitulo = value; }
        }

        private ContratoTipoItem[] m_ContratoTipoItems;
        public ContratoTipoItem[] contratoTipoItem
        {
            get { return this.m_ContratoTipoItems; }
            set { this.m_ContratoTipoItems = value; }
        }


        [
            TFieldAttributeGridDisplay("Dia de vencimento", 100),
            TFieldAttributeData(20, false)
        ]
        private int m_DiaVencimento;
        public int diaVencimento
        {
            get { return this.m_DiaVencimento; }
            set { this.m_DiaVencimento = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor Base", 95),
            TFieldAttributeFormat("C2", "")
        ]
        private double m_ValorBase;
        public double valorBase
        {
            get { return this.m_ValorBase; }
            set { this.m_ValorBase = value; }
        }

    }
}
