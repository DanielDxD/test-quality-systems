using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("EventoNfe")]
    public class EventoNFe : TTableBase
    {
        [TColumn("idEventoNFe", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idEventoNFe = new TFieldInteger();
        public TFieldInteger idEventoNFe
        {
            get { return this.m_idEventoNFe; }
        }

        [
            TColumn("idMovimentoFiscal", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idMovimentoFiscal->idMovimentoFiscal" })
        ]
        private MovimentoFiscal m_idMovimentoFiscal = null;
        public MovimentoFiscal movimentoFiscal
        {
            get
            {
                if (this.m_idMovimentoFiscal == null)
                {
                    this.m_idMovimentoFiscal = new MovimentoFiscal();

                    foreach (TJoin attribute in this.m_idMovimentoFiscal.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idMovimentoFiscal.connectionString = this.connectionString;
                            this.m_idMovimentoFiscal.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idMovimentoFiscal.selfFill();

                return this.m_idMovimentoFiscal;
            }
        }

        [TColumn("nSeqEvento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nSeqEvento = new TFieldString();
        public TFieldString nSeqEvento
        {
            get { return this.m_nSeqEvento; }
        }

        [TColumn("dhEvento", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dhEvento = new TFieldDatetime();
        public TFieldDatetime dhEvento
        {
            get { return this.m_dhEvento; }
        }

        [TColumn("descEvento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descEvento = new TFieldString();
        public TFieldString descEvento
        {
            get { return this.m_descEvento; }
        }

        [TColumn("nProt", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nProt = new TFieldString();
        public TFieldString nProt
        {
            get { return this.m_nProt; }
        }

        [TColumn("xCorrecao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_xCorrecao = new TFieldString();
        public TFieldString xCorrecao
        {
            get { return this.m_xCorrecao; }
        }

        [TColumn("xMotivo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_xMotivo = new TFieldString();
        public TFieldString xMotivo
        {
            get { return this.m_xMotivo; }
        }

        [TColumn("cstat", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_cstat = new TFieldInteger();
        public TFieldInteger cstat
        {
            get { return this.m_cstat; }
        }

        [TColumn("inutilizacao_nnfini", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_inutilizacao_nnfini = new TFieldInteger();
        public TFieldInteger inutilizacao_nnfini
        {
            get { return this.m_inutilizacao_nnfini; }
        }

        [TColumn("inutilizacao_nnffin", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_inutilizacao_nnffin = new TFieldInteger();
        public TFieldInteger inutilizacao_nnffin
        {
            get { return this.m_inutilizacao_nnffin; }
        }

        [TColumn("inutilizacao_serie", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_inutilizacao_serie = new TFieldInteger();
        public TFieldInteger inutilizacao_serie
        {
            get { return this.m_inutilizacao_serie; }
        }

        [TColumn("tipoEvento", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_tipoEvento = new TFieldInteger();
        public TFieldInteger tipoEvento
        {
            get { return this.m_tipoEvento; }
        }

        [TColumn("xml", System.Data.SqlDbType.VarBinary, false, false)]
        private TFieldVarbinary m_xml = new TFieldVarbinary();
        public TFieldVarbinary xml
        {
            get { return this.m_xml; }
        }

        [
            TColumn("idEmpresa", System.Data.SqlDbType.BigInt, false, false),
        ]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [
            TColumn("ambiente", System.Data.SqlDbType.Int, false, false),
        ]
        private TFieldInteger m_ambiente = new TFieldInteger();
        public TFieldInteger ambiente
        {
            get { return this.m_ambiente; }
        }

        [
            TColumn("tipoDocumento", System.Data.SqlDbType.Int, false, false),
        ]
        private TFieldInteger m_tipoDocumento = new TFieldInteger();
        public TFieldInteger tipoDocumento
        {
            get { return this.m_tipoDocumento; }
        }
    }
}
