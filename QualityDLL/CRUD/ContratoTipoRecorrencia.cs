using System;

namespace WS.CRUD
{
    public class ContratoTipoRecorrencia : WS.CRUD.Base
    {
        public ContratoTipoRecorrencia(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoRecorrencia input = (Data.ContratoTipoRecorrencia)parametros["Key"];
            Tables.ContratoTipoRecorrencia bd = new Tables.ContratoTipoRecorrencia();

            bd.idContratoTipoRecorrencia.isNull = true;
            bd.descricao.value = input.descricao;
            bd.recorrencia.value = input.recorrencia;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.ContratoTipoRecorrencia)parametros["Key"]).idContratoTipoRecorrencia = (int)bd.idContratoTipoRecorrencia.value;

            return input;
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoRecorrencia input = (Data.ContratoTipoRecorrencia)parametros["Key"];
            Tables.ContratoTipoRecorrencia bd = (Tables.ContratoTipoRecorrencia)this.m_EntityManager.find
            (
                typeof(Tables.ContratoTipoRecorrencia),
                new Object[]
                {
                    input.idContratoTipoRecorrencia
                }
            );

            bd.descricao.value = input.descricao;
            bd.recorrencia.value = input.recorrencia;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);
            return input;
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContratoTipoRecorrencia bd = new Tables.ContratoTipoRecorrencia();

            bd.idContratoTipoRecorrencia.value = ((Data.ContratoTipoRecorrencia)parametros["Key"]).idContratoTipoRecorrencia;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContratoTipoRecorrencia)bd).idContratoTipoRecorrencia.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContratoTipoRecorrencia)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContratoTipoRecorrencia)input).idContratoTipoRecorrencia = ((Tables.ContratoTipoRecorrencia)bd).idContratoTipoRecorrencia.value;
                    ((Data.ContratoTipoRecorrencia)input).descricao = ((Tables.ContratoTipoRecorrencia)bd).descricao.value;
                    ((Data.ContratoTipoRecorrencia)input).recorrencia = ((Tables.ContratoTipoRecorrencia)bd).recorrencia.value;
                    ((Data.ContratoTipoRecorrencia)input).observacao = ((Tables.ContratoTipoRecorrencia)bd).observacao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoRecorrencia result = (Data.ContratoTipoRecorrencia)parametros["Key"];

            try
            {
                result = (Data.ContratoTipoRecorrencia)this.preencher
                (
                    new Data.ContratoTipoRecorrencia(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContratoTipoRecorrencia),
                        new Object[]
                        {
                            result.idContratoTipoRecorrencia
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
            Data.ContratoTipoRecorrencia input = (Data.ContratoTipoRecorrencia)parametros["Key"];
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
                    typeof(Tables.ContratoTipoRecorrencia),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContratoTipoRecorrencia _data in
                    (System.Collections.Generic.List<Tables.ContratoTipoRecorrencia>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContratoTipoRecorrencia),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContratoTipoRecorrencia(), _data, level);

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

            Data.ContratoTipoRecorrencia _input = (Data.ContratoTipoRecorrencia)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContratoTipoRecorrencia > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipoRecorrencia.idContratoTipoRecorrencia = @idContratoTipoRecorrencia");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContratoTipoRecorrencia", _input.idContratoTipoRecorrencia));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipoRecorrencia.idContratoTipoRecorrencia");
                }
                else { }

                if (_input.recorrencia > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipoRecorrencia.recorrencia = @recorrencia");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("recorrencia", _input.recorrencia));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipoRecorrencia.recorrencia");
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipoRecorrencia.descricao LIKE @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipoRecorrencia.descricao");
                }
                else { }

                if (!String.IsNullOrEmpty(_input.observacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipoRecorrencia.observacao LIKE @observacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("observacao", "%" + _input.observacao + "%"));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipoRecorrencia.observacao");
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contratoTipoRecorrencia.* ") +
                    "from " +
                    (
                        "   contratoTipoRecorrencia contratoTipoRecorrencia "
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
