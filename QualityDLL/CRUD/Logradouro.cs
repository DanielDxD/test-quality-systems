using System;

namespace WS.CRUD
{
    public class Logradouro : WS.CRUD.Base
    {
        public Logradouro(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Logradouro input = (Data.Logradouro)parametros["Key"];
            Tables.Logradouro bd = new Tables.Logradouro();

            bd.idLogradouro.isNull = true;
            bd.descricao.value = input.descricao;
            if (input.tipoLogradouro != null)
                bd.tipoLogradouro.idTipoLogradouro.value = input.tipoLogradouro.idTipoLogradouro;
            else { }
            if (input.cidade != null)
                bd.cidade.idCidade.value = input.cidade.idCidade;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.Logradouro)parametros["Key"]).idLogradouro = (int)bd.idLogradouro.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Logradouro input = (Data.Logradouro)parametros["Key"];
            Tables.Logradouro bd = (Tables.Logradouro)this.m_EntityManager.find
            (
                typeof(Tables.Logradouro),
                new Object[]
                {
                    input.idLogradouro
                }
            );

            bd.descricao.value = input.descricao;
            if (input.tipoLogradouro != null)
                bd.tipoLogradouro.idTipoLogradouro.value = input.tipoLogradouro.idTipoLogradouro;
            else { }
            if (input.cidade != null)
                bd.cidade.idCidade.value = input.cidade.idCidade;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Logradouro bd = new Tables.Logradouro();

            bd.idLogradouro.value = ((Data.Logradouro)parametros["Key"]).idLogradouro;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Logradouro)bd).idLogradouro.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Logradouro)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Logradouro)input).idLogradouro = ((Tables.Logradouro)bd).idLogradouro.value;
                    ((Data.Logradouro)input).descricao = ((Tables.Logradouro)bd).descricao.value;
                    ((Data.Logradouro)input).tipoLogradouro = (Data.TipoLogradouro)(new WS.CRUD.TipoLogradouro(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoLogradouro(),
                        ((Tables.Logradouro)bd).tipoLogradouro,
                        level + 1
                    );
                    ((Data.Logradouro)input).cidade = (Data.Cidade)(new WS.CRUD.Cidade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Cidade(),
                        ((Tables.Logradouro)bd).cidade,
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
            Data.Logradouro result = (Data.Logradouro)parametros["Key"];

            try
            {
                result = (Data.Logradouro)this.preencher
                (
                    new Data.Logradouro(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Logradouro),
                        new Object[]
                        {
                            result.idLogradouro
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

            Data.Logradouro _input = (Data.Logradouro)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idLogradouro > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "logradouro.idLogradouro = @idLogradouro");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idLogradouro", _input.idLogradouro));
                    if (!sqlOrderBy.Contains("logradouro.idLogradouro"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "logradouro.idLogradouro");
                    else { }
                }
                else { }

                if (_input.cidade.idCidade > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   cidade.idCidade = @idCidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCidade", _input.cidade.idCidade));
                    if (!sqlOrderBy.Contains("cidade.idCidade"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.idCidade");
                    else { }
                }
                else { }

                if ((_input.cidade.descricao != null) && (_input.cidade.descricao.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   cidade.descricao like @descricaoCidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoCidade", "%" + _input.cidade.descricao + "%"));
                    if (!sqlOrderBy.Contains("cidade.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   (CONCAT(tipoLogradouro.tipo, ' ', logradouro.descricao) COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI OR CONCAT(tipoLogradouro.descricao, ' ', logradouro.descricao) COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI)");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("logradouro.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "logradouro.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "logradouro.* ") +
                    "from \n" +
                    "   logradouro logradouro\n" +
                    "       inner join cidade cidade on logradouro.idCidade = cidade.idCidade \n" +
                    "       inner join tipoLogradouro tipoLogradouro on tipoLogradouro.idTipoLogradouro = logradouro.idTipoLogradouro \n" +
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Logradouro input = (Data.Logradouro)parametros["Key"];
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
                    typeof(Tables.Logradouro),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Logradouro _data in
                    (System.Collections.Generic.List<Tables.Logradouro>)this.m_EntityManager.list
                    (
                        typeof(Tables.Logradouro),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Logradouro(), _data, level);

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
