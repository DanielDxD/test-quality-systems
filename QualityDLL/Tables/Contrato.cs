
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Contrato")]
    public class Contrato : TTableBase
    {
        [TColumn("idContrato", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdContrato = new TFieldInteger();
        public TFieldInteger idContrato
        {
            get { return this.m_IdContrato; }
        }

        [TColumn("idContratoTipo", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idContratoTipo->idContratoTipo" })]
        private ContratoTipo m_IdContratoTipo = null;
        public ContratoTipo contratoTipo
        {
            get
            {
                if (this.m_IdContratoTipo == null)
                {
                    this.m_IdContratoTipo = new ContratoTipo();
                    foreach (TJoin attribute in this.m_IdContratoTipo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContratoTipo.connectionString = this.connectionString;
                            this.m_IdContratoTipo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContratoTipo.selfFill();
                return this.m_IdContratoTipo;
            }
        }

        [TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })]
        private EmpresaRelacionamento m_IdEmpresaRelacionamento = null;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get
            {
                if (this.m_IdEmpresaRelacionamento == null)
                {
                    this.m_IdEmpresaRelacionamento = new EmpresaRelacionamento();
                    foreach (TJoin attribute in this.m_IdEmpresaRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdEmpresaRelacionamento.connectionString = this.connectionString;
                            this.m_IdEmpresaRelacionamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdEmpresaRelacionamento.selfFill();
                return this.m_IdEmpresaRelacionamento;
            }
        }

        [TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idFuncionario->idFuncionario" })]
        private Funcionario m_IdFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_IdFuncionario == null)
                {
                    this.m_IdFuncionario = new Funcionario();
                    foreach (TJoin attribute in this.m_IdFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdFuncionario.connectionString = this.connectionString;
                            this.m_IdFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdFuncionario.selfFill();
                return this.m_IdFuncionario;
            }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_Valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_Valor; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_ValorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_ValorDesconto; }
        }

        [TColumn("recorrencia", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Recorrencia = new TFieldInteger();
        public TFieldInteger recorrencia
        {
            get { return this.m_Recorrencia; }
        }

        [TColumn("dataInicial", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataInicial = new TFieldDatetime();
        public TFieldDatetime dataInicial
        {
            get { return this.m_DataInicial; }
        }

        [TColumn("dataFinal", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataFinal = new TFieldDatetime();
        public TFieldDatetime dataFinal
        {
            get { return this.m_DataFinal; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_DataCancelamento; }
        }

        [TColumn("observacaoCancelamento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_ObservacaoCancelamento = new TFieldString();
        public TFieldString observacaoCancelamento
        {
            get { return this.m_ObservacaoCancelamento; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_Observacao; }
        }

        [TColumn("gerarCobranca", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_gerarCobranca = new TFieldBoolean();
        public TFieldBoolean gerarCobranca
        {
            get { return this.m_gerarCobranca; }
        }
    }
}
