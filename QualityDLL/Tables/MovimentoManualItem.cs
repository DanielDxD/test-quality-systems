using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("MovimentoManualItem")]
    public class MovimentoManualItem : TTableBase
    {
        [TColumn("idMovimentoManualItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idMovimentoManualItem = new TFieldInteger();
        public TFieldInteger idMovimentoManualItem
        {
            get { return this.m_idMovimentoManualItem; }
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

        [
         TColumn("idMovimentoManual", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idMovimentoManual->idMovimentoManual" })
        ]
        private MovimentoManual m_idMovimentoManual = null;
        public MovimentoManual idMovimentoManual
        {
            get
            {
                if (this.m_idMovimentoManual == null)
                {
                    this.m_idMovimentoManual = new MovimentoManual();

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
         TColumn("idServico", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idServico->idServico" })
        ]
        private Servico m_idServico = null;
        public Servico idServico
        {
            get
            {
                if (this.m_idServico == null)
                {
                    this.m_idServico = new Servico();

                    foreach (TJoin attribute in this.m_idServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idServico.connectionString = this.connectionString;
                            this.m_idServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idServico.selfFill();

                return this.m_idServico;
            }
        }

        [
         TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private ProdutoServico m_idProdutoServico = null;
        public ProdutoServico idProdutoServico
        {
            get
            {
                this.m_idProdutoServico = new ProdutoServico();

                if (this.m_idProdutoServico == null)
                {
                    foreach (TJoin attribute in this.m_idProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idProdutoServico.connectionString = this.connectionString;
                            this.m_idProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idProdutoServico.selfFill();

                return this.m_idProdutoServico;
            }
        }
    }
}