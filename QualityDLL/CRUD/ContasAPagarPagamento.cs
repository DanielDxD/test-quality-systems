using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace WS.CRUD
{
    public class ContasAPagarPagamento : WS.CRUD.Base
    {
        public ContasAPagarPagamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagarPagamento input = (Data.ContasAPagarPagamento)parametros["Key"];
            Tables.ContasAPagarPagamento bd = new Tables.ContasAPagarPagamento();

            bd.idContasAPagarPagamento.isNull = true;
            bd.idContasAPagar.value = input.idContasAPagar;
            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else
                bd.contaPagamento.idContaPagamento.isNull = true;
            bd.dataMovimento.value = input.dataMovimento;
            bd.valorPrincipal.value = input.valorPrincipal;
            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;
            if (input.idDocumentoPagamento > 0)
                bd.idDocumentoPagamento.value = input.idDocumentoPagamento;
            else
                bd.idDocumentoPagamento.isNull = true;

            if (input.idFuncionario > 0)
                bd.idFuncionario.value = input.idFuncionario;
            else
                bd.idFuncionario.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAPagarPagamento)parametros["Key"]).idContasAPagarPagamento = (int)bd.idContasAPagarPagamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagarPagamento input = (Data.ContasAPagarPagamento)parametros["Key"];
            Tables.ContasAPagarPagamento bd = (Tables.ContasAPagarPagamento)this.m_EntityManager.find
            (
                typeof(Tables.ContasAPagarPagamento),
                new Object[]
                {
                    input.idContasAPagarPagamento
                }
            );

            bd.idContasAPagar.value = input.idContasAPagar;
            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else
                bd.contaPagamento.idContaPagamento.isNull = true;
            bd.dataMovimento.value = input.dataMovimento;

            bd.valorPrincipal.value = input.valorPrincipal;
            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;
            if (input.idDocumentoPagamento > 0)
                bd.idDocumentoPagamento.value = input.idDocumentoPagamento;
            else
                bd.idDocumentoPagamento.isNull = true;

            if (input.idFuncionario > 0)
                bd.idFuncionario.value = input.idFuncionario;
            else
                bd.idFuncionario.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAPagarPagamento bd = new Tables.ContasAPagarPagamento();

            bd.idContasAPagarPagamento.value = ((Data.ContasAPagarPagamento)parametros["Key"]).idContasAPagarPagamento;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAPagarPagamento)bd).idContasAPagarPagamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAPagarPagamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAPagarPagamento)input).idContasAPagarPagamento = ((Tables.ContasAPagarPagamento)bd).idContasAPagarPagamento.value;
                    ((Data.ContasAPagarPagamento)input).idContasAPagar = ((Tables.ContasAPagarPagamento)bd).idContasAPagar.value;
                    ((Data.ContasAPagarPagamento)input).dataMovimento = ((Tables.ContasAPagarPagamento)bd).dataMovimento.value;
                    ((Data.ContasAPagarPagamento)input).valorPrincipal = ((Tables.ContasAPagarPagamento)bd).valorPrincipal.value;
                    ((Data.ContasAPagarPagamento)input).valorMulta = ((Tables.ContasAPagarPagamento)bd).valorMulta.value;
                    ((Data.ContasAPagarPagamento)input).valorJuros = ((Tables.ContasAPagarPagamento)bd).valorJuros.value;
                    ((Data.ContasAPagarPagamento)input).valorDesconto = ((Tables.ContasAPagarPagamento)bd).valorDesconto.value;
                    ((Data.ContasAPagarPagamento)input).valorCM = ((Tables.ContasAPagarPagamento)bd).valorCM.value;

                    ((Data.ContasAPagarPagamento)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.ContasAPagarPagamento)bd).contaPagamento,
                        level + 1
                    );
                    ((Data.ContasAPagarPagamento)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.ContasAPagarPagamento)bd).tipoMovimentoContabil,
                        level + 1
                    );
                    ((Data.ContasAPagarPagamento)input).valorINSSRetido = ((Tables.ContasAPagarPagamento)bd).valorINSSRetido.value;
                    ((Data.ContasAPagarPagamento)input).valorISSRetido = ((Tables.ContasAPagarPagamento)bd).valorISSRetido.value;
                    ((Data.ContasAPagarPagamento)input).valorIRRetido = ((Tables.ContasAPagarPagamento)bd).valorIRRetido.value;
                    ((Data.ContasAPagarPagamento)input).valorPISRetido = ((Tables.ContasAPagarPagamento)bd).valorPISRetido.value;
                    ((Data.ContasAPagarPagamento)input).valorCOFINSRetido = ((Tables.ContasAPagarPagamento)bd).valorCOFINSRetido.value;
                    ((Data.ContasAPagarPagamento)input).valorCSLLRetido = ((Tables.ContasAPagarPagamento)bd).valorCSLLRetido.value;
                    if (!((Tables.ContasAPagarPagamento)bd).idDocumentoPagamento.isNull)
                    {
                        ((Data.ContasAPagarPagamento)input).idDocumentoPagamento = ((Tables.ContasAPagarPagamento)bd).idDocumentoPagamento.value;
                        try
                        {
                            List<NameValue> _params = new List<NameValue>();
                            _params.Add(new NameValue { name = "Level", value = level });
                            ((Data.ContasAPagarPagamento)input).documentoPagamento = Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, new Data.DocumentoPagamento { idDocumentoPagamento = ((Tables.ContasAPagarPagamento)bd).idDocumentoPagamento.value }, 1, _params).Cast<Data.DocumentoPagamento>().ToArray()[0];
                        }
                        catch { }
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
            Data.ContasAPagarPagamento result = (Data.ContasAPagarPagamento)parametros["Key"];

            try
            {
                result = (Data.ContasAPagarPagamento)this.preencher
                (
                    new Data.ContasAPagarPagamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAPagarPagamento),
                        new Object[]
                        {
                            result.idContasAPagarPagamento
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

            Data.ContasAPagarPagamento _input = (Data.ContasAPagarPagamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAPagarPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarPagamento.idContasAPagarPagamento = @idContasAPagarPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAPagarPagamento", _input.idContasAPagarPagamento));
                    if (!sqlOrderBy.Contains("contasAPagarPagamento.idContasAPagarPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarPagamento.idContasAPagarPagamento");
                    else { }
                }
                else { }

                if (_input.idDocumentoPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarPagamento.idDocumentoPagamento = @idDocumentoPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoPagamento", _input.idDocumentoPagamento));
                    if (!sqlOrderBy.Contains("contasAPagarPagamento.idDocumentoPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarPagamento.idDocumentoPagamento");
                    else { }
                }
                else { }

                if (_input.contaPagamento != null)
                {
                    if (_input.contaPagamento.idContaPagamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarPagamento.idContaPagamento = @idContaPagamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.contaPagamento.idContaPagamento));
                        if (!sqlOrderBy.Contains("contasAPagarPagamento.idContaPagamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarPagamento.idContaPagamento");
                        else { }
                    }
                    else { }
                }
                else { }               

                if (_input.idContasAPagar > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarPagamento.idContasAPagar = @idContasAPagar");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAPagar", _input.idContasAPagar));
                    if (!sqlOrderBy.Contains("contasAPagarPagamento.idContasAPagar"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarPagamento.idContasAPagar");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contasAPagarPagamento.* ") +
                    "from " +
                    "   contasAPagarPagamento " +
                    "inner join contasAPagar contasAPagar ON contasAPagar.idContasAPagar = contasAPagarPagamento.idContasAPagar\n" +
                    "       left join empresaRelacionamento empresaRelacionamento " +
                    "           on	empresaRelacionamento.idEmpresaRelacionamento = contasAPagar.idEmpresaRelacionamento " +
                    "       left join pessoa pessoa " +
                    "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                    "       left join contaPagamento contaPagamento " +
                    "           on	contaPagamento.idContaPagamento = contasAPagarPagamento.idContaPagamento " +
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
            Data.ContasAPagarPagamento input = (Data.ContasAPagarPagamento)parametros["Key"];
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
                    typeof(Tables.ContasAPagarPagamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAPagarPagamento _data in
                    (System.Collections.Generic.List<Tables.ContasAPagarPagamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAPagarPagamento),
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
                    _base = (Data.Base)this.preencher(new Data.ContasAPagarPagamento(), _data, level);

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
