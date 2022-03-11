using System;
using System.Collections.Generic;
using System.Data;
using ExcelLibrary.SpreadSheet;
using System.Web;
using System.Linq;
using System.IO;

namespace ExportacaoContabil
{

    public class Deducao
    {
        private string m_Tipo;
        public string tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private double m_Valor;
        public double valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private string m_NumeroDocumento;
        public string numeroDocumento
        {
            get { return this.m_NumeroDocumento; }
            set { this.m_NumeroDocumento = value; }
        }

        private string m_CodigoExportacaoEmpresaRelacionamento;
        public string codigoExportacaoEmpresaRelacionamento
        {
            get { return this.m_CodigoExportacaoEmpresaRelacionamento; }
            set { this.m_CodigoExportacaoEmpresaRelacionamento = value; }
        }

        private int m_IdContasAPagar;
        public int idContasAPagar
        {
            get { return this.m_IdContasAPagar; }
            set { this.m_IdContasAPagar = value; }
        }
    }

    public class Colunas
    {
        private int m_Coluna;
        public int coluna
        {
            get { return this.m_Coluna; }
            set { this.m_Coluna = value; }
        }

        private string m_valor;
        public string valor
        {
            get { return this.m_valor; }
            set { this.m_valor = value; }
        }

        private string m_formato;
        public string formato
        {
            get { return this.m_formato; }
            set { this.m_formato = value; }
        }
    }

    public class Lancamentos
    {
        private int _idContasAReceber;
        public int idContasAReceber
        {
            get { return this._idContasAReceber; }
            set { this._idContasAReceber = value; }
        }

        private int _idNaturezaOperacao;
        public int idNaturezaOperacao
        {
            get { return this._idNaturezaOperacao; }
            set { this._idNaturezaOperacao = value; }
        }
    }

    public class ExportDominio
    {
        private DateTime m_DataMovimento;
        public DateTime dataMovimento
        {
            get { return this.m_DataMovimento; }
            set { this.m_DataMovimento = value; }
        }

        private string m_debito;
        public string debito
        {
            get { return this.m_debito; }
            set { this.m_debito = value; }
        }

        private string m_credito;
        public string credito
        {
            get { return this.m_credito; }
            set { this.m_credito = value; }
        }

        private double m_valor;
        public double valor
        {
            get { return this.m_valor; }
            set { this.m_valor = value; }
        }

        private string m_descricao;
        public string descricao
        {
            get { return this.m_descricao; }
            set { this.m_descricao = value; }
        }
    }

    public class ExportacaoContabil
    {

        private static Workbook _workbook = null;
        private static Worksheet _worksheet = null;
        private static int _lastRow = 0;
        private static List<Colunas> _linhas = new List<Colunas>();
        private static List<Lancamentos> _idContasAReceberNaturezaExportado = new List<Lancamentos>();
        private static List<int> _idContasAReceberExportado = new List<int>();
        private static List<int> _idItemsProcessados = new List<int>();
        public static List<ExportDominio> listExportDominio = new List<ExportDominio>();
        public static List<Deducao> deducoesPagamento = new List<Deducao>();
        public static List<Deducao> deducoesRecebimento = new List<Deducao>();
        public static bool exportDominio = false;
        public static string dataInicial = null;
        private static string m_dataFinal;
        public static string dataFinal
        {
            get { return m_dataFinal; }
            set
            {
                _file = dir + @"exportacaoContabil-" + formataData(dataInicial) + "-" + formataData(value) + ".xls";
                m_dataFinal = value;
            }
        }
        public static string _file = null;
        private static string dir = HttpContext.Current.Server.MapPath("/data/exportacaoContabil/");
        public static string erros = "";
        private static int errorCount = 0;
        private static string url = "";
        private static string link = "";

        private static void addErro(string msg)
        {
            erros += (erros != null && erros.Length > 0 ? "<br />" : null) + "<li>" + msg + "</li>";
            errorCount += 1;
        }

        public static void limpaErros()
        {
            erros = "";
            errorCount = 0;
        }
        private static void imprimeCabecalho()
        {

            _worksheet.Cells[_lastRow, 0] = new Cell("lancto auto");
            _worksheet.Cells[_lastRow, 1] = new Cell("debito");
            _worksheet.Cells[_lastRow, 2] = new Cell("credito");
            _worksheet.Cells[_lastRow, 3] = new Cell("data");
            _worksheet.Cells[_lastRow, 4] = new Cell("valor");
            _worksheet.Cells[_lastRow, 5] = new Cell("cód histórico");
            _worksheet.Cells[_lastRow, 6] = new Cell("complemento historico");
            _worksheet.Cells[_lastRow, 7] = new Cell("Ccusto debito");
            _worksheet.Cells[_lastRow, 8] = new Cell("Ccusto credito");
            _worksheet.Cells[_lastRow, 9] = new Cell("NrDocumento");
            _lastRow++;
        }

        private static void imprimeLinha(List<Colunas> linha)
        {
            int i = 0;
            foreach (Colunas col in linha)
            {
                _worksheet.Cells[_lastRow, col.coluna] = new Cell(col.valor, col.formato);
                i++;
            }
            _lastRow++;
        }

        private static string formataData(string data)
        {
            return data.Substring(8, 2) + "-" + data.Substring(5, 2) + "-" + data.Substring(0, 4);
        }

        private static void addLinhaExportDominio(DateTime data, string debito, string credito, double valor, string descricao)
        {
            if (listExportDominio == null)
                listExportDominio = new List<ExportDominio>();
            else { }

            ExportDominio ed = new ExportDominio
            {
                dataMovimento = data,
                debito = debito,
                credito = credito,
                valor = valor,
                descricao = descricao.Replace("|", "").Trim()
            };
            listExportDominio.Add(ed);
        }

