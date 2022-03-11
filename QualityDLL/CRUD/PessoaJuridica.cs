using System;

namespace WS.CRUD
{
    public class PessoaJuridica : WS.CRUD.Base
    {
        public PessoaJuridica(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaJuridica input = (Data.PessoaJuridica)parametros["Key"];
            Tables.PessoaJuridica bd =
            (
                parametros["Return"] != null ?
                (Tables.PessoaJuridica)parametros["Return"] :
                new Tables.PessoaJuridica()
            );

            //Incluir/Alterar Pessoa
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.pessoa);

                input = (Data.PessoaJuridica)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.pessoa.idPessoa.value = input.idPessoa;
            bd.dataFundacao.value = input.dataFundacao;
            if ((input.atividadeEconomicaPrimaria != null) && (input.atividadeEconomicaPrimaria.idAtividadeEconomica > 0))
                bd.atividadeEconomicaPrimaria.idAtividadeEconomica.value = input.atividadeEconomicaPrimaria.idAtividadeEconomica;
            else
                bd.atividadeEconomicaPrimaria.idAtividadeEconomica.isNull = true;
            if ((input.atividadeEconomicaSecundaria != null) && (input.atividadeEconomicaSecundaria.idAtividadeEconomica > 0))
                bd.atividadeEconomicaSecundaria.idAtividadeEconomica.value = input.atividadeEconomicaSecundaria.idAtividadeEconomica;
            else
                bd.atividadeEconomicaSecundaria.idAtividadeEconomica.isNull = true;
            bd.inscricaoEstadual.value = input.inscricaoEstadual;
            bd.inscricaoMunicipal.value = input.inscricaoMunicipal;
            bd.inscricaoEstadualST.value = input.inscricaoEstadualST;

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaJuridica input = (Data.PessoaJuridica)parametros["Key"];
            Tables.PessoaJuridica bd =
            (
                parametros["Return"] != null ?
                (Tables.PessoaJuridica)parametros["Return"] :
                (Tables.PessoaJuridica)this.m_EntityManager.find
                (
                    typeof(Tables.PessoaJuridica),
                    new Object[]
                    {
                        input.idPessoa
                    }
                )
            );

            //Alterar Pessoa
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.pessoa);

                input = (Data.PessoaJuridica)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.dataFundacao.value = input.dataFundacao;
            if ((input.atividadeEconomicaPrimaria != null) && (input.atividadeEconomicaPrimaria.idAtividadeEconomica > 0))
                bd.atividadeEconomicaPrimaria.idAtividadeEconomica.value = input.atividadeEconomicaPrimaria.idAtividadeEconomica;
            else
                bd.atividadeEconomicaPrimaria.idAtividadeEconomica.isNull = true;
            if ((input.atividadeEconomicaSecundaria != null) && (input.atividadeEconomicaSecundaria.idAtividadeEconomica > 0))
                bd.atividadeEconomicaSecundaria.idAtividadeEconomica.value = input.atividadeEconomicaSecundaria.idAtividadeEconomica;
            else
                bd.atividadeEconomicaSecundaria.idAtividadeEconomica.isNull = true;
            bd.inscricaoEstadual.value = input.inscricaoEstadual;
            bd.inscricaoMunicipal.value = input.inscricaoMunicipal;
            bd.inscricaoEstadualST.value = input.inscricaoEstadualST;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaJuridica bd = new Tables.PessoaJuridica();

            bd.pessoa.idPessoa.value = ((Data.PessoaJuridica)parametros["Key"]).idPessoa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaJuridica)bd).pessoa.idPessoa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaJuridica)input).operacao = ENum.eOperacao.NONE;

                    input = (Data.PessoaJuridica)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        ((Tables.PessoaJuridica)bd).pessoa,
                        level
                    );
                    ((Data.PessoaJuridica)input).dataFundacao = ((Tables.PessoaJuridica)bd).dataFundacao.value;
                    ((Data.PessoaJuridica)input).atividadeEconomicaPrimaria = (Data.AtividadeEconomica)(new WS.CRUD.AtividadeEconomica(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.AtividadeEconomica(),
                        ((Tables.PessoaJuridica)bd).atividadeEconomicaPrimaria,
                        level + 1
                    );
                    ((Data.PessoaJuridica)input).atividadeEconomicaSecundaria = (Data.AtividadeEconomica)(new WS.CRUD.AtividadeEconomica(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.AtividadeEconomica(),
                        ((Tables.PessoaJuridica)bd).atividadeEconomicaSecundaria,
                        level + 1
                    );
                    ((Data.PessoaJuridica)input).inscricaoEstadual = ((Tables.PessoaJuridica)bd).inscricaoEstadual.value;
                    ((Data.PessoaJuridica)input).inscricaoMunicipal = ((Tables.PessoaJuridica)bd).inscricaoMunicipal.value;
                    ((Data.PessoaJuridica)input).inscricaoEstadualST = ((Tables.PessoaJuridica)bd).inscricaoEstadualST.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaJuridica result = (Data.PessoaJuridica)parametros["Key"];

            try
            {
                result = (Data.PessoaJuridica)this.preencher
                (
                    new Data.PessoaJuridica(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaJuridica),
                        new Object[]
                        {
                            result.idPessoa
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

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
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

            Data.PessoaJuridica _input = (Data.PessoaJuridica)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pessoa.pfPj = 'J'";

                if (_input.idPessoa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.idPessoa));
                    if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                    else { }
                }
                else { }

                if ((_input.cpfCnpj != null) && (_input.cpfCnpj.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.cpfCnpj + '%'));
                    if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                    else { }
                }
                else { }

                if ((_input.nomeRazaoSocial != null) && (_input.nomeRazaoSocial.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.nomeRazaoSocial + '%'));
                    if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "pessoaJuridica.* " +
                    "from " +
                    (
                    "pessoaJuridica pessoaJuridica " +
                        "inner join pessoa pessoa " +
                            "on pessoa.idPessoa = pessoaJuridica.idPessoaJuridica "
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PessoaJuridica input = (Data.PessoaJuridica)parametros["Key"];
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
                    typeof(Tables.PessoaJuridica),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaJuridica _data in
                    (System.Collections.Generic.List<Tables.PessoaJuridica>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaJuridica),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.PessoaJuridica();
                        ((Data.PessoaJuridica)_base).idPessoa = _data.pessoa.idPessoa.value;
                        ((Data.PessoaJuridica)_base).nomeRazaoSocial = _data.pessoa.nomeRazaoSocial.value;
                        ((Data.PessoaJuridica)_base).cpfCnpj = _data.pessoa.cpfCnpj.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.PessoaJuridica(), _data, level);

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
