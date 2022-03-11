
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ApiToken")]
    public class ApiToken : TTableBase
    {
        [TColumn("idUsuario", System.Data.SqlDbType.BigInt, true, false),
TJoin(new String[] { "idUsuario->idUsuario" })]
        private Usuario m_IdUsuario = null;
        public Usuario usuario
        {
            get
            {
                if (this.m_IdUsuario == null)
                {
                    this.m_IdUsuario = new Usuario();
                    foreach (TJoin attribute in this.m_IdUsuario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdUsuario.connectionString = this.connectionString;
                            this.m_IdUsuario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdUsuario.selfFill();
                return this.m_IdUsuario;
            }
        }

        [TColumn("idApiCredencial", System.Data.SqlDbType.Int, true, false),
TJoin(new String[] { "idApiCredencial->idApiCredencial" })]
        private ApiCredencial m_IdApiCredencial = null;
        public ApiCredencial apiCredencial
        {
            get
            {
                if (this.m_IdApiCredencial == null)
                {
                    this.m_IdApiCredencial = new ApiCredencial();
                    foreach (TJoin attribute in this.m_IdApiCredencial.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdApiCredencial.connectionString = this.connectionString;
                            this.m_IdApiCredencial.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdApiCredencial.selfFill();
                return this.m_IdApiCredencial;
            }
        }

        [TColumn("token", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Token = new TFieldString();
        public TFieldString token
        {
            get { return this.m_Token; }
        }

        [TColumn("expiresIn", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_ExpiresIn = new TFieldDatetime();
        public TFieldDatetime expiresIn
        {
            get { return this.m_ExpiresIn; }
        }

    }
}
