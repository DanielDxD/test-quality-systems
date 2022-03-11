using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("MovimentoFiscal")]
    public class MovimentoFiscal : TTableBase
    {
        [TColumn("idMovimentoFiscal", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idMovimentoFiscal = new TFieldInteger();
        public TFieldInteger idMovimentoFiscal
        {
            get { return this.m_idMovimentoFiscal; }
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

        [TColumn("serie", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_serie = new TFieldInteger();
        public TFieldInteger serie
        {
            get { return this.m_serie; }
        }

        [TColumn("xmlEnvio", System.Data.SqlDbType.VarBinary, false, false)]
        private TFieldVarbinary m_xmlEnvio = new TFieldVarbinary();
        public TFieldVarbinary xmlEnvio
        {
            get { return this.m_xmlEnvio; }
        }

        [TColumn("xmlRetorno", System.Data.SqlDbType.VarBinary, false, false)]
        private TFieldVarbinary m_xmlRetorno = new TFieldVarbinary();
        public TFieldVarbinary xmlRetorno
        {
            get { return this.m_xmlRetorno; }
        }

        [TColumn("emitida", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_emitida = new TFieldBoolean();
        public TFieldBoolean emitida
        {
            get { return this.m_emitida; }
        }

        [TColumn("cancelada", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_cancelada = new TFieldBoolean();
        public TFieldBoolean cancelada
        {
            get { return this.m_cancelada; }
        }

        [TColumn("dataEmissao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataEmissao = new TFieldDatetime();
        public TFieldDatetime dataEmissao
        {
            get { return this.m_dataEmissao; }
        }

        [TColumn("chave", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_chave = new TFieldString();
        public TFieldString chave
        {
            get { return this.m_chave; }
        }

        [TColumn("cstat", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_cstat = new TFieldInteger();
        public TFieldInteger cstat
        {
            get { return this.m_cstat; }
        }

        [TColumn("xMotivo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_xMotivo = new TFieldString();
        public TFieldString xMotivo
        {
            get { return this.m_xMotivo; }
        }

        [TColumn("dhRecbto", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dhRecbto = new TFieldDatetime();
        public TFieldDatetime dhRecbto
        {
            get { return this.m_dhRecbto; }
        }

        [TColumn("ambiente", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_ambiente = new TFieldInteger();
        public TFieldInteger ambiente
        {
            get { return this.m_ambiente; }
        }

        [TColumn("contingencia", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_contingencia = new TFieldBoolean();
        public TFieldBoolean contingencia
        {
            get { return this.m_contingencia; }
        }

        [TColumn("numero", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldBigInteger m_numero = new TFieldBigInteger();
        public TFieldBigInteger numero
        {
            get { return this.m_numero; }
        }

        [TColumn("tipoDocumento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_tipoDocumento = new TFieldInteger();
        public TFieldInteger tipoDocumento
        {
            get { return this.m_tipoDocumento; }
        }

        [TColumn("formaPagamento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_formaPagamento = new TFieldString();
        public TFieldString formaPagamento
        {
            get { return this.m_formaPagamento; }
        }


    }
}
