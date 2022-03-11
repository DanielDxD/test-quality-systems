using System;

namespace WS.CRUD
{
    public class PdvEstacoesSangria : WS.CRUD.Base
    {
        public PdvEstacoesSangria(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesSangria input = (Data.PdvEstacoesSangria)parametros["Key"];
            Tables.PdvEstacoesSangria bd = new Tables.PdvEstacoesSangria();

            bd.idPdvEstacaoSangria.isNull = true;
            bd.dataSangria.value = input.dataSangria;
            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if (input.funcionario != null && input.funcionario.idEmpresaRelacionamento > 0)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }
            bd.observacao.value = input.observacao;
            bd.valor.value = input.valor;

            this.m_EntityManager.persist(bd);

            ((Data.PdvEstacoesSangria)parametros["Key"]).idPdvEstacaoSangria = (int)bd.idPdvEstacaoSangria.value;            

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesSangria input = (Data.PdvEstacoesSangria)parametros["Key"];
            Tables.PdvEstacoesSangria bd = (Tables.PdvEstacoesSangria)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacoesSangria),
                new Object[]
                {
                    input.idPdvEstacaoSangria
                }
            );

            bd.dataSangria.value = input.dataSangria;
            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if (input.funcionario != null && input.funcionario.idEmpresaRelacionamento > 0)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }
            bd.observacao.value = input.observacao;
            bd.valor.value = input.valor;

            this.m_EntityManager.merge(bd);

            

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacoesSangria bd = new Tables.PdvEstacoesSangria();

            bd.idPdvEstacaoSangria.value = ((Data.PdvEstacoesSangria)parametros["Key"]).idPdvEstacaoSangria;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacoesSangria)bd).idPdvEstacaoSangria.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacoesSangria)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacoesSangria)input).idPdvEstacaoSangria = ((Tables.PdvEstacoesSangria)bd).idPdvEstacaoSangria.value;
                    ((Data.PdvEstacoesSangria)input).dataSangria = ((Tables.PdvEstacoesSangria)bd).dataSangria.value;
                    ((Data.PdvEstacoesSangria)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacao(),
                        ((Tables.PdvEstacoesSangria)bd).pdvEstacao,
                        level + 1
                    );
                    ((Data.PdvEstacoesSangria)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.PdvEstacoesSangria)bd).funcionario,
                        level + 1
                    );
                    ((Data.PdvEstacoesSangria)input).valor = ((Tables.PdvEstacoesSangria)bd).valor.value;
                    ((Data.PdvEstacoesSangria)input).observacao = ((Tables.PdvEstacoesSangria)bd).observacao.value;
                }
                else { }               
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesSangria result = (Data.PdvEstacoesSangria)parametros["Key"];

            try
            {
                result = (Data.PdvEstacoesSangria)this.preencher
                (
                    new Data.PdvEstacoesSangria(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PdvEstacoesSangria),
                        new Object[]
                        {
                            result.idPdvEstacaoSangria
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

            Data.PdvEstacoesSangria _input = (Data.PdvEstacoesSangria)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvEstacaoSangria > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesSangria.idPdvEstacaoSangria = @idPdvEstacaoSangria");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoSangria", _input.idPdvEstacaoSangria));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesSangria.idPdvEstacaoSangria");
                }
                else { }

                if (_input.pdvEstacao != null)
                {
                    if (_input.pdvEstacao.idPdvEstacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesSangria.idPdvEstacao = @idPdvEstacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesSangria.idPdvEstacao");
                    }
                    else { }
                }
                else { }

                if (_input.funcionario != null)
                {
                    if (_input.funcionario.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesSangria.idFuncionario = @idFuncionario");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.funcionario.idEmpresaRelacionamento));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesSangria.idFuncionario");
                    }
                    else { }

                    if (_input.funcionario.pessoa != null)
                    {
                        if ((_input.funcionario.pessoa != null) && (_input.funcionario.pessoa.idPessoa > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.funcionario.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if ((_input.funcionario.pessoa.cpfCnpj != null) && (_input.funcionario.pessoa.cpfCnpj.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.funcionario.pessoa.cpfCnpj + '%'));
                            if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                            else { }
                        }
                        else { }

                        if ((_input.funcionario.pessoa.nomeRazaoSocial != null) && (_input.funcionario.pessoa.nomeRazaoSocial.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.funcionario.pessoa.nomeRazaoSocial + '%'));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.valor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesSangria.valor = @valor");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valor", _input.valor));
                    if (!sqlOrderBy.Contains("pdvEstacoesSangria.valor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesSangria.valor");
                    else { }
                }
                else { }                

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pdvEstacoesSangria.* ") +
                    "from " +
                    (
                        "   pdvEstacoesSangria pdvEstacoesSangria\n " +
                        "       inner join pdvEstacoes pdvEstacoes\n" +
                        "           on pdvEstacoes.idPdvEstacao = pdvEstacoesSangria.idPdvEstacao\n" +
                        "       inner join empresaRelacionamento empresaRelacionamento\n " +
                        "           on empresaRelacionamento.idEmpresaRelacionamento = pdvEstacoesSangria.idFuncionario\n " +
                        "       LEFT join pessoa pessoa\n " +
                        "           on pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n"
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
            Data.PdvEstacoesSangria input = (Data.PdvEstacoesSangria)parametros["Key"];
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
                    typeof(Tables.PdvEstacoesSangria),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PdvEstacoesSangria _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesSangria>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesSangria),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.PdvEstacoesSangria(), _data, level);

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
