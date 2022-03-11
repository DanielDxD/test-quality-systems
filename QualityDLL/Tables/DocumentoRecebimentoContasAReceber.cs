using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("DocumentoRecebimentoContasAReceber")]
    public class DocumentoRecebimentoContasAReceber : TTableBase
    {
        [TColumn("idDocumentoRecebimentoContasAReceber", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idDocumentoRecebimentoContasAReceber = new TFieldInteger();
        public TFieldInteger idDocumentoRecebimentoContasAReceber
        {
            get { return this.m_idDocumentoRecebimentoContasAReceber; }
        }

        [TColumn("valorBase", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorBase = new TFieldDouble();
        public TFieldDouble valorBase
        {
            get { return this.m_valorBase; }
        }

        [TColumn("valorRecebido", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorRecebido = new TFieldDouble();
        public TFieldDouble valorRecebido
        {
            get { return this.m_valorRecebido; }
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

        [TColumn("idDocumentoRecebimento", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idDocumentoRecebimento = new TFieldInteger();
        public TFieldInteger idDocumentoRecebimento
        {
            get { return this.m_idDocumentoRecebimento; }
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
    }
}
