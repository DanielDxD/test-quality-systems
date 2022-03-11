using System;

namespace WS.CRUD
{
    public class DocumentoTransferencia : WS.CRUD.Base
    {
        public DocumentoTransferencia(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.DocumentoTransferencia input = (Data.DocumentoTransferencia)parametros["Key"];
            Tables.DocumentoTransferencia bd = new Tables.DocumentoTransferencia();

            bd.idDocumentoTransferencia.isNull = true;
            bd.idEmpresa.idEmpresa.value = input.idEmpresa;
            bd.idContaPagamentoOrigem.idContaPagamento.value = input.contaPagamentoOrigem.idContaPagamento;
            bd.idContaPagamentoDestino.idContaPagamento.value = input.contaPagamentoDestino.idContaPagamento;
            bd.dataGeracao.value = input.dataGeracao;
            bd.dataMovimento.value = input.dataMovimento;
            bd.descricao.value = input.descricao;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.valorTransferido.value = input.valorTransferido;

            this.m_EntityManager.persist(bd);

            ((Data.DocumentoTransferencia)parametros["Key"]).idDocumentoTransferencia = (int)bd.idDocumentoTransferencia.value;

            //Processa DocumentoTransferenciaItem
            if (input.documentoTransferenciaItems != null)
            {
                WS.CRUD.DocumentoTransferenciaItem documentoTransferenciaItemCRUD = new WS.CRUD.DocumentoTransferenciaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.documentoTransferenciaItems.Length; i++)
                {
                    input.documentoTransferenciaItems[i].idDocumentoTransferencia = bd.idDocumentoTransferencia.value;
                    _parameters.Add("Key", input.documentoTransferenciaItems[i]);
                    documentoTransferenciaItemCRUD.atualizar(_parameters);
                    if (input.documentoTransferenciaItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.documentoTransferenciaItems[i] = (Data.DocumentoTransferenciaItem)documentoTransferenciaItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                documentoTransferenciaItemCRUD = null;

                _parameters = null;
            }
            else { }

            return input /*this.preencher(input, bd, 0)*/;
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoTransferencia input = (Data.DocumentoTransferencia)parametros["Key"];
            Tables.DocumentoTransferencia bd = (Tables.DocumentoTransferencia)this.m_EntityManager.find
            (
                typeof(Tables.DocumentoTransferencia),
                new Object[]
                {
                    input.idDocumentoTransferencia
                }
            );

            bd.idEmpresa.idEmpresa.value = input.idEmpresa;
            bd.idContaPagamentoOrigem.idContaPagamento.value = input.contaPagamentoOrigem.idContaPagamento;
            bd.idContaPagamentoDestino.idContaPagamento.value = input.contaPagamentoDestino.idContaPagamento;
            bd.dataGeracao.value = input.dataGeracao;
            bd.dataMovimento.value = input.dataMovimento;
            bd.descricao.value = input.descricao;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.valorTransferido.value = input.valorTransferido;

            this.m_EntityManager.merge(bd);

            //Processa DocumentoTransferenciaItem
            if (input.documentoTransferenciaItems != null)
            {
                WS.CRUD.DocumentoTransferenciaItem documentoTransferenciaItemCRUD = new WS.CRUD.DocumentoTransferenciaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.documentoTransferenciaItems.Length; i++)
                {
                    input.documentoTransferenciaItems[i].idDocumentoTransferencia = bd.idDocumentoTransferencia.value;
                    _parameters.Add("Key", input.documentoTransferenciaItems[i]);
                    documentoTransferenciaItemCRUD.atualizar(_parameters);
                    if (input.documentoTransferenciaItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.documentoTransferenciaItems[i] = (Data.DocumentoTransferenciaItem)documentoTransferenciaItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                documentoTransferenciaItemCRUD = null;

                _parameters = null;
            }
            else { }

            return input /*this.preencher(input, bd, 0)*/;
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.DocumentoTransferencia bd = new Tables.DocumentoTransferencia();

            bd.idDocumentoTransferencia.value = ((Data.DocumentoTransferencia)parametros["Key"]).idDocumentoTransferencia;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.DocumentoTransferencia)bd).idDocumentoTransferencia.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.DocumentoTransferencia)input).operacao = ENum.eOperacao.NONE;

