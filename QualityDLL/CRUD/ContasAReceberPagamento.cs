using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WS.CRUD
{
    public class ContasAReceberPagamento : WS.CRUD.Base
    {
        public ContasAReceberPagamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberPagamento input = (Data.ContasAReceberPagamento)parametros["Key"];
            Tables.ContasAReceberPagamento bd = new Tables.ContasAReceberPagamento();

            bd.idContasAReceberPagamento.isNull = true;
            bd.idContasAReceber.value = input.idContasAReceber;
            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else
                bd.contaPagamento.idContaPagamento.isNull = true;
            bd.dataMovimento.value = input.dataMovimento;
            bd.valorPrincipal.value = input.valorPrincipal;
            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;

            if (input.contasAReceberRecibo != null && input.contasAReceberRecibo.idContasAReceberRecibo > 0)
                bd.contasAReceberRecibo.idContasAReceberRecibo.value = input.contasAReceberRecibo.idContasAReceberRecibo;
            else
                bd.contasAReceberRecibo.idContasAReceberRecibo.isNull = true;

            if (input.idFuncionario > 0)
                bd.idFuncionario.value = input.idFuncionario;
            else
                bd.idFuncionario.isNull = true;

            if (input.idDocumentoRecebimento > 0)
                bd.idDocumentoRecebimento.value = input.idDocumentoRecebimento;
            else
                bd.idDocumentoRecebimento.isNull = true;

            if (input.idPdvEstacao > 0)
                bd.idPdvEstacao.value = input.idPdvEstacao;
            else
                bd.idPdvEstacao.isNull = true;

            if (input.pdvCompraTaxaServico != null && input.pdvCompraTaxaServico.idPdvCompraTaxaServico > 0)
                bd.pdvCompraTaxaServico.idPdvCompraTaxaServico.value = input.pdvCompraTaxaServico.idPdvCompraTaxaServico;
            else
                bd.pdvCompraTaxaServico.idPdvCompraTaxaServico.isNull = true;

            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else
                bd.pdvCompra.idPdvCompra.isNull = true;

            //Incluir/Alterar Recibo

            if (!input.ignorarRecibo)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                if (input.contasAReceberRecibo == null)
                {
                    input.contasAReceberRecibo = new Data.ContasAReceberRecibo
                    {
                        operacao = ENum.eOperacao.INCLUIR,
                        dataRecibo = input.dataMovimento,
                        valorTotal = input.valorPrincipal,
                        descontoTotal = input.valorDesconto,
                        jurosTotal = input.valorJuros,
                        multaTotal = input.valorMulta
                    };
                }

                if (input.contasAReceberRecibo != null)
                {
                    _parametros.Add("Key", input.contasAReceberRecibo);

                    if (input.contasAReceberRecibo.idContasAReceberRecibo <= 0)
                    {
                        input.contasAReceberRecibo.operacao = ENum.eOperacao.INCLUIR;
                        input.contasAReceberRecibo = (Data.ContasAReceberRecibo)(new WS.CRUD.ContasAReceberRecibo(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parametros);
                    }
                    else if (input.contasAReceberRecibo.operacao == ENum.eOperacao.ALTERAR)
                        input.contasAReceberRecibo = (Data.ContasAReceberRecibo)(new WS.CRUD.ContasAReceberRecibo(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);

                    if (input.contasAReceberRecibo != null && input.contasAReceberRecibo.idContasAReceberRecibo > 0)
                        bd.contasAReceberRecibo.idContasAReceberRecibo.value = input.contasAReceberRecibo.idContasAReceberRecibo;
                }
                _parametros.Clear();
                _parametros = null;
            }

            this.m_EntityManager.persist(bd);

            ((Data.ContasAReceberPagamento)parametros["Key"]).idContasAReceberPagamento = (int)bd.idContasAReceberPagamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberPagamento input = (Data.ContasAReceberPagamento)parametros["Key"];
            Tables.ContasAReceberPagamento bd = (Tables.ContasAReceberPagamento)this.m_EntityManager.find
            (
                typeof(Tables.ContasAReceberPagamento),
                new Object[]
                {
                    input.idContasAReceberPagamento
                }
            );

            bd.idContasAReceber.value = input.idContasAReceber;
            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else
                bd.contaPagamento.idContaPagamento.isNull = true;
            bd.dataMovimento.value = input.dataMovimento;

            bd.valorPrincipal.value = input.valorPrincipal;
            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;
            if (input.idFuncionario > 0)
                bd.idFuncionario.value = input.idFuncionario;
            else
                bd.idFuncionario.isNull = true;
            if (input.idDocumentoRecebimento > 0)
                bd.idDocumentoRecebimento.value = input.idDocumentoRecebimento;
            else
                bd.idDocumentoRecebimento.isNull = true;

            if (input.idPdvEstacao > 0)
                bd.idPdvEstacao.value = input.idPdvEstacao;
            else
                bd.idPdvEstacao.isNull = true;

            if (input.pdvCompraTaxaServico != null && input.pdvCompraTaxaServico.idPdvCompraTaxaServico > 0)
                bd.pdvCompraTaxaServico.idPdvCompraTaxaServico.value = input.pdvCompraTaxaServico.idPdvCompraTaxaServico;
            else
                bd.pdvCompraTaxaServico.idPdvCompraTaxaServico.isNull = true;

            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else
                bd.pdvCompra.idPdvCompra.isNull = true;

            if (input.contasAReceberRecibo != null && input.contasAReceberRecibo.idContasAReceberRecibo > 0)
                bd.contasAReceberRecibo.idContasAReceberRecibo.value = input.contasAReceberRecibo.idContasAReceberRecibo;
            else
                bd.contasAReceberRecibo.idContasAReceberRecibo.isNull = true;

            //Incluir/Alterar Recibo
            if (!input.ignorarRecibo)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                if (input.contasAReceberRecibo == null)
                {
                    input.contasAReceberRecibo = new Data.ContasAReceberRecibo
                    {
                        operacao = ENum.eOperacao.INCLUIR,
                        dataRecibo = input.dataMovimento,
                        valorTotal = input.valorPrincipal,
                        descontoTotal = input.valorDesconto,
                        jurosTotal = input.valorJuros,
                        multaTotal = input.valorMulta
                    };
                }

                if (input.contasAReceberRecibo != null)
                {
                    _parametros.Add("Key", input.contasAReceberRecibo);
                    if (input.contasAReceberRecibo.idContasAReceberRecibo <= 0)
                    {
                        input.contasAReceberRecibo.operacao = ENum.eOperacao.INCLUIR;
                        input.contasAReceberRecibo = (Data.ContasAReceberRecibo)(new WS.CRUD.ContasAReceberRecibo(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parametros);
                    }
                    else if (input.contasAReceberRecibo.operacao == ENum.eOperacao.ALTERAR)
                        input.contasAReceberRecibo = (Data.ContasAReceberRecibo)(new WS.CRUD.ContasAReceberRecibo(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);

                    if (input.contasAReceberRecibo != null && input.contasAReceberRecibo.idContasAReceberRecibo > 0)
                        bd.contasAReceberRecibo.idContasAReceberRecibo.value = input.contasAReceberRecibo.idContasAReceberRecibo;
                }
                _parametros.Clear();
                _parametros = null;
            }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAReceberPagamento bd = new Tables.ContasAReceberPagamento();

            bd.idContasAReceberPagamento.value = ((Data.ContasAReceberPagamento)parametros["Key"]).idContasAReceberPagamento;

            this.m_EntityManager.remove(bd);

            /* removendo recibo */
            if (((Data.ContasAReceberPagamento)parametros["Key"]).contasAReceberRecibo != null && ((Data.ContasAReceberPagamento)parametros["Key"]).contasAReceberRecibo.idContasAReceberRecibo > 0)
            {
                Data.ContasAReceberPagamento cr = new Data.ContasAReceberPagamento
                {
                    idContasAReceber = ((Data.ContasAReceberPagamento)parametros["Key"]).idContasAReceber
                };
                Hashtable _parametros = new Hashtable();
                _parametros.Add("Key", cr);
                _parametros.Add("Level", 2);
                Data.Base[] list = (Data.Base[])(new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).listar(_parametros);
                if (list == null || (list != null && list.Length == 0))
                {
                    Tables.ContasAReceberRecibo bdRecibo = new Tables.ContasAReceberRecibo();
                    bdRecibo.idContasAReceberRecibo.value = ((Data.ContasAReceberPagamento)parametros["Key"]).contasAReceberRecibo.idContasAReceberRecibo;
                    this.m_EntityManager.remove(bdRecibo);
                }
                else
                {
                    Tables.ContasAReceberRecibo bdRecibo = new Tables.ContasAReceberRecibo();
                    bdRecibo = (Tables.ContasAReceberRecibo)this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceberRecibo),
                        new Object[]
                        {
                            ((Data.ContasAReceberPagamento)parametros["Key"]).contasAReceberRecibo.idContasAReceberRecibo
                        }
                    );
                    if (bdRecibo.idContasAReceberRecibo.value > 0)
                    {
                        bdRecibo.valorTotal.value = list.Cast<Data.ContasAReceberPagamento>().Sum(T => T.valorPrincipal + T.valorJuros + T.valorMulta - T.valorDesconto);
                        this.m_EntityManager.merge(bdRecibo);
                    }
                }
            }
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAReceberPagamento)bd).idContasAReceberPagamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAReceberPagamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAReceberPagamento)input).idContasAReceberPagamento = ((Tables.ContasAReceberPagamento)bd).idContasAReceberPagamento.value;
                    ((Data.ContasAReceberPagamento)input).idContasAReceber = ((Tables.ContasAReceberPagamento)bd).idContasAReceber.value;
                    ((Data.ContasAReceberPagamento)input).dataMovimento = ((Tables.ContasAReceberPagamento)bd).dataMovimento.value;
                    ((Data.ContasAReceberPagamento)input).valorPrincipal = ((Tables.ContasAReceberPagamento)bd).valorPrincipal.value;
                    ((Data.ContasAReceberPagamento)input).valorMulta = ((Tables.ContasAReceberPagamento)bd).valorMulta.value;
                    ((Data.ContasAReceberPagamento)input).valorJuros = ((Tables.ContasAReceberPagamento)bd).valorJuros.value;
                    ((Data.ContasAReceberPagamento)input).valorDesconto = ((Tables.ContasAReceberPagamento)bd).valorDesconto.value;
                    ((Data.ContasAReceberPagamento)input).idFuncionario = ((Tables.ContasAReceberPagamento)bd).idFuncionario.value;
                    ((Data.ContasAReceberPagamento)input).valorCM = ((Tables.ContasAReceberPagamento)bd).valorCM.value;
                    ((Data.ContasAReceberPagamento)input).idPdvEstacao = ((Tables.ContasAReceberPagamento)bd).idPdvEstacao.value;

                    ((Data.ContasAReceberPagamento)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.ContasAReceberPagamento)bd).contaPagamento,
                        level + 1
                    );
                    ((Data.ContasAReceberPagamento)input).contasAReceberRecibo = (Data.ContasAReceberRecibo)(new WS.CRUD.ContasAReceberRecibo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceberRecibo(),
                        ((Tables.ContasAReceberPagamento)bd).contasAReceberRecibo,
                        level + 1
                    );
                    ((Data.ContasAReceberPagamento)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.ContasAReceberPagamento)bd).tipoMovimentoContabil,
                        level + 1
                    );
                    ((Data.ContasAReceberPagamento)input).valorINSSRetido = ((Tables.ContasAReceberPagamento)bd).valorINSSRetido.value;
                    ((Data.ContasAReceberPagamento)input).valorISSRetido = ((Tables.ContasAReceberPagamento)bd).valorISSRetido.value;
                    ((Data.ContasAReceberPagamento)input).valorIRRetido = ((Tables.ContasAReceberPagamento)bd).valorIRRetido.value;
                    ((Data.ContasAReceberPagamento)input).valorPISRetido = ((Tables.ContasAReceberPagamento)bd).valorPISRetido.value;
                    ((Data.ContasAReceberPagamento)input).valorCOFINSRetido = ((Tables.ContasAReceberPagamento)bd).valorCOFINSRetido.value;
                    ((Data.ContasAReceberPagamento)input).valorCSLLRetido = ((Tables.ContasAReceberPagamento)bd).valorCSLLRetido.value;
                    if (!((Tables.ContasAReceberPagamento)bd).idDocumentoRecebimento.isNull)
                    {
                        ((Data.ContasAReceberPagamento)input).idDocumentoRecebimento = ((Tables.ContasAReceberPagamento)bd).idDocumentoRecebimento.value;
                        try
                        {
                            Hashtable _params = new Hashtable();
                            _params.Add("Key", new Data.DocumentoRecebimento { idDocumentoRecebimento = ((Tables.ContasAReceberPagamento)bd).idDocumentoRecebimento.value });
                            ((Data.ContasAReceberPagamento)input).documentoRecebimento = ((Data.Base[])(new WS.CRUD.DocumentoRecebimento(this.m_IdEmpresaCorrente, this.m_EntityManager).listar(_params))).Cast<Data.DocumentoRecebimento>().ToArray()[0];
                        }
                        catch { }
                    }
                    else { }

                    ((Data.ContasAReceberPagamento)input).pdvCompraTaxaServico = (Data.PdvCompraTaxaServico)(new WS.CRUD.PdvCompraTaxaServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvCompraTaxaServico(),
                        ((Tables.ContasAReceberPagamento)bd).pdvCompraTaxaServico,
                        level + 1
                    );

                    ((Data.ContasAReceberPagamento)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvCompra(),
                        ((Tables.ContasAReceberPagamento)bd).pdvCompra,
                        level + 1
                    );
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberPagamento result = (Data.ContasAReceberPagamento)parametros["Key"];

            try
            {
                result = (Data.ContasAReceberPagamento)this.preencher
                (
                    new Data.ContasAReceberPagamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceberPagamento),
                        new Object[]
                        {
                            result.idContasAReceberPagamento
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
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

            Data.ContasAReceberPagamento _input = (Data.ContasAReceberPagamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAReceberPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idContasAReceberPagamento = @idContasAReceberPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceberPagamento", _input.idContasAReceberPagamento));
                    if (!sqlOrderBy.Contains("contasAReceberPagamento.idContasAReceberPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idContasAReceberPagamento");
                    else { }
                }
                else { }

                if (_input.idDocumentoRecebimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idDocumentoRecebimento = @idDocumentoRecebimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoRecebimento", _input.idDocumentoRecebimento));
                    if (!sqlOrderBy.Contains("contasAReceberPagamento.idDocumentoRecebimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idDocumentoRecebimento");
                    else { }
                }
                else { }

                if (_input.idContasAReceber > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idContasAReceber = @idContasAReceber");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", _input.idContasAReceber));
                    if (!sqlOrderBy.Contains("contasAReceberPagamento.idContasAReceber"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idContasAReceber");
                    else { }
                }
                else { }

                if (_input.idPdvEstacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idPdvEstacao = @idPdvEstacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.idPdvEstacao));
                    if (!sqlOrderBy.Contains("contasAReceberPagamento.idPdvEstacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idPdvEstacao");
                    else { }
                }
                else { }

                if (_input.idFuncionario > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idFuncionario = @idFuncionario");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.idFuncionario));
                    if (!sqlOrderBy.Contains("contasAReceberPagamento.idFuncionario"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idFuncionario");
                    else { }
                }
                else { }

                if (_input.contasAReceberRecibo != null)
                {
                    if (_input.contasAReceberRecibo.idContasAReceberRecibo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idContasAReceberRecibo = @idContasAReceberRecibo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceberRecibo", _input.contasAReceberRecibo.idContasAReceberRecibo));
                        if (!sqlOrderBy.Contains("contasAReceberPagamento.idContasAReceberRecibo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idContasAReceberRecibo");
                        else { }
                    }
                }
                else { }

                if (_input.pdvCompra != null)
                {
                    if (_input.pdvCompra.idPdvCompra > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idPdvCompra = @idPdvCompra");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.pdvCompra.idPdvCompra));
                        if (!sqlOrderBy.Contains("contasAReceberPagamento.idPdvCompra"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idPdvCompra");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.documentoRecebimento != null)
                {
                    if (_input.documentoRecebimento.idDocumentoRecebimento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberPagamento.idDocumentoRecebimento = @idDocumentoRecebimento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoRecebimento", _input.documentoRecebimento.idDocumentoRecebimento));
                        if (!sqlOrderBy.Contains("contasAReceberPagamento.idDocumentoRecebimento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberPagamento.idDocumentoRecebimento");
                        else { }
                    }
                    else { }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contasAReceberPagamento.* ") +
                    "from \n" +
                    "   contasAReceberPagamento " +
                    " LEFT JOIN pdvEstacoes ON pdvEstacoes.idPdvEstacao = contasAReceberPagamento.idPdvEstacao\n" +

                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
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
            Data.ContasAReceberPagamento input = (Data.ContasAReceberPagamento)parametros["Key"];
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
                    typeof(Tables.ContasAReceberPagamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAReceberPagamento _data in
                    (System.Collections.Generic.List<Tables.ContasAReceberPagamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAReceberPagamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContasAReceberPagamento(), _data, level);

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
                Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
