using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Servico")]
    public class Servico : TTableBase
    {
        [TColumn("idServico", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idServico = new TFieldInteger();
        public TFieldInteger idServico
        {
            get { return this.m_idServico; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("aliquotaIss", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaIss = new TFieldDouble();
        public TFieldDouble aliquotaIss
        {
            get { return this.m_aliquotaIss; }
        }

        [
         TColumn("idTipoMovimento", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoMovimento->idTipoMovimento" })
        ]
        private TipoMovimento m_idTipoMovimento = null;
        public TipoMovimento tipoMovimento
        {
            get
            {
                if (this.m_idTipoMovimento == null)
                {
                    this.m_idTipoMovimento = new TipoMovimento();

                    foreach (TJoin attribute in this.m_idTipoMovimento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoMovimento.connectionString = this.connectionString;
                            this.m_idTipoMovimento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoMovimento.selfFill();

                return this.m_idTipoMovimento;
            }
        }
    }
}