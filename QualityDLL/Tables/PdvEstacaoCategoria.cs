
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("PdvEstacaoCategoria")]
    public class PdvEstacaoCategoria : TTableBase
    {
        [TColumn("idPdvEstacaoCategoria", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdPdvEstacaoCategoria = new TFieldInteger();
        public TFieldInteger idPdvEstacaoCategoria
        {
            get { return this.m_IdPdvEstacaoCategoria; }
        }

        [TColumn("idPdvEstacao", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idPdvEstacao->idPdvEstacao" })]
        private PdvEstacao m_IdPdvEstacao = null;
        public PdvEstacao pdvEstacao
        {
            get
            {
                if (this.m_IdPdvEstacao == null)
                {
                    this.m_IdPdvEstacao = new PdvEstacao();
                    foreach (TJoin attribute in this.m_IdPdvEstacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPdvEstacao.connectionString = this.connectionString;
                            this.m_IdPdvEstacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdPdvEstacao.selfFill();
                return this.m_IdPdvEstacao;
            }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("icone", System.Data.SqlDbType.Binary, false, false)]
        private TFieldVarbinary m_Icone = new TFieldVarbinary();
        public TFieldVarbinary icone
        {
            get { return this.m_Icone; }
        }

        [TColumn("idPdvEstacaoCategoriaPai", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idPdvEstacaoCategoriaPai->idPdvEstacaoCategoria" })]
        private PdvEstacaoCategoria m_IdPdvEstacaoCategoriaPai = null;
        public PdvEstacaoCategoria pdvEstacaoCategoriaPai
        {
            get
            {
                if (this.m_IdPdvEstacaoCategoriaPai == null)
                {
                    this.m_IdPdvEstacaoCategoriaPai = new PdvEstacaoCategoria();
                    foreach (TJoin attribute in this.m_IdPdvEstacaoCategoriaPai.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdPdvEstacaoCategoriaPai.connectionString = this.connectionString;
                            this.m_IdPdvEstacaoCategoriaPai.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdPdvEstacaoCategoriaPai.selfFill();
                return this.m_IdPdvEstacaoCategoriaPai;
            }
        }

    }
}
