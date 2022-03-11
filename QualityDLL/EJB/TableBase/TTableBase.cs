using System;
using System.Collections.Generic;
using System.Text;
using EJB.Attributes;
using System.Linq;

namespace EJB.TableBase
{
    public class TTableBase : TBase
    {
        private String m_tableName = "";
        private String m_ConnectionString = "";
        private EJB.EntityManager.EntityManager m_entityManager = null;
        public string sqlRetorno = "";

        private Object[] m_KeyFields = null;

        public String tableName
        {
            get { return this.m_tableName; }
            set { this.m_tableName = value; }
        }

        internal String connectionString
        {
            get { return this.m_ConnectionString; }
            set { this.m_ConnectionString = value; }
        }

        internal Object[] keyFields
        {
            get { return this.m_KeyFields; }
            set { this.m_KeyFields = value; }
        }

        internal EJB.EntityManager.EntityManager entityManager
        {
            get { return this.m_entityManager; }
            set { this.m_entityManager = value; }
        }

        internal void selfFill()
        {
            if
            (
                (
                    (this.m_ConnectionString.Length > 0) ||
                    (this.m_entityManager != null)
                ) &&
                (
                    (this.m_KeyFields != null) &&
                    (this.m_KeyFields.Length > 0)
                )
            )
            {
                if (this.m_entityManager == null)
                    this.m_entityManager = Utils.Utils.em;
                else { }

                System.Collections.Generic.List<TTableBase> readTable = new System.Collections.Generic.List<TTableBase>();
                TTableBase _table = null;

                //if(this.m_entityManager.inTransacionMode)
                //    this.m_entityManager._fillFind(this, this.m_KeyFields, ref readTable);
                //else
                _table = this.m_entityManager._find(this.GetType(), this.m_KeyFields, ref readTable);

                readTable.Clear();

                //if (!this.m_entityManager.inTransacionMode)
                //{
                if (_table != null)
                {
                    foreach
                    (
                        System.Reflection.FieldInfo fieldInfo in this.GetType().GetFields
                        (
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Public
                        )
                    )
                    {
                        if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                            ((TField)fieldInfo.GetValue(this)).internalValue = ((TField)fieldInfo.GetValue(_table)).value;
                        else
                        {
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                            {
                                if (((TTableBase)fieldInfo.GetValue(_table)) != null)
                                {
                                    TTableBase __table = (TTableBase)System.Reflection.Assembly.GetAssembly(fieldInfo.FieldType).CreateInstance(fieldInfo.FieldType.ToString());
                                    if (this.m_entityManager.inTransacionMode)
                                        __table.m_entityManager = this.entityManager;
                                    else
                                        __table.connectionString = ((TTableBase)fieldInfo.GetValue(_table)).m_ConnectionString;

                                    __table.keyFields = ((TTableBase)fieldInfo.GetValue(_table)).m_KeyFields;
                                    fieldInfo.SetValue
                                    (
                                        this,
                                        __table
                                    );
                                }
                                else { }
                            }
                            else
                            {
                                if ((fieldInfo.GetValue(_table) != null) && (fieldInfo.GetValue(_table).GetType().IsGenericType))
                                    if ((fieldInfo.GetCustomAttributes(typeof(TList), false) != null) && (fieldInfo.GetCustomAttributes(typeof(TList), false).Length > 0))
                                        if (((TList)fieldInfo.GetCustomAttributes(typeof(TList), false)[0]).value.IsSubclassOf(typeof(TTableBase)))
                                        {
                                            fieldInfo.SetValue(this, fieldInfo.GetValue(_table));
                                            //Object _tableList = fieldInfo.GetValue(_table);

                                            //fieldInfo.GetValue(this).GetType().GetMethod("AddRange").Invoke
                                            //(
                                            //    fieldInfo.GetValue(this),
                                            //    new Object[] { _tableList }
                                            //);
                                        }
                                        else { }
                                    else { }
                                else { }
                            }
                        }
                    }
                }
                else { }

                this.m_ConnectionString = "";
                this.m_KeyFields = null;
                this.m_entityManager = null;
                //}
                //else { }
            }
            else { }
        }

        protected TTableBase() : base()
        {
            this.m_tableName = ((TTable)this.GetType().GetCustomAttributes(typeof(TTable), false)[0]).value;

            foreach
            (
                System.Reflection.FieldInfo fieldInfo in this.GetType().GetFields
                (
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Public
                )
            )
            {
                foreach
                (
                    Object attribute in fieldInfo.GetCustomAttributes(false)
                )
                {
                    if (attribute is TColumn)
                    {
                        if
                        (
                            fieldInfo.FieldType.IsSubclassOf(typeof(TField))
                        )
                        {
                            ((TField)fieldInfo.GetValue(this)).name = ((TColumn)attribute).name;
                            ((TField)fieldInfo.GetValue(this)).type = ((TColumn)attribute).type;
                            ((TField)fieldInfo.GetValue(this)).identity = ((TColumn)attribute).identity;
                            ((TField)fieldInfo.GetValue(this)).primaryKey = ((TColumn)attribute).primaryKey;
                            ((TField)fieldInfo.GetValue(this)).showInFindOnly = ((TColumn)attribute).showInFindOnly;
                            ((TField)fieldInfo.GetValue(this)).setTableBase(this);
                        }
                        else { }
                    }
                    else { }
                }
            }
        }

