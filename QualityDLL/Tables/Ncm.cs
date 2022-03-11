
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Ncm")]
    public class Ncm : TTableBase
    {
        [TColumn("idNcm", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdNcm = new TFieldInteger();
        public TFieldInteger idNcm
        {
            get { return this.m_IdNcm; }
        }

        [
            TColumn("idEstado", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idEstado->idEstado" })
        ]
        private Estado m_IdEstado = null;
        public Estado estado
        {
            get
            {
                if (this.m_IdEstado == null)
                {
                    this.m_IdEstado = new Estado();
                    foreach (TJoin attribute in this.m_IdEstado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdEstado.connectionString = this.connectionString;
                            this.m_IdEstado.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdEstado.selfFill();
                return this.m_IdEstado;
            }
        }

        [TColumn("codigo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Codigo = new TFieldString();
        public TFieldString codigo
        {
            get { return this.m_Codigo; }
        }

        [TColumn("ex", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldDouble m_Ex = new TFieldDouble();
        public TFieldDouble ex
        {
            get { return this.m_Ex; }
        }

        [TColumn("tipo", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldDouble m_Tipo = new TFieldDouble();
        public TFieldDouble tipo
        {
            get { return this.m_Tipo; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("nacionalFederal", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldDouble m_NacionalFederal = new TFieldDouble();
        public TFieldDouble nacionalFederal
        {
            get { return this.m_NacionalFederal; }
        }

        [TColumn("importadosFederal", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldDouble m_ImportadosFederal = new TFieldDouble();
        public TFieldDouble importadosFederal
        {
            get { return this.m_ImportadosFederal; }
        }

        [TColumn("estadual", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldDouble m_Estadual = new TFieldDouble();
        public TFieldDouble estadual
        {
            get { return this.m_Estadual; }
        }

        [TColumn("municipal", System.Data.SqlDbType.BigInt, false, false)]
        private TFieldDouble m_Municipal = new TFieldDouble();
        public TFieldDouble municipal
        {
            get { return this.m_Municipal; }
        }

        [TColumn("vigenciaInicio", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_VigenciaInicio = new TFieldDatetime();
        public TFieldDatetime vigenciaInicio
        {
            get { return this.m_VigenciaInicio; }
        }

        [TColumn("vigenciaFim", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_VigenciaFim = new TFieldDatetime();
        public TFieldDatetime vigenciaFim
        {
            get { return this.m_VigenciaFim; }
        }

        [TColumn("chave", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Chave = new TFieldString();
        public TFieldString chave
        {
            get { return this.m_Chave; }
        }

        [TColumn("versao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Versao = new TFieldString();
        public TFieldString versao
        {
            get { return this.m_Versao; }
        }

        [TColumn("fonte", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Fonte = new TFieldString();
        public TFieldString fonte
        {
            get { return this.m_Fonte; }
        }

    }
}
