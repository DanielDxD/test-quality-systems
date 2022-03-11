using System;

namespace WS.CRUD
{
    public class Banco : WS.CRUD.Base
    {
        public Banco(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Banco input = (Data.Banco)parametros["Key"];
            Tables.Banco bd = new Tables.Banco();

            bd.idBanco.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            bd.codigoBanco.value = input.codigoBanco;
            bd.codigoAgencia.value = input.codigoAgencia;
            bd.digitoAgencia.value = input.digitoAgencia;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.Banco)parametros["Key"]).idBanco = (int)bd.idBanco.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Banco input = (Data.Banco)parametros["Key"];
            Tables.Banco bd = (Tables.Banco)this.m_EntityManager.find
            (
                typeof(Tables.Banco),
                new Object[]
                {
                    input.idBanco
                }
            );

            bd.codigoBanco.value = input.codigoBanco;
            bd.codigoAgencia.value = input.codigoAgencia;
            bd.digitoAgencia.value = input.digitoAgencia;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Banco bd = new Tables.Banco();

            bd.idBanco.value = ((Data.Banco)parametros["Key"]).idBanco;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Banco)bd).idBanco.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Banco)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Banco)input).idEmpresa = ((Tables.Banco)bd).idEmpresa.value;
                    ((Data.Banco)input).idBanco = ((Tables.Banco)bd).idBanco.value;
                    ((Data.Banco)input).codigoBanco = ((Tables.Banco)bd).codigoBanco.value;
                    ((Data.Banco)input).codigoAgencia = ((Tables.Banco)bd).codigoAgencia.value;
                    ((Data.Banco)input).digitoAgencia = ((Tables.Banco)bd).digitoAgencia.value;
                    ((Data.Banco)input).descricao = ((Tables.Banco)bd).descricao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Banco result = (Data.Banco)parametros["Key"];

            try
            {
                result = (Data.Banco)this.preencher
                (
                    new Data.Banco(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Banco),
                        new Object[]
                        {
                            result.idBanco
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

            Data.Banco _input = (Data.Banco)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idBanco > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "banco.idBanco = @idBanco");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBanco", _input.idBanco));
                    if (!sqlOrderBy.Contains("banco.idBanco"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "banco.idBanco");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   banco.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("banco.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "banco.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   banco.*\n" +
                    "from \n" + 
                    "   banco\n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Banco input = (Data.Banco)parametros["Key"];
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
                    typeof(Tables.Banco),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Banco _data in
                    (System.Collections.Generic.List<Tables.Banco>)this.m_EntityManager.list
                    (
                        typeof(Tables.Banco),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Banco(), _data, level);

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
