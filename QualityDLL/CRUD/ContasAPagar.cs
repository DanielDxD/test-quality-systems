using System;

namespace WS.CRUD
{
    public class ContasAPagar : WS.CRUD.Base
    {
        public ContasAPagar(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagar input = (Data.ContasAPagar)parametros["Key"];
            Tables.ContasAPagar bd = new Tables.ContasAPagar();

            bd.dataMovimento.value = input.dataMovimento;

            if (String.IsNullOrEmpty(input.numeroDocumento))
                bd.numeroDocumento.isNull = true;
            else
                bd.numeroDocumento.value = input.numeroDocumento;
            bd.dataVencimento.value = input.dataVencimento;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.desconto.value = input.desconto;
            bd.idEmpresa.value = input.idEmpresa;
            bd.parcela.value = input.parcela;

            if (input.evento != null && input.evento.idEvento > 0)
                bd.evento.idEvento.value = input.evento.idEvento;
            else
                bd.evento.idEvento.isNull = true;

            if (input.dataLancamento.Ticks > 0)
                bd.dataLancamento.value = input.dataLancamento;
            else
                bd.dataLancamento.isNull = true;

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }

            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;
            this.m_EntityManager.persist(bd);

            ((Data.ContasAPagar)parametros["Key"]).idContasAPagar = (int)bd.idContasAPagar.value;

            //Processa ContasAPagarItem
            
            if (input.contasAPagarItems != null)
            {
                WS.CRUD.ContasAPagarItem contasAPagarItemCRUD = new WS.CRUD.ContasAPagarItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAPagarItems.Length; i++)
                {
                    input.contasAPagarItems[i].idContasAPagar = bd.idContasAPagar.value;
                    _parameters.Add("Key", input.contasAPagarItems[i]);
                    contasAPagarItemCRUD.atualizar(_parameters);
                    if (input.contasAPagarItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAPagarItems[i] = (Data.ContasAPagarItem)contasAPagarItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                contasAPagarItemCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagar input = (Data.ContasAPagar)parametros["Key"];
            Tables.ContasAPagar bd = (Tables.ContasAPagar)this.m_EntityManager.find
            (
                typeof(Tables.ContasAPagar),
                new Object[]
                {
                    input.idContasAPagar
                }
            );

            bd.dataMovimento.value = input.dataMovimento;


            if (String.IsNullOrEmpty(input.numeroDocumento))
                bd.numeroDocumento.isNull = true;
            else
                bd.numeroDocumento.value = input.numeroDocumento;
            bd.dataVencimento.value = input.dataVencimento;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.desconto.value = input.desconto;
            bd.idEmpresa.value = input.idEmpresa;
            bd.parcela.value = input.parcela;
            if (input.dataLancamento.Ticks > 0)
                bd.dataLancamento.value = input.dataLancamento;
            else
                bd.dataLancamento.isNull = true;

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;

            if (input.evento != null && input.evento.idEvento > 0)
                bd.evento.idEvento.value = input.evento.idEvento;
            else
                bd.evento.idEvento.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa ContasAPagarItem
            if (input.contasAPagarItems != null)
            {
                WS.CRUD.ContasAPagarItem contasAPagarItemCRUD = new WS.CRUD.ContasAPagarItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAPagarItems.Length; i++)
                {
                    input.contasAPagarItems[i].idContasAPagar = bd.idContasAPagar.value;
                    _parameters.Add("Key", input.contasAPagarItems[i]);
                    if (input.contasAPagarItems[i].operacao == ENum.eOperacao.NONE)
                        input.contasAPagarItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contasAPagarItemCRUD.atualizar(_parameters);
                    if (input.contasAPagarItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAPagarItems[i] = (Data.ContasAPagarItem)contasAPagarItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                contasAPagarItemCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAPagar bd = new Tables.ContasAPagar();

            bd.idContasAPagar.value = ((Data.ContasAPagar)parametros["Key"]).idContasAPagar;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAPagar)bd).idContasAPagar.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAPagar)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAPagar)input).idContasAPagar = ((Tables.ContasAPagar)bd).idContasAPagar.value;
                    ((Data.ContasAPagar)input).dataMovimento = ((Tables.ContasAPagar)bd).dataMovimento.value;
                    ((Data.ContasAPagar)input).dataLancamento = ((Tables.ContasAPagar)bd).dataLancamento.value;
                    ((Data.ContasAPagar)input).idEvento = ((Tables.ContasAPagar)bd).idEvento.value;

