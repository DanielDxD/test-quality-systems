using System;

namespace WS.CRUD
{
    public class PedidoCompra : WS.CRUD.Base
    {
        public PedidoCompra(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PedidoCompra input = (Data.PedidoCompra)parametros["Key"];
            Tables.PedidoCompra bd = new Tables.PedidoCompra();

            bd.idPedidoCompra.isNull = true;
            bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            bd.dataPedido.value = input.dataPedido;
            bd.dataAprovacao.value = input.dataAprovacao;
            bd.dataPrevisaoPagamento.value = input.dataPrevisaoPagamento;
            if ((input.condicaoPagamento != null) && (input.condicaoPagamento.idCondicaoPagamento > 0))
                bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            else { }
            bd.valor.value = input.valor;
            if (input.idAprovador > 0)
                bd.idAprovador.value = input.idAprovador;
            else { }
            if (input.idComprador > 0)
                bd.idComprador.value = input.idComprador;
            else { }

            if (input.idRequisicaoCompra > 0)
                bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            else
                bd.idRequisicaoCompra.isNull = true;
            if (input.idNotaFiscal > 0)
                bd.idNotaFiscal.value = input.idNotaFiscal;
            else
                bd.idNotaFiscal.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            bd.valorFrete.value = input.valorFrete;
            bd.valorDesconto.value = input.valorDesconto;
            bd.descricao.value = input.descricao;
            bd.observacao.value = input.observacao;
            bd.dataCancelamento.value = input.dataCancelamento;

            this.m_EntityManager.persist(bd);

            ((Data.PedidoCompra)parametros["Key"]).idPedidoCompra = (int)bd.idPedidoCompra.value;

            //Processa PedidoCompraProdutoServico
            if (input.pedidoCompraProdutoServicos != null)
            {
                WS.CRUD.PedidoCompraProdutoServico pedidoCompraProdutoServicoCRUD = new WS.CRUD.PedidoCompraProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pedidoCompraProdutoServicos.Length; i++)
                {
                    input.pedidoCompraProdutoServicos[i].idPedidoCompra = bd.idPedidoCompra.value;
                    _parameters.Add("Key", input.pedidoCompraProdutoServicos[i]);
                    pedidoCompraProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pedidoCompraProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PedidoCompra input = (Data.PedidoCompra)parametros["Key"];
            Tables.PedidoCompra bd = (Tables.PedidoCompra)this.m_EntityManager.find
            (
                typeof(Tables.PedidoCompra),
                new Object[]
                {
                    input.idPedidoCompra
                }
            );

            bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            bd.dataPedido.value = input.dataPedido;
            bd.dataAprovacao.value = input.dataAprovacao;
            bd.dataPrevisaoPagamento.value = input.dataPrevisaoPagamento;
            if ((input.condicaoPagamento != null) && (input.condicaoPagamento.idCondicaoPagamento > 0))
                bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            else { }
            bd.valor.value = input.valor;
            if (input.idAprovador > 0)
                bd.idAprovador.value = input.idAprovador;
            else 
                bd.idAprovador.isNull = true;

            if (input.idComprador > 0)
                bd.idComprador.value = input.idComprador;
            else
                bd.idComprador.isNull = true;

            if (input.idRequisicaoCompra > 0)
                bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            else
                bd.idRequisicaoCompra.isNull = true;
            if (input.idNotaFiscal > 0)
                bd.idNotaFiscal.value = input.idNotaFiscal;
            else
                bd.idNotaFiscal.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            bd.valorFrete.value = input.valorFrete;
            bd.valorDesconto.value = input.valorDesconto;
            bd.descricao.value = input.descricao;
            bd.observacao.value = input.observacao;
            bd.dataCancelamento.value = input.dataCancelamento;

            this.m_EntityManager.merge(bd);

            //Processa PedidoCompraProdutoServico
            if (input.pedidoCompraProdutoServicos != null)
            {
                WS.CRUD.PedidoCompraProdutoServico pedidoCompraProdutoServicoCRUD = new WS.CRUD.PedidoCompraProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pedidoCompraProdutoServicos.Length; i++)
                {
                    input.pedidoCompraProdutoServicos[i].idPedidoCompra = bd.idPedidoCompra.value;
                    _parameters.Add("Key", input.pedidoCompraProdutoServicos[i]);
                    if (input.pedidoCompraProdutoServicos[i].operacao == ENum.eOperacao.NONE)
                        input.pedidoCompraProdutoServicos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pedidoCompraProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pedidoCompraProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PedidoCompra bd = new Tables.PedidoCompra();
            Data.PedidoCompra input = ((Data.PedidoCompra)parametros["Key"]);

            bd.idPedidoCompra.value = input.idPedidoCompra;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PedidoCompra)bd).idPedidoCompra.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PedidoCompra)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PedidoCompra)input).idPedidoCompra = ((Tables.PedidoCompra)bd).idPedidoCompra.value;
                    ((Data.PedidoCompra)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.PedidoCompra)bd).fornecedor,
                        level + 1
                    );

                    ((Data.PedidoCompra)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.PedidoCompra)bd).departamento,
                        level + 1
                    );

                    ((Data.PedidoCompra)input).aprovador = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.PedidoCompra)bd).aprovador,
                        level + 1
                    );

                    ((Data.PedidoCompra)input).comprador = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.PedidoCompra)bd).comprador,
                        level + 1
                    );

                    ((Data.PedidoCompra)input).dataAprovacao = ((Tables.PedidoCompra)bd).dataAprovacao.value;
                    ((Data.PedidoCompra)input).dataPedido = ((Tables.PedidoCompra)bd).dataPedido.value;
                    ((Data.PedidoCompra)input).condicaoPagamento = (Data.CondicaoPagamento)(new WS.CRUD.CondicaoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CondicaoPagamento(),
                        ((Tables.PedidoCompra)bd).condicaoPagamento,
                        level + 1
                    );
                    ((Data.PedidoCompra)input).valor = ((Tables.PedidoCompra)bd).valor.value;
                    ((Data.PedidoCompra)input).valorFrete = ((Tables.PedidoCompra)bd).valorFrete.value;
                    ((Data.PedidoCompra)input).valorDesconto = ((Tables.PedidoCompra)bd).valorDesconto.value;
                    ((Data.PedidoCompra)input).idAprovador = ((Tables.PedidoCompra)bd).idAprovador.value;
                    ((Data.PedidoCompra)input).idComprador = ((Tables.PedidoCompra)bd).idComprador.value;
                    ((Data.PedidoCompra)input).idRequisicaoCompra = ((Tables.PedidoCompra)bd).idRequisicaoCompra.value;
                    ((Data.PedidoCompra)input).idNotaFiscal = ((Tables.PedidoCompra)bd).idNotaFiscal.value;
                    ((Data.PedidoCompra)input).observacao = ((Tables.PedidoCompra)bd).observacao.value;
                    ((Data.PedidoCompra)input).descricao = ((Tables.PedidoCompra)bd).descricao.value;
                    ((Data.PedidoCompra)input).dataCancelamento = ((Tables.PedidoCompra)bd).dataCancelamento.value;
                    ((Data.PedidoCompra)input).dataPrevisaoPagamento = ((Tables.PedidoCompra)bd).dataPrevisaoPagamento.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher PedidoCompraProdutoServicos
                    if (((Tables.PedidoCompra)bd).pedidoCompraProdutoServicos != null)
                    {
                        System.Collections.Generic.List<Data.PedidoCompraProdutoServico> _list = new System.Collections.Generic.List<Data.PedidoCompraProdutoServico>();

                        foreach (Tables.PedidoCompraProdutoServico _item in ((Tables.PedidoCompra)bd).pedidoCompraProdutoServicos)
                        {
                            _list.Add
                            (
                                (Data.PedidoCompraProdutoServico)
                                (new WS.CRUD.PedidoCompraProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PedidoCompraProdutoServico(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.PedidoCompra)input).pedidoCompraProdutoServicos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.PedidoCompra)input).pedidoCompraProdutoServicos != null)
                        {
                            System.Collections.Generic.List<Data.PedidoCompraProdutoServico> _list = new System.Collections.Generic.List<Data.PedidoCompraProdutoServico>();

                            foreach (Data.PedidoCompraProdutoServico _item in ((Data.PedidoCompra)input).pedidoCompraProdutoServicos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.PedidoCompra)input).pedidoCompraProdutoServicos = _list.ToArray();
                            else
                                ((Data.PedidoCompra)input).pedidoCompraProdutoServicos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PedidoCompra result = (Data.PedidoCompra)parametros["Key"];

            try
            {
                result = (Data.PedidoCompra)this.preencher
                (
                    new Data.PedidoCompra(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PedidoCompra),
                        new Object[]
                        {
                            result.idPedidoCompra
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

            Data.PedidoCompra _input = (Data.PedidoCompra)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.fornecedor != null)
                {
                    if (_input.fornecedor.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.fornecedor.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.fornecedor.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "fornecedor.idFornecedor = @idFornecedor");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFornecedor", _input.fornecedor.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("fornecedor.idFornecedor"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "fornecedor.idFornecedor");
                        else { }
                    }
                    else { }

                    if ((_input.fornecedor.pessoa != null) && (!String.IsNullOrEmpty(_input.fornecedor.pessoa.nomeRazaoSocial)))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", "%" + _input.fornecedor.pessoa.nomeRazaoSocial + "%"));
                        if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.idRequisicaoCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pedidoCompraServico.idRequisicaoCompra = @idRequisicaoCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoCompra", _input.idRequisicaoCompra));
                    if (!sqlOrderBy.Contains("pedidoCompraServico.idRequisicaoCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraServico.idRequisicaoCompra");
                    else { }
                }
                else { }

                if ((_input.dataCancelamento != null) && (_input.dataCancelamento.Ticks > 0))
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "  pedidoCompraServico.dataCancelamento is not null");
                else
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "  pedidoCompraServico.dataCancelamento is null");

                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pedidoCompraServico.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("pedidoCompraServico.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraServico.idDepartamento");
                        else { }
                    }
                    else { }

                    if (_input.departamento.armazem == true)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   departamento.armazem = @armazem");
                        fieldKeys.Add(new EJB.TableBase.TFieldBoolean("armazem", _input.departamento.armazem));
                        if (!sqlOrderBy.Contains("departamento.armazem"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.armazem");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.idPedidoCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pedidoCompraServico.idPedidoCompra = @idPedidoCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPedidoCompra", _input.idPedidoCompra));
                    if (!sqlOrderBy.Contains("pedidoCompraServico.idPedidoCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraServico.idPedidoCompra");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pedidoCompraServico.* ") +
                    "from \n" + 
                    (
                        "pedidoCompraServico pedidoCompraServico\n" +
                        "    inner join fornecedor fornecedor\n" +
                        "        on	fornecedor.idFornecedor = pedidoCompraServico.idFornecedor\n" +
                        "    inner join empresaRelacionamento empresaRelacionamento\n" +
                        "        on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor\n" +
                        "    inner join pessoa pessoa\n" +
                        "        on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n" +
                        "    left join departamento departamento\n" +
                        "        on departamento.idDepartamento = pedidoCompraServico.idDepartamento" +
                        "    left join\n" +
                        "    (\n" +
                        "        select\n" +
                        "            idEntradaMercadoria,\n" +
                        "            idPedidoCompra\n" +
                        "        from\n" +
                        "            entradaMercadoria\n" +
                        "    ) entradaMercadoria\n" +
                        "        on	entradaMercadoria.idPedidoCompra = pedidoCompraServico.idPedidoCompra\n" +
                        "    left join\n" +
                        "    (\n" +
                        "        select\n" +
                        "            idNotaFiscal,\n" +
                        "            idPedidoCompra\n" +
                        "        from\n" +
                        "            notafiscalEPedidoCompra\n" +
                        "    ) notaFiscalEPedidoCompra\n" +
                        "        on	notaFiscalEPedidoCompra.idPedidoCompra = pedidoCompraServico.idPedidoCompra\n" +
                        "    left join notaFiscalE\n" +
                        "        on	notaFiscalE.idNotaFiscalE = pedidoCompraServico.idNotaFiscal\n"
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
            Data.PedidoCompra input = (Data.PedidoCompra)parametros["Key"];
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
                    typeof(Tables.PedidoCompra),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PedidoCompra _data in
                    (System.Collections.Generic.List<Tables.PedidoCompra>)this.m_EntityManager.list
                    (
                        typeof(Tables.PedidoCompra),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.PedidoCompra();
                        ((Data.PedidoCompra)_base).idPedidoCompra = _data.idPedidoCompra.value;
                        ((Data.PedidoCompra)_base).fornecedor = new Data.Fornecedor { pessoa = new Data.Pessoa { nomeRazaoSocial = _data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };
                        ((Data.PedidoCompra)_base).dataPedido = _data.dataPedido.value;
                        ((Data.PedidoCompra)_base).valor = _data.valor.value;
                        ((Data.PedidoCompra)_base).valorFrete = _data.valorFrete.value;
                        ((Data.PedidoCompra)_base).valorDesconto = _data.valorDesconto.value;
                        ((Data.PedidoCompra)_base).observacao = _data.observacao.value;
                        ((Data.PedidoCompra)_base).descricao = _data.descricao.value;
                        ((Data.PedidoCompra)_base).dataPrevisaoPagamento = _data.dataPrevisaoPagamento.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.PedidoCompra(), _data, level);

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
