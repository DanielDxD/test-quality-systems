using System;

namespace WS.CRUD
{
    public class DocumentoPagamento : WS.CRUD.Base
    {
        public DocumentoPagamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.DocumentoPagamento input = (Data.DocumentoPagamento)parametros["Key"];
            Tables.DocumentoPagamento bd = new Tables.DocumentoPagamento();

            bd.idDocumentoPagamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.dataGeracao.value = input.dataGeracao;
            bd.idEmpresa.value = input.idEmpresa;
            bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            bd.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.serieDocumento.value = input.serieDocumento;
            bd.valorPago.value = input.valorPago;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;
            bd.motivoCancelamento.value = input.motivoCancelamento;
            bd.dataMovimento.value = input.dataMovimento;
            bd.idTipoDocumento.value = input.tipoDocumento.idTipoDocumento;

            this.m_EntityManager.persist(bd);

            ((Data.DocumentoPagamento)parametros["Key"]).idDocumentoPagamento = (int)bd.idDocumentoPagamento.value;

            //Processa DocumentoPagamentoContasAPagar
            if (input.documentoPagamentoContasAPagars != null)
            {
                WS.CRUD.DocumentoPagamentoContasAPagar documentoPagamentoContasAPagarCRUD = new WS.CRUD.DocumentoPagamentoContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.documentoPagamentoContasAPagars.Length; i++)
                {
                    /*if
                    (
                        (
                            input.documentoPagamentoContasAPagars[i].valorPago +
                            input.documentoPagamentoContasAPagars[i].valorMulta +
                            input.documentoPagamentoContasAPagars[i].valorJuros +
                            input.documentoPagamentoContasAPagars[i].valorCM -
                            (
                                input.documentoPagamentoContasAPagars[i].valorDesconto +

                                input.documentoPagamentoContasAPagars[i].valorINSSRetido +
                                input.documentoPagamentoContasAPagars[i].valorISSRetido +
                                input.documentoPagamentoContasAPagars[i].valorIRRetido +
                                input.documentoPagamentoContasAPagars[i].valorPISRetido +
                                input.documentoPagamentoContasAPagars[i].valorCOFINSRetido +
                                input.documentoPagamentoContasAPagars[i].valorCSLLRetido
                            )
                        ) > 0.00
                    )
                    {
                        
                    }
                    else { } */
                    input.documentoPagamentoContasAPagars[i].idDocumentoPagamento = bd.idDocumentoPagamento.value;
                    _parameters.Add("Key", input.documentoPagamentoContasAPagars[i]);
                    documentoPagamentoContasAPagarCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                documentoPagamentoContasAPagarCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoPagamento input = (Data.DocumentoPagamento)parametros["Key"];
            Tables.DocumentoPagamento bd = (Tables.DocumentoPagamento)this.m_EntityManager.find
            (
                typeof(Tables.DocumentoPagamento),
                new Object[]
                {
                    input.idDocumentoPagamento
                }
            );

            bd.descricao.value = input.descricao;
            bd.dataGeracao.value = input.dataGeracao;
            bd.idEmpresa.value = input.idEmpresa;
            bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            bd.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.serieDocumento.value = input.serieDocumento;
            bd.valorPago.value = input.valorPago;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;
            bd.motivoCancelamento.value = input.motivoCancelamento;
            bd.dataMovimento.value = input.dataMovimento;
            bd.idTipoDocumento.value = input.tipoDocumento.idTipoDocumento;

            this.m_EntityManager.merge(bd);

            //Processa DocumentoPagamentoContasAPagar
            if (input.documentoPagamentoContasAPagars != null)
            {
                WS.CRUD.DocumentoPagamentoContasAPagar documentoPagamentoContasAPagarCRUD = new WS.CRUD.DocumentoPagamentoContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.documentoPagamentoContasAPagars.Length; i++)
                {
                    /*if
                    (
                        (
                            input.documentoPagamentoContasAPagars[i].valorPago +
                            input.documentoPagamentoContasAPagars[i].valorMulta +
                            input.documentoPagamentoContasAPagars[i].valorJuros +
                            input.documentoPagamentoContasAPagars[i].valorCM -
                            (
                                input.documentoPagamentoContasAPagars[i].valorDesconto +

                                input.documentoPagamentoContasAPagars[i].valorINSSRetido +
                                input.documentoPagamentoContasAPagars[i].valorISSRetido +
                                input.documentoPagamentoContasAPagars[i].valorIRRetido +
                                input.documentoPagamentoContasAPagars[i].valorPISRetido +
                                input.documentoPagamentoContasAPagars[i].valorCOFINSRetido +
                                input.documentoPagamentoContasAPagars[i].valorCSLLRetido
                            )
                        ) > 0.00
                    )
                    {

                    }
                    else { }*/
                    input.documentoPagamentoContasAPagars[i].idDocumentoPagamento = bd.idDocumentoPagamento.value;
                    _parameters.Add("Key", input.documentoPagamentoContasAPagars[i]);
                    documentoPagamentoContasAPagarCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                documentoPagamentoContasAPagarCRUD = null;
                _parameters = null;
            }
            else { }


            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.DocumentoPagamento bd = new Tables.DocumentoPagamento();

            bd.idDocumentoPagamento.value = ((Data.DocumentoPagamento)parametros["Key"]).idDocumentoPagamento;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.DocumentoPagamento)bd).idDocumentoPagamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.DocumentoPagamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.DocumentoPagamento)input).idDocumentoPagamento = ((Tables.DocumentoPagamento)bd).idDocumentoPagamento.value;
                    ((Data.DocumentoPagamento)input).descricao = ((Tables.DocumentoPagamento)bd).descricao.value;
                    ((Data.DocumentoPagamento)input).dataGeracao = ((Tables.DocumentoPagamento)bd).dataGeracao.value;
                    ((Data.DocumentoPagamento)input).idEmpresa = ((Tables.DocumentoPagamento)bd).idEmpresa.value;
                    ((Data.DocumentoPagamento)input).idContaPagamento = ((Tables.DocumentoPagamento)bd).idContaPagamento.value;
                    ((Data.DocumentoPagamento)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.DocumentoPagamento)bd).contaPagamento,
                        level + 1
                    );
                    ((Data.DocumentoPagamento)input).numeroDocumento = ((Tables.DocumentoPagamento)bd).numeroDocumento.value;
                    ((Data.DocumentoPagamento)input).serieDocumento = ((Tables.DocumentoPagamento)bd).serieDocumento.value;
                    ((Data.DocumentoPagamento)input).valorPago = ((Tables.DocumentoPagamento)bd).valorPago.value;
                    ((Data.DocumentoPagamento)input).dataCancelamento = ((Tables.DocumentoPagamento)bd).dataCancelamento.value;
                    ((Data.DocumentoPagamento)input).motivoCancelamento = ((Tables.DocumentoPagamento)bd).motivoCancelamento.value;
                    ((Data.DocumentoPagamento)input).dataMovimento = ((Tables.DocumentoPagamento)bd).dataMovimento.value;

                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();
                    _parameters.Add("Key", new Data.TipoDocumento { idTipoDocumento = ((Tables.DocumentoPagamento)bd).idTipoDocumento.value });
                    ((Data.DocumentoPagamento)input).tipoDocumento = (Data.TipoDocumento)(new WS.CRUD.TipoDocumento(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parameters);
                    _parameters.Clear();
                    _parameters = null;
                }
                else { }
            }
            else { }

            if (level < 1)
            {
                //Preencher DocumentoPagamentoContasAPagars
                if (((Tables.DocumentoPagamento)bd).documentoPagamentoContasAPagars != null)
                {
                    System.Collections.Generic.List<Data.DocumentoPagamentoContasAPagar> _list = new System.Collections.Generic.List<Data.DocumentoPagamentoContasAPagar>();

                    foreach (Tables.DocumentoPagamentoContasAPagar _item in ((Tables.DocumentoPagamento)bd).documentoPagamentoContasAPagars)
                    {
                        _list.Add
                        (
                            (Data.DocumentoPagamentoContasAPagar)
                            (new WS.CRUD.DocumentoPagamentoContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.DocumentoPagamentoContasAPagar(),
                                _item,
                                level
                            )
                        );
                    }

                    ((Data.DocumentoPagamento)input).documentoPagamentoContasAPagars = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoPagamento result = (Data.DocumentoPagamento)parametros["Key"];

            try
            {
                result = (Data.DocumentoPagamento)this.preencher
                (
                    new Data.DocumentoPagamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.DocumentoPagamento),
                        new Object[]
                        {
                            result.idDocumentoPagamento
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

            Data.DocumentoPagamento _input = (Data.DocumentoPagamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("documentoPagamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idDocumentoPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.idDocumentoPagamento = @idDocumentoPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoPagamento", _input.idDocumentoPagamento));
                    if (!sqlOrderBy.Contains("documentoPagamento.idDocumentoPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idDocumentoPagamento");
                    else { }
                }
                else { }

                if (_input.contaPagamento != null && _input.contaPagamento.idContaPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.idContaPagamento = @idContaPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.contaPagamento.idContaPagamento));
                    if (!sqlOrderBy.Contains("documentoPagamento.idContaPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idContaPagamento");
                    else { }
                }
                else { }

                if (_input.idContaPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.idContaPagamento = @idContaPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.idContaPagamento));
                    if (!sqlOrderBy.Contains("documentoPagamento.idContaPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idContaPagamento");
                    else { }
                }
                else { }

                if (_input.tipoDocumento != null)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoDocumento.cheque = @cheque");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cheque", _input.tipoDocumento.cheque ? "S" : "N"));
                    if (!sqlOrderBy.Contains("tipoDocumento.cheque"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoDocumento.cheque");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   documentoPagamento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", '%' + _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("documentoPagamento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "documentoPagamento.* ") +
                    "from " +
                    "   documentoPagamento " +
                    "   inner join tipoDocumento ON tipoDocumento.idTipoDocumento = documentoPagamento.idTipoDocumento " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    ( onlyCount ? "" : 
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
            Data.DocumentoPagamento input = (Data.DocumentoPagamento)parametros["Key"];
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
                    typeof(Tables.DocumentoPagamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.DocumentoPagamento _data in
                    (System.Collections.Generic.List<Tables.DocumentoPagamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.DocumentoPagamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.DocumentoPagamento();
                        ((Data.DocumentoPagamento)_base).idDocumentoPagamento = _data.idDocumentoPagamento.value;
                        ((Data.DocumentoPagamento)_base).descricao = _data.descricao.value;
                        ((Data.DocumentoPagamento)_base).dataGeracao = _data.dataGeracao.value;
                        ((Data.DocumentoPagamento)_base).numeroDocumento = _data.numeroDocumento.value;
                        ((Data.DocumentoPagamento)_base).valorPago = _data.valorPago.value;

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.DocumentoPagamento(), _data, level);

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
