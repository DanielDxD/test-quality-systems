using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ExportacaoContabil")]
    public class ExportacaoContabil : TTableBase
    {
        [TColumn("idExportacaoContabil", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idExportacaoContabil = new TFieldInteger();
        public TFieldInteger idExportacaoContabil
        {
            get { return this.m_idExportacaoContabil; }
        }

        [TColumn("provisiona", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_provisiona = new TFieldString();
        public TFieldString provisiona
        {
            get { return this.m_provisiona; }
        }

        [TColumn("tipoRetencao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipoRetencao = new TFieldString();
        public TFieldString tipoRetencao
        {
            get { return this.m_tipoRetencao; }
        }

        [TColumn("codigoContabil", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoContabil = new TFieldString();
        public TFieldString codigoContabil
        {
            get { return this.m_codigoContabil; }
        }

        [
            TColumn("idNaturezaOperacao", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idNaturezaOperacao->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_idNaturezaOperacao = null;
        public NaturezaOperacao naturezaOperacao
        {
            get
            {
                if (this.m_idNaturezaOperacao == null)
                {
                    this.m_idNaturezaOperacao = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_idNaturezaOperacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idNaturezaOperacao.connectionString = this.connectionString;
                            this.m_idNaturezaOperacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idNaturezaOperacao.selfFill();

                return this.m_idNaturezaOperacao;
            }
        }

        [
            TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_idDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_idDepartamento == null)
                {
                    this.m_idDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_idDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDepartamento.connectionString = this.connectionString;
                            this.m_idDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDepartamento.selfFill();

                return this.m_idDepartamento;
            }
        }

        [
            TColumn("idEmpresaRelacionamento", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idEmpresaRelacionamento->idEmpresaRelacionamento" })
        ]
        private EmpresaRelacionamento m_idEmpresaRelacionamento = null;
        public EmpresaRelacionamento empresaRelacionamento
        {
            get
            {
                if (this.m_idEmpresaRelacionamento == null)
                {
                    this.m_idEmpresaRelacionamento = new EmpresaRelacionamento();

                    foreach (TJoin attribute in this.m_idEmpresaRelacionamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresaRelacionamento.connectionString = this.connectionString;
                            this.m_idEmpresaRelacionamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresaRelacionamento.selfFill();

                return this.m_idEmpresaRelacionamento;
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
