using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvCompraCupomItem")]
    public class PdvCompraCupomItem : TTableBase
    {
        [TColumn("idPdvCompraCupomItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvCompraCupomItem = new TFieldInteger();
        public TFieldInteger idPdvCompraCupomItem
        {
            get { return this.m_idPdvCompraCupomItem; }
        }

        [
            TColumn("idPdvCompraCupom", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvCompraCupom->idPdvCompraCupom" })
        ]
        private PdvCompraCupom m_pdvCompraCupom = null;
        public PdvCompraCupom pdvCompraCupom
        {
            get
            {
                if (this.m_pdvCompraCupom == null)
                {
                    this.m_pdvCompraCupom = new PdvCompraCupom();

                    foreach (TJoin attribute in this.m_pdvCompraCupom.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvCompraCupom.connectionString = this.connectionString;
                            this.m_pdvCompraCupom.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvCompraCupom.selfFill();
                return this.m_pdvCompraCupom;
            }
        }

        [
            TColumn("idRequisicaoInternaProdutoServico", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idRequisicaoInternaProdutoServico->idRequisicaoInternaProdutoServico" })
        ]
        private RequisicaoInternaProdutoServico m_requisicaoInternaProdutoServico = null;
        public RequisicaoInternaProdutoServico requisicaoInternaProdutoServico
        {
            get
            {
                if (this.m_requisicaoInternaProdutoServico == null)
                {
                    this.m_requisicaoInternaProdutoServico = new RequisicaoInternaProdutoServico();

                    foreach (TJoin attribute in this.m_requisicaoInternaProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_requisicaoInternaProdutoServico.connectionString = this.connectionString;
                            this.m_requisicaoInternaProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_requisicaoInternaProdutoServico.selfFill();
                return this.m_requisicaoInternaProdutoServico;
            }
        }

        [
            TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private ProdutoServico m_produtoServico = null;
        public ProdutoServico produtoServico
        {
            get
            {
                if (this.m_produtoServico == null)
                {
                    this.m_produtoServico = new ProdutoServico();

                    foreach (TJoin attribute in this.m_produtoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_produtoServico.connectionString = this.connectionString;
                            this.m_produtoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_produtoServico.selfFill();
                return this.m_produtoServico;
            }
        }

        [TColumn("quantidade", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_quantidade = new TFieldDouble();
        public TFieldDouble quantidade
        {
            get { return this.m_quantidade; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("desconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_desconto = new TFieldDouble();
        public TFieldDouble desconto
        {
            get { return this.m_desconto; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [
            TColumn("idRequisicaoInternaComposicao", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idRequisicaoInternaComposicao->idRequisicaoInterna" })
        ]
        private RequisicaoInterna m_idRequisicaoInternaComposicao = null;
        public RequisicaoInterna requisicaoInternaComposicao
        {
            get
            {
                if (this.m_idRequisicaoInternaComposicao == null)
                {
                    this.m_idRequisicaoInternaComposicao = new RequisicaoInterna();

                    foreach (TJoin attribute in this.m_idRequisicaoInternaComposicao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRequisicaoInternaComposicao.connectionString = this.connectionString;
                            this.m_idRequisicaoInternaComposicao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRequisicaoInternaComposicao.selfFill();
                return this.m_idRequisicaoInternaComposicao;
            }
        }

    }
}
