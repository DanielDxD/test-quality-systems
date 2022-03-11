using System;
using System.Collections.Generic;
using Utils;

namespace WS.CRUD
{
    public class Convidado : WS.CRUD.Base
    {
        public Convidado(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Convidado input = (Data.Convidado)parametros["Key"];
            Tables.Convidado bd =
            (
                parametros["Return"] != null ?
                (Tables.Convidado)parametros["Return"] :
                new Tables.Convidado()
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
                    tre.tipo = "SC";
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

                _parametros.Add("Return", bd.convidadoEmpresaRelacionamento);

                input = (Data.Convidado)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }
    

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Convidado input = (Data.Convidado)parametros["Key"];
            Tables.Convidado bd =
            (
                parametros["Return"] != null ?
                (Tables.Convidado)parametros["Return"] :
                (Tables.Convidado)this.m_EntityManager.find
                (
                    typeof(Tables.Convidado),
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
                _parametros.Add("Return", bd.convidadoEmpresaRelacionamento);

                input = (Data.Convidado)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }
            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Convidado bd = new Tables.Convidado();

            bd.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value = ((Data.Convidado)parametros["Key"]).idEmpresaRelacionamento;
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
                        (bd.GetType().Name == typeof(Tables.Convidado).Name) &&
                        !((Tables.Convidado)bd).convidadoEmpresaRelacionamento.idEmpresaRelacionamento.isNull
                    )
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Convidado)input).operacao = ENum.eOperacao.NONE;

                    input = (Data.Convidado)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        (
                            (bd.GetType().Name == typeof(Tables.EmpresaRelacionamento).Name) ?
                            bd :
                            ((Tables.Convidado)bd).convidadoEmpresaRelacionamento
                        ),
                        level
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
            Data.Convidado result = (Data.Convidado)parametros["Key"];

            String queryString = "";

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                //usuario
                if ((result.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idConvidado", result.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "convidado.idConvidado = @idConvidado";
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
                    "    convidado\n" +
                    "        inner join empresaRelacionamento\n" +
                    "            on	empresaRelacionamento.idEmpresaRelacionamento = convidado.idConvidado\n" +
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
                    Tables.Convidado _data in
                    (System.Collections.Generic.List<Tables.Convidado>)this.m_EntityManager.list
                    (
                        typeof(Tables.Convidado),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.Convidado)this.preencher
                    (
                        new Data.Convidado(),
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

            Data.Convidado _input = (Data.Convidado)input;

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
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "convidado.idConvidado = @idConvidado");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idConvidado", _input.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("convidado.idConvidado"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "convidado.idConvidado");
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

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "convidado.* ") +
                    "from " +
                    (
                        "   convidado convidado" +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = convidado.idConvidado " +
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
            Data.Convidado input = (Data.Convidado)parametros["Key"];
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
                    typeof(Tables.Convidado),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Convidado _data in
                    (System.Collections.Generic.List<Tables.Convidado>)this.m_EntityManager.list
                    (
                        typeof(Tables.Convidado),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (_data.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value == 23127)
                        Console.Write("OK");
                    if (mode == "Roll")
                    {
                        _base = new Data.Convidado();
                        ((Data.Convidado)_base).idEmpresaRelacionamento = _data.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value;
                        ((Data.Convidado)_base).limitePosPago = _data.convidadoEmpresaRelacionamento.limitePosPago.value;
                        ((Data.Convidado)_base).pessoa = new Data.Pessoa { nomeRazaoSocial = _data.convidadoEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value };
                        ((Data.Convidado)_base).pessoa.idPessoa = _data.convidadoEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value;
                        ((Data.Convidado)_base).pessoa.cpfCnpj = _data.convidadoEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value;
                        ((Data.Convidado)_base).pessoa.pfpj = _data.convidadoEmpresaRelacionamento.pessoaRelacionamento.pfpj.value;

                        if (!String.IsNullOrEmpty(_data.convidadoEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value))
                            if (_data.convidadoEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                                ((Data.Convidado)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.convidadoEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                            else
                                ((Data.Convidado)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.convidadoEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");
                        else { }
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Convidado(), _data, level);

                    idEmpresaRelacionamento = ((Data.Convidado)_base).idEmpresaRelacionamento;
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
