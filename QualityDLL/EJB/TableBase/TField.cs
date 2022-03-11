using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJB.TableBase
{
    public class TField : TBase
    {
        private String m_Name;
        private System.Data.SqlDbType m_Type;
        private Boolean m_PrimaryKey;
        private Boolean m_Identity;
        private Object m_Value;
        private Boolean m_Changed;
        private Boolean m_Null;
        private Boolean m_New;
        private TTableBase m_TableBase;
        private String m_Alias;
        private Boolean m_ShowInFindOnly;

        internal virtual Object internalValue
        {
            set
            {
                this.m_Value = value;
                this.m_Changed = false;
                this.m_Null = (this.m_Value == null);
                this.m_New = false;
            }
        }

        public virtual Object value
        {
            get
            {
                if (this.m_TableBase != null)
                    this.m_TableBase.selfFill();
                else { }

                return this.m_Value;
            }
            set
            {
                if (this.m_TableBase != null)
                    this.m_TableBase.selfFill();
                else { }

                if
                (
                    this.m_New ||
                    (
                        (
                            (
                                ((this.m_Value == null) && (value != null)) ||
                                ((this.m_Value != null) && (value == null))
                            ) ?
                            true :
                            (
                                ((this.m_Value == null) && (value == null)) ?
                                false :
                                (!this.m_Value.Equals(value))
                            )
                        )
                    )
                )
                {
                    this.m_Value = value;
                    this.m_Changed = true;
                    this.m_Null = (this.m_Value == null);
                    this.m_New = false;
                }
                else { }
            }
        }

        internal Boolean isChanged
        {
            get { return this.m_Changed; }
            set { this.m_Changed = value; }
        }

        internal Boolean isNew
        {
            get { return this.m_New; }
            set { this.m_New = value; }
        }

        public virtual String StringValue
        {
            get
            {
                String Result = "";

                switch (this.m_Type)
                {
                    case System.Data.SqlDbType.Int:
                        Result = ((int)m_Value).ToString();
                        break;

                    case System.Data.SqlDbType.Decimal:
                    case System.Data.SqlDbType.Float:
                    case System.Data.SqlDbType.Money:
                    case System.Data.SqlDbType.Real:
                        Result = ((double)this.m_Value).ToString();
                        break;

                    case System.Data.SqlDbType.Date:
                        Result = ((DateTime)this.m_Value).ToString("dd/MM/yyyy");
                        break;

                    case System.Data.SqlDbType.DateTime:
                        Result = ((DateTime)this.m_Value).ToString("dd/MM/yyyy HH:mm:ss");
                        break;

                    default:
                        Result = Convert.ToString(m_Value);
                        break;
                }

                return Result;
            }

            set
            {
                switch (this.m_Type)
                {
                    case System.Data.SqlDbType.Int:
                        this.value = Utils.Utils.ToLong(value);
                        break;

                    case System.Data.SqlDbType.Decimal:
                    case System.Data.SqlDbType.Float:
                    case System.Data.SqlDbType.Money:
                    case System.Data.SqlDbType.Real:
                        this.value = Utils.Utils.ToDouble(value);
                        break;

                    case System.Data.SqlDbType.Date:
                        this.value = Utils.Utils.ToDate(value);
                        break;

                    case System.Data.SqlDbType.DateTime:
                    case System.Data.SqlDbType.DateTime2:
                        this.value = Utils.Utils.ToDateTime(value);
                        break;

                    default:
                        this.value = (value);
                        break;
                }
            }
        }

        public Boolean isNull
        {
            get
            {
                if (this.m_TableBase != null)
                    this.m_TableBase.selfFill();
                else { }

                return this.m_Null;
            }
            set
            {
                this.m_Null = value;
                if (value)
                    this.value = null;
                else { }
            }
        }

        internal void setTableBase(TTableBase tableBase)
        {
            this.m_TableBase = tableBase;
        }

        public TField()
            : base()
        {
            this.m_Name = "";
            this.m_Identity = false;
            this.m_Null = true;
            this.m_New = true;
        }

        public TField(string name, object value)
        {
            this.m_Name = name;
            this.m_Value = value;
        }

        public String name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }

        public System.Data.SqlDbType type
        {
            get { return this.m_Type; }
            set { this.m_Type = value; }
        }

        public Boolean primaryKey
        {
            get { return this.m_PrimaryKey; }
            set { this.m_PrimaryKey = value; }
        }

        public Boolean identity
        {
            get { return this.m_Identity; }
            set { this.m_Identity = value; }
        }

        public String alias
        {
            get { return this.m_Alias; }
            set { this.m_Alias = value; }
        }

        public bool showInFindOnly
        {
            get { return this.m_ShowInFindOnly; }
            set { this.m_ShowInFindOnly = value; }
        }
    }
}