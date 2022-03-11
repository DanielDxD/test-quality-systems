using System;

namespace WS.CRUD
{
    public class RequisicaoInterna : WS.CRUD.Base
    {
        public RequisicaoInterna(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInterna input = (Data.RequisicaoInterna)parametros["Key"];
            Tables.RequisicaoInterna bd = new Tables.RequisicaoInterna();

            bd.idRequisicaoInterna.isNull = true;
            bd.descricao.value = input.descricao;
            if (input.departamentoOrigem != null)
                bd.departamentoOrigem.idDepartamento.value = input.departamentoOrigem.idDepartamento;
            else { }
            if (input.departamentoDestino != null)
                bd.departamentoDestino.idDepartamento.value = input.departamentoDestino.idDepartamento;
            else { }
            bd.dataRequisicao.value = input.dataRequisicao;
            bd.tipo.value = input.tipo;

            if (input.funcionarioSolicitante != null && input.funcionarioSolicitante.idEmpresaRelacionamento > 0)
                bd.funcionarioSolicitante.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionarioSolicitante.idEmpresaRelacionamento;
            else
                bd.funcionarioSolicitante.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoInterna)parametros["Key"]).idRequisicaoInterna = (int)bd.idRequisicaoInterna.value;

            //Processa RequisicaoInternaSituacao
            if (input.requisicaoInternaSituacaos != null)
            {
                WS.CRUD.RequisicaoInternaSituacao requisicaoInternaSituacaoCRUD = new WS.CRUD.RequisicaoInternaSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoInternaSituacaos.Length; i++)
                {
                    input.requisicaoInternaSituacaos[i].idRequisicaoInterna = bd.idRequisicaoInterna.value;
                    _parameters.Add("Key", input.requisicaoInternaSituacaos[i]);
                    requisicaoInternaSituacaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoInternaSituacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa RequisicaoInternaProdutoServico
            if (input.requisicaoInternaProdutoServicos != null)
            {
                WS.CRUD.RequisicaoInternaProdutoServico requisicaoInternaProdutoServicoCRUD = new WS.CRUD.RequisicaoInternaProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoInternaProdutoServicos.Length; i++)
                {
                    input.requisicaoInternaProdutoServicos[i].requisicaoInterna = new Data.RequisicaoInterna();
                    input.requisicaoInternaProdutoServicos[i].requisicaoInterna.idRequisicaoInterna = bd.idRequisicaoInterna.value;
                    _parameters.Add("Key", input.requisicaoInternaProdutoServicos[i]);
                    _parameters.Add("Business", input.departamentoDestino.idEmpresa);
                    _parameters.Add("Source", input.departamentoOrigem.idDepartamento);
                    _parameters.Add("Target", input.departamentoDestino.idDepartamento);
                    _parameters.Add("Type", input.tipo);
                    requisicaoInternaProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoInternaProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInterna input = (Data.RequisicaoInterna)parametros["Key"];
            Tables.RequisicaoInterna bd = (Tables.RequisicaoInterna)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoInterna),
                new Object[]
                {
                    input.idRequisicaoInterna
                }
            );

            bd.descricao.value = input.descricao;
            if (input.departamentoOrigem != null)
                bd.departamentoOrigem.idDepartamento.value = input.departamentoOrigem.idDepartamento;
            else { }
            if (input.departamentoDestino != null)
                bd.departamentoDestino.idDepartamento.value = input.departamentoDestino.idDepartamento;
            else { }
            bd.dataRequisicao.value = input.dataRequisicao;
            bd.tipo.value = input.tipo;

