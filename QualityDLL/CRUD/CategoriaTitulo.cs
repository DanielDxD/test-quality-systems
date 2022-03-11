using System;

namespace WS.CRUD
{
    public class CategoriaTitulo : WS.CRUD.Base
    {
        public CategoriaTitulo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CategoriaTitulo input = (Data.CategoriaTitulo)parametros["Key"];
            Tables.CategoriaTitulo bd = new Tables.CategoriaTitulo();

            bd.idCategoriaTitulo.isNull = true;
            bd.descricao.value = input.descricao;
            bd.descricaoReduzida.value = input.descricaoReduzida;
            bd.familiar.value = input.familiar;
            bd.mesesVigencia.value = input.mesesVigencia;
            bd.idEmpresa.value = input.idEmpresa;
            bd.numero.value = input.numero;

            this.m_EntityManager.persist(bd);

            ((Data.CategoriaTitulo)parametros["Key"]).idCategoriaTitulo = (int)bd.idCategoriaTitulo.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CategoriaTitulo input = (Data.CategoriaTitulo)parametros["Key"];
            Tables.CategoriaTitulo bd = (Tables.CategoriaTitulo)this.m_EntityManager.find
            (
                typeof(Tables.CategoriaTitulo),
                new Object[]
                {
                    input.idCategoriaTitulo
                }
            );

            bd.descricao.value = input.descricao;
            bd.descricaoReduzida.value = input.descricaoReduzida;
            bd.familiar.value = input.familiar;
            bd.mesesVigencia.value = input.mesesVigencia;
            bd.idEmpresa.value = input.idEmpresa;
            bd.numero.value = input.numero;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CategoriaTitulo bd = new Tables.CategoriaTitulo();

            bd.idCategoriaTitulo.value = ((Data.CategoriaTitulo)parametros["Key"]).idCategoriaTitulo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CategoriaTitulo)bd).idCategoriaTitulo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CategoriaTitulo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CategoriaTitulo)input).idCategoriaTitulo = ((Tables.CategoriaTitulo)bd).idCategoriaTitulo.value;
                    ((Data.CategoriaTitulo)input).descricao = ((Tables.CategoriaTitulo)bd).descricao.value;
                    ((Data.CategoriaTitulo)input).descricaoReduzida = ((Tables.CategoriaTitulo)bd).descricaoReduzida.value;
                    ((Data.CategoriaTitulo)input).familiar = ((Tables.CategoriaTitulo)bd).familiar.value;
                    ((Data.CategoriaTitulo)input).mesesVigencia = ((Tables.CategoriaTitulo)bd).mesesVigencia.value;
                    ((Data.CategoriaTitulo)input).idEmpresa = ((Tables.CategoriaTitulo)bd).idEmpresa.value;
                    ((Data.CategoriaTitulo)input).numero = ((Tables.CategoriaTitulo)bd).numero.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.CategoriaTitulo result = (Data.CategoriaTitulo)parametros["Key"];

            try
            {
                result = (Data.CategoriaTitulo)this.preencher
                (
                    new Data.CategoriaTitulo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CategoriaTitulo),
                        new Object[]
                        {
                            result.idCategoriaTitulo
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
            Data.CategoriaTitulo input = (Data.CategoriaTitulo)parametros["Key"];
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
                    typeof(Tables.CategoriaTitulo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CategoriaTitulo _data in
                    (System.Collections.Generic.List<Tables.CategoriaTitulo>)this.m_EntityManager.list
                    (
                        typeof(Tables.CategoriaTitulo),
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
                    _base = (Data.Base)this.preencher(new Data.CategoriaTitulo(), _data, level);

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

            Data.CategoriaTitulo _input = (Data.CategoriaTitulo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idCategoriaTitulo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CategoriaTitulo.idCategoriaTitulo = @idCategoriaTitulo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCategoriaTitulo", _input.idCategoriaTitulo));
                    if (!sqlOrderBy.Contains("CategoriaTitulo.idCategoriaTitulo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CategoriaTitulo.idCategoriaTitulo");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0 || _input.idEmpresa == -1)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CategoriaTitulo.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("CategoriaTitulo.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CategoriaTitulo.idEmpresa");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CategoriaTitulo.descricao = @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao));
                    if (!sqlOrderBy.Contains("CategoriaTitulo.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CategoriaTitulo.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricaoReduzida))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CategoriaTitulo.descricaoReduzida = @descricaoReduzida");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoReduzida", _input.descricaoReduzida));
                    if (!sqlOrderBy.Contains("CategoriaTitulo.descricaoReduzida"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CategoriaTitulo.descricaoReduzida");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CategoriaTitulo.* ") +
                    "from " +
                    (
                        "   CategoriaTitulo CategoriaTitulo "
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