        public static void make(string type = "xlsx")
        {
            try
            {
                if (!exportDominio)
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    else { }

                    _lastRow = 0;
                    erros = "";
                    if (String.IsNullOrEmpty(_file))
                        _file = dir + @"exportacaoContabil-" + formataData(dataInicial) + "-" + formataData(dataFinal) + ".xls";
                    else { }

                    if (_workbook == null)
                        _workbook = new Workbook();
                    else { }

                    if (_worksheet == null)
                        _worksheet = new Worksheet("Planilha 1");
                    else { }

                    imprimeCabecalho();
                    getLancamentosContasAPagar();
                    getLancamentosContasAReceber();
                    getLancamentosTransferencia();
                    getDeducoesPagamento();
                    getDeducoesRecebimento();

                    if (!String.IsNullOrEmpty(erros))
                        throw new Exception(erros);
                    else { }

                    _workbook.Worksheets.Add(_worksheet);
                    _workbook.Save(_file);

                    _workbook = null;
                    _worksheet = null;
                }
                else
                {
                    _lastRow = 0;
                    getLancamentosContasAPagar();
                    getLancamentosContasAReceber();
                    getLancamentosTransferencia();
                    getDeducoesPagamento();
                    getDeducoesRecebimento();

                    if (!String.IsNullOrEmpty(erros))
                        throw new Exception(erros);
                    else { }

                    txt();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void txt()
        {
            if (listExportDominio != null)
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                else { }
                _file = dir + @"exportacaoContabil-" + formataData(dataInicial) + "-" + formataData(dataFinal) + ".txt";
                string saida = "";
                foreach (ExportDominio ed in listExportDominio)
                {
                    saida += "|6000|X|\r\n";
                    saida += "|6100|" + ed.dataMovimento.ToString("dd/MM/yyyy") + "|" + ed.debito + "|" + ed.credito + "|" + ed.valor.ToString("f2") + "||" + ed.descricao + "|\r\n";
                }

                if (System.IO.File.Exists(_file))
                    System.IO.File.Delete(_file);
                else { }

                System.IO.File.WriteAllText(_file, saida);
                listExportDominio.Clear();
                listExportDominio = null;
            }
        }

        private static void getLancamentosContasAPagar()
        {

            string query = @" DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)

SELECT 
    cpi.idContasAPagarItem,
    cpi.idContasAPagar,
    cpi.idMovimentoManual,
    cpi.idNotaFiscal,
    cpi.descricao,
    cpi.valor,
    cpi.valorDesconto,
    cpi.idNaturezaOperacao,
    cpi.idDepartamento,
    cpi.valorMulta,
    cpi.valorJuros,
    cpi.valorCM,
    cp.idContasAPagar,
    cp.dataMovimento,
    cp.dataVencimento,
    cp.valor,
    cp.iss,
    cp.desconto,
    cp.idFornecedor,
    cp.idEmpresa,
    cp.idTipoMovimentoContabil,
    cp.valorPago,
    cp.dataUltimoPagamento,
    cp.emAberto,
    cp.parcela,
    cp.numeroDocumento,
    cp.dataCancelamento,
    cp.idEmpresaRelacionamento,
    cp.dataLancamento,
    cp.idEvento,
    eccr.idExportacaoContabil,
    eccr.idNaturezaOperacao,
    eccr.idDepartamento,
    eccr.idEmpresaRelacionamento,
    eccr.idContaPagamento,
    eccr.provisiona,
	eccr.tipoRetencao,
    eccr.codigoContabil,
    ecsr.idExportacaoContabil,
    ecsr.idNaturezaOperacao,
    ecsr.idDepartamento,
    ecsr.idEmpresaRelacionamento,
    ecsr.idContaPagamento,
    ecsr.provisiona,
	ecsr.tipoRetencao,
    ecsr.codigoContabil,
    ecer.idExportacaoContabil,
    ecer.idNaturezaOperacao,
    ecer.idDepartamento,
    ecer.idEmpresaRelacionamento,
    ecer.idContaPagamento,
    ecer.provisiona,
	ecer.tipoRetencao,
    ecer.codigoContabil,
    naturezaOperacao.idNaturezaOperacao,
    naturezaOperacao.idEmpresa,
    naturezaOperacao.descricao,
    naturezaOperacao.codigoContabilReduzido,
    naturezaOperacao.pagarReceber,
    departamento.idDepartamento,
    departamento.idEmpresa,
    departamento.descricao,
    departamento.alcada,
    departamento.armazem,
    departamento.idDepartamentoPai,
    departamento.idPlanoContas,
    empresaRelacionamento.idEmpresaRelacionamento,
    empresaRelacionamento.idTipoRelacionamentoEmpresa,
    empresaRelacionamento.idEmpresa,
    empresaRelacionamento.idPessoaRelacionamento,
    empresaRelacionamento.idPessoaRelacionadaEmpresa,
    empresaRelacionamento.dataInicio,
    empresaRelacionamento.dataTermino,
    empresaRelacionamento.codigoExportacao,
    empresaRelacionamento.dadosBancarios,
    pessoa.idPessoa,
    pessoa.pfpj,
    pessoa.cpfCnpj,
    pessoa.nomeRazaoSocial,
    pessoa.apelidoNomeComercial
FROM contasAPagarItem cpi
INNER JOIN contasAPagar cp 
	ON cp.idContasAPagar = cpi.idContasAPagar
LEFT JOIN exportacaoContabil eccr 
	ON eccr.idNaturezaOperacao = cpi.idNaturezaOperacao AND eccr.idDepartamento = cpi.idDepartamento
LEFT JOIN exportacaoContabil ecsr 
	ON ecsr.idNaturezaOperacao = cpi.idNaturezaOperacao AND ecsr.idDepartamento IS NULL
LEFT JOIN exportacaoContabil ecer
	on ecer.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT JOIN naturezaOperacao on naturezaOperacao.idNaturezaOperacao = cpi.idNaturezaOperacao
LEFT JOIN departamento on departamento.iddepartamento = cpi.iddepartamento
LEFT JOIN empresaRelacionamento on empresaRelacionamento.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT JOIN pessoa ON pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
WHERE 
	CAST(cp.dataMovimento AS DATE) BETWEEN @dataInicial and @dataFinal
order by cpi.idcontasapagaritem";

            DataTable results = Utils.Utils.em.executeData(query, null);
            try
            {
                if (results != null)
                {
                    foreach (DataRow item in results.Rows)
                    {

                        bool provisionar = false;
                        string
                            debito = "",
                            credito = "",
                            data = "",
                            valor = "",
                            complemento = "",
                            nroDocumento = "",
                            codigoContabilNatureza = "";


                        /* Empresa Relacionamento não está vazio */
                        if (!String.IsNullOrEmpty(item[46].ToString()))
                        {
                            /* Departamento ou natureza */
                            if (!String.IsNullOrEmpty(item[30].ToString()))
                            {
                                provisionar = item[35].ToString() == "s";
                                codigoContabilNatureza = item[37].ToString();
                            }
                            else if (!String.IsNullOrEmpty(item[38].ToString()))
                            {
                                provisionar = item[43].ToString() == "s";
                                codigoContabilNatureza = item[45].ToString();
                            }
                            else
                            {
                                url = "/pagina/financeiro/pagar/contasAPagarEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAPagar=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/pagar/contasAPagar");
                                link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a pagar <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a natureza de operação <b>" + item[56].ToString() + "</b> nem para o departamento <b>" + item[61].ToString() + "</b>.");
                            }

                            if (provisionar)
                            {

                                if (existeItensDiferentes(Convert.ToInt32(item[1]), Convert.ToInt32(item[0]), provisionar, "cp"))
                                {
                                    url = "/pagina/financeiro/pagar/contasAPagarEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAPagar=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/pagar/contasAPagar");
                                    link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                    addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a pagar <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não é possível exportar um contas a pagar que possui itens provisionados e não provisionados na mesma conta.");
                                }
                                else
                                {
                                    debito = codigoContabilNatureza; /* Natureza */
                                    credito = item[53].ToString(); /* Empresa Relacionamento */
                                    data = Convert.ToDateTime(item[13].ToString()).ToString("dd/MM/yyyy"); /* Data Movimento */
                                    valor = item[5].ToString(); /* Valor sem rateio do contar a pagar item */
                                    complemento = item[4].ToString();
                                    nroDocumento = item[25].ToString();

                                    if (exportDominio)
                                        addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                    else
                                    {
                                        _worksheet.Cells[_lastRow, 0] = new Cell("");
                                        _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                        _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                        _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                        _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                        _worksheet.Cells[_lastRow, 5] = new Cell("");
                                        _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                        _worksheet.Cells[_lastRow, 7] = new Cell("");
                                        _worksheet.Cells[_lastRow, 8] = new Cell("");
                                        _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                    }
                                    _lastRow++;
                                }

                            }
                            else { }
                        }
                    }
                }
                else { }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            results = null;
            query = @"
DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)

SELECT 

    cpp.idContasAPagarPagamento,
    cpp.idContasAPagar,
    cpp.dataMovimento,
    cpp.valorPrincipal,
    cpp.valorMulta,
    cpp.valorJuros,
    cpp.valorDesconto,
    cpp.valorCM,
    cpp.idContaPagamento,
    cpp.idTipoMovimentoContabil,
    cpp.valorINSSRetido,
    cpp.valorISSRetido,
    cpp.valorIRRetido,
    cpp.valorPISRetido,
    cpp.valorCOFINSRetido,
    cpp.valorCSLLRetido,
    cpp.idDocumentoPagamento,
    cp.idContasAPagar,
    cp.dataMovimento,
    cp.dataVencimento,
    cp.valor,
    cp.iss,
    cp.desconto,
    cp.idFornecedor,
    cp.idEmpresa,
    cp.idTipoMovimentoContabil,
    cp.valorPago,
    cp.dataUltimoPagamento,
    cp.emAberto,
    cp.parcela,
    cp.numeroDocumento,
    cp.dataCancelamento,
    cp.idEmpresaRelacionamento,
    cp.dataLancamento,
    cp.idEvento,
    cpi.idContasAPagarItem,
    cpi.idContasAPagar,
    cpi.idMovimentoManual,
    cpi.idNotaFiscal,
    cpi.descricao,
    cpi.valor,
    cpi.valorDesconto,
    cpi.idNaturezaOperacao,
    cpi.idDepartamento,
    cpi.valorMulta,
    cpi.valorJuros,
    cpi.valorCM,
    eccr.idExportacaoContabil,
    eccr.idNaturezaOperacao,
    eccr.idDepartamento,
    eccr.idEmpresaRelacionamento,
    eccr.idContaPagamento,
    eccr.provisiona,
    eccr.tipoRetencao,
    eccr.codigoContabil,
    ecsr.idExportacaoContabil,
    ecsr.idNaturezaOperacao,
    ecsr.idDepartamento,
    ecsr.idEmpresaRelacionamento,
    ecsr.idContaPagamento,
    ecsr.provisiona,
    ecsr.tipoRetencao,
    ecsr.codigoContabil,
    ecer.idExportacaoContabil,
    ecer.idNaturezaOperacao,
    ecer.idDepartamento,
    ecer.idEmpresaRelacionamento,
    ecer.idContaPagamento,
    ecer.provisiona,
    ecer.tipoRetencao,
    ecer.codigoContabil,
    eccp.idExportacaoContabil,
    eccp.idNaturezaOperacao,
    eccp.idDepartamento,
    eccp.idEmpresaRelacionamento,
    eccp.idContaPagamento,
    eccp.provisiona,
    eccp.tipoRetencao,
    eccp.codigoContabil,
    naturezaOperacao.idNaturezaOperacao,
    naturezaOperacao.idEmpresa,
    naturezaOperacao.descricao,
    naturezaOperacao.codigoContabilReduzido,
    naturezaOperacao.pagarReceber,
    departamento.idDepartamento,
    departamento.idEmpresa,
    departamento.descricao,
    departamento.alcada,
    departamento.armazem,
    departamento.idDepartamentoPai,
    departamento.idPlanoContas,
    empresaRelacionamento.idEmpresaRelacionamento,
    empresaRelacionamento.idTipoRelacionamentoEmpresa,
    empresaRelacionamento.idEmpresa,
    empresaRelacionamento.idPessoaRelacionamento,
    empresaRelacionamento.idPessoaRelacionadaEmpresa,
    empresaRelacionamento.dataInicio,
    empresaRelacionamento.dataTermino,
    empresaRelacionamento.codigoExportacao,
    empresaRelacionamento.dadosBancarios,
    pessoa.idPessoa,
    pessoa.pfpj,
    pessoa.cpfCnpj,
    pessoa.nomeRazaoSocial,
    pessoa.apelidoNomeComercial,
    contaPagamento.idContaPagamento,
    contaPagamento.idEmpresa,
    contaPagamento.descricao,
    contaPagamento.idBanco,
    contaPagamento.numeroConta,
    contaPagamento.tipoConta,
    contaPagamento.idUsuario,
    contaPagamento.idPlanoContas,
    contaPagamento.saldoAtual,
    contaPagamento.recebimentoVinculado,
    contaPagamento.pagamentoVinculado,
    contaPagamento.numeroChequeInicial,
    contaPagamento.numeroChequeFinal,
    contaPagamento.idFormaPagamento,
    contaPagamento.codigoExportacao,
    documentoPagamento.idDocumentoPagamento,
    documentoPagamento.dataMovimento,
    documentoPagamento.idEmpresa,
    documentoPagamento.idContaPagamento,
    documentoPagamento.numeroDocumento,
    documentoPagamento.serieDocumento,
    documentoPagamento.valorPago,
    documentoPagamento.dataCancelamento,
    documentoPagamento.motivoCancelamento,
    documentoPagamento.descricao,
    documentoPagamento.dataGeracao,
    documentoPagamento.idTipoDocumento,
    cpp.valorPrincipal + IsNull(cpp.valorMulta, 0) + IsNull(cpp.valorJuros, 0) - IsNull(cpp.valorDesconto, 0) + IsNull(cpp.valorCM, 0) - IsNull(cpp.valorINSSRetido, 0) - IsNull(cpp.valorISSRetido, 0) - IsNull(cpp.valorIRRetido, 0) - IsNull(cpp.valorPISRetido, 0) - IsNull(cpp.valorCOFINSRetido, 0) - IsNull(cpp.valorCSLLRetido, 0),
	CAST
	(
		(
			(
				(cpp.valorPrincipal + IsNull(cpp.valorMulta, 0) + IsNull(cpp.valorJuros, 0) - IsNull(cpp.valorDesconto, 0) + IsNull(cpp.valorCM, 0) - IsNull(cpp.valorINSSRetido, 0) - IsNull(cpp.valorISSRetido, 0) - IsNull(cpp.valorIRRetido, 0) - IsNull(cpp.valorPISRetido, 0) - IsNull(cpp.valorCOFINSRetido, 0) - IsNull(cpp.valorCSLLRetido, 0))
				/
				(cp.valor - cp.desconto - cp.iss)
			) * cpi.valor
		)
	AS DECIMAL(15, 2))
FROM contasAPagarPagamento cpp
INNER JOIN contasAPagar cp ON cpp.idContasAPagar = cp.idContasAPagar
INNER JOIN contasAPagarItem cpi ON cpi.idContasAPagar = cp.idContasAPagar
LEFT JOIN exportacaoContabil eccr 
	ON eccr.idNaturezaOperacao = cpi.idNaturezaOperacao AND eccr.idDepartamento = cpi.idDepartamento
LEFT JOIN exportacaoContabil ecsr 
	ON ecsr.idNaturezaOperacao = cpi.idNaturezaOperacao AND ecsr.idDepartamento IS NULL
LEFT JOIN exportacaoContabil ecer
	on ecer.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT  join exportacaoContabil eccp 
	on eccp.idContaPagamento = cpp.idContaPagamento
LEFT JOIN naturezaOperacao on naturezaOperacao.idNaturezaOperacao = cpi.idNaturezaOperacao
LEFT JOIN departamento on departamento.iddepartamento = cpi.iddepartamento
LEFT JOIN empresaRelacionamento on empresaRelacionamento.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT JOIN pessoa ON pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
LEFT JOIN contaPagamento
	ON contaPagamento.idContaPagamento = cpp.idContaPagamento
LEFT JOIN documentoPagamento
	ON documentoPagamento.idDocumentoPagamento = cpp.idDocumentoPagamento
WHERE 
	CAST(cpp.dataMovimento AS DATE) BETWEEN @dataInicial and @dataFinal
ORDER BY cpp.idContasAPagarPagamento";

