using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJB.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class TColumn : System.Attribute
    {
        private String m_Name;
        private System.Data.SqlDbType m_Type;
        private bool m_PrimaryKey;
        private bool m_Identity;
        private bool m_ShowInFindOnly;

        public TColumn(String name, System.Data.SqlDbType type)
        {
            this.m_Name = name;
            this.m_Type = type;
            this.m_PrimaryKey = false;
            this.m_Identity = false;
            this.m_ShowInFindOnly = true;
        }

        public TColumn(String name, System.Data.SqlDbType type, bool primaryKey, bool identity, bool showInFindOnly = true)
        {
            this.m_Name = name;
            this.m_Type = type;
            this.m_PrimaryKey = primaryKey;
            this.m_Identity = identity;
            this.m_ShowInFindOnly = showInFindOnly;
        }

        public String name
        {
            get { return this.m_Name; }
        }

        public System.Data.SqlDbType type
        {
            get { return this.m_Type; }
        }

        public bool primaryKey
        {
            get { return this.m_PrimaryKey; }
        }

        public bool identity
        {
            get { return this.m_Identity; }
        }

        public bool showInFindOnly
        {
            get { return this.m_ShowInFindOnly; }
        }
    }
}
