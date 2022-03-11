using System;
using Utils.Pagina.Attributes;
using System.Linq;
using System.Collections.Generic;
using Utils;

namespace Data
{
    //[Serializable]
    public class ProdutoServico : Base
    {
        public ProdutoServico() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdProdutoServico;
        public int idProdutoServico
        {
            get { return this.m_IdProdutoServico; }
            set { this.m_IdProdutoServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Código do Produto", 125),
            TFieldAttributeData(6, false),
            TFieldAttributeKey(false, false)
        ]
        private String m_CodigoProduto;
        public String codigoProduto
        {
            get { return this.m_CodigoProduto; }
            set { this.m_CodigoProduto = value; }
        }


        [
            TFieldAttributeGridDisplay("Descrição", 350),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private String m_Cest;
        public String cest
        {
            get { return this.m_Cest; }
            set { this.m_Cest = value; }
        }


        private string m_taxaServico;
        public string taxaServico
        {
            get { return this.m_taxaServico; }
            set { this.m_taxaServico = value; }
        }

        private String m_ExtIpi;
        public String extIpi
        {
            get { return this.m_ExtIpi; }
            set { this.m_ExtIpi = value; }
        }

        [
            TFieldAttributeGridDisplay("Saldo do produto", 119),
            TFieldAttributeData(50, true)
        ]
        private double m_Saldo;
        public double saldo
        {
            get { return this.m_Saldo; }
            set { this.m_Saldo = value; }
        }

        private bool m_Perecivel;
        public bool perecivel
        {
            get { return this.m_Perecivel; }
            set { this.m_Perecivel = value; }
        }

        private bool m_Estocavel;
        public bool estocavel
        {
            get { return this.m_Estocavel; }
            set { this.m_Estocavel = value; }
        }

        private UnidadeProdutoServico m_IdUnidadeProdutoServico;
        public UnidadeProdutoServico unidadeProdutoServico
        {
            get { return this.m_IdUnidadeProdutoServico; }
            set { this.m_IdUnidadeProdutoServico = value; }
        }

        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get { return this.m_IdDepartamento; }
            set { this.m_IdDepartamento = value; }
        }

        private Ncm m_IdNcm;
        public Ncm ncm
        {
            get { return this.m_IdNcm; }
            set { this.m_IdNcm = value; }
        }

        private String m_EAN;
        public String EAN
        {
            get { return this.m_EAN; }
            set { this.m_EAN = value; }
        }

        private String m_MarcaModelo;
        public String marcaModelo
        {
            get { return this.m_MarcaModelo; }
            set { this.m_MarcaModelo = value; }
        }

        private RegraContabilizacao m_IdRegraContabilizacao;
        public RegraContabilizacao regraContabilizacao
        {
            get { return this.m_IdRegraContabilizacao; }
            set { this.m_IdRegraContabilizacao = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        private PlanoContas m_IdPlanoContas;
        public PlanoContas planoContas
        {
            get { return this.m_IdPlanoContas; }
            set { this.m_IdPlanoContas = value; }
        }

        private ProdutoServicoEmpresa[] m_ProdutoServicoEmpresas;
        public ProdutoServicoEmpresa[] produtoServicoEmpresas
        {
            get { return this.m_ProdutoServicoEmpresas; }
            set { this.m_ProdutoServicoEmpresas = value; }
        }

        //idProdutoServico
        private ProdutoServicoComposicao[] m_ProdutoServicoComposicaos;
        public ProdutoServicoComposicao[] produtoServicoComposicaos
        {
            get { return this.m_ProdutoServicoComposicaos; }
            set { this.m_ProdutoServicoComposicaos = value; }
        }

        //idProdutoServico
        private ProdutoServicoEstoque[] m_ProdutoServicoEstoques;
        public ProdutoServicoEstoque[] produtoServicoEstoques
        {
            get { return this.m_ProdutoServicoEstoques; }
            set { this.m_ProdutoServicoEstoques = value; }
        }

        //idProdutoServico
        private ProdutoServicoFornecedor[] m_ProdutoServicoFornecedors;
        public ProdutoServicoFornecedor[] produtoServicoFornecedors
        {
            get { return this.m_ProdutoServicoFornecedors; }
            set { this.m_ProdutoServicoFornecedors = value; }
        }

        //idProdutoServico
        private ProdutoServicoUnidade[] m_ProdutoServicoUnidades;
        public ProdutoServicoUnidade[] produtoServicoUnidades
        {
            get { return this.m_ProdutoServicoUnidades; }
            set { this.m_ProdutoServicoUnidades = value; }
        }

        //idProdutoServico
        private ProdutoServicoPatrimonio[] m_ProdutoServicoPatrimonio;
        public ProdutoServicoPatrimonio[] produtoServicoPatrimonio
        {
            get { return this.m_ProdutoServicoPatrimonio; }
            set { this.m_ProdutoServicoPatrimonio = value; }
        }

        public override string ToString()
        {
            return this.m_IdProdutoServico.ToString();
        }

        private double m_ValorUltimaCompra;
        public double valorUltimaCompra
        {
            get
            {
                //if (this.m_ValorUltimaCompra == 0)
                //    this.m_ValorUltimaCompra = this.valorRateado();
                //else { }
                return this.m_ValorUltimaCompra;
            }
            set
            {
                this.m_ValorUltimaCompra = value;
            }
        }

        public static ProdutoServicoFornecedor atrelarEmpresa(int idFornecedor, int idProdutoServico)
        {

            ProdutoServicoFornecedor result = new ProdutoServicoFornecedor
            {
                idProdutoServico = idProdutoServico,
                fornecedor = new Fornecedor
                {
                    idEmpresaRelacionamento = idFornecedor
                }
            };

            ProdutoServicoFornecedor psf = null;
            try
            {
                psf = (ProdutoServicoFornecedor)Utils.Utils.listaDados(0, result, 1)[0];
                psf.operacao = ENum.eOperacao.NONE;
            }
            catch
            {
                psf = null;
                psf = new ProdutoServicoFornecedor
                {
                    operacao = ENum.eOperacao.INCLUIR,
                    fornecedor = new Fornecedor
                    {
                        idEmpresaRelacionamento = idFornecedor
                    },
                    idProdutoServico = idProdutoServico
                };
                psf = (ProdutoServicoFornecedor)Utils.Utils.sr(0).atualizar(psf);
            }


            return psf;
        }

        private NotaFiscalE getUltimaNotaEntrada()
        {

            if (this.m_IdProdutoServico == 0)
                return null;
            else { }

            string query = @"
SELECT 
	top 1
	nfe.idNotaFiscalE
FROM notaFiscalEItem nfei
INNER JOIN notaFiscalE nfe ON nfe.idNotaFiscalE = nfei.idNotaFiscal
WHERE 
	nfei.idProdutoServico = @idProdutoServico
ORDER BY nfe.dataEmissao DESC";

            System.Collections.Generic.List<EJB.TableBase.TField> keys = new System.Collections.Generic.List<EJB.TableBase.TField>();
            EJB.TableBase.TField key = new EJB.TableBase.TField
            {
                name = "idProdutoServico",
                value = this.m_IdProdutoServico,
                type = System.Data.SqlDbType.Int
            };
            keys.Add(key);
            System.Data.DataTable results = Utils.Utils.em.executeData(query, keys.ToArray());
            if (results != null && results.Rows.Count > 0)
            {
                Data.NotaFiscalE nfe = new NotaFiscalE
                {
                    idNotaFiscalE = Convert.ToInt32(results.Rows[0][0])
                };
                try
                {
                    nfe = (Data.NotaFiscalE)Utils.Utils.listaDados(0, nfe, 1, new List<NameValue>() { new NameValue { name = "Mode", value = "Roll" } })[0];
                }
                catch { }
                //nfe = (Data.NotaFiscalE)Utils.Utils.sr(0).consultar(nfe);
                return nfe;
            }
            else { }
            return null;
        }

        public double valorRateado()
        {
            NotaFiscalE nfe = this.getUltimaNotaEntrada();
            if (nfe == null)
                return 0;
            else { }

            decimal
                descontoAcumulado = 0,
                freteAcumulado = 0,
                ipiAcumulado = 0,
                icmsSTAcumulado = 0,
                outrasDespesasAcumulado = 0,
                valorItem = 0,
                valorTotal = 0,
                valorDesconto = 0,
                valorFrete = 0,
                valorIpi = 0,
                valorIcmsST = 0,
                valorOutrasDespesas = 0;

            valorDesconto = Convert.ToDecimal(nfe.desconto);
            valorTotal = Convert.ToDecimal(nfe.valor);
            valorFrete = Convert.ToDecimal(nfe.frete);
            valorIpi = Convert.ToDecimal(nfe.ipi);
            valorIcmsST = Convert.ToDecimal(nfe.icmsST);
            valorOutrasDespesas = Convert.ToDecimal(nfe.outrasDespesas);

            decimal
                descontoRateado = 0,
                freteRateado = 0,
                ipiRateado = 0,
                icmsStRateado = 0,
                outrasDespesasRateado = 0;

            int i = 0;
            foreach (Data.NotaFiscalEItem item in nfe.notaFiscalEItems.Where(T => T.produtoServico.idProdutoServico == this.m_IdProdutoServico))
            {
                double fator = 1;
                try
                {
                    Data.ProdutoServicoUnidade psu = new ProdutoServicoUnidade
                    {
                        idProdutoServico = item.produtoServico.idProdutoServico,
                        unidadeProdutoServico = item.unidadeProdutoServico
                    };
                    psu = (Data.ProdutoServicoUnidade)Utils.Utils.listaDados(0, psu, 1, null)[0];
                    if (psu.fator == 0)
                        fator = 1;
                    else
                        fator = psu.fator;
                }
                catch { }
                valorItem = Convert.ToDecimal((item.valor / fator));

                if (i == (nfe.notaFiscalEItems.Length - 1) && nfe.notaFiscalEItems.Length > 1)
                {
                    descontoRateado = valorDesconto - descontoAcumulado;
                    freteRateado = valorFrete - freteAcumulado;
                    ipiRateado = valorIpi - ipiAcumulado;
                    icmsStRateado = valorIcmsST - icmsSTAcumulado;
                    outrasDespesasRateado = valorOutrasDespesas - outrasDespesasAcumulado;
                }
                else if (nfe.notaFiscalEItems.Length == 1)
                {
                    descontoAcumulado = valorDesconto;
                    freteAcumulado = valorFrete;
                    ipiRateado = valorIpi;
                    icmsStRateado = valorIcmsST;
                    outrasDespesasRateado = valorOutrasDespesas;
                }
                else
                {
                    descontoRateado = (valorItem / valorTotal) * valorDesconto;
                    descontoAcumulado += descontoRateado;

                    freteRateado = (valorItem / valorTotal) * valorFrete;
                    freteAcumulado += freteRateado;

                    //ipiRateado = (valorItem / valorTotal) * valorIpi;
                    ipiAcumulado += Convert.ToDecimal(item.ipi / item.quantidade / fator);

                    icmsStRateado = (valorItem / valorTotal) * valorIcmsST;
                    icmsSTAcumulado += icmsStRateado;

                    outrasDespesasRateado = (valorItem / valorTotal) * valorOutrasDespesas;
                    outrasDespesasAcumulado += outrasDespesasRateado;
                }
                i++;
            }
            return Convert.ToDouble(valorItem + freteAcumulado + ipiAcumulado + icmsSTAcumulado + outrasDespesasAcumulado - descontoAcumulado);
        }

    }
}
