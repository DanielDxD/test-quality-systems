using System;
using System.Collections.Generic;
using Utils;

namespace WS.CRUD
{
    public class Cliente : WS.CRUD.Base
    {
        public Cliente(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Cliente input = (Data.Cliente)parametros["Key"];
            Tables.Cliente bd =
            (
                parametros["Return"] != null ?
                (Tables.Cliente)parametros["Return"] :
                new Tables.Cliente()
            );

            //Incluir/Alterar EmpresaRelacionamento
            {

                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);

                if
                (
                    input.tipoRelacionamentoEmpresa == null ||
                    (input.tipoRelacionamentoEmpresa != null && input.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa == 0)
                )
                {
                    Data.TipoRelacionamentoEmpresa tre = new Data.TipoRelacionamentoEmpresa();
                    tre.tipo = "EC";
                    foreach (Data.TipoRelacionamentoEmpresa t in Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, tre, 1))
                    {
                        if (t.tipo == tre.tipo)
                        {
                            tre = t;
                            break;
                        }
                    }
                    input.tipoRelacionamentoEmpresa = tre;
                }
                else { }

                _parametros.Add("Return", bd.clienteEmpresaRelacionamento);

                input = (Data.Cliente)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.recebimentoPDV.value = input.recebimentoPDV;
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
            Data.Cliente input = (Data.Cliente)parametros["Key"];
            Tables.Cliente bd =
            (
                parametros["Return"] != null ?
                (Tables.Cliente)parametros["Return"] :
                (Tables.Cliente)this.m_EntityManager.find
                (
                    typeof(Tables.Cliente),
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
                _parametros.Add("Return", bd.clienteEmpresaRelacionamento);

                input = (Data.Cliente)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.recebimentoPDV.value = input.recebimentoPDV;
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
            Tables.Cliente bd = new Tables.Cliente();

            bd.clienteEmpresaRelacionamento.idEmpresaRelacionamento.value = ((Data.Cliente)parametros["Key"]).idEmpresaRelacionamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    (
                        (bd.GetType().Name == typeof(Tables.EmpresaRelacionamento).Name) &&
                        !((Tables.EmpresaRelacionamento)bd).idEmpresaRelacionamento.isNull
                    ) ||
                    (
                        (bd.GetType().Name == typeof(Tables.Cliente).Name) &&
                        !((Tables.Cliente)bd).clienteEmpresaRelacionamento.idEmpresaRelacionamento.isNull
                    )
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Cliente)input).operacao = ENum.eOperacao.NONE;

                    input = (Data.Cliente)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        (
                            (bd.GetType().Name == typeof(Tables.EmpresaRelacionamento).Name) ?
                            bd :
                            ((Tables.Cliente)bd).clienteEmpresaRelacionamento
                        ),
                        level
                    );

                    ((Data.Cliente)input).recebimentoPDV = ((Tables.Cliente)bd).recebimentoPDV.value;
                    ((Data.Cliente)input).dataContrato = ((Tables.Cliente)bd).dataContrato.value;
                    ((Data.Cliente)input).retemISS = ((Tables.Cliente)bd).retemISS.value;
                    ((Data.Cliente)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.Cliente)bd).planoContas,
                        level + 1
                    );
                    ((Data.Cliente)input).regraContabilizacao = (Data.RegraContabilizacao)(new WS.CRUD.RegraContabilizacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RegraContabilizacao(),
                        ((Tables.Cliente)bd).regraContabilizacao,
                        level + 1
                    );
                    ((Data.Cliente)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.Cliente)bd).tipoMovimentoContabil,
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
            Data.Cliente result = (Data.Cliente)parametros["Key"];

            String queryString = "";

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                //usuario
                if ((result.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCliente", result.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "cliente.idCliente = @idCliente";
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

                if (!String.IsNullOrEmpty(result.recebimentoPDV))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("recebimentoPDV", result.recebimentoPDV));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "cliente.recebimentoPDV = @recebimentoPDV";
                }
                else { }


                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" +
                    "    cliente\n" +
                    "        inner join empresaRelacionamento\n" +
                    "            on	empresaRelacionamento.idEmpresaRelacionamento = cliente.idCliente\n" +
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
                    Tables.Cliente _data in
                    (System.Collections.Generic.List<Tables.Cliente>)this.m_EntityManager.list
                    (
                        typeof(Tables.Cliente),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.Cliente)this.preencher
                    (
                        new Data.Cliente(),
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

            Data.Cliente _input = (Data.Cliente)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
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
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cliente.idCliente = @idCliente");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCliente", _input.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("cliente.idCliente"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cliente.idCliente");
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
                }
                else { }

                if (!String.IsNullOrEmpty(_input.recebimentoPDV))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cliente.recebimentoPDV = @recebimentoPDV ");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("recebimentoPDV", _input.recebimentoPDV));
                    if (!sqlOrderBy.Contains("cliente.recebimentoPDV"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cliente.recebimentoPDV");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "cliente.* ") +
                    "from " +
                    (
                        "   cliente cliente " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = cliente.idCliente " +
                        "       inner join tipoRelacionamentoEmpresa tipoRelacionamentoEmpresa\n" +
                        "           on	tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = empresaRelacionamento.idTipoRelacionamentoEmpresa\n" +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                        "       left join empresaRelacionamento empresaRelacionamentoPai on  empresaRelacionamentoPai.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionadaEmpresa "
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
            Data.Cliente input = (Data.Cliente)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];
            int idEmpresaRelacionamento = 0;
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
                    typeof(Tables.Cliente),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Cliente _data in
                    (System.Collections.Generic.List<Tables.Cliente>)this.m_EntityManager.list
                    (
                        typeof(Tables.Cliente),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (_data.clienteEmpresaRelacionamento.idEmpresaRelacionamento.value == 23127)
                        Console.Write("OK");
                    if (mode == "Roll")
                    {
                        _base = new Data.Cliente();
                        ((Data.Cliente)_base).idEmpresaRelacionamento = _data.clienteEmpresaRelacionamento.idEmpresaRelacionamento.value;
                        ((Data.Cliente)_base).limitePosPago = _data.clienteEmpresaRelacionamento.limitePosPago.value;
                        ((Data.Cliente)_base).pessoa = new Data.Pessoa { nomeRazaoSocial = _data.clienteEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value };
                        ((Data.Cliente)_base).pessoa.idPessoa = _data.clienteEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value;
                        ((Data.Cliente)_base).pessoa.cpfCnpj = _data.clienteEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value;
                        ((Data.Cliente)_base).pessoa.pfpj = _data.clienteEmpresaRelacionamento.pessoaRelacionamento.pfpj.value;

                        if (!String.IsNullOrEmpty(_data.clienteEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value))
                            if (_data.clienteEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                                ((Data.Cliente)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.clienteEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                            else
                                ((Data.Cliente)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.clienteEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");
                        else { }

                        ((Data.Cliente)_base).codigoExportacao = _data.clienteEmpresaRelacionamento.codigoExportacao.value;
                        ((Data.Cliente)_base).recebimentoPDV = _data.recebimentoPDV.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Cliente(), _data, level);

                    idEmpresaRelacionamento = ((Data.Cliente)_base).idEmpresaRelacionamento;
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
