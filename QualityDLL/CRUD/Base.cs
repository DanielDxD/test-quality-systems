using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WS.CRUD.Interface;

/// <summary>
/// Summary description for UsuarioSistema
/// </summary>
namespace WS.CRUD
{
    public class Base : WS.CRUD.Interface.CRUD
    {
        protected EJB.EntityManager.EntityManager m_EntityManager;

        protected long? m_IdEmpresaCorrente;

        public Base(long? idEmpresaCorrente, EJB.EntityManager.EntityManager entityManager)
        {
            this.m_IdEmpresaCorrente = idEmpresaCorrente;
            this.m_EntityManager = entityManager;
        }

        public void bancoDeDados(EJB.EntityManager.EntityManager entityManager)
        {
            this.m_EntityManager = entityManager;
        }

        public virtual Object incluir(System.Collections.Hashtable parametros)
        {
            return null;
        }

        public virtual Object alterar(System.Collections.Hashtable parametros)
        {
            return null;
        }

        public virtual void excluir(System.Collections.Hashtable parametros)
        {
        }

        public virtual Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            return null;
        }

        public Object atualizar(System.Collections.Hashtable parametros)
        {
            Object result = null;

            try
            {
                switch (((Data.Base)parametros["Key"]).operacao)
                {
                    case ENum.eOperacao.INCLUIR:
                        result = incluir(parametros);
                        break;

                    case ENum.eOperacao.ALTERAR:
                        result = alterar(parametros);
                        break;

                    case ENum.eOperacao.EXCLUIR:
                        excluir(parametros);
                        break;

                    default:
                        result = (Data.Base)parametros["Key"];
                        break;
                }
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".atualizar() -> " + e.ToString());

                throw e;
            }

            return result;
        }

        public virtual Object consultar(System.Collections.Hashtable parametros)
        {
            return null;
        }

        public virtual String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
               result = "",
               sqlFields = "",
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

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                foreach (EJB.Attributes.TColumn column in table.columns(true))
                    sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + column.name;

                foreach (EJB.Attributes.TColumn column in table.columns(false))
                {
                    sqlFields += (sqlFields.Length > 0 ? ", " : "") + column.name;

                    Object
                        inputField = null,
                        inputValue = null;

                    inputField = input.GetType().GetProperty(column.name);

                    if ((inputField == null) && column.name.StartsWith("id"))
                    {
                        String _columnName = column.name.Substring(2);
                        inputField = input.GetType().GetProperty(_columnName.Substring(0, 1).ToLower() + _columnName.Substring(1));
                    }
                    else { }

                    if (inputField != null)
                        inputValue = ((System.Reflection.PropertyInfo)inputField).GetValue(input, new Object[0]);
                    else { }

                    if (inputValue != null)
                    {
                        String _columnName = column.name;

                        if (inputValue.GetType().IsSubclassOf(typeof(Data.Base)))
                            inputValue = inputValue.GetType().GetProperty(column.name).GetValue(inputValue, new Object[0]);
                        else { }

                        String typeValue = inputValue.GetType().Name;

                        switch (typeValue)
                        {
                            case "Boolean":
                                if (((bool)inputValue))
                                {
                                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + _columnName + " = @" + _columnName;
                                    fieldKeys.Add(new EJB.TableBase.TFieldInteger(_columnName, (int)1));
                                }
                                else { }
                                break;

                            case "DateTime":
                                if (((DateTime)inputValue).Ticks != 0)
                                {
                                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + _columnName + " = @" + _columnName;
                                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime(_columnName, (DateTime)inputValue));
                                }
                                else { }
                                break;

                            case "Image":
                                break;

                            case "Int16":
                            case "Int32":
                                if (((int)inputValue) != 0)
                                {
                                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + _columnName + " = @" + _columnName;
                                    fieldKeys.Add(new EJB.TableBase.TFieldInteger(_columnName, (int)inputValue));
                                }
                                else { }
                                break;
                            case "Int64":
                                if (((Int64)inputValue) != 0)
                                {
                                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + _columnName + " = @" + _columnName;
                                    fieldKeys.Add(new EJB.TableBase.TFieldBigInteger(_columnName, (Int64)inputValue));
                                }
                                else { }
                                break;

                            case "Double":
                                if (((Double)inputValue) != 0.0)
                                {
                                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + _columnName + " = @" + _columnName;
                                    fieldKeys.Add(new EJB.TableBase.TFieldDouble(_columnName, (Double)inputValue));
                                }
                                else { }
                                break;

                            default:
                                if (((String)inputValue).Length > 0)
                                {
                                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + _columnName + " COLLATE Latin1_General_CI_AI like @" + _columnName + " COLLATE Latin1_General_CI_AI";
                                    fieldKeys.Add(new EJB.TableBase.TFieldString(_columnName, (String)inputValue + "%"));
                                }
                                else { }
                                break;
                        }
                    }
                    else { }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : sqlFields) +
                    " from " +
                    table.tableName +
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

        public virtual int contar(System.Collections.Hashtable parametros)
        {
            System.Data.SqlClient.SqlConnection _connection = null;

            System.Data.SqlClient.SqlCommand _command = null;

            int result = 0;

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros != null)
                {
                    if (parametros["Filter"] != null)
                    {
                        parametros["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
                        String
                            _filter = (String)parametros["Filter"],
                            _keys = "";

                        while (_filter.Contains("@"))
                        {
                            String __key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                            if (!_keys.Contains("[" + __key + "]"))
                            {
                                _fieldKeys.Add((EJB.TableBase.TField)parametros[__key]);
                                _keys += "[" + __key + "]";
                            }
                            else { }

                            _filter = _filter.Substring(_filter.IndexOf("@") + __key.Length);
                        }
                    }
                    else { }
                }
                else { }

                parametros.Add("onlyCount", true);

                _connection = new System.Data.SqlClient.SqlConnection(Utils.Utils.getSqlConfigs());
                _connection.Open();
                _command = _connection.CreateCommand();
                Type _targetTable = Type.GetType("Tables." + (parametros["Key"].GetType().Name.Replace("View", "")));

                _command.CommandText = this.makeSelect(_targetTable, (Data.Base)parametros["Key"], _fieldKeys, parametros);
                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; i < _fieldKeys.Count; i++)
                {
                    _command.Parameters.Add("@" + _fieldKeys[i].name, _fieldKeys[i].type);
                    _command.Parameters["@" + _fieldKeys[i].name].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + _fieldKeys[i].name].Value = _fieldKeys[i].value;
                }
                string query = m_EntityManager.CommandAsSql(_command);
                result = (int)_command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_command != null)
                {
                    _command.Dispose();
                    _command = null;
                }
                else { }

                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }
            }

            return result;
        }
        public virtual Object listar(Hashtable parametros)
        {
            return null;
        }
    }
}
