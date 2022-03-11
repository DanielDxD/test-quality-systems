using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("TipoMovimentoContabil")]
    public class TipoMovimentoContabil : TTableBase
    {
        [TColumn("idTipoMovimentoContabil", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idTipoMovimentoContabil = new TFieldInteger();
        public TFieldInteger idTipoMovimentoContabil
        {
            get { return this.m_idTipoMovimentoContabil; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("contabilizacaoPorCompetencia", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_contabilizacaoPorCompetencia = new TFieldBoolean();
        public TFieldBoolean contabilizacaoPorCompetencia
        {
            get { return this.m_contabilizacaoPorCompetencia; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get {return this.m_idEmpresa;}
        }

        [
         TColumn("idPlanoContasResultado", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPlanoContasResultado->idPlanoContas" })
        ]
        private PlanoContas m_idPlanoContasResultado = null;
        public PlanoContas planoContasResultado
        {
            get
            {
                if (this.m_idPlanoContasResultado == null)
                {
                    this.m_idPlanoContasResultado = new PlanoContas();

                    foreach (TJoin attribute in this.m_idPlanoContasResultado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPlanoContasResultado.connectionString = this.connectionString;
                            this.m_idPlanoContasResultado.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPlanoContasResultado.selfFill();

                return this.m_idPlanoContasResultado;
            }
        }

        [
         TColumn("idPlanoContasProvisao", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPlanoContasProvisao->idPlanoContas" })
        ]
        private PlanoContas m_idPlanoContasProvisao = null;
        public PlanoContas planoContasProvisao
        {
            get
            {
                if (this.m_idPlanoContasProvisao == null)
                {
                    this.m_idPlanoContasProvisao = new PlanoContas();

                    foreach (TJoin attribute in this.m_idPlanoContasProvisao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPlanoContasProvisao.connectionString = this.connectionString;
                            this.m_idPlanoContasProvisao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPlanoContasProvisao.selfFill();

                return this.m_idPlanoContasProvisao;
            }
        }

        [
         TColumn("idPlanoContasAdiantamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPlanoContasAdiantamento->idPlanoContas" })
        ]
        private PlanoContas m_idPlanoContasAdiantamento = null;
        public PlanoContas planoContasAdiantamento
        {
            get
            {
                if (this.m_idPlanoContasAdiantamento == null)
                {
                    this.m_idPlanoContasAdiantamento = new PlanoContas();

                    foreach (TJoin attribute in this.m_idPlanoContasAdiantamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPlanoContasAdiantamento.connectionString = this.connectionString;
                            this.m_idPlanoContasAdiantamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPlanoContasAdiantamento.selfFill();

                return this.m_idPlanoContasAdiantamento;
            }
        }

        [
         TColumn("idTipoMovimentoContabilPai", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoMovimentoContabilPai->idTipoMovimentoContabil" })
        ]
        private TipoMovimentoContabil m_idTipoMovimentoContabilPai = null;
        public TipoMovimentoContabil tipoMovimentoContabilPai
        {
            get
            {
                if (this.m_idTipoMovimentoContabilPai == null)
                {
                    this.m_idTipoMovimentoContabilPai = new TipoMovimentoContabil();

                    foreach (TJoin attribute in this.m_idTipoMovimentoContabilPai.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoMovimentoContabilPai.connectionString = this.connectionString;
                            this.m_idTipoMovimentoContabilPai.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoMovimentoContabilPai.selfFill();

                return this.m_idTipoMovimentoContabilPai;
            }
        }
    }
}