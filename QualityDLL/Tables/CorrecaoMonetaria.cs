
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("CorrecaoMonetaria")]
    public class CorrecaoMonetaria : TTableBase
    {
        [TColumn("idCorrecaoMonetaria", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdCorrecaoMonetaria = new TFieldInteger();
        public TFieldInteger idCorrecaoMonetaria
        {
            get { return this.m_IdCorrecaoMonetaria; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("ativo", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_Ativo = new TFieldBoolean();
        public TFieldBoolean ativo
        {
            get { return this.m_Ativo; }
        }

        [
         TList(typeof(CorrecaoMonetariaItem)),
         TJoin(new String[] { "idCorrecaoMonetaria->idCorrecaoMonetaria" })
        ]
        private Object m_CorrecaoMonetariaItems = null;
        public System.Collections.Generic.List<CorrecaoMonetariaItem> correcaoMonetariaItems
        {
            get
            {
                if (this.m_CorrecaoMonetariaItems != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(CorrecaoMonetariaItem) }
                     ).IsInstanceOfType(this.m_CorrecaoMonetariaItems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CorrecaoMonetariaItems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_CorrecaoMonetariaItems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_CorrecaoMonetariaItems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_CorrecaoMonetariaItems)[i]);

                        this.m_CorrecaoMonetariaItems = em.list(typeof(CorrecaoMonetariaItem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<CorrecaoMonetariaItem>)this.m_CorrecaoMonetariaItems;
            }
        }

    }
}
