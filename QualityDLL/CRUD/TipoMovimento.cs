using System;

namespace WS.CRUD
{
    public class TipoMovimento : WS.CRUD.Base
    {
        public TipoMovimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoMovimento input = (Data.TipoMovimento)parametros["Key"];
            Tables.TipoMovimento bd = new Tables.TipoMovimento();

            bd.idTipoMovimento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.persist(bd);

            ((Data.TipoMovimento)parametros["Key"]).idTipoMovimento = (int)bd.idTipoMovimento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoMovimento input = (Data.TipoMovimento)parametros["Key"];
            Tables.TipoMovimento bd = (Tables.TipoMovimento)this.m_EntityManager.find
            (
                typeof(Tables.TipoMovimento),
                new Object[]
                {
                    input.idTipoMovimento
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoMovimento bd = new Tables.TipoMovimento();

            bd.idTipoMovimento.value = ((Data.TipoMovimento)parametros["Key"]).idTipoMovimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoMovimento)bd).idTipoMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoMovimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoMovimento)input).idTipoMovimento = ((Tables.TipoMovimento)bd).idTipoMovimento.value;
                    ((Data.TipoMovimento)input).descricao = ((Tables.TipoMovimento)bd).descricao.value;
                    ((Data.TipoMovimento)input).tipo = ((Tables.TipoMovimento)bd).tipo.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoMovimento result = (Data.TipoMovimento)parametros["Key"];

            try
            {
                result = (Data.TipoMovimento)this.preencher
                (
                    new Data.TipoMovimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoMovimento),
                        new Object[]
                        {
                            result.idTipoMovimento
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

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }
            }
            else { }

            Data.TipoMovimento _input = (Data.TipoMovimento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTipoMovimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoMovimento.idTipoMovimento = @idTipoMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoMovimento", _input.idTipoMovimento));
                    if (!sqlOrderBy.Contains("tipoMovimento.idTipoMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoMovimento.idTipoMovimento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoMovimento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("tipoMovimento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoMovimento.descricao");
                    else { }
                }

                result =
                (

                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "tipoMovimento.* ") +
                    "from " +
                    "   tipoMovimento " +
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
            Data.TipoMovimento input = (Data.TipoMovimento)parametros["Key"];
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
                    typeof(Tables.TipoMovimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoMovimento _data in
                    (System.Collections.Generic.List<Tables.TipoMovimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoMovimento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.TipoMovimento(), _data, level);

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
