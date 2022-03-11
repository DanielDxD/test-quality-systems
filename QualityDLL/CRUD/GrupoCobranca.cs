using System;

namespace WS.CRUD
{
    public class GrupoCobranca : WS.CRUD.Base
    {
        public GrupoCobranca(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.GrupoCobranca input = (Data.GrupoCobranca)parametros["Key"];
            Tables.GrupoCobranca bd = new Tables.GrupoCobranca();

            bd.idGrupoCobranca.isNull = true;
            bd.descricao.value = input.descricao;

            if (input.parametroBoleto != null && input.parametroBoleto.idParametroBoleto > 0)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else
                bd.parametroBoleto.idParametroBoleto.isNull = true;

            bd.dataInicio.value = input.dataFim;
            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else
                bd.dataFim.isNull = true;
            bd.dataInicioAgrupamento.value = input.dataInicioAgrupamento;

            bd.diaCobranca.value = input.diaCobranca;
            bd.agruparDebitosTitulo.value = input.agruparDebitosTitulo;

            if (input.parametroAcrescimo != null && input.parametroAcrescimo.idParametroAcrescimo > 0)
                bd.parametroAcrescimo.idParametroAcrescimo.value = input.parametroAcrescimo.idParametroAcrescimo;
            else
                bd.parametroAcrescimo.idParametroAcrescimo.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.GrupoCobranca)parametros["Key"]).idGrupoCobranca = (int)bd.idGrupoCobranca.value;

