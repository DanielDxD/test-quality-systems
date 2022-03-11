using System;

namespace WS.CRUD
{
    public class PdvEstacoesConfig : WS.CRUD.Base
    {
        public PdvEstacoesConfig(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesConfig input = (Data.PdvEstacoesConfig)parametros["Key"];
            Tables.PdvEstacoesConfig bd = new Tables.PdvEstacoesConfig();

            bd.idPdvEstacao.isNull = true;
            bd.idPdvEstacao.value = input.idPdvEstacao;

            bd.nomeConfig.value = input.nomeConfig;
            bd.valor.value = input.valor;

            this.m_EntityManager.persist(bd);

            ((Data.PdvEstacoesConfig)parametros["Key"]).idPdvEstacao = (int)bd.idPdvEstacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesConfig input = (Data.PdvEstacoesConfig)parametros["Key"];
            Tables.PdvEstacoesConfig bd = (Tables.PdvEstacoesConfig)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacoesConfig),
                new Object[]
                {
                    input.idPdvEstacao,
                    input.nomeConfig
                }
            );

            bd.idPdvEstacao.value = input.idPdvEstacao;
            bd.nomeConfig.value = input.nomeConfig;
            bd.valor.value = input.valor;


            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacoesConfig bd = new Tables.PdvEstacoesConfig();

            bd.idPdvEstacao.value = ((Data.PdvEstacoesConfig)parametros["Key"]).idPdvEstacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacoesConfig)bd).idPdvEstacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacoesConfig)input).operacao = ENum.eOperacao.NONE;
                    ((Data.PdvEstacoesConfig)input).nomeConfig = ((Tables.PdvEstacoesConfig)bd).nomeConfig.value;
                    ((Data.PdvEstacoesConfig)input).valor = ((Tables.PdvEstacoesConfig)bd).valor.value;
                    ((Data.PdvEstacoesConfig)input).idPdvEstacao = ((Tables.PdvEstacoesConfig)bd).idPdvEstacao.value;

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesConfig result = (Data.PdvEstacoesConfig)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.idPdvEstacao > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", result.idPdvEstacao));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesConfig.idPdvEstacao = @idPdvEstacao";
                }
                else { }

                if (!String.IsNullOrEmpty(result.nomeConfig))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeConfig", result.nomeConfig));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesConfig.nomeConfig = @nomeConfig";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    pdvEstacoesConfig.*\n" +
                    "from \n" + 
                    "    pdvEstacoesConfig\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    )
                );

                foreach
                (
                    Tables.PdvEstacoesConfig _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesConfig>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesConfig),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvEstacoesConfig)this.preencher
                    (
                        new Data.PdvEstacoesConfig(),
                        _data,
                        0
                    );
                }
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
            Data.PdvEstacoesConfig input = (Data.PdvEstacoesConfig)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);



            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.PdvEstacoesConfig),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.PdvEstacoesConfig _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesConfig>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesConfig),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.PdvEstacoesConfig(), _data, level);

                    result.Add(_base);
                }


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

            Data.PdvEstacoesConfig _input = (Data.PdvEstacoesConfig)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvEstacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesConfig.idPdvEstacao = @idPdvEstacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.idPdvEstacao));
                    if (!sqlOrderBy.Contains("pdvEstacoesConfig.idPdvEstacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesConfig.idPdvEstacao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.nomeConfig))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvEstacoesConfig.nomeConfig = @nomeConfig");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeConfig", _input.nomeConfig));
                    if (!sqlOrderBy.Contains("pdvEstacoesConfig.nomeConfig"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesConfig.nomeConfig");
                    else { }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pdvEstacoesConfig.* ") +
                    " from pdvEstacoesConfig pdvEstacoesConfig " +
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
