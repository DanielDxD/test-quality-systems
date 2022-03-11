using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EJB.TableBase;
using EJB.Attributes;

namespace EJB.EntityManager
{
    public class EntityManager
    {
        static int OpenedConnection = 0;

        private String m_ConnectionString;
        private System.Data.SqlClient.SqlConnection m_Connection;
        private System.Data.SqlClient.SqlTransaction m_Transaction;

        public EntityManager()
        {
        }

        public EntityManager(String ConnectionString)
        {
            this.m_ConnectionString = ConnectionString;
        }

        public String ConnectionString
        {
            get { return this.m_ConnectionString; }
            set { this.m_ConnectionString = value; }
        }

        public void beginTransaction(string name = null)
        {
            if (this.m_Transaction == null)
            {
                this.m_Connection = new System.Data.SqlClient.SqlConnection(this.m_ConnectionString);
                this.m_Connection.Open();
                EntityManager.OpenedConnection++;

                if (!string.IsNullOrEmpty(name))
                    this.m_Transaction = this.m_Connection.BeginTransaction(System.Data.IsolationLevel.Snapshot, name);
                else
                    this.m_Transaction = this.m_Connection.BeginTransaction();
            }
        }

        public void commitTransaction(string name = null)
        {
            try
            {
                if (this.m_Transaction != null)
                {
                    this.m_Transaction.Commit();
                    this.m_Transaction.Dispose();
                    this.m_Transaction = null;

                    this.m_Connection.Close();
                    this.m_Connection.Dispose();
                    this.m_Connection = null;
                    if (EntityManager.OpenedConnection > 0)
                        EntityManager.OpenedConnection--;
                }
                else { }
            }
            catch { }
        }

        public void rollbackTransaction(string name = null)
        {
            try
            {
                if (this.m_Transaction != null)
                {
                    if (!String.IsNullOrEmpty(name))
                        this.m_Transaction.Rollback(name);
                    else
                        this.m_Transaction.Rollback();
                    this.m_Transaction.Dispose();
                    this.m_Transaction = null;

                    this.m_Connection.Close();
                    this.m_Connection.Dispose();
                    this.m_Connection = null;
                    if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                }
                else { }
            }
            catch { }
        }

        public Boolean inTransacionMode
        {
            get { return this.m_Transaction != null; }
        }

        internal void _find(TTableBase table, Object[] key)
        {
            System.Data.SqlClient.SqlConnection _connection = null;

            try
            {
                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                    EntityManager.OpenedConnection++;
                }
                else
                    _connection = this.m_Connection;

                String
                    sqlFields = "",
                    sqlKeys = "";

                TColumn[] fields = table.columns(false);
                TColumn[] keys = table.columns(true);

                foreach (TColumn column in fields)
                    sqlFields += (sqlFields.Length > 0 ? ", " : "") + column.name;

                foreach (TColumn column in keys)
                    sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + column.name + " = @" + column.name;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText =
                (
                    "Select\n\t" +
                        sqlFields + '\n' +
                    "From\n\t" +
                        table.tableName + '\n' + //((TTable)table.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                    "where\n\t" +
                        sqlKeys
                );
                _command.Transaction = this.m_Transaction;
                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; i < keys.Length; i++)
                {
                    _command.Parameters.Add("@" + keys[i].name, keys[i].type);
                    _command.Parameters["@" + keys[i].name].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + keys[i].name].Value = key[i];
                }

                System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                if (data.Read())
                {
                    foreach
                    (
                        System.Reflection.FieldInfo fieldInfo in table.GetType().GetFields
                        (
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Public
                        )
                    )
                    {
                        if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                        {
                            if (data.IsDBNull(data.GetOrdinal(((TField)fieldInfo.GetValue(table)).name)))
                                ((TField)fieldInfo.GetValue(table)).isNull = true;
                            else
                            {
                                //if (fieldInfo.FieldType.IsInstanceOfType(typeof(TFieldBlob)))
                                //{
                                //    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(table)).name)));
                                //    ((TField)fieldInfo.GetValue(table)).internalValue = System.Drawing.Image.FromStream(ms);
                                //}
                                //else
                                ((TField)fieldInfo.GetValue(table)).internalValue = data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(table)).name));
                            }

