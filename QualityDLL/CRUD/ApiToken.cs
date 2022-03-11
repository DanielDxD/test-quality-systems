using DataTypes;
using System;

namespace WS.CRUD
{
    public class ApiToken : WS.CRUD.Base
    {
        public ApiToken(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ApiToken input = (Data.ApiToken)parametros["Key"];
            Tables.ApiToken bd = new Tables.ApiToken();


            bd.apiCredencial.idApiCredencial.value = input.apiCredencial.idApiCredencial;
            bd.token.value = input.token;
            bd.expiresIn.value = input.expiresIn;
            bd.usuario.idUsuario.value = input.usuario.idUsuario;

            this.m_EntityManager.persist(bd);

            // ((Data.ApiToken)parametros["Key"]).idApiToken = (int)bd.idApiToken.value;           

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ApiToken input = (Data.ApiToken)parametros["Key"];
            Tables.ApiToken bd = (Tables.ApiToken)this.m_EntityManager.find
            (
                typeof(Tables.ApiToken),
                new Object[]
                {
                    (int)input.apiCredencial.idApiCredencial,
                    input.usuario.idUsuario
                }
            );


            bd.apiCredencial.idApiCredencial.value = input.apiCredencial.idApiCredencial;
            bd.token.value = input.token;
            bd.expiresIn.value = input.expiresIn;
            bd.usuario.idUsuario.value = input.usuario.idUsuario;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ApiToken bd = new Tables.ApiToken();

            bd.apiCredencial.idApiCredencial.value = (int)((Data.ApiToken)parametros["Key"]).apiCredencial.idApiCredencial;
            bd.usuario.idUsuario.value = ((Data.ApiToken)parametros["Key"]).usuario.idUsuario;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ApiToken)bd).apiCredencial.idApiCredencial.isNull && !((Tables.ApiToken)bd).usuario.idUsuario.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ApiToken)input).operacao = ENum.eOperacao.NONE;
                    ((Data.ApiToken)input).token = ((Tables.ApiToken)bd).token.value;
                    ((Data.ApiToken)input).expiresIn = ((Tables.ApiToken)bd).expiresIn.value;

                    ((Data.ApiToken)input).usuario = (Data.Usuario)(new WS.CRUD.Usuario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Usuario(),
                        ((Tables.ApiToken)bd).usuario,
                        level + 1
                    );
                    ((Data.ApiToken)input).apiCredencial = (Data.ApiCredencial)(new WS.CRUD.ApiCredencial(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ApiCredencial(),
                        ((Tables.ApiToken)bd).apiCredencial,
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
            Data.ApiToken result = (Data.ApiToken)parametros["Key"];

            try
            {
                result = (Data.ApiToken)this.preencher
                (
                    new Data.ApiToken(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ApiToken),
                        new Object[]
                        {
                            result.apiCredencial.idApiCredencial,
                            result.usuario.idUsuario
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ApiToken input = (Data.ApiToken)parametros["Key"];
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
                    typeof(Tables.ApiToken),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ApiToken _data in
                    (System.Collections.Generic.List<Tables.ApiToken>)this.m_EntityManager.list
                    (
                        typeof(Tables.ApiToken),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ApiToken(), _data, level);

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

            Data.ApiToken _input = (Data.ApiToken)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (!String.IsNullOrEmpty(_input.token))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ApiToken.token = @token");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("token", _input.token));
                    if (!sqlOrderBy.Contains("ApiToken.token"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ApiToken.token");
                    else { }
                }
                else { }

                if (_input.usuario != null)
                {
                    if (_input.usuario.idUsuario > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ApiToken.idUsuario = @idUsuario");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUsuario", _input.usuario.idUsuario));
                        if (!sqlOrderBy.Contains("ApiToken.idUsuario"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ApiToken.idUsuario");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.apiCredencial != null)
                {
                    if (_input.apiCredencial.idApiCredencial > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ApiToken.idApiCredencial = @idApiCredencial");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idApiCredencial", _input.apiCredencial.idApiCredencial));
                        if (!sqlOrderBy.Contains("ApiToken.idApiCredencial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ApiToken.idApiCredencial");
                        else { }
                    }
                    else { }
                    if ((int)_input.apiCredencial.provedor > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "apiCredencial.provedor = @provedor");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("provedor", (int)_input.apiCredencial.provedor));
                        if (!sqlOrderBy.Contains("apiCredencial.provedor"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "apiCredencial.provedor");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ApiToken.* ") +
                    "from " +
                    (
                        "   ApiToken ApiToken " +
                        " INNER JOIN apiCredencial ON apiCredencial.idApiCredencial = apitoken.idapicredencial \n" +
                        " INNER JOIN usuario ON usuario.idUsuario = apiToken.idUsuario" 
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
    }
}
