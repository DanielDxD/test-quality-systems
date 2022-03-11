using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WS.CRUD
{
    public class NotaFiscalE : WS.CRUD.Base
    {
        public NotaFiscalE(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalE input = (Data.NotaFiscalE)parametros["Key"];
            Tables.NotaFiscalE bd = new Tables.NotaFiscalE();

            bd.idNotaFiscalE.isNull = true;
            bd.numero.value = input.numero;
            bd.naturezaOperacao.value = input.naturezaOperacao;
            bd.dataEntrada.value = input.dataEntrada;

            bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            bd.valor.value = input.valor;
            bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            bd.dataEmissao.value = input.dataEmissao;
            if (input.dataVencimento.Ticks > 0)
                bd.dataVencimento.value = input.dataVencimento;
            else
                bd.dataVencimento.isNull = true;
            bd.iss.value = input.iss;
            bd.pis.value = input.pis;
            bd.cofins.value = input.cofins;
            bd.icms.value = input.icms;
            bd.icmsST.value = input.icmsST;
            bd.ir.value = input.ir;
            bd.ipi.value = input.ipi;
            bd.frete.value = input.frete;
            bd.icmsFrete.value = input.icmsFrete;
            bd.desconto.value = input.desconto;
            bd.icmsIncluso.value = input.icmsIncluso;
            bd.freteIncluso.value = input.freteIncluso;
            bd.descricao.value = input.descricao;
            bd.observacao.value = input.observacao;

            input.valorTotal = (input.valor + input.ipi + input.frete + input.icmsST + input.outrasDespesas - input.desconto);

            bd.departamento.idDepartamento.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
            {
                bd.departamento.idDepartamento.isNull = false;
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            }
            else { }

            bd.outrasDespesas.value = input.outrasDespesas;
            if (input.parcelas > 0)
                bd.parcelas.value = input.parcelas;
            else
                bd.parcelas.isNull = true;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            /* Grava��o da Nota Fiscal */
            this.m_EntityManager.persist(bd);

            /* Obt�m o ID autoincrement da nota */
            ((Data.NotaFiscalE)parametros["Key"]).idNotaFiscalE = (int)bd.idNotaFiscalE.value;

            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

            //Processa NotaFiscalEEntradaMercadoria
            //J� havia dado entrada das mercadorias sem a nota.
            if (input.notaFiscalEEntradaMercadorias != null)
            {
                WS.CRUD.NotaFiscalEEntradaMercadoria notaFiscalEEntradaMercadoriaCRUD = new WS.CRUD.NotaFiscalEEntradaMercadoria(this.m_IdEmpresaCorrente, this.m_EntityManager);

                for (int i = 0; i < input.notaFiscalEEntradaMercadorias.Length; i++)
                {
                    input.notaFiscalEEntradaMercadorias[i].idNotaFiscal = bd.idNotaFiscalE.value;
                    _parameters.Add("Key", input.notaFiscalEEntradaMercadorias[i]);
                    notaFiscalEEntradaMercadoriaCRUD.atualizar(_parameters);
                    if (input.notaFiscalEEntradaMercadorias[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.notaFiscalEEntradaMercadorias[i] = (Data.NotaFiscalEEntradaMercadoria)notaFiscalEEntradaMercadoriaCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                notaFiscalEEntradaMercadoriaCRUD = null;
            }
            else { }

            //Processa NotaFiscalEPedidoCompra
            if (input.notaFiscalEPedidoCompras != null)
            {
                WS.CRUD.NotaFiscalEPedidoCompra notaFiscalEPedidoCompraCRUD = new WS.CRUD.NotaFiscalEPedidoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager);

                for (int i = 0; i < input.notaFiscalEPedidoCompras.Length; i++)
                {
                    input.notaFiscalEPedidoCompras[i].idNotaFiscal = bd.idNotaFiscalE.value;
                    _parameters.Add("Key", input.notaFiscalEPedidoCompras[i]);
                    notaFiscalEPedidoCompraCRUD.atualizar(_parameters);
                    if (input.notaFiscalEPedidoCompras[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.notaFiscalEPedidoCompras[i] = (Data.NotaFiscalEPedidoCompra)notaFiscalEPedidoCompraCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                notaFiscalEPedidoCompraCRUD = null;
            }
            else { }

            //Processa NotaFiscalEItem
            if (input.notaFiscalEItems != null)
            {
                WS.CRUD.NotaFiscalEItem notaFiscalEItemCRUD = new WS.CRUD.NotaFiscalEItem(this.m_IdEmpresaCorrente, this.m_EntityManager);

                for (int i = 0; i < input.notaFiscalEItems.Length; i++)
                {
                    input.notaFiscalEItems[i].idNotaFiscal = bd.idNotaFiscalE.value;
                    _parameters.Add("Key", input.notaFiscalEItems[i]);
                    _parameters.Add("idEmpresa", input.fornecedor.idEmpresa);
                    _parameters.Add("dataEntrada", input.dataEntrada);
                    notaFiscalEItemCRUD.atualizar(_parameters);
                    if (input.notaFiscalEItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.notaFiscalEItems[i] = (Data.NotaFiscalEItem)notaFiscalEItemCRUD.consultar(_parameters);
                    else { }
                    _parameters.Clear();
                }

                notaFiscalEItemCRUD = null;
            }
            else { }
            if (!input.naturezaOperacao.StartsWith("Bonifica"))
            {
                //Processa Contas a Pagar
                #region Calcula valor das parcelas
                String[] condicoes = null;
                Double valorNF = input.valor;
                System.Collections.Generic.List<Data.ContasAPagar> cps = new System.Collections.Generic.List<Data.ContasAPagar>();

                if (!(input.condicaoPagamento.diasCorridos || input.condicaoPagamento.definidoPeloUsuario))
                {
                    input.condicaoPagamento.condicoes = "";

                    for (int i = 0; i < input.parcelas; i++)
                        input.condicaoPagamento.condicoes += (String.IsNullOrEmpty(input.condicaoPagamento.condicoes) ? "" : ";") + "0";
                }
                else
                {
                    input.condicaoPagamento.condicoes = "";

                    if (input.contasAPagar != null)
                    {
                        for (int i = 0; i < input.contasAPagar.Length; i++)
                            input.condicaoPagamento.condicoes += (String.IsNullOrEmpty(input.condicaoPagamento.condicoes) ? "" : ";") + "0";
                    }
                    else { }
                }

                if (String.IsNullOrEmpty(input.condicaoPagamento.condicoes))
                    condicoes = new String[] { "0" };
                else
                    condicoes = input.condicaoPagamento.condicoes.Split(new char[] { ';' });

                System.Collections.Generic.List<double> parcelas = new System.Collections.Generic.List<double>();

                int valoresACalcular = 0;

                double
                    valorResidual = 0.0,
                    valorApurado = 0.0,
                    valorParcela = 0.0;

                for (int i = 0; i < condicoes.Length; i++)
                {
                    if (condicoes[i].Contains(":"))
                        parcelas.Add(Math.Round(input.valor * Math.Abs(Utils.Utils.ToDouble(condicoes[i].Split(new char[] { ':' })[1])) / 100.00, 2));
                    else
                    {
                        valoresACalcular++;
                        parcelas.Add(0.0);
                    }

                    valorApurado += parcelas[parcelas.Count - 1];
                }

                valorApurado = (input.valor - valorApurado);

                if (valoresACalcular > 0)
                {
                    valorParcela = Math.Round((valorApurado / valoresACalcular), 2, MidpointRounding.ToEven);
                    valorResidual = Math.Round((valorApurado - (valorParcela * valoresACalcular)), 2);
                }
                else { }

                for (int i = 0; i < parcelas.Count; i++)
                {
                    if (parcelas[i] == 0.0)
                        parcelas[i] = valorParcela;
                    else { }
                }

                parcelas[parcelas.Count - 1] = Math.Round(parcelas[parcelas.Count - 1] + valorResidual, 2);
                #endregion

                Double valorPago = 0;
                for (int i = 0; i < condicoes.Length; i++)
                {
                    #region Calcula data de vencimento das parcelas
                    int diasCondicao = Utils.Utils.ToInt(condicoes[i].Split(new char[] { ':' })[0]);

                    DateTime vencimento =
                    (
                        input.condicaoPagamento.diasCorridos ?
                        input.dataEmissao.AddDays(diasCondicao) :
                        (
                            input.condicaoPagamento.definidoPeloUsuario ?
                            (
                                input.contasAPagar == null ?
                                input.dataVencimento :
                                input.contasAPagar[i].dataVencimento
                            ) :
                            input.dataVencimento.AddMonths(i)
                        )
                    );
                    #endregion
                    //
                    //Gravando parcelas do contas a pagar
                    //


                    /* Valores a descontar */
                    Double valorADescontar = 0;
                    Double valorContasAPagar;

                    switch (input.naturezaOperacao)
                    {
                        case "Servico":
                            {
                                valorADescontar =
                                    (
                                        (-input.desconto) - input.iss - input.pis - input.cofins - input.ir - input.outrasDespesas
                                    );
                                break;
                            }

                        case "Compra":
                            {
                                valorADescontar = (-input.desconto) + input.frete + input.outrasDespesas + input.icmsST + input.ipi;
                                break;
                            }
                    }

                    valorContasAPagar = parcelas[i];
                    if (valorADescontar != 0)
                        if (condicoes.Length > 1 && i == (condicoes.Length - 1))
                            valorContasAPagar = Math.Round(input.valorTotal - valorPago, 2);
                        else
                            valorContasAPagar = Math.Round(valorContasAPagar + ((valorADescontar) / parcelas.Count), 2);
                    else { }


                    Data.ContasAPagar cp = new Data.ContasAPagar();
                    cp.operacao = ENum.eOperacao.INCLUIR;
                    cp.idEmpresa = input.fornecedor.idEmpresa;
                    cp.dataMovimento = input.dataEmissao;
                    cp.dataVencimento = ((vencimento >= DateTime.Today) ? vencimento : DateTime.Today);
                    cp.empresaRelacionamento = (Data.EmpresaRelacionamento)Utils.Utils.sr((long)this.m_IdEmpresaCorrente).consultar(new Data.EmpresaRelacionamento { idEmpresaRelacionamento = input.fornecedor.idEmpresaRelacionamento });
                    cp.outrasInformacoes = input.contasAPagar[i].outrasInformacoes;
                    cp.parcela = (condicoes.Length >= 1) ? String.Format("{0} de {1}", i + 1, condicoes.Length) : "";
                    cp.evento = input.contasAPagar[i].evento;
                    cp.numeroDocumento = input.contasAPagar[i].numeroDocumento;
                    cp.valor =
                    (
                        input.condicaoPagamento.definidoPeloUsuario ?
                        (
                            input.contasAPagar == null ?
                            input.valorTotal :
                            input.contasAPagar[i].valor
                        ) :
                        //parcelas[i]
                        valorContasAPagar
                    );

                    valorPago = Math.Round(valorPago + valorContasAPagar, 2);

                    cp.contasAPagarItems = new Data.ContasAPagarItem[1];
                    cp.contasAPagarItems[0] = new Data.ContasAPagarItem();
                    cp.contasAPagarItems[0].operacao = ENum.eOperacao.INCLUIR;
                    cp.contasAPagarItems[0].idContasAPagar = cp.idContasAPagar;
                    cp.contasAPagarItems[0].idNotaFiscal = input.idNotaFiscalE;
                    cp.contasAPagarItems[0].valor = cp.valor;
                    cp.contasAPagarItems[0].valorDesconto = 0;
                    cp.contasAPagarItems[0].descricao = "Referente NF " + input.numero;

                    if (cp.outrasInformacoes != null)
                    {

                        if (cp.outrasInformacoes.idNaturezaOperacao > 0)
                            cp.contasAPagarItems[0].idNaturezaOperacao = cp.outrasInformacoes.idNaturezaOperacao;
                        else { }

                        if (cp.outrasInformacoes.idDepartamento > 0)
                            cp.contasAPagarItems[0].idDepartamento = cp.outrasInformacoes.idDepartamento;
                        else { }

                        if (!String.IsNullOrEmpty(cp.outrasInformacoes.descricao))
                            cp.contasAPagarItems[0].descricao = cp.outrasInformacoes.descricao;
                        else
                        {
                            cp.contasAPagarItems[0].descricao = "Referente NF " + input.numero;
                        }
                    }



                    cps.Add(cp);

                }

                input.contasAPagar = cps.ToArray();

                /* Verificando Contas A Pagar */
                DateTime dv =
                            (
                                (
                                    (cps != null) &&
                                    (cps.Count > 0) &&
                                    (cps[0].dataVencimento.Ticks > 0)
                                ) ?
                                cps[0].dataVencimento :
                                input.dataVencimento
                            );

                if (input.parcelas >= 1)
                {

                    if (input.contasAPagar != null)
                    {
                        if (Convert.ToDouble(input.valorTotal.ToString("0.00")) != Convert.ToDouble(input.contasAPagar.Sum(X => X.valor).ToString("0.00")))
                            throw new Utils.BusinessRuleException("Valor da(s) parcela(s) é diferente do valor da NF");
                        else { }

                        DateTime vencimento = input.dataEmissao;

                        for (int i = 0; i < input.contasAPagar.Length; i++)
                        {
                            if (input.contasAPagar[i].dataVencimento < vencimento)
                                throw new Utils.BusinessRuleException("Data de vencimento da parcela " + (i + 1).ToString() + " deve ser maior ou igual a " + vencimento.ToString("dd/MM/yyyy"));
                            else
                                vencimento = input.contasAPagar[i].dataVencimento;
                        }
                    }
                    else { }
                }
                else { }

                if (dv.Ticks <= ((Data.Empresa)HttpContext.Current.Session["currentBusiness"]).dataCorte.Ticks)
                    throw new Utils.BusinessRuleException("Data de vencimento deve ser maior que " + ((Data.Empresa)HttpContext.Current.Session["currentBusiness"]).dataCorte.ToString("dd/MM/yyyy"));
                else { }

                foreach (Data.ContasAPagar item in cps)
                {
                    WS.CRUD.ContasAPagar contasAPagarCRUD = new WS.CRUD.ContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    _parameters.Add("Key", item);
                    contasAPagarCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                cps.Clear();
                cps = null;
            }
            else { }

            _parameters = null;

            return input;// this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalE input = (Data.NotaFiscalE)parametros["Key"];
            Tables.NotaFiscalE bd = (Tables.NotaFiscalE)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalE),
                new Object[]
                {
                    input.idNotaFiscalE
                }
            );

            bd.numero.value = input.numero;
            bd.naturezaOperacao.value = input.naturezaOperacao;
            bd.dataEntrada.value = input.dataEntrada;
            bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            bd.valor.value = input.valor;
            bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            bd.dataEmissao.value = input.dataEmissao;

            bd.departamento.idDepartamento.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
            {
                bd.departamento.idDepartamento.isNull = false;
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            }
            else { }

            if (input.dataVencimento.Ticks > 0)
                bd.dataVencimento.value = input.dataVencimento;
            else
                bd.dataVencimento.isNull = true;
            bd.iss.value = input.iss;
            bd.pis.value = input.pis;
            bd.cofins.value = input.cofins;
            bd.icms.value = input.icms;
            bd.icmsST.value = input.icmsST;
            bd.ir.value = input.ir;
            bd.ipi.value = input.ipi;
            bd.frete.value = input.frete;
            bd.icmsFrete.value = input.icmsFrete;
            bd.desconto.value = input.desconto;
            bd.icmsIncluso.value = input.icmsIncluso;
            bd.freteIncluso.value = input.freteIncluso;
            bd.outrasDespesas.value = input.outrasDespesas;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            bd.descricao.value = input.descricao;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

            //Processa NotaFiscalEEntradaMercadoria
            if (input.notaFiscalEEntradaMercadorias != null)
            {
                WS.CRUD.NotaFiscalEEntradaMercadoria notaFiscalEEntradaMercadoriaCRUD = new WS.CRUD.NotaFiscalEEntradaMercadoria(this.m_IdEmpresaCorrente, this.m_EntityManager);

                for (int i = 0; i < input.notaFiscalEEntradaMercadorias.Length; i++)
                {
                    input.notaFiscalEEntradaMercadorias[i].idNotaFiscal = bd.idNotaFiscalE.value;
                    _parameters.Add("Key", input.notaFiscalEEntradaMercadorias[i]);
                    if (input.notaFiscalEEntradaMercadorias[i].operacao == ENum.eOperacao.NONE)
                        input.notaFiscalEEntradaMercadorias[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    notaFiscalEEntradaMercadoriaCRUD.atualizar(_parameters);
                    if (input.notaFiscalEEntradaMercadorias[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.notaFiscalEEntradaMercadorias[i] = (Data.NotaFiscalEEntradaMercadoria)notaFiscalEEntradaMercadoriaCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                notaFiscalEEntradaMercadoriaCRUD = null;
            }
            else { }

            //Processa NotaFiscalEPedidoCompra
            if (input.notaFiscalEPedidoCompras != null)
            {
                WS.CRUD.NotaFiscalEPedidoCompra notaFiscalEPedidoCompraCRUD = new WS.CRUD.NotaFiscalEPedidoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager);

                for (int i = 0; i < input.notaFiscalEPedidoCompras.Length; i++)
                {
                    input.notaFiscalEPedidoCompras[i].idNotaFiscal = bd.idNotaFiscalE.value;
                    _parameters.Add("Key", input.notaFiscalEPedidoCompras[i]);
                    if (input.notaFiscalEPedidoCompras[i].operacao == ENum.eOperacao.NONE)
                        input.notaFiscalEPedidoCompras[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    notaFiscalEPedidoCompraCRUD.atualizar(_parameters);
                    if (input.notaFiscalEPedidoCompras[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.notaFiscalEPedidoCompras[i] = (Data.NotaFiscalEPedidoCompra)notaFiscalEPedidoCompraCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                notaFiscalEPedidoCompraCRUD = null;
            }
            else { }

            //Processa NotaFiscalEItem
            if (input.notaFiscalEItems != null)
            {
                WS.CRUD.NotaFiscalEItem notaFiscalEItemCRUD = new WS.CRUD.NotaFiscalEItem(this.m_IdEmpresaCorrente, this.m_EntityManager);

                for (int i = 0; i < input.notaFiscalEItems.Length; i++)
                {
                    input.notaFiscalEItems[i].idNotaFiscal = bd.idNotaFiscalE.value;
                    _parameters.Add("Key", input.notaFiscalEItems[i]);
                    _parameters.Add("idEmpresa", input.fornecedor.idEmpresa);
                    _parameters.Add("dataEntrada", input.dataEntrada);
                    if (input.notaFiscalEItems[i].operacao == ENum.eOperacao.NONE)
                        input.notaFiscalEItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    notaFiscalEItemCRUD.atualizar(_parameters);
                    if (input.notaFiscalEItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.notaFiscalEItems[i] = (Data.NotaFiscalEItem)notaFiscalEItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                notaFiscalEItemCRUD = null;
            }
            else { }

            _parameters = null;

            return input;// this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NotaFiscalE bd = new Tables.NotaFiscalE();

            bd.idNotaFiscalE.value = ((Data.NotaFiscalE)parametros["Key"]).idNotaFiscalE;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NotaFiscalE)bd).idNotaFiscalE.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NotaFiscalE)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NotaFiscalE)input).idNotaFiscalE = ((Tables.NotaFiscalE)bd).idNotaFiscalE.value;
                    ((Data.NotaFiscalE)input).numero = ((Tables.NotaFiscalE)bd).numero.value;
                    ((Data.NotaFiscalE)input).naturezaOperacao = ((Tables.NotaFiscalE)bd).naturezaOperacao.value;
                    ((Data.NotaFiscalE)input).dataEntrada = ((Tables.NotaFiscalE)bd).dataEntrada.value;

                    ((Data.NotaFiscalE)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.NotaFiscalE)bd).departamento,
                        level + 1
                    );

                    ((Data.NotaFiscalE)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.NotaFiscalE)bd).fornecedor,
                        level + 1
                    );
                    ((Data.NotaFiscalE)input).valor = ((Tables.NotaFiscalE)bd).valor.value;
                    ((Data.NotaFiscalE)input).condicaoPagamento = (Data.CondicaoPagamento)(new WS.CRUD.CondicaoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CondicaoPagamento(),
                        ((Tables.NotaFiscalE)bd).condicaoPagamento,
                        level + 1
                    );
                    ((Data.NotaFiscalE)input).dataEmissao = ((Tables.NotaFiscalE)bd).dataEmissao.value;
                    ((Data.NotaFiscalE)input).dataVencimento = ((Tables.NotaFiscalE)bd).dataVencimento.value;
                    ((Data.NotaFiscalE)input).iss = ((Tables.NotaFiscalE)bd).iss.value;
                    ((Data.NotaFiscalE)input).pis = ((Tables.NotaFiscalE)bd).pis.value;
                    ((Data.NotaFiscalE)input).cofins = ((Tables.NotaFiscalE)bd).cofins.value;
                    ((Data.NotaFiscalE)input).icms = ((Tables.NotaFiscalE)bd).icms.value;
                    ((Data.NotaFiscalE)input).icmsST = ((Tables.NotaFiscalE)bd).icmsST.value;
                    ((Data.NotaFiscalE)input).ir = ((Tables.NotaFiscalE)bd).ir.value;
                    ((Data.NotaFiscalE)input).ipi = ((Tables.NotaFiscalE)bd).ipi.value;
                    ((Data.NotaFiscalE)input).frete = ((Tables.NotaFiscalE)bd).frete.value;
                    ((Data.NotaFiscalE)input).icmsFrete = ((Tables.NotaFiscalE)bd).icmsFrete.value;
                    ((Data.NotaFiscalE)input).desconto = ((Tables.NotaFiscalE)bd).desconto.value;
                    ((Data.NotaFiscalE)input).icmsIncluso = ((Tables.NotaFiscalE)bd).icmsIncluso.value;
                    ((Data.NotaFiscalE)input).freteIncluso = ((Tables.NotaFiscalE)bd).freteIncluso.value;
                    ((Data.NotaFiscalE)input).outrasDespesas = ((Tables.NotaFiscalE)bd).outrasDespesas.value;
                    ((Data.NotaFiscalE)input).valorTotal = ((Tables.NotaFiscalE)bd).valorTotal.value;
                    ((Data.NotaFiscalE)input).descricao = ((Tables.NotaFiscalE)bd).descricao.value;
                    ((Data.NotaFiscalE)input).observacao = ((Tables.NotaFiscalE)bd).observacao.value;
                    if (!((Tables.NotaFiscalE)bd).parcelas.isNull)
                        ((Data.NotaFiscalE)input).parcelas = ((Tables.NotaFiscalE)bd).parcelas.value;
                    else { }
                    ((Data.NotaFiscalE)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.NotaFiscalE)bd).tipoMovimentoContabil,
                        level + 1
                    );

                    ((Data.NotaFiscalE)input).contasAPagar = new Data.ContasAPagar[((Data.NotaFiscalE)input).parcelas];
                    int iParcela = 0;


                    System.Collections.Generic.List<Tables.ContasAPagar> list = (System.Collections.Generic.List<Tables.ContasAPagar>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAPagar),
                        (
                            @"
                                select
                                    cp.*
                                from
                                    contasAPagar cp
		                                inner join contasAPagarItem cpi
			                                on	cpi.idContasAPagar = cp.idContasAPagar
                                where
                                    cpi.idNotaFiscal = @idNotaFiscal and
                                    cp.idEmpresaRelacionamento = @idEmpresaRelacionamento
                                order by
                                    cp.idContasAPagar"
                        ),
                        new EJB.TableBase.TField[]
                        {
                            new EJB.TableBase.TFieldInteger("idNotaFiscal", ((Data.NotaFiscalE)input).idNotaFiscalE),
                            new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", ((Data.NotaFiscalE)input).fornecedor.idEmpresaRelacionamento)
                        }
                    );

                    if (list != null)
                    {
                        foreach
                        (
                            Tables.ContasAPagar _data in list
                        )
                            ((Data.NotaFiscalE)input).contasAPagar[iParcela++] = (Data.ContasAPagar)(new WS.CRUD.ContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher(new Data.ContasAPagar(), _data, 0);
                    }
                    else { }
                }
            }
            else { }

            if (level < 1)
            {
                //Preencher NotaFiscalEEntradaMercadorias
                if (((Tables.NotaFiscalE)bd).notaFiscalEEntradaMercadorias != null)
                {
                    System.Collections.Generic.List<Data.NotaFiscalEEntradaMercadoria> _list = new System.Collections.Generic.List<Data.NotaFiscalEEntradaMercadoria>();

                    foreach (Tables.NotaFiscalEEntradaMercadoria _item in ((Tables.NotaFiscalE)bd).notaFiscalEEntradaMercadorias)
                    {
                        _list.Add
                        (
                            (Data.NotaFiscalEEntradaMercadoria)
                            (new WS.CRUD.NotaFiscalEEntradaMercadoria(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.NotaFiscalEEntradaMercadoria(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.NotaFiscalE)input).notaFiscalEEntradaMercadorias = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.NotaFiscalE)input).notaFiscalEEntradaMercadorias != null)
                    {
                        System.Collections.Generic.List<Data.NotaFiscalEEntradaMercadoria> _list = new System.Collections.Generic.List<Data.NotaFiscalEEntradaMercadoria>();

                        foreach (Data.NotaFiscalEEntradaMercadoria _item in ((Data.NotaFiscalE)input).notaFiscalEEntradaMercadorias)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.NotaFiscalE)input).notaFiscalEEntradaMercadorias = _list.ToArray();
                        else
                            ((Data.NotaFiscalE)input).notaFiscalEEntradaMercadorias = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }

            if (level < 1)
            {
                //Preencher NotaFiscalEPedidoCompras
                if (((Tables.NotaFiscalE)bd).notaFiscalEPedidoCompras != null)
                {
                    System.Collections.Generic.List<Data.NotaFiscalEPedidoCompra> _list = new System.Collections.Generic.List<Data.NotaFiscalEPedidoCompra>();

                    foreach (Tables.NotaFiscalEPedidoCompra _item in ((Tables.NotaFiscalE)bd).notaFiscalEPedidoCompras)
                    {
                        _list.Add
                        (
                            (Data.NotaFiscalEPedidoCompra)
                            (new WS.CRUD.NotaFiscalEPedidoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.NotaFiscalEPedidoCompra(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.NotaFiscalE)input).notaFiscalEPedidoCompras = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.NotaFiscalE)input).notaFiscalEPedidoCompras != null)
                    {
                        System.Collections.Generic.List<Data.NotaFiscalEPedidoCompra> _list = new System.Collections.Generic.List<Data.NotaFiscalEPedidoCompra>();

                        foreach (Data.NotaFiscalEPedidoCompra _item in ((Data.NotaFiscalE)input).notaFiscalEPedidoCompras)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.NotaFiscalE)input).notaFiscalEPedidoCompras = _list.ToArray();
                        else
                            ((Data.NotaFiscalE)input).notaFiscalEPedidoCompras = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }

            if (level < 1)
            {
                //Preencher NotaFiscalEItems
                if (((Tables.NotaFiscalE)bd).notaFiscalEItems != null)
                {
                    System.Collections.Generic.List<Data.NotaFiscalEItem> _list = new System.Collections.Generic.List<Data.NotaFiscalEItem>();

                    foreach (Tables.NotaFiscalEItem _item in ((Tables.NotaFiscalE)bd).notaFiscalEItems)
                    {
                        _list.Add
                        (
                            (Data.NotaFiscalEItem)
                            (new WS.CRUD.NotaFiscalEItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.NotaFiscalEItem(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.NotaFiscalE)input).notaFiscalEItems = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.NotaFiscalE)input).notaFiscalEItems != null)
                    {
                        System.Collections.Generic.List<Data.NotaFiscalEItem> _list = new System.Collections.Generic.List<Data.NotaFiscalEItem>();

                        foreach (Data.NotaFiscalEItem _item in ((Data.NotaFiscalE)input).notaFiscalEItems)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.NotaFiscalE)input).notaFiscalEItems = _list.ToArray();
                        else
                            ((Data.NotaFiscalE)input).notaFiscalEItems = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalE result = (Data.NotaFiscalE)parametros["Key"];

            try
            {
                result = (Data.NotaFiscalE)this.preencher
                (
                    new Data.NotaFiscalE(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NotaFiscalE),
                        new Object[]
                        {
                            result.idNotaFiscalE
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            bool onlyCount = false;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }
            }
            else { }

            Data.NotaFiscalE _input = (Data.NotaFiscalE)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.fornecedor != null)
                {
                    if (_input.fornecedor.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.fornecedor.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.fornecedor.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   fornecedor.idFornecedor = @idFornecedor");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFornecedor", _input.fornecedor.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("fornecedor.idFornecedor"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "fornecedor.idFornecedor");
                        else { }
                    }
                    else { }

                    if ((_input.fornecedor.pessoa != null) && (!String.IsNullOrEmpty(_input.fornecedor.pessoa.nomeRazaoSocial)))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.fornecedor.pessoa.nomeRazaoSocial + '%'));
                        if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.idNotaFiscalE > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalE.idNotaFiscalE = @idNotaFiscalE");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNotaFiscalE", _input.idNotaFiscalE));
                    if (!sqlOrderBy.Contains("notaFiscalE.idNotaFiscalE"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalE.idNotaFiscalE");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numero))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalE.numero = @numero");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numero", _input.numero));
                    if (!sqlOrderBy.Contains("notaFiscalE.numero"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalE.numero");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "notaFiscalE.* ") +
                    "from \n" +
                    (
                        "notaFiscalE notaFiscalE\n" +
                        "	inner join fornecedor fornecedor\n" +
                        "       on	fornecedor.idFornecedor = notaFiscalE.idFornecedor\n" +
                        "   inner join	empresaRelacionamento empresaRelacionamento\n" +
                        "       on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor\n" +
                        "   inner join pessoa pessoa\n" +
                        "       on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n"
                    ) +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalE input = (Data.NotaFiscalE)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String
                        _filter = (String)parametros["Filter"],
                        _keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!_keys.Contains("[" + _key + "]"))
                        {
                            _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                            _keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.NotaFiscalE),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NotaFiscalE _data in
                    (System.Collections.Generic.List<Tables.NotaFiscalE>)this.m_EntityManager.list
                    (
                        typeof(Tables.NotaFiscalE),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.NotaFiscalE();
                        ((Data.NotaFiscalE)_base).idNotaFiscalE = _data.idNotaFiscalE.value;
                        ((Data.NotaFiscalE)_base).fornecedor = new Data.Fornecedor { pessoa = new Data.Pessoa { nomeRazaoSocial = _data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };
                        ((Data.NotaFiscalE)_base).dataEmissao = _data.dataEmissao.value;
                        ((Data.NotaFiscalE)_base).valor = _data.valorTotal.value;
                        ((Data.NotaFiscalE)_base).dataEntrada = _data.dataEntrada.value;
                        ((Data.NotaFiscalE)_base).descricao = _data.descricao.value;
                        ((Data.NotaFiscalE)_base).observacao = _data.observacao.value;
                        ((Data.NotaFiscalE)_base).frete = _data.frete.value;
                        ((Data.NotaFiscalE)_base).ipi = _data.ipi.value;
                        ((Data.NotaFiscalE)_base).icms = _data.icms.value;
                        ((Data.NotaFiscalE)_base).icmsFrete = _data.icmsFrete.value;
                        ((Data.NotaFiscalE)_base).icmsST = _data.icmsST.value;
                        ((Data.NotaFiscalE)_base).outrasDespesas = _data.outrasDespesas.value;
                        ((Data.NotaFiscalE)_base).desconto = _data.desconto.value;

                        if (level < 1)
                        {
                            if (((Tables.NotaFiscalE)_data).notaFiscalEItems != null)
                            {
                                System.Collections.Generic.List<Data.NotaFiscalEItem> _list = new System.Collections.Generic.List<Data.NotaFiscalEItem>();

                                foreach (Tables.NotaFiscalEItem _item in ((Tables.NotaFiscalE)_data).notaFiscalEItems)
                                {
                                    _list.Add
                                    (
                                        (Data.NotaFiscalEItem)
                                        (new WS.CRUD.NotaFiscalEItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.NotaFiscalEItem(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }

                                ((Data.NotaFiscalE)_base).notaFiscalEItems = _list.ToArray();
                                _list.Clear();
                                _list = null;
                            }
                            else
                            {
                                if (((Data.NotaFiscalE)_base).notaFiscalEItems != null)
                                {
                                    System.Collections.Generic.List<Data.NotaFiscalEItem> _list = new System.Collections.Generic.List<Data.NotaFiscalEItem>();

                                    foreach (Data.NotaFiscalEItem _item in ((Data.NotaFiscalE)_base).notaFiscalEItems)
                                    {
                                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                        {
                                            _item.operacao = ENum.eOperacao.NONE;
                                            _list.Add(_item);
                                        }
                                        else { }
                                    }

                                    if (_list.Count > 0)
                                        ((Data.NotaFiscalE)_base).notaFiscalEItems = _list.ToArray();
                                    else
                                        ((Data.NotaFiscalE)_base).notaFiscalEItems = null;

                                    _list.Clear();
                                    _list = null;
                                }
                                else { }
                            }
                        }
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.NotaFiscalE(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    report.ProcessRecord(null);
                else { }

                _fieldKeys.Clear();
                _fieldKeys = null;
                _select = null;
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }

    }
}
