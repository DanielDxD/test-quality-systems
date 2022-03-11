using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("empresaRelacionamentoCartaoMovimento")]
    public class EmpresaRelacionamentoCartaoMovimento : TTableBase
    {

        [TColumn("idEmpresaRelacionamentoCartaoMovimento", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idEmpresaRelacionamentoCartaoMovimento = new TFieldInteger();
        public TFieldInteger idEmpresaRelacionamentoCartaoMovimento
        {
            get { return this.m_idEmpresaRelacionamentoCartaoMovimento; }
        }

        [
            TColumn("idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao->idEmpresaRelacionamentoCartaoMovimento" })
        ]
        private EmpresaRelacionamentoCartaoMovimento m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao = null;
        public EmpresaRelacionamentoCartaoMovimento estornoDevolucao
        {
            get
            {
                if (this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao == null)
                {
                    this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao = new EmpresaRelacionamentoCartaoMovimento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao.selfFill();

                return this.m_idEmpresaRelacionamentoCartaoMovimentoEstornoDevolucao;
            }
        }

        [
            TColumn("idEmpresaRelacionamentoCartao", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idEmpresaRelacionamentoCartao->idEmpresaRelacionamentoCartao" })
        ]
        private EmpresaRelacionamentoCartao m_idEmpresaRelacionamentoCartao = null;
        public EmpresaRelacionamentoCartao empresaRelacionamentoCartao
        {
            get
            {
                if (this.m_idEmpresaRelacionamentoCartao == null)
                {
                    this.m_idEmpresaRelacionamentoCartao = new EmpresaRelacionamentoCartao();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamentoCartao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresaRelacionamentoCartao.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamentoCartao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamentoCartao.selfFill();

                return this.m_idEmpresaRelacionamentoCartao;
            }
        }


        [
            TColumn("idContaPagamentoMovimento", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idContaPagamentoMovimento->idContaPagamentoMovimento" })
        ]
        private ContaPagamentoMovimento m_idContaPagamentoMovimento = null;
        public ContaPagamentoMovimento contaPagamentoMovimento
        {
            get
            {
                if (this.m_idContaPagamentoMovimento == null)
                {
                    this.m_idContaPagamentoMovimento = new ContaPagamentoMovimento();

                    foreach (TJoin attribute in this.m_idContaPagamentoMovimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContaPagamentoMovimento.connectionString = this.connectionString;
                            this.m_idContaPagamentoMovimento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContaPagamentoMovimento.selfFill();

                return this.m_idContaPagamentoMovimento;
            }
        }

        [
            TColumn("idContasAReceber", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idContasAReceber->idContasAReceber" })
        ]
        private ContasAReceber m_idContasAReceber = null;
        public ContasAReceber contasAReceber
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
            TColumn("idPdvCompra", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private PdvCompra m_idPdvCompra = null;
        public PdvCompra pdvCompra
        {
            get
            {
                if (this.m_idPdvCompra == null)
                {
                    this.m_idPdvCompra = new PdvCompra();

                    foreach (TJoin attribute in this.m_idPdvCompra.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPdvCompra.connectionString = this.connectionString;
                            this.m_idPdvCompra.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPdvCompra.selfFill();

                return this.m_idPdvCompra;
            }
        }

        [TColumn("tipoMovimento", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_tipoMovimento = new TFieldString();
        public TFieldString tipoMovimento
        {
            get { return this.m_tipoMovimento; }
        }

        [TColumn("tipoOperacao", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_tipoOperacao = new TFieldString();
        public TFieldString tipoOperacao
        {
            get { return this.m_tipoOperacao; }
        }

        [TColumn("valorMovimento", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorMovimento = new TFieldDouble();
        public TFieldDouble valorMovimento
        {
            get { return this.m_valorMovimento; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [TColumn("dataMovimento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataMovimento = new TFieldDatetime();
        public TFieldDatetime dataMovimento
        {
            get { return this.m_dataMovimento; }
        }

        [
             TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, false, false),
             TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
         ]
        private PdvEstacao  m_idPdvEstacao = null;
        public PdvEstacao  pdvEstacao
        {
            get
            {
                if (this.m_idPdvEstacao == null)
                {
                    this.m_idPdvEstacao = new PdvEstacao ();

                    foreach (TJoin attribute in this.m_idPdvEstacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPdvEstacao.connectionString = this.connectionString;
                            this.m_idPdvEstacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPdvEstacao.selfFill();

                return this.m_idPdvEstacao;
            }
        }

    }
}