                    ((Data.DocumentoTransferencia)input).idDocumentoTransferencia = ((Tables.DocumentoTransferencia)bd).idDocumentoTransferencia.value;
                    ((Data.DocumentoTransferencia)input).idEmpresa = ((Tables.DocumentoTransferencia)bd).idEmpresa.idEmpresa.value;
                    ((Data.DocumentoTransferencia)input).contaPagamentoOrigem = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.DocumentoTransferencia)bd).idContaPagamentoOrigem,
                        level + 1
                    );
                    ((Data.DocumentoTransferencia)input).contaPagamentoDestino = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.DocumentoTransferencia)bd).idContaPagamentoDestino,
                        level + 1
                    );
                    ((Data.DocumentoTransferencia)input).dataGeracao = ((Tables.DocumentoTransferencia)bd).dataGeracao.value;
                    ((Data.DocumentoTransferencia)input).dataMovimento = ((Tables.DocumentoTransferencia)bd).dataMovimento.value;
                    ((Data.DocumentoTransferencia)input).descricao = ((Tables.DocumentoTransferencia)bd).descricao.value;
                    ((Data.DocumentoTransferencia)input).numeroDocumento = ((Tables.DocumentoTransferencia)bd).numeroDocumento.value;
                    ((Data.DocumentoTransferencia)input).valorTransferido = ((Tables.DocumentoTransferencia)bd).valorTransferido.value;

                    if (level < 1)
                    {
                        //Preencher DocumentoTransferenciaItems
                        if (((Tables.DocumentoTransferencia)bd).documentoTransferenciaItems != null)
                        {
                            System.Collections.Generic.List<Data.DocumentoTransferenciaItem> _list = new System.Collections.Generic.List<Data.DocumentoTransferenciaItem>();

                            foreach (Tables.DocumentoTransferenciaItem _item in ((Tables.DocumentoTransferencia)bd).documentoTransferenciaItems)
                            {
                                _list.Add
                                (
                                    (Data.DocumentoTransferenciaItem)
                                    (new WS.CRUD.DocumentoTransferenciaItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.DocumentoTransferenciaItem(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.DocumentoTransferencia)input).documentoTransferenciaItems = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.DocumentoTransferencia)input).documentoTransferenciaItems != null)
                            {
                                System.Collections.Generic.List<Data.DocumentoTransferenciaItem> _list = new System.Collections.Generic.List<Data.DocumentoTransferenciaItem>();

                                foreach (Data.DocumentoTransferenciaItem _item in ((Data.DocumentoTransferencia)input).documentoTransferenciaItems)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.DocumentoTransferencia)input).documentoTransferenciaItems = _list.ToArray();
                                else
                                    ((Data.DocumentoTransferencia)input).documentoTransferenciaItems = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                    else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoTransferencia result = (Data.DocumentoTransferencia)parametros["Key"];

            try
            {
                result = (Data.DocumentoTransferencia)this.preencher
                (
                    new Data.DocumentoTransferencia(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.DocumentoTransferencia),
                        new Object[]
                        {
                            result.idDocumentoTransferencia
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

            Data.DocumentoTransferencia _input = (Data.DocumentoTransferencia)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoTransferencia.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("documentoTransferencia.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idDocumentoTransferencia > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoTransferencia.idDocumentoTransferencia = @idDocumentoTransferencia");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoTransferencia", _input.idDocumentoTransferencia));
                    if (!sqlOrderBy.Contains("documentoTransferencia.idDocumentoTransferencia"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.idDocumentoTransferencia");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   documentoTransferencia.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", '%' + _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("documentoTransferencia.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.descricao");
                    else { }
                }
                else { }

                if (_input.valorTransferido > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   documentoTransferencia.valorTransferido = @valorTransferido");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valorTransferido", _input.valorTransferido));
                    if (!sqlOrderBy.Contains("documentoTransferencia.valorTransferido"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.valorTransferido");
                    else { }
                }
                else { }

               

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "documentoTransferencia.* ") +
                    "from " +
                    "   documentoTransferencia " +
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoTransferencia input = (Data.DocumentoTransferencia)parametros["Key"];
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
                    Tables.DocumentoTransferencia _data in
                    (System.Collections.Generic.List<Tables.DocumentoTransferencia>)this.m_EntityManager.list
                    (
                        typeof(Tables.DocumentoTransferencia),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.DocumentoTransferencia();
                        ((Data.DocumentoTransferencia)_base).idDocumentoTransferencia = _data.idDocumentoTransferencia.value;
                        ((Data.DocumentoTransferencia)_base).descricao = _data.descricao.value;
                        ((Data.DocumentoTransferencia)_base).idEmpresa = _data.idEmpresa.idEmpresa.value;
                        ((Data.DocumentoTransferencia)_base).dataGeracao = _data.dataGeracao.value;
                        ((Data.DocumentoTransferencia)_base).dataMovimento = _data.dataMovimento.value;
                        ((Data.DocumentoTransferencia)_base).numeroDocumento = _data.numeroDocumento.value;
                        ((Data.DocumentoTransferencia)_base).valorTransferido = _data.valorTransferido.value;
                        ((Data.DocumentoTransferencia)_base).contaPagamentoOrigem = new Data.ContaPagamento
                        {
                            idContaPagamento = _data.idContaPagamentoOrigem.idContaPagamento.value,
                            descricao = _data.idContaPagamentoOrigem.descricao.value
                        };
                        ((Data.DocumentoTransferencia)_base).contaPagamentoDestino = new Data.ContaPagamento
                        {
                            idContaPagamento = _data.idContaPagamentoDestino.idContaPagamento.value,
                            descricao = _data.idContaPagamentoDestino.descricao.value
                        };
                        
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.DocumentoTransferencia(), _data, level);

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
