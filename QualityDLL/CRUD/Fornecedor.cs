using System;

namespace WS.CRUD
{
    public class Fornecedor : WS.CRUD.Base
    {
        public Fornecedor(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Fornecedor input = (Data.Fornecedor)parametros["Key"];
            Tables.Fornecedor bd =
            (
                parametros["Return"] != null ?
                (Tables.Fornecedor)parametros["Return"] :
                new Tables.Fornecedor()
            );

            //Incluir/Alterar EmpresaRelacionamento
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.fornecedorEmpresaRelacionamento);

                input = (Data.Fornecedor)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.dataContrato.value = input.dataContrato;
            bd.retemISS.value = input.retemISS;
            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if ((input.regraContabilizacao != null) && (input.regraContabilizacao.idRegraContabilizacao > 0))
                bd.regraContabilizacao.idRegraContabilizacao.value = input.regraContabilizacao.idRegraContabilizacao;
            else { }
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Fornecedor input = (Data.Fornecedor)parametros["Key"];
            Tables.Fornecedor bd =
            (
                parametros["Return"] != null ?
                (Tables.Fornecedor)parametros["Return"] :
                (Tables.Fornecedor)this.m_EntityManager.find
                (
                    typeof(Tables.Fornecedor),
                    new Object[]
                    {
                        input.idEmpresaRelacionamento
                    }
                )
            );

            //Alterar EmpresaRelacionamento
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.fornecedorEmpresaRelacionamento);

                input = (Data.Fornecedor)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.dataContrato.value = input.dataContrato;
            bd.retemISS.value = input.retemISS;
            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if ((input.regraContabilizacao != null) && (input.regraContabilizacao.idRegraContabilizacao > 0))
                bd.regraContabilizacao.idRegraContabilizacao.value = input.regraContabilizacao.idRegraContabilizacao;
            else { }
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Fornecedor bd = new Tables.Fornecedor();

