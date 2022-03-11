using System;

namespace WS.CRUD
{
    public class EstadoCivil : WS.CRUD.Base
    {
        public EstadoCivil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EstadoCivil input = (Data.EstadoCivil)parametros["Key"];
            Tables.EstadoCivil bd = new Tables.EstadoCivil();

            bd.idEstadoCivil.isNull = true;
            bd.descricao.value = input.descricao;
            bd.temConjuge.value = input.temConjuge;

            this.m_EntityManager.persist(bd);

            ((Data.EstadoCivil)parametros["Key"]).idEstadoCivil = (int)bd.idEstadoCivil.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EstadoCivil input = (Data.EstadoCivil)parametros["Key"];
            Tables.EstadoCivil bd = (Tables.EstadoCivil)this.m_EntityManager.find
            (
                typeof(Tables.EstadoCivil),
                new Object[]
                {
                    input.idEstadoCivil
                }
            );

            bd.descricao.value = input.descricao;
            bd.temConjuge.value = input.temConjuge;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EstadoCivil bd = new Tables.EstadoCivil();

            bd.idEstadoCivil.value = ((Data.EstadoCivil)parametros["Key"]).idEstadoCivil;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EstadoCivil)bd).idEstadoCivil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EstadoCivil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EstadoCivil)input).idEstadoCivil = ((Tables.EstadoCivil)bd).idEstadoCivil.value;
                    ((Data.EstadoCivil)input).descricao = ((Tables.EstadoCivil)bd).descricao.value;
                    ((Data.EstadoCivil)input).temConjuge = ((Tables.EstadoCivil)bd).temConjuge.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.EstadoCivil result = (Data.EstadoCivil)parametros["Key"];

            try
            {
                result = (Data.EstadoCivil)this.preencher
                (
                    new Data.EstadoCivil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EstadoCivil),
                        new Object[]
                        {
                            result.idEstadoCivil
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

            Data.EstadoCivil _input = (Data.EstadoCivil)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEstadoCivil > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "estadoCivil.idEstadoCivil = @idEstadoCivil");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEstadoCivil", _input.idEstadoCivil));
                    if (!sqlOrderBy.Contains("estadoCivil.idEstadoCivil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estadoCivil.idEstadoCivil");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   estadoCivil.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("estadoCivil.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estadoCivil.descricao");
                    else { }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "estadoCivil.* ") +
                    "from " +
                    "   estadoCivil " +
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
            Data.EstadoCivil input = (Data.EstadoCivil)parametros["Key"];
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
                    typeof(Tables.EstadoCivil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.EstadoCivil _data in
                    (System.Collections.Generic.List<Tables.EstadoCivil>)this.m_EntityManager.list
                    (
                        typeof(Tables.EstadoCivil),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.EstadoCivil(), _data, level);

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
