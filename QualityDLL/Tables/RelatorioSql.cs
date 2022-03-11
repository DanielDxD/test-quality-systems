using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("RelatorioSql")]
    public class RelatorioSql : TTableBase
    {
        [TColumn("idRelatorioSql", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idRelatorioSql = new TFieldInteger();
        public TFieldInteger idRelatorioSql
        {
            get { return this.m_idRelatorioSql; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("consulta", System.Data.SqlDbType.NVarChar, false, false)]
        private TFieldString m_consulta = new TFieldString();
        public TFieldString consulta
        {
            get { return this.m_consulta; }
        }

        [
         TList(typeof(RelatorioSqlFiltros)),
         TJoin(new String[] { "idRelatorioSql->idRelatorioSql" })
        ]
        private Object m_RelatorioSqlFiltros = null;
        public System.Collections.Generic.List<RelatorioSqlFiltros> relatorioSqlFiltros
        {
            get
            {
                if (this.m_RelatorioSqlFiltros != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(RelatorioSqlFiltros) }
                     ).IsInstanceOfType(this.m_RelatorioSqlFiltros)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioSqlFiltros)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RelatorioSqlFiltros).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RelatorioSqlFiltros).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioSqlFiltros)[i]);

                        this.m_RelatorioSqlFiltros = em.list(typeof(RelatorioSqlFiltros), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<RelatorioSqlFiltros>)this.m_RelatorioSqlFiltros;
            }
        }


    }
}
