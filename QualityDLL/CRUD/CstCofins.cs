using System;

namespace WS.CRUD
{
    public class CstCofins : WS.CRUD.Base
    {
        public CstCofins(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CstCofins input = (Data.CstCofins)parametros["Key"];
            Tables.CstCofins bd = new Tables.CstCofins();

            bd.cst.value = input.cst;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);
            ((Data.CstCofins)parametros["Key"]).idcstCofins = (int)bd.idcstCofins.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CstCofins input = (Data.CstCofins)parametros["Key"];
            Tables.CstCofins bd = (Tables.CstCofins)this.m_EntityManager.find
            (
                typeof(Tables.CstCofins),
                new Object[]
                {
                    input.idcstCofins
                }
            );

            bd.cst.value = input.cst;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CstCofins bd = new Tables.CstCofins();

            bd.idcstCofins.value = ((Data.CstCofins)parametros["Key"]).idcstCofins;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.CstCofins)bd).idcstCofins.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CstCofins)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CstCofins)input).idcstCofins = ((Tables.CstCofins)bd).idcstCofins.value;
                    ((Data.CstCofins)input).cst = ((Tables.CstCofins)bd).cst.value;
                    ((Data.CstCofins)input).descricao = ((Tables.CstCofins)bd).descricao.value;
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.CstCofins result = (Data.CstCofins)parametros["Key"];

            try
            {
                result = (Data.CstCofins)this.preencher
                (
                    new Data.CstCofins(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CstCofins),
                        new Object[]
                        {
                            result.idcstCofins
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

            Data.CstCofins _input = (Data.CstCofins)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idcstCofins > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CstCofins.idcstCofins = @idcstCofins");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idcstCofins", _input.idcstCofins));
                    if (!sqlOrderBy.Contains("CstCofins.idcstCofins"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CstCofins.idcstCofins");
                    else { }
                }
                else { }

                if (_input.cst > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CstCofins.cst = @cst");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("cst", _input.cst));
                    if (!sqlOrderBy.Contains("CstCofins.cst"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CstCofins.cst");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CstCofins.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("CstCofins.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CstCofins.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CstCofins.* ") +
                    "from " +
                    (
                        "   CstCofins CstCofins " 
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
            Data.CstCofins input = (Data.CstCofins)parametros["Key"];
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
                    typeof(Tables.CstCofins),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CstCofins _data in
                    (System.Collections.Generic.List<Tables.CstCofins>)this.m_EntityManager.list
                    (
                        typeof(Tables.CstCofins),
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
                    _base = (Data.Base)this.preencher(new Data.CstCofins(), _data, level);

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
