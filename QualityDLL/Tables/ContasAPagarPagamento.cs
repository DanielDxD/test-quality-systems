using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContasAPagarPagamento")]
    public class ContasAPagarPagamento : TTableBase
    {
        [TColumn("idContasAPagarPagamento", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContasAPagarPagamento = new TFieldInteger();
        public TFieldInteger idContasAPagarPagamento
        {
            get { return this.m_idContasAPagarPagamento; }
        }

        [TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataMovimento = new TFieldDatetime();
        public TFieldDatetime dataMovimento
        {
            get { return this.m_dataMovimento; }
        }

        [TColumn("valorPrincipal", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorPrincipal = new TFieldDouble();
        public TFieldDouble valorPrincipal
        {
            get { return this.m_valorPrincipal; }
        }

        [TColumn("valorMulta", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorMulta = new TFieldDouble();
        public TFieldDouble valorMulta
        {
            get { return this.m_valorMulta; }
        }

        [TColumn("valorJuros", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorJuros = new TFieldDouble();
        public TFieldDouble valorJuros
        {
            get { return this.m_valorJuros; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [TColumn("valorCM", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorCM = new TFieldDouble();
        public TFieldDouble valorCM
        {
            get { return this.m_valorCM; }
        }

        [TColumn("idContasAPagar", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idContasAPagar = new TFieldInteger();
        public TFieldInteger idContasAPagar
        {
            get { return this.m_idContasAPagar; }
        }

        [TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idFuncionario = new TFieldInteger();
        public TFieldInteger idFuncionario
        {
            get { return this.m_idFuncionario; }
        }

        [TColumn("valorINSSRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorINSSRetido = new TFieldDouble();
        public TFieldDouble valorINSSRetido
        {
            get { return this.m_valorINSSRetido; }
        }

        [TColumn("valorISSRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorISSRetido = new TFieldDouble();
        public TFieldDouble valorISSRetido
        {
            get { return this.m_valorISSRetido; }
        }

        [TColumn("valorIRRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorIRRetido = new TFieldDouble();
        public TFieldDouble valorIRRetido
        {
            get { return this.m_valorIRRetido; }
        }

        [TColumn("valorPISRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorPISRetido = new TFieldDouble();
        public TFieldDouble valorPISRetido
        {
            get { return this.m_valorPISRetido; }
        }

        [TColumn("valorCOFINSRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorCOFINSRetido = new TFieldDouble();
        public TFieldDouble valorCOFINSRetido
        {
            get { return this.m_valorCOFINSRetido; }
        }

        [TColumn("valorCSLLRetido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorCSLLRetido = new TFieldDouble();
        public TFieldDouble valorCSLLRetido
        {
            get { return this.m_valorCSLLRetido; }
        }

        [TColumn("idDocumentoPagamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idDocumentoPagamento = new TFieldInteger();
        public TFieldInteger idDocumentoPagamento
        {
            get { return this.m_idDocumentoPagamento; }
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
         TColumn("idContaPagamento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idContaPagamento->idContaPagamento" })
        ]
        private ContaPagamento m_idContaPagamento = null;
        public ContaPagamento contaPagamento
        {
            get
            {
                if (this.m_idContaPagamento == null)
                {
                    this.m_idContaPagamento = new ContaPagamento();

                    foreach (TJoin attribute in this.m_idContaPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContaPagamento.connectionString = this.connectionString;
                            this.m_idContaPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContaPagamento.selfFill();

                return this.m_idContaPagamento;
            }
        }
    }
}