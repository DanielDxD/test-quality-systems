
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Convite")]
    public class Convite : TTableBase
    {
        [TColumn("idConvite", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdConvite = new TFieldInteger();
        public TFieldInteger idConvite
        {
            get { return this.m_IdConvite; }
        }

        [TColumn("idTipoConvite", System.Data.SqlDbType.Int, false, false),
TJoin(new String[] { "idTipoConvite->idTipoConvite" })]
        private TipoConvite m_IdTipoConvite = null;
        public TipoConvite tipoConvite
        {
            get
            {
                if (this.m_IdTipoConvite == null)
                {
                    this.m_IdTipoConvite = new TipoConvite();
                    foreach (TJoin attribute in this.m_IdTipoConvite.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdTipoConvite.connectionString = this.connectionString;
                            this.m_IdTipoConvite.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdTipoConvite.selfFill();
                return this.m_IdTipoConvite;
            }
        }

        [TColumn("idContasAReceber", System.Data.SqlDbType.Int, false, false),
        TJoin(new String[] { "idContasAReceber->idContasAReceber" })]
        private ContasAReceber m_IdContasAReceber = null;
        public ContasAReceber contasAReceber
        {
            get
            {
                if (this.m_IdContasAReceber == null)
                {
                    this.m_IdContasAReceber = new ContasAReceber();
                    foreach (TJoin attribute in this.m_IdContasAReceber.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdContasAReceber.connectionString = this.connectionString;
                            this.m_IdContasAReceber.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdContasAReceber.selfFill();
                return this.m_IdContasAReceber;
            }
        }

        [TColumn("idTituloSocio", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idTituloSocio->idTituloSocio" })]
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

        [TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idFuncionario->idFuncionario" })]
        private Funcionario m_IdFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_IdFuncionario == null)
                {
                    this.m_IdFuncionario = new Funcionario();
                    foreach (TJoin attribute in this.m_IdFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdFuncionario.connectionString = this.connectionString;
                            this.m_IdFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdFuncionario.selfFill();
                return this.m_IdFuncionario;
            }
        }

        [TColumn("idConvidado", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idConvidado->idConvidado" })]
        private Convidado m_IdConvidado = null;
        public Convidado convidado
        {
            get
            {
                if (this.m_IdConvidado == null)
                {
                    this.m_IdConvidado = new Convidado();
                    foreach (TJoin attribute in this.m_IdConvidado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdConvidado.connectionString = this.connectionString;
                            this.m_IdConvidado.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdConvidado.selfFill();
                return this.m_IdConvidado;
            }
        }

        [TColumn("dataCriacaoConvite", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataCriacaoConvite = new TFieldDatetime();
        public TFieldDatetime dataCriacaoConvite
        {
            get { return this.m_DataCriacaoConvite; }
        }

        [TColumn("dataVencimentoInicial", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataVencimentoInicial = new TFieldDatetime();
        public TFieldDatetime dataVencimentoInicial
        {
            get { return this.m_DataVencimentoInicial; }
        }

        [TColumn("dataVencimentoFinal", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataVencimentoFinal = new TFieldDatetime();
        public TFieldDatetime dataVencimentoFinal
        {
            get { return this.m_DataVencimentoFinal; }
        }

        [TColumn("metodoCriacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_MetodoCriacao = new TFieldString();
        public TFieldString metodoCriacao
        {
            get { return this.m_MetodoCriacao; }
        }
    }
}
