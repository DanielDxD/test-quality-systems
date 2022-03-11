using System;

namespace Data
{
    //[Serializable]
    public class ParametroBoleto : Base
    {
        public ParametroBoleto() : base()
        {
        }

        private int m_IdParametroBoleto;
        public int idParametroBoleto
        {
            get { return this.m_IdParametroBoleto; }
            set { this.m_IdParametroBoleto = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private String m_CodigoEstacao;
        public String codigoEstacao
        {
            get { return this.m_CodigoEstacao; }
            set { this.m_CodigoEstacao = value; }
        }

        private String m_CodigoConvenio;
        public String codigoConvenio
        {
            get { return this.m_CodigoConvenio; }
            set { this.m_CodigoConvenio = value; }
        }

        private String m_CodigoConvenioDigito;
        public String codigoConvenioDigito
        {
            get { return this.m_CodigoConvenioDigito; }
            set { this.m_CodigoConvenioDigito = value; }
        }

        private String m_CodigoCarteira;
        public String codigoCarteira
        {
            get { return this.m_CodigoCarteira; }
            set { this.m_CodigoCarteira = value; }
        }

        private double m_ValorTaxa;
        public double valorTaxa
        {
            get { return this.m_ValorTaxa; }
            set { this.m_ValorTaxa = value; }
        }

        private int m_Variacao;
        public int variacao
        {
            get { return this.m_Variacao; }
            set { this.m_Variacao = value; }
        }

        private String m_PadraoArquivo;
        public String padraoArquivo
        {
            get { return this.m_PadraoArquivo; }
            set { this.m_PadraoArquivo = value; }
        }

        private int m_TipoCadastramento;
        public int tipoCadastramento
        {
            get { return this.m_TipoCadastramento; }
            set { this.m_TipoCadastramento = value; }
        }

        private int m_TipoDocumento;
        public int tipoDocumento
        {
            get { return this.m_TipoDocumento; }
            set { this.m_TipoDocumento = value; }
        }

        private int m_IdentificadorEmissao;
        public int identificadorEmissao
        {
            get { return this.m_IdentificadorEmissao; }
            set { this.m_IdentificadorEmissao = value; }
        }

        private int m_EspecieTitulo;
        public int especieTitulo
        {
            get { return this.m_EspecieTitulo; }
            set { this.m_EspecieTitulo = value; }
        }

        private int m_InstrucaoCodificada1;
        public int instrucaoCodificada1
        {
            get { return this.m_InstrucaoCodificada1; }
            set { this.m_InstrucaoCodificada1 = value; }
        }

        private int m_InstrucaoCodificada2;
        public int instrucaoCodificada2
        {
            get { return this.m_InstrucaoCodificada2; }
            set { this.m_InstrucaoCodificada2 = value; }
        }

        private int m_PrazoProtesto;
        public int prazoProtesto
        {
            get { return this.m_PrazoProtesto; }
            set { this.m_PrazoProtesto = value; }
        }

        private int m_CodigoDevolucao;
        public int codigoDevolucao
        {
            get { return this.m_CodigoDevolucao; }
            set { this.m_CodigoDevolucao = value; }
        }

        private int m_PrazoDevolucao;
        public int prazoDevolucao
        {
            get { return this.m_PrazoDevolucao; }
            set { this.m_PrazoDevolucao = value; }
        }

        private int m_TipoJuro;
        public int tipoJuro
        {
            get { return this.m_TipoJuro; }
            set { this.m_TipoJuro = value; }
        }

        private int m_TipoMulta;
        public int tipoMulta
        {
            get { return this.m_TipoMulta; }
            set { this.m_TipoMulta = value; }
        }

        private ContaPagamento m_IdContaPagamento;
        public ContaPagamento contaPagamento
        {
            get { return this.m_IdContaPagamento; }
            set { this.m_IdContaPagamento = value; }
        }

        //idParametroBoleto
        private ParametroBoletoNossoNumero[] m_ParametroBoletoNossoNumeros;
        public ParametroBoletoNossoNumero[] parametroBoletoNossoNumeros
        {
            get { return this.m_ParametroBoletoNossoNumeros; }
            set { this.m_ParametroBoletoNossoNumeros = value; }
        }

        public override string ToString()
        {
            return this.m_IdParametroBoleto.ToString();
        }
    }
}
