using System;

namespace WS.CRUD
{
    public class ContasAPagarItem : WS.CRUD.Base
    {
        public ContasAPagarItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagarItem input = (Data.ContasAPagarItem)parametros["Key"];
            Tables.ContasAPagarItem bd = new Tables.ContasAPagarItem();

            bd.idContasAPagarItem.isNull = true;
            bd.idContasAPagar.value = input.idContasAPagar;
            if (input.idMovimentoManual > 0)
                bd.movimentoManual.idMovimentoManual.value = input.idMovimentoManual;
            else
                bd.movimentoManual.idMovimentoManual.isNull = true;
            if (input.idNotaFiscal > 0)
                bd.notaFiscal.idNotaFiscalE.value = input.idNotaFiscal;
            else
                bd.notaFiscal.idNotaFiscalE.isNull = true;
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.valorDesconto.value = input.valorDesconto;
            if (input.idDepartamento > 0)
                bd.idDepartamento.value = input.idDepartamento;
            else
                bd.idDepartamento.isNull = true;
            if (input.idNaturezaOperacao > 0)
                bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            else
                bd.idNaturezaOperacao.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAPagarItem)parametros["Key"]).idContasAPagarItem = (int)bd.idContasAPagarItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagarItem input = (Data.ContasAPagarItem)parametros["Key"];
            Tables.ContasAPagarItem bd = (Tables.ContasAPagarItem)this.m_EntityManager.find
            (
                typeof(Tables.ContasAPagarItem),
                new Object[]
                {
                    input.idContasAPagarItem
                }
            );

            bd.idContasAPagar.value = input.idContasAPagar;

            if (input.idMovimentoManual > 0)
                bd.movimentoManual.idMovimentoManual.value = input.idMovimentoManual;
            else
                bd.movimentoManual.idMovimentoManual.isNull = true;
            if (input.idNotaFiscal > 0)
                bd.notaFiscal.idNotaFiscalE.value = input.idNotaFiscal;
            else
                bd.notaFiscal.idNotaFiscalE.isNull = true;
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.valorDesconto.value = input.valorDesconto;
            if (input.idDepartamento > 0)
                bd.idDepartamento.value = input.idDepartamento;
            else
                bd.idDepartamento.isNull = true;
            if (input.idNaturezaOperacao > 0)
                bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            else
                bd.idNaturezaOperacao.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAPagarItem bd = new Tables.ContasAPagarItem();

            bd.idContasAPagarItem.value = ((Data.ContasAPagarItem)parametros["Key"]).idContasAPagarItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAPagarItem)bd).idContasAPagarItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAPagarItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAPagarItem)input).idContasAPagarItem = ((Tables.ContasAPagarItem)bd).idContasAPagarItem.value;
                    ((Data.ContasAPagarItem)input).idContasAPagar = ((Tables.ContasAPagarItem)bd).idContasAPagar.value;
                    ((Data.ContasAPagarItem)input).idMovimentoManual = ((Tables.ContasAPagarItem)bd).movimentoManual.idMovimentoManual.value;
                    if (((Tables.ContasAPagarItem)bd).notaFiscal != null)
                        ((Data.ContasAPagarItem)input).idNotaFiscal = ((Tables.ContasAPagarItem)bd).notaFiscal.idNotaFiscalE.value;
                    else { }
                    ((Data.ContasAPagarItem)input).descricao = ((Tables.ContasAPagarItem)bd).descricao.value;
                    ((Data.ContasAPagarItem)input).valor = ((Tables.ContasAPagarItem)bd).valor.value;
                    ((Data.ContasAPagarItem)input).valorDesconto = ((Tables.ContasAPagarItem)bd).valorDesconto.value;
                    if (!((Tables.ContasAPagarItem)bd).idDepartamento.isNull)
                        ((Data.ContasAPagarItem)input).idDepartamento = ((Tables.ContasAPagarItem)bd).idDepartamento.value;
                    else { }
                    if (!((Tables.ContasAPagarItem)bd).idNaturezaOperacao.isNull)
                        ((Data.ContasAPagarItem)input).idNaturezaOperacao = ((Tables.ContasAPagarItem)bd).idNaturezaOperacao.value;
                    else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContasAPagarItem result = (Data.ContasAPagarItem)parametros["Key"];

            try
            {
                result = (Data.ContasAPagarItem)this.preencher
                (
                    new Data.ContasAPagarItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAPagarItem),
                        new Object[]
                        {
                            result.idContasAPagarItem
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

            Data.ContasAPagarItem _input = (Data.ContasAPagarItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAPagarItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarItem.idContasAPagarItem = @idContasAPagarItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAPagarItem", _input.idContasAPagarItem));
                    if (!sqlOrderBy.Contains("contasAPagarItem.idContasAPagarItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarItem.idContasAPagarItem");
                    else { }
                }
                else { }

                if (_input.idNaturezaOperacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarItem.idNaturezaOperacao = @idNaturezaOperacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.idNaturezaOperacao));
                    if (!sqlOrderBy.Contains("contasAPagarItem.idNaturezaOperacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarItem.idNaturezaOperacao");
                    else { }
                }
                else { }

                if (_input.idDepartamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAPagarItem.idDepartamento = @idDepartamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.idDepartamento));
                    if (!sqlOrderBy.Contains("contasAPagarItem.idDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAPagarItem.idDepartamento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   contasAPagarItem.* " +
                    "from " +
                    (
                        "   contasAPagarItem contasAPagarItem " +
                        "       inner join contasAPagar contasAPagar " +
                        "           on	contasAPagar.idContasAPagar = contasAPagarItem.idContasAPagar " +
                        "       left join fornecedor fornecedor " +
                        "           on	fornecedor.idFornecedor = contasAPagar.idFornecedor " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = contasAPagar.idEmpresaRelacionamento" +
                        "       left join departamento departamento " +
                        "           on departamento.idDepartamento = contasAPagarItem.idDepartamento" +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                        "       left join naturezaOperacao " +
                        "           on naturezaOperacao.idNaturezaOperacao = contasAPagarItem.idNaturezaOperacao "
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
            Data.ContasAPagarItem input = (Data.ContasAPagarItem)parametros["Key"];
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
                    typeof(Tables.ContasAPagarItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAPagarItem _data in
                    (System.Collections.Generic.List<Tables.ContasAPagarItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAPagarItem),
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
                    _base = (Data.Base)this.preencher(new Data.ContasAPagarItem(), _data, level);

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
