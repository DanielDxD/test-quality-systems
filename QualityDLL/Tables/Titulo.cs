using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Titulo")]
    public class Titulo : TTableBase
    {
        [TColumn("idTitulo", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idTitulo = new TFieldInteger();
        public TFieldInteger idTitulo
        {
            get { return this.m_idTitulo; }
        }

        [TColumn("numero", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldBigInteger m_numero = new TFieldBigInteger();
        public TFieldBigInteger numero
        {
            get { return this.m_numero; }
        }

        [TColumn("serie", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_serie = new TFieldString();
        public TFieldString serie
        {
            get { return this.m_serie; }
        }


        [
            TColumn("idSituacao", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idSituacao->idSituacao" })
        ]
        private Situacao m_idSituacao = null;
        public Situacao situacao
        {
            get
            {
                if (this.m_idSituacao == null)
                {
                    this.m_idSituacao = new Situacao();

                    foreach (TJoin attribute in this.m_idSituacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idSituacao.connectionString = this.connectionString;
                            this.m_idSituacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idSituacao.selfFill();

                return this.m_idSituacao;
            }
        }

        [TColumn("dataCriacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCriacao = new TFieldDatetime();
        public TFieldDatetime dataCriacao
        {
            get { return this.m_dataCriacao; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [
            TList(typeof(TituloConsignacao)),
            TJoin(new String[] { "idTitulo->idTitulo" })
        ]
        private Object m_TituloConsignacaos = null;
        public System.Collections.Generic.List<TituloConsignacao> tituloConsignacaos
        {
            get
            {
                if (this.m_TituloConsignacaos != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(TituloConsignacao) }
                        ).IsInstanceOfType(this.m_TituloConsignacaos)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaos)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaos).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaos).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloConsignacaos)[i]);

                        this.m_TituloConsignacaos = em.list(typeof(TituloConsignacao), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<TituloConsignacao>)this.m_TituloConsignacaos;
            }
        }

        [
            TList(typeof(TituloSocio)),
            TJoin(new String[] { "idTitulo->idTitulo" })
        ]
        private Object m_TituloSocios = null;
        public System.Collections.Generic.List<TituloSocio> tituloSocios
        {
            get
            {
                if (this.m_TituloSocios != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(TituloSocio) }
                        ).IsInstanceOfType(this.m_TituloSocios)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocios)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_TituloSocios).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_TituloSocios).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_TituloSocios)[i]);

                        this.m_TituloSocios = em.list(typeof(TituloSocio), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<TituloSocio>)this.m_TituloSocios;
            }
        }
    }
}
