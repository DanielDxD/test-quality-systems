using System;
using System.Collections;

namespace WS.CRUD
{
    public class Empresa : WS.CRUD.Base
    {
        public Empresa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Empresa input = (Data.Empresa)parametros["Key"];
            Tables.Empresa bd =
            (
                parametros["Return"] != null ?
                (Tables.Empresa)parametros["Return"] :
                new Tables.Empresa()
            );

            //Incluir/Alterar Pessoafisica/Juridica
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.pessoa);
                //_parametros.Add("Return", bd.pessoa);

                if (input.pessoa.pfpj == "F")
                    input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);
                else
                    input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
                if (input.dataCorte.Ticks > 0)
                    bd.dataCorte.value = input.dataCorte;
                else
                    bd.dataCorte.isNull = true;
                _parametros.Clear();
                _parametros = null;
            }

            bd.idEmpresa.isNull = true;

            bd.mascaraCodigoContabil.value = input.mascaraCodigoContabil;
            bd.chavePix.value = input.chavePix;
            bd.developerKey.value = input.developerKey;
            bd.clientSecret.value = input.clientSecret;
            bd.clientId.value = input.clientId;

            bd.crt.value = input.crt;
            bd.certificado.value = input.certificado;
            bd.nomeCertificado.value = input.nomeCertificado;
            bd.csc.value = input.csc;
            bd.idCsc.value = input.idCsc;
            bd.regimePisCofins.value = input.regimePisCofins;
            bd.aliquotaCofins.value = input.aliquotaCofins;
            bd.aliquotaPis.value = input.aliquotaPis;
            bd.aliquotaPis.value = input.aliquotaPis;
            bd.cnae.value = input.cnae;
            if (input.estado != null && input.estado.idEstado > 0)
                bd.estado.idEstado.value = input.estado.idEstado;
            else
                bd.estado.idEstado.isNull = true;

            if (!String.IsNullOrEmpty(input.gerarDebitoPosPago))
                bd.gerarDebitoPosPago.value = input.gerarDebitoPosPago.ToLower() == "s";
            else { }

            if (!String.IsNullOrEmpty(input.agruparDebitosTitularDependente))
                bd.agruparDebitosTitularDependente.value = input.agruparDebitosTitularDependente.ToLower() == "s";
            else { }

            bd.multa.value = input.multa;

            if (input.parametroBoleto != null && input.parametroBoleto.idParametroBoleto > 0)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else
                bd.parametroBoleto.idParametroBoleto.isNull = true;

            if (input.grupoCobranca != null && input.grupoCobranca.idGrupoCobranca > 0)
                bd.grupoCobranca.idGrupoCobranca.value = input.grupoCobranca.idGrupoCobranca;
            else
                bd.grupoCobranca.idGrupoCobranca.isNull = true;

            bd.tipoEmissaoFiscal.value = input.tipoEmissaoFiscal;
            bd.diaVencimentoDebito.value = input.diaVencimentoDebito;

            if (input.naturezaOperacaoMulta != null && input.naturezaOperacaoMulta.idNaturezaOperacao > 0)
                bd.naturezaOperacaoMulta.idNaturezaOperacao.value = input.naturezaOperacaoMulta.idNaturezaOperacao;
            else
                bd.naturezaOperacaoMulta.idNaturezaOperacao.isNull = true;

            if (input.naturezaOperacaoCorrecaoMonetaria != null && input.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao > 0)
                bd.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao.value = input.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao;
            else
                bd.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao.isNull = true;

            if (input.parametroAcrescimo != null && input.parametroAcrescimo.idParametroAcrescimo > 0)
                bd.parametroAcrescimo.idParametroAcrescimo.value = input.parametroAcrescimo.idParametroAcrescimo;
            else
                bd.parametroAcrescimo.idParametroAcrescimo.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.Empresa)parametros["Key"]).idEmpresa = (int)bd.idEmpresa.value;

            String
                signature = Utils.Utils.RecordSign(input, 4);

            if (String.IsNullOrEmpty(signature))
                signature = new Utils.Base64().encode(new Utils.MD5().digest(Utils.Utils.RandomString(10)));
            else { }

            string
                senhaCertificado = "";

            if (!String.IsNullOrEmpty(input.senhaCertificado))
                senhaCertificado = Utils.Security.EncryptRijndael(input.senhaCertificado, signature);
            else
                senhaCertificado = null;

            this.m_EntityManager.execute
            (
                "update empresa set assinatura = '" + signature + "', senhaCertificado = '" + senhaCertificado + "' where idEmpresa = @idEmpresa",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger
                    (
                        "idEmpresa",
                        input.idEmpresa
                    )
                }
            );

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Empresa input = (Data.Empresa)parametros["Key"];
            Tables.Empresa bd =
            (
                parametros["Return"] != null ?
                (Tables.Empresa)parametros["Return"] :
                (Tables.Empresa)this.m_EntityManager.find
                (
                    typeof(Tables.Empresa),
                    new Object[]
                    {
                        input.idEmpresa
                    }
                )
            );

            bd.mascaraCodigoContabil.value = input.mascaraCodigoContabil;
            if (input.dataCorte.Ticks > 0)
                bd.dataCorte.value = input.dataCorte;
            else
                bd.dataCorte.isNull = true;

            bd.chavePix.value = input.chavePix;
            bd.developerKey.value = input.developerKey;
            bd.clientSecret.value = input.clientSecret;
            bd.clientId.value = input.clientId;
            bd.crt.value = input.crt;
            bd.certificado.value = input.certificado;
            bd.nomeCertificado.value = input.nomeCertificado;
            bd.senhaCertificado.value = input.senhaCertificado;
            bd.csc.value = input.csc;
            bd.idCsc.value = input.idCsc;
            bd.cnae.value = input.cnae;
            bd.regimePisCofins.value = input.regimePisCofins;
            bd.aliquotaCofins.value = input.aliquotaCofins;
            bd.aliquotaPis.value = input.aliquotaPis;
            if (input.estado != null && input.estado.idEstado > 0)
                bd.estado.idEstado.value = input.estado.idEstado;
            else
                bd.estado.idEstado.isNull = true;
            bd.tipoEmissaoFiscal.value = input.tipoEmissaoFiscal;

            if (input.parametroBoleto != null && input.parametroBoleto.idParametroBoleto > 0)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else
                bd.parametroBoleto.idParametroBoleto.isNull = true;

            if (!String.IsNullOrEmpty(input.gerarDebitoPosPago))
                bd.gerarDebitoPosPago.value = input.gerarDebitoPosPago.ToLower() == "s";
            else { }

            if (!String.IsNullOrEmpty(input.agruparDebitosTitularDependente))
                bd.agruparDebitosTitularDependente.value = input.agruparDebitosTitularDependente.ToLower() == "s";
            else { }

            bd.multa.value = input.multa;
            bd.diaVencimentoDebito.value = input.diaVencimentoDebito;
            if (input.naturezaOperacaoMulta != null && input.naturezaOperacaoMulta.idNaturezaOperacao > 0)
                bd.naturezaOperacaoMulta.idNaturezaOperacao.value = input.naturezaOperacaoMulta.idNaturezaOperacao;
            else
                bd.naturezaOperacaoMulta.idNaturezaOperacao.isNull = true;

            if (input.naturezaOperacaoCorrecaoMonetaria != null && input.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao > 0)
                bd.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao.value = input.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao;
            else
                bd.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao.isNull = true;

            if (input.grupoCobranca != null && input.grupoCobranca.idGrupoCobranca > 0)
                bd.grupoCobranca.idGrupoCobranca.value = input.grupoCobranca.idGrupoCobranca;
            else
                bd.grupoCobranca.idGrupoCobranca.isNull = true;

            if (input.parametroAcrescimo != null && input.parametroAcrescimo.idParametroAcrescimo > 0)
                bd.parametroAcrescimo.idParametroAcrescimo.value = input.parametroAcrescimo.idParametroAcrescimo;
            else
                bd.parametroAcrescimo.idParametroAcrescimo.isNull = true;

            this.m_EntityManager.merge(bd);

            //Incluir/Alterar Pessoafisica/Juridica
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.pessoa);
                //_parametros.Add("Return", bd.pessoa);

                if (input.pessoa.pfpj == "F")
                    input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);
                else
                    input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            String
                signature = Utils.Utils.RecordSign(input, 4);
            if (String.IsNullOrEmpty(signature))
                signature = new Utils.Base64().encode(new Utils.MD5().digest(Utils.Utils.RandomString(10)));
            else { }

            string
                senhaCertificado = "";

            if (!String.IsNullOrEmpty(input.senhaCertificado))
                senhaCertificado = Utils.Security.EncryptRijndael(input.senhaCertificado, signature);
            else
                senhaCertificado = null;

            this.m_EntityManager.execute
            (
                "update empresa set assinatura = '" + signature + "', senhaCertificado = '" + senhaCertificado + "' where idEmpresa = @idEmpresa",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger
                    (
                        "idEmpresa",
                        input.idEmpresa
                    )
                }
            );

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Empresa bd = new Tables.Empresa();

            bd.idEmpresa.value = ((Data.Empresa)parametros["Key"]).idEmpresa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Empresa)bd).idEmpresa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Empresa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Empresa)input).idEmpresa = ((Tables.Empresa)bd).idEmpresa.value;

                    {
                        System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                        if (((Tables.Empresa)bd).pessoa.pfpj.value == "F")
                        {
                            ((Data.Empresa)input).pessoa = new Data.PessoaFisica();
                            ((Data.Empresa)input).pessoa.idPessoa = ((Tables.Empresa)bd).pessoa.idPessoa.value;
                            _parameters.Add("Key", ((Data.Empresa)input).pessoa);
                            ((Data.Empresa)input).pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parameters);
                        }
                        else
                        {
                            ((Data.Empresa)input).pessoa = new Data.PessoaJuridica();
                            ((Data.Empresa)input).pessoa.idPessoa = ((Tables.Empresa)bd).pessoa.idPessoa.value;
                            _parameters.Add("Key", ((Data.Empresa)input).pessoa);
                            ((Data.Empresa)input).pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parameters);
                        }

                        _parameters.Clear();
                        _parameters = null;
                    }

                    ((Data.Empresa)input).chavePix = ((Tables.Empresa)bd).chavePix.value;
                    ((Data.Empresa)input).developerKey = ((Tables.Empresa)bd).developerKey.value;
                    ((Data.Empresa)input).clientId = ((Tables.Empresa)bd).clientId.value;
                    ((Data.Empresa)input).clientSecret = ((Tables.Empresa)bd).clientSecret.value;
                    ((Data.Empresa)input).assinatura = ((Tables.Empresa)bd).assinatura.value;
                    ((Data.Empresa)input).mascaraCodigoContabil = ((Tables.Empresa)bd).mascaraCodigoContabil.value;
                    ((Data.Empresa)input).dataCorte = ((Tables.Empresa)bd).dataCorte.value;
                    ((Data.Empresa)input).crt = ((Tables.Empresa)bd).crt.value;
                    ((Data.Empresa)input).certificado = ((Tables.Empresa)bd).certificado.value;
                    ((Data.Empresa)input).nomeCertificado = ((Tables.Empresa)bd).nomeCertificado.value;
                    ((Data.Empresa)input).diaVencimentoDebito = ((Tables.Empresa)bd).diaVencimentoDebito.value;
                    ((Data.Empresa)input).multa = ((Tables.Empresa)bd).multa.value;
                    ((Data.Empresa)input).gerarDebitoPosPago = ((Tables.Empresa)bd).gerarDebitoPosPago.value ? "s" : "n";
                    ((Data.Empresa)input).agruparDebitosTitularDependente = ((Tables.Empresa)bd).agruparDebitosTitularDependente.value ? "s" : "n";
                    if (((Tables.Empresa)bd).senhaCertificado.value != null)
                        try
                        {
                            ((Data.Empresa)input).senhaCertificado = Utils.Security.DecryptRijndael(((Tables.Empresa)bd).senhaCertificado.value, ((Tables.Empresa)bd).assinatura.value);
                        }
                        catch
                        {
                            ((Data.Empresa)input).senhaCertificado = ((Tables.Empresa)bd).senhaCertificado.value;
                        }
                    else { }
                    ((Data.Empresa)input).csc = ((Tables.Empresa)bd).csc.value;
                    ((Data.Empresa)input).idCsc = ((Tables.Empresa)bd).idCsc.value;
                    ((Data.Empresa)input).cnae = ((Tables.Empresa)bd).cnae.value;
                    ((Data.Empresa)input).regimePisCofins = ((Tables.Empresa)bd).regimePisCofins.value;
                    ((Data.Empresa)input).tipoEmissaoFiscal = ((Tables.Empresa)bd).tipoEmissaoFiscal.value;
                    ((Data.Empresa)input).aliquotaPis = ((Tables.Empresa)bd).aliquotaPis.value;
                    ((Data.Empresa)input).aliquotaCofins = ((Tables.Empresa)bd).aliquotaCofins.value;
                    ((Data.Empresa)input).estado = (Data.Estado)(new WS.CRUD.Estado(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Estado(),
                        ((Tables.Empresa)bd).estado,
                        level + 1
                    );
                    ((Data.Empresa)input).naturezaOperacaoMulta = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.Empresa)bd).naturezaOperacaoMulta,
                        level + 1
                    );
                    ((Data.Empresa)input).grupoCobranca = (Data.GrupoCobranca)(new WS.CRUD.GrupoCobranca(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.GrupoCobranca(),
                        ((Tables.Empresa)bd).grupoCobranca,
                        level + 1
                    );
                    ((Data.Empresa)input).naturezaOperacaoCorrecaoMonetaria = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.Empresa)bd).naturezaOperacaoCorrecaoMonetaria,
                        level + 1
                    );

                    ((Data.Empresa)input).parametroBoleto = (Data.ParametroBoleto)(new WS.CRUD.ParametroBoleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroBoleto(),
                        ((Tables.Empresa)bd).parametroBoleto,
                        level + 1
                    );

                    ((Data.Empresa)input).parametroAcrescimo = (Data.ParametroAcrescimo)(new WS.CRUD.ParametroAcrescimo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroAcrescimo(),
                        ((Tables.Empresa)bd).parametroAcrescimo,
                        level + 1
                    );

                    //Verify Record Signature
                    //if (!((Tables.Empresa)bd).assinatura.isNull)
                    //    if (((Tables.Empresa)bd).assinatura.value != Utils.Utils.RecordSign(input, 4))
                    //        throw new Exception("Empresa - Assinatura Inv�lida.");
                    //    else { }
                    //else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Empresa result = (Data.Empresa)parametros["Key"];

            try
            {
                result = (Data.Empresa)this.preencher
                (
                    new Data.Empresa(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Empresa),
                        new Object[]
                        {
                            result.idEmpresa
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }
            }
            else { }

            Data.Empresa _input = (Data.Empresa)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresa.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("empresa.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresa.idEmpresa");
                    else { }
                }
                else { }

                if (_input.pessoa != null)
                {
                    if ((_input.pessoa != null) && (_input.pessoa.idPessoa > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.pessoa.idPessoa));
                        if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                        else { }
                    }
                    else { }

                    if ((_input.pessoa.cpfCnpj != null) && (_input.pessoa.cpfCnpj.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.pessoa.cpfCnpj + '%'));
                        if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                        else { }
                    }
                    else { }

                    if ((_input.pessoa.nomeRazaoSocial != null) && (_input.pessoa.nomeRazaoSocial.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.pessoa.nomeRazaoSocial + '%'));
                        if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   empresa.* " +
                    "from " +
                    (
                        "   empresa empresa " +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresa.idPessoa "
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Empresa input = (Data.Empresa)parametros["Key"];
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String
                        _filter = (String)parametros["Filter"],
                        _keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!_keys.Contains("[" + _key + "]"))
                        {
                            _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                            _keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.Empresa),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Empresa _data in
                    (System.Collections.Generic.List<Tables.Empresa>)this.m_EntityManager.list
                    (
                        typeof(Tables.Empresa),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Empresa();
                        ((Data.Empresa)_base).idEmpresa = _data.idEmpresa.value;
                        ((Data.Empresa)_base).chavePix = _data.chavePix.value;
                        ((Data.Empresa)_base).developerKey = _data.developerKey.value;
                        ((Data.Empresa)_base).clientId = _data.clientId.value;
                        ((Data.Empresa)_base).clientSecret = _data.clientSecret.value;
                        ((Data.Empresa)_base).crt = _data.crt.value;
                        ((Data.Empresa)_base).certificado = _data.certificado.value;
                        ((Data.Empresa)_base).nomeCertificado = _data.nomeCertificado.value;
                        if (!String.IsNullOrEmpty(_data.senhaCertificado.value))
                            ((Data.Empresa)_base).senhaCertificado = Utils.Security.DecryptRijndael(_data.senhaCertificado.value, _data.assinatura.value);
                        else { }
                        ((Data.Empresa)_base).csc = _data.csc.value;
                        ((Data.Empresa)_base).idCsc = _data.idCsc.value;
                        ((Data.Empresa)_base).cnae = _data.cnae.value;
                        ((Data.Empresa)_base).regimePisCofins = _data.regimePisCofins.value;
                        ((Data.Empresa)_base).aliquotaCofins = _data.aliquotaCofins.value;
                        ((Data.Empresa)_base).aliquotaPis = _data.aliquotaPis.value;
                        ((Data.Empresa)_base).idEmpresa = _data.idEmpresa.value;
                        ((Data.Empresa)_base).multa = _data.multa.value;
                        ((Data.Empresa)_base).diaVencimentoDebito = _data.diaVencimentoDebito.value;
                        ((Data.Empresa)_base).gerarDebitoPosPago = _data.gerarDebitoPosPago.value ? "s" : "n";
                        ((Data.Empresa)_base).agruparDebitosTitularDependente = _data.agruparDebitosTitularDependente.value ? "s" : "n";
                        if (_data.naturezaOperacaoMulta.idNaturezaOperacao.value > 0)
                            ((Data.Empresa)_base).naturezaOperacaoMulta = new Data.NaturezaOperacao
                            {
                                idNaturezaOperacao = _data.naturezaOperacaoMulta.idNaturezaOperacao.value,
                                descricao = _data.naturezaOperacaoMulta.descricao.value
                            };

                        if (_data.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao.value > 0)
                            ((Data.Empresa)_base).naturezaOperacaoCorrecaoMonetaria = new Data.NaturezaOperacao
                            {
                                idNaturezaOperacao = _data.naturezaOperacaoCorrecaoMonetaria.idNaturezaOperacao.value,
                                descricao = _data.naturezaOperacaoCorrecaoMonetaria.descricao.value
                            };
                        ((Data.Empresa)_base).pessoa = new Data.Pessoa
                        {
                            nomeRazaoSocial = _data.pessoa.nomeRazaoSocial.value,
                            cpfCnpj = _data.pessoa.cpfCnpj.value,
                            pfpj = _data.pessoa.pfpj.value,
                            idPessoa = _data.pessoa.idPessoa.value
                        };
                        ((Data.Empresa)_base).assinatura = _data.assinatura.value;
                        ((Data.Empresa)_base).tipoEmissaoFiscal = _data.tipoEmissaoFiscal.value;
                        ((Data.Empresa)_base).parametroBoleto = new Data.ParametroBoleto
                        {
                            idParametroBoleto = _data.parametroBoleto.idParametroBoleto.value
                        };
                        ((Data.Empresa)_base).grupoCobranca = new Data.GrupoCobranca
                        {
                            idGrupoCobranca = _data.grupoCobranca.idGrupoCobranca.value
                        };
                        ((Data.Empresa)_base).parametroAcrescimo = new Data.ParametroAcrescimo
                        {
                            idParametroAcrescimo = _data.parametroAcrescimo.idParametroAcrescimo.value
                        };
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Empresa(), _data, level);


                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    /*report.ProcessRecord(null);*/
                    Console.WriteLine("Relatorio");
                else { }

                _fieldKeys.Clear();
                _fieldKeys = null;
                _select = null;
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
