using System;

namespace WS.CRUD
{
    public class Cidade : WS.CRUD.Base
    {
        public Cidade(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Cidade input = (Data.Cidade)parametros["Key"];
            Tables.Cidade bd = new Tables.Cidade();

            bd.idCidade.value = System.Convert.ToInt32(this.m_EntityManager.executeScalar("select cast((IsNull(max(idCidade), 0) + 1) as bigint) from cidade", null));
            bd.descricao.value = input.descricao;
            if (input.estado != null)
                bd.estado.idEstado.value = input.estado.idEstado;
            else { }
            bd.codigoIBGE.value = input.codigoIBGE;

            this.m_EntityManager.persist(bd);

            ((Data.Cidade)parametros["Key"]).idCidade = (int)bd.idCidade.value;


            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Cidade input = (Data.Cidade)parametros["Key"];
            Tables.Cidade bd = (Tables.Cidade)this.m_EntityManager.find
            (
                typeof(Tables.Cidade),
                new Object[]
                {
                    input.idCidade
                }
            );

            bd.descricao.value = input.descricao;
            if (input.estado != null)
                bd.estado.idEstado.value = input.estado.idEstado;
            else { }
            bd.codigoIBGE.value = input.codigoIBGE;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Cidade bd = new Tables.Cidade();

            bd.idCidade.value = ((Data.Cidade)parametros["Key"]).idCidade;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Cidade)bd).idCidade.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Cidade)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Cidade)input).idCidade = ((Tables.Cidade)bd).idCidade.value;
                    ((Data.Cidade)input).descricao = ((Tables.Cidade)bd).descricao.value;
                    ((Data.Cidade)input).estado = (Data.Estado)(new WS.CRUD.Estado(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Estado(),
                        ((Tables.Cidade)bd).estado,
                        level + 1
                    );
                    ((Data.Cidade)input).codigoIBGE = ((Tables.Cidade)bd).codigoIBGE.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Cidade result = (Data.Cidade)parametros["Key"];

            try
            {
                result = (Data.Cidade)this.preencher
                (
                    new Data.Cidade(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Cidade),
                        new Object[]
                        {
                            result.idCidade
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

            Data.Cidade _input = (Data.Cidade)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.descricao");

                if (_input.idCidade > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cidade.idCidade = @idCidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCidade", _input.idCidade));
                    if (!sqlOrderBy.Contains("cidade.idCidade"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.idCidade");
                    else { }
                }
                else { }

                if ((_input.descricao != null) && (_input.descricao.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cidade.descricao COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("cidade.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.descricao");
                    else { };
                }
                else { }

                if (_input.codigoIBGE > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cidade.codigoIBGE = @codigoIBGE");
                    fieldKeys.Add(new EJB.TableBase.TFieldBigInteger("codigoIBGE", _input.codigoIBGE));
                    if (!sqlOrderBy.Contains("cidade.codigoIBGE"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.codigoIBGE");
                    else { };
                }
                else { }

                if (_input.estado != null)
                {
                    if (_input.estado.idEstado > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "estado.idEstado = @idEstado");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEstado", _input.estado.idEstado));
                        if (!sqlOrderBy.Contains("estado.idEstado"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estado.idEstado");
                        else { }
                    }
                    else { }

                    if ((_input.estado.descricao != null) && (_input.estado.descricao.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "estado.descricao COLLATE Latin1_General_CI_AI like @descricaoEstdo COLLATE Latin1_General_CI_AI");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoEstado", _input.estado.descricao + '%'));
                        if (!sqlOrderBy.Contains("estado.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estado.descricao");
                        else { }
                    }
                    else { }

                    if ((_input.estado.uf != null) && (_input.estado.uf.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "estado.uf COLLATE Latin1_General_CI_AI like @uf COLLATE Latin1_General_CI_AI");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("uf", _input.estado.uf + '%'));
                        if (!sqlOrderBy.Contains("estado.uf"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estado.uf");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "cidade.idCidade, LTRIM(RTRIM(cidade.descricao)) descricao, cidade.idEstado, cidade.codigoIBGE ") +
                    "from " +
                    (
                    "cidade cidade " +
                        "inner join estado estado " +
                            "on estado.idEstado = cidade.idEstado "
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
            Data.Cidade input = (Data.Cidade)parametros["Key"];
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
                    typeof(Tables.Cidade),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Cidade _data in
                    (System.Collections.Generic.List<Tables.Cidade>)this.m_EntityManager.list
                    (
                        typeof(Tables.Cidade),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Cidade(), _data, level);

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
