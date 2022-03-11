using System;

namespace WS.CRUD
{
    public class TipoRelacionamentoEmpresa : WS.CRUD.Base
    {
        public TipoRelacionamentoEmpresa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoRelacionamentoEmpresa input = (Data.TipoRelacionamentoEmpresa)parametros["Key"];
            Tables.TipoRelacionamentoEmpresa bd = new Tables.TipoRelacionamentoEmpresa();

            bd.idTipoRelacionamentoEmpresa.isNull = true;
            bd.descricao.value = input.descricao;
            bd.empresaSocio.value = input.empresaSocio;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.persist(bd);

            ((Data.TipoRelacionamentoEmpresa)parametros["Key"]).idTipoRelacionamentoEmpresa = (int)bd.idTipoRelacionamentoEmpresa.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoRelacionamentoEmpresa input = (Data.TipoRelacionamentoEmpresa)parametros["Key"];
            Tables.TipoRelacionamentoEmpresa bd = (Tables.TipoRelacionamentoEmpresa)this.m_EntityManager.find
            (
                typeof(Tables.TipoRelacionamentoEmpresa),
                new Object[]
                {
                    input.idTipoRelacionamentoEmpresa
                }
            );

            bd.descricao.value = input.descricao;
            bd.empresaSocio.value = input.empresaSocio;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoRelacionamentoEmpresa bd = new Tables.TipoRelacionamentoEmpresa();

            bd.idTipoRelacionamentoEmpresa.value = ((Data.TipoRelacionamentoEmpresa)parametros["Key"]).idTipoRelacionamentoEmpresa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoRelacionamentoEmpresa)bd).idTipoRelacionamentoEmpresa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoRelacionamentoEmpresa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoRelacionamentoEmpresa)input).idTipoRelacionamentoEmpresa = ((Tables.TipoRelacionamentoEmpresa)bd).idTipoRelacionamentoEmpresa.value;
                    ((Data.TipoRelacionamentoEmpresa)input).descricao = ((Tables.TipoRelacionamentoEmpresa)bd).descricao.value;
                    ((Data.TipoRelacionamentoEmpresa)input).empresaSocio = ((Tables.TipoRelacionamentoEmpresa)bd).empresaSocio.value;
                    ((Data.TipoRelacionamentoEmpresa)input).tipo = ((Tables.TipoRelacionamentoEmpresa)bd).tipo.value;
                }
                else { }
            }
            else { }

            return input;
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

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
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

            Data.TipoRelacionamentoEmpresa _input = (Data.TipoRelacionamentoEmpresa)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idTipoRelacionamentoEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = @idTipoRelacionamentoEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoRelacionamentoEmpresa", _input.idTipoRelacionamentoEmpresa));
                    if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamentoEmpresa.tipo = @tipo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipo", _input.tipo));
                    if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.tipo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.tipo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.empresaSocio))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamentoEmpresa.empresaSocio = @empresaSocio");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("empresaSocio", _input.empresaSocio));
                    if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.empresaSocio"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.empresaSocio");
                    else { }
                }
                else { }

                result =
                    (
                        (
                            @"select " + (numRows > 0 && offSet < 0 ? " top " + numRows.ToString() + " " : "") +
                            @"   *
                            from
                                tipoRelacionamentoEmpresa		                            
                            "
                        ) +
                        (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (offSet > 0 && numRows > 0 ? " OFFSET " + offSet + " ROWS FETCH NEXT " + numRows + " ROWS ONLY" : "")
                    );

                table = null;
            }
            else { }

            return result;
        }


        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoRelacionamentoEmpresa result = (Data.TipoRelacionamentoEmpresa)parametros["Key"];

            try
            {
                result = (Data.TipoRelacionamentoEmpresa)this.preencher
                (
                    new Data.TipoRelacionamentoEmpresa(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoRelacionamentoEmpresa),
                        new Object[]
                        {
                            result.idTipoRelacionamentoEmpresa
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
            Data.TipoRelacionamentoEmpresa input = (Data.TipoRelacionamentoEmpresa)parametros["Key"];
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
                    typeof(Tables.TipoRelacionamentoEmpresa),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoRelacionamentoEmpresa _data in
                    (System.Collections.Generic.List<Tables.TipoRelacionamentoEmpresa>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoRelacionamentoEmpresa),
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
                    _base = (Data.Base)this.preencher(new Data.TipoRelacionamentoEmpresa(), _data, level);

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
