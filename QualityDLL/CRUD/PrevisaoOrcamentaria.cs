using System;

namespace WS.CRUD
{
    public class PrevisaoOrcamentaria : WS.CRUD.Base
    {
        public PrevisaoOrcamentaria(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PrevisaoOrcamentaria input = (Data.PrevisaoOrcamentaria)parametros["Key"];
            Tables.PrevisaoOrcamentaria bd = new Tables.PrevisaoOrcamentaria();

            bd.idPrevisaoOrcamentaria.isNull = true;
            bd.dataReferencia.value = input.dataReferencia;
            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            bd.valor.value = input.valor;

            this.m_EntityManager.persist(bd);

            ((Data.PrevisaoOrcamentaria)parametros["Key"]).idPrevisaoOrcamentaria = (int)bd.idPrevisaoOrcamentaria.value;
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PrevisaoOrcamentaria input = (Data.PrevisaoOrcamentaria)parametros["Key"];
            Tables.PrevisaoOrcamentaria bd = (Tables.PrevisaoOrcamentaria)this.m_EntityManager.find
            (
                typeof(Tables.PrevisaoOrcamentaria),
                new Object[]
                {
                    input.idPrevisaoOrcamentaria
                }
            );

            bd.dataReferencia.value = input.dataReferencia;
            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            bd.valor.value = input.valor;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PrevisaoOrcamentaria bd = new Tables.PrevisaoOrcamentaria();

            bd.idPrevisaoOrcamentaria.value = ((Data.PrevisaoOrcamentaria)parametros["Key"]).idPrevisaoOrcamentaria;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PrevisaoOrcamentaria)bd).idPrevisaoOrcamentaria.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PrevisaoOrcamentaria)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PrevisaoOrcamentaria)input).idPrevisaoOrcamentaria = ((Tables.PrevisaoOrcamentaria)bd).idPrevisaoOrcamentaria.value;
                    ((Data.PrevisaoOrcamentaria)input).valor = ((Tables.PrevisaoOrcamentaria)bd).valor.value;
                    ((Data.PrevisaoOrcamentaria)input).dataReferencia = ((Tables.PrevisaoOrcamentaria)bd).dataReferencia.value;
                    ((Data.PrevisaoOrcamentaria)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.PrevisaoOrcamentaria)bd).naturezaOperacao,
                        level + 1
                    );

                    if (((Tables.PrevisaoOrcamentaria)bd).departamento.idDepartamento.value > 0)
                        ((Data.PrevisaoOrcamentaria)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.Departamento(),
                            ((Tables.PrevisaoOrcamentaria)bd).departamento,
                            level + 1
                        );
                    else
                        ((Data.PrevisaoOrcamentaria)input).departamento = null;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PrevisaoOrcamentaria result = (Data.PrevisaoOrcamentaria)parametros["Key"];

            try
            {
                result = (Data.PrevisaoOrcamentaria)this.preencher
                (
                    new Data.PrevisaoOrcamentaria(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PrevisaoOrcamentaria),
                        new Object[]
                        {
                            result.idPrevisaoOrcamentaria
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

            Data.PrevisaoOrcamentaria _input = (Data.PrevisaoOrcamentaria)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPrevisaoOrcamentaria > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PrevisaoOrcamentaria.idPrevisaoOrcamentaria = @idPrevisaoOrcamentaria");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPrevisaoOrcamentaria", _input.idPrevisaoOrcamentaria));
                    if (!sqlOrderBy.Contains("PrevisaoOrcamentaria.idPrevisaoOrcamentaria"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PrevisaoOrcamentaria.idPrevisaoOrcamentaria");
                    else { }
                }
                else { }

                if (_input.valor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PrevisaoOrcamentaria.valor = @valor");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valor", _input.valor));
                    if (!sqlOrderBy.Contains("PrevisaoOrcamentaria.valor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PrevisaoOrcamentaria.valor");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.dataReferencia))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PrevisaoOrcamentaria.dataReferencia = @dataReferencia");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("dataReferencia", _input.dataReferencia));
                    if (!sqlOrderBy.Contains("PrevisaoOrcamentaria.dataReferencia"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PrevisaoOrcamentaria.dataReferencia");
                    else { }
                }
                else { }

                if (_input.naturezaOperacao != null)
                {
                    if (_input.naturezaOperacao.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PrevisaoOrcamentaria.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacao.idNaturezaOperacao));
                        if (!sqlOrderBy.Contains("PrevisaoOrcamentaria.idNaturezaOperacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PrevisaoOrcamentaria.idNaturezaOperacao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PrevisaoOrcamentaria.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("PrevisaoOrcamentaria.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PrevisaoOrcamentaria.idDepartamento");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "PrevisaoOrcamentaria.* ") +
                    "from " +
                    (
                        "   PrevisaoOrcamentaria PrevisaoOrcamentaria " +
                        "       left join departamento departamento " +
                        "           on	departamento.idDepartamento = PrevisaoOrcamentaria.idDepartamento " +
                        "       inner join naturezaOperacao naturezaOperacao " +
                        "           on	naturezaOperacao.idNaturezaOperacao = PrevisaoOrcamentaria.idNaturezaOperacao "
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


        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PrevisaoOrcamentaria input = (Data.PrevisaoOrcamentaria)parametros["Key"];
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
                    typeof(Tables.PrevisaoOrcamentaria),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PrevisaoOrcamentaria _data in
                    (System.Collections.Generic.List<Tables.PrevisaoOrcamentaria>)this.m_EntityManager.list
                    (
                        typeof(Tables.PrevisaoOrcamentaria),
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
                    _base = (Data.Base)this.preencher(new Data.PrevisaoOrcamentaria(), _data, level);

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
