using System;

namespace WS.CRUD
{
    public class Pix : WS.CRUD.Base
    {
        public Pix(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Pix input = (Data.Pix)parametros["Key"];
            Tables.Pix bd = new Tables.Pix();

            bd.idPix.isNull = true;
            bd.status.value = input.status;
            bd.expiracao.value = input.expiracao;
            bd.criacao.value = input.criacao;
            bd.valor.value = input.valor;
            bd.chave.value = input.chave;
            bd.solicitacaoPagador.value = input.solicitacaoPagador;
            bd.location.value = input.location;
            bd.textoImagemQRcode.value = input.textoImagemQRcode;
            bd.txid.value = input.txid;
            bd.revisao.value = input.revisao;
            bd.devedorNome.value = input.devedorNome;
            bd.devedorCpfCnpj.value = input.devedorCpfCnpj;
            bd.dataConciliacaoQuality.value = input.dataConciliacaoQuality;

            this.m_EntityManager.persist(bd);

            ((Data.Pix)parametros["Key"]).idPix = (int)bd.idPix.value;

            if (input.pixTransacoes != null)
            {
                WS.CRUD.PixTransacao pixTransacaoCRUD = new WS.CRUD.PixTransacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pixTransacoes.Length; i++)
                {
                    input.pixTransacoes[i].pix = new Data.Pix
                    {
                        idPix = bd.idPix.value
                    };
                    _parameters.Add("Key", input.pixTransacoes[i]);
                    pixTransacaoCRUD.atualizar(_parameters);
                    if (input.pixTransacoes[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pixTransacoes[i] = (Data.PixTransacao)pixTransacaoCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                pixTransacaoCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Pix input = (Data.Pix)parametros["Key"];
            Tables.Pix bd = (Tables.Pix)this.m_EntityManager.find
            (
                typeof(Tables.Pix),
                new Object[]
                {
                    input.idPix
                }
            );

            bd.status.value = input.status;
            bd.expiracao.value = input.expiracao;
            bd.criacao.value = input.criacao;
            bd.valor.value = input.valor;
            bd.chave.value = input.chave;
            bd.solicitacaoPagador.value = input.solicitacaoPagador;
            bd.location.value = input.location;
            bd.textoImagemQRcode.value = input.textoImagemQRcode;
            bd.txid.value = input.txid;
            bd.revisao.value = input.revisao;
            bd.devedorNome.value = input.devedorNome;
            bd.devedorCpfCnpj.value = input.devedorCpfCnpj;
            bd.dataConciliacaoQuality.value = input.dataConciliacaoQuality;

            this.m_EntityManager.merge(bd);

            if (input.pixTransacoes != null)
            {
                WS.CRUD.PixTransacao pixTransacaoCRUD = new WS.CRUD.PixTransacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pixTransacoes.Length; i++)
                {
                    input.pixTransacoes[i].pix = new Data.Pix
                    {
                        idPix = bd.idPix.value
                    };
                    _parameters.Add("Key", input.pixTransacoes[i]);
                    if (input.pixTransacoes[i].operacao == ENum.eOperacao.NONE)
                        input.pixTransacoes[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pixTransacaoCRUD.atualizar(_parameters);
                    if (input.pixTransacoes[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pixTransacoes[i] = (Data.PixTransacao)pixTransacaoCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                pixTransacaoCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Pix bd = new Tables.Pix();

            bd.idPix.value = ((Data.Pix)parametros["Key"]).idPix;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Pix)bd).idPix.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Pix)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Pix)input).idPix = ((Tables.Pix)bd).idPix.value;
                    ((Data.Pix)input).status = ((Tables.Pix)bd).status.value;
                    ((Data.Pix)input).expiracao = ((Tables.Pix)bd).expiracao.value;
                    ((Data.Pix)input).criacao = ((Tables.Pix)bd).criacao.value;
                    ((Data.Pix)input).valor = ((Tables.Pix)bd).valor.value;
                    ((Data.Pix)input).chave = ((Tables.Pix)bd).chave.value;
                    ((Data.Pix)input).solicitacaoPagador = ((Tables.Pix)bd).solicitacaoPagador.value;
                    ((Data.Pix)input).location = ((Tables.Pix)bd).location.value;
                    ((Data.Pix)input).textoImagemQRcode = ((Tables.Pix)bd).textoImagemQRcode.value;
                    ((Data.Pix)input).txid = ((Tables.Pix)bd).txid.value;
                    ((Data.Pix)input).revisao = ((Tables.Pix)bd).revisao.value;
                    ((Data.Pix)input).devedorNome = ((Tables.Pix)bd).devedorNome.value;
                    ((Data.Pix)input).devedorCpfCnpj = ((Tables.Pix)bd).devedorCpfCnpj.value;
                    ((Data.Pix)input).dataConciliacaoQuality = ((Tables.Pix)bd).dataConciliacaoQuality.value;
                }
                else { }
            }
            else { }

            if (level < 1)
            {
                //Preencher pixTransacoes
                if (((Tables.Pix)bd).pixTransacoes != null)
                {
                    System.Collections.Generic.List<Data.PixTransacao> _list = new System.Collections.Generic.List<Data.PixTransacao>();

                    foreach (Tables.PixTransacao _item in ((Tables.Pix)bd).pixTransacoes)
                    {
                        _list.Add
                        (
                            (Data.PixTransacao)
                            (new WS.CRUD.PixTransacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.PixTransacao(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.Pix)input).pixTransacoes = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.Pix)input).pixTransacoes != null)
                    {
                        System.Collections.Generic.List<Data.PixTransacao> _list = new System.Collections.Generic.List<Data.PixTransacao>();

                        foreach (Data.PixTransacao _item in ((Data.Pix)input).pixTransacoes)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.Pix)input).pixTransacoes = _list.ToArray();
                        else
                            ((Data.Pix)input).pixTransacoes = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Pix result = (Data.Pix)parametros["Key"];

            try
            {
                result = (Data.Pix)this.preencher
                (
                    new Data.Pix(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Pix),
                        new Object[]
                        {
                            result.idPix
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Pix input = (Data.Pix)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

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
                    typeof(Tables.Pix),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Pix _data in
                    (System.Collections.Generic.List<Tables.Pix>)this.m_EntityManager.list
                    (
                        typeof(Tables.Pix),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.Pix(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    report.ProcessRecord(null);
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

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            bool onlyCount = false;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
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

            Data.Pix _input = (Data.Pix)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idPix > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pix.idPix = @idPix");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPix", _input.idPix));
                    if (!sqlOrderBy.Contains("Pix.idPix"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pix.idPix");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.status))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pix.status = @status");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("status", _input.status));
                    if (!sqlOrderBy.Contains("Pix.status"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pix.status");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.txid))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pix.txid = @txid");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("txid", _input.txid));
                    if (!sqlOrderBy.Contains("Pix.txid"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pix.txid");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.devedorCpfCnpj))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pix.devedorCpfCnpj = @devedorCpfCnpj");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("devedorCpfCnpj", _input.devedorCpfCnpj));
                    if (!sqlOrderBy.Contains("Pix.devedorCpfCnpj"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pix.devedorCpfCnpj");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Pix.* ") +
                    "from " +
                    (
                        "   Pix Pix "
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );
                table = null;
            }
            else { }

            return result;
        }
    }
}
