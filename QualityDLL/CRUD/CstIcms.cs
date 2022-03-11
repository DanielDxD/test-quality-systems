using System;

namespace WS.CRUD
{
    public class CstIcms : WS.CRUD.Base
    {
        public CstIcms(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CstIcms input = (Data.CstIcms)parametros["Key"];
            Tables.CstIcms bd = new Tables.CstIcms();

            bd.cstCsosn.value = input.cstCsosn;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);
            ((Data.CstIcms)parametros["Key"]).idcstIcms = (int)bd.idcstIcms.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CstIcms input = (Data.CstIcms)parametros["Key"];
            Tables.CstIcms bd = (Tables.CstIcms)this.m_EntityManager.find
            (
                typeof(Tables.CstIcms),
                new Object[]
                {
                    input.idcstIcms
                }
            );

            bd.cstCsosn.value = input.cstCsosn;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CstIcms bd = new Tables.CstIcms();

            bd.idcstIcms.value = ((Data.CstIcms)parametros["Key"]).idcstIcms;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.CstIcms)bd).idcstIcms.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CstIcms)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CstIcms)input).idcstIcms = ((Tables.CstIcms)bd).idcstIcms.value;
                    ((Data.CstIcms)input).cstCsosn = ((Tables.CstIcms)bd).cstCsosn.value;
                    ((Data.CstIcms)input).descricao = ((Tables.CstIcms)bd).descricao.value;
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.CstIcms result = (Data.CstIcms)parametros["Key"];

            try
            {
                result = (Data.CstIcms)this.preencher
                (
                    new Data.CstIcms(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CstIcms),
                        new Object[]
                        {
                            result.idcstIcms
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

            Data.CstIcms _input = (Data.CstIcms)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idcstIcms > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CstIcms.idcstIcms = @idcstIcms");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idcstIcms", _input.idcstIcms));
                    if (!sqlOrderBy.Contains("CstIcms.idcstIcms"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CstIcms.idcstIcms");
                    else { }
                }
                else { }

                if (_input.cstCsosn > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CstIcms.cstCsosn = @cstCsosn");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("cstCsosn", _input.cstCsosn));
                    if (!sqlOrderBy.Contains("CstIcms.cstCsosn"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CstIcms.cstCsosn");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CstIcms.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("CstIcms.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CstIcms.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CstIcms.* ") +
                    "from " +
                    (
                        "   CstIcms CstIcms " 
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
            Data.CstIcms input = (Data.CstIcms)parametros["Key"];
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
                    typeof(Tables.CstIcms),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CstIcms _data in
                    (System.Collections.Generic.List<Tables.CstIcms>)this.m_EntityManager.list
                    (
                        typeof(Tables.CstIcms),
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
                    _base = (Data.Base)this.preencher(new Data.CstIcms(), _data, level);

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
