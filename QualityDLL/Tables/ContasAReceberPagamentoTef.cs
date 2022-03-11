
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("ContasAReceberPagamentoTef")]
    public class ContasAReceberPagamentoTef : TTableBase
    {
        [TColumn("idContasAReceberPagamentoTef", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdContasAReceberPagamentoTef = new TFieldInteger();
        public TFieldInteger idContasAReceberPagamentoTef
        {
            get { return this.m_IdContasAReceberPagamentoTef; }
        }

        [
            TColumn("idContasAReceberPagamento", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idContasAReceberPagamento->idContasAReceberPagamento" })
        ]
        private ContasAReceberPagamento m_IdContasAReceberPagamento = null;
        public ContasAReceberPagamento contasAReceberPagamento
        {
            get
            {
                if (this.m_IdContasAReceberPagamento == null)
                {
                    this.m_IdContasAReceberPagamento = new ContasAReceberPagamento();
                    foreach (TJoin attribute in this.m_IdContasAReceberPagamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContasAReceberPagamento.connectionString = this.connectionString;
                            this.m_IdContasAReceberPagamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContasAReceberPagamento.selfFill();
                return this.m_IdContasAReceberPagamento;
            }
        }

        [TColumn("dataTransacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataTransacao = new TFieldDatetime();
        public TFieldDatetime dataTransacao
        {
            get { return this.m_DataTransacao; }
        }

        [TColumn("codigoAutorizacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_CodigoAutorizacao = new TFieldString();
        public TFieldString codigoAutorizacao
        {
            get { return this.m_CodigoAutorizacao; }
        }

        [TColumn("bandeira", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Bandeira = new TFieldString();
        public TFieldString bandeira
        {
            get { return this.m_Bandeira; }
        }

        [TColumn("cartaoNumero", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_CartaoNumero = new TFieldString();
        public TFieldString cartaoNumero
        {
            get { return this.m_CartaoNumero; }
        }

        [TColumn("transacaoId", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_TransacaoId = new TFieldString();
        public TFieldString transacaoId
        {
            get { return this.m_TransacaoId; }
        }

        [TColumn("serviceType", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_ServiceType = new TFieldInteger();
        public TFieldInteger serviceType
        {
            get { return this.m_ServiceType; }
        }

        [TColumn("tipoPagamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_TipoPagamento = new TFieldInteger();
        public TFieldInteger tipoPagamento
        {
            get { return this.m_TipoPagamento; }
        }

        [TColumn("parcelas", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Parcelas = new TFieldInteger();
        public TFieldInteger parcelas
        {
            get { return this.m_Parcelas; }
        }

        [TColumn("tipoParcelamento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_TipoParcelamento = new TFieldInteger();
        public TFieldInteger tipoParcelamento
        {
            get { return this.m_TipoParcelamento; }
        }

        [TColumn("funcionario", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Funcionario = new TFieldString();
        public TFieldString funcionario
        {
            get { return this.m_Funcionario; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_Valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_Valor; }
        }

        [TColumn("isApproved", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_IsApproved = new TFieldBoolean();
        public TFieldBoolean isApproved
        {
            get { return this.m_IsApproved; }
        }

    }
}
