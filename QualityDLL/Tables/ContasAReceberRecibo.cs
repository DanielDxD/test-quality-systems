
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContasAReceberRecibo")]
    public class ContasAReceberRecibo : TTableBase
    {
        [TColumn("idContasAReceberRecibo", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdContasAReceberRecibo = new TFieldInteger();
        public TFieldInteger idContasAReceberRecibo
        {
            get { return this.m_IdContasAReceberRecibo; }
        }

        [TColumn("dataRecibo", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataRecibo = new TFieldDatetime();
        public TFieldDatetime dataRecibo
        {
            get { return this.m_DataRecibo; }
        }

        [TColumn("valorTotal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorTotal = new TFieldDouble();
        public TFieldDouble valorTotal
        {
            get { return this.m_ValorTotal; }
        }

        [TColumn("jurosTotal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_JurosTotal = new TFieldDouble();
        public TFieldDouble jurosTotal
        {
            get { return this.m_JurosTotal; }
        }

        [TColumn("multaTotal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_MultaTotal = new TFieldDouble();
        public TFieldDouble multaTotal
        {
            get { return this.m_MultaTotal; }
        }

        [TColumn("descontoTotal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_DescontoTotal = new TFieldDouble();
        public TFieldDouble descontoTotal
        {
            get { return this.m_DescontoTotal; }
        }

        [
         TList(typeof(ContasAReceberPagamento)),
         TJoin(new String[] { "idContasAReceberRecibo->idContasAReceberRecibo" })
        ]
        private Object m_ContasAReceberPagamentos = null;
        public System.Collections.Generic.List<ContasAReceberPagamento> contasAReceberPagamentos
        {
            get
            {
                if (this.m_ContasAReceberPagamentos != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(ContasAReceberPagamento) }
                     ).IsInstanceOfType(this.m_ContasAReceberPagamentos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_ContasAReceberPagamentos)[i]);

                        this.m_ContasAReceberPagamentos = em.list(typeof(ContasAReceberPagamento), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<ContasAReceberPagamento>)this.m_ContasAReceberPagamentos;
            }
        }

    }
}
