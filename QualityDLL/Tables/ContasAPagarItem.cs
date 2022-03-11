using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("ContasAPagarItem")]
    public class ContasAPagarItem : TTableBase
    {
        [TColumn("idContasAPagarItem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idContasAPagarItem = new TFieldInteger();
        public TFieldInteger idContasAPagarItem
        {
            get { return this.m_idContasAPagarItem; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_valor; }
        }

        [TColumn("valorDesconto", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDesconto = new TFieldDouble();
        public TFieldDouble valorDesconto
        {
            get { return this.m_valorDesconto; }
        }

        [
         TColumn("idMovimentoManual", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idMovimentoManual->idMovimentoManual" })
        ]
        private MovimentoManual m_idMovimentoManual = null;
        public MovimentoManual movimentoManual
        {
            get
            {
                if (this.m_idMovimentoManual == null)
                {
                    this.m_idMovimentoManual = new MovimentoManual();

                    foreach (TJoin attribute in this.m_idMovimentoManual.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idMovimentoManual.connectionString = this.connectionString;
                            this.m_idMovimentoManual.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idMovimentoManual.selfFill();

                return this.m_idMovimentoManual;
            }
        }

        [
         TColumn("idNotaFiscal", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idNotaFiscal->idNotaFiscalE" })
        ]
        private NotaFiscalE m_idNotaFiscal = null;
        public NotaFiscalE notaFiscal
        {
            get
            {
                if (this.m_idNotaFiscal == null)
                {
                    this.m_idNotaFiscal = new NotaFiscalE();

                    foreach (TJoin attribute in this.m_idNotaFiscal.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idNotaFiscal.connectionString = this.connectionString;
                            this.m_idNotaFiscal.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idNotaFiscal.selfFill();

                return this.m_idNotaFiscal;
            }
        }

        [TColumn("idContasAPagar", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idContasAPagar = new TFieldInteger();
        public TFieldInteger idContasAPagar
        {
            get { return this.m_idContasAPagar; }
        }

        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idNaturezaOperacao = new TFieldInteger();
        public TFieldInteger idNaturezaOperacao
        {
            get { return this.m_idNaturezaOperacao; }
        }

        [TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldInteger m_idDepartamento = new TFieldInteger();
        public TFieldInteger idDepartamento
        {
            get { return this.m_idDepartamento; }
        }
    }
}