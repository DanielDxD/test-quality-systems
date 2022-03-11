
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("PixTransacao")]
    public class PixTransacao : TTableBase
    {
        [TColumn("idPixTransacao", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdPixTransacao = new TFieldInteger();
        public TFieldInteger idPixTransacao
        {
            get { return this.m_IdPixTransacao; }
        }

        [
            TColumn("idPix", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPix->idPix" })
        ]
        private Pix m_IdPix = null;
        public Pix pix
        {
            get
            {
                if (this.m_IdPix == null)
                {
                    this.m_IdPix = new Pix();
                    foreach (TJoin attribute in this.m_IdPix.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPix.connectionString = this.connectionString;
                            this.m_IdPix.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdPix.selfFill();
                return this.m_IdPix;
            }
        }

        [TColumn("endToEndId", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_EndToEndId = new TFieldString();
        public TFieldString endToEndId
        {
            get { return this.m_EndToEndId; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDecimal m_Valor = new TFieldDecimal();
        public TFieldDecimal valor
        {
            get { return this.m_Valor; }
        }

        [TColumn("horario", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_Horario = new TFieldDatetime();
        public TFieldDatetime horario
        {
            get { return this.m_Horario; }
        }

        [TColumn("pagadorCpfCnpj", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_PagadorCpfCnpj = new TFieldString();
        public TFieldString pagadorCpfCnpj
        {
            get { return this.m_PagadorCpfCnpj; }
        }

        [TColumn("pagadorNome", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_PagadorNome = new TFieldString();
        public TFieldString pagadorNome
        {
            get { return this.m_PagadorNome; }
        }

    }
}
