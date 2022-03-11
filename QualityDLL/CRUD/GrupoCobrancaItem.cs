using System;

namespace WS.CRUD
{
    public class GrupoCobrancaItem : WS.CRUD.Base
    {
        public GrupoCobrancaItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.GrupoCobrancaItem input = (Data.GrupoCobrancaItem)parametros["Key"];
            Tables.GrupoCobrancaItem bd = new Tables.GrupoCobrancaItem();

            bd.idGrupoCobrancaItem.isNull = true;
            bd.grupoCobranca.idGrupoCobranca.value = input.grupoCobranca.idGrupoCobranca;
            bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;

            if (input.parametroBoletoDesconto != null && input.parametroBoletoDesconto.idParametroBoletoDesconto > 0)
                bd.parametroBoletoDesconto.idParametroBoletoDesconto.value = input.parametroBoletoDesconto.idParametroBoletoDesconto;
            else
                bd.parametroBoletoDesconto.idParametroBoletoDesconto.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.GrupoCobrancaItem)parametros["Key"]).idGrupoCobrancaItem = (int)bd.idGrupoCobrancaItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.GrupoCobrancaItem input = (Data.GrupoCobrancaItem)parametros["Key"];
            Tables.GrupoCobrancaItem bd = (Tables.GrupoCobrancaItem)this.m_EntityManager.find
            (
                typeof(Tables.GrupoCobrancaItem),
                new Object[]
                {
                    input.idGrupoCobrancaItem
                }
            );

            bd.grupoCobranca.idGrupoCobranca.value = input.grupoCobranca.idGrupoCobranca;
            bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;

            if (input.parametroBoletoDesconto != null && input.parametroBoletoDesconto.idParametroBoletoDesconto > 0)
                bd.parametroBoletoDesconto.idParametroBoletoDesconto.value = input.parametroBoletoDesconto.idParametroBoletoDesconto;
            else
                bd.parametroBoletoDesconto.idParametroBoletoDesconto.isNull = true;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.GrupoCobrancaItem bd = new Tables.GrupoCobrancaItem();

            bd.idGrupoCobrancaItem.value = ((Data.GrupoCobrancaItem)parametros["Key"]).idGrupoCobrancaItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.GrupoCobrancaItem)bd).idGrupoCobrancaItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.GrupoCobrancaItem)input).operacao = ENum.eOperacao.NONE;
                    ((Data.GrupoCobrancaItem)input).idGrupoCobrancaItem = ((Tables.GrupoCobrancaItem)bd).idGrupoCobrancaItem.value;

                    ((Data.GrupoCobrancaItem)input).grupoCobranca = (Data.GrupoCobranca)(new WS.CRUD.GrupoCobranca(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.GrupoCobranca(),
                        ((Tables.GrupoCobrancaItem)bd).grupoCobranca,
                        level + 1
                    );

                    ((Data.GrupoCobrancaItem)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.GrupoCobrancaItem)bd).naturezaOperacao,
                        level + 1
                    );

                    ((Data.GrupoCobrancaItem)input).parametroBoletoDesconto = (Data.ParametroBoletoDesconto)(new WS.CRUD.ParametroBoletoDesconto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroBoletoDesconto(),
                        ((Tables.GrupoCobrancaItem)bd).parametroBoletoDesconto,
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
            Data.GrupoCobrancaItem result = (Data.GrupoCobrancaItem)parametros["Key"];

            try
            {
                result = (Data.GrupoCobrancaItem)this.preencher
                (
                    new Data.GrupoCobrancaItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.GrupoCobrancaItem),
                        new Object[]
                        {
                            result.idGrupoCobrancaItem
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
            Data.GrupoCobrancaItem input = (Data.GrupoCobrancaItem)parametros["Key"];
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
                    typeof(Tables.GrupoCobrancaItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.GrupoCobrancaItem _data in
                    (System.Collections.Generic.List<Tables.GrupoCobrancaItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.GrupoCobrancaItem),
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
                    _base = (Data.Base)this.preencher(new Data.GrupoCobrancaItem(), _data, level);

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

            Data.GrupoCobrancaItem _input = (Data.GrupoCobrancaItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idGrupoCobrancaItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobrancaItem.idGrupoCobrancaItem = @idGrupoCobrancaItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idGrupoCobrancaItem", _input.idGrupoCobrancaItem));
                    if (!sqlOrderBy.Contains("GrupoCobrancaItem.idGrupoCobrancaItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobrancaItem.idGrupoCobrancaItem");
                    else { }
                }
                else { }

                if (_input.grupoCobranca != null)
                {
                    if (_input.grupoCobranca.idGrupoCobranca > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobrancaItem.idGrupoCobranca = @idGrupoCobranca");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idGrupoCobranca", _input.grupoCobranca.idGrupoCobranca));
                        if (!sqlOrderBy.Contains("GrupoCobrancaItem.idGrupoCobranca"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobrancaItem.idGrupoCobranca");
                        else { }
                    }
                }
                else { }

                if (_input.parametroBoletoDesconto != null)
                {
                    if (_input.parametroBoletoDesconto.idParametroBoletoDesconto > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobrancaItem.idParametroBoletoDesconto = @idParametroBoletoDesconto");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroBoletoDesconto", _input.parametroBoletoDesconto.idParametroBoletoDesconto));
                        if (!sqlOrderBy.Contains("GrupoCobrancaItem.idParametroBoletoDesconto"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobrancaItem.idParametroAcrescimo");
                        else { }
                    }
                }
                else { }

                if (_input.naturezaOperacao != null)
                {
                    if (_input.naturezaOperacao.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "GrupoCobrancaItem.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacao.idNaturezaOperacao));
                        if (!sqlOrderBy.Contains("GrupoCobrancaItem.idNaturezaOperacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "GrupoCobrancaItem.idParametroAcrescimo");
                        else { }
                    }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "GrupoCobrancaItem.* ") +
                    "from " +
                    (
                        "   GrupoCobrancaItem GrupoCobrancaItem " +
                        "INNER JOIN naturezaOperacao ON naturezaOperacao.idNaturezaOperacao = GrupoCobrancaItem.idNaturezaOperacao\n" +
                        "LEFT JOIN parametroBoletoDesconto ON parametroBoletoDesconto.idParametroBoletoDesconto = GrupoCobrancaItem.idParametroBoletoDesconto\n" +
                        "LEFT JOIN parametroAcrescimo ON parametroAcrescimo.idParametroAcrescimo = GrupoCobrancaItem.idParametroAcrescimo\n"
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
