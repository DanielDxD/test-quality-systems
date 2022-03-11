
using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ModalidadeEsportiva")]
	public class ModalidadeEsportiva : TTableBase
	{
		public ModalidadeEsportiva() : base() {}

		[
			TColumn("idModalidadeEsportiva", System.Data.SqlDbType.BigInt, true, true)
		]
		private TFieldInteger m_idModalidadeEsportiva = new TFieldInteger();
		public TFieldInteger idModalidadeEsportiva 
		{ 
			get { return this.m_idModalidadeEsportiva; }
		}

		[
			TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)
		]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao 
		{ 
			get { return this.m_descricao; }
		}

		[
			TColumn("idadeMinima", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_idadeMinima = new TFieldInteger();
		public TFieldInteger idadeMinima 
		{ 
			get { return this.m_idadeMinima; }
		}

		[
			TColumn("idadeMaxima", System.Data.SqlDbType.Int, false, false)
		]
		private TFieldInteger m_idadeMaxima = new TFieldInteger();
		public TFieldInteger idadeMaxima 
		{ 
			get { return this.m_idadeMaxima; }
        }

        [
            TColumn("situacao", System.Data.SqlDbType.Char, false, false)
        ]
        private TFieldString m_situacao = new TFieldString();
        public TFieldString situacao
        {
            get { return this.m_situacao; }
        }

        [
          TList(typeof(ModalidadeEsportivaTurma)),
          TJoin(new String[] { "idModalidadeEsportiva->idModalidadeEsportiva" })
         ]
        private Object m_Turmas = null;
        public System.Collections.Generic.List<ModalidadeEsportivaTurma> turmas
        {
            get
            {
                if (this.m_Turmas != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ModalidadeEsportivaTurma) }
                     ).IsInstanceOfType(this.m_Turmas)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Turmas)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Turmas).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Turmas).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Turmas)[i]);

                        this.m_Turmas = em.list(typeof(ModalidadeEsportivaTurma), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ModalidadeEsportivaTurma>)this.m_Turmas;
            }
        }

    }
}
