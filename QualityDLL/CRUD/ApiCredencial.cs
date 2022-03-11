using DataTypes;
using System;

namespace WS.CRUD
{
    public class ApiCredencial : WS.CRUD.Base
    {
        public ApiCredencial(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ApiCredencial input = (Data.ApiCredencial)parametros["Key"];
            Tables.ApiCredencial bd = new Tables.ApiCredencial();

            bd.idApiCredencial.isNull = true;
            bd.empresa.idEmpresa.value = input.empresa.idEmpresa;
            bd.descricao.value = input.descricao;
            bd.provedor.value = (int)input.provedor;
            bd.client_id.value = input.client_id;
            bd.client_secret.value = input.client_secret;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.ApiCredencial)parametros["Key"]).idApiCredencial = (int)bd.idApiCredencial.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ApiCredencial input = (Data.ApiCredencial)parametros["Key"];
            Tables.ApiCredencial bd = (Tables.ApiCredencial)this.m_EntityManager.find
            (
                typeof(Tables.ApiCredencial),
                new Object[]
                {
                    input.idApiCredencial
                }
            );

            bd.empresa.idEmpresa.value = input.empresa.idEmpresa;
            bd.descricao.value = input.descricao;
            bd.provedor.value = (int)input.provedor;
            bd.client_id.value = input.client_id;
            bd.client_secret.value = input.client_secret;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ApiCredencial bd = new Tables.ApiCredencial();

            bd.idApiCredencial.value = ((Data.ApiCredencial)parametros["Key"]).idApiCredencial;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ApiCredencial)bd).idApiCredencial.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ApiCredencial)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ApiCredencial)input).idApiCredencial = ((Tables.ApiCredencial)bd).idApiCredencial.value;
                    ((Data.ApiCredencial)input).empresa = (Data.Empresa)(new WS.CRUD.Empresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Empresa(),
                        ((Tables.ApiCredencial)bd).empresa,
                        level + 1
                    );

                    ((Data.ApiCredencial)input).provedor = (ProvedorToken)Enum.ToObject(typeof(ProvedorToken), ((Tables.ApiCredencial)bd).provedor.value);
                    ((Data.ApiCredencial)input).descricao = ((Tables.ApiCredencial)bd).descricao.value;
                    ((Data.ApiCredencial)input).client_secret = ((Tables.ApiCredencial)bd).client_secret.value;
                    ((Data.ApiCredencial)input).client_id = ((Tables.ApiCredencial)bd).client_id.value;
                    ((Data.ApiCredencial)input).observacao = ((Tables.ApiCredencial)bd).observacao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ApiCredencial result = (Data.ApiCredencial)parametros["Key"];

            try
            {
                result = (Data.ApiCredencial)this.preencher
                (
                    new Data.ApiCredencial(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ApiCredencial),
                        new Object[]
                        {
                            result.idApiCredencial
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

            Data.ApiCredencial _input = (Data.ApiCredencial)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idApiCredencial > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ApiCredencial.idApiCredencial = @idApiCredencial");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idApiCredencial", _input.idApiCredencial));
                    if (!sqlOrderBy.Contains("ApiCredencial.idApiCredencial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ApiCredencial.idApiCredencial");
                    else { }
                }
                else { }

                if ((int)_input.provedor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ApiCredencial.provedor = @provedor");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("provedor", (int)_input.provedor));
                    if (!sqlOrderBy.Contains("ApiCredencial.provedor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ApiCredencial.provedor");
                    else { }
                }
                else { }

                if (_input.empresa != null)
                {
                    if (_input.empresa.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   empresa.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.empresa.idEmpresa));
                        if (!sqlOrderBy.Contains("empresa.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresa.idEmpresa");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ApiCredencial.descricao Collate Latin1_General_CI_AI like @descricao Collate Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("ApiCredencial.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ApiCredencial.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ApiCredencial.* ") +
                    "from\n" +
                    "   ApiCredencial ApiCredencial\n" +
                    "       inner join empresa empresa \n" +
                    "           on ApiCredencial.idEmpresa = empresa.idEmpresa \n" +
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
            Data.ApiCredencial input = (Data.ApiCredencial)parametros["Key"];
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
                    typeof(Tables.ApiCredencial),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ApiCredencial _data in
                    (System.Collections.Generic.List<Tables.ApiCredencial>)this.m_EntityManager.list
                    (
                        typeof(Tables.ApiCredencial),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.ApiCredencial(), _data, level);

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
