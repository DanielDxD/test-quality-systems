using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvCompra")]
    public class PdvCompra: TTableBase
    {
        [TColumn("idPdvCompra", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvCompra = new TFieldInteger();
        public TFieldInteger idPdvCompra
        {
            get { return this.m_idPdvCompra; }
        }

        [TColumn("dataCompra", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCompra = new TFieldDatetime();
        public TFieldDatetime dataCompra
        {
            get { return this.m_dataCompra; }
        }

        [TColumn("numeroDocumento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroDocumento = new TFieldString();
        public TFieldString numeroDocumento
        {
            get { return this.m_numeroDocumento; }
        }

        [TColumn("statusCompra", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_statusCompra = new TFieldString();
        public TFieldString statusCompra
        {
            get { return this.m_statusCompra; }
        }
        

        [TColumn("cpfCnpj", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_cpfCnpj = new TFieldString();
        public TFieldString cpfCnpj
        {
            get { return this.m_cpfCnpj; }
        }

        [TColumn("numeroComanda", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroComanda = new TFieldString();
        public TFieldString numeroComanda
        {
            get { return this.m_numeroComanda; }
        }

        [
            TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idPessoaFisicaJuridica = null;
        public EmpresaRelacionamento pessoaFisicaJuridica
        {
            get
            {
                if (this.m_idPessoaFisicaJuridica == null)
                {
                    this.m_idPessoaFisicaJuridica = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idPessoaFisicaJuridica.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPessoaFisicaJuridica.connectionString = this.connectionString;
                            this.m_idPessoaFisicaJuridica.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPessoaFisicaJuridica.selfFill();
                return this.m_idPessoaFisicaJuridica;
            }
        }

        [
            TColumn("idRequisicaoInterna", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idRequisicaoInterna->idRequisicaoInterna" })
        ]
        private RequisicaoInterna m_idRequisicaoInterna = null;
        public RequisicaoInterna requisicaoInterna
        {
            get
            {
                if (this.m_idRequisicaoInterna == null)
                {
                    this.m_idRequisicaoInterna = new RequisicaoInterna();

                    foreach (TJoin attribute in this.m_idRequisicaoInterna.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRequisicaoInterna.connectionString = this.connectionString;
                            this.m_idRequisicaoInterna.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRequisicaoInterna.selfFill();
                return this.m_idRequisicaoInterna;
            }
        }

        [
            TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
        ]
        private PdvEstacao  m_idPdvEstacao = null;
        public PdvEstacao  pdvEstacao
        {
            get
            {
                if (this.m_idPdvEstacao == null)
                {
                    this.m_idPdvEstacao = new PdvEstacao ();

                    foreach (TJoin attribute in this.m_idPdvEstacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPdvEstacao.connectionString = this.connectionString;
                            this.m_idPdvEstacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPdvEstacao.selfFill();
                return this.m_idPdvEstacao;
            }
        }

        [
            TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private ContasAReceber m_idContasAReceber = null;
        public ContasAReceber contasAReceber
        {
            get
            {
                if (this.m_idContasAReceber == null)
                {
                    this.m_idContasAReceber = new ContasAReceber();

                    foreach (TJoin attribute in this.m_idContasAReceber.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContasAReceber.connectionString = this.connectionString;
                            this.m_idContasAReceber.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContasAReceber.selfFill();
                return this.m_idContasAReceber;
            }
        }

        [
         TList(typeof(PdvCompraTaxaServico)),
         TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private Object m_PdvCompraTaxaServico = null;
        public System.Collections.Generic.List<PdvCompraTaxaServico> pdvCompraTaxaServico
        {
            get
            {
                if (this.m_PdvCompraTaxaServico != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvCompraTaxaServico) }
                     ).IsInstanceOfType(this.m_PdvCompraTaxaServico)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraTaxaServico)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PdvCompraTaxaServico).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PdvCompraTaxaServico).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraTaxaServico)[i]);

                        this.m_PdvCompraTaxaServico = em.list(typeof(PdvCompraTaxaServico), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvCompraTaxaServico>)this.m_PdvCompraTaxaServico;
            }
        }

        [
         TList(typeof(PdvCompraCupom)),
         TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private Object m_PdvCompraCupons = null;
        public System.Collections.Generic.List<PdvCompraCupom> pdvCompraCupons
        {
            get
            {
                if (this.m_PdvCompraCupons != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvCompraCupom) }
                     ).IsInstanceOfType(this.m_PdvCompraCupons)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupons)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupons).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupons).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraCupons)[i]);

                        this.m_PdvCompraCupons = em.list(typeof(PdvCompraCupom), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvCompraCupom>)this.m_PdvCompraCupons;
            }
        }

        [
         TList(typeof(PdvCompraStatus)),
         TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private Object m_PdvCompraStatus = null;
        public System.Collections.Generic.List<PdvCompraStatus> pdvCompraStatus
        {
            get
            {
                if (this.m_PdvCompraStatus != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PdvCompraStatus) }
                     ).IsInstanceOfType(this.m_PdvCompraStatus)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraStatus)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PdvCompraStatus).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PdvCompraStatus).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PdvCompraStatus)[i]);

                        this.m_PdvCompraStatus = em.list(typeof(PdvCompraStatus), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PdvCompraStatus>)this.m_PdvCompraStatus;
            }
        }


        [
            TColumn("idPos", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPos->idPos" })
        ]
        private Pos m_idPos = null;
        public Pos pos
        {
            get
            {
                if (this.m_idPos == null)
                {
                    this.m_idPos = new Pos();

                    foreach (TJoin attribute in this.m_idPos.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPos.connectionString = this.connectionString;
                            this.m_idPos.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPos.selfFill();
                return this.m_idPos;
            }
        }
    }
}
