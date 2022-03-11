using System;
using System.Linq;

namespace WS.CRUD
{
    public class RequisicaoCotacao : WS.CRUD.Base
    {
        public RequisicaoCotacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacao input = (Data.RequisicaoCotacao)parametros["Key"];
            Tables.RequisicaoCotacao bd = new Tables.RequisicaoCotacao();

            bd.idRequisicaoCotacao.isNull = true;
            bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            if (input.fornecedor != null)
                if (input.fornecedor.idEmpresaRelacionamento > 0)
                    bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
                else { }
            else { }
            bd.dataCotacao.value = input.dataCotacao;
            bd.dataRespostaCotacao.value = input.dataRespostaCotacao;
            bd.dataPrevisaoPagamento.value = input.dataPrevisaoPagamento;
            bd.valor.value = input.valor;
            if ((input.condicaoPagamento != null) && (input.condicaoPagamento.idCondicaoPagamento > 0))
                bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            else { }
            bd.prazoEntrega.value = input.prazoEntrega;
            bd.valorFrete.value = input.valorFrete;
            bd.valorDesconto.value = input.valorDesconto;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoCotacao)parametros["Key"]).idRequisicaoCotacao = (int)bd.idRequisicaoCotacao.value;

            //Processa RequisicaoCotacaoProdutoServico
            if (input.requisicaoCotacaoProdutoServicos != null)
            {
                WS.CRUD.RequisicaoCotacaoProdutoServico requisicaoCotacaoProdutoServicoCRUD = new WS.CRUD.RequisicaoCotacaoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCotacaoProdutoServicos.Length; i++)
                {
                    input.requisicaoCotacaoProdutoServicos[i].idRequisicaoCotacao = bd.idRequisicaoCotacao.value;
                    _parameters.Add("Key", input.requisicaoCotacaoProdutoServicos[i]);
                    requisicaoCotacaoProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCotacaoProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacao input = (Data.RequisicaoCotacao)parametros["Key"];
            Tables.RequisicaoCotacao bd = (Tables.RequisicaoCotacao)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoCotacao),
                new Object[]
                {
                    input.idRequisicaoCotacao
                }
            );

            bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            if (input.fornecedor != null)
                bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            else { }
            bd.dataCotacao.value = input.dataCotacao;
            bd.dataRespostaCotacao.value = input.dataRespostaCotacao;
            bd.dataPrevisaoPagamento.value = input.dataPrevisaoPagamento;
            bd.valor.value = input.valor;
            if ((input.condicaoPagamento != null) && (input.condicaoPagamento.idCondicaoPagamento > 0))
                bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            else { }
            bd.prazoEntrega.value = input.prazoEntrega;
            bd.valorFrete.value = input.valorFrete;
            bd.valorDesconto.value = input.valorDesconto;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            //Processa RequisicaoCotacaoProdutoServico
            if (input.requisicaoCotacaoProdutoServicos != null)
            {
                WS.CRUD.RequisicaoCotacaoProdutoServico requisicaoCotacaoProdutoServicoCRUD = new WS.CRUD.RequisicaoCotacaoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCotacaoProdutoServicos.Length; i++)
                {
                    input.requisicaoCotacaoProdutoServicos[i].idRequisicaoCotacao = bd.idRequisicaoCotacao.value;
                    _parameters.Add("Key", input.requisicaoCotacaoProdutoServicos[i]);
                    if (input.requisicaoCotacaoProdutoServicos[i].operacao == ENum.eOperacao.NONE)
                        input.requisicaoCotacaoProdutoServicos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    requisicaoCotacaoProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCotacaoProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            this.m_EntityManager.execute
            (
                "delete from requisicaoCotacao where idRequisicaoCotacao = @idRequisicaoCotacao",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger("idRequisicaoCotacao", ((Data.RequisicaoCotacao)parametros["Key"]).idRequisicaoCotacao)
                }
            );
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoCotacao)bd).idRequisicaoCotacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoCotacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoCotacao)input).idRequisicaoCotacao = ((Tables.RequisicaoCotacao)bd).idRequisicaoCotacao.value;
                    ((Data.RequisicaoCotacao)input).idRequisicaoCompra = ((Tables.RequisicaoCotacao)bd).idRequisicaoCompra.value;
                    ((Data.RequisicaoCotacao)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.RequisicaoCotacao)bd).fornecedor,
                        level + 1
                    );

                    ((Data.RequisicaoCotacao)input).dataCotacao = ((Tables.RequisicaoCotacao)bd).dataCotacao.value;
                    ((Data.RequisicaoCotacao)input).dataPrevisaoPagamento = ((Tables.RequisicaoCotacao)bd).dataPrevisaoPagamento.value;
                    ((Data.RequisicaoCotacao)input).observacao = ((Tables.RequisicaoCotacao)bd).observacao.value;
                    ((Data.RequisicaoCotacao)input).descricao =
                    (
                        (Data.RequisicaoCompra)(new RequisicaoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.RequisicaoCompra(),
                                this.m_EntityManager.find
                                (
                                    typeof(Tables.RequisicaoCompra),
                                    new Object[]
                                    {
                                        ((Tables.RequisicaoCotacao)bd).idRequisicaoCompra.value
                                    }
                                ),
                                1
                            )
                    ).descricao;
                    ((Data.RequisicaoCotacao)input).dataRespostaCotacao = ((Tables.RequisicaoCotacao)bd).dataRespostaCotacao.value;
                    ((Data.RequisicaoCotacao)input).valor = ((Tables.RequisicaoCotacao)bd).valor.value;
                    ((Data.RequisicaoCotacao)input).valorFrete = ((Tables.RequisicaoCotacao)bd).valorFrete.value;
                    ((Data.RequisicaoCotacao)input).valorDesconto = ((Tables.RequisicaoCotacao)bd).valorDesconto.value;
                    ((Data.RequisicaoCotacao)input).condicaoPagamento = (Data.CondicaoPagamento)(new WS.CRUD.CondicaoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CondicaoPagamento(),
                        ((Tables.RequisicaoCotacao)bd).condicaoPagamento,
                        level + 1
                    );
                    ((Data.RequisicaoCotacao)input).prazoEntrega = String.IsNullOrEmpty(((Tables.RequisicaoCotacao)bd).prazoEntrega.value) ? "" : ((Tables.RequisicaoCotacao)bd).prazoEntrega.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher RequisicaoCotacaoProdutoServicos
                    if (((Tables.RequisicaoCotacao)bd).requisicaoCotacaoProdutoServicos != null)
                    {
                        System.Collections.Generic.List<Data.RequisicaoCotacaoProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoCotacaoProdutoServico>();

                        foreach (Tables.RequisicaoCotacaoProdutoServico _item in ((Tables.RequisicaoCotacao)bd).requisicaoCotacaoProdutoServicos)
                        {
                            _list.Add
                            (
                                (Data.RequisicaoCotacaoProdutoServico)
                                (new WS.CRUD.RequisicaoCotacaoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.RequisicaoCotacaoProdutoServico(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos != null)
                        {
                            System.Collections.Generic.List<Data.RequisicaoCotacaoProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoCotacaoProdutoServico>();

                            foreach (Data.RequisicaoCotacaoProdutoServico _item in ((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos = _list.ToArray();
                            else
                                ((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }

                bool preenchido = false;
                if (((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos != null)
                {
                    try
                    {
                        Data.RequisicaoCotacaoProdutoServico _find = ((Data.RequisicaoCotacao)input).requisicaoCotacaoProdutoServicos.First(X => X.quantidadeAprovada > 0);
                        if (_find != null && _find.idRequisicaoCotacaoProdutoServico > 0)
                            preenchido = true;
                        else { }
                    }
                    catch
                    {
                        preenchido = false;
                    }
                }
                ((Data.RequisicaoCotacao)input).preenchida = preenchido;
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacao result = (Data.RequisicaoCotacao)parametros["Key"];

            try
            {
                result = (Data.RequisicaoCotacao)this.preencher
                (
                    new Data.RequisicaoCotacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoCotacao),
                        new Object[]
                        {
                            result.idRequisicaoCotacao
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

            Data.RequisicaoCotacao _input = (Data.RequisicaoCotacao)input;

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

                    if (!String.IsNullOrEmpty(_input.fornecedor.pessoa.nomeRazaoSocial))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", "%" + _input.fornecedor.pessoa.nomeRazaoSocial + "%"));
                        if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
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
                }
                else { }

                if (_input.idRequisicaoCotacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoCotacao.idRequisicaoCotacao = @idRequisicaoCotacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoCotacao", _input.idRequisicaoCotacao));
                    if (!sqlOrderBy.Contains("requisicaoCotacao.idRequisicaoCotacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoCotacao.idRequisicaoCotacao");
                    else { }
                }
                else { }

                if (_input.dataPrevisaoPagamento.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CAST(requisicaoCotacao.dataPrevisaoPagamento AS DATE) = CAST(@dataPrevisaoPagamento AS DATE)");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataPrevisaoPagamento", _input.dataPrevisaoPagamento));
                    if (!sqlOrderBy.Contains("requisicaoCotacao.dataPrevisaoPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoCotacao.dataPrevisaoPagamento");
                    else { }
                }
                else { }

                if (_input.idRequisicaoCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoCotacao.idRequisicaoCompra = @idRequisicaoCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoCompra", _input.idRequisicaoCompra));
                    if (!sqlOrderBy.Contains("requisicaoCotacao.idRequisicaoCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoCotacao.idRequisicaoCompra");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "requisicaoCotacao.* ") +
                    "from \n" +
                    (
                        @"
                            requisicaoCotacao requisicaoCotacao 
                                inner join fornecedor fornecedor 
                                    on	fornecedor.idFornecedor = requisicaoCotacao.idFornecedor 
                                inner join empresaRelacionamento empresaRelacionamento 
                                    on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor
		                        inner join pessoa pessoa
			                        on pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
		                        inner join
		                        (
			                        select 
				                        requisicaoCompra.idRequisicaoCompra, requisicaoCompraSituacao.situacao, requisicaoCompra.dataRequisicao, departamento.idEmpresa
			                        from
				                        requisicaoCompra requisicaoCompra
                                            inner join departamento departamento
		                                        on	departamento.idDepartamento = requisicaoCompra.idDepartamento
					                        inner join
						                        (
							                        select
								                        idRequisicaoCompra,
								                        MAX(idRequisicaoCompraSituacao) idRequisicaoCompraSituacao
							                        from
								                        requisicaoCompraSituacao
							                        group by
								                        idRequisicaoCompra
						                        ) requisicaoCompraSituacaoAtual
							                        on	requisicaoCompraSituacaoAtual.idRequisicaoCompra = requisicaoCompra.idRequisicaoCompra
					                        inner join requisicaoCompraSituacao requisicaoCompraSituacao
						                        on	requisicaoCompraSituacao.idRequisicaoCompraSituacao = requisicaoCompraSituacaoAtual.idRequisicaoCompraSituacao
		                        ) requisicaoCompra
			                        on requisicaoCompra.idRequisicaoCompra = requisicaoCotacao.idRequisicaoCompra
                        "
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
            Data.RequisicaoCotacao input = (Data.RequisicaoCotacao)parametros["Key"];
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
                    typeof(Tables.RequisicaoCotacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                Object _dataList = this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoCotacao),
                        _select,
                       _fieldKeys.ToArray()
                    );

                if (_dataList != null)
                {
                    foreach (Tables.RequisicaoCotacao _data in (System.Collections.Generic.List<Tables.RequisicaoCotacao>)_dataList)
                    {
                        Data.Base _base = new Data.Base();

                        if (mode == "Roll")
                        {
                            _base = new Data.RequisicaoCotacao();
                            ((Data.RequisicaoCotacao)_base).idRequisicaoCompra = _data.idRequisicaoCompra.value;
                            ((Data.RequisicaoCotacao)_base).idRequisicaoCotacao = _data.idRequisicaoCotacao.value;
                            ((Data.RequisicaoCotacao)_base).observacao = _data.observacao.value;
                            ((Data.RequisicaoCotacao)_base).valor = _data.valor.value;
                            ((Data.RequisicaoCotacao)_base).valorFrete = _data.valorFrete.value;
                            ((Data.RequisicaoCotacao)_base).valorDesconto = _data.valorDesconto.value;
                            ((Data.RequisicaoCotacao)_base).dataPrevisaoPagamento = _data.dataPrevisaoPagamento.value;
                            ((Data.RequisicaoCotacao)_base).dataCotacao = _data.dataCotacao.value;
                            ((Data.RequisicaoCotacao)_base).fornecedor = new Data.Fornecedor { pessoa = new Data.Pessoa { nomeRazaoSocial = _data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };

                            try
                            {
                                if (!String.IsNullOrEmpty(_data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value))
                                    if (((Data.RequisicaoCotacao)_base).fornecedor.pessoa.pfpj == "F")
                                        ((Data.RequisicaoCotacao)_base).cpfCnpj = Convert.ToUInt64(_data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                                    else
                                        ((Data.RequisicaoCotacao)_base).cpfCnpj = Convert.ToUInt64(_data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");
                            }
                            catch { }

                            ((Data.RequisicaoCotacao)_base).descricao =
                            (
                                (Data.RequisicaoCompra)(new RequisicaoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.RequisicaoCompra(),
                                        this.m_EntityManager.find
                                        (
                                            typeof(Tables.RequisicaoCompra),
                                            new Object[]
                                        {
                                            _data.idRequisicaoCompra.value
                                        }
                                        ),
                                        1
                                    )
                            ).descricao;

                            bool preenchido = false;

                            //Preencher RequisicaoCotacaoProdutoServicos
                            if (((Tables.RequisicaoCotacao)_data).requisicaoCotacaoProdutoServicos != null)
                            {
                                System.Collections.Generic.List<Data.RequisicaoCotacaoProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoCotacaoProdutoServico>();

                                foreach (Tables.RequisicaoCotacaoProdutoServico _item in ((Tables.RequisicaoCotacao)_data).requisicaoCotacaoProdutoServicos)
                                {
                                    _list.Add
                                    (
                                        (Data.RequisicaoCotacaoProdutoServico)
                                        (new WS.CRUD.RequisicaoCotacaoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.RequisicaoCotacaoProdutoServico(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }

                                ((Data.RequisicaoCotacao)_base).requisicaoCotacaoProdutoServicos = _list.ToArray();
                                _list.Clear();
                                _list = null;
                            }
                            else { }

                            if (((Data.RequisicaoCotacao)_base).requisicaoCotacaoProdutoServicos != null)
                            {
                                try
                                {
                                    Data.RequisicaoCotacaoProdutoServico _find = ((Data.RequisicaoCotacao)_base).requisicaoCotacaoProdutoServicos.Where(X => X.quantidadeAprovada > 0).ToList()[0];
                                    if (_find != null && _find.idRequisicaoCotacaoProdutoServico > 0)
                                        preenchido = true;
                                    else { }
                                }
                                catch
                                {
                                    preenchido = false;
                                }
                            }
                            ((Data.RequisicaoCotacao)_base).preenchida = preenchido;

                        }
                        else
                            _base = (Data.Base)this.preencher(new Data.RequisicaoCotacao(), _data, level);

                        if (report != null)
                            report.ProcessRecord(_base);
                        else
                            result.Add(_base);
                    }
                }
                else { }

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