        public TColumn[] columns(bool onlyPrimaryKey)
        {
            System.Collections.Generic.List<TColumn> result = new System.Collections.Generic.List<TColumn>();

            foreach
            (
                System.Reflection.FieldInfo fieldInfo in this.GetType().GetFields
                (
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Public
                )
            )
            {
                String fieldName = "";

                if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                {
                    fieldName = ((TField)fieldInfo.GetValue(this)).name; //Table.ColumnName

                    if (!onlyPrimaryKey || (onlyPrimaryKey && ((TField)fieldInfo.GetValue(this)).primaryKey))
                    {
                        int i = 0;

                        for (; i < result.Count; i++)
                        {
                            if (result[i].name == fieldName)
                                break;
                            else { }
                        }

                        if (i == result.Count)
                            result.Add
                            (
                                new TColumn
                                (
                                    fieldName,
                                    ((TField)fieldInfo.GetValue(this)).type,
                                    ((TField)fieldInfo.GetValue(this)).primaryKey,
                                    ((TField)fieldInfo.GetValue(this)).identity,
                                    ((TField)fieldInfo.GetValue(this)).showInFindOnly
                                )
                            );
                        else { }
                    }
                    else { }
                }
                else
                {
                    if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                    {
                        foreach (Object attribute in fieldInfo.GetCustomAttributes(typeof(TColumn), false))
                        {
                            fieldName = ((TColumn)attribute).name;

                            if (!onlyPrimaryKey || (onlyPrimaryKey && ((TColumn)attribute).primaryKey))
                            {
                                int i = 0;

                                for (; i < result.Count; i++)
                                {
                                    if (result[i].name == fieldName)
                                        break;
                                    else { }
                                }

                                if (i == result.Count)
                                    result.Add((TColumn)attribute);
                                else { }
                            }
                            else { }
                        }
                    }
                    else { }
                }
            }

            return result.ToArray();
        }

        public Boolean Equals(TTableBase anotherTable)
        {
            Boolean result = false;

            TColumn[] keys = this.columns(true);

            for (int i = 0; ((keys != null) && (i < keys.Length)); i++)
                result =
                (
                    result &&
                    (
                        this.fieldByColumnName(keys[i].name).value == anotherTable.fieldByColumnName(keys[i].name).value
                    )
                );

            return result;
        }

        public Boolean Equals(Object[] key)
        {
            Boolean result = false;

            TColumn[] keys = this.columns(true);

            for (int i = 0; ((keys != null) && (i < keys.Length)); i++)
                result =
                (
                    result &&
                    (
                        this.fieldByColumnName(keys[i].name).value == key[i]
                    )
                );

            return result;
        }

        public TField fieldByColumnName(String columnName)
        {
            TField
                result = null;

            foreach
            (
                System.Reflection.FieldInfo fieldInfo in this.GetType().GetFields
                (
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Public
                )
            )
            {
                if (fieldInfo.FieldType.IsSubclassOf(typeof(TField)))
                {
                    if (((TField)fieldInfo.GetValue(this)).name == columnName)
                        result = ((TField)fieldInfo.GetValue(this));
                    else { }
                }
                else
                {
                    if (fieldInfo.FieldType.IsSubclassOf(typeof(TTableBase)))
                    {
                        foreach (Object attribute in fieldInfo.GetCustomAttributes(typeof(TColumn), false))
                        {
                            TJoin _join = ((TJoin[])fieldInfo.GetCustomAttributes(typeof(TJoin), false))[0];

                            for (int i = 0; i < _join.count; i++)
                            {
                                if (_join.column(i) == columnName)
                                {
                                    if (fieldInfo.GetValue(this) == null)
                                        result = new TField();
                                    else
                                        result = ((TTableBase)fieldInfo.GetValue(this)).fieldByColumnName(_join.referencedColumn(i));

                                    if ((result != null))
                                    {
                                        if ((result.name == null) || ((result.name != null) && (result.name.Length == 0)))
                                            result.name = _join.column(i);
                                        else
                                            result.alias = _join.column(i);
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                    }
                    else { }
                }

                if (result != null)
                    break;
                else { }
            }

            return result;
        }
    }
}
