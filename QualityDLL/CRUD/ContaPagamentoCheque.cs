using System;

namespace WS.CRUD
{
    public class ContaPagamentoCheque : WS.CRUD.Base
    {
        public ContaPagamentoCheque(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoCheque input = (Data.ContaPagamentoCheque)parametros["Key"];
            Tables.ContaPagamentoCheque bd = new Tables.ContaPagamentoCheque();

            bd.idContaPagamentoCheque.isNull = true;
            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.idContaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else { }
            if ((input.documentoPagamento != null) && (input.documentoPagamento.idDocumentoPagamento > 0))
                bd.idDocumentoPagamento.idDocumentoPagamento.value = input.documentoPagamento.idDocumentoPagamento;
            else { }
            if ((input.documentoTransferencia != null) && (input.documentoTransferencia.idDocumentoTransferencia > 0))
                bd.idDocumentoTransferencia.idDocumentoTransferencia.value = input.documentoTransferencia.idDocumentoTransferencia;
            else { }

            bd.numero.value = input.numero;
            bd.dataEmissao.value = input.dataEmissao;
            bd.valor.value = input.valor;
            bd.valorExtenso.value = input.valorExtenso;
            bd.dataCancelamento.value = input.dataCancelamento;

            this.m_EntityManager.persist(bd);

            ((Data.ContaPagamentoCheque)parametros["Key"]).idContaPagamentoCheque = (int)bd.idContaPagamentoCheque.value;

            return input; // this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoCheque input = (Data.ContaPagamentoCheque)parametros["Key"];
            Tables.ContaPagamentoCheque bd = (Tables.ContaPagamentoCheque)this.m_EntityManager.find
            (
                typeof(Tables.ContaPagamentoCheque),
                new Object[]
                {
                    input.idContaPagamentoCheque
                }
            );

            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.idContaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else { }
            if ((input.documentoPagamento != null) && (input.documentoPagamento.idDocumentoPagamento > 0))
                bd.idDocumentoPagamento.idDocumentoPagamento.value = input.documentoPagamento.idDocumentoPagamento;
            else { }
            if ((input.documentoTransferencia != null) && (input.documentoTransferencia.idDocumentoTransferencia > 0))
                bd.idDocumentoTransferencia.idDocumentoTransferencia.value = input.documentoTransferencia.idDocumentoTransferencia;
            else { }
            bd.numero.value = input.numero;
            bd.dataEmissao.value = input.dataEmissao;
            bd.valor.value = input.valor;
            bd.valorExtenso.value = input.valorExtenso;
            bd.dataCancelamento.value = input.dataCancelamento;

            this.m_EntityManager.merge(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContaPagamentoCheque bd = new Tables.ContaPagamentoCheque();

            bd.idContaPagamentoCheque.value = ((Data.ContaPagamentoCheque)parametros["Key"]).idContaPagamentoCheque;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContaPagamentoCheque)bd).idContaPagamentoCheque.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContaPagamentoCheque)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContaPagamentoCheque)input).idContaPagamentoCheque = ((Tables.ContaPagamentoCheque)bd).idContaPagamentoCheque.value;
                    ((Data.ContaPagamentoCheque)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.ContaPagamentoCheque)bd).idContaPagamento,
                        level
                    );
                    ((Data.ContaPagamentoCheque)input).documentoPagamento = (Data.DocumentoPagamento)(new WS.CRUD.DocumentoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.DocumentoPagamento(),
                        ((Tables.ContaPagamentoCheque)bd).idDocumentoPagamento,
                        level
                    );

                    ((Data.ContaPagamentoCheque)input).documentoTransferencia = (Data.DocumentoTransferencia)(new WS.CRUD.DocumentoTransferencia(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.DocumentoTransferencia(),
                        ((Tables.ContaPagamentoCheque)bd).idDocumentoTransferencia,
                        level
                    );
                    ((Data.ContaPagamentoCheque)input).numero = ((Tables.ContaPagamentoCheque)bd).numero.value;
                    ((Data.ContaPagamentoCheque)input).dataEmissao = ((Tables.ContaPagamentoCheque)bd).dataEmissao.value;
                    ((Data.ContaPagamentoCheque)input).valor = ((Tables.ContaPagamentoCheque)bd).valor.value;
                    ((Data.ContaPagamentoCheque)input).valorExtenso = ((Tables.ContaPagamentoCheque)bd).valorExtenso.value;
                    ((Data.ContaPagamentoCheque)input).dataCancelamento = ((Tables.ContaPagamentoCheque)bd).dataCancelamento.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoCheque result = (Data.ContaPagamentoCheque)parametros["Key"];

            try
            {
                result = (Data.ContaPagamentoCheque)this.preencher
                (
                    new Data.ContaPagamentoCheque(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContaPagamentoCheque),
                        new Object[]
                        {
                            result.idContaPagamentoCheque
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

        //Emissao, Código, Descricao, Número
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

            Data.ContaPagamentoCheque _input = (Data.ContaPagamentoCheque)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContaPagamentoCheque > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoCheque.idContaPagamentoCheque = @idContaPagamentoCheque");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamentoCheque", _input.idContaPagamentoCheque));
                    if (!sqlOrderBy.Contains("contaPagamentoCheque.idContaPagamentoCheque"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamentoCheque.idContaPagamentoCheque");
                    else { }
                }
                else { }

                if (_input.dataEmissao.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamentoCheque.dataEmissao = @dataEmissao");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataEmissao", _input.dataEmissao));
                }
                else { }

                if (_input.documentoPagamento != null)
                {
                    if (_input.documentoPagamento.idDocumentoPagamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.idDocumentoPagamento = @idDocumentoPagamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoPagamento", _input.documentoPagamento.idDocumentoPagamento));
                        if (!sqlOrderBy.Contains("documentoPagamento.idDocumentoPagamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idDocumentoPagamento");
                        else { }
                    }
                    else { }

                    if (_input.documentoPagamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.idEmpresa = @documentoPagamentoIdEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("documentoPagamentoIdEmpresa", _input.documentoPagamento.idEmpresa));
                        if (!sqlOrderBy.Contains("documentoPagamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.documentoPagamento.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamento.descricao like @descricao");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.documentoPagamento.descricao + "%"));
                        if (!sqlOrderBy.Contains("documentoPagamento.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.descricao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.documentoTransferencia != null)
                {

                    if (_input.documentoTransferencia.idDocumentoTransferencia > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoTransferencia.idDocumentoTransferencia = @idDocumentoTransferencia");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoTransferencia", _input.documentoTransferencia.idDocumentoTransferencia));
                        if (!sqlOrderBy.Contains("documentoTransferencia.idDocumentoTransferencia"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.idDocumentoTransferencia");
                        else { }
                    }
                    else { }

                    if (_input.documentoTransferencia.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoTransferencia.idEmpresa = @documentoTransferenciaIdEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("documentoTransferenciaIdEmpresa", _input.documentoTransferencia.idEmpresa));
                        if (!sqlOrderBy.Contains("documentoTransferencia.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.idEmpresa");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.documentoTransferencia.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoTransferencia.descricao like @descricao");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.documentoTransferencia.descricao + "%"));
                        if (!sqlOrderBy.Contains("documentoTransferencia.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoTransferencia.descricao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.contaPagamento != null)
                {
                    if (_input.contaPagamento.idContaPagamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.idContaPagamento = @idContaPagamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.contaPagamento.idContaPagamento));
                        if (!sqlOrderBy.Contains("documentoPagamento.idContaPagamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamento.idContaPagamento");
                        else { }
                    }
                    else { }

                    if (_input.contaPagamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.contaPagamento.idEmpresa));
                        if (!sqlOrderBy.Contains("contaPagamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.contaPagamento.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.descricao like @descricaoContaPagamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoContaPagamento", _input.contaPagamento.descricao + "%"));
                        if (!sqlOrderBy.Contains("contaPagamento.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.descricao");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   contaPagamentoCheque.* " +
                    "from " +
                    (
                        "   contaPagamentoCheque contaPagamentoCheque " +
                        "       left join documentoPagamento documentoPagamento " +
                        "           on	documentoPagamento.idDocumentoPagamento = contaPagamentoCheque.idDocumentoPagamento " +
                        "       left join documentoTransferencia documentoTransferencia " +
                        "           on	documentoTransferencia.idDocumentoTransferencia = contaPagamentoCheque.idDocumentoTransferencia " +
                        "       inner join contaPagamento contaPagamento " +
                        "           on	contaPagamento.idContaPagamento = contaPagamentoCheque.idContaPagamento "
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
            Data.ContaPagamentoCheque input = (Data.ContaPagamentoCheque)parametros["Key"];
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
                    typeof(Tables.ContasAPagar),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContaPagamentoCheque _data in
                    (System.Collections.Generic.List<Tables.ContaPagamentoCheque>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContaPagamentoCheque),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.ContaPagamentoCheque();
                        ((Data.ContaPagamentoCheque)_base).idContaPagamentoCheque = _data.idContaPagamentoCheque.value;
                        ((Data.ContaPagamentoCheque)_base).numero = _data.numero.value;
                        ((Data.ContaPagamentoCheque)_base).valor = _data.valor.value;
                        ((Data.ContaPagamentoCheque)_base).valorExtenso = _data.valorExtenso.value;
                        ((Data.ContaPagamentoCheque)_base).valor = _data.valor.value;
                        ((Data.ContaPagamentoCheque)_base).dataEmissao = _data.dataEmissao.value;
                        ((Data.ContaPagamentoCheque)_base).dataCancelamento = _data.dataCancelamento.value;
                        ((Data.ContaPagamentoCheque)_base).documentoPagamento = new Data.DocumentoPagamento();
                        if (_data.idDocumentoPagamento.idDocumentoPagamento.value > 0)
                        {
                            ((Data.ContaPagamentoCheque)_base).documentoPagamento = (Data.DocumentoPagamento)(new WS.CRUD.DocumentoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.DocumentoPagamento(),
                                ((Tables.ContaPagamentoCheque)_data).idDocumentoPagamento,
                                level + 1
                            );
                        }
                        else { }
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContaPagamentoCheque(), _data, level);


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
    }
}
