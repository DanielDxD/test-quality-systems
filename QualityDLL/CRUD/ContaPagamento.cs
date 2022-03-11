using System;

namespace WS.CRUD
{
    public class ContaPagamento : WS.CRUD.Base
    {
        public ContaPagamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamento input = (Data.ContaPagamento)parametros["Key"];
            Tables.ContaPagamento bd = new Tables.ContaPagamento();

            bd.idContaPagamento.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            bd.descricao.value = input.descricao;
            if ((input.banco != null) && (input.banco.idBanco > 0))
                bd.banco.idBanco.value = input.banco.idBanco;
            else
                bd.banco.idBanco.isNull = true;
            bd.numeroConta.value = input.numeroConta;
            bd.tipoConta.value = input.tipoConta;
            if (input.idUsuario > 0)
                bd.idUsuario.value = input.idUsuario;
            else
                bd.idUsuario.isNull = true;
            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else
                bd.planoContas.idPlanoContas.isNull = true;
            bd.saldoAtual.value = input.saldoAtual;
            bd.recebimentoVinculado.value = input.recebimentoVinculado;
            bd.pagamentoVinculado.value = input.pagamentoVinculado;
            if (input.numeroChequeInicial > 0)
                bd.numeroChequeInicial.value = input.numeroChequeInicial;
            else
                bd.numeroChequeInicial.isNull = true;
            if (input.numeroChequeFinal > 0)
                bd.numeroChequeFinal.value = input.numeroChequeFinal;
            else
                bd.numeroChequeFinal.isNull = true;

            if ((input.formaPagamento != null) && (input.formaPagamento.idFormaPagamento > 0))
                bd.formaPagamento.idFormaPagamento.value = input.formaPagamento.idFormaPagamento;
            else
                bd.formaPagamento.idFormaPagamento.isNull = true;

            bd.codigoExportacao.isNull = true;
            if (!String.IsNullOrEmpty(input.codigoExportacao))
                bd.codigoExportacao.value = input.codigoExportacao;
            else { }

            bd.agencia.value = input.agencia;
            bd.agenciaDigito.value = input.agenciaDigito;
            bd.numeroContaDigito.value = input.numeroContaDigito;

            this.m_EntityManager.persist(bd);

            ((Data.ContaPagamento)parametros["Key"]).idContaPagamento = (int)bd.idContaPagamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamento input = (Data.ContaPagamento)parametros["Key"];
            Tables.ContaPagamento bd = (Tables.ContaPagamento)this.m_EntityManager.find
            (
                typeof(Tables.ContaPagamento),
                new Object[]
                {
                    input.idContaPagamento
                }
            );

            bd.idEmpresa.value = input.idEmpresa;
            bd.descricao.value = input.descricao;
            if ((input.banco != null) && (input.banco.idBanco > 0))
                bd.banco.idBanco.value = input.banco.idBanco;
            else
                bd.banco.idBanco.isNull = true;
            bd.numeroConta.value = input.numeroConta;
            bd.tipoConta.value = input.tipoConta;
            if (input.idUsuario > 0)
                bd.idUsuario.value = input.idUsuario;
            else
                bd.idUsuario.isNull = true;
            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else
                bd.planoContas.idPlanoContas.isNull = true;
            bd.saldoAtual.value = input.saldoAtual;
            bd.recebimentoVinculado.value = input.recebimentoVinculado;
            bd.pagamentoVinculado.value = input.pagamentoVinculado;
            if (input.numeroChequeInicial > 0)
                bd.numeroChequeInicial.value = input.numeroChequeInicial;
            else
                bd.numeroChequeInicial.isNull = true;
            if (input.numeroChequeFinal > 0)
                bd.numeroChequeFinal.value = input.numeroChequeFinal;
            else
                bd.numeroChequeFinal.isNull = true;

            if ((input.formaPagamento != null) && (input.formaPagamento.idFormaPagamento > 0))
                bd.formaPagamento.idFormaPagamento.value = input.formaPagamento.idFormaPagamento;
            else
                bd.formaPagamento.idFormaPagamento.isNull = true;

