using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PdvCompraStatus")]
    public class PdvCompraStatus : TTableBase
    {
        [TColumn("idPdvCompraStatus", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPdvCompraStatus = new TFieldInteger();
        public TFieldInteger idPdvCompraStatus
        {
            get { return this.m_idPdvCompraStatus; }
        }

        [
            TColumn("idPdvCompra", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPdvCompra->idPdvCompra" })
        ]
        private PdvCompra m_pdvCompra = null;
        public PdvCompra pdvCompra
        {
            get
            {
                if (this.m_pdvCompra == null)
                {
                    this.m_pdvCompra = new PdvCompra();

                    foreach (TJoin attribute in this.m_pdvCompra.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_pdvCompra.connectionString = this.connectionString;
                            this.m_pdvCompra.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_pdvCompra.selfFill();
                return this.m_pdvCompra;
            }
        }

        [TColumn("data", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_data = new TFieldDatetime();
        public TFieldDatetime data
        {
            get { return this.m_data; }
        }

        [TColumn("statusVenda", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_statusVenda = new TFieldString();
        public TFieldString statusVenda
        {
            get { return this.m_statusVenda; }
        }

        [
              TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
              TJoin(new String[] { "idFuncionario->idFuncionario" })
          ]
        private Funcionario m_idFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_idFuncionario == null)
                {
                    this.m_idFuncionario = new Funcionario();

                    foreach (TJoin attribute in this.m_idFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idFuncionario.connectionString = this.connectionString;
                            this.m_idFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idFuncionario.selfFill();

                return this.m_idFuncionario;
            }
        }

    }
}
