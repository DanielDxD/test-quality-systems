
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("CalculoEfetuado")]
    public class CalculoEfetuado : TTableBase
    {
        [TColumn("idCalculoEfetuado", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdCalculoEfetuado = new TFieldInteger();
        public TFieldInteger idCalculoEfetuado
        {
            get { return this.m_IdCalculoEfetuado; }
        }

        [TColumn("dataCalculo", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataCalculo = new TFieldDatetime();
        public TFieldDatetime dataCalculo
        {
            get { return this.m_DataCalculo; }
        }

        [TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idFuncionario->idFuncionario" })]
        private Funcionario m_IdFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_IdFuncionario == null)
                {
                    this.m_IdFuncionario = new Funcionario();
                    foreach (TJoin attribute in this.m_IdFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdFuncionario.connectionString = this.connectionString;
                            this.m_IdFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdFuncionario.selfFill();
                return this.m_IdFuncionario;
            }
        }

        [TColumn("valorApurado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorApurado = new TFieldDouble();
        public TFieldDouble valorApurado
        {
            get { return this.m_ValorApurado; }
        }

    }
}
