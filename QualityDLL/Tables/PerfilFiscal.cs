
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("PerfilFiscal")]
    public class PerfilFiscal : TTableBase
    {
        [TColumn("idPerfilFiscal", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdPerfilFiscal = new TFieldInteger();
        public TFieldInteger idPerfilFiscal
        {
            get { return this.m_IdPerfilFiscal; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("sequencia", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Sequencia = new TFieldInteger();
        public TFieldInteger sequencia
        {
            get { return this.m_Sequencia; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_IdEmpresa; }
        }        

        [
            TColumn("idCfop", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idCfop->idCfop" })
        ]
        private CfOp m_IdCfop = null;
        public CfOp cfop
        {
            get
            {
                if (this.m_IdCfop == null)
                {
                    this.m_IdCfop = new CfOp();
                    foreach (TJoin attribute in this.m_IdCfop.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCfop.connectionString = this.connectionString;
                            this.m_IdCfop.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCfop.selfFill();
                return this.m_IdCfop;
            }
        }

        [TColumn("idCstIcms", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idCstIcms->idcstIcms" })]
        private CstIcms m_IdCstIcms = null;
        public CstIcms cstIcms
        {
            get
            {
                if (this.m_IdCstIcms == null)
                {
                    this.m_IdCstIcms = new CstIcms();
                    foreach (TJoin attribute in this.m_IdCstIcms.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCstIcms.connectionString = this.connectionString;
                            this.m_IdCstIcms.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCstIcms.selfFill();
                return this.m_IdCstIcms;
            }
        }

        [TColumn("idCstPis", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idCstPis->idcstpis" })]
        private CstPis m_IdCstPis = null;
        public CstPis cstPis
        {
            get
            {
                if (this.m_IdCstPis == null)
                {
                    this.m_IdCstPis = new CstPis();
                    foreach (TJoin attribute in this.m_IdCstPis.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCstPis.connectionString = this.connectionString;
                            this.m_IdCstPis.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCstPis.selfFill();
                return this.m_IdCstPis;
            }
        }

        [TColumn("idCstCofins", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idCstCofins->idcstCofins" })]
        private CstCofins m_IdCstCofins = null;
        public CstCofins cstCofins
        {
            get
            {
                if (this.m_IdCstCofins == null)
                {
                    this.m_IdCstCofins = new CstCofins();
                    foreach (TJoin attribute in this.m_IdCstCofins.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCstCofins.connectionString = this.connectionString;
                            this.m_IdCstCofins.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCstCofins.selfFill();
                return this.m_IdCstCofins;
            }
        }

        [TColumn("idCstIpi", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idCstIpi->idcstipi" })]
        private CstIpi m_IdCstIpi = null;
        public CstIpi cstIpi
        {
            get
            {
                if (this.m_IdCstIpi == null)
                {
                    this.m_IdCstIpi = new CstIpi();
                    foreach (TJoin attribute in this.m_IdCstIpi.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdCstIpi.connectionString = this.connectionString;
                            this.m_IdCstIpi.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdCstIpi.selfFill();
                return this.m_IdCstIpi;
            }
        }

        [TColumn("tipo", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_Tipo = new TFieldString();
        public TFieldString tipo
        {
            get { return this.m_Tipo; }
        }

        [TColumn("icms", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_Icms = new TFieldBoolean();
        public TFieldBoolean icms
        {
            get { return this.m_Icms; }
        }

        [TColumn("icmsSt", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_IcmsSt = new TFieldBoolean();
        public TFieldBoolean icmsSt
        {
            get { return this.m_IcmsSt; }
        }

        [TColumn("ipi", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_Ipi = new TFieldBoolean();
        public TFieldBoolean ipi
        {
            get { return this.m_Ipi; }
        }

        [TColumn("icmsSIpi", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_IcmsSIpi = new TFieldBoolean();
        public TFieldBoolean icmsSIpi
        {
            get { return this.m_IcmsSIpi; }
        }

        [TColumn("redBcIcms", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_RedBcIcms = new TFieldBoolean();
        public TFieldBoolean redBcIcms
        {
            get { return this.m_RedBcIcms; }
        }

        [TColumn("redBCIcmsSt", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_RedBCIcmsSt = new TFieldBoolean();
        public TFieldBoolean redBCIcmsSt
        {
            get { return this.m_RedBCIcmsSt; }
        }

        [TColumn("icmsDiferido", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_IcmsDiferido = new TFieldBoolean();
        public TFieldBoolean icmsDiferido
        {
            get { return this.m_IcmsDiferido; }
        }

        [TColumn("fcpIcms", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_FcpIcms = new TFieldBoolean();
        public TFieldBoolean fcpIcms
        {
            get { return this.m_FcpIcms; }
        }

        [TColumn("fcpIcmsSt", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_FcpIcmsSt = new TFieldBoolean();
        public TFieldBoolean fcpIcmsSt
        {
            get { return this.m_FcpIcmsSt; }
        }

        [TColumn("aplicarAliquotaIcms", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_AplicarAliquotaIcms = new TFieldBoolean();
        public TFieldBoolean aplicarAliquotaIcms
        {
            get { return this.m_AplicarAliquotaIcms; }
        }

        [TColumn("aliquotaIcms", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_AliquotaIcms = new TFieldDouble();
        public TFieldDouble aliquotaIcms
        {
            get { return this.m_AliquotaIcms; }
        }

        [TColumn("aplicarAliquotaIcmsSt", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_AplicarAliquotaIcmsSt = new TFieldBoolean();
        public TFieldBoolean aplicarAliquotaIcmsSt
        {
            get { return this.m_AplicarAliquotaIcmsSt; }
        }

        [TColumn("aliquotaIcmsSt", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_AliquotaIcmsSt = new TFieldDouble();
        public TFieldDouble aliquotaIcmsSt
        {
            get { return this.m_AliquotaIcmsSt; }
        }

    }
}
