using System;

namespace WS.CRUD
{
    public class AppNotificacoes : WS.CRUD.Base
    {
        public AppNotificacoes(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.AppNotificacoes input = (Data.AppNotificacoes)parametros["Key"];
            Tables.AppNotificacoes bd = new Tables.AppNotificacoes();

            bd.idAppNotificacao.isNull = true;
            bd.dataNotificacao.value = input.dataNotificacao;
            bd.textoConteudo.value = input.textoConteudo;
            bd.textoNotificacao.value = input.textoNotificacao;
            if ((input.funcionario != null) && (input.funcionario.idEmpresaRelacionamento > 0))
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.AppNotificacoes)parametros["Key"]).idAppNotificacao = (int)bd.idAppNotificacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.AppNotificacoes input = (Data.AppNotificacoes)parametros["Key"];
            Tables.AppNotificacoes bd = (Tables.AppNotificacoes)this.m_EntityManager.find
            (
                typeof(Tables.AppNotificacoes),
                new Object[]
                {
                    input.idAppNotificacao
                }
            );
            bd.dataNotificacao.value = input.dataNotificacao;
            bd.textoConteudo.value = input.textoConteudo;
            bd.textoNotificacao.value = input.textoNotificacao;
            if ((input.funcionario != null) && (input.funcionario.idEmpresaRelacionamento > 0))
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.AppNotificacoes bd = new Tables.AppNotificacoes();

            bd.idAppNotificacao.value = ((Data.AppNotificacoes)parametros["Key"]).idAppNotificacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.AppNotificacoes)bd).idAppNotificacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.AppNotificacoes)input).operacao = ENum.eOperacao.NONE;

                    ((Data.AppNotificacoes)input).idAppNotificacao = ((Tables.AppNotificacoes)bd).idAppNotificacao.value;
                    ((Data.AppNotificacoes)input).dataNotificacao = ((Tables.AppNotificacoes)bd).dataNotificacao.value;
                    ((Data.AppNotificacoes)input).textoNotificacao = ((Tables.AppNotificacoes)bd).textoNotificacao.value;
                    ((Data.AppNotificacoes)input).textoConteudo = ((Tables.AppNotificacoes)bd).textoConteudo.value;
                    ((Data.AppNotificacoes)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.AppNotificacoes)bd).funcionario,
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
            Data.AppNotificacoes result = (Data.AppNotificacoes)parametros["Key"];

            try
            {
                result = (Data.AppNotificacoes)this.preencher
                (
                    new Data.AppNotificacoes(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.AppNotificacoes),
                        new Object[]
                        {
                            result.idAppNotificacao
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
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

            Data.AppNotificacoes _input = (Data.AppNotificacoes)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idAppNotificacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "AppNotificacoes.idAppNotificacao = @idAppNotificacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idAppNotificacao", _input.idAppNotificacao));
                    if (!sqlOrderBy.Contains("AppNotificacoes.idAppNotificacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "AppNotificacoes.idAppNotificacao");
                    else { }
                }
                else { }

                if (_input.dataNotificacao.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   AppNotificacoes.dataNotificacao = @dataNotificacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataNotificacao", _input.dataNotificacao));
                    if (!sqlOrderBy.Contains("AppNotificacoes.dataNotificacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "AppNotificacoes.dataNotificacao");
                    else { }
                }
                else { }

                if (_input.funcionario != null)
                {
                    if (_input.funcionario.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   AppNotificacoes.idFuncionario = @idFuncionario");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.funcionario.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("AppNotificacoes.idFuncionario"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "AppNotificacoes.idFuncionario");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   AppNotificacoes.*\n" +
                    "from \n" +
                    "   AppNotificacoes\n" +
                    " inner join empresaRelacionamento ON appNotificacoes.idFuncionario = empresaRelacionamento.idEmpresaRelacionamento \n" +
                    " inner join funcionario ON appNotificacoes.idFuncionario = funcionario.idFuncionario \n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.AppNotificacoes input = (Data.AppNotificacoes)parametros["Key"];
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
                    typeof(Tables.AppNotificacoes),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.AppNotificacoes _data in
                    (System.Collections.Generic.List<Tables.AppNotificacoes>)this.m_EntityManager.list
                    (
                        typeof(Tables.AppNotificacoes),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.AppNotificacoes(), _data, level);

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
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
