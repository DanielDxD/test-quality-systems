using System;

namespace WS.CRUD
{
    public class TipoEnderecoContato : WS.CRUD.Base
    {
        public TipoEnderecoContato(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoEnderecoContato input = (Data.TipoEnderecoContato)parametros["Key"];
            Tables.TipoEnderecoContato bd = new Tables.TipoEnderecoContato();

            bd.idTipoEnderecoContato.isNull = true;
            bd.descricao.value = input.descricao;
            bd.enderecoContato.value = input.enderecoContato;

            this.m_EntityManager.persist(bd);

            ((Data.TipoEnderecoContato)parametros["Key"]).idTipoEnderecoContato = (int)bd.idTipoEnderecoContato.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoEnderecoContato input = (Data.TipoEnderecoContato)parametros["Key"];
            Tables.TipoEnderecoContato bd = (Tables.TipoEnderecoContato)this.m_EntityManager.find
            (
                typeof(Tables.TipoEnderecoContato),
                new Object[]
                {
                    input.idTipoEnderecoContato
                }
            );

            bd.descricao.value = input.descricao;
            bd.enderecoContato.value = input.enderecoContato;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoEnderecoContato bd = new Tables.TipoEnderecoContato();

            bd.idTipoEnderecoContato.value = ((Data.TipoEnderecoContato)parametros["Key"]).idTipoEnderecoContato;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoEnderecoContato)bd).idTipoEnderecoContato.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoEnderecoContato)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoEnderecoContato)input).idTipoEnderecoContato = ((Tables.TipoEnderecoContato)bd).idTipoEnderecoContato.value;
                    ((Data.TipoEnderecoContato)input).descricao = ((Tables.TipoEnderecoContato)bd).descricao.value;
                    ((Data.TipoEnderecoContato)input).enderecoContato = ((Tables.TipoEnderecoContato)bd).enderecoContato.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoEnderecoContato result = (Data.TipoEnderecoContato)parametros["Key"];

            try
            {
                result = (Data.TipoEnderecoContato)this.preencher
                (
                    new Data.TipoEnderecoContato(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoEnderecoContato),
                        new Object[]
                        {
                            result.idTipoEnderecoContato
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
            Data.TipoEnderecoContato input = (Data.TipoEnderecoContato)parametros["Key"];
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

                /*if(parametros["Order"] != null)
                {
                    String _order = (String)parametros["Order"];

                    while (_order.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }*/

                String _select = this.makeSelect
                (
                    typeof(Tables.TipoEnderecoContato),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoEnderecoContato _data in
                    (System.Collections.Generic.List<Tables.TipoEnderecoContato>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoEnderecoContato),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.TipoEnderecoContato(), _data, level);

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

            Data.TipoEnderecoContato _input = (Data.TipoEnderecoContato)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTipoEnderecoContato > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " TipoEnderecoContato.idTipoEnderecoContato = @idTipoEnderecoContato";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoEnderecoContato", _input.idTipoEnderecoContato));
                    if (!sqlOrderBy.Contains("TipoEnderecoContato.idTipoEnderecoContato"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " TipoEnderecoContato.idTipoEnderecoContato";
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " TipoEnderecoContato.descricao like @descricao";
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("TipoEnderecoContato.descricao"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " TipoEnderecoContato.descricao";
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.enderecoContato))
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " TipoEnderecoContato.enderecoContato = @enderecoContato";
                    fieldKeys.Add(new EJB.TableBase.TFieldString("enderecoContato", _input.enderecoContato));
                    if (!sqlOrderBy.Contains("TipoEnderecoContato.enderecoContato"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " TipoEnderecoContato.enderecoContato";
                    else { }
                }
                else { }
            }
            else { }

            result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "TipoEnderecoContato.* ") +
                "from " +
                    "TipoEnderecoContato " +
                (sqlWhere.Length > 0 ? " where " + sqlWhere : "") + " " +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
            );

            table = null;

            return result;

        }
    }
}
