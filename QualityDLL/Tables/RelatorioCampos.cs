using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("RelatorioCampos")]
    public class RelatorioCampos : TTableBase
    {
        [TColumn("idRelatorioCampo", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idRelatorioCampo = new TFieldInteger();
        public TFieldInteger idRelatorioCampo
        {
            get { return this.m_idRelatorioCampo; }
        }

        [TColumn("nome", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nome = new TFieldString();
        public TFieldString nome
        {
            get { return this.m_nome; }
        }

        [TColumn("tipo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipo = new TFieldString();
        public TFieldString tipo
        {
            get { return this.m_tipo; }
        }

        [TColumn("campo", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_campo = new TFieldBoolean();
        public TFieldBoolean campo
        {
            get { return this.m_campo; }
        }

        [TColumn("cantoBorda", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_cantoBorda = new TFieldInteger();
        public TFieldInteger cantoBorda
        {
            get { return this.m_cantoBorda; }
        }

        [TColumn("linha", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_linha = new TFieldString();
        public TFieldString linha
        {
            get { return this.m_linha; }
        }

        [TColumn("coluna", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_coluna = new TFieldString();
        public TFieldString coluna
        {
            get { return this.m_coluna; }
        }

        [TColumn("largura", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_largura = new TFieldString();
        public TFieldString largura
        {
            get { return this.m_largura; }
        }

        [TColumn("altura", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_altura = new TFieldString();
        public TFieldString altura
        {
            get { return this.m_altura; }
        }

        [TColumn("valor", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_valor = new TFieldString();
        public TFieldString valor
        {
            get { return this.m_valor; }
        }

        [TColumn("formato", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_formato = new TFieldString();
        public TFieldString formato
        {
            get { return this.m_formato; }
        }

        [TColumn("condicao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_condicao = new TFieldString();
        public TFieldString condicao
        {
            get { return this.m_condicao; }
        }

        [TColumn("fonteNome", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_fonteNome = new TFieldString();
        public TFieldString fonteNome
        {
            get { return this.m_fonteNome; }
        }

        [TColumn("fonteTamanho", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_fonteTamanho = new TFieldInteger();
        public TFieldInteger fonteTamanho
        {
            get { return this.m_fonteTamanho; }
        }

        [TColumn("fonteEstilo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_fonteEstilo = new TFieldString();
        public TFieldString fonteEstilo
        {
            get { return this.m_fonteEstilo; }
        }

        [TColumn("fonteCor", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_fonteCor = new TFieldString();
        public TFieldString fonteCor
        {
            get { return this.m_fonteCor; }
        }

        [TColumn("alinhamento", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_alinhamento = new TFieldString();
        public TFieldString alinhamento
        {
            get { return this.m_alinhamento; }
        }

        [
         TColumn("idRelatorioBanda", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idRelatorioBanda->idRelatorioBanda" })
        ]
        private RelatorioBandas m_idRelatorioBanda = null;
        public RelatorioBandas idRelatorioBanda
        {
            get
            {
                if (this.m_idRelatorioBanda == null)
                {
                    this.m_idRelatorioBanda = new RelatorioBandas();

                    foreach (TJoin attribute in this.m_idRelatorioBanda.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idRelatorioBanda.connectionString = this.connectionString;
                            this.m_idRelatorioBanda.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idRelatorioBanda.selfFill();

                return this.m_idRelatorioBanda;
            }
        }
    }
}
