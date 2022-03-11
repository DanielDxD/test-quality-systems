using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Cliente")]
    public class Cliente : TTableBase
    {

        [TColumn("dataContrato", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataContrato = new TFieldDatetime();
        public TFieldDatetime dataContrato
        {
            get { return this.m_dataContrato; }
        }

        [TColumn("retemISS", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_retemISS = new TFieldBoolean();
        public TFieldBoolean retemISS
        {
            get { return this.m_retemISS; }
        }

        [TColumn("recebimentoPDV", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_recebimentoPDV = new TFieldString();
        public TFieldString recebimentoPDV
        {
            get { return this.m_recebimentoPDV; }
        }

        [
            TColumn("idCliente", System.Data.SqlDbType.BigInt, true, false),
            TJoin(new String[] { "idCliente->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idCliente = null;
        public EmpresaRelacionamento clienteEmpresaRelacionamento
        {
            get
            {
                if (this.m_idCliente == null)
                {
                    this.m_idCliente = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idCliente.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idCliente.connectionString = this.connectionString;
                            this.m_idCliente.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idCliente.selfFill();

                return this.m_idCliente;
            }
        }

        [
         TColumn("idRegraContabilizacao", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idRegraContabilizacao->idRegraContabilizacao" })
        ]
        private RegraContabilizacao m_idRegraContabilizacao = null;
        public RegraContabilizacao regraContabilizacao
        {
            get
            {
                if (this.m_idRegraContabilizacao == null)
                {
                    this.m_idRegraContabilizacao = new RegraContabilizacao();

                    foreach (TJoin attribute in this.m_idRegraContabilizacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRegraContabilizacao.connectionString = this.connectionString;
                            this.m_idRegraContabilizacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRegraContabilizacao.selfFill();

                return this.m_idRegraContabilizacao;
            }
        }

        [
         TColumn("idTipoMovimentoContabil", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoMovimentoContabil->idTipoMovimentoContabil" })
        ]
        private TipoMovimentoContabil m_idTipoMovimentoContabil = null;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get
            {
                if (this.m_idTipoMovimentoContabil == null)
                {
                    this.m_idTipoMovimentoContabil = new TipoMovimentoContabil();

                    foreach (TJoin attribute in this.m_idTipoMovimentoContabil.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoMovimentoContabil.connectionString = this.connectionString;
                            this.m_idTipoMovimentoContabil.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoMovimentoContabil.selfFill();

                return this.m_idTipoMovimentoContabil;
            }
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
    }
}
