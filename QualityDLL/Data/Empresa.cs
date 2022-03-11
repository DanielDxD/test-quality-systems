using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [
        TClassAttributeFields
        (
            new String[]
                {
                    "m_IdEmpresa",
                    "m_IdPessoa"
                }
        )
    ]
    public class Empresa : Base
    {
        public Empresa()
            : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, false)
        ]
        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        [
            TFieldAttributeGridDisplay("Nome", 290),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idPessoa:nomeRazaoSocial")
        ]
        private Pessoa m_IdPessoa;
        public Pessoa pessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        private ParametroBoleto m_IdParametroBoleto;
        public ParametroBoleto parametroBoleto
        {
            get { return this.m_IdParametroBoleto; }
            set { this.m_IdParametroBoleto = value; }
        }

        private ParametroAcrescimo m_IdParametroAcrescimo;
        public ParametroAcrescimo parametroAcrescimo
        {
            get { return this.m_IdParametroAcrescimo; }
            set { this.m_IdParametroAcrescimo = value; }
        }

        private GrupoCobranca m_IdGrupoCobranca;
        public GrupoCobranca grupoCobranca
        {
            get { return this.m_IdGrupoCobranca; }
            set { this.m_IdGrupoCobranca = value; }
        }

        private String m_MascaraCodigoContabil;
        public String mascaraCodigoContabil
        {
            get { return this.m_MascaraCodigoContabil; }
            set { this.m_MascaraCodigoContabil = value; }
        }

        private String m_ChavePix;
        public String chavePix
        {
            get { return this.m_ChavePix; }
            set { this.m_ChavePix = value; }
        }

        private String m_DeveloperKey;
        public String developerKey
        {
            get { return this.m_DeveloperKey; }
            set { this.m_DeveloperKey = value; }
        }

        private String m_ClientId;
        public String clientId
        {
            get { return this.m_ClientId; }
            set { this.m_ClientId = value; }
        }

        private String m_ClientSecret;
        public String clientSecret
        {
            get { return this.m_ClientSecret; }
            set { this.m_ClientSecret = value; }
        }

        private DateTime m_DataCorte;
        public DateTime dataCorte
        {
            get { return this.m_DataCorte; }
            set { this.m_DataCorte = value; }
        }

        private NaturezaOperacao m_naturezaOperacaoMulta;
        public NaturezaOperacao naturezaOperacaoMulta
        {
            get { return this.m_naturezaOperacaoMulta; }
            set { this.m_naturezaOperacaoMulta = value; }
        }

        private NaturezaOperacao m_naturezaOperacaoCorrecaoMonetaria;
        public NaturezaOperacao naturezaOperacaoCorrecaoMonetaria
        {
            get { return this.m_naturezaOperacaoCorrecaoMonetaria; }
            set { this.m_naturezaOperacaoCorrecaoMonetaria = value; }
        }

        private int m_Crt;
        public int crt
        {
            get { return this.m_Crt; }
            set { this.m_Crt = value; }
        }

        private byte[] m_certificado;
        public byte[] certificado
        {
            get { return this.m_certificado; }
            set { this.m_certificado = value; }
        }

        private string m_nomeCertificado;
        public string nomeCertificado
        {
            get { return this.m_nomeCertificado; }
            set { this.m_nomeCertificado = value; }
        }

        private string m_assinatura;
        public string assinatura
        {
            get { return this.m_assinatura; }
            set { this.m_assinatura = value; }
        }

        private string m_senhaCertificado;
        public string senhaCertificado
        {
            get { return this.m_senhaCertificado; }
            set { this.m_senhaCertificado = value; }
        }

        private string m_csc;
        public string csc
        {
            get { return this.m_csc; }
            set { this.m_csc = value; }
        }

        private string m_idCsc;
        public string idCsc
        {
            get { return this.m_idCsc; }
            set { this.m_idCsc = value; }
        }

        private int m_cnae;
        public int cnae
        {
            get { return this.m_cnae; }
            set { this.m_cnae = value; }
        }

        private int m_regimePisCofins;
        public int regimePisCofins
        {
            get { return this.m_regimePisCofins; }
            set { this.m_regimePisCofins = value; }
        }

        private int m_diaVencimentoDebito;
        public int diaVencimentoDebito
        {
            get { return this.m_diaVencimentoDebito; }
            set { this.m_diaVencimentoDebito = value; }
        }

        private double m_aliquotaPis;
        public double aliquotaPis
        {
            get { return this.m_aliquotaPis; }
            set { this.m_aliquotaPis = value; }
        }

        private double m_aliquotaCofins;
        public double aliquotaCofins
        {
            get { return this.m_aliquotaCofins; }
            set { this.m_aliquotaCofins = value; }
        }

        private Estado m_IdEstado;
        public Estado estado
        {
            get { return this.m_IdEstado; }
            set { this.m_IdEstado = value; }
        }

        private string m_tipoEmissaoFiscal;
        public string tipoEmissaoFiscal
        {
            get { return this.m_tipoEmissaoFiscal; }
            set { this.m_tipoEmissaoFiscal = value; }
        }

        private double m_Multa;
        public double multa
        {
            get { return this.m_Multa; }
            set { this.m_Multa = value; }
        }

        private string m_GerarDebitoPosPago;
        public string gerarDebitoPosPago
        {
            get { return this.m_GerarDebitoPosPago; }
            set { this.m_GerarDebitoPosPago = value; }
        }

        private string m_AgruparDebitosTitularDependente;
        public string agruparDebitosTitularDependente
        {
            get { return this.m_AgruparDebitosTitularDependente; }
            set { this.m_AgruparDebitosTitularDependente = value; }
        }

        public override string ToString()
        {
            return this.m_IdEmpresa.ToString();
        }
    }
}
