using System;

namespace Utils
{
    //[Serializable]
    public class NameValue
    {
        private string m_name;
        private object m_value;

        public NameValue()
        {
        }

        public NameValue(string pName, object pValue)
        {
            this.m_name = pName;
            this.m_value = pValue;
        }

        public string name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        public object value
        {
            get { return this.m_value; }
            set { this.m_value = value; }
        }
    }
}