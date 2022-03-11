using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class TituloSocio : Base
    {
        public TituloSocio() : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdTituloSocio;
        public int idTituloSocio
        {
            get { return this.m_IdTituloSocio; }
            set { this.m_IdTituloSocio = value; }
        }


        private CategoriaTitulo m_IdCategoriaTitulo;
        public CategoriaTitulo categoriaTitulo
        {
            get { return this.m_IdCategoriaTitulo; }
            set { this.m_IdCategoriaTitulo = value; }
        }

        private TituloSocio m_IdTituloSocioTitular;
        public TituloSocio titular
        {
            get { return this.m_IdTituloSocioTitular; }
            set { this.m_IdTituloSocioTitular = value; }
        }

        [
            TFieldAttributeGridDisplay("Categoria", 120),
        ]
        private string m_CategoriaView;
        public string categoriaView
        {
            get { return this.m_CategoriaView; }
            set { this.m_CategoriaView = value; }
        }

        [
            TFieldAttributeGridDisplay("Título", 120),
            TFieldAttributeSubfield("idTitulo:numero")
        ]
        private Titulo m_IdTitulo;
        public Titulo titulo
        {
            get { return this.m_IdTitulo; }
            set { this.m_IdTitulo = value; }
        }

        [
            TFieldAttributeGridDisplay("CPF/CNPJ", 200)
        ]
        private String m_CpfCnpj;
        public String cpfCnpj
        {
            get { return this.m_CpfCnpj; }
            set { this.m_CpfCnpj = value; }
        }

        [
            TFieldAttributeGridDisplay("Nome", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial")
        ]
        private EmpresaRelacionamento m_IdTitularEmpresaRelacionamento;
        public EmpresaRelacionamento titularEmpresaRelacionamento
        {
            get { return this.m_IdTitularEmpresaRelacionamento; }
            set { this.m_IdTitularEmpresaRelacionamento = value; }
        }

        private bool m_dependente;
        public bool dependente
        {
            get { return this.m_dependente; }
            set { this.m_dependente = value; }
        }

        private bool m_vinculado;
        public bool vinculado
        {
            get { return this.m_vinculado; }
            set { this.m_vinculado = value; }
        }

        private TituloSocioVinculo m_IdTituloSocioVinculo;
        public TituloSocioVinculo meuVinculo
        {
            get { return this.m_IdTituloSocioVinculo; }
            set { this.m_IdTituloSocioVinculo = value; }
        }

        [
            TFieldAttributeGridDisplay("Tipo", 200)
        ]
        private string m_Tipo;
        public string tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private DateTime m_DataContrato;
        public DateTime dataContrato
        {
            get { return this.m_DataContrato; }
            set { this.m_DataContrato = value; }
        }

        private DateTime m_dataInicioTitulo;
        public DateTime dataInicioTitulo
        {
            get { return this.m_dataInicioTitulo; }
            set { this.m_dataInicioTitulo = value; }
        }

        private DateTime m_dataFimTitulo;
        public DateTime dataFimTitulo
        {
            get { return this.m_dataFimTitulo; }
            set { this.m_dataFimTitulo = value; }
        }

        private bool m_Ativo;
        public bool ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

        private DateTime m_DataCadastramento;
        public DateTime dataCadastramento
        {
            get { return this.m_DataCadastramento; }
            set { this.m_DataCadastramento = value; }
        }

        private int m_UsuarioCadastramento;
        public int usuarioCadastramento
        {
            get { return this.m_UsuarioCadastramento; }
            set { this.m_UsuarioCadastramento = value; }
        }

        private TituloSocioSituacao m_situacaoAtual;
        public TituloSocioSituacao situacaoAtual
        {
            get { return this.m_situacaoAtual; }
            set { this.m_situacaoAtual = value; }
        }

        private DateTime m_DataAlteracao;
        public DateTime dataAlteracao
        {
            get { return this.m_DataAlteracao; }
            set { this.m_DataAlteracao = value; }
        }

        private int m_UsuarioAlteracao;
        public int usuarioAlteracao
        {
            get { return this.m_UsuarioAlteracao; }
            set { this.m_UsuarioAlteracao = value; }
        }

        //idTituloSocio
        private TituloSocioLancamentoContabil[] m_TituloSocioLancamentoContabils;
        public TituloSocioLancamentoContabil[] tituloSocioLancamentoContabils
        {
            get { return this.m_TituloSocioLancamentoContabils; }
            set { this.m_TituloSocioLancamentoContabils = value; }
        }

        private TituloSocioSituacao[] m_TituloSocioSituacao;
        public TituloSocioSituacao[] tituloSocioSituacao
        {
            get { return this.m_TituloSocioSituacao; }
            set { this.m_TituloSocioSituacao = value; }
        }

        private TituloSocioVinculo[] m_TituloSocioVinculo;
        public TituloSocioVinculo[] tituloSocioVinculo
        {
            get { return this.m_TituloSocioVinculo; }
            set { this.m_TituloSocioVinculo = value; }
        }

        private TituloSocioDependente[] m_Dependentes;
        public TituloSocioDependente[] dependentes
        {
            get { return this.m_Dependentes; }
            set { this.m_Dependentes = value; }
        }

        private TipoRelacionamento m_IdTipoRelacionamento;
        public TipoRelacionamento tipoRelacionamento
        {
            get { return this.m_IdTipoRelacionamento; }
            set { this.m_IdTipoRelacionamento = value; }
        }

        private ContasAPagar[] m_ContasAPagar;
        public ContasAPagar[] contasAPagar
        {
            get { return this.m_ContasAPagar; }
            set { this.m_ContasAPagar = value; }
        }

        private ContasAReceber[] m_ContasAReceber;
        public ContasAReceber[] contasAReceber
        {
            get { return this.m_ContasAReceber; }
            set { this.m_ContasAReceber = value; }
        }

        private Convite[] m_Convite;
        public Convite[] convite
        {
            get { return this.m_Convite; }
            set { this.m_Convite = value; }
        }

        private Banco m_IdBanco;
        public Banco banco
        {

            get { return this.m_IdBanco; }
            set { this.m_IdBanco = value; }
        }

        private string m_Agencia;
        public string agencia
        {

            get { return this.m_Agencia; }
            set { this.m_Agencia = value; }
        }

        private string m_Conta;
        public string conta
        {

            get { return this.m_Conta; }
            set { this.m_Conta = value; }
        }

        public override string ToString()
        {
            return this.m_IdTituloSocio.ToString();
        }
    }
}
