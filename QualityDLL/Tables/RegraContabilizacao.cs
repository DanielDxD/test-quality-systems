using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("RegraContabilizacao")]
    public class RegraContabilizacao : TTableBase
    {
        [TColumn("idRegraContabilizacao", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idRegraContabilizacao = new TFieldInteger();
        public TFieldInteger idRegraContabilizacao
        {
            get { return this.m_idRegraContabilizacao; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("tipoAgrupamento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipoAgrupamento = new TFieldString();
        public TFieldString tipoAgrupamento
        {
            get { return this.m_tipoAgrupamento; }
        }

        [
         TList(typeof(RegraContabilizacaoLancamento)),
         TJoin(new String[] { "idRegraContabilizacao->idRegraContabilizacao" })
        ]
        private Object m_RegraContabilizacaoLancamentos = null;
        public System.Collections.Generic.List<RegraContabilizacaoLancamento> regraContabilizacaoLancamentos
        {
            get
            {
                if (this.m_RegraContabilizacaoLancamentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(RegraContabilizacaoLancamento) }
                     ).IsInstanceOfType(this.m_RegraContabilizacaoLancamentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RegraContabilizacaoLancamentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RegraContabilizacaoLancamentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RegraContabilizacaoLancamentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RegraContabilizacaoLancamentos)[i]);

                        this.m_RegraContabilizacaoLancamentos = em.list(typeof(RegraContabilizacaoLancamento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<RegraContabilizacaoLancamento>)this.m_RegraContabilizacaoLancamentos;
            }
        }
    }
}
