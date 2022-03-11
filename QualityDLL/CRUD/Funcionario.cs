using System;
using System.Linq;

namespace WS.CRUD
{
    public class Funcionario : WS.CRUD.Base
    {
        public Funcionario(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Funcionario input = (Data.Funcionario)parametros["Key"];
            Tables.Funcionario bd =
            (
                parametros["Return"] != null ?
                (Tables.Funcionario)parametros["Return"] :
                 new Tables.Funcionario()
            );

            //Incluir/Alterar EmpresaRelacionamento
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.funcionarioEmpresaRelacionamento);

                input = (Data.Funcionario)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.cargo.value = input.cargo;
            bd.matricula.value = input.matricula;
            bd.comissao.value = input.comissao;
            bd.salarioBase.value = input.salarioBase;

            this.m_EntityManager.persist(bd);

            if (input.departamentosFuncionario != null)
            {
                WS.CRUD.DepartamentoFuncionario departamentoFuncionarioCRUD = new WS.CRUD.DepartamentoFuncionario(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.departamentosFuncionario.Length; i++)
                {
                    if (input.departamentosFuncionario[i].funcionario == null)
                        input.departamentosFuncionario[i].funcionario = new Data.Funcionario();

                    input.departamentosFuncionario[i].funcionario.idEmpresaRelacionamento = bd.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.departamentosFuncionario[i]);
                    departamentoFuncionarioCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                departamentoFuncionarioCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Funcionario input = (Data.Funcionario)parametros["Key"];
            Tables.Funcionario bd =
            (
                parametros["Return"] != null ?
                (Tables.Funcionario)parametros["Return"] :
                (Tables.Funcionario)this.m_EntityManager.find
                (
                    typeof(Tables.Funcionario),
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
                _parametros.Add("Return", bd.funcionarioEmpresaRelacionamento);

                input = (Data.Funcionario)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.cargo.value = input.cargo;
            bd.matricula.value = input.matricula;
            bd.comissao.value = input.comissao;
            bd.salarioBase.value = input.salarioBase;

            this.m_EntityManager.merge(bd);

            if (input.departamentosFuncionario != null)
            {
                WS.CRUD.DepartamentoFuncionario departamentoFuncionarioCRUD = new WS.CRUD.DepartamentoFuncionario(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.departamentosFuncionario.Length; i++)
                {
                    if (input.departamentosFuncionario[i].funcionario == null)
                        input.departamentosFuncionario[i].funcionario = new Data.Funcionario();

                    input.departamentosFuncionario[i].funcionario.idEmpresaRelacionamento = bd.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.departamentosFuncionario[i]);
                    if (input.departamentosFuncionario[i].operacao == ENum.eOperacao.NONE)
                        input.departamentosFuncionario[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    departamentoFuncionarioCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                departamentoFuncionarioCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Funcionario bd = new Tables.Funcionario();

            bd.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = ((Data.Funcionario)parametros["Key"]).idEmpresaRelacionamento;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Funcionario)bd).funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Funcionario)input).operacao = ENum.eOperacao.NONE;

                    input = (Data.Funcionario)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        ((Tables.Funcionario)bd).funcionarioEmpresaRelacionamento,
                        level
                    );
                    ((Data.Funcionario)input).cargo = ((Tables.Funcionario)bd).cargo.value;
                    ((Data.Funcionario)input).matricula = ((Tables.Funcionario)bd).matricula.value;
                    ((Data.Funcionario)input).comissao = ((Tables.Funcionario)bd).comissao.value;
                    ((Data.Funcionario)input).salarioBase = ((Tables.Funcionario)bd).salarioBase.value;

                    if (level < 1)
                    {
                        //Preencher DepartamentoFuncionario
                        if (((Tables.Funcionario)bd).departamentoFuncionarios != null)
                        {
                            System.Collections.Generic.List<Data.DepartamentoFuncionario> _list = new System.Collections.Generic.List<Data.DepartamentoFuncionario>();

                            foreach (Tables.DepartamentoFuncionario _item in ((Tables.Funcionario)bd).departamentoFuncionarios)
                            {
                                _list.Add
                                (
                                    (Data.DepartamentoFuncionario)
                                    (new WS.CRUD.DepartamentoFuncionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.DepartamentoFuncionario(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Funcionario)input).departamentosFuncionario = _list.OrderBy(df => df.dataTermino).ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                    else { }

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Funcionario result = (Data.Funcionario)parametros["Key"];

            try
            {
                result = (Data.Funcionario)this.preencher
                (
                    new Data.Funcionario(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Funcionario),
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

            Data.Funcionario _input = (Data.Funcionario)input;

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
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "funcionario.idFuncionario = @idFuncionario");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("funcionario.idFuncionario"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "funcionario.idFuncionario");
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
                        fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.pessoa.cpfCnpj + '%'));
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
                    "   " + (onlyCount ? " COUNT(1) " : "funcionario.* ") +
                    "from " +
                    (
                        "   funcionario funcionario " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = funcionario.idFuncionario " +
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
            Data.Funcionario input = (Data.Funcionario)parametros["Key"];
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
                    typeof(Tables.Funcionario),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Funcionario _data in
                    (System.Collections.Generic.List<Tables.Funcionario>)this.m_EntityManager.list
                    (
                        typeof(Tables.Funcionario),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Funcionario();
                        ((Data.Funcionario)_base).idEmpresaRelacionamento = _data.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value;
                        ((Data.Funcionario)_base).limitePosPago = _data.funcionarioEmpresaRelacionamento.limitePosPago.value;
                        ((Data.Funcionario)_base).pessoa = new Data.Pessoa { nomeRazaoSocial = _data.funcionarioEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value };
                        ((Data.Funcionario)_base).matricula = _data.matricula.value;
                        ((Data.Funcionario)_base).salarioBase = _data.salarioBase.value;

                        if (_data.funcionarioEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                            ((Data.Funcionario)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.funcionarioEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                        else
                            ((Data.Funcionario)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.funcionarioEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Funcionario(), _data, level);

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
