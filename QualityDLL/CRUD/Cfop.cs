using System;

namespace WS.CRUD
{
    public class CfOp : WS.CRUD.Base
    {
        public CfOp(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CfOp input = (Data.CfOp)parametros["Key"];
            Tables.CfOp bd = new Tables.CfOp();

            bd.codigo.value = input.codigo;
            bd.tipo.value = input.tipo;
            bd.descricao.value = input.descricao;
            bd.ativo.value = input.ativo == "s";

            this.m_EntityManager.persist(bd);
            ((Data.CfOp)parametros["Key"]).idCfop = (int)bd.idCfop.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CfOp input = (Data.CfOp)parametros["Key"];
            Tables.CfOp bd = (Tables.CfOp)this.m_EntityManager.find
            (
                typeof(Tables.CfOp),
                new Object[]
                {
                    input.idCfop
                }
            );

            bd.codigo.value = input.codigo;
            bd.tipo.value = input.tipo;
            bd.descricao.value = input.descricao;
            bd.ativo.value = input.ativo == "s";

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CfOp bd = new Tables.CfOp();

            bd.idCfop.value = ((Data.CfOp)parametros["Key"]).idCfop;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.CfOp)bd).idCfop.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CfOp)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CfOp)input).idCfop = ((Tables.CfOp)bd).idCfop.value;
                    ((Data.CfOp)input).codigo = ((Tables.CfOp)bd).codigo.value;
                    ((Data.CfOp)input).tipo = ((Tables.CfOp)bd).tipo.value;
                    ((Data.CfOp)input).descricao = ((Tables.CfOp)bd).descricao.value;
                    ((Data.CfOp)input).ativo = ((Tables.CfOp)bd).ativo.value ? "s" : "n";
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.CfOp result = (Data.CfOp)parametros["Key"];

            try
            {
                result = (Data.CfOp)this.preencher
                (
                    new Data.CfOp(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CfOp),
                        new Object[]
                        {
                            result.idCfop
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

            Data.CfOp _input = (Data.CfOp)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idCfop > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CfOp.idCfop = @idCfop");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCfop", _input.idCfop));
                    if (!sqlOrderBy.Contains("CfOp.idCfop"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CfOp.idCfop");
                    else { }
                }
                else { }

                if (_input.tipo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CfOp.tipo = @tipo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("tipo", _input.tipo));
                    if (!sqlOrderBy.Contains("CfOp.tipo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CfOp.tipo");
                    else { }
                }
                else { }

                if (_input.codigo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CfOp.codigo = @codigo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("codigo", _input.codigo));
                    if (!sqlOrderBy.Contains("CfOp.codigo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CfOp.codigo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.ativo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CfOp.ativo = @ativo");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("ativo", _input.ativo == "s"));
                    if (!sqlOrderBy.Contains("CfOp.ativo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CfOp.ativo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CfOp.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("CfOp.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CfOp.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CfOp.* ") +
                    "from " +
                    (
                        "   CfOp CfOp " 
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
            Data.CfOp input = (Data.CfOp)parametros["Key"];
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
                    typeof(Tables.CfOp),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CfOp _data in
                    (System.Collections.Generic.List<Tables.CfOp>)this.m_EntityManager.list
                    (
                        typeof(Tables.CfOp),
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
                    _base = (Data.Base)this.preencher(new Data.CfOp(), _data, level);

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
