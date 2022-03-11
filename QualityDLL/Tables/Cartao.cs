using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("cartao")]
	public class Cartao: TTableBase
	{
        [TColumn("idCartao", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idCartao = new TFieldInteger();
        public TFieldInteger idCartao
        {
            get { return this.m_idCartao; }
        }

        [TColumn("numeroCartao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroCartao = new TFieldString();
        public TFieldString numeroCartao
        {
            get { return this.m_numeroCartao; }
        }

        [TColumn("dataEmissao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataEmissao = new TFieldDatetime();
        public TFieldDatetime dataEmissao
        {
            get { return this.m_dataEmissao; }
        }

        [TColumn("dataValidade", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataValidade = new TFieldDatetime();
        public TFieldDatetime dataValidade
        {
            get { return this.m_dataValidade; }
        }

        [TColumn("dataCancelamento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCancelamento = new TFieldDatetime();
        public TFieldDatetime dataCancelamento
        {
            get { return this.m_dataCancelamento; }
        }

        [TColumn("ativo", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_ativo = new TFieldString();
        public TFieldString ativo
        {
            get { return this.m_ativo; }
        }

        [TColumn("codigoBarras", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoBarras = new TFieldString();
        public TFieldString codigoBarras
        {
            get { return this.m_codigoBarras; }
        }

        [TColumn("idQuality", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_idQuality = new TFieldString();
        public TFieldString idQuality
        {
            get { return this.m_idQuality; }
        }

        [TColumn("numeroRFID", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroRFID = new TFieldString();
        public TFieldString numeroRFID
        {
            get { return this.m_numeroRFID; }
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
    }
}
