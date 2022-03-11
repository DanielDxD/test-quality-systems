using System;
using System.Collections.Generic;
using System.Drawing;

namespace WS.CRUD
{
    public class ContaPagamentoMovimento : WS.CRUD.Base
    {
        public ContaPagamentoMovimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoMovimento input = (Data.ContaPagamentoMovimento)parametros["Key"];
            Tables.ContaPagamentoMovimento bd = new Tables.ContaPagamentoMovimento();

            bd.idContaPagamentoMovimento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.dataMovimento.value = input.dataMovimento;
            bd.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            if ((input.documentoPagamento != null) && (input.documentoPagamento.idDocumentoPagamento > 0))
                bd.documentoPagamento.idDocumentoPagamento.value = input.documentoPagamento.idDocumentoPagamento;
            else
                bd.documentoPagamento.idDocumentoPagamento.isNull = true;
            if ((input.documentoRecebimento != null) && (input.documentoRecebimento.idDocumentoRecebimento > 0))
                bd.documentoRecebimento.idDocumentoRecebimento.value = input.documentoRecebimento.idDocumentoRecebimento;
            else
                bd.documentoRecebimento.idDocumentoRecebimento.isNull = true;
            if ((input.documentoTransferenciaEntrada != null) && (input.documentoTransferenciaEntrada.idDocumentoTransferencia > 0))
                bd.documentoTransferenciaEntrada.idDocumentoTransferencia.value = input.documentoTransferenciaEntrada.idDocumentoTransferencia;
            else
                bd.documentoTransferenciaEntrada.idDocumentoTransferencia.isNull = true;
            if ((input.documentoTransferenciaSaida != null) && (input.documentoTransferenciaSaida.idDocumentoTransferencia > 0))
                bd.documentoTransferenciaSaida.idDocumentoTransferencia.value = input.documentoTransferenciaSaida.idDocumentoTransferencia;
            else
                bd.documentoTransferenciaSaida.idDocumentoTransferencia.isNull = true;
            bd.valor.value = input.valor;
            if (input.dataConciliacao.Ticks > 0)
                bd.dataConciliacao.value = input.dataConciliacao;
            else
                bd.dataConciliacao.isNull = true;

            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.ContaPagamentoMovimento)parametros["Key"]).idContaPagamentoMovimento = (int)bd.idContaPagamentoMovimento.value;

            //Atualiza Contas A Pagar Pagamento
            if (!input.ignoraBaixa)
            {
                if ((input.documentoPagamento != null) && (input.documentoPagamento.idDocumentoPagamento > 0))
                {
                    List<Data.ContasAPagarPagamento> capps = new List<Data.ContasAPagarPagamento>();
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    if ((input.documentoPagamento != null) && (input.documentoPagamento.idDocumentoPagamento > 0))
                    {
                        Data.DocumentoPagamentoContasAPagar dpcap = new Data.DocumentoPagamentoContasAPagar();
                        dpcap.idDocumentoPagamento = input.documentoPagamento.idDocumentoPagamento;

                        WS.CRUD.DocumentoPagamentoContasAPagar documentoPagamentoContasAPagarCRUD = new WS.CRUD.DocumentoPagamentoContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager);

                        _parameters.Add("Key", dpcap);

                        foreach (var item in (Data.Base[])documentoPagamentoContasAPagarCRUD.listar(_parameters))
                        {
                            capps.Add
                            (
                                new Data.ContasAPagarPagamento
                                {
                                    operacao = ENum.eOperacao.INCLUIR,
                                    idContasAPagar = ((Data.DocumentoPagamentoContasAPagar)item).contasAPagar.idContasAPagar,
                                    dataMovimento = bd.dataMovimento.value,
                                    valorPrincipal = ((Data.DocumentoPagamentoContasAPagar)item).valorPago,
                                    valorMulta = ((Data.DocumentoPagamentoContasAPagar)item).valorMulta,
                                    valorJuros = ((Data.DocumentoPagamentoContasAPagar)item).valorJuros,
                                    valorDesconto = ((Data.DocumentoPagamentoContasAPagar)item).valorDesconto,
                                    valorCM = ((Data.DocumentoPagamentoContasAPagar)item).valorCM,
                                    contaPagamento = new Data.ContaPagamento { idContaPagamento = bd.idContaPagamento.value },
                                    valorINSSRetido = ((Data.DocumentoPagamentoContasAPagar)item).valorINSSRetido,
                                    valorISSRetido = ((Data.DocumentoPagamentoContasAPagar)item).valorISSRetido,
                                    valorIRRetido = ((Data.DocumentoPagamentoContasAPagar)item).valorIRRetido,
                                    valorPISRetido = ((Data.DocumentoPagamentoContasAPagar)item).valorPISRetido,
                                    valorCOFINSRetido = ((Data.DocumentoPagamentoContasAPagar)item).valorCOFINSRetido,
                                    valorCSLLRetido = ((Data.DocumentoPagamentoContasAPagar)item).valorCSLLRetido,
                                    idDocumentoPagamento = ((Data.DocumentoPagamentoContasAPagar)item).idDocumentoPagamento,
                                    idFuncionario = input.idFuncionario
                                }
                            );
                        }

                        _parameters.Clear();

                        documentoPagamentoContasAPagarCRUD = null;
                    }
                    else { }

                    WS.CRUD.ContasAPagarPagamento contasAPagarPagamentoCRUD = new WS.CRUD.ContasAPagarPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);

                    foreach (var capp in capps)
                    {

                        _parameters.Add("Key", capp);
                        contasAPagarPagamentoCRUD.atualizar(_parameters);
                        _parameters.Clear();
                    }

                    _parameters = null;
                    contasAPagarPagamentoCRUD = null;
                }
                else { }


                //Atualiza Contas A Receber Recebimento
                if ((input.documentoRecebimento != null) && (input.documentoRecebimento.idDocumentoRecebimento > 0))
                {
                    List<Data.ContasAReceberPagamento> carps = new List<Data.ContasAReceberPagamento>();
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    if ((input.documentoRecebimento != null) && (input.documentoRecebimento.idDocumentoRecebimento > 0))
                    {
                        Data.DocumentoRecebimentoContasAReceber dpcar = new Data.DocumentoRecebimentoContasAReceber();
                        dpcar.idDocumentoRecebimento = input.documentoRecebimento.idDocumentoRecebimento;

                        WS.CRUD.DocumentoRecebimentoContasAReceber documentoRecebimentoContasAReceberCRUD = new WS.CRUD.DocumentoRecebimentoContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager);

                        _parameters.Add("Key", dpcar);
                        if (input.documentoRecebimento.documentoRecebimentoContasARecebers != null)
                            foreach (var item in input.documentoRecebimento.documentoRecebimentoContasARecebers)
                            {

                                Double valorBruto = (
                                    item.valorRecebido +
                                    (
                                        item.valorDesconto +
                                        item.valorINSSRetido +
                                        item.valorISSRetido +
                                        item.valorIRRetido +
                                        item.valorPISRetido +
                                        item.valorCOFINSRetido +
                                        item.valorCSLLRetido
                                    ) -
                                    (
                                        item.valorMulta +
                                        item.valorJuros +
                                        item.valorCM
                                    )

                                );

                                carps.Add
                                (
                                    new Data.ContasAReceberPagamento
                                    {
                                        operacao = ENum.eOperacao.INCLUIR,
                                        idContasAReceber = item.contasAReceber.idContasAReceber,
                                        dataMovimento = bd.dataMovimento.value,
                                        valorPrincipal = item.valorRecebido,
                                        valorMulta = item.valorMulta,
                                        valorJuros = item.valorJuros,
                                        valorDesconto = item.valorDesconto,
                                        valorCM = item.valorCM,
                                        contaPagamento = new Data.ContaPagamento { idContaPagamento = bd.idContaPagamento.value },
                                        valorINSSRetido = item.valorINSSRetido,
                                        valorISSRetido = item.valorISSRetido,
                                        valorIRRetido = item.valorIRRetido,
                                        valorPISRetido = item.valorPISRetido,
                                        valorCOFINSRetido = item.valorCOFINSRetido,
                                        valorCSLLRetido = item.valorCSLLRetido,
                                        idDocumentoRecebimento = item.idDocumentoRecebimento,
                                        idFuncionario = input.idFuncionario,
                                        ignorarRecibo = input.ignorarRecibo
                                    }
                                );

                            }

                        _parameters.Clear();

                        documentoRecebimentoContasAReceberCRUD = null;
                    }
                    else { }

                    WS.CRUD.ContasAReceberPagamento contasAReceberRecebimentoCRUD = new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);

                    foreach (var carp in carps)
                    {
                        if (input.idPdvEstacao > 0)
                            ((Data.ContasAReceberPagamento)carp).idPdvEstacao = input.idPdvEstacao;
                        else { }

                        if (input.idPdvCompraTaxaServico > 0)
                            ((Data.ContasAReceberPagamento)carp).pdvCompraTaxaServico = new Data.PdvCompraTaxaServico { idPdvCompraTaxaServico = input.idPdvCompraTaxaServico };
                        else { }

                        if (input.idPdvCompra > 0)
                            ((Data.ContasAReceberPagamento)carp).pdvCompra = new Data.PdvCompra { idPdvCompra = input.idPdvCompra };
                        else { }

                        _parameters.Add("Key", carp);
                        contasAReceberRecebimentoCRUD.atualizar(_parameters);
                        _parameters.Clear();
                    }

                    _parameters = null;
                    contasAReceberRecebimentoCRUD = null;
                }
                else { }
            }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoMovimento input = (Data.ContaPagamentoMovimento)parametros["Key"];
            Tables.ContaPagamentoMovimento bd = (Tables.ContaPagamentoMovimento)this.m_EntityManager.find
            (
                typeof(Tables.ContaPagamentoMovimento),
                new Object[]
                {
                    input.idContaPagamentoMovimento
                }
            );

            bd.descricao.value = input.descricao;

            if (input.dataConciliacao.Ticks > 0)
                bd.dataConciliacao.value = input.dataConciliacao;
            else
                bd.dataConciliacao.isNull = true;

            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContaPagamentoMovimento bd = new Tables.ContaPagamentoMovimento();
            Data.ContaPagamentoMovimento input = (Data.ContaPagamentoMovimento)parametros["Key"];

            bd.idContaPagamentoMovimento.value = input.idContaPagamentoMovimento;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContaPagamentoMovimento)bd).idContaPagamentoMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContaPagamentoMovimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContaPagamentoMovimento)input).idContaPagamentoMovimento = ((Tables.ContaPagamentoMovimento)bd).idContaPagamentoMovimento.value;
                    ((Data.ContaPagamentoMovimento)input).descricao = ((Tables.ContaPagamentoMovimento)bd).descricao.value;
                    ((Data.ContaPagamentoMovimento)input).observacao = ((Tables.ContaPagamentoMovimento)bd).observacao.value;
                    ((Data.ContaPagamentoMovimento)input).dataMovimento = ((Tables.ContaPagamentoMovimento)bd).dataMovimento.value;
                    {
                        ((Data.ContaPagamentoMovimento)input).contaPagamento = new Data.ContaPagamento();
                        ((Data.ContaPagamentoMovimento)input).contaPagamento.idContaPagamento = ((Tables.ContaPagamentoMovimento)bd).idContaPagamento.value;

                        List<Utils.NameValue> pr = new List<Utils.NameValue>();
                        pr.Add(new Utils.NameValue { name = "Level", value = 1 });
                        ((Data.ContaPagamentoMovimento)input).contaPagamento = (Data.ContaPagamento)Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, ((Data.ContaPagamentoMovimento)input).contaPagamento, 1, pr)[0];
                        //((Data.ContaPagamentoMovimento)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parameters);
                    }

                    //DocumentoPagamento
                    if (((Tables.ContaPagamentoMovimento)bd).documentoPagamento.idDocumentoPagamento.value == 0)
                        ((Data.ContaPagamentoMovimento)input).documentoPagamento = null;
                    else
                        ((Data.ContaPagamentoMovimento)input).documentoPagamento = (Data.DocumentoPagamento)(new WS.CRUD.DocumentoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.DocumentoPagamento(),
                            ((Tables.ContaPagamentoMovimento)bd).documentoPagamento,
                            level + 1
                        );

                    //DocumentoRecebimento
                    if (((Tables.ContaPagamentoMovimento)bd).documentoRecebimento.idDocumentoRecebimento.value == 0)
                        ((Data.ContaPagamentoMovimento)input).documentoRecebimento = null;
                    else
                    {
                        ((Data.ContaPagamentoMovimento)input).documentoRecebimento = (Data.DocumentoRecebimento)(new WS.CRUD.DocumentoRecebimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.DocumentoRecebimento(),
                            ((Tables.ContaPagamentoMovimento)bd).documentoRecebimento,
                            level + 1
                        );

                        ((Data.ContaPagamentoMovimento)input).dataVencimento = ((Tables.ContaPagamentoMovimento)bd).documentoRecebimento.dataVencimento.value;
                        ((Data.ContaPagamentoMovimento)input).documentoRecebimento.dataVencimento = ((Tables.ContaPagamentoMovimento)bd).documentoRecebimento.dataVencimento.value;

                    }
                    //DocumentoTransferenciaEntrada
                    if (((Tables.ContaPagamentoMovimento)bd).documentoTransferenciaEntrada.idDocumentoTransferencia.value == 0)
                        ((Data.ContaPagamentoMovimento)input).documentoTransferenciaEntrada = null;
                    else
                        ((Data.ContaPagamentoMovimento)input).documentoTransferenciaEntrada = (Data.DocumentoTransferencia)(new WS.CRUD.DocumentoTransferencia(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.DocumentoTransferencia(),
                            ((Tables.ContaPagamentoMovimento)bd).documentoTransferenciaEntrada,
                            level + 1
                        );

                    //DocumentoTransferenciaSaida
                    if (((Tables.ContaPagamentoMovimento)bd).documentoTransferenciaSaida.idDocumentoTransferencia.value == 0)
                        ((Data.ContaPagamentoMovimento)input).documentoTransferenciaSaida = null;
                    else
                        ((Data.ContaPagamentoMovimento)input).documentoTransferenciaSaida = (Data.DocumentoTransferencia)(new WS.CRUD.DocumentoTransferencia(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.DocumentoTransferencia(),
                            ((Tables.ContaPagamentoMovimento)bd).documentoTransferenciaSaida,
                            level + 1
                        );

                    ((Data.ContaPagamentoMovimento)input).idDocumentoTransferenciaItem = ((Tables.ContaPagamentoMovimento)bd).idDocumentoTransferenciaItem.value;

                    ((Data.ContaPagamentoMovimento)input).valor = ((Tables.ContaPagamentoMovimento)bd).valor.value;
                    ((Data.ContaPagamentoMovimento)input).dataConciliacao = ((Tables.ContaPagamentoMovimento)bd).dataConciliacao.value;

                    ((Data.ContaPagamentoMovimento)input).valorMulta = ((Tables.ContaPagamentoMovimento)bd).valorMulta.value;
                    ((Data.ContaPagamentoMovimento)input).valorJuros = ((Tables.ContaPagamentoMovimento)bd).valorJuros.value;
                    ((Data.ContaPagamentoMovimento)input).valorDesconto = ((Tables.ContaPagamentoMovimento)bd).valorDesconto.value;
                    ((Data.ContaPagamentoMovimento)input).valorCM = ((Tables.ContaPagamentoMovimento)bd).valorCM.value;
                    ((Data.ContaPagamentoMovimento)input).valorINSSRetido = ((Tables.ContaPagamentoMovimento)bd).valorINSSRetido.value;
                    ((Data.ContaPagamentoMovimento)input).valorISSRetido = ((Tables.ContaPagamentoMovimento)bd).valorISSRetido.value;
                    ((Data.ContaPagamentoMovimento)input).valorIRRetido = ((Tables.ContaPagamentoMovimento)bd).valorIRRetido.value;
                    ((Data.ContaPagamentoMovimento)input).valorPISRetido = ((Tables.ContaPagamentoMovimento)bd).valorPISRetido.value;
                    ((Data.ContaPagamentoMovimento)input).valorCOFINSRetido = ((Tables.ContaPagamentoMovimento)bd).valorCOFINSRetido.value;
                    ((Data.ContaPagamentoMovimento)input).valorCSLLRetido = ((Tables.ContaPagamentoMovimento)bd).valorCSLLRetido.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoMovimento result = (Data.ContaPagamentoMovimento)parametros["Key"];

            try
            {
                result = (Data.ContaPagamentoMovimento)this.preencher
                (
                    new Data.ContaPagamentoMovimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContaPagamentoMovimento),
                        new Object[]
                        {
                            result.idContaPagamentoMovimento
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

            Data.ContaPagamentoMovimento _input = (Data.ContaPagamentoMovimento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContaPagamentoMovimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.idContaPagamentoMovimento = @idContaPagamentoMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamentoMovimento", _input.idContaPagamentoMovimento));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.idContaPagamentoMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.idContaPagamentoMovimento");
                    else { }
                }
                else { }

                if (_input.contaPagamento != null)
                {
                    if (_input.contaPagamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.contaPagamento.idEmpresa));
                        if (!sqlOrderBy.Contains("contaPagamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.contaPagamento.idContaPagamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.idContaPagamento = @idContaPagamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.contaPagamento.idContaPagamento));
                        if (!sqlOrderBy.Contains("contaPagamento.idContaPagamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.idContaPagamento");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.contaPagamento.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.descricao like @contaPagamentoDescricao");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("contaPagamentoDescricao", '%' + _input.contaPagamento.descricao + '%'));
                        if (!sqlOrderBy.Contains("contaPagamento.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.descricao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", '%' + _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.observacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.observacao like @observacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("observacao", '%' + _input.observacao + '%'));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.observacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.observacao");
                    else { }
                }
                else { }

                if (_input.documentoRecebimento != null && _input.documentoRecebimento.idDocumentoRecebimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.idDocumentoRecebimento = @idDocumentoRecebimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoRecebimento", _input.documentoRecebimento.idDocumentoRecebimento));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.idDocumentoRecebimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.idDocumentoRecebimento");
                    else { }
                }
                else { }

                if (_input.documentoPagamento != null && _input.documentoPagamento.idDocumentoPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.idDocumentoPagamento = @idDocumentoPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoPagamento", _input.documentoPagamento.idDocumentoPagamento));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.idDocumentoPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.idDocumentoPagamento");
                    else { }
                }
                else { }

                if (_input.documentoTransferenciaEntrada != null && _input.documentoTransferenciaEntrada.idDocumentoTransferencia > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.idDocumentoTransferenciaEntrada = @idDocumentoTransferenciaEntrada");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoTransferenciaEntrada", _input.documentoTransferenciaEntrada.idDocumentoTransferencia));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.idDocumentoTransferenciaEntrada"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.idDocumentoTransferenciaEntrada");
                    else { }
                }
                else { }

                if (_input.documentoTransferenciaSaida != null && _input.documentoTransferenciaSaida.idDocumentoTransferencia > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.idDocumentoTransferenciaSaida = @idDocumentoTransferenciaSaida");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoTransferenciaSaida", _input.documentoTransferenciaSaida.idDocumentoTransferencia));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.idDocumentoTransferenciaSaida"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.idDocumentoTransferenciaSaida");
                    else { }
                }
                else { }

                if (_input.valor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoMovimento.valor = @valor");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valor", _input.valor));
                    if (!sqlOrderBy.Contains("contaPagamentoMovimento.valor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoMovimento.valor");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contaPagamentoMovimento.* ") +
                    "from " +
                    "   contaPagamento " +
                    "       inner join contaPagamentoMovimento " +
                    "            on	contaPagamentoMovimento.idContaPagamento = contaPagamento.idContaPagamento " +
                    " " +
                    //"       --Documento de Pagamento " +
                    "       left join documentoPagamento " +
                    "          on	documentoPagamento.idDocumentoPagamento = contaPagamentoMovimento.idDocumentoPagamento  and " +
                    "               documentoPagamento.dataCancelamento is null " +
                    " " +
                    //"       --Documento de Recebimento " +
                    "       left join documentoRecebimento " +
                    "           on	documentoRecebimento.idDocumentoRecebimento = contaPagamentoMovimento.idDocumentoRecebimento " +
                    " " +
                    //"       --Documento Transferencia de Entrada " +
                    "       left join documentoTransferenciaItem documentoTransferenciaEntrada " +
                    "           on	documentoTransferenciaEntrada.idDocumentoTransferencia = contaPagamentoMovimento.idDocumentoTransferenciaEntrada and " +
                    "               documentoTransferenciaEntrada.idDocumentoTransferenciaItem = contaPagamentoMovimento.idDocumentoTransferenciaItem " +
                    " " +
                    //"       --Documento Transferencia de Saida " +
                    "       left join documentoTransferenciaItem documentoTransferenciaSaida " +
                    "           on	documentoTransferenciaSaida.idDocumentoTransferencia = contaPagamentoMovimento.idDocumentoTransferenciaSaida and " +
                    "               documentoTransferenciaSaida.idDocumentoTransferenciaItem = contaPagamentoMovimento.idDocumentoTransferenciaItem " +
                    " " +
                    //"       --Verifica se Documento de Recebimento tem Transferencia " +
                    "       left join documentoTransferenciaItem documentoRecebimentoTransferido " +
                    "           on	documentoRecebimentoTransferido.idDocumentoRecebimentoTransferido = documentoRecebimento.idDocumentoRecebimento " +
                    " " +
                    //"       --Verifica se Documento de Transferencia de Entrada tem transferencia " +
                    "       left join documentoTransferenciaItem documentoTransferenciaEntradaTransferido " +
                    "           on	documentoTransferenciaEntradaTransferido.idDocumentoTransferenciaTransferidoItem = documentoTransferenciaEntrada.idDocumentoTransferenciaItem " +
                    "       left join documentoTransferencia documentoTransferenciaEntradaPai ON documentoTransferenciaEntrada.idDocumentoTransferencia = documentoTransferenciaEntradaPai.idDocumentoTransferencia " +
                    "where " +
                        "   ( " +
                        "       contaPagamentoMovimento.idDocumentoPagamento is not null or " +
                        "       contaPagamentoMovimento.idDocumentoRecebimento is not null or " +
                        "       contaPagamentoMovimento.idDocumentoTransferenciaEntrada is not null or " +
                        "       contaPagamentoMovimento.idDocumentoTransferenciaSaida is not null " +
                        "   ) " +
                    (sqlWhere.Length > 0 ? " and " + sqlWhere : "") +
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
            Data.ContaPagamentoMovimento input = (Data.ContaPagamentoMovimento)parametros["Key"];
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
                    typeof(Tables.ContaPagamentoMovimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContaPagamentoMovimento _data in
                    (System.Collections.Generic.List<Tables.ContaPagamentoMovimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContaPagamentoMovimento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.ContaPagamentoMovimento();
                        ((Data.ContaPagamentoMovimento)_base).idContaPagamentoMovimento = _data.idContaPagamentoMovimento.value;
                        ((Data.ContaPagamentoMovimento)_base).descricao = _data.descricao.value;
                        ((Data.ContaPagamentoMovimento)_base).observacao = _data.observacao.value;
                        ((Data.ContaPagamentoMovimento)_base).dataMovimento = _data.dataMovimento.value;
                        ((Data.ContaPagamentoMovimento)_base).valor = _data.valor.value;
                        ((Data.ContaPagamentoMovimento)_base).documentoRecebimento = new Data.DocumentoRecebimento();
                        if (_data.documentoPagamento.idDocumentoPagamento.value > 0) //Pagamento
                            ((Data.ContaPagamentoMovimento)_base).documentoRecebimento.numeroDocumento = _data.documentoPagamento.numeroDocumento.value;
                        else
                        {
                            if (_data.documentoRecebimento.idDocumentoRecebimento.value > 0)
                            { //Recebimento
                                ((Data.ContaPagamentoMovimento)_base).documentoRecebimento.idDocumentoRecebimento = _data.documentoRecebimento.idDocumentoRecebimento.value;
                                ((Data.ContaPagamentoMovimento)_base).documentoRecebimento.numeroDocumento = _data.documentoRecebimento.numeroDocumento.value;
                                ((Data.ContaPagamentoMovimento)_base).dataVencimento = _data.documentoRecebimento.dataVencimento.value;
                                ((Data.ContaPagamentoMovimento)_base).documentoRecebimento.dataVencimento = _data.documentoRecebimento.dataVencimento.value;
                            }
                            else
                            {
                                if (_data.documentoTransferenciaEntrada.idDocumentoTransferencia.value > 0) //Transferência entrada
                                    ((Data.ContaPagamentoMovimento)_base).documentoRecebimento.numeroDocumento = _data.documentoTransferenciaEntrada.numeroDocumento.value;
                                else
                                {
                                    if (_data.documentoTransferenciaSaida.idDocumentoTransferencia.value > 0) //Transferência saída
                                        ((Data.ContaPagamentoMovimento)_base).documentoRecebimento.numeroDocumento = _data.documentoTransferenciaSaida.numeroDocumento.value;
                                    else
                                    {

                                    }
                                }

                            }
                        }
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContaPagamentoMovimento(), _data, level);

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
