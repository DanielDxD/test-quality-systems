using System;

namespace WS.CRUD
{
    public class EntradaMercadoria : WS.CRUD.Base
    {
        public EntradaMercadoria(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EntradaMercadoria input = (Data.EntradaMercadoria)parametros["Key"];
            Tables.EntradaMercadoria bd = new Tables.EntradaMercadoria();

            bd.idEntradaMercadoria.isNull = true;
            bd.dataEntrada.value = input.dataEntrada;
            if (input.idPedidoCompra > 0)
                bd.idPedidoCompra.value = input.idPedidoCompra;
            else { }
            if ((input.fornecedor != null) && (input.fornecedor.idEmpresaRelacionamento > 0))
                bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            else { }
            bd.valor.value = input.valor;
            if ((input.condicaoPagamento != null) && (input.condicaoPagamento.idCondicaoPagamento > 0))
                bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            else { }
            bd.dataVencimento.value = input.dataVencimento;
            if (input.idNotaFiscal > 0)
                bd.idNotaFiscal.value = input.idNotaFiscal;
            else
                bd.idNotaFiscal.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.EntradaMercadoria)parametros["Key"]).idEntradaMercadoria = (int)bd.idEntradaMercadoria.value;

            //Processa EntradaMercadoriaItem
            if (input.entradaMercadoriaItems != null)
            {
                WS.CRUD.EntradaMercadoriaItem entradaMercadoriaItemCRUD = new WS.CRUD.EntradaMercadoriaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.entradaMercadoriaItems.Length; i++)
                {
                    input.entradaMercadoriaItems[i].idEntradaMercadoria = bd.idEntradaMercadoria.value;
                    _parameters.Add("Key", input.entradaMercadoriaItems[i]);
                    _parameters.Add("idPedidoCompra", input.idPedidoCompra);
                    _parameters.Add("dataEntrada", input.dataEntrada);
                    entradaMercadoriaItemCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                entradaMercadoriaItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EntradaMercadoria input = (Data.EntradaMercadoria)parametros["Key"];
            Tables.EntradaMercadoria bd = (Tables.EntradaMercadoria)this.m_EntityManager.find
            (
                typeof(Tables.EntradaMercadoria),
                new Object[]
                {
                    input.idEntradaMercadoria
                }
            );

            bd.dataEntrada.value = input.dataEntrada;
            if (input.idPedidoCompra > 0)
                bd.idPedidoCompra.value = input.idPedidoCompra;
            else { }
            if ((input.fornecedor != null) && (input.fornecedor.idEmpresaRelacionamento > 0))
                bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            else { }
            bd.valor.value = input.valor;
            if ((input.condicaoPagamento != null) && (input.condicaoPagamento.idCondicaoPagamento > 0))
                bd.condicaoPagamento.idCondicaoPagamento.value = input.condicaoPagamento.idCondicaoPagamento;
            else { }
            bd.dataVencimento.value = input.dataVencimento;
            if (input.idNotaFiscal > 0)
                bd.idNotaFiscal.value = input.idNotaFiscal;
            else
                bd.idNotaFiscal.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa EntradaMercadoriaItem
            if (input.entradaMercadoriaItems != null)
            {
                WS.CRUD.EntradaMercadoriaItem entradaMercadoriaItemCRUD = new WS.CRUD.EntradaMercadoriaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.entradaMercadoriaItems.Length; i++)
                {
                    input.entradaMercadoriaItems[i].idEntradaMercadoria = bd.idEntradaMercadoria.value;
                    _parameters.Add("Key", input.entradaMercadoriaItems[i]);
                    _parameters.Add("idPedidoCompra", input.idPedidoCompra);
                    _parameters.Add("dataEntrada", input.dataEntrada);
                    if (input.entradaMercadoriaItems[i].operacao == ENum.eOperacao.NONE)
                        input.entradaMercadoriaItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    entradaMercadoriaItemCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                entradaMercadoriaItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EntradaMercadoria bd = new Tables.EntradaMercadoria();

            bd.idEntradaMercadoria.value = ((Data.EntradaMercadoria)parametros["Key"]).idEntradaMercadoria;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EntradaMercadoria)bd).idEntradaMercadoria.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EntradaMercadoria)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EntradaMercadoria)input).idEntradaMercadoria = ((Tables.EntradaMercadoria)bd).idEntradaMercadoria.value;
                    ((Data.EntradaMercadoria)input).dataEntrada = ((Tables.EntradaMercadoria)bd).dataEntrada.value;
                    ((Data.EntradaMercadoria)input).idPedidoCompra = ((Tables.EntradaMercadoria)bd).idPedidoCompra.value;
                    ((Data.EntradaMercadoria)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.EntradaMercadoria)bd).fornecedor,
                        level
                    );
                    ((Data.EntradaMercadoria)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.EntradaMercadoria)bd).departamento,
                        level
                    );
                    ((Data.EntradaMercadoria)input).valor = ((Tables.EntradaMercadoria)bd).valor.value;
                    ((Data.EntradaMercadoria)input).condicaoPagamento = (Data.CondicaoPagamento)(new WS.CRUD.CondicaoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CondicaoPagamento(),
                        ((Tables.EntradaMercadoria)bd).condicaoPagamento,
                        level
                    );
                    ((Data.EntradaMercadoria)input).dataVencimento = ((Tables.EntradaMercadoria)bd).dataVencimento.value;
                    ((Data.EntradaMercadoria)input).idNotaFiscal = ((Tables.EntradaMercadoria)bd).idNotaFiscal.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher EntradaMercadoriaItems
                    if (((Tables.EntradaMercadoria)bd).entradaMercadoriaItems != null)
                    {
                        System.Collections.Generic.List<Data.EntradaMercadoriaItem> _list = new System.Collections.Generic.List<Data.EntradaMercadoriaItem>();

                        foreach (Tables.EntradaMercadoriaItem _item in ((Tables.EntradaMercadoria)bd).entradaMercadoriaItems)
                        {
                            _list.Add
                            (
                                (Data.EntradaMercadoriaItem)
                                (new WS.CRUD.EntradaMercadoriaItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.EntradaMercadoriaItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.EntradaMercadoria)input).entradaMercadoriaItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.EntradaMercadoria)input).entradaMercadoriaItems != null)
                        {
                            System.Collections.Generic.List<Data.EntradaMercadoriaItem> _list = new System.Collections.Generic.List<Data.EntradaMercadoriaItem>();

                            foreach (Data.EntradaMercadoriaItem _item in ((Data.EntradaMercadoria)input).entradaMercadoriaItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.EntradaMercadoria)input).entradaMercadoriaItems = _list.ToArray();
                            else
                                ((Data.EntradaMercadoria)input).entradaMercadoriaItems = null;

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
            Data.EntradaMercadoria result = (Data.EntradaMercadoria)parametros["Key"];

            try
            {
                result = (Data.EntradaMercadoria)this.preencher
                (
                    new Data.EntradaMercadoria(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EntradaMercadoria),
                        new Object[]
                        {
                            result.idEntradaMercadoria
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

            Data.EntradaMercadoria _input = (Data.EntradaMercadoria)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.fornecedor != null)
                {
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

                if (_input.idEntradaMercadoria > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   entradaMercadoria.idEntradaMercadoria = @idEntradaMercadoria");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEntradaMercadoria", _input.idEntradaMercadoria));
                    if (!sqlOrderBy.Contains("entradaMercadoria.idEntradaMercadoria"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "entradaMercadoria.idEntradaMercadoria");
                    else { }
                }
                else { }

                if (_input.idPedidoCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   entradaMercadoria.idPedidoCompra = @idPedidoCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPedidoCompra", _input.idPedidoCompra));
                    if (!sqlOrderBy.Contains("entradaMercadoria.idPedidoCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "entradaMercadoria.idPedidoCompra");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "entradaMercadoria.* ") +
                    "from \n" + 
                    (
                        "entradaMercadoria entradaMercadoria\n" +
                        "	inner join fornecedor fornecedor\n" +
                        "       on	fornecedor.idFornecedor = entradaMercadoria.idFornecedor\n" +
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
            Data.EntradaMercadoria input = (Data.EntradaMercadoria)parametros["Key"];
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
                    typeof(Tables.EntradaMercadoria),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.EntradaMercadoria _data in
                    (System.Collections.Generic.List<Tables.EntradaMercadoria>)this.m_EntityManager.list
                    (
                        typeof(Tables.EntradaMercadoria),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.EntradaMercadoria();
                        ((Data.EntradaMercadoria)_base).idEntradaMercadoria = _data.idEntradaMercadoria.value;
                        ((Data.EntradaMercadoria)_base).fornecedor = new Data.Fornecedor { pessoa = new Data.Pessoa { nomeRazaoSocial = _data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };
                        ((Data.EntradaMercadoria)_base).dataEntrada = _data.dataEntrada.value;
                        ((Data.EntradaMercadoria)_base).departamento = new Data.Departamento { idDepartamento = _data.departamento.idDepartamento.value, descricao = _data.departamento.descricao.value };
                        ((Data.EntradaMercadoria)_base).valor = _data.valor.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.EntradaMercadoria(), _data, level);

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