            if (input.funcionarioSolicitante != null && input.funcionarioSolicitante.idEmpresaRelacionamento > 0)
                bd.funcionarioSolicitante.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionarioSolicitante.idEmpresaRelacionamento;
            else
                bd.funcionarioSolicitante.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa RequisicaoInternaSituacao
            if (input.requisicaoInternaSituacaos != null)
            {
                WS.CRUD.RequisicaoInternaSituacao requisicaoInternaSituacaoCRUD = new WS.CRUD.RequisicaoInternaSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoInternaSituacaos.Length; i++)
                {
                    input.requisicaoInternaSituacaos[i].idRequisicaoInterna = bd.idRequisicaoInterna.value;
                    _parameters.Add("Key", input.requisicaoInternaSituacaos[i]);
                    if (input.requisicaoInternaSituacaos[i].operacao == ENum.eOperacao.NONE)
                        input.requisicaoInternaSituacaos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    requisicaoInternaSituacaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoInternaSituacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa RequisicaoInternaProdutoServico
            if (input.requisicaoInternaProdutoServicos != null)
            {
                WS.CRUD.RequisicaoInternaProdutoServico requisicaoInternaProdutoServicoCRUD = new WS.CRUD.RequisicaoInternaProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoInternaProdutoServicos.Length; i++)
                {
                    input.requisicaoInternaProdutoServicos[i].requisicaoInterna = new Data.RequisicaoInterna();
                    input.requisicaoInternaProdutoServicos[i].requisicaoInterna.idRequisicaoInterna = bd.idRequisicaoInterna.value;
                    _parameters.Add("Key", input.requisicaoInternaProdutoServicos[i]);
                    _parameters.Add("Business", input.departamentoDestino.idEmpresa);
                    _parameters.Add("Source", input.departamentoOrigem.idDepartamento);
                    _parameters.Add("Target", input.departamentoDestino.idDepartamento);
                    _parameters.Add("Type", input.tipo);
                    if (input.requisicaoInternaProdutoServicos[i].operacao == ENum.eOperacao.NONE)
                        input.requisicaoInternaProdutoServicos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    requisicaoInternaProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoInternaProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            this.m_EntityManager.execute
            (
                @"delete 
                    from 
                        requisicaoInterna
                    where 
                        idRequisicaoInterna = @idRequisicaoInterna
                ",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger("idRequisicaoInterna", ((Data.RequisicaoInterna)parametros["Key"]).idRequisicaoInterna)
                }
            );
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoInterna)bd).idRequisicaoInterna.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoInterna)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoInterna)input).idRequisicaoInterna = ((Tables.RequisicaoInterna)bd).idRequisicaoInterna.value;
                    ((Data.RequisicaoInterna)input).descricao = ((Tables.RequisicaoInterna)bd).descricao.value;
                    ((Data.RequisicaoInterna)input).departamentoOrigem = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.RequisicaoInterna)bd).departamentoOrigem,
                        level + 1
                    );

                    ((Data.RequisicaoInterna)input).funcionarioSolicitante = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.RequisicaoInterna)bd).funcionarioSolicitante,
                        level + 1
                    );

                    ((Data.RequisicaoInterna)input).departamentoDestino = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.RequisicaoInterna)bd).departamentoDestino,
                        level + 1
                    );
                    ((Data.RequisicaoInterna)input).dataRequisicao = ((Tables.RequisicaoInterna)bd).dataRequisicao.value;
                    ((Data.RequisicaoInterna)input).tipo = ((Tables.RequisicaoInterna)bd).tipo.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher RequisicaoInternaSituacaos
                    if (((Tables.RequisicaoInterna)bd).requisicaoInternaSituacaos != null)
                    {
                        System.Collections.Generic.List<Data.RequisicaoInternaSituacao> _list = new System.Collections.Generic.List<Data.RequisicaoInternaSituacao>();

                        foreach (Tables.RequisicaoInternaSituacao _item in ((Tables.RequisicaoInterna)bd).requisicaoInternaSituacaos)
                        {
                            _list.Add
                            (
                                (Data.RequisicaoInternaSituacao)
                                (new WS.CRUD.RequisicaoInternaSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.RequisicaoInternaSituacao(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.RequisicaoInterna)input).requisicaoInternaSituacaos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoInterna)input).requisicaoInternaSituacaos != null)
                        {
                            System.Collections.Generic.List<Data.RequisicaoInternaSituacao> _list = new System.Collections.Generic.List<Data.RequisicaoInternaSituacao>();

                            foreach (Data.RequisicaoInternaSituacao _item in ((Data.RequisicaoInterna)input).requisicaoInternaSituacaos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoInterna)input).requisicaoInternaSituacaos = _list.ToArray();
                            else
                                ((Data.RequisicaoInterna)input).requisicaoInternaSituacaos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher RequisicaoInternaProdutoServicos
                    if (((Tables.RequisicaoInterna)bd).requisicaoInternaProdutoServicos != null)
                    {
                        System.Collections.Generic.List<Data.RequisicaoInternaProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoInternaProdutoServico>();

                        foreach (Tables.RequisicaoInternaProdutoServico _item in ((Tables.RequisicaoInterna)bd).requisicaoInternaProdutoServicos)
                        {
                            _list.Add
                            (
                                (Data.RequisicaoInternaProdutoServico)
                                (new WS.CRUD.RequisicaoInternaProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.RequisicaoInternaProdutoServico(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.RequisicaoInterna)input).requisicaoInternaProdutoServicos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoInterna)input).requisicaoInternaProdutoServicos != null)
                        {
                            System.Collections.Generic.List<Data.RequisicaoInternaProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoInternaProdutoServico>();

                            foreach (Data.RequisicaoInternaProdutoServico _item in ((Data.RequisicaoInterna)input).requisicaoInternaProdutoServicos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoInterna)input).requisicaoInternaProdutoServicos = _list.ToArray();
                            else
                                ((Data.RequisicaoInterna)input).requisicaoInternaProdutoServicos = null;

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
            Data.RequisicaoInterna result = (Data.RequisicaoInterna)parametros["Key"];

            try
            {
                result = (Data.RequisicaoInterna)this.preencher
                (
                    new Data.RequisicaoInterna(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoInterna),
                        new Object[]
                        {
                            result.idRequisicaoInterna
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

            Data.RequisicaoInterna _input = (Data.RequisicaoInterna)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if ((_input.departamentoDestino != null) && (_input.departamentoDestino.idEmpresa > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamentoDestino.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.departamentoDestino.idEmpresa));
                    if (!sqlOrderBy.Contains("departamentoDestino.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamentoDestino.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idRequisicaoInterna > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInterna.idRequisicaoInterna = @idRequisicaoInterna");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInterna", _input.idRequisicaoInterna));
                    if (!sqlOrderBy.Contains("requisicaoInterna.idRequisicaoInterna"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInterna.idRequisicaoInterna");
                    else { }
                }
                else { }

                if ((_input.departamentoDestino != null) && (_input.departamentoDestino.idDepartamento > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamentoDestino.idDepartamento = @idDepartamentoDestino");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoDestino", _input.departamentoDestino.idDepartamento));
                    if (!sqlOrderBy.Contains("departamentoDestino.idDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamentoDestino.idDepartamento");
                    else { }
                }
                else { }

                if ((_input.departamentoOrigem != null) && (_input.departamentoOrigem.idDepartamento > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamentoOrigem.idDepartamento = @idDepartamentoOrigem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoOrigem", _input.departamentoOrigem.idDepartamento));
                    if (!sqlOrderBy.Contains("departamentoOrigem.idDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamentoOrigem.idDepartamento");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInterna.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("requisicaoInterna.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInterna.descricao");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.tipo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInterna.tipo = @tipo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipo", _input.tipo));
                    if (!sqlOrderBy.Contains("requisicaoInterna.tipo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInterna.tipo");
                    else { }
                }
                else { }

                //
                //Forçando o idRequisicação interna porque o Rows Fetch está se perdendo com o order by com valores repetidos
                //
                if (!sqlOrderBy.Contains("requisicaoInterna.idRequisicaoInterna"))
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInterna.idRequisicaoInterna");
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "requisicaoInterna.* ") +
                    "from \n" +
                    (
                        @"
                        requisicaoInterna requisicaoInterna
	                        inner join departamento departamentoOrigem
		                        on	departamentoOrigem.idDepartamento = requisicaoInterna.idDepartamentoOrigem
	                        inner join departamento departamentoDestino
		                        on	departamentoDestino.idDepartamento = requisicaoInterna.idDepartamentoDestino
                            left join funcionario funcionarioSolicitante
                                on funcionarioSolicitante.idFuncionario = requisicaoInterna.idFuncionarioSolicitante
	                        inner join 
	                        (
		                        select
			                        idRequisicaoInterna,
			                        MAX(idRequisicaoInternaSituacao) idRequisicaoInternaSituacao
		                        from
			                        requisicaoInternaSituacao
		                        group by
			                        idRequisicaoInterna
	                        ) requisicaoInternaSituacaoAtual
		                        on	requisicaoInternaSituacaoAtual.idRequisicaoInterna = requisicaoInterna.idRequisicaoInterna
	                        inner join requisicaoInternaSituacao requisicaoInternaSituacao
		                        on	requisicaoInternaSituacao.idRequisicaoInternaSituacao = requisicaoInternaSituacaoAtual.idRequisicaoInternaSituacao and requisicaoInternaSituacao.idRequisicaoInterna = requisicaoInternaSituacaoAtual.idRequisicaoInterna 
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
            Data.RequisicaoInterna input = (Data.RequisicaoInterna)parametros["Key"];
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
                    typeof(Tables.RequisicaoInterna),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoInterna _data in
                    (System.Collections.Generic.List<Tables.RequisicaoInterna>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoInterna),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.RequisicaoInterna();
                        ((Data.RequisicaoInterna)_base).idRequisicaoInterna = _data.idRequisicaoInterna.value;
                        ((Data.RequisicaoInterna)_base).descricao = _data.descricao.value;
                        ((Data.RequisicaoInterna)_base).dataRequisicao = _data.dataRequisicao.value;
                        ((Data.RequisicaoInterna)_base).tipo = _data.tipo.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.RequisicaoInterna(), _data, level);

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
