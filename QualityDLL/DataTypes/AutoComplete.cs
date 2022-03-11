using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTypes
{
    public class AutoComplete
    {

        private string m_label;
        public string label
        {
            get { return this.m_label; }
            set { this.m_label = value; }
        }

        private Object m_Value;
        public Object value
        {
            get { return this.m_Value; }
            set { this.m_Value = value; }
        }

        private Object m_Id;
        public Object id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }

        private Object m_CpfCnpj;
        public Object cpfCnpj
        {
            get { return this.m_CpfCnpj; }
            set { this.m_CpfCnpj = value; }
        }

        private Object m_NumeroCartao;
        public Object numeroCartao
        {
            get { return this.m_NumeroCartao; }
            set { this.m_NumeroCartao = value; }
        }

        private Object m_DataValidade;
        public Object dataValidade
        {
            get { return this.m_DataValidade; }
            set { this.m_DataValidade = value; }
        }

        private Object m_SaldoAtual;
        public Object saldoAtual
        {
            get { return this.m_SaldoAtual; }
            set { this.m_SaldoAtual = value; }
        }

        private Object m_Unidade;
        public Object unidade
        {
            get { return this.m_Unidade; }
            set { this.m_Unidade = value; }
        }

    }
}