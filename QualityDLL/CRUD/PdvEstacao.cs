using System;

namespace WS.CRUD
{
    public class PdvEstacao : WS.CRUD.Base
    {
        public PdvEstacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacao input = (Data.PdvEstacao)parametros["Key"];
            Tables.PdvEstacao bd = new Tables.PdvEstacao();

            bd.idPdvEstacao.isNull = true;
            bd.idPdvEstacao.value = input.idPdvEstacao;
            bd.aplicarTaxaServico.value = input.aplicarTaxaServico;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if (input.departamentoOrigem != null && input.departamentoOrigem.idDepartamento > 0)
                bd.departamentoOrigem.idDepartamento.value = input.departamentoOrigem.idDepartamento;
            else { }

            if (input.prePagoDepartamento != null && input.prePagoDepartamento.idDepartamento > 0)
                bd.prePagoDepartamento.idDepartamento.value = input.prePagoDepartamento.idDepartamento;
            else { }

            if (input.posPagoNaturezaOperacao != null && input.posPagoNaturezaOperacao.idNaturezaOperacao > 0)
                bd.posPagoNaturezaOperacao.idNaturezaOperacao.value = input.posPagoNaturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.prePagoNaturezaOperacao != null && input.prePagoNaturezaOperacao.idNaturezaOperacao > 0)
                bd.prePagoNaturezaOperacao.idNaturezaOperacao.value = input.prePagoNaturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.prePagoNaturezaOperacaoEstorno != null && input.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao > 0)
                bd.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao.value = input.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao;
            else { }
            bd.habilitarPrePago.value = input.habilitarPrePago;
            bd.habilitarPosPago.value = input.habilitarPosPago;

            if (input.aberturaCaixaAtual != null && input.aberturaCaixaAtual.idPdvEstacaoAberturaCaixa > 0)
                bd.aberturaCaixaAtual.idPdvEstacaoAberturaCaixa.value = input.aberturaCaixaAtual.idPdvEstacaoAberturaCaixa;
            else { }

            bd.descricao.value = input.descricao;
            bd.confirmacaoGerente.value = input.confirmacaoGerente;
            bd.habilitarNotaPromissoria.value = input.habilitarNotaPromissoria;
            bd.habilitarDescontoTotal.value = input.habilitarDescontoTotal;
            bd.agruparProdutosCupom.value = input.agruparProdutosCupom;

            if (input.aparelhoSat != null && input.aparelhoSat.idAparelhoSat > 0)
                bd.aparelhoSat.idAparelhoSat.value = input.aparelhoSat.idAparelhoSat;
            else { }

            if (input.cliente != null && input.cliente.idEmpresaRelacionamento > 0)
                bd.cliente.clienteEmpresaRelacionamento.idEmpresaRelacionamento.value = input.cliente.idEmpresaRelacionamento;
            else { }

            bd.pos.value = input.pos == "s" ? true : false;

            if (input.idContaPagamentoDesconto > 0)
                bd.idContaPagamentoDesconto.value = input.idContaPagamentoDesconto;
            else
                bd.idContaPagamentoDesconto.isNull = true;

            this.m_EntityManager.persist(bd);
            ((Data.PdvEstacao)parametros["Key"]).idPdvEstacao = (int)bd.idPdvEstacao.value;

            if (input.pdvEstacaoConfig != null)
            {
                WS.CRUD.PdvEstacoesConfig pdvEstacoesConfigCRUD = new WS.CRUD.PdvEstacoesConfig(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvEstacaoConfig.Length; i++)
                {
                    input.pdvEstacaoConfig[i].idPdvEstacao = bd.idPdvEstacao.value;
                    _parameters.Add("Key", input.pdvEstacaoConfig[i]);
                    pdvEstacoesConfigCRUD.atualizar(_parameters);
                    if (input.pdvEstacaoConfig[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pdvEstacaoConfig[i] = (Data.PdvEstacoesConfig)pdvEstacoesConfigCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacao input = (Data.PdvEstacao)parametros["Key"];
            Tables.PdvEstacao bd = (Tables.PdvEstacao)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacao),
                new Object[]
                {
                    input.idPdvEstacao
                }
            );

            bd.idPdvEstacao.value = input.idPdvEstacao;
            bd.aplicarTaxaServico.value = input.aplicarTaxaServico;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if (input.departamentoOrigem != null && input.departamentoOrigem.idDepartamento > 0)
                bd.departamentoOrigem.idDepartamento.value = input.departamentoOrigem.idDepartamento;
            else { }

            if (input.aberturaCaixaAtual != null && input.aberturaCaixaAtual.idPdvEstacaoAberturaCaixa > 0)
                bd.aberturaCaixaAtual.idPdvEstacaoAberturaCaixa.value = input.aberturaCaixaAtual.idPdvEstacaoAberturaCaixa;
            else { }

            bd.descricao.value = input.descricao;
            bd.confirmacaoGerente.value = input.confirmacaoGerente;
            bd.habilitarNotaPromissoria.value = input.habilitarNotaPromissoria;
            bd.habilitarDescontoTotal.value = input.habilitarDescontoTotal;
            bd.agruparProdutosCupom.value = input.agruparProdutosCupom;
            bd.pos.value = input.pos == "s" ? true : false;
            if (input.aparelhoSat != null && input.aparelhoSat.idAparelhoSat > 0)
                bd.aparelhoSat.idAparelhoSat.value = input.aparelhoSat.idAparelhoSat;
            else { }

            if (input.posPagoNaturezaOperacao != null && input.posPagoNaturezaOperacao.idNaturezaOperacao > 0)
                bd.posPagoNaturezaOperacao.idNaturezaOperacao.value = input.posPagoNaturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else { }

            bd.prePagoDepartamento.idDepartamento.isNull = true;
            if (input.prePagoDepartamento != null && input.prePagoDepartamento.idDepartamento > 0)
                bd.prePagoDepartamento.idDepartamento.value = input.prePagoDepartamento.idDepartamento;
            else { }

            bd.prePagoNaturezaOperacao.idNaturezaOperacao.isNull = true;
            if (input.prePagoNaturezaOperacao != null && input.prePagoNaturezaOperacao.idNaturezaOperacao > 0)
                bd.prePagoNaturezaOperacao.idNaturezaOperacao.value = input.prePagoNaturezaOperacao.idNaturezaOperacao;
            else { }

            bd.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao.isNull = true;
            if (input.prePagoNaturezaOperacaoEstorno != null && input.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao > 0)
                bd.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao.value = input.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao;
            else { }
            bd.habilitarPrePago.value = input.habilitarPrePago;
            bd.habilitarPosPago.value = input.habilitarPosPago;

            if (input.idContaPagamentoDesconto > 0)
                bd.idContaPagamentoDesconto.value = input.idContaPagamentoDesconto;
            else
                bd.idContaPagamentoDesconto.isNull = true;

            if (input.cliente != null && input.cliente.idEmpresaRelacionamento > 0)
                bd.cliente.clienteEmpresaRelacionamento.idEmpresaRelacionamento.value = input.cliente.idEmpresaRelacionamento;
            else
                bd.cliente.clienteEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa PdvEstacoesConfig
            if (input.pdvEstacaoConfig != null)
            {
                WS.CRUD.PdvEstacoesConfig pdvEstacoesConfigCRUD = new WS.CRUD.PdvEstacoesConfig(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvEstacaoConfig.Length; i++)
                {
                    input.pdvEstacaoConfig[i].idPdvEstacao = bd.idPdvEstacao.value;
                    _parameters.Add("Key", input.pdvEstacaoConfig[i]);
                    if (input.pdvEstacaoConfig[i].operacao == ENum.eOperacao.NONE)
                        input.pdvEstacaoConfig[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pdvEstacoesConfigCRUD.atualizar(_parameters);
                    if (input.pdvEstacaoConfig[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pdvEstacaoConfig[i] = (Data.PdvEstacoesConfig)pdvEstacoesConfigCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacao bd = new Tables.PdvEstacao();
            Data.PdvEstacao input = (Data.PdvEstacao)parametros["Key"];

            /* Excluir Configs*/
            {
                WS.CRUD.PdvEstacao pdvEstacoesCRUD = new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();
                _parameters.Add("Key", input);
                try
                {
                    input.pdvEstacaoConfig = (Data.PdvEstacoesConfig[])pdvEstacoesCRUD.listar(_parameters);
                }
                catch
                {
                    input.pdvEstacaoConfig = null;
                }

                if (input.pdvEstacaoConfig != null && input.pdvEstacaoConfig.Length > 0)
                {
                    _parameters.Clear();
                    PdvEstacao pdvEstacoesConfigCRUD = new PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    for (int i = 0; i < input.pdvEstacaoConfig.Length; i++)
                    {
                        input.pdvEstacaoConfig[i].operacao = ENum.eOperacao.EXCLUIR;
                        _parameters.Add("Key", input.pdvEstacaoConfig[i]);
                        pdvEstacoesConfigCRUD.atualizar(_parameters);
                        _parameters.Clear();
                    }
                }
            }

            bd.idPdvEstacao.value = ((Data.PdvEstacao)parametros["Key"]).idPdvEstacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacao)bd).idPdvEstacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacao)input).operacao = ENum.eOperacao.NONE;
                    ((Data.PdvEstacao)input).confirmacaoGerente = ((Tables.PdvEstacao)bd).confirmacaoGerente.value;
                    ((Data.PdvEstacao)input).habilitarNotaPromissoria = ((Tables.PdvEstacao)bd).habilitarNotaPromissoria.value;
                    ((Data.PdvEstacao)input).habilitarDescontoTotal = ((Tables.PdvEstacao)bd).habilitarDescontoTotal.value;
                    ((Data.PdvEstacao)input).habilitarPrePago = ((Tables.PdvEstacao)bd).habilitarPrePago.value;
                    ((Data.PdvEstacao)input).habilitarPosPago = ((Tables.PdvEstacao)bd).habilitarPosPago.value;
                    ((Data.PdvEstacao)input).agruparProdutosCupom = ((Tables.PdvEstacao)bd).agruparProdutosCupom.value;
                    ((Data.PdvEstacao)input).idPdvEstacao = ((Tables.PdvEstacao)bd).idPdvEstacao.value;
                    ((Data.PdvEstacao)input).descricao = ((Tables.PdvEstacao)bd).descricao.value;
                    ((Data.PdvEstacao)input).aberto = ((Tables.PdvEstacao)bd).aberto;
                    ((Data.PdvEstacao)input).aplicarTaxaServico = ((Tables.PdvEstacao)bd).aplicarTaxaServico.value;
                    ((Data.PdvEstacao)input).pos = ((Tables.PdvEstacao)bd).pos.value ? "s" : "n";
                    ((Data.PdvEstacao)input).idContaPagamentoDesconto = ((Tables.PdvEstacao)bd).idContaPagamentoDesconto.value;
                    ((Data.PdvEstacao)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.PdvEstacao)bd).departamento,
                        level + 1
                    );
                    ((Data.PdvEstacao)input).aparelhoSat = (Data.AparelhoSat)(new WS.CRUD.AparelhoSat(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.AparelhoSat(),
                        ((Tables.PdvEstacao)bd).aparelhoSat,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).prePagoDepartamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.PdvEstacao)bd).prePagoDepartamento,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).cliente = (Data.Cliente)(new WS.CRUD.Cliente(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Cliente(),
                        ((Tables.PdvEstacao)bd).cliente,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).prePagoNaturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.PdvEstacao)bd).prePagoNaturezaOperacao,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).posPagoNaturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.PdvEstacao)bd).posPagoNaturezaOperacao,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.PdvEstacao)bd).naturezaOperacao,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).prePagoNaturezaOperacaoEstorno = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.PdvEstacao)bd).prePagoNaturezaOperacaoEstorno,
                        level + 1
                    );

                    ((Data.PdvEstacao)input).departamentoOrigem = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.PdvEstacao)bd).departamentoOrigem,
                        level + 1
                    );

                    if (!((Data.PdvEstacao)input).ignorarAberturaCaixa)
                        ((Data.PdvEstacao)input).aberturaCaixaAtual = (Data.PdvEstacoesAberturaCaixa)(new WS.CRUD.PdvEstacoesAberturaCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacoesAberturaCaixa(),
                            ((Tables.PdvEstacao)bd).aberturaCaixaAtual,
                            0
                        );

                    try
                    {
                        Data.DepartamentoFuncionario df = new Data.DepartamentoFuncionario();
                        df.departamento = ((Data.PdvEstacao)input).departamento;
                        df.responsavel = true;

                        df = (Data.DepartamentoFuncionario)Utils.Utils.sr((int)this.m_IdEmpresaCorrente).consultar(df);
                        if (df != null && df.funcionario != null && df.funcionario.idEmpresaRelacionamento > 0)
                            ((Data.PdvEstacao)input).idEmpresaRelacionamentoGerente = df.funcionario.idEmpresaRelacionamento;
                        else { }
                    }
                    catch { }

                    if (level < 1)
                    {

                        if (((Tables.PdvEstacao)bd).pdvEstacaoConfig != null)
                        {
                            System.Collections.Generic.List<Data.PdvEstacoesConfig> _list = new System.Collections.Generic.List<Data.PdvEstacoesConfig>();

                            foreach (Tables.PdvEstacoesConfig _item in ((Tables.PdvEstacao)bd).pdvEstacaoConfig)
                            {
                                _list.Add
                                (
                                    (Data.PdvEstacoesConfig)
                                    (new WS.CRUD.PdvEstacoesConfig(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvEstacoesConfig(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                                 ((Data.PdvEstacao)input).pdvEstacaoConfig = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.PdvEstacao)input).pdvEstacaoConfig != null)
                            {
                                System.Collections.Generic.List<Data.PdvEstacoesConfig> _list = new System.Collections.Generic.List<Data.PdvEstacoesConfig>();

                                foreach (Data.PdvEstacoesConfig _item in ((Data.PdvEstacao)input).pdvEstacaoConfig)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.PdvEstacao)input).pdvEstacaoConfig = _list.ToArray();
                                else
                                    ((Data.PdvEstacao)input).pdvEstacaoConfig = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        if (!((Data.PdvEstacao)input).ignorarAberturaCaixa)
                        {
                            if (((Tables.PdvEstacao)bd).pdvEstacoesAberturaCaixa != null)
                            {
                                System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixa> _list = new System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixa>();

                                foreach (Tables.PdvEstacoesAberturaCaixa _item in ((Tables.PdvEstacao)bd).pdvEstacoesAberturaCaixa)
                                {
                                    _list.Add
                                    (
                                        (Data.PdvEstacoesAberturaCaixa)
                                        (new WS.CRUD.PdvEstacoesAberturaCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.PdvEstacoesAberturaCaixa(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }

                                 ((Data.PdvEstacao)input).pdvEstacoesAberturaCaixa = _list.ToArray();
                                _list.Clear();
                                _list = null;
                            }
                            else
                            {
                                if (((Data.PdvEstacao)input).pdvEstacoesAberturaCaixa != null)
                                {
                                    System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixa> _list = new System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixa>();

                                    foreach (Data.PdvEstacoesAberturaCaixa _item in ((Data.PdvEstacao)input).pdvEstacoesAberturaCaixa)
                                    {
                                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                        {
                                            _item.operacao = ENum.eOperacao.NONE;
                                            _list.Add(_item);
                                        }
                                        else { }
                                    }

                                    if (_list.Count > 0)
                                        ((Data.PdvEstacao)input).pdvEstacoesAberturaCaixa = _list.ToArray();
                                    else
                                        ((Data.PdvEstacao)input).pdvEstacoesAberturaCaixa = null;

                                    _list.Clear();
                                    _list = null;
                                }
                                else { }
                            }

                            if (((Tables.PdvEstacao)bd).pdvEstacoesFechamentoCaixa != null)
                            {
                                System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixa> _list = new System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixa>();

                                foreach (Tables.PdvEstacoesFechamentoCaixa _item in ((Tables.PdvEstacao)bd).pdvEstacoesFechamentoCaixa)
                                {
                                    _list.Add
                                    (
                                        (Data.PdvEstacoesFechamentoCaixa)
                                        (new WS.CRUD.PdvEstacoesFechamentoCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.PdvEstacoesFechamentoCaixa(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }

                                 ((Data.PdvEstacao)input).pdvEstacoesFechamentoCaixa = _list.ToArray();
                                _list.Clear();
                                _list = null;
                            }
                            else
                            {
                                if (((Data.PdvEstacao)input).pdvEstacoesFechamentoCaixa != null)
                                {
                                    System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixa> _list = new System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixa>();

                                    foreach (Data.PdvEstacoesFechamentoCaixa _item in ((Data.PdvEstacao)input).pdvEstacoesFechamentoCaixa)
                                    {
                                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                        {
                                            _item.operacao = ENum.eOperacao.NONE;
                                            _list.Add(_item);
                                        }
                                        else { }
                                    }

                                    if (_list.Count > 0)
                                        ((Data.PdvEstacao)input).pdvEstacoesFechamentoCaixa = _list.ToArray();
                                    else
                                        ((Data.PdvEstacao)input).pdvEstacoesFechamentoCaixa = null;

                                    _list.Clear();
                                    _list = null;
                                }
                                else { }
                            }
                        }
                    }

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacao result = (Data.PdvEstacao)parametros["Key"];

            try
            {
                result = (Data.PdvEstacao)this.preencher
                (
                    new Data.PdvEstacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PdvEstacao),
                        new Object[]
                        {
                            result.idPdvEstacao
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacao input = (Data.PdvEstacao)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);


            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.PdvEstacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.PdvEstacao _data in
                    (System.Collections.Generic.List<Tables.PdvEstacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacao),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.PdvEstacao();
                        ((Data.PdvEstacao)_base).idPdvEstacao = _data.idPdvEstacao.value;
                        ((Data.PdvEstacao)_base).departamento = new Data.Departamento { descricao = _data.departamento.descricao.value, idDepartamento = _data.departamento.idDepartamento.value };
                        ((Data.PdvEstacao)_base).departamentoOrigem = new Data.Departamento { descricao = _data.departamentoOrigem.descricao.value, idDepartamento = _data.departamentoOrigem.idDepartamento.value };
                        ((Data.PdvEstacao)_base).pos = _data.pos.value ? "s" : "n";
                        ((Data.PdvEstacao)_base).descricao = _data.descricao.value;

                        if (!input.ignorarAberturaCaixa)
                            ((Data.PdvEstacao)_base).aberturaCaixaAtual = (Data.PdvEstacoesAberturaCaixa)(new WS.CRUD.PdvEstacoesAberturaCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.PdvEstacoesAberturaCaixa(),
                                ((Tables.PdvEstacao)_data).aberturaCaixaAtual,
                                0
                            );
                        ((Data.PdvEstacao)_base).aparelhoSat = (Data.AparelhoSat)(new WS.CRUD.AparelhoSat(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.AparelhoSat(),
                            ((Tables.PdvEstacao)_data).aparelhoSat,
                            0
                        );
                        ((Data.PdvEstacao)_base).habilitarDescontoTotal = _data.habilitarDescontoTotal.value;
                        ((Data.PdvEstacao)_base).confirmacaoGerente = _data.confirmacaoGerente.value;
                        ((Data.PdvEstacao)_base).habilitarNotaPromissoria = _data.habilitarNotaPromissoria.value;
                        ((Data.PdvEstacao)_base).agruparProdutosCupom = _data.agruparProdutosCupom.value;
                        ((Data.PdvEstacao)_base).habilitarPrePago = _data.habilitarPrePago.value;
                        ((Data.PdvEstacao)_base).habilitarPosPago = _data.habilitarPosPago.value;
                        ((Data.PdvEstacao)_base).aplicarTaxaServico = _data.aplicarTaxaServico.value;

                        ((Data.PdvEstacao)_base).prePagoDepartamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.Departamento(),
                            ((Tables.PdvEstacao)_data).prePagoDepartamento,
                            level + 1
                        );
                        ((Data.PdvEstacao)_base).prePagoNaturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.NaturezaOperacao(),
                            ((Tables.PdvEstacao)_data).prePagoNaturezaOperacao,
                            level + 1
                        );
                        ((Data.PdvEstacao)_base).posPagoNaturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.NaturezaOperacao(),
                            ((Tables.PdvEstacao)_data).posPagoNaturezaOperacao,
                            level + 1
                        );
                        ((Data.PdvEstacao)_base).prePagoNaturezaOperacaoEstorno = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.NaturezaOperacao(),
                            ((Tables.PdvEstacao)_data).prePagoNaturezaOperacaoEstorno,
                            level + 1
                        );
                        ((Data.PdvEstacao)_base).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.NaturezaOperacao(),
                            ((Tables.PdvEstacao)_data).naturezaOperacao,
                            level + 1
                        );


                        ((Data.PdvEstacao)_base).cliente = (Data.Cliente)(new WS.CRUD.Cliente(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.Cliente(),
                            ((Tables.PdvEstacao)_data).cliente,
                            level + 1
                        );
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.PdvEstacao { ignorarAberturaCaixa = input.ignorarAberturaCaixa }, _data, level);

                    result.Add(_base);
                }


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

            Data.PdvEstacao _input = (Data.PdvEstacao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvEstacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.idPdvEstacao = @idPdvEstacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.idPdvEstacao));
                    if (!sqlOrderBy.Contains("PdvEstacoes.idPdvEstacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.idPdvEstacao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.descricao LIKE @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("PdvEstacoes.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.descricao");
                    else { }
                }
                else { }

                if (_input.aparelhoSat != null)
                {
                    if (_input.aparelhoSat.idAparelhoSat > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.idAparelhoSat = @idAparelhoSat");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idAparelhoSat", _input.aparelhoSat.idAparelhoSat));
                        if (!sqlOrderBy.Contains("PdvEstacoes.idAparelhoSat"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.idAparelhoSat");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.pos))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.pos = @pos");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("pos", _input.pos == "s"));
                }
                else { }

                if (_input.Pos != null)
                {
                    if (_input.Pos.idPos > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.pos = @idPos");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPos", _input.Pos.idPos));
                        if (!sqlOrderBy.Contains("PdvEstacoes.pos"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.pos");
                        else { }
                    }
                    else { }
                }
                else

                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("departamento.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idDepartamento");
                        else { }
                    }
                    else { }

                    if (_input.departamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.departamento.idEmpresa));
                        if (!sqlOrderBy.Contains("departamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idEmpresa");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.confirmacaoGerente)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.confirmacaoGerente = @confirmacaoGerente");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("confirmacaoGerente", _input.confirmacaoGerente));
                    if (!sqlOrderBy.Contains("PdvEstacoes.confirmacaoGerente"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.confirmacaoGerente");
                    else { }
                }
                else { }

                if (_input.habilitarPrePago)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.habilitarPrePago = @habilitarPrePago");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("habilitarPrePago", _input.habilitarPrePago));
                    if (!sqlOrderBy.Contains("PdvEstacoes.habilitarPrePago"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.habilitarPrePago");
                    else { }
                }
                else { }

                if (_input.prePagoNaturezaOperacao != null && _input.prePagoNaturezaOperacao.idNaturezaOperacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.prePagoNaturezaOperacao = @prePagoNaturezaOperacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("prePagoNaturezaOperacao", _input.prePagoNaturezaOperacao.idNaturezaOperacao));
                    if (!sqlOrderBy.Contains("PdvEstacoes.prePagoNaturezaOperacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.prePagoNaturezaOperacao");
                    else { }
                }
                else { }


                if (_input.prePagoNaturezaOperacaoEstorno != null && _input.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.prePagoNaturezaOperacaoEstorno = @prePagoNaturezaOperacaoEstorno");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("prePagoNaturezaOperacaoEstorno", _input.prePagoNaturezaOperacaoEstorno.idNaturezaOperacao));
                    if (!sqlOrderBy.Contains("PdvEstacoes.prePagoNaturezaOperacaoEstorno"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.prePagoNaturezaOperacaoEstorno");
                    else { }
                }
                else { }

                if (_input.prePagoDepartamento != null && _input.prePagoDepartamento.idDepartamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacoes.prePagoDepartamento = @prePagoDepartamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("prePagoDepartamento", _input.prePagoDepartamento.idDepartamento));
                    if (!sqlOrderBy.Contains("PdvEstacoes.prePagoDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacoes.prePagoDepartamento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : " PdvEstacoes.*, departamento.* ") +
                    "from " +
                    (
                    "PdvEstacoes PdvEstacoes " +
                    "       left join departamento departamentoOrigem on (PdvEstacoes.idDepartamentoOrigem = departamentoOrigem.idDepartamento)\n " +
                    "       inner join departamento departamento on (PdvEstacoes.idDepartamento = departamento.idDepartamento) \n "
                    ) +
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

    }
}