            try
            {

                _idItemsProcessados = null;
                _idItemsProcessados = new List<int>();
                results = Utils.Utils.em.executeData(query, null);
                if (results != null)
                {
                    foreach (DataRow item in results.Rows)
                    {

                        bool
                            provisionar = false,
                            naturezaDepartamento = false;
                        string
                            debito = "",
                            credito = "",
                            data = "",
                            valor = "",
                            complemento = "",
                            nroDocumento = "",
                            codigoContabilNatureza = "";

                        if (!String.IsNullOrEmpty(item[63].ToString())) /* Existe linha pro empresa relacionamento */
                        {

                            if (String.IsNullOrEmpty(item[71].ToString())) /* Conta */
                            {
                                url = "/pagina/financeiro/pagar/contasAPagarEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAPagar=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/pagar/contasAPagar");
                                link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a pagar <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a conta de pagamento <b>" + item[107].ToString() + "</b>.");
                            }
                            else
                            {

                                /* Possui natureza de operação e departamento */
                                if (!String.IsNullOrEmpty(item[47].ToString()))
                                {
                                    provisionar = item[52].ToString() == "s";
                                    codigoContabilNatureza = item[54].ToString();
                                    naturezaDepartamento = true;
                                }
                                else if (!String.IsNullOrEmpty(item[55].ToString()))
                                {

                                    provisionar = item[60].ToString() == "s";
                                    codigoContabilNatureza = item[62].ToString();
                                    naturezaDepartamento = true;
                                }

                                if (!naturezaDepartamento)
                                {
                                    url = "/pagina/financeiro/pagar/contasAPagarEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAPagar=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/pagar/contasAPagar");
                                    link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                    addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a pagar <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a natureza de operação <b>" + item[81].ToString() + "</b> nem para o departamento <b>" + item[86].ToString() + "</b>.");
                                }
                                else
                                {
                                    if (provisionar)
                                    {

                                        int idItem = Convert.ToInt32(item[0].ToString());
                                        if (_idItemsProcessados.FirstOrDefault(T => T == idItem) <= 0)
                                        {
                                            _idItemsProcessados.Add(idItem);
                                            debito = item[70].ToString(); /* Conta Pagamento */
                                            credito = item[78].ToString(); /* Empresa Relaconamento */
                                            data = Convert.ToDateTime(item[2].ToString()).ToString("dd/MM/yyyy");
                                            valor = item[132].ToString(); /* Valor não rateado */
                                            complemento = item[129].ToString();
                                            nroDocumento = item[124].ToString();

                                            if (Convert.ToDouble(valor) > 0)
                                            {
                                                if (exportDominio)
                                                    addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                                else
                                                {
                                                    _worksheet.Cells[_lastRow, 0] = new Cell("");
                                                    _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                                    _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                                    _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                                    _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                                    _worksheet.Cells[_lastRow, 5] = new Cell("");
                                                    _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                                    _worksheet.Cells[_lastRow, 7] = new Cell("");
                                                    _worksheet.Cells[_lastRow, 8] = new Cell("");
                                                    _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                                }
                                                _lastRow++;
                                            }
                                            else { }
                                        }
                                        else { }
                                    }
                                    else
                                    {
                                        debito = codigoContabilNatureza; /* Conta Pagamento */
                                        credito = item[78].ToString(); /* Natureza */
                                        data = Convert.ToDateTime(item[2].ToString()).ToString("dd/MM/yyyy");
                                        valor = item[133].ToString(); /* Valor rateado */
                                        complemento = item[129].ToString();
                                        nroDocumento = item[124].ToString();

                                        if (Convert.ToDouble(valor) > 0)
                                        {
                                            if (exportDominio)
                                                addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                            else
                                            {
                                                _worksheet.Cells[_lastRow, 0] = new Cell("");
                                                _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                                _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                                _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                                _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                                _worksheet.Cells[_lastRow, 5] = new Cell("");
                                                _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                                _worksheet.Cells[_lastRow, 7] = new Cell("");
                                                _worksheet.Cells[_lastRow, 8] = new Cell("");
                                                _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                            }
                                            _lastRow++;
                                        }
                                        else { }

                                    }
                                }
                            }
                        }
                        else
                        {
                            /* Não possui empresa relacionamento e não possui conta */
                            if (String.IsNullOrEmpty(item[71].ToString()))
                            {
                                url = "/pagina/financeiro/pagar/contasAPagarEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAPagar=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/pagar/contasAPagar");
                                link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a pagar <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a conta de pagamento <b>" + item[107].ToString() + "</b>.");
                            }
                            else
                            {
                                /* Possui natureza de operação e departamento */
                                if (!String.IsNullOrEmpty(item[47].ToString()))
                                {
                                    provisionar = false;
                                    codigoContabilNatureza = item[54].ToString();
                                    naturezaDepartamento = true;
                                }
                                else if (!String.IsNullOrEmpty(item[56].ToString()))
                                {
                                    provisionar = false;
                                    codigoContabilNatureza = item[62].ToString();
                                    naturezaDepartamento = true;
                                }

                                debito = codigoContabilNatureza; /* Conta Pagamento */
                                credito = item[78].ToString(); /* Natureza */
                                data = Convert.ToDateTime(item[2].ToString()).ToString("dd/MM/yyyy");
                                valor = item[133].ToString(); /* Valor rateado */
                                complemento = item[129].ToString();
                                nroDocumento = item[124].ToString();

                                if (Convert.ToDouble(valor) > 0)
                                {
                                    if (exportDominio)
                                        addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                    else
                                    {
                                        _worksheet.Cells[_lastRow, 0] = new Cell("");
                                        _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                        _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                        _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                        _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                        _worksheet.Cells[_lastRow, 5] = new Cell("");
                                        _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                        _worksheet.Cells[_lastRow, 7] = new Cell("");
                                        _worksheet.Cells[_lastRow, 8] = new Cell("");
                                        _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                    }
                                    _lastRow++;
                                }
                                else { }
                            }
                        }
                    }
                }
                else { }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private static void getLancamentosContasAReceber()
        {

            string query = @" DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)

SELECT 
    cpi.idContasAReceberItem,
    cpi.idContasAReceber,
    cpi.idMovimento,
    cpi.idMovimentoManual,
    cpi.descricao,
    cpi.valor,
    cpi.aliquotaIss,
    cpi.valorIss,
    cpi.aliquotaIcms,
    cpi.valorIcms,
    cpi.valorDesconto,
    cpi.idNaturezaOperacao,
    cpi.idDepartamento,
    cpi.valorMulta,
    cpi.valorJuros,
    cpi.valorCm,
    cpi.idRequisicaoInternaProdutoServico,
    cpi.idPdvCompraCupomItem,
    cp.idContasAReceber,
    cp.dataLancamento,
    cp.dataVencimento,
    cp.descricao,
    cp.valor,
    cp.iss,
    cp.desconto,
    cp.idEmpresa,
    cp.idTipoMovimentoContabil,
    cp.valorRecebido,
    cp.dataUltimoRecebimento,
    cp.emAberto,
    cp.idEmpresaRelacionamento,
    cp.parcela,
    cp.numeroDocumento,
    cp.dataLancamentoEfetivo,
    cp.dataCancelamento,
    eccr.*,
    ecsr.*,
    ecer.*,
    naturezaOperacao.idNaturezaOperacao,
    naturezaOperacao.idEmpresa,
    naturezaOperacao.descricao,
    naturezaOperacao.codigoContabilReduzido,
    naturezaOperacao.pagarReceber,
    departamento.idDepartamento,
    departamento.idEmpresa,
    departamento.descricao,
    departamento.alcada,
    departamento.armazem,
    departamento.idDepartamentoPai,
    departamento.idPlanoContas,
    empresaRelacionamento.idEmpresaRelacionamento,
empresaRelacionamento.idTipoRelacionamentoEmpresa,
empresaRelacionamento.idEmpresa,
empresaRelacionamento.idPessoaRelacionamento,
empresaRelacionamento.idPessoaRelacionadaEmpresa,
empresaRelacionamento.dataInicio,
empresaRelacionamento.dataTermino,
empresaRelacionamento.codigoExportacao,
empresaRelacionamento.dadosBancarios,
    pessoa.idPessoa,
pessoa.pfpj,
pessoa.cpfCnpj,
pessoa.nomeRazaoSocial,
pessoa.apelidoNomeComercial 
FROM contasAreceberItem cpi
INNER JOIN contasAreceber cp 
	ON cp.idContasAreceber = cpi.idContasAreceber
LEFT JOIN exportacaoContabil eccr 
	ON eccr.idNaturezaOperacao = cpi.idNaturezaOperacao AND eccr.idDepartamento = cpi.idDepartamento
LEFT JOIN exportacaoContabil ecsr 
	ON ecsr.idNaturezaOperacao = cpi.idNaturezaOperacao AND ecsr.idDepartamento IS NULL
LEFT JOIN exportacaoContabil ecer
	on ecer.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT JOIN naturezaOperacao on naturezaOperacao.idNaturezaOperacao = cpi.idNaturezaOperacao
LEFT JOIN departamento on departamento.iddepartamento = cpi.iddepartamento
LEFT JOIN empresaRelacionamento on empresaRelacionamento.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT JOIN pessoa ON pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
WHERE 
	CAST(cp.dataLancamento AS DATE) BETWEEN @dataInicial and @dataFinal
order by cpi.idcontasareceberitem";

            DataTable results = Utils.Utils.em.executeData(query, null);
            try
            {
                if (results != null)
                {
                    foreach (DataRow item in results.Rows)
                    {

                        bool provisionar = false;
                        string
                            debito = "",
                            credito = "",
                            data = "",
                            valor = "",
                            complemento = "",
                            nroDocumento = "",
                            codigoContabilNatureza = "";

                        /* Empresa Relacionamento Vazio */
                        if (!String.IsNullOrEmpty(item[51].ToString()))
                        {

                            /* Possui natureza de operação e departamento */
                            if (!String.IsNullOrEmpty(item[35].ToString()))
                            {
                                provisionar = item[40].ToString() == "s";
                                codigoContabilNatureza = item[42].ToString();
                            }
                            else if (!String.IsNullOrEmpty(item[43].ToString()))
                            {
                                provisionar = item[48].ToString() == "s";
                                codigoContabilNatureza = item[50].ToString();
                            }
                            else
                            {

                                url = "/pagina/financeiro/receber/contasAReceberEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAReceber=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/receber/contasAReceber");
                                link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a receber <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a natureza de operação <b>" + item[61].ToString() + "</b> nem para o departamento <b>" + item[67].ToString() + "</b>.");

                            }

                            if (provisionar)
                            {

                                if (existeItensDiferentes(Convert.ToInt32(item[1]), Convert.ToInt32(item[0]), provisionar, "cr"))
                                {
                                    url = "/pagina/financeiro/receber/contasAReceberEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAReceber=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/receber/contasAReceber");
                                    link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                    addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a receber <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não é possível exportar um contas a receber que possui itens provisionados e não provisionados na mesma conta.");
                                }
                                else
                                {

                                    debito = item[58].ToString(); /* Empresa */
                                    credito = codigoContabilNatureza; /* Natureza */
                                    data = Convert.ToDateTime(item[19].ToString()).ToString("dd/MM/yyyy");
                                    valor = item[5].ToString();
                                    complemento = item[4].ToString().Trim();
                                    nroDocumento = item[32].ToString();

                                    if (exportDominio)
                                        addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                    else
                                    {
                                        _worksheet.Cells[_lastRow, 0] = new Cell("");
                                        _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                        _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                        _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                        _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                        _worksheet.Cells[_lastRow, 5] = new Cell("");
                                        _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                        _worksheet.Cells[_lastRow, 7] = new Cell("");
                                        _worksheet.Cells[_lastRow, 8] = new Cell("");
                                        _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                    }
                                    _lastRow++;
                                }

                            }
                            else { }
                        }
                    }
                }
                else { }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            results = null;
            query = @"
DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)

SELECT 
    cpp.idContasAReceberPagamento,
    cpp.idContasAReceber,
    cpp.dataMovimento,
    cpp.valorPrincipal,
    cpp.valorMulta,
    cpp.valorJuros,
    cpp.valorDesconto,
    cpp.valorCM,
    cpp.idContaPagamento,
    cpp.idDocumentoRecebimento,
    cpp.idTipoMovimentoContabil,
    cpp.valorINSSRetido,
    cpp.valorISSRetido,
    cpp.valorIRRetido,
    cpp.valorPISRetido,
    cpp.valorCOFINSRetido,
    cpp.valorCSLLRetido,
    cp.idContasAReceber,
    cp.dataLancamento,
    cp.dataVencimento,
    cp.descricao,
    cp.valor,
    cp.iss,
    cp.desconto,
    cp.idEmpresa,
    cp.idTipoMovimentoContabil,
    cp.valorRecebido,
    cp.dataUltimoRecebimento,
    cp.emAberto,
    cp.idEmpresaRelacionamento,
    cp.parcela,
    cp.numeroDocumento,
    cp.dataLancamentoEfetivo,
    cp.dataCancelamento,
    cpi.idContasAReceberItem,
	cpi.idContasAReceber,
	cpi.idMovimento,
	cpi.idMovimentoManual,
	cpi.descricao,
	cpi.valor,
	cpi.aliquotaIss,
	cpi.valorIss,
	cpi.aliquotaIcms,
	cpi.valorIcms,
	cpi.valorDesconto,
	cpi.idNaturezaOperacao,
	cpi.idDepartamento,
	cpi.valorMulta,
	cpi.valorJuros,
	cpi.valorCm,
    eccr.*,
    ecsr.*,
    ecer.*,
    eccp.*,
    naturezaOperacao.idNaturezaOperacao,
    naturezaOperacao.idEmpresa,
    naturezaOperacao.descricao,
    naturezaOperacao.codigoContabilReduzido,
    naturezaOperacao.pagarReceber,
    departamento.idDepartamento,
    departamento.idEmpresa,
    departamento.descricao,
    departamento.alcada,
    departamento.armazem,
    departamento.idDepartamentoPai,
    departamento.idPlanoContas,
    empresaRelacionamento.idEmpresaRelacionamento,
empresaRelacionamento.idTipoRelacionamentoEmpresa,
empresaRelacionamento.idEmpresa,
empresaRelacionamento.idPessoaRelacionamento,
empresaRelacionamento.idPessoaRelacionadaEmpresa,
empresaRelacionamento.dataInicio,
empresaRelacionamento.dataTermino,
empresaRelacionamento.codigoExportacao,
empresaRelacionamento.dadosBancarios,
    pessoa.idPessoa,
pessoa.pfpj,
pessoa.cpfCnpj,
pessoa.nomeRazaoSocial,
pessoa.apelidoNomeComercial,
    contaPagamento.idContaPagamento,
    contaPagamento.idEmpresa,
    contaPagamento.descricao,
    contaPagamento.idBanco,
    contaPagamento.numeroConta,
    contaPagamento.tipoConta,
    contaPagamento.idUsuario,
    contaPagamento.idPlanoContas,
    contaPagamento.saldoAtual,
    contaPagamento.recebimentoVinculado,
    contaPagamento.pagamentoVinculado,
    contaPagamento.numeroChequeInicial,
    contaPagamento.numeroChequeFinal,
    contaPagamento.idFormaPagamento,
    contaPagamento.codigoExportacao,
    documentoRecebimento.idDocumentoRecebimento,
documentoRecebimento.idEmpresa,
documentoRecebimento.idContaPagamento,
documentoRecebimento.dataMovimento,
documentoRecebimento.descricao,
documentoRecebimento.numeroDocumento,
documentoRecebimento.valorRecebido,
documentoRecebimento.dataGeracao,
documentoRecebimento.dataVencimento,
documentoRecebimento.dataCancelamento,
    cpp.valorPrincipal + IsNull(cpp.valorMulta, 0) + IsNull(cpp.valorJuros, 0) - IsNull(cpp.valorDesconto, 0) + IsNull(cpp.valorCM, 0) - IsNull(cpp.valorINSSRetido, 0) - IsNull(cpp.valorISSRetido, 0) - IsNull(cpp.valorIRRetido, 0) - IsNull(cpp.valorPISRetido, 0) - IsNull(cpp.valorCOFINSRetido, 0) - IsNull(cpp.valorCSLLRetido, 0),
	CAST
	(
		(
			(
				(cpp.valorPrincipal + IsNull(cpp.valorMulta, 0) + IsNull(cpp.valorJuros, 0) - IsNull(cpp.valorDesconto, 0) + IsNull(cpp.valorCM, 0) - IsNull(cpp.valorINSSRetido, 0) - IsNull(cpp.valorISSRetido, 0) - IsNull(cpp.valorIRRetido, 0) - IsNull(cpp.valorPISRetido, 0) - IsNull(cpp.valorCOFINSRetido, 0) - IsNull(cpp.valorCSLLRetido, 0))
				/
				(cp.valor - cp.desconto - cp.iss)
			) * cpi.valor
		)
	AS DECIMAL(15, 2))
