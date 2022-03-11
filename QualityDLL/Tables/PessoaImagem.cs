using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("PessoaImagem")]
    public class PessoaImagem : TTableBase
    {
        [TColumn("idPessoaImagem", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idPessoaImagem = new TFieldInteger();
        public TFieldInteger idPessoaImagem
        {
            get { return this.m_idPessoaImagem; }
        }

        [TColumn("imagem", System.Data.SqlDbType.Image, false, false)]
        private TFieldBlob m_imagem = new TFieldBlob();
        public TFieldBlob imagem
        {
            get { return this.m_imagem; }
        }

        [
         TColumn("idPessoa", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idPessoa->idPessoa" })
        ]
        private Pessoa m_idPessoa = null;
        public Pessoa pessoa
        {
            get
            {
                if (this.m_idPessoa == null)
                {
                    this.m_idPessoa = new Pessoa();

                    foreach (TJoin attribute in this.m_idPessoa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idPessoa.connectionString = this.connectionString;
                            this.m_idPessoa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPessoa.selfFill();

                return this.m_idPessoa;
            }
        }

        [
         TColumn("idTipoImagem", System.Data.SqlDbType.Int, false, false),
         TJoin(new String[] { "idTipoImagem->idTipoImagem" })
        ]
        private TipoImagem m_idTipoImagem = null;
        public TipoImagem tipoImagem
        {
            get
            {
                if (this.m_idTipoImagem == null)
                {
                    this.m_idTipoImagem = new TipoImagem();

                    foreach (TJoin attribute in this.m_idTipoImagem.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTipoImagem.connectionString = this.connectionString;
                            this.m_idTipoImagem.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTipoImagem.selfFill();

                return this.m_idTipoImagem;
            }
        }
    }
}