
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("UsuarioLogado")]
    public class UsuarioLogado : TTableBase
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

        [TColumn("modulo", System.Data.SqlDbType.VarChar, true, false)]
        private TFieldString m_Modulo = new TFieldString();
        public TFieldString modulo
        {
            get { return this.m_Modulo; }
        }

        [TColumn("dataLogin", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataLogin = new TFieldDatetime();
        public TFieldDatetime dataLogin
        {
            get { return this.m_DataLogin; }
        }

        [TColumn("token", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Token = new TFieldString();
        public TFieldString token
        {
            get { return this.m_Token; }
        }

        [TColumn("hashSign", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_SessionId = new TFieldString();
        public TFieldString sessionId
        {
            get { return this.m_SessionId; }
        }

    }
}
