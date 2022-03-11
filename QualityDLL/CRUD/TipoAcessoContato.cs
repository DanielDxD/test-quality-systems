using System;

namespace WS.CRUD
{
    public class TipoAcessoContato : WS.CRUD.Base
    {
        public TipoAcessoContato(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoAcessoContato input = (Data.TipoAcessoContato)parametros["Key"];
            Tables.TipoAcessoContato bd = new Tables.TipoAcessoContato();

            bd.idTipoAcessoContato.isNull = true;
            bd.tipo.value = input.tipo;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.TipoAcessoContato)parametros["Key"]).idTipoAcessoContato = (int)bd.idTipoAcessoContato.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoAcessoContato input = (Data.TipoAcessoContato)parametros["Key"];
            Tables.TipoAcessoContato bd = (Tables.TipoAcessoContato)this.m_EntityManager.find
            (
                typeof(Tables.TipoAcessoContato),
                new Object[]
                {
                    input.idTipoAcessoContato
                }
            );

            bd.tipo.value = input.tipo;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoAcessoContato bd = new Tables.TipoAcessoContato();

            bd.idTipoAcessoContato.value = ((Data.TipoAcessoContato)parametros["Key"]).idTipoAcessoContato;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoAcessoContato)bd).idTipoAcessoContato.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoAcessoContato)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoAcessoContato)input).idTipoAcessoContato = ((Tables.TipoAcessoContato)bd).idTipoAcessoContato.value;
                    ((Data.TipoAcessoContato)input).tipo = ((Tables.TipoAcessoContato)bd).tipo.value;
                    ((Data.TipoAcessoContato)input).descricao = ((Tables.TipoAcessoContato)bd).descricao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoAcessoContato result = (Data.TipoAcessoContato)parametros["Key"];

            try
            {
                result = (Data.TipoAcessoContato)this.preencher
                (
                    new Data.TipoAcessoContato(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoAcessoContato),
                        new Object[]
                        {
                            result.idTipoAcessoContato
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
            Data.TipoAcessoContato input = (Data.TipoAcessoContato)parametros["Key"];
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
                    typeof(Tables.TipoAcessoContato),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoAcessoContato _data in
                    (System.Collections.Generic.List<Tables.TipoAcessoContato>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoAcessoContato),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.TipoAcessoContato(), _data, level);

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

            Data.TipoAcessoContato _input = (Data.TipoAcessoContato)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTipoAcessoContato > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "TipoAcessoContato.idTipoAcessoContato = @idTipoAcessoContato");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoAcessoContato", _input.idTipoAcessoContato));
                    if (!sqlOrderBy.Contains("TipoAcessoContato.idTipoAcessoContato"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "TipoAcessoContato.idTipoAcessoContato");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "TipoAcessoContato.tipo = @tipo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipo", _input.tipo));
                    if (!sqlOrderBy.Contains("TipoAcessoContato.tipo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "TipoAcessoContato.tipo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "TipoAcessoContato.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", '%' + _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("TipoAcessoContato.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "TipoAcessoContato.descricao");
                    else { }
                }
                else { }



                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "TipoAcessoContato.* ") +
                    "from \n" +
                    "   TipoAcessoContato TipoAcessoContato\n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
