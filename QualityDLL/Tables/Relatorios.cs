using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Relatorios")]
    public class Relatorios : TTableBase
    {
        [TColumn("idRelatorio", System.Data.SqlDbType.Int, true, false)]
        private TFieldInteger m_idRelatorio = new TFieldInteger();
        public TFieldInteger idRelatorio
        {
            get { return this.m_idRelatorio; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("largura", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_largura = new TFieldInteger();
        public TFieldInteger largura
        {
            get { return this.m_largura; }
        }

        [TColumn("altura", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_altura = new TFieldInteger();
        public TFieldInteger altura
        {
            get { return this.m_altura; }
        }

        [TColumn("colunas", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_colunas = new TFieldInteger();
        public TFieldInteger colunas
        {
            get { return this.m_colunas; }
        }

        [TColumn("paginas", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_paginas = new TFieldInteger();
        public TFieldInteger paginas
        {
            get { return this.m_paginas; }
        }

        [TColumn("margemTopo", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_margemTopo = new TFieldInteger();
        public TFieldInteger margemTopo
        {
            get { return this.m_margemTopo; }
        }

        [TColumn("margemRodape", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_margemRodape = new TFieldInteger();
        public TFieldInteger margemRodape
        {
            get { return this.m_margemRodape; }
        }

        [TColumn("margemEsquerda", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_margemEsquerda = new TFieldInteger();
        public TFieldInteger margemEsquerda
        {
            get { return this.m_margemEsquerda; }
        }

        [TColumn("margemDireita", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_margemDireita = new TFieldInteger();
        public TFieldInteger margemDireita
        {
            get { return this.m_margemDireita; }
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

        [TColumn("classeBase", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_classeBase = new TFieldString();
        public TFieldString classeBase
        {
            get { return this.m_classeBase; }
        }

        [TColumn("tipo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipo = new TFieldString();
        public TFieldString tipo
        {
            get { return this.m_tipo; }
        }

        [TColumn("condicao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_condicao = new TFieldString();
        public TFieldString condicao
        {
            get { return this.m_condicao; }
        }

        [
         TList(typeof(RelatorioBandas)),
         TJoin(new String[] { "idRelatorio->idRelatorio" })
        ]
        private Object m_RelatorioBandass = null;
        public System.Collections.Generic.List<RelatorioBandas> relatorioBandass
        {
            get
            {
                if (this.m_RelatorioBandass != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(RelatorioBandas) }
                     ).IsInstanceOfType(this.m_RelatorioBandass)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_RelatorioBandass)[i]);

                        this.m_RelatorioBandass = em.list(typeof(RelatorioBandas), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<RelatorioBandas>)this.m_RelatorioBandass;
            }
        }
    }
}