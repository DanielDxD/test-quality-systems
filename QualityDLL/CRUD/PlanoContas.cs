using System;

namespace WS.CRUD
{
    public class PlanoContas : WS.CRUD.Base
    {
        public PlanoContas(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PlanoContas input = (Data.PlanoContas)parametros["Key"];
            Tables.PlanoContas bd = new Tables.PlanoContas();

            bd.idPlanoContas.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            bd.analiticoSintetico.value = input.analiticoSintetico;
            bd.codigoContabil.value = input.codigoContabil;
            bd.descricao.value = input.descricao;
            if (String.IsNullOrEmpty(input.codigoContabilReduzido))
                bd.codigoContabilReduzido.isNull = true;
            else
                bd.codigoContabilReduzido.value = input.codigoContabilReduzido;

            this.m_EntityManager.persist(bd);

            ((Data.PlanoContas)parametros["Key"]).idPlanoContas = (int)bd.idPlanoContas.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContas input = (Data.PlanoContas)parametros["Key"];
            Tables.PlanoContas bd = (Tables.PlanoContas)this.m_EntityManager.find
            (
                typeof(Tables.PlanoContas),
                new Object[]
                {
                    input.idPlanoContas
                }
            );

            bd.idEmpresa.value = input.idEmpresa;
            bd.analiticoSintetico.value = input.analiticoSintetico;
            bd.codigoContabil.value = input.codigoContabil;
            bd.descricao.value = input.descricao;
            if (String.IsNullOrEmpty(input.codigoContabilReduzido))
                bd.codigoContabilReduzido.isNull = true;
            else
                bd.codigoContabilReduzido.value = input.codigoContabilReduzido;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PlanoContas bd = new Tables.PlanoContas();

            bd.idPlanoContas.value = ((Data.PlanoContas)parametros["Key"]).idPlanoContas;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PlanoContas)bd).idPlanoContas.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PlanoContas)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PlanoContas)input).idPlanoContas = ((Tables.PlanoContas)bd).idPlanoContas.value;
                    ((Data.PlanoContas)input).analiticoSintetico = ((Tables.PlanoContas)bd).analiticoSintetico.value;
                    ((Data.PlanoContas)input).codigoContabil = ((Tables.PlanoContas)bd).codigoContabil.value;
                    ((Data.PlanoContas)input).descricao = ((Tables.PlanoContas)bd).descricao.value;
                    ((Data.PlanoContas)input).idEmpresa = ((Tables.PlanoContas)bd).idEmpresa.value;
                    if (!((Tables.PlanoContas)bd).codigoContabilReduzido.isNull)
                        ((Data.PlanoContas)input).codigoContabilReduzido = ((Tables.PlanoContas)bd).codigoContabilReduzido.value;
                    else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContas result = (Data.PlanoContas)parametros["Key"];

            try
            {
                result = (Data.PlanoContas)this.preencher
                (
                    new Data.PlanoContas(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PlanoContas),
                        new Object[]
                        {
                            result.idPlanoContas
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

            Data.PlanoContas _input = (Data.PlanoContas)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "planoContas.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("planoContas.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idPlanoContas > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "planoContas.idPlanoContas = @idPlanoContas");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPlanoContas", _input.idPlanoContas));
                    if (!sqlOrderBy.Contains("planoContas.idPlanoContas"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.idPlanoContas");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   planoContas.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("planoContas.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoContabil))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   planoContas.codigoContabil = @codigoContabil");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoContabil", _input.codigoContabil));
                    if (!sqlOrderBy.Contains("planoContas.codigoContabil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.codigoContabil");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoContabilReduzido))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   planoContas.codigoContabilReduzido = @codigoContabilReduzido");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoContabilReduzido", _input.codigoContabilReduzido));
                    if (!sqlOrderBy.Contains("planoContas.codigoContabilReduzido"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.codigoContabilReduzido");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.analiticoSintetico))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   planoContas.analiticoSintetico = @analiticoSintetico");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("analiticoSintetico", _input.analiticoSintetico));
                    if (!sqlOrderBy.Contains("planoContas.analiticoSintetico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.analiticoSintetico");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   planoContas.* " +
                    "from " +
                    "   planoContas " +
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
            Data.PlanoContas input = (Data.PlanoContas)parametros["Key"];
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
                    typeof(Tables.PlanoContas),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PlanoContas _data in
                    (System.Collections.Generic.List<Tables.PlanoContas>)this.m_EntityManager.list
                    (
                        typeof(Tables.PlanoContas),
                        _select.Replace("order by idPlanoContas", "order by codigoContabil"),
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.PlanoContas(), _data, level);

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
