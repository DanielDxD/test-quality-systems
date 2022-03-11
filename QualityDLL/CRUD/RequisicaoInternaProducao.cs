using System;

namespace WS.CRUD
{
    public class RequisicaoInternaProducao : WS.CRUD.Base
    {
        public RequisicaoInternaProducao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaProducao input = (Data.RequisicaoInternaProducao)parametros["Key"];
            Tables.RequisicaoInternaProducao bd = new Tables.RequisicaoInternaProducao();

            bd.idRequisicaoInternaProducao.isNull = true;
            if (input.requisicaoInternaEntrada != null)
                bd.requisicaoInternaEntrada.idRequisicaoInterna.value = input.requisicaoInternaEntrada.idRequisicaoInterna;
            else { }
            if (input.requisicaoInternaSaida != null)
                bd.requisicaoInternaSaida.idRequisicaoInterna.value = input.requisicaoInternaSaida.idRequisicaoInterna;
            else { }
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoInternaProducao)parametros["Key"]).idRequisicaoInternaProducao = (int)bd.idRequisicaoInternaProducao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaProducao input = (Data.RequisicaoInternaProducao)parametros["Key"];
            Tables.RequisicaoInternaProducao bd = (Tables.RequisicaoInternaProducao)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoInternaProducao),
                new Object[]
                {
                    input.idRequisicaoInternaProducao
                }
            );

            if (input.requisicaoInternaEntrada != null)
                bd.requisicaoInternaEntrada.idRequisicaoInterna.value = input.requisicaoInternaEntrada.idRequisicaoInterna;
            else { }
            if (input.requisicaoInternaSaida != null)
                bd.requisicaoInternaSaida.idRequisicaoInterna.value = input.requisicaoInternaSaida.idRequisicaoInterna;
            else { }
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RequisicaoInternaProducao bd = new Tables.RequisicaoInternaProducao();

            bd.idRequisicaoInternaProducao.value = ((Data.RequisicaoInternaProducao)parametros["Key"]).idRequisicaoInternaProducao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoInternaProducao)bd).idRequisicaoInternaProducao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoInternaProducao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoInternaProducao)input).idRequisicaoInternaProducao = ((Tables.RequisicaoInternaProducao)bd).idRequisicaoInternaProducao.value;
                    ((Data.RequisicaoInternaProducao)input).descricao = ((Tables.RequisicaoInternaProducao)bd).descricao.value;
                    ((Data.RequisicaoInternaProducao)input).requisicaoInternaEntrada = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInterna(),
                        ((Tables.RequisicaoInternaProducao)bd).requisicaoInternaEntrada,
                        level + 1
                    );
                    ((Data.RequisicaoInternaProducao)input).requisicaoInternaSaida = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInterna(),
                        ((Tables.RequisicaoInternaProducao)bd).requisicaoInternaSaida,
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
            Data.RequisicaoInternaProducao result = (Data.RequisicaoInternaProducao)parametros["Key"];

            try
            {
                result = (Data.RequisicaoInternaProducao)this.preencher
                (
                    new Data.RequisicaoInternaProducao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoInternaProducao),
                        new Object[]
                        {
                            result.idRequisicaoInternaProducao
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
            Data.RequisicaoInternaProducao input = (Data.RequisicaoInternaProducao)parametros["Key"];
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
                    typeof(Tables.RequisicaoInternaProducao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoInternaProducao _data in
                    (System.Collections.Generic.List<Tables.RequisicaoInternaProducao>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoInternaProducao),
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
                    _base = (Data.Base)this.preencher(new Data.RequisicaoInternaProducao(), _data, level);

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

            Data.RequisicaoInternaProducao _input = (Data.RequisicaoInternaProducao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idRequisicaoInternaProducao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInternaProducao.idRequisicaoInternaProducao = @idRequisicaoInternaProducao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInternaProducao", _input.idRequisicaoInternaProducao));
                    if (!sqlOrderBy.Contains("requisicaoInternaProducao.idRequisicaoInternaProducao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProducao.idRequisicaoInternaProducao");
                    else { }
                }
                else { }

                

                if (_input.requisicaoInternaEntrada != null)
                {
                    if (_input.requisicaoInternaEntrada.idRequisicaoInterna > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInternaProducao.idRequisicaoInternaEntrada = @idRequisicaoInternaEntrada");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInternaEntrada", _input.requisicaoInternaEntrada.idRequisicaoInterna));
                        if (!sqlOrderBy.Contains("requisicaoInternaProducao.idRequisicaoInternaEntrada"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProducao.idRequisicaoInternaEntrada");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.requisicaoInternaSaida != null)
                {
                    if (_input.requisicaoInternaSaida.idRequisicaoInterna > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInternaProducao.idRequisicaoInternaSaida = @idRequisicaoInternaSaida");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInternaSaida", _input.requisicaoInternaEntrada.idRequisicaoInterna));
                        if (!sqlOrderBy.Contains("requisicaoInternaProducao.idRequisicaoInternaSaida"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProducao.idRequisicaoInternaSaida");
                        else { }
                    }
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "requisicaoInternaProducao.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("requisicaoInternaProducao.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProducao.descricao");
                    else { }
                }
                else { }

                //
                //Forçando o idRequisicação interna porque o Rows Fetch está se perdendo com o order by com valores repetidos
                //
                if (!sqlOrderBy.Contains("requisicaoInternaProducao.idRequisicaoInternaProducao"))
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProducao.idRequisicaoInternaProducao");
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "requisicaoInternaProducao.* ") +
                    "from \n" +
                    (
                        @"
                        requisicaoInternaProducao requisicaoInternaProducao
	                        inner join requisicaoInterna requisicaoInternaEntrada
		                        on	requisicaoInternaEntrada.idRequisicaoInterna = requisicaoInternaProducao.idRequisicaoInternaEntrada
	                        inner join requisicaoInterna requisicaoInternaSaida
		                        on	requisicaoInternaSaida.idRequisicaoInterna = requisicaoInternaProducao.idRequisicaoInternaSaida
                        "
                    ) +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
