using System;

namespace WS.CRUD
{
    public class Feriado : WS.CRUD.Base
    {
        public Feriado(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Feriado input = (Data.Feriado)parametros["Key"];
            Tables.Feriado bd = new Tables.Feriado();

            bd.idFeriado.isNull = true;
            bd.descricao.value = input.descricao;
            bd.dia.value = input.dia;
            bd.mes.value = input.mes;
            bd.ano.value = input.ano;

            this.m_EntityManager.persist(bd);

            ((Data.Feriado)parametros["Key"]).idFeriado = (int)bd.idFeriado.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Feriado input = (Data.Feriado)parametros["Key"];
            Tables.Feriado bd = (Tables.Feriado)this.m_EntityManager.find
            (
                typeof(Tables.Feriado),
                new Object[]
                {
                    input.idFeriado
                }
            );

            bd.descricao.value = input.descricao;
            bd.dia.value = input.dia;
            bd.mes.value = input.mes;
            bd.ano.value = input.ano;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Feriado bd = new Tables.Feriado();

            bd.idFeriado.value = ((Data.Feriado)parametros["Key"]).idFeriado;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Feriado)bd).idFeriado.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Feriado)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Feriado)input).idFeriado = ((Tables.Feriado)bd).idFeriado.value;
                    ((Data.Feriado)input).descricao = ((Tables.Feriado)bd).descricao.value;
                    ((Data.Feriado)input).dia = ((Tables.Feriado)bd).dia.value;
                    ((Data.Feriado)input).mes = ((Tables.Feriado)bd).mes.value;
                    ((Data.Feriado)input).ano = ((Tables.Feriado)bd).ano.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Feriado result = (Data.Feriado)parametros["Key"];

            try
            {
                result = (Data.Feriado)this.preencher
                (
                    new Data.Feriado(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Feriado),
                        new Object[]
                        {
                            result.idFeriado
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
            Data.Feriado input = (Data.Feriado)parametros["Key"];
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
                    typeof(Tables.Feriado),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Feriado _data in
                    (System.Collections.Generic.List<Tables.Feriado>)this.m_EntityManager.list
                    (
                        typeof(Tables.Feriado),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.Feriado(), _data, level);

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

            Data.Feriado _input = (Data.Feriado)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idFeriado > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Feriado.idFeriado = @idFeriado");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFeriado", _input.idFeriado));
                    if (!sqlOrderBy.Contains("Feriado.idFeriado"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Feriado.idFeriado");
                    else { }
                }
                else { }

                if (_input.dia > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Feriado.dia = @dia");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("dia", _input.dia));
                    if (!sqlOrderBy.Contains("Feriado.dia"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Feriado.dia");
                    else { }
                }
                else { }

                if (_input.mes > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Feriado.mes = @mes");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("mes", _input.mes));
                    if (!sqlOrderBy.Contains("Feriado.mes"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Feriado.mes");
                    else { }
                }
                else { }

                if (_input.ano > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Feriado.ano = @ano");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("ano", _input.ano));
                    if (!sqlOrderBy.Contains("Feriado.ano"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Feriado.ano");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Feriado.* ") +
                    "from " +
                    (
                        "   Feriado Feriado "
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
