using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContasAReceberItem")]
    public class ContasAReceberItem : TTableBase
    {
        [TColumn("idContasAReceberItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContasAReceberItem = new TFieldInteger();
        public TFieldInteger idContasAReceberItem
        {
            get { return this.m_idContasAReceberItem; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("aliquotaIss", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaIss = new TFieldDouble();
        public TFieldDouble aliquotaIss
        {
            get { return this.m_aliquotaIss; }
        }

        [TColumn("valorIss", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorIss = new TFieldDouble();
        public TFieldDouble valorIss
        {
            get { return this.m_valorIss; }
        }

        [TColumn("aliquotaIcms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaIcms = new TFieldDouble();
        public TFieldDouble aliquotaIcms
        {
            get { return this.m_aliquotaIcms; }
        }

        [TColumn("valorIcms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorIcms = new TFieldDouble();
        public TFieldDouble valorIcms
        {
            get { return this.m_valorIcms; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idNaturezaOperacao = new TFieldInteger();
        public TFieldInteger idNaturezaOperacao
        {
            get { return this.m_idNaturezaOperacao; }
        }

        [TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idDepartamento = new TFieldInteger();
        public TFieldInteger idDepartamento
        {
            get { return this.m_idDepartamento; }
        }

        [
         TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private ContasAReceber m_idContasAReceber = null;
        public ContasAReceber idContasAReceber
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
        TColumn("idConvite", System.Data.SqlDbType.BigInt, false, false),
        TJoin(new String[] { "idConvite->idConvite" })
        ]
        private Convite m_IdConvite = null;
        public Convite convite
        {
            get
            {
                if (this.m_IdConvite == null)
                {
                    this.m_IdConvite = new Convite();

                    foreach (TJoin attribute in this.m_IdConvite.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdConvite.connectionString = this.connectionString;
                            this.m_IdConvite.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdConvite.selfFill();

                return this.m_IdConvite;
            }
        }

        [
         TColumn("idMovimento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idMovimento->idMovimento" })
        ]
        private Movimento m_idMovimento = null;
        public Movimento idMovimento
        {
            get
            {
                if (this.m_idMovimento == null)
                {
                    this.m_idMovimento = new Movimento();

                    foreach (TJoin attribute in this.m_idMovimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idMovimento.connectionString = this.connectionString;
                            this.m_idMovimento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idMovimento.selfFill();

                return this.m_idMovimento;
            }
        }

        [
         TColumn("idMovimentoManual", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idMovimentoManual->idMovimentoManual" })
        ]
        private MovimentoManual m_idMovimentoManual = null;
        public MovimentoManual idMovimentoManual
        {
            get
            {
                this.m_idMovimentoManual = new MovimentoManual();

                if (this.m_idMovimentoManual == null)
                {
                    foreach (TJoin attribute in this.m_idMovimentoManual.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idMovimentoManual.connectionString = this.connectionString;
                            this.m_idMovimentoManual.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idMovimentoManual.selfFill();

                return this.m_idMovimentoManual;
            }
        }



        [
         TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_departamento = null;
        public Departamento departamento
        {
            get
            {
                this.m_departamento = new Departamento();

                if (this.m_departamento == null)
                {
                    foreach (TJoin attribute in this.m_departamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_departamento.connectionString = this.connectionString;
                            this.m_departamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_departamento.selfFill();

                return this.m_departamento;
            }
        }

        [
           TColumn("idPdvCompraCupomItem", System.Data.SqlDbType.Decimal, false, false),
           TJoin(new String[] { "idPdvCompraCupomItem->idPdvCompraCupomItem" })
       ]
        private PdvCompraCupomItem m_idPdvCompraCupomItem = null;
        public PdvCompraCupomItem pdvCompraCupomItem
        {
            get
            {
                if (this.m_idPdvCompraCupomItem == null)
                {
                    this.m_idPdvCompraCupomItem = new PdvCompraCupomItem();

                    foreach (TJoin attribute in this.m_idPdvCompraCupomItem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPdvCompraCupomItem.connectionString = this.connectionString;
                            this.m_idPdvCompraCupomItem.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPdvCompraCupomItem.selfFill();

                return this.m_idPdvCompraCupomItem;
            }
        }
    }
}