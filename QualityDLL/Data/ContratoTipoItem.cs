using System;

namespace Data
{
    //[Serializable]
    public class ContratoTipoItem : Base
    {

        public ContratoTipoItem() : base()
        {
        }

        private int m_IdContratoTipoItem;
        public int idContratoTipoItem
        {
            get { return this.m_IdContratoTipoItem; }
            set { this.m_IdContratoTipoItem = value; }
        }

        private ContratoTipo m_IdContratoTipo;
        public ContratoTipo contratoTipo
        {
            get { return this.m_IdContratoTipo; }
            set { this.m_IdContratoTipo = value; }
        }

        private TipoRelacionamento m_IdTipoRelacionamento;
        public TipoRelacionamento tipoRelacionamento
        {
            get { return this.m_IdTipoRelacionamento; }
            set { this.m_IdTipoRelacionamento = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        private string m_Genero;
        public string genero
        {
            get { return this.m_Genero; }
            set { this.m_Genero = value; }
        }

        private DateTime m_DtAdmissaoInicial;
        public DateTime dtAdmissaoInicial
        {
            get { return this.m_DtAdmissaoInicial; }
            set { this.m_DtAdmissaoInicial = value; }
        }

        private DateTime m_DtAdmissaoFinal;
        public DateTime dtAdmissaoFinal
        {
            get { return this.m_DtAdmissaoFinal; }
            set { this.m_DtAdmissaoFinal = value; }
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

        private ContratoTipoItemValor[] m_ContratoTipoItemValor;
        public ContratoTipoItemValor[] contratoTipoItemValor
        {

            get { return this.m_ContratoTipoItemValor; }
            set { this.m_ContratoTipoItemValor = value; }
        }

    }
}