            if (input.grupoCobrancaItems != null)
            {
                WS.CRUD.PdvCompraStatus grupoCobrancaItemsCRUD = new WS.CRUD.PdvCompraStatus(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.grupoCobrancaItems.Length; i++)
                {
                    if (input.grupoCobrancaItems[i].grupoCobranca == null)
                    {
                        input.grupoCobrancaItems[i].grupoCobranca = new Data.GrupoCobranca();
                        input.grupoCobrancaItems[i].grupoCobranca.idGrupoCobranca = bd.idGrupoCobranca.value;
                    }
                    _parameters.Add("Key", input.grupoCobrancaItems[i]);
                    grupoCobrancaItemsCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                grupoCobrancaItemsCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.GrupoCobranca input = (Data.GrupoCobranca)parametros["Key"];
            Tables.GrupoCobranca bd = (Tables.GrupoCobranca)this.m_EntityManager.find
            (
                typeof(Tables.GrupoCobranca),
                new Object[]
                {
                    input.idGrupoCobranca
                }
            );
            bd.descricao.value = input.descricao;

            if (input.parametroBoleto != null && input.parametroBoleto.idParametroBoleto > 0)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else
                bd.parametroBoleto.idParametroBoleto.isNull = true;

            bd.dataInicio.value = input.dataFim;
            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else
                bd.dataFim.isNull = true;
            bd.dataInicioAgrupamento.value = input.dataInicioAgrupamento;
            bd.diaCobranca.value = input.diaCobranca;
            bd.agruparDebitosTitulo.value = input.agruparDebitosTitulo;

            if (input.parametroAcrescimo != null && input.parametroAcrescimo.idParametroAcrescimo > 0)
                bd.parametroAcrescimo.idParametroAcrescimo.value = input.parametroAcrescimo.idParametroAcrescimo;
            else
                bd.parametroAcrescimo.idParametroAcrescimo.isNull = true;

            this.m_EntityManager.merge(bd);

            if (input.grupoCobrancaItems != null)
            {
                WS.CRUD.GrupoCobrancaItem grupoCobrancaItemsCRUD = new WS.CRUD.GrupoCobrancaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.grupoCobrancaItems.Length; i++)
                {
                    if (input.grupoCobrancaItems[i].grupoCobranca == null)
                        input.grupoCobrancaItems[i].grupoCobranca = new Data.GrupoCobranca { idGrupoCobranca = bd.idGrupoCobranca.value };
                    _parameters.Add("Key", input.grupoCobrancaItems[i]);
                    if (input.grupoCobrancaItems[i].operacao == ENum.eOperacao.NONE)
                        input.grupoCobrancaItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    grupoCobrancaItemsCRUD.atualizar(_parameters);
                    if (input.grupoCobrancaItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.grupoCobrancaItems[i] = (Data.GrupoCobrancaItem)grupoCobrancaItemsCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                grupoCobrancaItemsCRUD = null;
            }
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.GrupoCobranca bd = new Tables.GrupoCobranca();

            bd.idGrupoCobranca.value = ((Data.GrupoCobranca)parametros["Key"]).idGrupoCobranca;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.GrupoCobranca)bd).idGrupoCobranca.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.GrupoCobranca)input).operacao = ENum.eOperacao.NONE;

                    ((Data.GrupoCobranca)input).idGrupoCobranca = ((Tables.GrupoCobranca)bd).idGrupoCobranca.value;
                    ((Data.GrupoCobranca)input).descricao = ((Tables.GrupoCobranca)bd).descricao.value;
                    ((Data.GrupoCobranca)input).dataInicio = ((Tables.GrupoCobranca)bd).dataInicio.value;
                    ((Data.GrupoCobranca)input).dataFim = ((Tables.GrupoCobranca)bd).dataFim.value;
                    ((Data.GrupoCobranca)input).dataInicioAgrupamento = ((Tables.GrupoCobranca)bd).dataInicioAgrupamento.value;
                    ((Data.GrupoCobranca)input).diaCobranca = ((Tables.GrupoCobranca)bd).diaCobranca.value;
                    ((Data.GrupoCobranca)input).agruparDebitosTitulo = ((Tables.GrupoCobranca)bd).agruparDebitosTitulo.value;

                    ((Data.GrupoCobranca)input).parametroAcrescimo = (Data.ParametroAcrescimo)(new WS.CRUD.ParametroAcrescimo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroAcrescimo(),
                        ((Tables.GrupoCobranca)bd).parametroAcrescimo,
                        level + 1
                    );

                    ((Data.GrupoCobranca)input).parametroBoleto = (Data.ParametroBoleto)(new WS.CRUD.ParametroBoleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroBoleto(),
                        ((Tables.GrupoCobranca)bd).parametroBoleto,
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
            Data.GrupoCobranca result = (Data.GrupoCobranca)parametros["Key"];

            try
            {
                result = (Data.GrupoCobranca)this.preencher
                (
                    new Data.GrupoCobranca(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.GrupoCobranca),
                        new Object[]
                        {
                            result.idGrupoCobranca
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
            Data.GrupoCobranca input = (Data.GrupoCobranca)parametros["Key"];
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
                    typeof(Tables.GrupoCobranca),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.GrupoCobranca _data in
                    (System.Collections.Generic.List<Tables.GrupoCobranca>)this.m_EntityManager.list
                    (
                        typeof(Tables.GrupoCobranca),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.GrupoCobranca(), _data, level);

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

            Data.GrupoCobranca _input = (Data.GrupoCobranca)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idGrupoCobranca > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobranca.idGrupoCobranca = @idGrupoCobranca");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idGrupoCobranca", _input.idGrupoCobranca));
                    if (!sqlOrderBy.Contains("GrupoCobranca.idGrupoCobranca"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobranca.idGrupoCobranca");
                    else { }
                }
                else { }

                if (_input.parametroBoleto != null)
                {
                    if (_input.parametroBoleto.idParametroBoleto > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobranca.idParametroBoleto = @idParametroBoleto");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroBoleto", _input.parametroBoleto.idParametroBoleto));
                        if (!sqlOrderBy.Contains("GrupoCobranca.idParametroBoleto"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobranca.idParametroBoleto");
                        else { }
                    }

                    if (_input.parametroBoleto.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "parametroBoleto.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.parametroBoleto.idEmpresa));
                        if (!sqlOrderBy.Contains("parametroBoleto.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "parametroBoleto.idEmpresa");
                        else { }
                    }
                }
                else { }

                if (_input.parametroAcrescimo != null)
                {
                    if (_input.parametroAcrescimo.idParametroAcrescimo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobranca.idParametroAcrescimo = @idParametroAcrescimo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroAcrescimo", _input.parametroAcrescimo.idParametroAcrescimo));
                        if (!sqlOrderBy.Contains("GrupoCobranca.idParametroAcrescimo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobranca.idParametroAcrescimo");
                        else { }
                    }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "GrupoCobranca.* ") +
                    "from " +
                    (
                        "   GrupoCobranca GrupoCobranca " +
                        "INNER JOIN parametroBoleto ON parametroBoleto.idParametroBoleto = GrupoCobranca.idParametroBoleto \n" +
                        "LEFT JOIN parametroAcrescimo ON parametroAcrescimo.idParametroAcrescimo = GrupoCobranca.idParametroAcrescimo \n"
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
