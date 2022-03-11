using System;

namespace WS.CRUD
{
    public class DocumentoRecebimento : WS.CRUD.Base
    {
        public DocumentoRecebimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimento input = (Data.DocumentoRecebimento)parametros["Key"];
            Tables.DocumentoRecebimento bd = new Tables.DocumentoRecebimento();

            bd.idDocumentoRecebimento.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            bd.idContaPagamento.idContaPagamento.value = input.idContaPagamento.idContaPagamento;
            bd.dataGeracao.value = input.dataGeracao;
            bd.dataMovimento.value = input.dataMovimento;
            bd.descricao.value = input.descricao;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.valorRecebido.value = input.valorRecebido;
            bd.dataVencimento.value = input.dataVencimento;
            bd.dataCancelamento.value = input.dataCancelamento;

            this.m_EntityManager.persist(bd);

            ((Data.DocumentoRecebimento)parametros["Key"]).idDocumentoRecebimento = (int)bd.idDocumentoRecebimento.value;

            //Processa DocumentoRecebimentoContasAReceber
            if (input.documentoRecebimentoContasARecebers != null)
            {
                WS.CRUD.DocumentoRecebimentoContasAReceber documentoRecebimentoContasAReceberCRUD = new WS.CRUD.DocumentoRecebimentoContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.documentoRecebimentoContasARecebers.Length; i++)
                {
                    input.documentoRecebimentoContasARecebers[i].idDocumentoRecebimento = bd.idDocumentoRecebimento.value;
                    _parameters.Add("Key", input.documentoRecebimentoContasARecebers[i]);
                    documentoRecebimentoContasAReceberCRUD.atualizar(_parameters);
                    if (input.documentoRecebimentoContasARecebers[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.documentoRecebimentoContasARecebers[i] = (Data.DocumentoRecebimentoContasAReceber)documentoRecebimentoContasAReceberCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                documentoRecebimentoContasAReceberCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ContaPagamentoMovimento
            if (input.contaPagamentoMovimentos != null)
            {
                WS.CRUD.ContaPagamentoMovimento contaPagamentoMovimentoCRUD = new WS.CRUD.ContaPagamentoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contaPagamentoMovimentos.Length; i++)
                {
                    input.contaPagamentoMovimentos[i].documentoRecebimento = new Data.DocumentoRecebimento();
                    input.contaPagamentoMovimentos[i].documentoRecebimento.idDocumentoRecebimento = bd.idDocumentoRecebimento.value;
                    _parameters.Add("Key", input.contaPagamentoMovimentos[i]);
                    contaPagamentoMovimentoCRUD.atualizar(_parameters);
                    if (input.contaPagamentoMovimentos[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contaPagamentoMovimentos[i] = (Data.ContaPagamentoMovimento)contaPagamentoMovimentoCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                contaPagamentoMovimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimento input = (Data.DocumentoRecebimento)parametros["Key"];
            Tables.DocumentoRecebimento bd = (Tables.DocumentoRecebimento)this.m_EntityManager.find
            (
                typeof(Tables.DocumentoRecebimento),
                new Object[]
                {
                    input.idDocumentoRecebimento
                }
            );

            bd.idEmpresa.value = input.idEmpresa;
            if (input.idContaPagamento != null)
                bd.idContaPagamento.idContaPagamento.value = input.idContaPagamento.idContaPagamento;
            else { }
            bd.dataGeracao.value = input.dataGeracao;
            bd.dataMovimento.value = input.dataMovimento;
            bd.descricao.value = input.descricao;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.valorRecebido.value = input.valorRecebido;
            bd.dataVencimento.value = input.dataVencimento;
            bd.dataCancelamento.value = input.dataCancelamento;

            this.m_EntityManager.merge(bd);

            //Processa DocumentoRecebimentoContasAReceber
            if (input.documentoRecebimentoContasARecebers != null)
            {
                WS.CRUD.DocumentoRecebimentoContasAReceber documentoRecebimentoContasAReceberCRUD = new WS.CRUD.DocumentoRecebimentoContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.documentoRecebimentoContasARecebers.Length; i++)
                {
                    input.documentoRecebimentoContasARecebers[i].idDocumentoRecebimento = bd.idDocumentoRecebimento.value;
                    _parameters.Add("Key", input.documentoRecebimentoContasARecebers[i]);
                    if (input.documentoRecebimentoContasARecebers[i].operacao == ENum.eOperacao.NONE)
                        input.documentoRecebimentoContasARecebers[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    documentoRecebimentoContasAReceberCRUD.atualizar(_parameters);
                    if (input.documentoRecebimentoContasARecebers[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.documentoRecebimentoContasARecebers[i] = (Data.DocumentoRecebimentoContasAReceber)documentoRecebimentoContasAReceberCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                documentoRecebimentoContasAReceberCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ContaPagamentoMovimento
            if (input.contaPagamentoMovimentos != null)
            {
                WS.CRUD.ContaPagamentoMovimento contaPagamentoMovimentoCRUD = new WS.CRUD.ContaPagamentoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contaPagamentoMovimentos.Length; i++)
                {
                    input.contaPagamentoMovimentos[i].documentoRecebimento = new Data.DocumentoRecebimento();
                    input.contaPagamentoMovimentos[i].documentoRecebimento.idDocumentoRecebimento = bd.idDocumentoRecebimento.value;
                    _parameters.Add("Key", input.contaPagamentoMovimentos[i]);
                    if (input.contaPagamentoMovimentos[i].operacao == ENum.eOperacao.NONE)
                        input.contaPagamentoMovimentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contaPagamentoMovimentoCRUD.atualizar(_parameters);
                    if (input.contaPagamentoMovimentos[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contaPagamentoMovimentos[i] = (Data.ContaPagamentoMovimento)contaPagamentoMovimentoCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                contaPagamentoMovimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.DocumentoRecebimento bd = new Tables.DocumentoRecebimento();

            bd.idDocumentoRecebimento.value = ((Data.DocumentoRecebimento)parametros["Key"]).idDocumentoRecebimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.DocumentoRecebimento)bd).idDocumentoRecebimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.DocumentoRecebimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.DocumentoRecebimento)input).idDocumentoRecebimento = ((Tables.DocumentoRecebimento)bd).idDocumentoRecebimento.value;
                    ((Data.DocumentoRecebimento)input).idEmpresa = ((Tables.DocumentoRecebimento)bd).idEmpresa.value;
                    ((Data.DocumentoRecebimento)input).idContaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.DocumentoRecebimento)bd).idContaPagamento,
                        level + 1
                    );
                    ((Data.DocumentoRecebimento)input).dataGeracao = ((Tables.DocumentoRecebimento)bd).dataGeracao.value;
                    ((Data.DocumentoRecebimento)input).dataCancelamento = ((Tables.DocumentoRecebimento)bd).dataCancelamento.value;
                    ((Data.DocumentoRecebimento)input).dataMovimento = ((Tables.DocumentoRecebimento)bd).dataMovimento.value;
                    ((Data.DocumentoRecebimento)input).descricao = ((Tables.DocumentoRecebimento)bd).descricao.value;
                    ((Data.DocumentoRecebimento)input).numeroDocumento = ((Tables.DocumentoRecebimento)bd).numeroDocumento.value;
                    ((Data.DocumentoRecebimento)input).valorRecebido = ((Tables.DocumentoRecebimento)bd).valorRecebido.value;
                    ((Data.DocumentoRecebimento)input).dataVencimento = ((Tables.DocumentoRecebimento)bd).dataVencimento.value;
                }
                else { }
            }
            else { }

            if (level < 1)
            {
                //Preencher DocumentoRecebimentoContasARecebers
                if (((Tables.DocumentoRecebimento)bd).documentoRecebimentoContasARecebers != null)
                {
                    System.Collections.Generic.List<Data.DocumentoRecebimentoContasAReceber> _list = new System.Collections.Generic.List<Data.DocumentoRecebimentoContasAReceber>();

                    foreach (Tables.DocumentoRecebimentoContasAReceber _item in ((Tables.DocumentoRecebimento)bd).documentoRecebimentoContasARecebers)
                    {
                        _list.Add
                        (
                            (Data.DocumentoRecebimentoContasAReceber)
                            (new WS.CRUD.DocumentoRecebimentoContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.DocumentoRecebimentoContasAReceber(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.DocumentoRecebimento)input).documentoRecebimentoContasARecebers = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.DocumentoRecebimento)input).documentoRecebimentoContasARecebers != null)
                    {
                        System.Collections.Generic.List<Data.DocumentoRecebimentoContasAReceber> _list = new System.Collections.Generic.List<Data.DocumentoRecebimentoContasAReceber>();

                        foreach (Data.DocumentoRecebimentoContasAReceber _item in ((Data.DocumentoRecebimento)input).documentoRecebimentoContasARecebers)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.DocumentoRecebimento)input).documentoRecebimentoContasARecebers = _list.ToArray();
                        else
                            ((Data.DocumentoRecebimento)input).documentoRecebimentoContasARecebers = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            if (level < 1)
            {
                //Preencher ContaPagamentoMovimentos
                if (((Tables.DocumentoRecebimento)bd).contaPagamentoMovimentos != null)
                {
                    System.Collections.Generic.List<Data.ContaPagamentoMovimento> _list = new System.Collections.Generic.List<Data.ContaPagamentoMovimento>();

                    foreach (Tables.ContaPagamentoMovimento _item in ((Tables.DocumentoRecebimento)bd).contaPagamentoMovimentos)
                    {
                        _list.Add
                        (
                            (Data.ContaPagamentoMovimento)
                            (new WS.CRUD.ContaPagamentoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ContaPagamentoMovimento(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.DocumentoRecebimento)input).contaPagamentoMovimentos = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.DocumentoRecebimento)input).contaPagamentoMovimentos != null)
                    {
                        System.Collections.Generic.List<Data.ContaPagamentoMovimento> _list = new System.Collections.Generic.List<Data.ContaPagamentoMovimento>();

                        foreach (Data.ContaPagamentoMovimento _item in ((Data.DocumentoRecebimento)input).contaPagamentoMovimentos)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.DocumentoRecebimento)input).contaPagamentoMovimentos = _list.ToArray();
                        else
                            ((Data.DocumentoRecebimento)input).contaPagamentoMovimentos = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimento result = (Data.DocumentoRecebimento)parametros["Key"];

            try
            {
                result = (Data.DocumentoRecebimento)this.preencher
                (
                    new Data.DocumentoRecebimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.DocumentoRecebimento),
                        new Object[]
                        {
                            result.idDocumentoRecebimento
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
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

            Data.DocumentoRecebimento _input = (Data.DocumentoRecebimento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoRecebimento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("documentoRecebimento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoRecebimento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idDocumentoRecebimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoRecebimento.idDocumentoRecebimento = @idDocumentoRecebimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoRecebimento", _input.idDocumentoRecebimento));
                    if (!sqlOrderBy.Contains("documentoRecebimento.idDocumentoRecebimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoRecebimento.idDocumentoRecebimento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   documentoRecebimento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("documentoRecebimento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoRecebimento.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   documentoRecebimento.* " +
                    "from " +
                    "   documentoRecebimento " +
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
            Data.DocumentoRecebimento input = (Data.DocumentoRecebimento)parametros["Key"];
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
                    typeof(Tables.Atendimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.DocumentoRecebimento _data in
                    (System.Collections.Generic.List<Tables.DocumentoRecebimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.DocumentoRecebimento),
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
                    //        _data.descricao.value + ( + _data.codConsCampo.idCadastro.nome.value + )
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.DocumentoRecebimento(), _data, level);

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
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
