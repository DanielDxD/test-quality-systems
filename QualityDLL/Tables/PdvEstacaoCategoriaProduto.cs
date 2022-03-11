
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("PdvEstacaoCategoriaProduto")]
    public class PdvEstacaoCategoriaProduto : TTableBase
    {
        [TColumn("idPdvEstacaoCategoriaProduto", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdPdvEstacaoCategoriaProduto = new TFieldInteger();
        public TFieldInteger idPdvEstacaoCategoriaProduto
        {
            get { return this.m_IdPdvEstacaoCategoriaProduto; }
        }

        [TColumn("idPdvEstacaoCategoria", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idPdvEstacaoCategoria->idPdvEstacaoCategoria" })]
        private PdvEstacaoCategoria m_IdPdvEstacaoCategoria = null;
        public PdvEstacaoCategoria pdvEstacaoCategoria
        {
            get
            {
                if (this.m_IdPdvEstacaoCategoria == null)
                {
                    this.m_IdPdvEstacaoCategoria = new PdvEstacaoCategoria();
                    foreach (TJoin attribute in this.m_IdPdvEstacaoCategoria.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPdvEstacaoCategoria.connectionString = this.connectionString;
                            this.m_IdPdvEstacaoCategoria.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdPdvEstacaoCategoria.selfFill();
                return this.m_IdPdvEstacaoCategoria;
            }
        }

        [TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idProdutoServico->idProdutoServico" })]
        private ProdutoServico m_IdProdutoServico = null;
        public ProdutoServico produtoServico
        {
            get
            {
                if (this.m_IdProdutoServico == null)
                {
                    this.m_IdProdutoServico = new ProdutoServico();
                    foreach (TJoin attribute in this.m_IdProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdProdutoServico.connectionString = this.connectionString;
                            this.m_IdProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdProdutoServico.selfFill();
                return this.m_IdProdutoServico;
            }
        }

        [TColumn("ordem", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Ordem = new TFieldInteger();
        public TFieldInteger ordem
        {
            get { return this.m_Ordem; }
        }

    }
}