            bd.codigoExportacao.isNull = true;
            if (!String.IsNullOrEmpty(input.codigoExportacao))
                bd.codigoExportacao.value = input.codigoExportacao;
            else { }

            bd.agencia.value = input.agencia;
            bd.agenciaDigito.value = input.agenciaDigito;
            bd.numeroContaDigito.value = input.numeroContaDigito;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContaPagamento bd = new Tables.ContaPagamento();

            bd.idContaPagamento.value = ((Data.ContaPagamento)parametros["Key"]).idContaPagamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContaPagamento)bd).idContaPagamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContaPagamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContaPagamento)input).idContaPagamento = ((Tables.ContaPagamento)bd).idContaPagamento.value;
                    ((Data.ContaPagamento)input).idEmpresa = ((Tables.ContaPagamento)bd).idEmpresa.value;
                    ((Data.ContaPagamento)input).descricao = ((Tables.ContaPagamento)bd).descricao.value;
                    ((Data.ContaPagamento)input).codigoExportacao = ((Tables.ContaPagamento)bd).codigoExportacao.value;
                    ((Data.ContaPagamento)input).banco = (Data.Banco)(new WS.CRUD.Banco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Banco(),
                        ((Tables.ContaPagamento)bd).banco,
                        level + 1
                    );
                    ((Data.ContaPagamento)input).numeroConta = ((Tables.ContaPagamento)bd).numeroConta.value;
                    ((Data.ContaPagamento)input).tipoConta = ((Tables.ContaPagamento)bd).tipoConta.value;
                    ((Data.ContaPagamento)input).idUsuario = ((Tables.ContaPagamento)bd).idUsuario.value;
                    ((Data.ContaPagamento)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.ContaPagamento)bd).planoContas,
                        level + 1
                    );
                    ((Data.ContaPagamento)input).saldoAtual = ((Tables.ContaPagamento)bd).saldoAtual.value;
                    ((Data.ContaPagamento)input).recebimentoVinculado = ((Tables.ContaPagamento)bd).recebimentoVinculado.value;
                    ((Data.ContaPagamento)input).pagamentoVinculado = ((Tables.ContaPagamento)bd).pagamentoVinculado.value;
                    ((Data.ContaPagamento)input).numeroChequeInicial = ((Tables.ContaPagamento)bd).numeroChequeInicial.value;
                    ((Data.ContaPagamento)input).numeroChequeFinal = ((Tables.ContaPagamento)bd).numeroChequeFinal.value;
                    ((Data.ContaPagamento)input).formaPagamento = (Data.FormaPagamento)(new WS.CRUD.FormaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.FormaPagamento(),
                        ((Tables.ContaPagamento)bd).formaPagamento,
                        level + 1
                    );

                    ((Data.ContaPagamento)input).agencia = ((Tables.ContaPagamento)bd).agencia.value;
                    ((Data.ContaPagamento)input).agenciaDigito = ((Tables.ContaPagamento)bd).agenciaDigito.value;
                    ((Data.ContaPagamento)input).numeroContaDigito = ((Tables.ContaPagamento)bd).numeroContaDigito.value;

                }
                else { }
            }
            else { }

            if (level < 1)
            {
                //Preencher ContaPagamentoSaldos
                if (((Tables.ContaPagamento)bd).contaPagamentoSaldos != null)
                {
                    System.Collections.Generic.List<Data.ContaPagamentoSaldo> _list = new System.Collections.Generic.List<Data.ContaPagamentoSaldo>();

                    foreach (Tables.ContaPagamentoSaldo _item in ((Tables.ContaPagamento)bd).contaPagamentoSaldos)
                    {
                        _list.Add
                        (
                            (Data.ContaPagamentoSaldo)
                            (new WS.CRUD.ContaPagamentoSaldo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ContaPagamentoSaldo(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.ContaPagamento)input).contaPagamentoSaldos = _list.ToArray();
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
            Data.ContaPagamento result = (Data.ContaPagamento)parametros["Key"];

            try
            {
                result = (Data.ContaPagamento)this.preencher
                (
                    new Data.ContaPagamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContaPagamento),
                        new Object[]
                        {
                            result.idContaPagamento
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

            Data.ContaPagamento _input = (Data.ContaPagamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("contaPagamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idContaPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contaPagamento.idContaPagamento = @idContaPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.idContaPagamento));
                    if (!sqlOrderBy.Contains("contaPagamento.idContaPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.idContaPagamento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contaPagamento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("contaPagamento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoExportacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contaPagamento.codigoExportacao like @codigoExportacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoExportacao", _input.codigoExportacao + "%"));
                    if (!sqlOrderBy.Contains("contaPagamento.codigoExportacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contaPagamento.codigoExportacao");
                    else { }
                }
                else { }

                if(_input.formaPagamento != null)
                {
                    if(!String.IsNullOrEmpty(_input.formaPagamento.habilitarValorDigitadoFechamento))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   formaPagamento.habilitarValorDigitadoFechamento = @habilitarValorDigitadoFechamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldBoolean("habilitarValorDigitadoFechamento", _input.formaPagamento.habilitarValorDigitadoFechamento == "1"));
                        if (!sqlOrderBy.Contains("formaPagamento.habilitarValorDigitadoFechamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "formaPagamento.habilitarValorDigitadoFechamento");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   contaPagamento.*\n" +
                    "from \n" + 
                    "   contaPagamento\n" +
                    " left join formaPagamento ON formaPagamento.idFormaPagamento = contaPagamento.idFormaPagamento \n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.ContaPagamento input = (Data.ContaPagamento)parametros["Key"];
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
                    typeof(Tables.ContaPagamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContaPagamento _data in
                    (System.Collections.Generic.List<Tables.ContaPagamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContaPagamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.ContaPagamento();
                        ((Data.ContaPagamento)_base).idContaPagamento = _data.idContaPagamento.value;
                        ((Data.ContaPagamento)_base).descricao = _data.descricao.value;
                        ((Data.ContaPagamento)_base).tipoConta = _data.tipoConta.value;
                        ((Data.ContaPagamento)_base).idEmpresa = _data.idEmpresa.value;
                        ((Data.ContaPagamento)_base).banco = new Data.Banco();
                        ((Data.ContaPagamento)_base).banco.idBanco = _data.banco.idBanco.value;
                        ((Data.ContaPagamento)_base).numeroConta = _data.numeroConta.value;
                        ((Data.ContaPagamento)_base).saldoAtual = _data.saldoAtual.value;
                        ((Data.ContaPagamento)_base).recebimentoVinculado = _data.recebimentoVinculado.value;
                        ((Data.ContaPagamento)_base).pagamentoVinculado = _data.pagamentoVinculado.value;
                        ((Data.ContaPagamento)_base).numeroChequeInicial = _data.numeroChequeInicial.value;
                        ((Data.ContaPagamento)_base).numeroChequeFinal = _data.numeroChequeFinal.value;
                        ((Data.ContaPagamento)_base).codigoExportacao = _data.codigoExportacao.value;
                        ((Data.ContaPagamento)_base).formaPagamento = new Data.FormaPagamento();
                        ((Data.ContaPagamento)_base).formaPagamento.idFormaPagamento = _data.formaPagamento.idFormaPagamento.value;
                        ((Data.ContaPagamento)_base).formaPagamento.descricao = _data.formaPagamento.descricao.value;
                        ((Data.ContaPagamento)_base).formaPagamento.habilitarValorDigitadoFechamento = _data.formaPagamento.habilitarValorDigitadoFechamento.value ? "1" : "0";

                        ((Data.ContaPagamento)_base).agencia = _data.agencia.value;
                        ((Data.ContaPagamento)_base).agenciaDigito = _data.agenciaDigito.value;
                        ((Data.ContaPagamento)_base).numeroContaDigito = _data.numeroContaDigito.value;

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContaPagamento(), _data, level);


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
