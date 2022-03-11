using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("configuracaoFiscal")]
    public class ConfiguracaoFiscal : TTableBase
    {
        [TColumn("nomeConfig", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nomeConfig = new TFieldString();
        public TFieldString nomeConfig
        {
            get { return this.m_nomeConfig; }
        }

        [TColumn("valorConfig", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_valorConfig = new TFieldString();
        public TFieldString valorConfig
        {
            get { return this.m_valorConfig; }
        }

        [
            TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idEmpresa->idEmpresa" })
        ]
        private Empresa m_empresa = null;
        public Empresa empresa
        {
            get
            {
                if (this.m_empresa == null)
                {
                    this.m_empresa = new Empresa();

                    foreach (TJoin attribute in this.m_empresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_empresa.connectionString = this.connectionString;
                            this.m_empresa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_empresa.selfFill();

                return this.m_empresa;
            }
        }
    }
}
