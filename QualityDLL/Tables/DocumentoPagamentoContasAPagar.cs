using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("DocumentoPagamentoContasAPagar")]
    public class DocumentoPagamentoContasAPagar : TTableBase
    {
        [TColumn("idDocumentoPagamentoContasAPagar", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idDocumentoPagamentoContasAPagar = new TFieldInteger();
        public TFieldInteger idDocumentoPagamentoContasAPagar
        {
            get { return this.m_idDocumentoPagamentoContasAPagar; }
        }

        [TColumn("valorBase", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorBase = new TFieldDouble();
        public TFieldDouble valorBase
        {
            get { return this.m_valorBase; }
        }

        [TColumn("valorPago", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorPago = new TFieldDouble();
        public TFieldDouble valorPago
        {
            get { return this.m_valorPago; }
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

        [TColumn("idDocumentoPagamento", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idDocumentoPagamento = new TFieldInteger();
        public TFieldInteger idDocumentoPagamento
        {
            get {return this.m_idDocumentoPagamento;}
        }

        [
         TColumn("idContasAPagar", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idContasAPagar->idContasAPagar" })
        ]
        private ContasAPagar m_idContasAPagar = null;
        public ContasAPagar contasAPagar
        {
            get
            {
                if (this.m_idContasAPagar == null)
                {
                    this.m_idContasAPagar = new ContasAPagar();

                    foreach (TJoin attribute in this.m_idContasAPagar.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idContasAPagar.connectionString = this.connectionString;
                            this.m_idContasAPagar.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idContasAPagar.selfFill();

                return this.m_idContasAPagar;
            }
        }
    }
}
