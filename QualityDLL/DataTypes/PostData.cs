using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTypes
{
    public class PostData
    {

        private string m_KeyValue;
        public string keyValue
        {
            get { return this.m_KeyValue; }
            set { this.m_KeyValue = value; }
        }

        private string m_Value;
        public string Value
        {
            get { return this.m_Value; }
            set { this.m_Value = value; }
        }

    }
}