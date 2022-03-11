using System;

namespace WS.CRUD
{
    public class DocumentoPagamentoContasAPagar : WS.CRUD.Base
    {
        public DocumentoPagamentoContasAPagar(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.DocumentoPagamentoContasAPagar input = (Data.DocumentoPagamentoContasAPagar)parametros["Key"];
            Tables.DocumentoPagamentoContasAPagar bd = new Tables.DocumentoPagamentoContasAPagar();

            bd.idDocumentoPagamentoContasAPagar.isNull = true;
            bd.idDocumentoPagamento.value = input.idDocumentoPagamento;
            bd.contasAPagar.idContasAPagar.value = input.contasAPagar.idContasAPagar;
            bd.valorBase.value = input.valorBase;
            bd.valorPago.value = input.valorPago;

            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;

            this.m_EntityManager.persist(bd);

            ((Data.DocumentoPagamentoContasAPagar)parametros["Key"]).idDocumentoPagamentoContasAPagar = (int)bd.idDocumentoPagamentoContasAPagar.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoPagamentoContasAPagar input = (Data.DocumentoPagamentoContasAPagar)parametros["Key"];
            Tables.DocumentoPagamentoContasAPagar bd = (Tables.DocumentoPagamentoContasAPagar)this.m_EntityManager.find
            (
                typeof(Tables.DocumentoPagamentoContasAPagar),
                new Object[]
                {
                    input.idDocumentoPagamentoContasAPagar
                }
            );

            bd.idDocumentoPagamento.value = input.idDocumentoPagamento;
            bd.contasAPagar.idContasAPagar.value = input.contasAPagar.idContasAPagar;
            bd.valorBase.value = input.valorBase;
            bd.valorPago.value = input.valorPago;

            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.DocumentoPagamentoContasAPagar bd = new Tables.DocumentoPagamentoContasAPagar();

            bd.idDocumentoPagamentoContasAPagar.value = ((Data.DocumentoPagamentoContasAPagar)parametros["Key"]).idDocumentoPagamentoContasAPagar;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.DocumentoPagamentoContasAPagar)bd).idDocumentoPagamentoContasAPagar.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.DocumentoPagamentoContasAPagar)input).operacao = ENum.eOperacao.NONE;

                    ((Data.DocumentoPagamentoContasAPagar)input).idDocumentoPagamentoContasAPagar = ((Tables.DocumentoPagamentoContasAPagar)bd).idDocumentoPagamentoContasAPagar.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).idDocumentoPagamento = ((Tables.DocumentoPagamentoContasAPagar)bd).idDocumentoPagamento.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).contasAPagar = (Data.ContasAPagar)(new WS.CRUD.ContasAPagar(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAPagar(),
                        ((Tables.DocumentoPagamentoContasAPagar)bd).contasAPagar,
                        level
                    );
                    ((Data.DocumentoPagamentoContasAPagar)input).valorBase = ((Tables.DocumentoPagamentoContasAPagar)bd).valorBase.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorPago = ((Tables.DocumentoPagamentoContasAPagar)bd).valorPago.value;

                    ((Data.DocumentoPagamentoContasAPagar)input).valorMulta = ((Tables.DocumentoPagamentoContasAPagar)bd).valorMulta.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorJuros = ((Tables.DocumentoPagamentoContasAPagar)bd).valorJuros.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorDesconto = ((Tables.DocumentoPagamentoContasAPagar)bd).valorDesconto.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorCM = ((Tables.DocumentoPagamentoContasAPagar)bd).valorCM.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorINSSRetido = ((Tables.DocumentoPagamentoContasAPagar)bd).valorINSSRetido.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorISSRetido = ((Tables.DocumentoPagamentoContasAPagar)bd).valorISSRetido.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorIRRetido = ((Tables.DocumentoPagamentoContasAPagar)bd).valorIRRetido.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorPISRetido = ((Tables.DocumentoPagamentoContasAPagar)bd).valorPISRetido.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorCOFINSRetido = ((Tables.DocumentoPagamentoContasAPagar)bd).valorCOFINSRetido.value;
                    ((Data.DocumentoPagamentoContasAPagar)input).valorCSLLRetido = ((Tables.DocumentoPagamentoContasAPagar)bd).valorCSLLRetido.value;

                    //((Data.DocumentoPagamentoContasAPagar)input).valorABaixar =
                    //(
                    //    ((Data.DocumentoPagamentoContasAPagar)input).valorPago +
                    //    ((Data.DocumentoPagamentoContasAPagar)input).valorMulta +
                    //    ((Data.DocumentoPagamentoContasAPagar)input).valorJuros +
                    //    ((Data.DocumentoPagamentoContasAPagar)input).valorCM -
                    //    ((Data.DocumentoPagamentoContasAPagar)input).valorDesconto
                    //);
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoPagamentoContasAPagar result = (Data.DocumentoPagamentoContasAPagar)parametros["Key"];

            try
            {
                result = (Data.DocumentoPagamentoContasAPagar)this.preencher
                (
                    new Data.DocumentoPagamentoContasAPagar(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.DocumentoPagamentoContasAPagar),
                        new Object[]
                        {
                            result.idDocumentoPagamentoContasAPagar
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

            Boolean
                cancelado = false;

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

            Data.DocumentoPagamentoContasAPagar _input = (Data.DocumentoPagamentoContasAPagar)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idDocumentoPagamentoContasAPagar > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamentoContasAPagar.idDocumentoPagamentoContasAPagar = @idDocumentoPagamentoContasAPagar");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoPagamentoContasAPagar", _input.idDocumentoPagamentoContasAPagar));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamentoContasAPagar.idDocumentoPagamentoContasAPagar");
                }
                else { }

                if (_input.idDocumentoPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoPagamentoContasAPagar.idDocumentoPagamento = @idDocumentoPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoPagamento", _input.idDocumentoPagamento));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoPagamentoContasAPagar.idDocumentoPagamento");
                }
                else { }

                if (_input.contasAPagar != null)
                {
                    if (_input.contasAPagar.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.contasAPagar.idEmpresa));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.idEmpresa");
                    }
                    else { }

                    if (_input.contasAPagar.idContasAPagar > 0)
                    {
                        cancelado = true;
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagar.idContasAPagar = @idContasAPagar");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAPagar", _input.contasAPagar.idContasAPagar));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagar.idContasAPagar");
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   documentoPagamentoContasAPagar.* " +
                    "from " +
                    (
                        "   documentoPagamentoContasAPagar documentoPagamentoContasAPagar " +
                        "       inner join documentoPagamento documentoPagamento " +
                        "           on  documentoPagamento.idDocumentoPagamento = documentoPagamentoContasAPagar.idDocumentoPagamento " +
                        "       inner join contasAPagar contasAPagar " +
                        "           on  contasAPagar.idContasAPagar = documentoPagamentoContasAPagar.idContasAPagar " +
                                    (cancelado ? " and documentoPagamento.dataCancelamento is null " : "") +
                        "       left join fornecedor fornecedor " +
                        "           on	fornecedor.idFornecedor = contasAPagar.idFornecedor " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = contasAPagar.idEmpresaRelacionamento " +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento "
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
            Data.DocumentoPagamentoContasAPagar input = (Data.DocumentoPagamentoContasAPagar)parametros["Key"];
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
                    typeof(Tables.DocumentoPagamentoContasAPagar),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.DocumentoPagamentoContasAPagar _data in
                    (System.Collections.Generic.List<Tables.DocumentoPagamentoContasAPagar>)this.m_EntityManager.list
                    (
                        typeof(Tables.DocumentoPagamentoContasAPagar),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.DocumentoPagamentoContasAPagar(), _data, level);

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
