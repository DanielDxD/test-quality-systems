using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Empresa")]
    public class Empresa : TTableBase
    {
        [TColumn("idEmpresa", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_idEmpresa = new TFieldInteger();
        public TFieldInteger idEmpresa
        {
            get { return this.m_idEmpresa; }
        }

        [TColumn("mascaraCodigoContabil", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_mascaraCodigoContabil = new TFieldString();
        public TFieldString mascaraCodigoContabil
        {
            get { return this.m_mascaraCodigoContabil; }
        }

        [TColumn("assinatura", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_assinatura = new TFieldString();
        public TFieldString assinatura
        {
            get { return this.m_assinatura; }
        }

        [TColumn("chavePix", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_chavePix = new TFieldString();
        public TFieldString chavePix
        {
            get { return this.m_chavePix; }
        }

        [TColumn("developerKey", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_developerKey = new TFieldString();
        public TFieldString developerKey
        {
            get { return this.m_developerKey; }
        }

        [TColumn("clientId", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_clientId = new TFieldString();
        public TFieldString clientId
        {
            get { return this.m_clientId; }
        }

        [TColumn("clientSecret", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_clientSecret = new TFieldString();
        public TFieldString clientSecret
        {
            get { return this.m_clientSecret; }
        }

        [TColumn("dataCorte", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataCorte = new TFieldDatetime();
        public TFieldDatetime dataCorte
        {
            get { return this.m_dataCorte; }
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

        [
            TColumn("idGrupoCobranca", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idGrupoCobranca->idGrupoCobranca" })
        ]
        private GrupoCobranca m_idGrupoCobranca = null;
        public GrupoCobranca grupoCobranca
        {
            get
            {
                if (this.m_idGrupoCobranca == null)
                {
                    this.m_idGrupoCobranca = new GrupoCobranca();

                    foreach (TJoin attribute in this.m_idGrupoCobranca.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idGrupoCobranca.connectionString = this.connectionString;
                            this.m_idGrupoCobranca.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idGrupoCobranca.selfFill();

                return this.m_idGrupoCobranca;
            }
        }


        [
            TColumn("idNaturezaOperacaoMulta", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idNaturezaOperacaoMulta->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_idNaturezaOperacaoMulta = null;
        public NaturezaOperacao naturezaOperacaoMulta
        {
            get
            {
                if (this.m_idNaturezaOperacaoMulta == null)
                {
                    this.m_idNaturezaOperacaoMulta = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_idNaturezaOperacaoMulta.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idNaturezaOperacaoMulta.connectionString = this.connectionString;
                            this.m_idNaturezaOperacaoMulta.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idNaturezaOperacaoMulta.selfFill();

                return this.m_idNaturezaOperacaoMulta;
            }
        }

        [
            TColumn("idNaturezaOperacaoCorrecaoMonetaria", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idNaturezaOperacaoCorrecaoMonetaria->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_idNaturezaOperacaoCorrecaoMonetaria = null;
        public NaturezaOperacao naturezaOperacaoCorrecaoMonetaria
        {
            get
            {
                if (this.m_idNaturezaOperacaoCorrecaoMonetaria == null)
                {
                    this.m_idNaturezaOperacaoCorrecaoMonetaria = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_idNaturezaOperacaoCorrecaoMonetaria.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idNaturezaOperacaoCorrecaoMonetaria.connectionString = this.connectionString;
                            this.m_idNaturezaOperacaoCorrecaoMonetaria.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idNaturezaOperacaoCorrecaoMonetaria.selfFill();

                return this.m_idNaturezaOperacaoCorrecaoMonetaria;
            }
        }

        [
            TColumn("idParametroBoleto", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idParametroBoleto->idParametroBoleto" })
        ]
        private ParametroBoleto m_idParametroBoleto = null;
        public ParametroBoleto parametroBoleto
        {
            get
            {
                if (this.m_idParametroBoleto == null)
                {
                    this.m_idParametroBoleto = new ParametroBoleto();

                    foreach (TJoin attribute in this.m_idParametroBoleto.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idParametroBoleto.connectionString = this.connectionString;
                            this.m_idParametroBoleto.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idParametroBoleto.selfFill();

                return this.m_idParametroBoleto;
            }
        }

        [TColumn("crt", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_crt = new TFieldInteger();
        public TFieldInteger crt
        {
            get { return this.m_crt; }
        }

        [TColumn("certificado", System.Data.SqlDbType.VarBinary, false, false)]
        private TFieldVarbinary m_certificado = new TFieldVarbinary();
        public TFieldVarbinary certificado
        {
            get { return this.m_certificado; }
        }

        [TColumn("nomeCertificado", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nomeCertificado = new TFieldString();
        public TFieldString nomeCertificado
        {
            get { return this.m_nomeCertificado; }
        }

        [TColumn("senhaCertificado", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_senhaCertificado = new TFieldString();
        public TFieldString senhaCertificado
        {
            get { return this.m_senhaCertificado; }
        }

        [TColumn("csc", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_csc = new TFieldString();
        public TFieldString csc
        {
            get { return this.m_csc; }
        }

        [TColumn("idCsc", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_idCsc = new TFieldString();
        public TFieldString idCsc
        {
            get { return this.m_idCsc; }
        }

        [TColumn("cnae", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_cnae = new TFieldInteger();
        public TFieldInteger cnae
        {
            get { return this.m_cnae; }
        }

        [TColumn("regimePisCofins", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_regimePisCofins = new TFieldInteger();
        public TFieldInteger regimePisCofins
        {
            get { return this.m_regimePisCofins; }
        }

        [TColumn("diaVencimentoDebito", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_diaVencimentoDebito = new TFieldInteger();
        public TFieldInteger diaVencimentoDebito
        {
            get { return this.m_diaVencimentoDebito; }
        }

        [TColumn("aliquotaPis", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaPis = new TFieldDouble();
        public TFieldDouble aliquotaPis
        {
            get { return this.m_aliquotaPis; }
        }

        [TColumn("aliquotaCofins", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaCofins = new TFieldDouble();
        public TFieldDouble aliquotaCofins
        {
            get { return this.m_aliquotaCofins; }
        }

        [
            TColumn("idEstado", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idEstado->idEstado" })
        ]
        private Estado m_idEstado = null;
        public Estado estado
        {
            get
            {
                if (this.m_idEstado == null)
                {
                    this.m_idEstado = new Estado();

                    foreach (TJoin attribute in this.m_idEstado.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEstado.connectionString = this.connectionString;
                            this.m_idEstado.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEstado.selfFill();

                return this.m_idEstado;
            }
        }

        [TColumn("tipoEmissaoFiscal", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_tipoEmissaoFiscal = new TFieldString();
        public TFieldString tipoEmissaoFiscal
        {
            get { return this.m_tipoEmissaoFiscal; }
        }

        [TColumn("multa", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_Multa = new TFieldDouble();
        public TFieldDouble multa
        {
            get { return this.m_Multa; }
        }

        [TColumn("gerarDebitoPosPago", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_gerarDebitoPosPago = new TFieldBoolean();
        public TFieldBoolean gerarDebitoPosPago
        {
            get { return this.m_gerarDebitoPosPago; }
        }

        [TColumn("agruparDebitosTitularDependente", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_agruparDebitosTitularDependente = new TFieldBoolean();
        public TFieldBoolean agruparDebitosTitularDependente
        {
            get { return this.m_agruparDebitosTitularDependente; }
        }
    }
}
