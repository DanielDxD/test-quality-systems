using System;
using System.Collections.Generic;
using Utils;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class EmpresaRelacionamento : Base
    {
        public EmpresaRelacionamento() : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdEmpresaRelacionamento;
        public int idEmpresaRelacionamento
        {
            get { return this.m_IdEmpresaRelacionamento; }
            set { this.m_IdEmpresaRelacionamento = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private DateTime m_DataInicio;
        public DateTime dataInicio
        {
            get { return this.m_DataInicio; }
            set { this.m_DataInicio = value; }
        }

        private double m_LimitPosPago;
        public double limitePosPago
        {
            get { return this.m_LimitPosPago; }
            set { this.m_LimitPosPago = value; }
        }

        private DateTime m_DataTermino;
        public DateTime dataTermino
        {
            get { return this.m_DataTermino; }
            set { this.m_DataTermino = value; }
        }

        private string m_CodigoExportacao;
        public string codigoExportacao
        {
            get { return this.m_CodigoExportacao; }
            set { this.m_CodigoExportacao = value; }
        }

        private string m_Senha;
        public string senha
        {
            get { return this.m_Senha; }
            set { this.m_Senha = value; }
        }

        [
            TFieldAttributeGridDisplay("Nome", 390),
            TFieldAttributeData(6, true),
            TFieldAttributeSubfield("idPessoa:nomeRazaoSocial")
        ]
        private Pessoa m_IdPessoa;
        public Pessoa pessoa
        {
            get { return this.m_IdPessoa; }
            set { this.m_IdPessoa = value; }
        }

        private TipoRelacionamentoEmpresa m_IdTipoRelacionamentoEmpresa;
        public TipoRelacionamentoEmpresa tipoRelacionamentoEmpresa
        {
            get { return this.m_IdTipoRelacionamentoEmpresa; }
            set { this.m_IdTipoRelacionamentoEmpresa = value; }
        }

        private EmpresaRelacionamento m_IdPessoaRelacionadaEmpresa;
        public EmpresaRelacionamento pessoaRelacionadaEmpresa
        {
            get { return this.m_IdPessoaRelacionadaEmpresa; }
            set { this.m_IdPessoaRelacionadaEmpresa = value; }
        }

        //idPessoaRelacionadaEmpresa
        private EmpresaRelacionamento[] m_EmpresaRelacionamentos;
        public EmpresaRelacionamento[] empresaRelacionamentos
        {
            get { return this.m_EmpresaRelacionamentos; }
            set { this.m_EmpresaRelacionamentos = value; }
        }

        //idEmpresaRelacionamento
        private EmpresaRelacionamentoCartao[] m_Comandas;
        public EmpresaRelacionamentoCartao[] comandas
        {
            get { return this.m_Comandas; }
            set { this.m_Comandas = value; }
        }

        //idEmpresaRelacionamento
        private Cartao[] m_Cartoes;
        public Cartao[] cartoes
        {
            get { return this.m_Cartoes; }
            set { this.m_Cartoes = value; }
        }

        //idEmpresaRelacionamento
        private ExameEmpresaRelacionamento[] m_ExameEmpresaRelacionamentos;
        public ExameEmpresaRelacionamento[] exameEmpresaRelacionamentos
        {
            get { return this.m_ExameEmpresaRelacionamentos; }
            set { this.m_ExameEmpresaRelacionamentos = value; }
        }

        private String m_DadosBancarios;
        public String dadosBancarios
        {
            get { return this.m_DadosBancarios; }
            set { this.m_DadosBancarios = value; }
        }

        private ExportacaoContabil m_ExportacaoContabil;
        public ExportacaoContabil exportacaoContabil
        {
            get { return this.m_ExportacaoContabil; }
            set { this.m_ExportacaoContabil = value; }
        }

        private string m_Username;
        public string username
        {
            get { return this.m_Username; }
            set { this.m_Username = value; }
        }

        public override string ToString()
        {
            return this.m_IdEmpresaRelacionamento.ToString();
        }

        public EmpresaRelacionamento authenticate()
        {

            string _filter = "";
            _filter += (_filter.Length > 0 ? " AND " : null) + String.Format("(pessoa.cpfCnpj = '{0}' OR email.informacao = '{0}')", this.username);
            _filter += (_filter.Length > 0 ? " AND " : null) + String.Format("empresaRelacionamento.senha = (SELECT STUFF((SELECT CAST(HASHBYTES('MD5',  '1234') as varbinary(max)) FOR XML PATH('')), 1, 0, ''))", this.senha);
            _filter += (_filter.Length > 0 ? " AND " : null) + "empresaRelacionamento.dataTermino IS NULL";
            Data.EmpresaRelacionamento key = new EmpresaRelacionamento();
            try
            {
                List<NameValue> _params = new List<NameValue>() { new NameValue { name = "Filter", value = _filter } };
                key = (Data.EmpresaRelacionamento)Utils.Utils.listaDados(this.idEmpresa, key, 1, _params)[0];
            }
            catch
            {
                key = null;
            }
            return key;
        }
    }
}