FROM contasAreceberPagamento cpp
INNER JOIN contasAreceber cp ON cpp.idContasAreceber = cp.idContasAreceber
INNER JOIN contasAreceberItem cpi ON cpi.idContasAreceber = cp.idContasAreceber
LEFT JOIN exportacaoContabil eccr 
	ON eccr.idNaturezaOperacao = cpi.idNaturezaOperacao AND eccr.idDepartamento = cpi.idDepartamento
LEFT JOIN exportacaoContabil ecsr 
	ON ecsr.idNaturezaOperacao = cpi.idNaturezaOperacao AND ecsr.idDepartamento IS NULL
LEFT JOIN exportacaoContabil ecer
	on ecer.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT  join exportacaoContabil eccp 
	on eccp.idContaPagamento = cpp.idContaPagamento
LEFT JOIN naturezaOperacao on naturezaOperacao.idNaturezaOperacao = cpi.idNaturezaOperacao
LEFT JOIN departamento on departamento.iddepartamento = cpi.iddepartamento
LEFT JOIN empresaRelacionamento on empresaRelacionamento.idEmpresaRelacionamento = cp.idEmpresaRelacionamento
LEFT JOIN pessoa ON pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
LEFT JOIN contaPagamento
	ON contaPagamento.idContaPagamento = cpp.idContaPagamento
LEFT JOIN documentoRecebimento
	ON documentoRecebimento.idDocumentoRecebimento = cpp.idDocumentoRecebimento
WHERE 
	CAST(cpp.dataMovimento AS DATE) BETWEEN @dataInicial and @dataFinal