            bd.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = ((Data.Fornecedor)parametros["Key"]).idEmpresaRelacionamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Fornecedor)bd).fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Fornecedor)input).operacao = ENum.eOperacao.NONE;

                    input = (Data.Fornecedor)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        ((Tables.Fornecedor)bd).fornecedorEmpresaRelacionamento,
                        level
                    );

                    ((Data.Fornecedor)input).dataContrato = ((Tables.Fornecedor)bd).dataContrato.value;
                    ((Data.Fornecedor)input).retemISS = ((Tables.Fornecedor)bd).retemISS.value;
                    ((Data.Fornecedor)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.Fornecedor)bd).planoContas,
                        level + 1
                    );
                    ((Data.Fornecedor)input).regraContabilizacao = (Data.RegraContabilizacao)(new WS.CRUD.RegraContabilizacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RegraContabilizacao(),
                        ((Tables.Fornecedor)bd).regraContabilizacao,
                        level + 1
                    );
                    ((Data.Fornecedor)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.Fornecedor)bd).tipoMovimentoContabil,
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

            /*Consultar Diferente */
            Data.Fornecedor result = (Data.Fornecedor)parametros["Key"];

            String queryString = "";

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                //usuario
                if ((result.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFornecedor", result.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "fornecedor.idFornecedor = @idFornecedor";
                }
                else { }

                //idPessoa
                if (result.pessoa != null)
                {
                    if (result.pessoa.idPessoa > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", result.pessoa.idPessoa));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa";
                    }
                    else { }

                    if (!String.IsNullOrEmpty(result.pessoa.cpfCnpj))
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", result.pessoa.cpfCnpj));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.cpfCnpj = @cpfCnpj";
                    }
                    else { }


                }
                else { }


                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" +
                    "    fornecedor\n" +
                    "        inner join empresaRelacionamento\n" +
                    "            on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor\n" +
                    "        inner join pessoa\n" +
                    "            on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    ) +
                    "order by\n" +
                    "	pessoa.nomeRazaoSocial\n"
                );

                foreach
                (
                    Tables.Fornecedor _data in
                    (System.Collections.Generic.List<Tables.Fornecedor>)this.m_EntityManager.list
                    (
                        typeof(Tables.Fornecedor),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.Fornecedor)this.preencher
                    (
                        new Data.Fornecedor(),
                        _data,
                        0
                    );
                }
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString() + "[" + queryString + "]");
                throw new Exception(e.Message);
            }

            return result;
            /*

            Data.Fornecedor result = (Data.Fornecedor)parametros["Key"];

            try
            {
                result = (Data.Fornecedor)this.preencher
                (
                    new Data.Fornecedor(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Fornecedor),
                        new Object[]
                        {
                            result.idEmpresaRelacionamento
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

            return result;*/
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

            Data.Fornecedor _input = (Data.Fornecedor)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idEmpresaRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "fornecedor.idFornecedor = @idFornecedor");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFornecedor", _input.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("fornecedor.idFornecedor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "fornecedor.idFornecedor");
                    else { }
                }
                else { }

                if (_input.pessoa != null)
                {
                    if ((_input.pessoa != null) && (_input.pessoa.idPessoa > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.pessoa.idPessoa));
                        if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                        else { }
                    }
                    else { }

                    if ((_input.pessoa.cpfCnpj != null) && (_input.pessoa.cpfCnpj.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", '%' + _input.pessoa.cpfCnpj + '%'));
                        if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                        else { }
                    }
                    else { }

                    if ((_input.pessoa.nomeRazaoSocial != null) && (_input.pessoa.nomeRazaoSocial.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.pessoa.nomeRazaoSocial + '%'));
                        if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                        else { }
                    }
                    else { }

                    try
                    {
                        Data.PessoaJuridica pj = (Data.PessoaJuridica)_input.pessoa;

                        if ((pj.atividadeEconomicaPrimaria != null) && (pj.atividadeEconomicaPrimaria.idAtividadeEconomica > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoaJuridica.idAtividadeEconomicaPrimaria = @idAtividadeEconomicaPrimaria");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idAtividadeEconomicaPrimaria", pj.atividadeEconomicaPrimaria.idAtividadeEconomica));
                            if (!sqlOrderBy.Contains("pessoaJuridica.idAtividadeEconomicaPrimaria"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoaJuridica.idAtividadeEconomicaPrimaria");
                            else { }
                        }
                        else { }
                    }
                    catch { }
                }
                else { }

                result =
                    (
                        (
                            @"select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                            "   " + (onlyCount ? " COUNT(1) " : "* ") +
                            @"
                            from
                                fornecedor
		                            inner join empresaRelacionamento
			                            on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor
		                            inner join tipoRelacionamentoEmpresa
			                            on	tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = empresaRelacionamento.idTipoRelacionamentoEmpresa
                                    inner join pessoa pessoa
	                                    on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
		                            left join pessoaJuridica
			                            on	pessoaJuridica.idPessoaJuridica = pessoa.idPessoa
		                            left join pessoaFisica
			                            on	pessoaFisica.idPessoaFisica = pessoa.idPessoa
		                            left join atividadeEconomica
			                            on	AtividadeEconomica.idAtividadeEconomica = pessoaJuridica.idAtividadeEconomicaPrimaria
		                            left join exportacaoContabil
			                            on	exportacaoContabil.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionamento
		                            left join empresaRelacionamento empresaRelacionamentoPai
			                            on	empresaRelacionamentoPai.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionadaEmpresa
                            "
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
            Data.Fornecedor input = (Data.Fornecedor)parametros["Key"];
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
                    typeof(Tables.Fornecedor),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Fornecedor _data in
                    (System.Collections.Generic.List<Tables.Fornecedor>)this.m_EntityManager.list
                    (
                        typeof(Tables.Fornecedor),
                        _select,
                        _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Fornecedor();
                        ((Data.Fornecedor)_base).idEmpresaRelacionamento = _data.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value;
                        ((Data.Fornecedor)_base).limitePosPago = _data.fornecedorEmpresaRelacionamento.limitePosPago.value;
                        ((Data.Fornecedor)_base).pessoa = new Data.Pessoa { nomeRazaoSocial = _data.fornecedorEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value };

                        if (_data.fornecedorEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                            ((Data.Fornecedor)_base).pessoa.cpfCnpjFormatado = Utils.Utils.ToUInt64(_data.fornecedorEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                        else
                            ((Data.Fornecedor)_base).pessoa.cpfCnpjFormatado = Utils.Utils.ToUInt64(_data.fornecedorEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Fornecedor(), _data, level);

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
