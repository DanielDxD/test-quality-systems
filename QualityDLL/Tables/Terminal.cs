
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Terminal")]
    public class Terminal : TTableBase
    {
        [TColumn("idTerminal", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdTerminal = new TFieldInteger();
        public TFieldInteger idTerminal
        {
            get { return this.m_IdTerminal; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("numeroTerminal", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_NumeroTerminal = new TFieldInteger();
        public TFieldInteger numeroTerminal
        {
            get { return this.m_NumeroTerminal; }
        }

        [TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idDepartamento->idDepartamento" })]
        private Departamento m_IdDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_IdDepartamento == null)
                {
                    this.m_IdDepartamento = new Departamento();
                    foreach (TJoin attribute in this.m_IdDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();
                        bool existNullKey = false;
                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }
                        if (!existNullKey)
                        {
                            this.m_IdDepartamento.connectionString = this.connectionString;
                            this.m_IdDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdDepartamento.selfFill();
                return this.m_IdDepartamento;
            }
        }

    }
}
