using System;

namespace WS.CRUD
{
    public class UnidadeProdutoServico : WS.CRUD.Base
    {
        public UnidadeProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.UnidadeProdutoServico input = (Data.UnidadeProdutoServico)parametros["Key"];
            Tables.UnidadeProdutoServico bd = new Tables.UnidadeProdutoServico();

            bd.idUnidadeProdutoServico.isNull = true;
            bd.descricao.value = input.descricao;
            bd.sigla.value = input.sigla;

            this.m_EntityManager.persist(bd);

            ((Data.UnidadeProdutoServico)parametros["Key"]).idUnidadeProdutoServico = (int)bd.idUnidadeProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.UnidadeProdutoServico input = (Data.UnidadeProdutoServico)parametros["Key"];
            Tables.UnidadeProdutoServico bd = (Tables.UnidadeProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.UnidadeProdutoServico),
                new Object[]
                {
                    input.idUnidadeProdutoServico
                }
            );

            bd.descricao.value = input.descricao;
            bd.sigla.value = input.sigla;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.UnidadeProdutoServico bd = new Tables.UnidadeProdutoServico();

            bd.idUnidadeProdutoServico.value = ((Data.UnidadeProdutoServico)parametros["Key"]).idUnidadeProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.UnidadeProdutoServico)bd).idUnidadeProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.UnidadeProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.UnidadeProdutoServico)input).idUnidadeProdutoServico = ((Tables.UnidadeProdutoServico)bd).idUnidadeProdutoServico.value;
                    ((Data.UnidadeProdutoServico)input).descricao = ((Tables.UnidadeProdutoServico)bd).descricao.value;
                    ((Data.UnidadeProdutoServico)input).sigla = ((Tables.UnidadeProdutoServico)bd).sigla.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.UnidadeProdutoServico result = (Data.UnidadeProdutoServico)parametros["Key"];

            try
            {
                result = (Data.UnidadeProdutoServico)this.preencher
                (
                    new Data.UnidadeProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.UnidadeProdutoServico),
                        new Object[]
                        {
                            result.idUnidadeProdutoServico
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

            Data.UnidadeProdutoServico _input = (Data.UnidadeProdutoServico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere = "";

                if (_input.idUnidadeProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "unidadeProdutoServico.idUnidadeProdutoServico = @idUnidadeProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUnidadeProdutoServico", _input.idUnidadeProdutoServico));
                    if (!sqlOrderBy.Contains("unidadeProdutoServico.idUnidadeProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "unidadeProdutoServico.idUnidadeProdutoServico");
                    else { }
                }
                else { }

                if ((_input.descricao != null) && (_input.descricao.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "unidadeProdutoServico.descricao COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("unidadeProdutoServico.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "unidadeProdutoServico.descricao");
                    else { };
                }
                else { }

                if ((_input.sigla != null) && (_input.sigla.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "unidadeProdutoServico.sigla COLLATE Latin1_General_CI_AI = @sigla COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("sigla", _input.sigla));
                    if (!sqlOrderBy.Contains("unidadeProdutoServico.sigla"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "unidadeProdutoServico.sigla");
                    else { };
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "unidadeProdutoServico.* ") +
                    "from " +
                        "   unidadeProdutoServico " +
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
            Data.UnidadeProdutoServico input = (Data.UnidadeProdutoServico)parametros["Key"];
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
                    typeof(Tables.UnidadeProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.UnidadeProdutoServico _data in
                    (System.Collections.Generic.List<Tables.UnidadeProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.UnidadeProdutoServico),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.UnidadeProdutoServico(), _data, level);

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
