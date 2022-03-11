
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("RequisicaoInternaProducao")]
    public class RequisicaoInternaProducao : TTableBase
    {
        [TColumn("idRequisicaoInternaProducao", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdRequisicaoInternaProducao = new TFieldInteger();
        public TFieldInteger idRequisicaoInternaProducao
        {
            get { return this.m_IdRequisicaoInternaProducao; }
        }

        [TColumn("idRequisicaoInternaEntrada", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idRequisicaoInternaEntrada->idRequisicaoInterna" })]
        private RequisicaoInterna m_IdRequisicaoInternaEntrada = null;
        public RequisicaoInterna requisicaoInternaEntrada
        {
            get
            {
                if (this.m_IdRequisicaoInternaEntrada == null)
                {
                    this.m_IdRequisicaoInternaEntrada = new RequisicaoInterna();
                    foreach (TJoin attribute in this.m_IdRequisicaoInternaEntrada.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdRequisicaoInternaEntrada.connectionString = this.connectionString;
                            this.m_IdRequisicaoInternaEntrada.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdRequisicaoInternaEntrada.selfFill();
                return this.m_IdRequisicaoInternaEntrada;
            }
        }

        [TColumn("idRequisicaoInternaSaida", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idRequisicaoInternaSaida->idRequisicaoInterna" })]
        private RequisicaoInterna m_IdRequisicaoInternaSaida = null;
        public RequisicaoInterna requisicaoInternaSaida
        {
            get
            {
                if (this.m_IdRequisicaoInternaSaida == null)
                {
                    this.m_IdRequisicaoInternaSaida = new RequisicaoInterna();
                    foreach (TJoin attribute in this.m_IdRequisicaoInternaSaida.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdRequisicaoInternaSaida.connectionString = this.connectionString;
                            this.m_IdRequisicaoInternaSaida.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdRequisicaoInternaSaida.selfFill();
                return this.m_IdRequisicaoInternaSaida;
            }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

    }
}
