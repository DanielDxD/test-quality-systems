using System;

namespace WS.CRUD
{
    public class TipoSituacao : WS.CRUD.Base
    {
        public TipoSituacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoSituacao input = (Data.TipoSituacao)parametros["Key"];
            Tables.TipoSituacao bd = new Tables.TipoSituacao();

            bd.idTipoSituacao.isNull = true;
            bd.descricao.value = input.descricao;
            bd.bloqueioPortaria.value = input.bloqueioPortaria == "s";
            bd.observacao.value = input.observacao;
            bd.idEmpresa.value = input.idEmpresa;

            this.m_EntityManager.persist(bd);

            ((Data.TipoSituacao)parametros["Key"]).idTipoSituacao = (int)bd.idTipoSituacao.value;           

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoSituacao input = (Data.TipoSituacao)parametros["Key"];
            Tables.TipoSituacao bd = (Tables.TipoSituacao)this.m_EntityManager.find
            (
                typeof(Tables.TipoSituacao),
                new Object[]
                {
                    input.idTipoSituacao
                }
            );

            bd.descricao.value = input.descricao;
            bd.bloqueioPortaria.value = input.bloqueioPortaria == "s";
            bd.observacao.value = input.observacao;
            bd.idEmpresa.value = input.idEmpresa;
            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoSituacao bd = new Tables.TipoSituacao();

            bd.idTipoSituacao.value = ((Data.TipoSituacao)parametros["Key"]).idTipoSituacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoSituacao)bd).idTipoSituacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoSituacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoSituacao)input).idTipoSituacao = ((Tables.TipoSituacao)bd).idTipoSituacao.value;
                    ((Data.TipoSituacao)input).descricao = ((Tables.TipoSituacao)bd).descricao.value;
                    ((Data.TipoSituacao)input).bloqueioPortaria = ((Tables.TipoSituacao)bd).bloqueioPortaria.value ? "s" : "n";
                    ((Data.TipoSituacao)input).observacao = ((Tables.TipoSituacao)bd).observacao.value;
                    ((Data.TipoSituacao)input).idEmpresa = ((Tables.TipoSituacao)bd).idEmpresa.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoSituacao result = (Data.TipoSituacao)parametros["Key"];

            try
            {
                result = (Data.TipoSituacao)this.preencher
                (
                    new Data.TipoSituacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoSituacao),
                        new Object[]
                        {
                            result.idTipoSituacao
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
            Data.TipoSituacao input = (Data.TipoSituacao)parametros["Key"];
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
                    typeof(Tables.TipoSituacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoSituacao _data in
                    (System.Collections.Generic.List<Tables.TipoSituacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoSituacao),
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
                    _base = (Data.Base)this.preencher(new Data.TipoSituacao(), _data, level);

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

            Data.TipoSituacao _input = (Data.TipoSituacao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idTipoSituacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "TipoSituacao.idTipoSituacao = @idTipoSituacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoSituacao", _input.idTipoSituacao));
                    if (!sqlOrderBy.Contains("TipoSituacao.idTipoSituacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "TipoSituacao.idTipoSituacao");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "TipoSituacao.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("TipoSituacao.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "TipoSituacao.idEmpresa");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.bloqueioPortaria))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "TipoSituacao.bloqueioPortaria = @bloqueioPortaria");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("bloqueioPortaria", _input.bloqueioPortaria == "s"));
                    if (!sqlOrderBy.Contains("TipoSituacao.bloqueioPortaria"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "TipoSituacao.bloqueioPortaria");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "TipoSituacao.* ") +
                    "from " +
                    (
                        "   TipoSituacao TipoSituacao "
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
