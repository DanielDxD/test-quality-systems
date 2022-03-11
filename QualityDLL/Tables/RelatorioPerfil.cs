using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("relatorioPerfil")]
    public class RelatorioPerfil : TTableBase
    {
        [TColumn("idRelatorioPerfil", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idRelatorioPerfil = new TFieldInteger();
        public TFieldInteger idRelatorioPerfil
        {
            get { return this.m_idRelatorioPerfil; }
        }

        [
            TColumn("idPerfil", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idPerfil->idPerfil" })
        ]
        private Perfil m_idPerfil = null;
        public Perfil perfil
        {
            get
            {
                if (this.m_idPerfil == null)
                {
                    this.m_idPerfil = new Perfil();

                    foreach (TJoin attribute in this.m_idPerfil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPerfil.connectionString = this.connectionString;
                            this.m_idPerfil.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPerfil.selfFill();

                return this.m_idPerfil;
            }
        }

        [
            TColumn("idRelatorio", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idRelatorio->idRelatorio" })
        ]
        private Relatorios m_idRelatorio = null;
        public Relatorios relatorio
        {
            get
            {
                if (this.m_idRelatorio == null)
                {
                    this.m_idRelatorio = new Relatorios();

                    foreach (TJoin attribute in this.m_idRelatorio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRelatorio.connectionString = this.connectionString;
                            this.m_idRelatorio.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRelatorio.selfFill();

                return this.m_idRelatorio;
            }
        }



        [
            TColumn("idRelatorioSql", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idRelatorioSql->idRelatorioSql" })
        ]
        private RelatorioSql m_idRelatorioDinamico = null;
        public RelatorioSql relatorioDinamico
        {
            get
            {
                if (this.m_idRelatorioDinamico == null)
                {
                    this.m_idRelatorioDinamico = new RelatorioSql();

                    foreach (TJoin attribute in this.m_idRelatorioDinamico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRelatorioDinamico.connectionString = this.connectionString;
                            this.m_idRelatorioDinamico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRelatorioDinamico.selfFill();

                return this.m_idRelatorioDinamico;
            }
        }

    }
}
