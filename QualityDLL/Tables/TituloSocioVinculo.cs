using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("TituloSocioVinculo")]
    public class TituloSocioVinculo : TTableBase
    {
        [TColumn("idTituloSocioVinculo", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idTituloSocioVinculo = new TFieldInteger();
        public TFieldInteger idTituloSocioVinculo
        {
            get { return this.m_idTituloSocioVinculo; }
        }

        [TColumn("dataInicio", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataInicio = new TFieldDatetime();
        public TFieldDatetime dataInicio
        {
            get { return this.m_DataInicio; }
        }

        [TColumn("dataFim", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataFim = new TFieldDatetime();
        public TFieldDatetime dataFim
        {
            get { return this.m_DataFim; }
        }

        [
            TColumn("idTituloSocio", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idTituloSocio->idTituloSocio" })
        ]
        private TituloSocio m_idTituloSocio = null;
        public TituloSocio tituloSocio
        {
            get
            {
                if (this.m_idTituloSocio == null)
                {
                    this.m_idTituloSocio = new TituloSocio();

                    foreach (TJoin attribute in this.m_idTituloSocio.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTituloSocio.connectionString = this.connectionString;
                            this.m_idTituloSocio.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTituloSocio.selfFill();

                return this.m_idTituloSocio;
            }
        }

        [
            TColumn("idTituloSocioVinculado", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idTituloSocioVinculado->idTituloSocio" })
        ]
        private TituloSocio m_idTituloSocioVinculado = null;
        public TituloSocio tituloSocioVinculado
        {
            get
            {
                if (this.m_idTituloSocioVinculado == null)
                {
                    this.m_idTituloSocioVinculado = new TituloSocio();

                    foreach (TJoin attribute in this.m_idTituloSocioVinculado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idTituloSocioVinculado.connectionString = this.connectionString;
                            this.m_idTituloSocioVinculado.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idTituloSocioVinculado.selfFill();

                return this.m_idTituloSocioVinculado;
            }
        }

        [
            TColumn("idVinculo", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idVinculo->idVinculo" })
        ]
        private Vinculo m_idVinculo = null;
        public Vinculo vinculo
        {
            get
            {
                if (this.m_idVinculo == null)
                {
                    this.m_idVinculo = new Vinculo();

                    foreach (TJoin attribute in this.m_idVinculo.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idVinculo.connectionString = this.connectionString;
                            this.m_idVinculo.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idVinculo.selfFill();

                return this.m_idVinculo;
            }
        }
    }
}
