using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Fornecedor")]
    public class Fornecedor : TTableBase
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

        [
            TColumn("idFornecedor", System.Data.SqlDbType.BigInt, true, false),
            TJoin(new String[] { "idFornecedor->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idFornecedor = null;
        public EmpresaRelacionamento fornecedorEmpresaRelacionamento
        {
            get
            {
                if (this.m_idFornecedor == null)
                {
                    this.m_idFornecedor = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idFornecedor.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idFornecedor.connectionString = this.connectionString;
                            this.m_idFornecedor.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idFornecedor.selfFill();

                return this.m_idFornecedor;
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