ORDER BY cpp.idContasAreceberPagamento";

            try
            {

                _idItemsProcessados = null;
                _idItemsProcessados = new List<int>();

                results = Utils.Utils.em.executeData(query, null);
                if (results != null)
                {
                    foreach (DataRow item in results.Rows)
                    {

                        bool
                            provisionar = false,
                            naturezaDepartamento = false;
                        string
                            debito = "",
                            credito = "",
                            data = "",
                            valor = "",
                            complemento = "",
                            nroDocumento = "",
                            codigoContabilNatureza = "";

                        if (!String.IsNullOrEmpty(item[66].ToString())) /* Existe linha pro empresa relacionamento */
                        {
                            /* Conta*/
                            if (String.IsNullOrEmpty(item[74].ToString()))
                            {
                                url = "/pagina/financeiro/receber/contasAReceberEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAReceber=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/receber/contasAReceber");
                                link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a receber <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a conta de pagamento <b>" + item[110].ToString() + "</b>.");
                            }
                            else
                            {

                                /* Possui natureza de operação e departamento */
                                if (!String.IsNullOrEmpty(item[50].ToString()))
                                {
                                    provisionar = item[55].ToString() == "s";
                                    codigoContabilNatureza = item[57].ToString();
                                    naturezaDepartamento = true;
                                }
                                else if (!String.IsNullOrEmpty(item[59].ToString()))
                                {
                                    provisionar = item[63].ToString() == "s";
                                    codigoContabilNatureza = item[65].ToString();
                                    naturezaDepartamento = true;
                                }

                                if (!naturezaDepartamento)
                                {
                                    url = "/pagina/financeiro/receber/contasAReceberEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAReceber=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/receber/contasAReceber");
                                    link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                    addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a receber <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a natureza de operação <b>" + item[84].ToString() + "</b> nem para o departamento <b>" + item[89].ToString() + "</b>.");
                                }
                                else
                                {
                                    if (provisionar)
                                    {
                                        int idItem = Convert.ToInt32(item[0].ToString());
                                        if (_idItemsProcessados.FirstOrDefault(T => T == idItem) <= 0)
                                        {
                                            _idItemsProcessados.Add(idItem);
                                            debito = item[81].ToString(); /* Conta Pagamento */
                                            credito = item[73].ToString(); /* Empresa Relaconamento */
                                            data = Convert.ToDateTime(item[2].ToString()).ToString("dd/MM/yyyy");
                                            valor = item[133].ToString(); /* Valor não rateado */
                                            complemento = item[127].ToString().Trim();
                                            nroDocumento = item[128].ToString();

                                            if (exportDominio)
                                                addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                            else
                                            {
                                                _worksheet.Cells[_lastRow, 0] = new Cell("");
                                                _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                                _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                                _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                                _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                                _worksheet.Cells[_lastRow, 5] = new Cell("");
                                                _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                                _worksheet.Cells[_lastRow, 7] = new Cell("");
                                                _worksheet.Cells[_lastRow, 8] = new Cell("");
                                                _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                            }
                                            _lastRow++;
                                        }
                                        else { }
                                    }
                                    else
                                    {
                                        debito = item[81].ToString(); /* Conta Pagamento */
                                        credito = codigoContabilNatureza; /* Natureza */
                                        data = Convert.ToDateTime(item[2].ToString()).ToString("dd/MM/yyyy");
                                        valor = item[134].ToString(); /* Valor rateado */
                                        complemento = item[127].ToString().Trim();
                                        nroDocumento = item[128].ToString();

                                        if (exportDominio)
                                            addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                        else
                                        {
                                            _worksheet.Cells[_lastRow, 0] = new Cell("");
                                            _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                            _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                            _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                            _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                            _worksheet.Cells[_lastRow, 5] = new Cell("");
                                            _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                            _worksheet.Cells[_lastRow, 7] = new Cell("");
                                            _worksheet.Cells[_lastRow, 8] = new Cell("");
                                            _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                        }
                                        _lastRow++;

                                    }
                                }
                            }
                        }
                        else
                        {
                            /* Não possui empresa relacionamento e não possui conta */
                            if (String.IsNullOrEmpty(item[74].ToString()))
                            {
                                url = "/pagina/financeiro/receber/contasAReceberEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAReceber=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/receber/contasAReceber");
                                link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                                addErro("Erro ao exportar o item " + item[0].ToString() + " do contas a receber <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a conta de pagamento <b>" + item[110].ToString() + "</b>.");
                            }
                            else
                            {
                                /* Possui natureza de operação e departamento */
                                if (!String.IsNullOrEmpty(item[50].ToString()))
                                {
                                    provisionar = false;
                                    codigoContabilNatureza = item[57].ToString();
                                    naturezaDepartamento = true;
                                }
                                else if (!String.IsNullOrEmpty(item[58].ToString()))
                                {
                                    provisionar = false;
                                    codigoContabilNatureza = item[65].ToString();
                                    naturezaDepartamento = true;
                                }

                                debito = item[81].ToString(); /* Conta Pagamento */
                                credito = codigoContabilNatureza; /* Natureza */
                                data = Convert.ToDateTime(item[2].ToString()).ToString("dd/MM/yyyy");
                                valor = item[134].ToString(); /* Valor rateado */
                                complemento = item[127].ToString();
                                nroDocumento = item[128].ToString();

                                if (exportDominio)
                                    addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                else
                                {
                                    _worksheet.Cells[_lastRow, 0] = new Cell("");
                                    _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                    _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                    _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                    _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                    _worksheet.Cells[_lastRow, 5] = new Cell("");
                                    _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                    _worksheet.Cells[_lastRow, 7] = new Cell("");
                                    _worksheet.Cells[_lastRow, 8] = new Cell("");
                                    _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                }
                                _lastRow++;
                            }
                        }

                    } /* For */
                }
                else { }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private static void getLancamentosTransferencia()
        {

            string query = @" DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)

SELECT 
    documentoTransferencia.idDocumentoTransferencia,
documentoTransferencia.idEmpresa,
documentoTransferencia.idContaPagamentoOrigem,
documentoTransferencia.idContaPagamentoDestino,
documentoTransferencia.dataMovimento,
documentoTransferencia.descricao,
documentoTransferencia.numeroDocumento,
documentoTransferencia.valorTransferido,
documentoTransferencia.dataGeracao, 
    contaPagamentoOrigem.idcontaPagamento,
    contaPagamentoOrigem.idEmpresa,
    contaPagamentoOrigem.descricao,
    contaPagamentoOrigem.idBanco,
    contaPagamentoOrigem.numeroConta,
    contaPagamentoOrigem.tipoConta,
    contaPagamentoOrigem.idUsuario,
    contaPagamentoOrigem.idPlanoContas,
    contaPagamentoOrigem.saldoAtual,
    contaPagamentoOrigem.recebimentoVinculado,
    contaPagamentoOrigem.pagamentoVinculado,
    contaPagamentoOrigem.numeroChequeInicial,
    contaPagamentoOrigem.numeroChequeFinal,
    contaPagamentoOrigem.idFormaPagamento,
    contaPagamentoOrigem.codigoExportacao,
    contaPagamentoDestino.idcontaPagamento,
    contaPagamentoDestino.idEmpresa,
    contaPagamentoDestino.descricao,
    contaPagamentoDestino.idBanco,
    contaPagamentoDestino.numeroConta,
    contaPagamentoDestino.tipoConta,
    contaPagamentoDestino.idUsuario,
    contaPagamentoDestino.idPlanoContas,
    contaPagamentoDestino.saldoAtual,
    contaPagamentoDestino.recebimentoVinculado,
    contaPagamentoDestino.pagamentoVinculado,
    contaPagamentoDestino.numeroChequeInicial,
    contaPagamentoDestino.numeroChequeFinal,
    contaPagamentoDestino.idFormaPagamento,
    contaPagamentoDestino.codigoExportacao,
exportacaoContabilOrigem.*,
exportacaoContabilDestino.*
FROM documentoTransferencia
INNER JOIN contaPagamento contaPagamentoOrigem
	on contaPagamentoOrigem.idContaPagamento = documentoTransferencia.idContaPagamentoOrigem
INNER JOIN contaPagamento contaPagamentoDestino
	on contaPagamentoDestino.idContaPagamento = documentoTransferencia.idContaPagamentoDestino
LEFT JOIN exportacaoContabil exportacaoContabilOrigem
	on exportacaoContabilOrigem.idContaPagamento = contaPagamentoOrigem.idContaPagamento
LEFT JOIN exportacaoContabil exportacaoContabilDestino
	on exportacaoContabilDestino.idContaPagamento = contaPagamentoDestino.idContaPagamento
WHERE 
	CAST(documentoTransferencia.dataMovimento AS DATE) BETWEEN @dataInicial and @dataFinal";

            DataTable results = Utils.Utils.em.executeData(query, null);
            try
            {
                if (results != null)
                {


                    string
                        debito = "",
                        credito = "",
                        data = "",
                        valor = "",
                        complemento = "",
                        nroDocumento = "";

                    foreach (DataRow item in results.Rows)
                    {

                        bool
                            codigoExportacaoOrigem = false,
                            codigoExportacaoDestino = false;


                        codigoExportacaoOrigem = !String.IsNullOrEmpty(item[46].ToString());
                        codigoExportacaoDestino = !String.IsNullOrEmpty(item[54].ToString());

                        if (!codigoExportacaoOrigem || !codigoExportacaoDestino)
                        {
                            url = "/pagina/financeiro/documentoTransferenciaEA.aspx?scriptOpenWindowManual=1&allowSave=true&idDocumentoTransferencia=" + item[0].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/documentoTransferenciaEA");
                            link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));

                            if (!codigoExportacaoOrigem)
                                addErro("Erro ao exportar o documento de transferência <a href=\"" + link + "\" target=\"_blank\">" + item[0].ToString() + "</a>. Não existe código contábil para a conta de pagamento de origem <b>" + item[11].ToString() + "</b>.");
                            else { }

                            if (!codigoExportacaoDestino)
                                addErro("Erro ao exportar o documento de transferência <a href=\"" + link + "\" target=\"_blank\">" + item[0].ToString() + "</a>. Não existe código contábil para a conta de pagamento de destino <b>" + item[26].ToString() + "</b>.");
                            else { }
                        }
                        else { }

                        if (codigoExportacaoDestino && codigoExportacaoOrigem)
                        {

                            debito = item[54].ToString();
                            credito = item[46].ToString();
                            data = Convert.ToDateTime(item[4].ToString()).ToString("dd/MM/yyyy");
                            valor = item[7].ToString();
                            complemento = item[5].ToString();
                            nroDocumento = item[6].ToString();

                            if (exportDominio)
                                addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                            else
                            {
                                _worksheet.Cells[_lastRow, 0] = new Cell("");
                                _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                _worksheet.Cells[_lastRow, 5] = new Cell("");
                                _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                _worksheet.Cells[_lastRow, 7] = new Cell("");
                                _worksheet.Cells[_lastRow, 8] = new Cell("");
                                _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                            }
                            _lastRow++;
                        }
                        else { }
                    }
                }
                else { }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static void getDeducoesPagamento()
        {
            string query = @" DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)
	
SELECT 
	contasAPagarPagamento.idContasAPagarPagamento,
	contasAPagarPagamento.idContasAPagar,
	contasAPagar.idEmpresaRelacionamento,
	contasAPagar.numeroDocumento,
	contasAPagarPagamento.dataMovimento,
	contasAPagarPagamento.valorMulta,
	contasAPagarPagamento.valorJuros,
	contasAPagarPagamento.valorDesconto,
	contasAPagarPagamento.valorCM,
	contasAPagarPagamento.valorINSSRetido,
	contasAPagarPagamento.valorISSRetido,
	contasAPagarPagamento.valorIRRetido,
	contasAPagarPagamento.valorPISRetido,
	contasAPagarPagamento.valorCOFINSRetido,
	contasAPagarPagamento.valorCSLLRetido,
	ecer.idExportacaoContabil,
	ecer.idEmpresaRelacionamento,
	ecer.codigoContabil,
	pessoa.nomeRazaoSocial
FROM contasAPagarPagamento
INNER JOIN contasAPagar ON contasAPagar.idContasAPagar = contasAPagarPagamento.idContasAPagar
LEFT JOIN exportacaoContabil ecer ON ecer.idEmpresaRelacionamento = contasAPagar.idEmpresaRelacionamento
INNER JOIN empresaRelacionamento er ON er.idEmpresaRelacionamento = contasAPagar.idEmpresaRelacionamento
INNER JOIN pessoa ON pessoa.idPessoa = er.idPessoaRelacionamento
WHERE
	CAST(contasAPagarPagamento.dataMovimento AS DATE) BETWEEN @dataInicial AND @dataFinal AND
	(
		IsNull(contasAPagarPagamento.valorMulta, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorJuros, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorDesconto, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorCM, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorINSSRetido, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorISSRetido, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorIRRetido, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorPISRetido, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorCOFINSRetido, 0) > 0 OR
		IsNull(contasAPagarPagamento.valorCSLLRetido, 0) > 0 
	)

ORDER BY contasAPagarPagamento.dataMovimento";
            DataTable results = Utils.Utils.em.executeData(query, null);
            try
            {
                if (results != null)
                {

                    string
                        debito = "",
                        credito = "",
                        data = "",
                        valor = "",
                        complemento = "",
                        nroDocumento = "";

                    deducoesPagamento = null;
                    deducoesPagamento = new List<Deducao>();

                    foreach (DataRow item in results.Rows)
                    {

                        if (String.IsNullOrEmpty(item[15].ToString()))
                        {
                            url = "/pagina/financeiro/pagar/contasAPagarEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAPagar=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/pagar/contasAPagar");
                            link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                            addErro("Erro ao exportar a dedução do contas a pagar <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a pessoa <b>" + item[18].ToString() + "</b>.");
                        }
                        else
                        {
                            Double
                                valorMulta = Utils.Utils.ToDouble(item[5].ToString()),
                                valorJuros = Utils.Utils.ToDouble(item[6].ToString()),
                                valorDesconto = Utils.Utils.ToDouble(item[7].ToString()),
                                valorCM = Utils.Utils.ToDouble(item[8].ToString()),
                                valorINSSRetido = Utils.Utils.ToDouble(item[9].ToString()),
                                valorISSRetido = Utils.Utils.ToDouble(item[10].ToString()),
                                valorIRRetido = Utils.Utils.ToDouble(item[11].ToString()),
                                valorPISRetido = Utils.Utils.ToDouble(item[12].ToString()),
                                valorCOFINSRetido = Utils.Utils.ToDouble(item[13].ToString()),
                                valorCSLLRetido = Utils.Utils.ToDouble(item[14].ToString());

                            Deducao
                                deducaoValorDesconto = null,
                                deducaoValorCM = null,
                                deducaoValorINSSRetido = null,
                                deducaoValorISSRetido = null,
                                deducaoValorIRRetido = null,
                                deducaoValorPISRetido = null,
                                deducaoValorCOFINSRetido = null,
                                deducaoValorCSLLRetido = null,
                                deducaoValorMulta = null,
                                deducaoValorJuros = null;

                            DateTime
                                dataMovimento = Convert.ToDateTime(item[4].ToString());

                            String
                                numeroDocumento = item[3].ToString().Trim(),
                                codigoExportacaoEmpresaRelacionamento = item[17].ToString();

                            int
                                idContasAPagar = Utils.Utils.ToInt(item[1].ToString());


                            if (valorDesconto > 0)
                            {
                                try
                                {
                                    deducaoValorDesconto = deducoesPagamento.Where(X => X.tipo == "descontoP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorDesconto = new Deducao { tipo = "descontoP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorDesconto);
                                }

                                deducaoValorDesconto.valor += valorDesconto;
                            }
                            else { }

                            if (valorCM > 0)
                            {
                                try
                                {
                                    deducaoValorCM = deducoesPagamento.Where(X => X.tipo == "cmP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];

                                }
                                catch
                                {
                                    deducaoValorCM = new Deducao { tipo = "cmP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorCM);
                                }
                                deducaoValorCM.valor += valorCM;
                            }
                            else { }

                            if (valorINSSRetido > 0)
                            {
                                try
                                {
                                    deducaoValorINSSRetido = deducoesPagamento.Where(X => X.tipo == "inssP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorINSSRetido = new Deducao { tipo = "inssP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorINSSRetido);
                                }
                                deducaoValorINSSRetido.valor += valorINSSRetido;
                            }
                            else { }

                            if (valorISSRetido > 0)
                            {
                                try
                                {
                                    deducaoValorISSRetido = deducoesPagamento.Where(X => X.tipo == "issP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorISSRetido = new Deducao { tipo = "issP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorISSRetido);
                                }
                                deducaoValorISSRetido.valor += valorISSRetido;
                            }
                            else { }

                            if (valorIRRetido > 0)
                            {
                                try
                                {
                                    deducaoValorIRRetido = deducoesPagamento.Where(X => X.tipo == "irP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorIRRetido = new Deducao { tipo = "irP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorIRRetido);
                                }
                                deducaoValorIRRetido.valor += valorIRRetido;
                            }
                            else { }

                            if (valorPISRetido > 0)
                            {
                                try
                                {
                                    deducaoValorPISRetido = deducoesPagamento.Where(X => X.tipo == "pisP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorPISRetido = new Deducao { tipo = "pisP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorPISRetido);
                                }
                                deducaoValorPISRetido.valor += valorPISRetido;
                            }
                            else { }

                            if (valorCOFINSRetido > 0)
                            {
                                try
                                {
                                    deducaoValorCOFINSRetido = deducoesPagamento.Where(X => X.tipo == "cofinsP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorCOFINSRetido = new Deducao { tipo = "cofinsP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorCOFINSRetido);
                                }
                                deducaoValorCOFINSRetido.valor += valorCOFINSRetido;
                            }
                            else { }

                            if (valorCSLLRetido > 0)
                            {
                                try
                                {
                                    deducaoValorCSLLRetido = deducoesPagamento.Where(X => X.tipo == "csllP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorCSLLRetido = new Deducao { tipo = "csllP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorCSLLRetido);
                                }
                                deducaoValorCSLLRetido.valor += valorCSLLRetido;
                            }
                            else { }

                            if (valorMulta > 0)
                            {
                                try
                                {
                                    deducaoValorMulta = deducoesPagamento.Where(X => X.tipo == "multaP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorMulta = new Deducao { tipo = "multaP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorMulta);
                                }

                                deducaoValorMulta.valor += valorMulta;
                            }
                            else { }

                            if (valorJuros > 0)
                            {
                                try
                                {
                                    deducaoValorJuros = deducoesPagamento.Where(X => X.tipo == "jurosP" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAPagar).ToList()[0];

                                }
                                catch
                                {
                                    deducaoValorJuros = new Deducao { tipo = "jurosP", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAPagar };
                                    deducoesPagamento.Add(deducaoValorJuros);
                                }
                                deducaoValorJuros.valor += valorJuros;
                            }
                            else { }

                        }
                    }

                    if (errorCount == 0)
                    {
                        string
                            nomeRetencao = "";

                        foreach (Deducao item in deducoesPagamento)
                        {
                            if (item.valor > 0)
                            {
                                Data.ExportacaoContabil keyRetencao = new Data.ExportacaoContabil
                                {
                                    tipoRetencao = item.tipo
                                };
                                try
                                {
                                    keyRetencao = (Data.ExportacaoContabil)Utils.Utils.listaDados(0, keyRetencao, 1)[0];
                                }
                                catch
                                {
                                    keyRetencao = null;
                                }

                                if (keyRetencao != null && keyRetencao.idExportacaoContabil > 0)
                                {

                                    switch (keyRetencao.tipoRetencao)
                                    {
                                        case "descontoP": nomeRetencao = "Descontos"; break;
                                        case "cmP": nomeRetencao = "Correção Monetária"; break;
                                        case "inssP": nomeRetencao = "INSS"; break;
                                        case "issP": nomeRetencao = "ISS"; break;
                                        case "irP": nomeRetencao = "Imposto de Renda"; break;
                                        case "pisP": nomeRetencao = "PIS"; break;
                                        case "cofinsP": nomeRetencao = "COFINS"; break;
                                        case "csllP": nomeRetencao = "CSLL"; break;
                                        case "multaP": nomeRetencao = "Multas"; break;
                                        case "jurosP": nomeRetencao = "Juros"; break;
                                    }

                                    debito = (keyRetencao.tipoRetencao == "multaP" || keyRetencao.tipoRetencao == "jurosP") ? keyRetencao.codigoContabil : item.codigoExportacaoEmpresaRelacionamento;
                                    credito = (keyRetencao.tipoRetencao == "multaP" || keyRetencao.tipoRetencao == "jurosP") ? item.codigoExportacaoEmpresaRelacionamento : keyRetencao.codigoContabil;
                                    data = item.dataMovimento.ToString("dd/MM/yyyy");
                                    valor = item.valor.ToString("n2");
                                    complemento = nomeRetencao;
                                    nroDocumento = item.numeroDocumento;

                                    if (exportDominio)
                                        addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                    else
                                    {
                                        _worksheet.Cells[_lastRow, 0] = new Cell("");
                                        _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                        _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                        _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                        _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                        _worksheet.Cells[_lastRow, 5] = new Cell("");
                                        _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                        _worksheet.Cells[_lastRow, 7] = new Cell("");
                                        _worksheet.Cells[_lastRow, 8] = new Cell("");
                                        _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                    }
                                    _lastRow++;
                                }
                                else { }
                            }
                            else { }
                        }
                    }
                    else { }
                }
                else { }
            }
            catch { }
        }

        private static void getDeducoesRecebimento()
        {
            string query = @" DECLARE
	@dataInicial DATE = CAST('" + dataInicial + @"' AS DATE),
	@dataFinal DATE = CAST('" + dataFinal + @"' AS DATE)
	
SELECT 
	contasAReceberPagamento.idContasAReceberPagamento,
	contasAReceberPagamento.idContasAReceber,
	contasAReceber.idEmpresaRelacionamento,
	contasAReceber.numeroDocumento,
	contasAReceberPagamento.dataMovimento,
	contasAReceberPagamento.valorMulta,
	contasAReceberPagamento.valorJuros,
	contasAReceberPagamento.valorDesconto,
	contasAReceberPagamento.valorCM,
	contasAReceberPagamento.valorINSSRetido,
	contasAReceberPagamento.valorISSRetido,
	contasAReceberPagamento.valorIRRetido,
	contasAReceberPagamento.valorPISRetido,
	contasAReceberPagamento.valorCOFINSRetido,
	contasAReceberPagamento.valorCSLLRetido,
	ecer.idExportacaoContabil,
	ecer.idEmpresaRelacionamento,
	ecer.codigoContabil,
	pessoa.nomeRazaoSocial
FROM contasAReceberPagamento
INNER JOIN contasAReceber ON contasAReceber.idContasAReceber = contasAReceberPagamento.idContasAReceber
LEFT JOIN exportacaoContabil ecer ON ecer.idEmpresaRelacionamento = contasAReceber.idEmpresaRelacionamento
INNER JOIN empresaRelacionamento er ON er.idEmpresaRelacionamento = contasAReceber.idEmpresaRelacionamento
INNER JOIN pessoa ON pessoa.idPessoa = er.idPessoaRelacionamento
WHERE
	CAST(contasAReceberPagamento.dataMovimento AS DATE) BETWEEN @dataInicial AND @dataFinal AND
	(
		IsNull(contasAReceberPagamento.valorMulta, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorJuros, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorDesconto, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorCM, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorINSSRetido, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorISSRetido, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorIRRetido, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorPISRetido, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorCOFINSRetido, 0) > 0 OR
		IsNull(contasAReceberPagamento.valorCSLLRetido, 0) > 0 
	)

ORDER BY contasAReceberPagamento.dataMovimento";
            DataTable results = Utils.Utils.em.executeData(query, null);
            try
            {
                if (results != null)
                {

                    string
                        debito = "",
                        credito = "",
                        data = "",
                        valor = "",
                        complemento = "",
                        nroDocumento = "";

                    deducoesRecebimento = null;
                    deducoesRecebimento = new List<Deducao>();

                    foreach (DataRow item in results.Rows)
                    {

                        if (String.IsNullOrEmpty(item[15].ToString()))
                        {
                            url = "/pagina/financeiro/receber/contasAReceberEA.aspx?scriptOpenWindowManual=1&allowSave=true&idContasAReceber=" + item[1].ToString() + "&idMenu=" + Utils.Utils.getIdMenu("/pagina/financeiro/receber/contasAReceber");
                            link = Utils.Utils.ResolveUrl("~/Default.aspx?openWindowManual=true&redirect=" + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Utils.Security.EncryptRijndael(url, Utils.Security.getInputKey()))));
                            addErro("Erro ao exportar a dedução do contas a receber <a href=\"" + link + "\" target=\"_blank\">" + item[1].ToString() + "</a>. Não existe código contábil para a pessoa <b>" + item[18].ToString() + "</b>.");
                        }
                        else
                        {
                            Double
                                valorMulta = Utils.Utils.ToDouble(item[5].ToString()),
                                valorJuros = Utils.Utils.ToDouble(item[6].ToString()),
                                valorDesconto = Utils.Utils.ToDouble(item[7].ToString()),
                                valorCM = Utils.Utils.ToDouble(item[8].ToString()),
                                valorINSSRetido = Utils.Utils.ToDouble(item[9].ToString()),
                                valorISSRetido = Utils.Utils.ToDouble(item[10].ToString()),
                                valorIRRetido = Utils.Utils.ToDouble(item[11].ToString()),
                                valorPISRetido = Utils.Utils.ToDouble(item[12].ToString()),
                                valorCOFINSRetido = Utils.Utils.ToDouble(item[13].ToString()),
                                valorCSLLRetido = Utils.Utils.ToDouble(item[14].ToString());

                            Deducao
                                deducaoValorDesconto = null,
                                deducaoValorCM = null,
                                deducaoValorINSSRetido = null,
                                deducaoValorISSRetido = null,
                                deducaoValorIRRetido = null,
                                deducaoValorPISRetido = null,
                                deducaoValorCOFINSRetido = null,
                                deducaoValorCSLLRetido = null,
                                deducaoValorMulta = null,
                                deducaoValorJuros = null;

                            DateTime
                                dataMovimento = Convert.ToDateTime(item[4].ToString());

                            String
                                numeroDocumento = item[3].ToString().Trim(),
                                codigoExportacaoEmpresaRelacionamento = item[17].ToString();

                            int
                                idContasAReceber = Utils.Utils.ToInt(item[1].ToString());


                            if (valorDesconto > 0)
                            {
                                try
                                {
                                    deducaoValorDesconto = deducoesRecebimento.Where(X => X.tipo == "descontoR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorDesconto = new Deducao { tipo = "descontoR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorDesconto);
                                }

                                deducaoValorDesconto.valor += valorDesconto;
                            }
                            else { }

                            if (valorCM > 0)
                            {
                                try
                                {
                                    deducaoValorCM = deducoesRecebimento.Where(X => X.tipo == "cmR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];

                                }
                                catch
                                {
                                    deducaoValorCM = new Deducao { tipo = "cmR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorCM);
                                }
                                deducaoValorCM.valor += valorCM;
                            }
                            else { }

                            if (valorINSSRetido > 0)
                            {
                                try
                                {
                                    deducaoValorINSSRetido = deducoesRecebimento.Where(X => X.tipo == "inssR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorINSSRetido = new Deducao { tipo = "inssR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorINSSRetido);
                                }
                                deducaoValorINSSRetido.valor += valorINSSRetido;
                            }
                            else { }

                            if (valorISSRetido > 0)
                            {
                                try
                                {
                                    deducaoValorISSRetido = deducoesRecebimento.Where(X => X.tipo == "issR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorISSRetido = new Deducao { tipo = "issR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorISSRetido);
                                }
                                deducaoValorISSRetido.valor += valorISSRetido;
                            }
                            else { }

                            if (valorIRRetido > 0)
                            {
                                try
                                {
                                    deducaoValorIRRetido = deducoesRecebimento.Where(X => X.tipo == "irR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorIRRetido = new Deducao { tipo = "irR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorIRRetido);
                                }
                                deducaoValorIRRetido.valor += valorIRRetido;
                            }
                            else { }

                            if (valorPISRetido > 0)
                            {
                                try
                                {
                                    deducaoValorPISRetido = deducoesRecebimento.Where(X => X.tipo == "pisR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorPISRetido = new Deducao { tipo = "pisR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorPISRetido);
                                }
                                deducaoValorPISRetido.valor += valorPISRetido;
                            }
                            else { }

                            if (valorCOFINSRetido > 0)
                            {
                                try
                                {
                                    deducaoValorCOFINSRetido = deducoesRecebimento.Where(X => X.tipo == "cofinsR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorCOFINSRetido = new Deducao { tipo = "cofinsR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorCOFINSRetido);
                                }
                                deducaoValorCOFINSRetido.valor += valorCOFINSRetido;
                            }
                            else { }

                            if (valorCSLLRetido > 0)
                            {
                                try
                                {
                                    deducaoValorCSLLRetido = deducoesRecebimento.Where(X => X.tipo == "csllR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorCSLLRetido = new Deducao { tipo = "csllR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorCSLLRetido);
                                }
                                deducaoValorCSLLRetido.valor += valorCSLLRetido;
                            }
                            else { }

                            if (valorMulta > 0)
                            {
                                try
                                {
                                    deducaoValorMulta = deducoesRecebimento.Where(X => X.tipo == "multaR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];
                                }
                                catch
                                {
                                    deducaoValorMulta = new Deducao { tipo = "multaR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorMulta);
                                }

                                deducaoValorMulta.valor += valorMulta;
                            }
                            else { }

                            if (valorJuros > 0)
                            {
                                try
                                {
                                    deducaoValorJuros = deducoesRecebimento.Where(X => X.tipo == "jurosR" && X.dataMovimento.ToString("yyyy-MM-dd") == dataMovimento.ToString("yyyy-MM-dd") && X.idContasAPagar == idContasAReceber).ToList()[0];

                                }
                                catch
                                {
                                    deducaoValorJuros = new Deducao { tipo = "jurosR", dataMovimento = dataMovimento, numeroDocumento = numeroDocumento, codigoExportacaoEmpresaRelacionamento = codigoExportacaoEmpresaRelacionamento, idContasAPagar = idContasAReceber };
                                    deducoesRecebimento.Add(deducaoValorJuros);
                                }
                                deducaoValorJuros.valor += valorJuros;
                            }
                            else { }

                        }
                    }

                    if (errorCount == 0)
                    {
                        string
                            nomeRetencao = "";

                        foreach (Deducao item in deducoesRecebimento)
                        {
                            if (item.valor > 0)
                            {
                                Data.ExportacaoContabil keyRetencao = new Data.ExportacaoContabil
                                {
                                    tipoRetencao = item.tipo
                                };
                                try
                                {
                                    keyRetencao = (Data.ExportacaoContabil)Utils.Utils.listaDados(0, keyRetencao, 1)[0];
                                }
                                catch
                                {
                                    keyRetencao = null;
                                }

                                if (keyRetencao != null && keyRetencao.idExportacaoContabil > 0)
                                {

                                    switch (keyRetencao.tipoRetencao)
                                    {
                                        case "descontoR": nomeRetencao = "Descontos"; break;
                                        case "cmR": nomeRetencao = "Correção Monetária"; break;
                                        case "inssR": nomeRetencao = "INSS"; break;
                                        case "issR": nomeRetencao = "ISS"; break;
                                        case "irR": nomeRetencao = "Imposto de Renda"; break;
                                        case "pisR": nomeRetencao = "PIS"; break;
                                        case "cofinsR": nomeRetencao = "COFINS"; break;
                                        case "csllR": nomeRetencao = "CSLL"; break;
                                        case "multaR": nomeRetencao = "Multas"; break;
                                        case "jurosR": nomeRetencao = "Juros"; break;
                                    }

                                    debito = (keyRetencao.tipoRetencao == "multaR" || keyRetencao.tipoRetencao == "jurosR") ? item.codigoExportacaoEmpresaRelacionamento : keyRetencao.codigoContabil;
                                    credito = (keyRetencao.tipoRetencao == "multaR" || keyRetencao.tipoRetencao == "jurosR") ? keyRetencao.codigoContabil : item.codigoExportacaoEmpresaRelacionamento;
                                    data = item.dataMovimento.ToString("dd/MM/yyyy");
                                    valor = item.valor.ToString("n2");
                                    complemento = nomeRetencao;
                                    nroDocumento = item.numeroDocumento;

                                    if (exportDominio)
                                        addLinhaExportDominio(Convert.ToDateTime(data), debito, credito, Convert.ToDouble(valor), complemento);
                                    else
                                    {
                                        _worksheet.Cells[_lastRow, 0] = new Cell("");
                                        _worksheet.Cells[_lastRow, 1] = new Cell(debito);
                                        _worksheet.Cells[_lastRow, 2] = new Cell(credito);
                                        _worksheet.Cells[_lastRow, 3] = new Cell(data);
                                        _worksheet.Cells[_lastRow, 4] = new Cell(Utils.Utils.ToDouble(valor));
                                        _worksheet.Cells[_lastRow, 5] = new Cell("");
                                        _worksheet.Cells[_lastRow, 6] = new Cell(complemento);
                                        _worksheet.Cells[_lastRow, 7] = new Cell("");
                                        _worksheet.Cells[_lastRow, 8] = new Cell("");
                                        _worksheet.Cells[_lastRow, 9] = new Cell(nroDocumento);
                                    }
                                    _lastRow++;
                                }
                                else { }
                            }
                            else { }
                        }
                    }
                    else { }
                }
                else { }
            }
            catch { }
        }


        private static bool existeItensDiferentes(int idContasAPagar, int idContasAPagarItem, bool provisiona, string tipo = "cp")
        {
            if (tipo == "cp")
            {

                string query = @"SELECT * FROM contasAPagarItem cpi
LEFT JOIN exportacaoContabil eccr 
	ON eccr.idNaturezaOperacao = cpi.idNaturezaOperacao AND eccr.idDepartamento = cpi.idDepartamento
LEFT JOIN exportacaoContabil ecsr 
	ON ecsr.idNaturezaOperacao = cpi.idNaturezaOperacao AND ecsr.idDepartamento IS NULL

WHERE cpi.idContasAPagar = " + idContasAPagar.ToString() + @" AND cpi.idContasAPagarItem <> " + idContasAPagarItem.ToString();

                DataTable result = Utils.Utils.em.executeData(query, null);
                if (result != null)
                {
                    if (result.Rows.Count == 0)
                        return false;
                    else { }

                    bool provisionar = false;

                    foreach (DataRow item in result.Rows)
                    {

                        if (String.IsNullOrEmpty(item[12].ToString()) && String.IsNullOrEmpty(item[20].ToString()))
                            return false;
                        else { }

                        if (!String.IsNullOrEmpty(item[12].ToString()) && String.IsNullOrEmpty(item[20].ToString()))
                        {
                            provisionar = item[17].ToString() == "s";
                        }
                        else if (!String.IsNullOrEmpty(item[20].ToString()) && String.IsNullOrEmpty(item[12].ToString()))
                        {
                            provisionar = item[25].ToString() == "s";
                        }

                        if (provisiona != provisionar)
                            return true;
                        else { }
                    }

                }
                else { }
            }
            else
            {
                string query = @"SELECT * FROM contasAReceberItem cpi
LEFT JOIN exportacaoContabil eccr 
	ON eccr.idNaturezaOperacao = cpi.idNaturezaOperacao AND eccr.idDepartamento = cpi.idDepartamento
LEFT JOIN exportacaoContabil ecsr 
	ON ecsr.idNaturezaOperacao = cpi.idNaturezaOperacao AND ecsr.idDepartamento IS NULL

WHERE cpi.idContasAReceber = " + idContasAPagar.ToString() + @" AND cpi.idContasAReceberItem <> " + idContasAPagarItem.ToString();

                DataTable result = Utils.Utils.em.executeData(query, null);
                if (result != null)
                {
                    if (result.Rows.Count == 0)
                        return false;
                    else { }

                    bool provisionar = false;

                    foreach (DataRow item in result.Rows)
                    {

                        if (String.IsNullOrEmpty(item[18].ToString()) && String.IsNullOrEmpty(item[27].ToString()))
                            return false;
                        else { }

                        if (!String.IsNullOrEmpty(item[18].ToString()) && String.IsNullOrEmpty(item[27].ToString()))
                        {
                            provisionar = item[23].ToString() == "s";
                        }
                        else if (!String.IsNullOrEmpty(item[27].ToString()) && String.IsNullOrEmpty(item[18].ToString()))
                        {
                            provisionar = item[32].ToString() == "s";
                        }

                        if (provisiona != provisionar)
                            return true;
                        else { }
                    }

                }
                else { }

            }

            return false;
        }
    }
}
