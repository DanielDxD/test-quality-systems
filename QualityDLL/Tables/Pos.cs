using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Pos")]
    public class Pos : TTableBase
    {
        [TColumn("idPos", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPos = new TFieldInteger();
        public TFieldInteger idPos
        {
            get { return this.m_idPos; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("impressora", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_impressora = new TFieldString();
        public TFieldString impressora
        {
            get { return this.m_impressora; }
        }

        [TColumn("fixarMenuPrePagoApp", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_fixarMenuPrePago = new TFieldBoolean();
        public TFieldBoolean fixarMenuPrePago
        {
            get { return this.m_fixarMenuPrePago; }
        }

        [
            TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })
        ]
        private PdvEstacao m_idPdvEstacao = null;
        public PdvEstacao pdvEstacao
        {
            get
            {
                if (this.m_idPdvEstacao == null)
                {
                    this.m_idPdvEstacao = new PdvEstacao();

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