                    ((Data.ContasAPagar)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.ContasAPagar)bd).empresaRelacionamento,
                        level + 1
                    );

                    ((Data.ContasAPagar)input).numeroDocumento = ((Tables.ContasAPagar)bd).numeroDocumento.value;
                    ((Data.ContasAPagar)input).dataVencimento = ((Tables.ContasAPagar)bd).dataVencimento.value;
                    ((Data.ContasAPagar)input).valor = ((Tables.ContasAPagar)bd).valor.value;
                    ((Data.ContasAPagar)input).iss = ((Tables.ContasAPagar)bd).iss.value;
                    ((Data.ContasAPagar)input).desconto = ((Tables.ContasAPagar)bd).desconto.value;
                    if (!((Tables.ContasAPagar)bd).valorPago.isNull)
                    {
                        ((Data.ContasAPagar)input).pago = ((Tables.ContasAPagar)bd).valorPago.value;
                        ((Data.ContasAPagar)input).dataUltimoPagamento = ((Tables.ContasAPagar)bd).dataUltimoPagamento.value;
                    }
                    else
                        ((Data.ContasAPagar)input).pago = 0;

                    ((Data.ContasAPagar)input).emAberto = ((Tables.ContasAPagar)bd).emAberto.value ? "S" : "N";

                    ((Data.ContasAPagar)input).idEmpresa = ((Tables.ContasAPagar)bd).idEmpresa.value;
                    if (!((Tables.ContasAPagar)bd).parcela.isNull)
                        ((Data.ContasAPagar)input).parcela = ((Tables.ContasAPagar)bd).parcela.value;
                    else { }

                    ((Data.ContasAPagar)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.ContasAPagar)bd).tipoMovimentoContabil,
                        level + 1
                    );

                    ((Data.ContasAPagar)input).evento = (Data.Evento)(new WS.CRUD.Evento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Evento(),
                        ((Tables.ContasAPagar)bd).evento,
                        level + 1
                    );

                    ((Data.ContasAPagar)input).dataCancelamento = ((Tables.ContasAPagar)bd).dataCancelamento.value;
                }
                else { }
            }
            else { }

            if (level < 1)
            {
                //Preencher ContasAPagarPagamentos
                if (((Tables.ContasAPagar)bd).contasAPagarPagamentos != null)
                {
                    System.Collections.Generic.List<Data.ContasAPagarPagamento> _list = new System.Collections.Generic.List<Data.ContasAPagarPagamento>();

                    foreach (Tables.ContasAPagarPagamento _item in ((Tables.ContasAPagar)bd).contasAPagarPagamentos)
                    {
                        _list.Add
                        (
                            (Data.ContasAPagarPagamento)
                            (new WS.CRUD.ContasAPagarPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ContasAPagarPagamento(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.ContasAPagar)input).contasAPagarPagamentos = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.ContasAPagar)input).contasAPagarPagamentos != null)
                    {
                        System.Collections.Generic.List<Data.ContasAPagarPagamento> _list = new System.Collections.Generic.List<Data.ContasAPagarPagamento>();

                        foreach (Data.ContasAPagarPagamento _item in ((Data.ContasAPagar)input).contasAPagarPagamentos)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.ContasAPagar)input).contasAPagarPagamentos = _list.ToArray();
                        else
                            ((Data.ContasAPagar)input).contasAPagarPagamentos = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            if (level < 1)
            {
                //Preencher ContasAPagarItems
                if (((Tables.ContasAPagar)bd).contasAPagarItems != null)
                {
                    System.Collections.Generic.List<Data.ContasAPagarItem> _list = new System.Collections.Generic.List<Data.ContasAPagarItem>();

                    foreach (Tables.ContasAPagarItem _item in ((Tables.ContasAPagar)bd).contasAPagarItems)
                    {
                        _list.Add
                        (
                            (Data.ContasAPagarItem)
                            (new WS.CRUD.ContasAPagarItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ContasAPagarItem(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.ContasAPagar)input).contasAPagarItems = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.ContasAPagar)input).contasAPagarItems != null)
                    {
                        System.Collections.Generic.List<Data.ContasAPagarItem> _list = new System.Collections.Generic.List<Data.ContasAPagarItem>();

                        foreach (Data.ContasAPagarItem _item in ((Data.ContasAPagar)input).contasAPagarItems)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.ContasAPagar)input).contasAPagarItems = _list.ToArray();
                        else
                            ((Data.ContasAPagar)input).contasAPagarItems = null;

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
            Data.ContasAPagar result = (Data.ContasAPagar)parametros["Key"];

            try
            {
                result = (Data.ContasAPagar)this.preencher
                (
                    new Data.ContasAPagar(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAPagar),
                        new Object[]
                        {
                            result.idContasAPagar
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

            Data.ContasAPagar _input = (Data.ContasAPagar)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAPagar > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.idContasAPagar = @idContasAPagar");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAPagar", _input.idContasAPagar));
                    if (!sqlOrderBy.Contains("contasAPagar.idContasAPagar"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.idContasAPagar");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("contasAPagar.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.idEmpresa");
                    else { }
                }
                else { }

                if (_input.valor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.valor = @valor");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valor", _input.valor));
                    if (!sqlOrderBy.Contains("contasAPagar.valor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.valor");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.emAberto))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.emAberto = @emAberto and contasAPagar.dataCancelamento is null");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("emAberto", _input.emAberto.ToUpper() == "S"));
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroDocumento))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.numeroDocumento = @numeroDocumento");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroDocumento", _input.numeroDocumento));
                }
                else { }

                if (_input.idEvento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.idEvento = @idEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEvento", _input.idEvento));
                    if (!sqlOrderBy.Contains("contasAPagar.idEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.idEvento");
                    else { }
                }


                if (_input.evento != null && _input.evento.idEvento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.idEvento = @idEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEvento", _input.evento.idEvento));
                    if (!sqlOrderBy.Contains("contasAPagar.idEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.idEvento");
                    else { }
                }


                if (_input.empresaRelacionamento != null)
                {
                    if ((_input.empresaRelacionamento.idEmpresa > 0) && (_input.idEmpresa == 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.empresaRelacionamento.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idempresaRelacionamento = @idempresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idempresaRelacionamento", _input.empresaRelacionamento.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idempresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idempresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.pessoa != null)
                    {
                        if ((_input.empresaRelacionamento.pessoa != null) && (_input.empresaRelacionamento.pessoa.idPessoa > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.empresaRelacionamento.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if ((_input.empresaRelacionamento.pessoa.cpfCnpj != null) && (_input.empresaRelacionamento.pessoa.cpfCnpj.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", '%' + _input.empresaRelacionamento.pessoa.cpfCnpj + '%'));
                            if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                            else { }
                        }
                        else { }

                        if ((_input.empresaRelacionamento.pessoa.nomeRazaoSocial != null) && (_input.empresaRelacionamento.pessoa.nomeRazaoSocial.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.empresaRelacionamento.pessoa.nomeRazaoSocial + '%'));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contasAPagar.* ") +
                    "from " +
                    (
                        "   contasAPagar contasAPagar " +
                        "       left join fornecedor fornecedor " +
                        "           on	fornecedor.idFornecedor = contasAPagar.idFornecedor " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = contasAPagar.idEmpresaRelacionamento " +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                        "       left join evento evento " +
                        "           on contasAPagar.idEvento = evento.idEvento" +
                        "       left join " +
                        "       ( " +
                        "           select " +
                        "               idContasAPagar, " +
                        "               MAX(idDocumentoPagamento) idDocumentoPagamentoContas " +
                        "           from " +
                        "               documentoPagamentoContasAPagar " +
                        "           group by " +
                        "               idContasAPagar " +
                        "       ) documentoPagamentoContasAPagar " +
                        "           on	documentoPagamentoContasAPagar.idContasAPagar = contasAPagar.idContasAPagar "
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagar input = (Data.ContasAPagar)parametros["Key"];
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
                    typeof(Tables.ContasAPagar),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAPagar _data in
                    (System.Collections.Generic.List<Tables.ContasAPagar>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAPagar),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.ContasAPagar();

                        ((Data.ContasAPagar)_base).idContasAPagar = _data.idContasAPagar.value;
                        ((Data.ContasAPagar)_base).valor = _data.valor.value;
                        ((Data.ContasAPagar)_base).valorPago = (_data.valorPago.isNull ? 0.0 : _data.valorPago.value);
                        ((Data.ContasAPagar)_base).desconto = (_data.desconto.isNull ? 0.0 : _data.desconto.value);
                        ((Data.ContasAPagar)_base).pago = (_data.valorPago.isNull ? 0.0 : _data.valorPago.value);
                        ((Data.ContasAPagar)_base).dataVencimento = _data.dataVencimento.value;
                        ((Data.ContasAPagar)_base).dataUltimoPagamento = _data.dataUltimoPagamento.value;
                        ((Data.ContasAPagar)_base).parcela = _data.parcela.value;
                        ((Data.ContasAPagar)_base).numeroDocumento = _data.numeroDocumento.value;
                        ((Data.ContasAPagar)_base).empresaRelacionamento = new Data.EmpresaRelacionamento { pessoa = new Data.Pessoa { nomeRazaoSocial = _data.empresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };
                        ((Data.ContasAPagar)_base).evento = new Data.Evento { idEvento = _data.idEvento.value, descricao = _data.evento.descricao.value };
                        ((Data.ContasAPagar)_base).emAberto = _data.emAberto.value ? "S" : "N";
                        ((Data.ContasAPagar)_base).dataCancelamento = _data.dataCancelamento.value;
                        ((Data.ContasAPagar)_base).dataLancamento = _data.dataLancamento.value;

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContasAPagar(), _data, level);

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
