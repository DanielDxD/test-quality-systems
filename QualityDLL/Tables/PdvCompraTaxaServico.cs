using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvCompraTaxaServico")]
    public class PdvCompraTaxaServico : TTableBase
    {
        [TColumn("idPdvCompraTaxaServico", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvCompraTaxaServico = new TFieldInteger();
        public TFieldInteger idPdvCompraTaxaServico
        {
            get { return this.m_idPdvCompraTaxaServico; }
        }

        [
            TColumn("idPdvCompra", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private PdvCompra m_pdvCompra = null;
        public PdvCompra pdvCompra
        {
            get
            {
                if (this.m_pdvCompra == null)
                {
                    this.m_pdvCompra = new PdvCompra();

                    foreach (TJoin attribute in this.m_pdvCompra.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvCompra.connectionString = this.connectionString;
                            this.m_pdvCompra.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvCompra.selfFill();
                return this.m_pdvCompra;
            }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_Valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_Valor; }
        }       
    }
}
