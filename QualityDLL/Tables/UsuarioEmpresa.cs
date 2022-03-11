using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("UsuarioEmpresa")]
    public class UsuarioEmpresa : TTableBase
    {
        [
         TColumn("idUsuario", System.Data.SqlDbType.BigInt, true, false),
         TJoin(new String[] { "idUsuario->idUsuario" })
        ]
        private Usuario m_idUsuario = null;
        public Usuario idUsuario
        {
            get
            {
                if (this.m_idUsuario == null)
                {
                    this.m_idUsuario = new Usuario();

                    foreach (TJoin attribute in this.m_idUsuario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idUsuario.connectionString = this.connectionString;
                            this.m_idUsuario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idUsuario.selfFill();

                return this.m_idUsuario;
            }
        }

        [
         TColumn("idEmpresa", System.Data.SqlDbType.Int, true, false),
         TJoin(new String[] { "idEmpresa->idEmpresa" })
        ]
        private Empresa m_idEmpresa = null;
        public Empresa idEmpresa
        {
            get
            {
                if (this.m_idEmpresa == null)
                {
                    this.m_idEmpresa = new Empresa();

                    foreach (TJoin attribute in this.m_idEmpresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresa.connectionString = this.connectionString;
                            this.m_idEmpresa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresa.selfFill();

                return this.m_idEmpresa;
            }
        }
    }
}