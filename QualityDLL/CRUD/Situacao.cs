using System;

namespace WS.CRUD
{
    public class Situacao : WS.CRUD.Base
    {
        public Situacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Situacao input = (Data.Situacao)parametros["Key"];
            Tables.Situacao bd = new Tables.Situacao();

            bd.idSituacao.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipoSituacao.idTipoSituacao.value = input.tipoSituacao.idTipoSituacao;

            this.m_EntityManager.persist(bd);

            ((Data.Situacao)parametros["Key"]).idSituacao = (int)bd.idSituacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Situacao input = (Data.Situacao)parametros["Key"];
            Tables.Situacao bd = (Tables.Situacao)this.m_EntityManager.find
            (
                typeof(Tables.Situacao),
                new Object[]
                {
                    input.idSituacao
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipoSituacao.idTipoSituacao.value = input.tipoSituacao.idTipoSituacao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Situacao bd = new Tables.Situacao();

            bd.idSituacao.value = ((Data.Situacao)parametros["Key"]).idSituacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Situacao)bd).idSituacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Situacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Situacao)input).idSituacao = ((Tables.Situacao)bd).idSituacao.value;
                    ((Data.Situacao)input).descricao = ((Tables.Situacao)bd).descricao.value;
                    ((Data.Situacao)input).tipoSituacao = (Data.TipoSituacao)(new WS.CRUD.TipoSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoSituacao(),
                        ((Tables.Situacao)bd).tipoSituacao,
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
            Data.Situacao result = (Data.Situacao)parametros["Key"];

            try
            {
                result = (Data.Situacao)this.preencher
                (
                    new Data.Situacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Situacao),
                        new Object[]
                        {
                            result.idSituacao
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
            Data.Situacao input = (Data.Situacao)parametros["Key"];
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
                    typeof(Tables.Situacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Situacao _data in
                    (System.Collections.Generic.List<Tables.Situacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.Situacao),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.Situacao(), _data, level);

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

            Data.Situacao _input = (Data.Situacao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idSituacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Situacao.idSituacao = @idSituacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idSituacao", _input.idSituacao));
                    if (!sqlOrderBy.Contains("Situacao.idSituacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Situacao.idSituacao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Situacao.descricao LIKE @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("Situacao.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Situacao.descricao");
                    else { }
                }
                else { }

                if(_input.tipoSituacao != null)
                {
                    if(_input.tipoSituacao.idTipoSituacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoSituacao.idTipoSituacao = @idTipoSituacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoSituacao", _input.tipoSituacao.idTipoSituacao));
                        if (!sqlOrderBy.Contains("tipoSituacao.idTipoSituacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoSituacao.idTipoSituacao");
                        else { }
                    }
                    else { }

                    if(_input.tipoSituacao.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoSituacao.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.tipoSituacao.idEmpresa));
                        if (!sqlOrderBy.Contains("tipoSituacao.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoSituacao.idEmpresa");
                        else { }
                    }
                    else { }
                }
                else { }                

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Situacao.* ") +
                    "from " +
                    (
                        "   Situacao Situacao " +
                        "       inner join tipoSituacao tipoSituacao " +
                        "           on	tipoSituacao.idTipoSituacao = Situacao.idTipoSituacao "
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