                            ((TField)fieldInfo.GetValue(table)).isChanged = false;
                        }
                        else
                        {
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                            {
                                foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                {
                                    System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                                    bool existNullKey = false;

                                    for (int i = 0; i < attribute.count; i++)
                                    {
                                        if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                            existNullKey = true;
                                        else
                                            _keys.Add(data.GetValue(data.GetOrdinal(attribute.column(i))));
                                    }

                                    if (!existNullKey)
                                    {
                                        TTableBase _table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());
                                        if (this.m_Transaction == null)
                                            _table.connectionString = this.m_ConnectionString;
                                        else
                                            _table.entityManager = this;
                                        _table.keyFields = _keys.ToArray();

                                        fieldInfo.SetValue
                                        (
                                            table,
                                            _table
                                        );
                                    }
                                    else { }
                                }
                            }
                            else
                            {
                                if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                                {
                                    if (this.m_Transaction == null)
                                    {
                                        if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                        {
                                            TTableBase objectToList = (TTableBase)System.Reflection.Assembly.GetAssembly(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value).CreateInstance(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.ToString());

                                            foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                            {
                                                System.Collections.Generic.List<TBase> _keys = new System.Collections.Generic.List<TBase>();

                                                bool existNullKey = false;

                                                for (int i = 0; i < attribute.count; i++)
                                                {
                                                    if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                        existNullKey = true;
                                                    else
                                                    {
                                                        TField _field = objectToList.fieldByColumnName(attribute.referencedColumn(i));
                                                        _field.internalValue = data.GetValue(data.GetOrdinal(attribute.column(i)));
                                                        _keys.Add(_field);
                                                    }
                                                }

                                                if (!existNullKey)
                                                {
                                                    _keys.Insert(0, new TField("", this));
                                                    fieldInfo.SetValue(table, _keys);
                                                }
                                                else { }
                                            }
                                        }
                                        else { }
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                    }
                }
                else { }

                data.Close();
                data.Dispose();

                _command.Dispose();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                if (_connection != null)
                {
                    if (this.m_Transaction == null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        if (OpenedConnection > 0)
                            EntityManager.OpenedConnection--;
                    }
                    else { }
                }
                else { }
            }
        }

        internal TTableBase _find(Type returnClass, Object[] key, ref System.Collections.Generic.List<TTableBase> readTable)
        {
            TTableBase result = null;

            TTableBase objectToFind = null;

            for (int i = 0; ((objectToFind == null) && (i < readTable.Count)); i++)
                result = ((returnClass.Equals(readTable[i].GetType())) && (readTable[i].Equals(key))) ? readTable[i] : null;

            if (result == null)
            {
                objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());

                System.Data.SqlClient.SqlConnection _connection = null;

                try
                {
                    if (this.m_Transaction == null)
                    {
                        _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                        _connection.Open();
                        EntityManager.OpenedConnection++;
                    }
                    else
                        _connection = this.m_Connection;

                    String
                        sqlFields = "",
                        sqlKeys = "";

                    TColumn[] fields = objectToFind.columns(false);
                    TColumn[] keys = objectToFind.columns(true);

                    foreach (TColumn column in fields.Where(X => X.showInFindOnly))
                        sqlFields += (sqlFields.Length > 0 ? ", " : "") + column.name;

                    foreach (TColumn column in keys)
                        sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + column.name + " = @" + column.name;

                    System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                    _command.CommandText =
                    (
                        "Select\n\t" +
                            sqlFields + '\n' +
                        "From\n\t" +
                            objectToFind.tableName + '\n' + //((TTable)objectToFind.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                        "where\n\t" +
                            sqlKeys
                    );
                    _command.Transaction = this.m_Transaction;
                    _command.CommandType = System.Data.CommandType.Text;

                    for (int i = 0; i < keys.Length; i++)
                    {
                        _command.Parameters.Add("@" + keys[i].name, keys[i].type);
                        _command.Parameters["@" + keys[i].name].Direction = System.Data.ParameterDirection.Input;
                        _command.Parameters["@" + keys[i].name].Value = key[i];
                    }
                    string query = CommandAsSql(_command);

                    System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                    if (data.Read())
                    {
                        readTable.Add(objectToFind);

                        foreach
                        (
                            System.Reflection.FieldInfo fieldInfo in objectToFind.GetType().GetFields
                            (
                                System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public
                            )
                        )
                        {
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                            {
                                if (data.IsDBNull(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)))
                                    ((TField)fieldInfo.GetValue(objectToFind)).isNull = true;
                                else
                                {
                                    //if (fieldInfo.FieldType.IsInstanceOfType(typeof(TFieldBlob)))
                                    //{
                                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)));
                                    //    ((TField)fieldInfo.GetValue(objectToFind)).internalValue = System.Drawing.Image.FromStream(ms);
                                    //}
                                    //else
                                    ((TField)fieldInfo.GetValue(objectToFind)).internalValue = data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name));
                                }

                                ((TField)fieldInfo.GetValue(objectToFind)).isChanged = false;
                            }
                            else
                            {
                                if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                                {
                                    foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                    {
                                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                                        bool existNullKey = false;

                                        for (int i = 0; i < attribute.count; i++)
                                        {
                                            if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                existNullKey = true;
                                            else
                                                _keys.Add(data.GetValue(data.GetOrdinal(attribute.column(i))));
                                        }

                                        if (!existNullKey)
                                        {
                                            TTableBase _table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());

                                            if (this.m_Transaction == null)
                                                _table.connectionString = this.m_ConnectionString;
                                            else
                                                _table.entityManager = this;
                                            _table.keyFields = _keys.ToArray();

                                            fieldInfo.SetValue
                                            (
                                                objectToFind,
                                                _table
                                            );
                                        }
                                        else { }
                                    }
                                }
                                else
                                {
                                    if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                                    {
                                        if (this.m_Transaction == null)
                                        {
                                            if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                            {
                                                TTableBase objectToList = (TTableBase)System.Reflection.Assembly.GetAssembly(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value).CreateInstance(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.ToString());

                                                foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                                {
                                                    System.Collections.Generic.List<TBase> _keys = new System.Collections.Generic.List<TBase>();

                                                    bool existNullKey = false;

                                                    for (int i = 0; i < attribute.count; i++)
                                                    {
                                                        if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                            existNullKey = true;
                                                        else
                                                        {
                                                            TField _field = objectToList.fieldByColumnName(attribute.referencedColumn(i));
                                                            _field.internalValue = data.GetValue(data.GetOrdinal(attribute.column(i)));
                                                            _keys.Add(_field);
                                                        }
                                                    }

                                                    if (!existNullKey)
                                                    {
                                                        _keys.Insert(0, new TField("", this));
                                                        fieldInfo.SetValue(objectToFind, _keys);
                                                    }
                                                    else { }
                                                }
                                            }
                                            else { }
                                        }
                                        else { }
                                    }
                                    else { }
                                }
                            }
                        }
                    }
                    else { }

                    data.Close();
                    data.Dispose();

                    _command.Dispose();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                finally
                {
                    if (_connection != null)
                    {
                        if (this.m_Transaction == null)
                        {
                            _connection.Close();
                            _connection.Dispose();
                            if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                        }
                        else { }
                    }
                    else { }
                }
            }
            else { }

            result = objectToFind;

            return result;
        }

        internal void _fillFind(TTableBase target, Object[] key, ref System.Collections.Generic.List<TTableBase> readTable)
        {
            if (target != null)
            {
                TTableBase objectToFind = null;

                objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(target.GetType()).CreateInstance(target.GetType().ToString());

                System.Data.SqlClient.SqlConnection _connection = null;

                try
                {
                    if (this.m_Transaction == null)
                    {
                        _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                        _connection.Open();
                        EntityManager.OpenedConnection++;
                    }
                    else
                        _connection = this.m_Connection;

                    String
                        sqlFields = "",
                        sqlKeys = "";

                    TColumn[] fields = objectToFind.columns(false);
                    TColumn[] keys = objectToFind.columns(true);

                    foreach (TColumn column in fields)
                        sqlFields += (sqlFields.Length > 0 ? ", " : "") + column.name;

                    foreach (TColumn column in keys)
                        sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + column.name + " = @" + column.name;

                    System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                    _command.CommandText =
                    (
                        "Select\n\t" +
                            sqlFields + '\n' +
                        "From\n\t" +
                            target.tableName + '\n' + //((TTable)objectToFind.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                        "where\n\t" +
                            sqlKeys
                    );
                    _command.Transaction = this.m_Transaction;
                    _command.CommandType = System.Data.CommandType.Text;

                    for (int i = 0; i < keys.Length; i++)
                    {
                        _command.Parameters.Add("@" + keys[i].name, keys[i].type);
                        _command.Parameters["@" + keys[i].name].Direction = System.Data.ParameterDirection.Input;
                        _command.Parameters["@" + keys[i].name].Value = key[i];
                    }

                    System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                    if (data.Read())
                    {
                        readTable.Add(target);

                        foreach
                        (
                            System.Reflection.FieldInfo fieldInfo in objectToFind.GetType().GetFields
                            (
                                System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public
                            )
                        )
                        {
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                            {
                                if (data.IsDBNull(data.GetOrdinal(((TField)fieldInfo.GetValue(target)).name)))
                                    ((TField)fieldInfo.GetValue(target)).isNull = true;
                                else
                                {
                                    //if (fieldInfo.FieldType.IsInstanceOfType(typeof(TFieldBlob)))
                                    //{
                                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)));
                                    //    ((TField)fieldInfo.GetValue(objectToFind)).internalValue = System.Drawing.Image.FromStream(ms);
                                    //}
                                    //else
                                    ((TField)fieldInfo.GetValue(target)).internalValue = data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(target)).name));
                                }

                                ((TField)fieldInfo.GetValue(target)).isChanged = false;
                            }
                            else
                            {
                                if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                                {
                                    foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                    {
                                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                                        bool existNullKey = false;

                                        for (int i = 0; i < attribute.count; i++)
                                        {
                                            if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                existNullKey = true;
                                            else
                                                _keys.Add(data.GetValue(data.GetOrdinal(attribute.column(i))));
                                        }

                                        if (!existNullKey)
                                        {
                                            TTableBase _table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());

                                            if (this.m_Transaction == null)
                                                _table.connectionString = this.m_ConnectionString;
                                            else
                                                _table.entityManager = this;
                                            _table.keyFields = _keys.ToArray();

                                            fieldInfo.SetValue
                                            (
                                                target,
                                                _table
                                            );
                                        }
                                        else { }
                                    }
                                }
                                else
                                {
                                    if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                                    {
                                        if (this.m_Transaction == null)
                                        {
                                            if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                            {
                                                TTableBase objectToList = (TTableBase)System.Reflection.Assembly.GetAssembly(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value).CreateInstance(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.ToString());

                                                foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                                {
                                                    System.Collections.Generic.List<TBase> _keys = new System.Collections.Generic.List<TBase>();

                                                    bool existNullKey = false;

                                                    for (int i = 0; i < attribute.count; i++)
                                                    {
                                                        if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                            existNullKey = true;
                                                        else
                                                        {
                                                            TField _field = objectToList.fieldByColumnName(attribute.referencedColumn(i));
                                                            _field.internalValue = data.GetValue(data.GetOrdinal(attribute.column(i)));
                                                            _keys.Add(_field);
                                                        }
                                                    }

                                                    if (!existNullKey)
                                                    {
                                                        _keys.Insert(0, new TField("", this));
                                                        fieldInfo.SetValue(target, _keys);
                                                    }
                                                    else { }
                                                }
                                            }
                                            else { }
                                        }
                                        else { }
                                    }
                                    else { }
                                }
                            }
                        }
                    }
                    else { }

                    data.Close();
                    data.Dispose();

                    objectToFind = null;

                    _command.Dispose();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                finally
                {
                    if (_connection != null)
                    {
                        if (this.m_Transaction == null)
                        {
                            _connection.Close();
                            _connection.Dispose();
                            if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                        }
                        else { }
                    }
                    else { }
                }
            }
            else { }
        }

        public TTableBase find(Type returnClass, Object[] key)
        {
            TTableBase Result = null;

            System.Collections.Generic.List<TTableBase> readTable = new System.Collections.Generic.List<TTableBase>();

            Result = this._find(returnClass, key, ref readTable);

            readTable.Clear();

            return Result;
        }

        public Object list(Type returnClass, TField[] keys)
        {
            return this.list(returnClass, keys, new TField[] { });
        }

        private String verificaOrderBy(String sqlCommand, bool completo)
        {
            int orderByIndex = -1;

            String result = "";

            while ((sqlCommand.Length > 0) && (!completo || (orderByIndex = sqlCommand.ToLower().IndexOf("order by")) >= 0))
            {
                if (completo)
                {
                    result += sqlCommand.Substring(0, orderByIndex + 8);

                    sqlCommand = sqlCommand.Substring(orderByIndex + 8);
                }
                else { }

                int parenteses = 0;

                List<String> itens = new List<string>();
                List<String> _itens = new List<string>();

                String token = "";
                String _token = "";

                bool bLoop = true;

                while (bLoop && sqlCommand.Length > 0)
                {
                    switch (sqlCommand[0])
                    {
                        case '(':
                            parenteses++;
                            token += sqlCommand[0];
                            _token += sqlCommand[0];
                            break;

                        case ')':
                            parenteses--;
                            if (parenteses < 0)
                                bLoop = false;
                            else
                            {
                                token += sqlCommand[0];
                                _token += sqlCommand[0];
                            }
                            break;

                        case ',':
                            if (parenteses == 0)
                            {
                                if (!itens.Contains(token))
                                {
                                    itens.Add(token);
                                    _itens.Add(_token);
                                }
                                else
                                    _token.ToLower();

                                token = "";
                                _token = "";
                            }
                            else
                            {
                                token += sqlCommand[0];
                                _token += sqlCommand[0];
                            }

                            break;

                        default:
                            _token += sqlCommand[0];

                            if (sqlCommand[0] > ' ')
                                token += sqlCommand[0];
                            else { }
                            break;
                    }

                    if (bLoop)
                        sqlCommand = sqlCommand.Substring(1);
                    else { }
                }

                if ((token.Length > 0) && !itens.Contains(token))
                {
                    itens.Add(token);
                    _itens.Add(_token);
                }
                else
                    _token.ToLower();

                result += String.Join(", ", _itens.ToArray());
            }

            result += sqlCommand;

            return result;
        }

        public Object list(Type returnClass, String sqlCommand, TField[] keys)
        {
            Object Result = null;

            sqlCommand = verificaOrderBy(sqlCommand, true);

            System.Collections.ArrayList readTables = new System.Collections.ArrayList();

            TTableBase objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());

            System.Data.SqlClient.SqlConnection _connection = null;

            try
            {
                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);

                    _connection.Open();
                    EntityManager.OpenedConnection++;
                }
                else
                    _connection = this.m_Connection;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();
                _command.Transaction = this.m_Transaction;
                _command.CommandText = sqlCommand;

                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; ((keys != null) && (i < keys.Length)); i++)
                {
                    if (keys[i] != null)
                    {
                        String _key = keys[i].alias != null ? keys[i].alias : keys[i].name;

                        _command.Parameters.Add("@" + _key, keys[i].type);
                        _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                        _command.Parameters["@" + _key].Value = keys[i].value;
                    }
                }

                string query = CommandAsSql(_command);
                System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                if (Result == null)
                    Result = System.Activator.CreateInstance
                    (
                        typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { returnClass }
                        )
                    );
                else { }

                while (data.Read())
                {
                    if (Result == null)
                        Result = System.Activator.CreateInstance
                        (
                            typeof(System.Collections.Generic.List<>).MakeGenericType
                            (
                                new Type[] { returnClass }
                            )
                        );
                    else { }

                    foreach
                    (
                        System.Reflection.FieldInfo fieldInfo in objectToFind.GetType().GetFields
                        (
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Public
                        )
                    )
                    {
                        if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                        {
                            if (data.IsDBNull(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)))
                                ((TField)fieldInfo.GetValue(objectToFind)).isNull = true;
                            else
                            {
                                //if (fieldInfo.FieldType.IsInstanceOfType(typeof(TFieldBlob)))
                                //{
                                //    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)));
                                //    ((TField)fieldInfo.GetValue(objectToFind)).internalValue = System.Drawing.Image.FromStream(ms);
                                //}
                                //else
                                ((TField)fieldInfo.GetValue(objectToFind)).internalValue = data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name));
                            }

                            ((TField)fieldInfo.GetValue(objectToFind)).isChanged = false;
                        }
                        else
                        {
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                            {
                                foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                {
                                    System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                                    bool existNullKey = false;

                                    for (int i = 0; i < attribute.count; i++)
                                    {
                                        if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                            existNullKey = true;
                                        else
                                            _keys.Add(data.GetValue(data.GetOrdinal(attribute.column(i))));
                                    }

                                    if (!existNullKey)
                                    {
                                        TTableBase _table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());
                                        if (this.m_Transaction == null)
                                            _table.connectionString = this.m_ConnectionString;
                                        else
                                            _table.entityManager = this;
                                        _table.keyFields = _keys.ToArray();

                                        fieldInfo.SetValue
                                        (
                                            objectToFind,
                                            _table
                                        );
                                    }
                                    else { }
                                }
                            }
                            else
                            {
                                if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                                {

                                    if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                    {
                                        TTableBase objectToList = (TTableBase)System.Reflection.Assembly.GetAssembly(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value).CreateInstance(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.ToString());

                                        foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                        {
                                            System.Collections.Generic.List<TBase> _keys = new System.Collections.Generic.List<TBase>();

                                            bool existNullKey = false;

                                            for (int i = 0; i < attribute.count; i++)
                                            {
                                                if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                    existNullKey = true;
                                                else
                                                {
                                                    TField _field = objectToList.fieldByColumnName(attribute.referencedColumn(i));
                                                    _field.internalValue = data.GetValue(data.GetOrdinal(attribute.column(i)));
                                                    _keys.Add(_field);
                                                }
                                            }

                                            if (!existNullKey)
                                            {
                                                _keys.Insert(0, new TField("", this));
                                                fieldInfo.SetValue(objectToFind, _keys);
                                            }
                                            else { }
                                        }
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                    }

                    Result.GetType().GetMethod("Add").Invoke(Result, new Object[] { objectToFind });

                    objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());
                }

                data.Close();
                data.Dispose();

                _command.Dispose();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                if (_connection != null)
                {
                    if (this.m_Transaction == null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                    }
                    else { }
                }
                else { }
            }

            readTables.Clear();

            return Result;
        }

        public string ParameterValueForSQL(System.Data.SqlClient.SqlParameter sp)
        {
            string retval = "";

            switch (sp.SqlDbType)
            {

                case System.Data.SqlDbType.VarBinary:
                    {
                        if (sp.Value == DBNull.Value)
                        {
                            retval = "NULL";
                        }
                        else
                        {
                            retval = "CONVERT(VARBINARY(MAX), '" + Encoding.ASCII.GetString((byte[])sp.Value) + "')";
                        }
                        break;
                    }
                case System.Data.SqlDbType.Char:
                case System.Data.SqlDbType.NChar:
                case System.Data.SqlDbType.NText:
                case System.Data.SqlDbType.NVarChar:
                case System.Data.SqlDbType.Text:
                case System.Data.SqlDbType.Time:
                case System.Data.SqlDbType.VarChar:
                case System.Data.SqlDbType.Xml:
                case System.Data.SqlDbType.Date:
                case System.Data.SqlDbType.DateTime:
                case System.Data.SqlDbType.DateTime2:
                case System.Data.SqlDbType.DateTimeOffset:
                    if (sp.Value == DBNull.Value)
                    {
                        retval = "NULL";
                    }
                    else
                    {
                        retval = "'" + sp.Value.ToString().Replace("'", "''") + "'";
                    }
                    break;

                case System.Data.SqlDbType.Bit:
                    if (sp.Value == DBNull.Value)
                    {
                        retval = "NULL";
                    }
                    else
                    {
                        retval = ((bool)sp.Value == false) ? "0" : "1";
                    }
                    break;

                default:
                    if (sp.Value == DBNull.Value)
                    {
                        retval = "NULL";
                    }
                    else
                    {
                        retval = sp.Value.ToString().Replace("'", "''");
                    }
                    break;
            }

            return retval;
        }

        public string CommandAsSql(System.Data.SqlClient.SqlCommand sc)
        {
            string sql = sc.CommandText;

            //sql = sql.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            //sql = System.Text.RegularExpressions.Regex.Replace(sql, @"\s+", " ");

            foreach (System.Data.SqlClient.SqlParameter sp in sc.Parameters)
            {
                string spName = sp.ParameterName;

                if (sql.Contains(spName))
                {
                    string spValue = ParameterValueForSQL(sp);
                    sql = sql.Replace(spName, spValue);
                }
                else { }
            }

            sql = sql.Replace("= NULL", "IS NULL");
            sql = sql.Replace("!= NULL", "IS NOT NULL");
            return sql;
        }

        public Object list(Type returnClass, TField[] keys, TField[] orders)
        {
            Object Result = null;

            System.Collections.ArrayList readTables = new System.Collections.ArrayList();

            TTableBase objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());

            System.Data.SqlClient.SqlConnection _connection = null;

            try
            {
                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                    EntityManager.OpenedConnection++;
                }
                else
                    _connection = this.m_Connection;

                String
                    sqlFields = "",
                    sqlKeys = "",
                    sqlOrder = "";

                TColumn[] fields = objectToFind.columns(false);

                foreach (TColumn column in fields)
                    sqlFields += (sqlFields.Length > 0 ? ", " : "") + column.name;

                foreach (TField key in keys)
                    sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + key.name + " = @" + key.name;

                if (orders.Length > 0)
                {
                    foreach (TField order in orders)
                        sqlOrder += (sqlOrder.Length > 0 ? " , " : "") + order.name;
                }
                else
                {
                    foreach (TColumn order in objectToFind.columns(true))
                        sqlOrder += (sqlOrder.Length > 0 ? " , " : "") + order.name;
                }

                sqlOrder = verificaOrderBy(sqlOrder, false);

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText =
                (
                    "Select\n\t" +
                        sqlFields + '\n' +
                    "From\n\t" +
                        objectToFind.tableName + '\n' + //((TTable)objectToFind.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                    "where\n\t" +
                        sqlKeys +
                    (
                        sqlOrder.Length > 0 ?
                        "\nOrder by\n\t" + sqlOrder :
                        ""
                    )
                );
                _command.Transaction = this.m_Transaction;
                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; i < keys.Length; i++)
                {
                    String _key = keys[i].alias != null ? keys[i].alias : keys[i].name;

                    _command.Parameters.Add("@" + _key, keys[i].type);
                    _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + _key].Value = keys[i].value;
                }

                System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                while (data.Read())
                {
                    if (Result == null)
                        Result = System.Activator.CreateInstance
                        (
                            typeof(System.Collections.Generic.List<>).MakeGenericType
                            (
                                new Type[] { returnClass }
                            )
                        );
                    else { }

                    foreach
                    (
                        System.Reflection.FieldInfo fieldInfo in objectToFind.GetType().GetFields
                        (
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Public
                        )
                    )
                    {
                        if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                        {
                            if (data.IsDBNull(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)))
                                ((TField)fieldInfo.GetValue(objectToFind)).isNull = true;
                            else
                            {
                                //if (fieldInfo.FieldType.IsInstanceOfType(typeof(TFieldBlob)))
                                //{
                                //    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name)));
                                //    ((TField)fieldInfo.GetValue(objectToFind)).internalValue = System.Drawing.Image.FromStream(ms);
                                //}
                                //else
                                ((TField)fieldInfo.GetValue(objectToFind)).internalValue = data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(objectToFind)).name));
                            }

                            ((TField)fieldInfo.GetValue(objectToFind)).isChanged = false;
                        }
                        else
                        {
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                            {
                                foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                {
                                    System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                                    for (int i = 0; i < attribute.count; i++)
                                        _keys.Add(data.GetValue(data.GetOrdinal(attribute.column(i))));

                                    TTableBase _table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());
                                    if (this.m_Transaction == null)
                                        _table.connectionString = this.m_ConnectionString;
                                    else
                                        _table.entityManager = this;
                                    _table.keyFields = _keys.ToArray();

                                    fieldInfo.SetValue
                                    (
                                        objectToFind,
                                        _table
                                    );
                                }
                            }
                            else
                            {
                                if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                                {
                                    if (this.m_Transaction == null)
                                    {
                                        if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                        {
                                            TTableBase objectToList = (TTableBase)System.Reflection.Assembly.GetAssembly(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value).CreateInstance(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.ToString());

                                            foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                            {
                                                System.Collections.Generic.List<TBase> _keys = new System.Collections.Generic.List<TBase>();

                                                bool existNullKey = false;

                                                for (int i = 0; i < attribute.count; i++)
                                                {
                                                    if (data.IsDBNull(data.GetOrdinal(attribute.column(i))))
                                                        existNullKey = true;
                                                    else
                                                    {
                                                        TField _field = objectToList.fieldByColumnName(attribute.referencedColumn(i));
                                                        _field.internalValue = data.GetValue(data.GetOrdinal(attribute.column(i)));
                                                        _keys.Add(_field);
                                                    }
                                                }

                                                if (!existNullKey)
                                                {
                                                    _keys.Insert(0, new TField("", this));
                                                    fieldInfo.SetValue(objectToFind, _keys);
                                                }
                                                else { }
                                            }
                                        }
                                        else { }
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                    }

                    Result.GetType().GetMethod("Add").Invoke(Result, new Object[] { objectToFind });

                    objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());
                }

                data.Close();
                data.Dispose();

                _command.Dispose();

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                if (_connection != null)
                {
                    if (this.m_Transaction == null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                    }
                    else { }
                }
                else { }
            }

            readTables.Clear();

            return Result;
        }

        public void persist(TTableBase table)
        {
            //Utils.Utils.WriteLogPDV("Insere na tabela " + table.tableName);

            if (this.m_Transaction != null)
            {
                String
                    sqlFields = "",
                    sqlValues = "";

                System.Collections.Generic.List<TField> inputCols = new System.Collections.Generic.List<TField>();

                TColumn[] fields = table.columns(false);

                foreach (TColumn column in fields)
                {
                    TField field = table.fieldByColumnName(column.name);

                    if (field != null)
                    {
                        if (!column.identity)
                        {
                            if (column.primaryKey)
                            {
                                int i = 0;

                                for (; i < inputCols.Count; i++)
                                {
                                    if (inputCols[i].name == (field.alias != null ? field.alias : field.name))
                                        break;
                                    else { }
                                }

                                if (i == inputCols.Count)
                                {
                                    sqlFields += ((sqlFields.Length > 0) ? ", " : "") + column.name;
                                    sqlValues += ((sqlValues.Length > 0) ? ", " : "") + "@" + column.name;

                                    inputCols.Add(field);
                                }
                                else { }
                            }
                            else
                            {
                                if (!field.isNull)
                                {
                                    int i = 0;

                                    for (; i < inputCols.Count; i++)
                                    {
                                        if (inputCols[i].name == (field.alias != null ? field.alias : field.name))
                                            break;
                                        else { }
                                    }

                                    if (i == inputCols.Count)
                                    {
                                        sqlFields += ((sqlFields.Length > 0) ? ", " : "") + column.name;
                                        sqlValues += ((sqlValues.Length > 0) ? ", " : "") + "@" + column.name;

                                        inputCols.Add(field);
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                        else { }
                    }
                    else { }
                }

                if (sqlFields.Length > 0)
                {
                    System.Data.SqlClient.SqlCommand _command = this.m_Connection.CreateCommand();

                    _command.CommandText =
                    (
                        "Insert Into\n\t" +
                            table.tableName + '\n' + //((TTable)table.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                        "(\n\t" +
                            sqlFields + '\n' +
                        ")\n" +
                        "Values\n" +
                        "(\n\t" +
                            sqlValues + '\n' +
                        ")\n"
                    );

                    _command.Transaction = this.m_Transaction;
                    _command.CommandType = System.Data.CommandType.Text;

                    foreach (TField key in inputCols)
                    {
                        System.IO.MemoryStream msImage = null;

                        if (key.type == System.Data.SqlDbType.Image)
                        {
                            msImage = new System.IO.MemoryStream();

                            ((System.Drawing.Image)key.value).Save(msImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else { }

                        String _key = key.alias != null ? key.alias : key.name;

                        _command.Parameters.Add("@" + _key, key.type);
                        _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                        _command.Parameters["@" + _key].Value = ((key.type == System.Data.SqlDbType.Image) ? msImage.ToArray() : key.value);

                        if (msImage != null)
                            msImage.Dispose();
                        else { }
                    }

                    String _commandDebug = _command.CommandText;
                    string query = SqlCommandDumper.GetCommandText(_command);
                    table.sqlRetorno = query;
                    _command.ExecuteNonQuery();

                    _command.Dispose();
                }
                else { }

                foreach (TColumn column in fields)
                {
                    if (column.identity)
                    {
                        System.Data.SqlClient.SqlCommand _command = this.m_Connection.CreateCommand();
                        _command.Transaction = this.m_Transaction;
                        _command.CommandText =
                        (
                            "Select cast(IDENT_CURRENT(\'" + table.tableName /*((TTable)table.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value */ + "\') as integer) as " + column.name
                        );

                        System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                        if (data.Read())
                        {
                            TField _field = table.fieldByColumnName(column.name);
                            _field.internalValue = data.GetValue(data.GetOrdinal(column.name));
                            _field.isChanged = false;
                            _field = null;
                        }
                        else { }

                        data.Close();
                        data.Dispose();

                        _command.Dispose();
                    }
                    else { }
                }
            }
            else { }
        }

        public void merge(TTableBase table)
        {
            //Utils.Utils.WriteLogPDV("Update da tabela " + table.tableName);

            if (this.m_Transaction != null)
            {
                String
                    sqlFields = "",
                    sqlKeys = "";

                System.Collections.Generic.List<TField> inputCols = new System.Collections.Generic.List<TField>();

                TColumn[] fields = table.columns(false).Where(X => X.showInFindOnly).ToArray();

                foreach (TColumn column in fields)
                {
                    TField field = table.fieldByColumnName(column.name);

                    if (field != null)
                    {
                        if (column.primaryKey)
                        {
                            int i = 0;

                            for (; i < inputCols.Count; i++)
                            {
                                if (inputCols[i].name == (field.alias != null ? field.alias : field.name))
                                    break;
                                else { }
                            }

                            if (i == inputCols.Count)
                            {
                                sqlKeys += ((sqlKeys.Length > 0) ? " and " : "") + column.name + " = @" + column.name;

                                inputCols.Add(field);
                            }
                            else { }
                        }
                        else
                        {
                            if (field.isChanged)
                            {
                                int i = 0;

                                for (; i < inputCols.Count; i++)
                                {
                                    if (inputCols[i].alias == (field.alias != null ? field.alias : field.name))
                                        break;
                                    else { }
                                }

                                if (i == inputCols.Count)
                                {
                                    if (field.isNull)
                                        if (!field.isNew)
                                            sqlFields += ((sqlFields.Length > 0) ? ", " : "") + column.name + " = null";
                                        else { }
                                    else
                                    {
                                        sqlFields += ((sqlFields.Length > 0) ? ", " : "") + column.name + " = @" + column.name;
                                        inputCols.Add(field);
                                    }
                                }
                                else { }
                            }
                            else { }
                        }
                    }
                    else { }
                }

                if (sqlFields.Length > 0)
                {
                    System.Data.SqlClient.SqlCommand _command = this.m_Connection.CreateCommand();

                    _command.CommandText =
                    (
                        "Update\n\t" +
                            table.tableName + '\n' + //((TTable)table.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                        "Set\n\t" +
                            sqlFields + '\n' +
                        "Where\n\t" +
                            sqlKeys
                    );
                    _command.Transaction = this.m_Transaction;
                    _command.CommandType = System.Data.CommandType.Text;

                    foreach (TField key in inputCols)
                    {
                        System.IO.MemoryStream msImage = null;

                        if (key.type == System.Data.SqlDbType.Image)
                        {
                            msImage = new System.IO.MemoryStream();

                            ((System.Drawing.Image)key.value).Save(msImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else { }

                        String _key = key.alias != null ? key.alias : key.name;

                        _command.Parameters.Add("@" + _key, key.type);
                        _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                        _command.Parameters["@" + _key].Value =
                            (
                                (key.type == System.Data.SqlDbType.Image) ? msImage.ToArray() : key.value
                            );

                        if (msImage != null)
                            msImage.Dispose();
                        else { }
                    }

                    string query = SqlCommandDumper.GetCommandText(_command);
                    table.sqlRetorno = query;
                    _command.ExecuteNonQuery();

                    _command.Dispose();
                }
                else { }
            }
            else { }
        }

        public void remove(TTableBase table)
        {
            //Utils.Utils.WriteLogPDV("Delete da tabela " + table.tableName);

            if (this.m_Transaction != null)
            {
                String
                    sqlKeys = "";

                TColumn[] keys = table.columns(true);

                foreach (TColumn column in keys)
                    sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + column.name + " = @" + column.name;

                System.Data.SqlClient.SqlCommand _command = this.m_Connection.CreateCommand();

                _command.CommandText =
                (
                    "Delete From\n\t" +
                        table.tableName + '\n' + //((TTable)table.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value + '\n' +
                    "Where\n\t" +
                        sqlKeys
                );
                _command.Transaction = this.m_Transaction;
                _command.CommandType = System.Data.CommandType.Text;

                foreach (TColumn column in keys)
                {
                    _command.Parameters.Add("@" + column.name, column.type);
                    _command.Parameters["@" + column.name].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + column.name].Value = table.fieldByColumnName(column.name).value;
                }

                _command.ExecuteNonQuery();

                _command.Dispose();
            }
            else { }
        }

        public int execute(String sqlCommand, TField[] keys)
        {
            int result = 0;

            System.Data.SqlClient.SqlConnection _connection = null;

            try
            {
                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                    EntityManager.OpenedConnection++;
                }
                else
                    _connection = this.m_Connection;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText = sqlCommand;
                _command.Transaction = this.m_Transaction;
                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; ((keys != null) && (i < keys.Length)); i++)
                {
                    String _key = keys[i].alias != null ? keys[i].alias : keys[i].name;

                    _command.Parameters.Add("@" + _key, keys[i].type);
                    _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + _key].Value = keys[i].value;
                }

                result = _command.ExecuteNonQuery();

                _command.Dispose();

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                if (_connection != null)
                {
                    if (this.m_Transaction == null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                    }
                    else { }
                }
                else { }
            }

            return result;
        }

        public System.Data.DataTable executeData(String sqlCommand, TField[] keys, bool catchException = false)
        {
            System.Data.DataTable Result = null;

            System.Data.SqlClient.SqlConnection _connection = null;

            try
            {
                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                    EntityManager.OpenedConnection++;
                }
                else
                    _connection = this.m_Connection;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText = sqlCommand;
                _command.Transaction = this.m_Transaction;
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandTimeout = 0;

                for (int i = 0; ((keys != null) && (i < keys.Length)); i++)
                {
                    String _key = keys[i].alias != null ? keys[i].alias : keys[i].name;

                    _command.Parameters.Add("@" + _key, keys[i].type);
                    _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + _key].Value = keys[i].value;
                }

                string query = CommandAsSql(_command);
                System.Data.SqlClient.SqlDataReader _data = _command.ExecuteReader();

                if (_data != null)
                {
                    Result = new System.Data.DataTable();
                    Result.Load(_data);
                }
                else { }

                _command.Dispose();
            }
            catch (Exception e)
            {
                if (catchException)
                    throw e;
                else { }
            }
            finally
            {
                if (_connection != null)
                {
                    if (this.m_Transaction == null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                    }
                    else { }
                }
                else { }
            }

            return Result;
        }

        public object executeScalar(String sqlCommand, TField[] keys)
        {
            Object Result = null;

            System.Data.SqlClient.SqlConnection _connection = null;

            try
            {
                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                    if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection++;
                }
                else
                    _connection = this.m_Connection;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText = sqlCommand;
                _command.Transaction = this.m_Transaction;

                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; ((keys != null) && (i < keys.Length)); i++)
                {
                    String _key = keys[i].alias != null ? keys[i].alias : keys[i].name;

                    _command.Parameters.Add("@" + _key, keys[i].type);
                    _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + _key].Value = keys[i].value;
                }

                Result = _command.ExecuteScalar();

                _command.Dispose();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                if (_connection != null)
                {
                    if (this.m_Transaction == null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        if (EntityManager.OpenedConnection > 0) EntityManager.OpenedConnection--;
                    }
                    else { }
                }
                else { }
            }

            return Result;
        }
    }
}
/*
        internal String[] MakeSelectCommand(Type returnClass, int level, ref int tableIndex, string joinFields = null)
        {
            String[] result = {"", ""};

            if (level < 6)
            {
                int curTableIndex = tableIndex;
                tableIndex++;

                TTableBase objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());

                String[] parentLevelAndKeys = (joinFields ?? (returnClass.Name + curTableIndex.ToString())).Split(',');

                foreach
                (
                    System.Reflection.FieldInfo fieldInfo in objectToFind.GetType().GetFields
                    (
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Public
                    )
                )
                {
                    if
                    (
                        !(
                            (returnClass.Name == "EmpresaRelacionamento") &&
                            (fieldInfo.Name == "m_idPessoaRelacionamento")
                        )
                    )
                    {
                        if (!((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0)))
                        {
                            String columnName = "";

                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                                columnName = ((TField)fieldInfo.GetValue(objectToFind)).name;
                            else
                                columnName = ((TColumn)fieldInfo.GetCustomAttributes(typeof(TColumn), false)[0]).name;

                            result[0] += (result[0].Length > 0 ? ",\n" : "") + "\t" + parentLevelAndKeys[0] + '.' + columnName + " as " + columnName + curTableIndex.ToString();

                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                            {
                                String joinKeys = "";

                                foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                {
                                    for (int i = 0; i < attribute.count; i++)
                                        joinKeys += (joinKeys.Length > 0 ? "," : "") + attribute.column(i) + "," + attribute.referencedColumn(i);
                                }

                                String[] _result = MakeSelectCommand(fieldInfo.FieldType, level + 1, ref tableIndex, columnName + curTableIndex.ToString() + "," + parentLevelAndKeys[0] + "," + joinKeys.ToString());

                                if (_result[0].Length > 0)
                                    result[0] += (result[0].Length > 0 ? ",\n" : "") + _result[0];
                                else { }

                                if (_result[1].Length > 0)
                                    result[1] += (result[1].Length > 0 ? "\n" : "") + _result[1];
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }
                }

                if (curTableIndex > 0)
                {
                    String _join = "\t\tleft join " + objectToFind.tableName + " " + parentLevelAndKeys[0] + "\n\t\t\ton";

                    for (int i = 0; i < parentLevelAndKeys.Length - 2; i += 2)
                        _join += (i > 0 ? " and\n\t\t\t\t" : "\t") + parentLevelAndKeys[0] + "." + parentLevelAndKeys[2 + (i * 2) + 1] + " = " + parentLevelAndKeys[1] + "." + parentLevelAndKeys[2 + (i * 2) + 0];

                    result[1] = (_join + (result[1].Length > 0 ? "\n" : "") + result[1]);
                }
                else { }
            }
            else { }

            return result;
        }

        internal void FillFields(TTableBase table, System.Data.SqlClient.SqlDataReader data, ref int level)
        {
            int curLevel = level;

            level++;

            foreach
            (
                System.Reflection.FieldInfo fieldInfo in table.GetType().GetFields
                (
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Public
                )
            )
            {
                if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                {
                    if (data.IsDBNull(data.GetOrdinal(((TField)fieldInfo.GetValue(table)).name + curLevel.ToString())))
                        ((TField)fieldInfo.GetValue(table)).isNull = true;
                    else
                        ((TField)fieldInfo.GetValue(table)).internalValue = data.GetValue(data.GetOrdinal(((TField)fieldInfo.GetValue(table)).name + curLevel.ToString()));

                    ((TField)fieldInfo.GetValue(table)).isChanged = false;
                }
                else
                {
                    if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                    {
                        TTableBase _table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());

                        this.FillFields(_table, data, ref level);

                        fieldInfo.SetValue
                        (
                            table,
                            _table
                        );
                    }
                    else
                    {
                        if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                        {
                            if (this.m_Transaction == null)
                            {
                                if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                {
                                    TTableBase objectToList = (TTableBase)System.Reflection.Assembly.GetAssembly(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value).CreateInstance(((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.ToString());

                                    foreach (TJoin attribute in fieldInfo.GetCustomAttributes(typeof(TJoin), false))
                                    {
                                        System.Collections.Generic.List<TBase> _keys = new System.Collections.Generic.List<TBase>();

                                        bool existNullKey = false;

                                        for (int i = 0; i < attribute.count; i++)
                                        {
                                            if (data.IsDBNull(data.GetOrdinal(attribute.column(i) + curLevel.ToString())))
                                                existNullKey = true;
                                            else
                                            {
                                                TField _field = objectToList.fieldByColumnName(attribute.referencedColumn(i));
                                                _field.internalValue = data.GetValue(data.GetOrdinal(attribute.column(i) + curLevel.ToString()));
                                                _keys.Add(_field);
                                            }
                                        }

                                        if (!existNullKey)
                                        {
                                            _keys.Insert(0, new EJB.TableBase.TFieldString(this.m_ConnectionString, ""));
                                            fieldInfo.SetValue(table, _keys);
                                        }
                                        else { }
                                    }
                                }
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                }
            }
        }

        internal void _find(TTableBase table, Object[] key)
        {
            System.Data.SqlClient.SqlConnection _connection = null;

            if (this.m_Transaction == null)
            {
                _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                _connection.Open();
            }
            else
                _connection = this.m_Connection;

            String
                sqlKeys = "";

            TColumn[] keys = table.columns(true);

            int level = 0;
            String[] sqlFieldsAndJoin = this.MakeSelectCommand(table.GetType(), 0, ref level);

            foreach (TColumn column in keys)
                sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + table.tableName + "0." + column.name + " = @" + column.name;

            System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

            _command.CommandText =
            (
                "Select\n" +
                    sqlFieldsAndJoin[0] + '\n' +
                "From\n\t" +
                    table.tableName + " " + table.tableName + "0\n" +
                    (sqlFieldsAndJoin[1].Length > 0? (sqlFieldsAndJoin[1] + "\n") : "") +
                "where\n\t" +
                    sqlKeys
            );
            _command.Transaction = this.m_Transaction;
            _command.CommandType = System.Data.CommandType.Text;

            for (int i = 0; i < keys.Length; i++)
            {
                _command.Parameters.Add("@" + keys[i].name, keys[i].type);
                _command.Parameters["@" + keys[i].name].Direction = System.Data.ParameterDirection.Input;
                _command.Parameters["@" + keys[i].name].Value = key[i];
            }

            System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();
            level = 0;

            while (data.Read())
                this.FillFields(table, data, ref level);

            data.Close();
            data.Dispose();

            _command.Dispose();

            if (this.m_Transaction == null)
            {
                _connection.Close();
                _connection.Dispose();
            }
            else { }
        }

        internal TTableBase _find(Type returnClass, Object[] key, ref System.Collections.Generic.List<TTableBase> readTable)
        {
            TTableBase result = null;

            TTableBase objectToFind = null;

            for (int i = 0; ((objectToFind == null) && (i < readTable.Count)); i++)
                result = ((returnClass.Equals(readTable[i].GetType())) && (readTable[i].Equals(key))) ? readTable[i] : null;

            if (result == null)
            {
                objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());

                System.Data.SqlClient.SqlConnection _connection = null;

                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                }
                else
                    _connection = this.m_Connection;

                String
                    sqlKeys = "";

                TColumn[] keys = objectToFind.columns(true);

                int level = 0;
                String[] sqlFieldsAndJoin = this.MakeSelectCommand(returnClass, 0, ref level);

                foreach (TColumn column in keys)
                    sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + objectToFind.tableName + "0." + column.name + " = @" + column.name;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText =
                (
                    "Select\n" +
                        sqlFieldsAndJoin[0] + '\n' +
                    "From\n\t" +
                        objectToFind.tableName + " " + objectToFind.tableName + "0\n" +
                        (sqlFieldsAndJoin[1].Length > 0 ? (sqlFieldsAndJoin[1] + "\n") : "") +
                    "where\n\t" +
                        sqlKeys
                );
                _command.Transaction = this.m_Transaction; 
                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; i < keys.Length; i++)
                {
                    _command.Parameters.Add("@" + keys[i].name, keys[i].type);
                    _command.Parameters["@" + keys[i].name].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + keys[i].name].Value = key[i];
                }

                System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();
                level = 0;

                while (data.Read())
                    this.FillFields(objectToFind, data, ref level);

                data.Close();
                data.Dispose();

                _command.Dispose();

                if (this.m_Transaction == null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                else { }
            }
            else { }

            result = objectToFind;

            return result;
        }

        internal void _fillFind(TTableBase target, Object[] key, ref System.Collections.Generic.List<TTableBase> readTable)
        {
            if (target != null)
            {
                TTableBase objectToFind = null;

                objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(target.GetType()).CreateInstance(target.GetType().ToString());

                System.Data.SqlClient.SqlConnection _connection = null;

                if (this.m_Transaction == null)
                {
                    _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                    _connection.Open();
                }
                else
                    _connection = this.m_Connection;

                String
                    sqlKeys = "";

                TColumn[] keys = objectToFind.columns(true);

                int level = 0;
                String[] sqlFieldsAndJoin = this.MakeSelectCommand(target.GetType(), 0, ref level);

                foreach (TColumn column in keys)
                    sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + target.tableName + "0." + column.name + " = @" + column.name;

                System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

                _command.CommandText =
                (
                    "Select\n" +
                        sqlFieldsAndJoin[0] + '\n' +
                    "From\n\t" +
                        target.tableName + " " + target.tableName + "0\n" +
                        (sqlFieldsAndJoin[1].Length > 0 ? (sqlFieldsAndJoin[1] + "\n") : "") +
                    "where\n\t" +
                        sqlKeys
                );
                _command.Transaction = this.m_Transaction;
                _command.CommandType = System.Data.CommandType.Text;

                for (int i = 0; i < keys.Length; i++)
                {
                    _command.Parameters.Add("@" + keys[i].name, keys[i].type);
                    _command.Parameters["@" + keys[i].name].Direction = System.Data.ParameterDirection.Input;
                    _command.Parameters["@" + keys[i].name].Value = key[i];
                }

                System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();

                level = 0;

                while (data.Read())
                    this.FillFields(objectToFind, data, ref level);

                data.Close();
                data.Dispose();

                objectToFind = null;

                _command.Dispose();

                if (this.m_Transaction == null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                else { }
            }
            else { }
        }

        public Object list(Type returnClass, TField[] keys, TField[] orders)
        {
            Object Result = null;

            System.Collections.ArrayList readTables = new System.Collections.ArrayList();

            TTableBase objectToFind = (TTableBase)System.Reflection.Assembly.GetAssembly(returnClass).CreateInstance(returnClass.ToString());

            System.Data.SqlClient.SqlConnection _connection = null;

            if (this.m_Transaction == null)
            {
                _connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
                _connection.Open();
            }
            else
                _connection = this.m_Connection;

            String
                sqlKeys = "",
                sqlOrder = "";

            foreach (TField key in keys)
                sqlKeys += (sqlKeys.Length > 0 ? " and " : "") + objectToFind.tableName + "0." + key.name + " = @" + key.name;

            if (orders.Length > 0)
            {
                foreach (TField order in orders)
                    sqlOrder += (sqlOrder.Length > 0 ? " , " : "") + objectToFind.tableName + "0." + order.name;
            }
            else
            {
                foreach (TColumn order in objectToFind.columns(true))
                    sqlOrder += (sqlOrder.Length > 0 ? " , " : "") + objectToFind.tableName + "0." + order.name;
            }

            System.Data.SqlClient.SqlCommand _command = _connection.CreateCommand();

            int level = 0;
            String[] sqlFieldsAndJoin = this.MakeSelectCommand(objectToFind.GetType(), 0, ref level);

            _command.CommandText =
            (
                "Select\n" +
                    sqlFieldsAndJoin[0] + '\n' +
                "From\n\t" +
                    objectToFind.tableName + " " + objectToFind.tableName + "0\n" +
                    (sqlFieldsAndJoin[1].Length > 0 ? (sqlFieldsAndJoin[1] + "\n") : "") +
                "where\n\t" +
                    sqlKeys +
                (
                    sqlOrder.Length > 0 ?
                    "\nOrder by\n\t" + sqlOrder :
                    ""
                )
            );
            _command.Transaction = this.m_Transaction;
            _command.CommandType = System.Data.CommandType.Text;

            for (int i = 0; i < keys.Length; i++)
            {
                String _key = keys[i].alias != null ? keys[i].alias : keys[i].name;

                _command.Parameters.Add("@" + _key, keys[i].type);
                _command.Parameters["@" + _key].Direction = System.Data.ParameterDirection.Input;
                _command.Parameters["@" + _key].Value = keys[i].value;
            }

            System.Data.SqlClient.SqlDataReader data = _command.ExecuteReader();
            level = 0;

            while (data.Read())
                this.FillFields(objectToFind, data, ref level);

            data.Close();
            data.Dispose();

            _command.Dispose();

            if (this.m_Transaction == null)
            {
                _connection.Close();
                _connection.Dispose();
            }
            else { }

            readTables.Clear();

            return Result;
        }
*/
