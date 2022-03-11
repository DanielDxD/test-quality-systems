
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ApiCredencial")]
    public class ApiCredencial : TTableBase
    {
        [TColumn("idApiCredencial", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdApiCredencial = new TFieldInteger();
        public TFieldInteger idApiCredencial
        {
            get { return this.m_IdApiCredencial; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idEmpresa->idEmpresa" })]
        private Empresa m_IdEmpresa = null;
        public Empresa empresa
        {
            get
            {
                if (this.m_IdEmpresa == null)
                {
                    this.m_IdEmpresa = new Empresa();
                    foreach (TJoin attribute in this.m_IdEmpresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdEmpresa.connectionString = this.connectionString;
                            this.m_IdEmpresa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdEmpresa.selfFill();
                return this.m_IdEmpresa;
            }
        }

        [TColumn("provedor", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Provedor = new TFieldInteger();
        public TFieldInteger provedor
        {
            get { return this.m_Provedor; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("client_id", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Client_id = new TFieldString();
        public TFieldString client_id
        {
            get { return this.m_Client_id; }
        }

        [TColumn("client_secret", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Client_secret = new TFieldString();
        public TFieldString client_secret
        {
            get { return this.m_Client_secret; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_Observacao; }
        }

    }
}
