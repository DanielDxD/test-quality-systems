using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Convidado")]
    public class Convidado : TTableBase
    {

        [
            TColumn("idConvidado", System.Data.SqlDbType.BigInt, true, false),
            TJoin(new String[] { "idConvidado->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idConvidado = null;
        public EmpresaRelacionamento convidadoEmpresaRelacionamento
        {
            get
            {
                if (this.m_idConvidado == null)
                {
                    this.m_idConvidado = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idConvidado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idConvidado.connectionString = this.connectionString;
                            this.m_idConvidado.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idConvidado.selfFill();

                return this.m_idConvidado;
            }
        }
    }
}
