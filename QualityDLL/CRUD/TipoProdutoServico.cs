using System;

namespace WS.CRUD
{
    public class TipoProdutoServico : WS.CRUD.Base
    {
        public TipoProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoProdutoServico input = (Data.TipoProdutoServico)parametros["Key"];
            Tables.TipoProdutoServico bd = new Tables.TipoProdutoServico();

            bd.idTipoProdutoServico.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.persist(bd);

            ((Data.TipoProdutoServico)parametros["Key"]).idTipoProdutoServico = (int)bd.idTipoProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoProdutoServico input = (Data.TipoProdutoServico)parametros["Key"];
            Tables.TipoProdutoServico bd = (Tables.TipoProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.TipoProdutoServico),
                new Object[]
                {
                    input.idTipoProdutoServico
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoProdutoServico bd = new Tables.TipoProdutoServico();

            bd.idTipoProdutoServico.value = ((Data.TipoProdutoServico)parametros["Key"]).idTipoProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoProdutoServico)bd).idTipoProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoProdutoServico)input).idTipoProdutoServico = ((Tables.TipoProdutoServico)bd).idTipoProdutoServico.value;
                    ((Data.TipoProdutoServico)input).descricao = ((Tables.TipoProdutoServico)bd).descricao.value;
                    ((Data.TipoProdutoServico)input).tipo = ((Tables.TipoProdutoServico)bd).tipo.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoProdutoServico result = (Data.TipoProdutoServico)parametros["Key"];

            try
            {
                result = (Data.TipoProdutoServico)this.preencher
                (
                    new Data.TipoProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoProdutoServico),
                        new Object[]
                        {
                            result.idTipoProdutoServico
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

            Data.TipoProdutoServico _input = (Data.TipoProdutoServico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idTipoProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoProdutoServico.idTipoProdutoServico = @idTipoProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoProdutoServico", _input.idTipoProdutoServico));
                    if (!sqlOrderBy.Contains("tipoProdutoServico.idTipoProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoProdutoServico.idTipoProdutoServico");
                    else { }
                }
                else { }

                if ((_input.descricao != null) && (_input.descricao.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoProdutoServico.descricao COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("tipoProdutoServico.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoProdutoServico.descricao");
                    else { };
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "tipoProdutoServico.* ") +
                    "from " +
                        "   tipoProdutoServico " +
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
            Data.TipoProdutoServico input = (Data.TipoProdutoServico)parametros["Key"];
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
                    typeof(Tables.TipoProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoProdutoServico _data in
                    (System.Collections.Generic.List<Tables.TipoProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoProdutoServico),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.TipoProdutoServico();
                        ((Data.TipoProdutoServico)_base).idTipoProdutoServico = _data.idTipoProdutoServico.value;
                        ((Data.TipoProdutoServico)_base).descricao = _data.descricao.value;
                        ((Data.TipoProdutoServico)_base).tipo = _data.tipo.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.TipoProdutoServico(), _data, level);

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
