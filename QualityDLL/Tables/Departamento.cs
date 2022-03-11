using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Departamento")]
    public class Departamento : TTableBase
    {
        [TColumn("idDepartamento", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idDepartamento = new TFieldInteger();
        public TFieldInteger idDepartamento
        {
            get { return this.m_idDepartamento; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("alcada", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_alcada = new TFieldDouble();
        public TFieldDouble alcada
        {
            get { return this.m_alcada; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("armazem", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_armazem = new TFieldBoolean();
        public TFieldBoolean armazem
        {
            get { return this.m_armazem; }
        }

        [TColumn("idDepartamentoPai", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idDepartamentoPai = new TFieldInteger();
        public TFieldInteger idDepartamentoPai
        {
            get { return this.m_idDepartamentoPai; }
        }

        [
            TColumn("idPlanoContas", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPlanoContas->idPlanoContas" })
        ]
        private PlanoContas m_idPlanoContas = null;
        public PlanoContas planoContas
        {
            get
            {
                if (this.m_idPlanoContas == null)
                {
                    this.m_idPlanoContas = new PlanoContas();

                    foreach (TJoin attribute in this.m_idPlanoContas.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPlanoContas.connectionString = this.connectionString;
                            this.m_idPlanoContas.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPlanoContas.selfFill();

                return this.m_idPlanoContas;
            }
        }

        [
         TList(typeof(Departamento)),
         TJoin(new String[] { "idDepartamento->idDepartamentoPai" })
        ]
        private Object m_Departamentos = null;
        public System.Collections.Generic.List<Departamento> departamentos
        {
            get
            {
                if (this.m_Departamentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(Departamento) }
                     ).IsInstanceOfType(this.m_Departamentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Departamentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_Departamentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_Departamentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_Departamentos)[i]);

                        this.m_Departamentos = em.list(typeof(Departamento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<Departamento>)this.m_Departamentos;
            }
        }

        [TColumn("ativo", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_ativo = new TFieldString();
        public TFieldString ativo
        {
            get { return this.m_ativo; }
        }
    }
}
