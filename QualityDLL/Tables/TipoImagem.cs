using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("TipoImagem")]
    public class TipoImagem : TTableBase
    {
        [TColumn("idTipoImagem", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idTipoImagem = new TFieldInteger();
        public TFieldInteger idTipoImagem
        {
            get { return this.m_idTipoImagem; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }
        [
         TList(typeof(PessoaImagem)),
         TJoin(new String[] { "idTipoImagem->idTipoImagem" })
        ]
        private Object m_PessoaImagems = null;
        public System.Collections.Generic.List<PessoaImagem> pessoaImagems
        {
            get
            {
                if (this.m_PessoaImagems == null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PessoaImagem) }
                     ).IsInstanceOfType(this.m_PessoaImagems)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaImagems)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PessoaImagems).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PessoaImagems).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PessoaImagems)[i]);

                        this.m_PessoaImagems = em.list(typeof(PessoaImagem), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PessoaImagem>)this.m_PessoaImagems;
            }
        }
    }
}