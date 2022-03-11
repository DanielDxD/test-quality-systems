using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("NaturezaOperacao")]
    public class NaturezaOperacao : TTableBase
    {
        [TColumn("idNaturezaOperacao", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idNaturezaOperacao = new TFieldInteger();
        public TFieldInteger idNaturezaOperacao
        {
            get { return this.m_idNaturezaOperacao; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }

        [TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("codigoContabilReduzido", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoContabilReduzido = new TFieldString();
        public TFieldString codigoContabilReduzido
        {
            get { return this.m_codigoContabilReduzido; }
        }

        [TColumn("pagarReceber", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_pagarReceber = new TFieldString();
        public TFieldString pagarReceber
        {
            get { return this.m_pagarReceber; }
        }

        [TColumn("ativo", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_ativo = new TFieldString();
        public TFieldString ativo
        {
            get { return this.m_ativo; }
        }

        [
            TColumn("idParametroAcrescimo", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idParametroAcrescimo->idParametroAcrescimo" })
        ]
        private ParametroAcrescimo m_idParametroAcrescimo = null;
        public ParametroAcrescimo parametroAcrescimo
        {
            get
            {
                if (this.m_idParametroAcrescimo == null)
                {
                    this.m_idParametroAcrescimo = new ParametroAcrescimo();

                    foreach (TJoin attribute in this.m_idParametroAcrescimo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idParametroAcrescimo.connectionString = this.connectionString;
                            this.m_idParametroAcrescimo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idParametroAcrescimo.selfFill();

                return this.m_idParametroAcrescimo;
            }
        }
    }
}
