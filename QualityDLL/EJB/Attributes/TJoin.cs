using System;
using System.Collections.Generic;
using System.Text;

namespace EJB.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class TJoin : System.Attribute
    {
        private readonly String[] m_JoinColumns;

        public TJoin(String[] joinColumns)
        {
            this.m_JoinColumns = joinColumns;
        }

        public int count
        {
            get { return (this.m_JoinColumns != null ? this.m_JoinColumns.Length : 0); }
        }

        public String column(int index)
        {
            return
            (
                this.m_JoinColumns != null ?
                    ((index >= 0) && (index < this.m_JoinColumns.Length)) ?
                        this.m_JoinColumns[index].IndexOf("->") > (-1) ?
                            this.m_JoinColumns[index].Substring(0, this.m_JoinColumns[index].IndexOf("->")) :
                            this.m_JoinColumns[index] :
                        "" :
                    ""
            );
        }

        public String referencedColumn(String columnName)
        {
            String result = null;

            for (int i = 0; ((result == null) && (this.m_JoinColumns != null) && (this.m_JoinColumns.Length > 0)); i++)
            {
                if (this.column(i) == columnName)
                    result = this.referencedColumn(i);
                else { }
            }

            return result;
        }

        public String referencedColumn(int index)
        {
            return
            (
                this.m_JoinColumns != null ?
                    ((index >= 0) && (index < this.m_JoinColumns.Length)) ?
                        this.m_JoinColumns[index].IndexOf("->") > (-1) ?
                            this.m_JoinColumns[index].Substring(this.m_JoinColumns[index].IndexOf("->") + 2) :
                            this.m_JoinColumns[index] :
                        "" :
                    ""
            );
        }
    }
}
