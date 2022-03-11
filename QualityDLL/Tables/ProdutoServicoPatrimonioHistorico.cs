using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("ProdutoServicoPatrimonioHistorico")]
	public class ProdutoServicoPatrimonioHistorico : TTableBase
	{
		[TColumn("idProdutoServicoPatrimonioHistorico", System.Data.SqlDbType.BigInt, true, true)]
		private TFieldInteger m_idProdutoServicoPatrimonioHistorico = new TFieldInteger();
		public TFieldInteger idProdutoServicoPatrimonioHistorico
        {
			get{return this.m_idProdutoServicoPatrimonioHistorico; }
        }

        [TColumn("dataHistorico", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataHistorico = new TFieldDatetime();
        public TFieldDatetime dataHistorico
        {
            get { return this.m_dataHistorico; }
        }

        [TColumn("dataReferencia", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_dataReferencia = new TFieldString();
        public TFieldString dataReferencia
        {
            get { return this.m_dataReferencia; }
        }

        [TColumn("valorDepreciado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorDepreciado = new TFieldDouble();
        public TFieldDouble valorDepreciado
        {
            get { return this.m_valorDepreciado; }
        }

        [TColumn("valorAtual", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorAtual = new TFieldDouble();
        public TFieldDouble valorAtual
        {
            get { return this.m_valorAtual; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [
            TColumn("idProdutoServicoPatrimonio", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idProdutoServicoPatrimonio->idProdutoServicoPatrimonio" })
        ]
        private ProdutoServicoPatrimonio m_idProdutoServicoPatrimonio = null;
        public ProdutoServicoPatrimonio produtoServicoPatrimonio
        {
            get
            {
                if (this.m_idProdutoServicoPatrimonio == null)
                {
                    this.m_idProdutoServicoPatrimonio = new ProdutoServicoPatrimonio();

                    foreach (TJoin attribute in this.m_idProdutoServicoPatrimonio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idProdutoServicoPatrimonio.connectionString = this.connectionString;
                            this.m_idProdutoServicoPatrimonio.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idProdutoServicoPatrimonio.selfFill();

                return this.m_idProdutoServicoPatrimonio;
            }
        }      
	}
}
