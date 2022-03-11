using System;

namespace WS.CRUD
{
    public class ParametroAcrescimo : WS.CRUD.Base
    {
        public ParametroAcrescimo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ParametroAcrescimo input = (Data.ParametroAcrescimo)parametros["Key"];
            Tables.ParametroAcrescimo bd = new Tables.ParametroAcrescimo();

            bd.idParametroAcrescimo.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipoJuro.value = input.tipoJuro;
            bd.tipoMulta.value = input.tipoMulta;
            bd.tipoCarenciaJuros.value = input.tipoCarenciaJuros;
            bd.tipoCarenciaMulta.value = input.tipoCarenciaMulta;
            bd.diasCarenciaJuros.value = input.diasCarenciaJuros;
            bd.diasCarenciaMulta.value = input.diasCarenciaMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorMulta.value = input.valorMulta;

            if (!String.IsNullOrEmpty(input.jurosMesesAnteriores))
                bd.jurosMesesAnteriores.value = input.jurosMesesAnteriores.ToLower() == "s";
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.ParametroAcrescimo)parametros["Key"]).idParametroAcrescimo = (int)bd.idParametroAcrescimo.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ParametroAcrescimo input = (Data.ParametroAcrescimo)parametros["Key"];
            Tables.ParametroAcrescimo bd = (Tables.ParametroAcrescimo)this.m_EntityManager.find
            (
                typeof(Tables.ParametroAcrescimo),
                new Object[]
                {
                    input.idParametroAcrescimo
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipoJuro.value = input.tipoJuro;
            bd.tipoMulta.value = input.tipoMulta;
            bd.tipoCarenciaJuros.value = input.tipoCarenciaJuros;
            bd.tipoCarenciaMulta.value = input.tipoCarenciaMulta;
            bd.diasCarenciaJuros.value = input.diasCarenciaJuros;
            bd.diasCarenciaMulta.value = input.diasCarenciaMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorMulta.value = input.valorMulta;
            bd.jurosMesesAnteriores.value = input.jurosMesesAnteriores == "s";

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ParametroAcrescimo bd = new Tables.ParametroAcrescimo();

            bd.idParametroAcrescimo.value = ((Data.ParametroAcrescimo)parametros["Key"]).idParametroAcrescimo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ParametroAcrescimo)bd).idParametroAcrescimo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ParametroAcrescimo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ParametroAcrescimo)input).idParametroAcrescimo = ((Tables.ParametroAcrescimo)bd).idParametroAcrescimo.value;
                    ((Data.ParametroAcrescimo)input).descricao = ((Tables.ParametroAcrescimo)bd).descricao.value;
                    ((Data.ParametroAcrescimo)input).diasCarenciaJuros = ((Tables.ParametroAcrescimo)bd).diasCarenciaJuros.value;
                    ((Data.ParametroAcrescimo)input).diasCarenciaMulta = ((Tables.ParametroAcrescimo)bd).diasCarenciaMulta.value;
                    ((Data.ParametroAcrescimo)input).tipoCarenciaJuros = ((Tables.ParametroAcrescimo)bd).tipoCarenciaJuros.value;
                    ((Data.ParametroAcrescimo)input).tipoCarenciaMulta = ((Tables.ParametroAcrescimo)bd).tipoCarenciaMulta.value;
                    ((Data.ParametroAcrescimo)input).tipoJuro = ((Tables.ParametroAcrescimo)bd).tipoJuro.value;
                    ((Data.ParametroAcrescimo)input).tipoMulta = ((Tables.ParametroAcrescimo)bd).tipoMulta.value;
                    ((Data.ParametroAcrescimo)input).valorMulta = ((Tables.ParametroAcrescimo)bd).valorMulta.value;
                    ((Data.ParametroAcrescimo)input).valorJuros = ((Tables.ParametroAcrescimo)bd).valorJuros.value;
                    ((Data.ParametroAcrescimo)input).jurosMesesAnteriores = ((Tables.ParametroAcrescimo)bd).jurosMesesAnteriores.value ? "s" : "n";
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ParametroAcrescimo result = (Data.ParametroAcrescimo)parametros["Key"];

            try
            {
                result = (Data.ParametroAcrescimo)this.preencher
                (
                    new Data.ParametroAcrescimo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ParametroAcrescimo),
                        new Object[]
                        {
                            result.idParametroAcrescimo
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
            Data.ParametroAcrescimo input = (Data.ParametroAcrescimo)parametros["Key"];
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
                    typeof(Tables.ParametroAcrescimo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ParametroAcrescimo _data in
                    (System.Collections.Generic.List<Tables.ParametroAcrescimo>)this.m_EntityManager.list
                    (
                        typeof(Tables.ParametroAcrescimo),
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
                    _base = (Data.Base)this.preencher(new Data.ParametroAcrescimo(), _data, level);

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

            Data.ParametroAcrescimo _input = (Data.ParametroAcrescimo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idParametroAcrescimo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.idParametroAcrescimo = @idParametroAcrescimo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroAcrescimo", _input.idParametroAcrescimo));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.idParametroAcrescimo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.idParametroAcrescimo");
                    else { }
                }
                else { }

                if (_input.diasCarenciaMulta > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.diasCarenciaMulta = @diasCarenciaMulta");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("diasCarenciaMulta", _input.diasCarenciaMulta));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.diasCarenciaMulta"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.diasCarenciaMulta");
                    else { }
                }
                else { }

                if (_input.diasCarenciaJuros > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.diasCarenciaJuros = @diasCarenciaJuros");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("diasCarenciaJuros", _input.diasCarenciaJuros));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.diasCarenciaJuros"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.diasCarenciaJuros");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoCarenciaJuros))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.tipoCarenciaJuros = @tipoCarenciaJuros");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoCarenciaJuros", _input.tipoCarenciaJuros));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.tipoCarenciaJuros"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.tipoCarenciaJuros");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.jurosMesesAnteriores))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.jurosMesesAnteriores = @jurosMesesAnteriores");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("jurosMesesAnteriores", _input.jurosMesesAnteriores.ToLower() == "s"));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.jurosMesesAnteriores"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.jurosMesesAnteriores");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoCarenciaMulta))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.tipoCarenciaMulta = @tipoCarenciaMulta");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoCarenciaMulta", _input.tipoCarenciaMulta));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.tipoCarenciaMulta"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.tipoCarenciaMulta");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoJuro))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.tipoJuro = @tipoJuro");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoJuro", _input.tipoJuro));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.tipoJuro"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.tipoJuro");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoMulta))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroAcrescimo.tipoMulta = @tipoMulta");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoMulta", _input.tipoMulta));
                    if (!sqlOrderBy.Contains("ParametroAcrescimo.tipoMulta"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroAcrescimo.tipoMulta");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ParametroAcrescimo.* ") +
                    "from " +
                    (
                        "   ParametroAcrescimo ParametroAcrescimo "
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
