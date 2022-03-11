using System;
using System.Linq;

namespace WS.CRUD
{
    public class Contrato : WS.CRUD.Base
    {
        public Contrato(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Contrato input = (Data.Contrato)parametros["Key"];
            Tables.Contrato bd = new Tables.Contrato();

            bd.idContrato.isNull = true;
            bd.contratoTipo.idContratoTipo.value = input.contratoTipo.idContratoTipo;
            bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            bd.valor.value = input.valor;
            bd.valorDesconto.value = input.valorDesconto;
            bd.recorrencia.value = input.recorrencia;
            bd.dataInicial.value = input.dataInicial;
            bd.gerarCobranca.value = input.gerarCobranca == "s";

            if (input.dataFinal.Ticks > 0)
                bd.dataFinal.value = input.dataFinal;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;

            bd.observacaoCancelamento.value = input.observacaoCancelamento;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.Contrato)parametros["Key"]).idContrato = (int)bd.idContrato.value;
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Contrato input = (Data.Contrato)parametros["Key"];
            Tables.Contrato bd = (Tables.Contrato)this.m_EntityManager.find
            (
                typeof(Tables.Contrato),
                new Object[]
                {
                    input.idContrato
                }
            );

            bd.contratoTipo.idContratoTipo.value = input.contratoTipo.idContratoTipo;
            bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            bd.valor.value = input.valor;
            bd.valorDesconto.value = input.valorDesconto;
            bd.recorrencia.value = input.recorrencia;
            bd.dataInicial.value = input.dataInicial;
            bd.gerarCobranca.value = input.gerarCobranca == "s";

            if (input.dataFinal.Ticks > 0)
                bd.dataFinal.value = input.dataFinal;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;

            bd.observacaoCancelamento.value = input.observacaoCancelamento;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Contrato bd = new Tables.Contrato();

            bd.idContrato.value = ((Data.Contrato)parametros["Key"]).idContrato;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Contrato)bd).idContrato.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Contrato)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Contrato)input).idContrato = ((Tables.Contrato)bd).idContrato.value;
                    ((Data.Contrato)input).valor = ((Tables.Contrato)bd).valor.value;
                    ((Data.Contrato)input).valorDesconto = ((Tables.Contrato)bd).valorDesconto.value;
                    ((Data.Contrato)input).dataCancelamento = ((Tables.Contrato)bd).dataCancelamento.value;
                    ((Data.Contrato)input).recorrencia = ((Tables.Contrato)bd).recorrencia.value;
                    ((Data.Contrato)input).dataInicial = ((Tables.Contrato)bd).dataInicial.value;
                    ((Data.Contrato)input).dataFinal = ((Tables.Contrato)bd).dataFinal.value;
                    ((Data.Contrato)input).observacaoCancelamento = ((Tables.Contrato)bd).observacaoCancelamento.value;
                    ((Data.Contrato)input).observacao = ((Tables.Contrato)bd).observacao.value;
                    ((Data.Contrato)input).gerarCobranca = ((Tables.Contrato)bd).gerarCobranca.value ? "s" : "n";
                    ((Data.Contrato)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.Contrato)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.Contrato)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.Contrato)bd).funcionario,
                        level + 1
                    );
                    ((Data.Contrato)input).contratoTipo = (Data.ContratoTipo)(new WS.CRUD.ContratoTipo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContratoTipo(),
                        ((Tables.Contrato)bd).contratoTipo,
                        level + 1
                    );
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Contrato result = (Data.Contrato)parametros["Key"];

            try
            {
                result = (Data.Contrato)this.preencher
                (
                    new Data.Contrato(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Contrato),
                        new Object[]
                        {
                            result.idContrato
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

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }
            }
            else { }

            Data.Contrato _input = (Data.Contrato)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContrato > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Contrato.idContrato = @idContrato");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContrato", _input.idContrato));
                    if (!sqlOrderBy.Contains("Contrato.idContrato"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Contrato.idContrato");
                    else { }
                }
                else { }

                
                if (_input.dataInicial.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Contrato.dataInicial >= @dataInicial");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataInicial", _input.dataInicial));
                    if (!sqlOrderBy.Contains("Contrato.dataInicial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Contrato.dataInicial");
                    else { }
                }
                else { }

                if (_input.dataFinal.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Contrato.dataFinal <= @dataFinal");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataFinal", _input.dataFinal));
                    if (!sqlOrderBy.Contains("Contrato.dataFinal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Contrato.dataFinal");
                    else { }
                }
                else { }

                //Boolean gerarCobranca
                
                if (!String.IsNullOrEmpty(_input.gerarCobranca))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Contrato.gerarCobranca = @gerarCobranca");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("gerarCobranca", _input.gerarCobranca == "s"));
                    if (!sqlOrderBy.Contains("Contrato.gerarCobranca"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Contrato.gerarCobranca");
                    else { }
                }

                if (_input.contratoTipo != null)
                {
                    if (!String.IsNullOrEmpty(_input.contratoTipo.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contratoTipo.descricao LIKE @descricao");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.contratoTipo.descricao + "%"));
                        if (!sqlOrderBy.Contains("contratoTipo.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.descricao");
                        else { }
                    }

                    if (_input.contratoTipo.diaVencimento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contratoTipo.diaVencimento = @diaVencimento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("diaVencimento", _input.contratoTipo.diaVencimento));
                        if (!sqlOrderBy.Contains("contratoTipo.diaVencimento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.diaVencimento");
                        else { }
                    }

                    if (_input.contratoTipo.naturezaOperacao != null)
                    {
                        if (_input.contratoTipo.naturezaOperacao.idNaturezaOperacao > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contratoTipo.idNaturezaOperacao = @idNaturezaOperacao");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.contratoTipo.naturezaOperacao.idNaturezaOperacao));
                            if (!sqlOrderBy.Contains("contratoTipo.idNaturezaOperacao"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idNaturezaOperacao");
                            else { }
                        }
                    }
                    else { }

                    if (_input.contratoTipo.departamento != null)
                    {
                        if (_input.contratoTipo.departamento.idDepartamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contratoTipo.idDepartamento = @idDepartamento");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.contratoTipo.departamento.idDepartamento));
                            if (!sqlOrderBy.Contains("contratoTipo.idDepartamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idDepartamento");
                            else { }
                        }
                    }
                    else { }

                    if (_input.contratoTipo.categoriaTitulo != null)
                    {
                        if (_input.contratoTipo.categoriaTitulo.idCategoriaTitulo > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contratoTipo.idCategoriaTitulo = @idCategoriaTitulo");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCategoriaTitulo", _input.contratoTipo.categoriaTitulo.idCategoriaTitulo));
                            if (!sqlOrderBy.Contains("contratoTipo.idCategoriaTitulo"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idCategoriaTitulo");
                            else { }
                        }
                    }
                    else { }

                }
                else { }

                if (_input.empresaRelacionamento != null)
                {

                    if (_input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   Contrato.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.empresaRelacionamento.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("Contrato.idEmpresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Contrato.idEmpresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.empresaRelacionamento.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.tipoRelacionamentoEmpresa != null)
                    {
                        if (_input.empresaRelacionamento.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = @idTipoRelacionamentoEmpresa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoRelacionamentoEmpresa", _input.empresaRelacionamento.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa));
                            if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa");
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.pessoa != null)
                    {
                        if (_input.empresaRelacionamento.pessoa.idPessoa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.empresaRelacionamento.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if (!String.IsNullOrEmpty(_input.empresaRelacionamento.pessoa.nomeRazaoSocial))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.empresaRelacionamento.pessoa.nomeRazaoSocial + "%"));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }

                    }
                    else { }

                }
                else { }

                if (_input.contratoTipo != null)
                {
                    if (_input.contratoTipo.idContratoTipo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   Contrato.idContratoTipo = @idContratoTipo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContratoTipo", _input.contratoTipo.idContratoTipo));
                        if (!sqlOrderBy.Contains("Contrato.idContratoTipo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Contrato.idContratoTipo");
                        else { }
                    }
                    else { }
                }
                else { }

                if (String.IsNullOrEmpty(sqlOrderBy))
                    sqlOrderBy += "contrato.idContrato DESC";
                else { }



                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Contrato.* ") +
                    "from \n" +
                    "   Contrato\n" +
                    "inner join empresaRelacionamento empresaRelacionamento" +
                    "   on empresaRelacionamento.idEmpresaRelacionamento = contrato.idEmpresaRelacionamento\n" +
                    "inner join pessoa pessoa" +
                    "   on empresaRelacionamento.idPessoaRelacionamento = pessoa.idPessoa\n" +
                    "inner join tipoRelacionamentoEmpresa tipoRelacionamentoEmpresa" +
                    "   on empresaRelacionamento.idTipoRelacionamentoEmpresa = tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa\n" +
                    "inner join contratoTipo contratoTipo" +
                    "   on contratoTipo.idContratoTipo = contrato.idContratoTipo\n " +
                    "inner join contratoTipoRecorrencia contratoTipoRecorrencia" +
                    "   on contratoTipoRecorrencia.idContratoTipoRecorrencia = contratoTipo.idContratoTipoRecorrencia\n " +
                    "inner join funcionario funcionario" +
                    "   on funcionario.idFuncionario = contrato.idFuncionario\n " +
                    "inner join naturezaOperacao naturezaOperacao" +
                    "   on naturezaOperacao.idNaturezaOperacao = contratoTipo.idNaturezaOperacao\n " +
                    "inner join departamento departamento" +
                    "   on departamento.idDepartamento = contratoTipo.idDepartamento\n " +
                    "left join categoriaTitulo categoriaTitulo" +
                    "   on categoriaTitulo.idCategoriaTitulo = contratoTipo.idCategoriaTitulo\n " +

                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.Contrato input = (Data.Contrato)parametros["Key"];
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
                    typeof(Tables.Contrato),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Contrato _data in
                    (System.Collections.Generic.List<Tables.Contrato>)this.m_EntityManager.list
                    (
                        typeof(Tables.Contrato),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Contrato();
                        ((Data.Contrato)_base).idContrato = _data.idContrato.value;
                        ((Data.Contrato)_base).dataInicial = _data.dataInicial.value;
                        ((Data.Contrato)_base).dataFinal = _data.dataFinal.value;
                        ((Data.Contrato)_base).dataCancelamento = _data.dataCancelamento.value;
                        ((Data.Contrato)_base).observacao = _data.observacao.value;
                        ((Data.Contrato)_base).observacaoCancelamento = _data.observacaoCancelamento.value;
                        ((Data.Contrato)_base).valor = _data.valor.value;
                        ((Data.Contrato)_base).valorDesconto = _data.valorDesconto.value;
                        ((Data.Contrato)_base).gerarCobranca = _data.gerarCobranca.value ? "s" : "n";
                        ((Data.Contrato)_base).empresaRelacionamento = new Data.EmpresaRelacionamento
                        {
                            pessoa = new Data.Pessoa
                            {
                                idPessoa = _data.empresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                nomeRazaoSocial = _data.empresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                            }
                        };
                        ((Data.Contrato)_base).funcionario = new Data.Funcionario
                        {
                            pessoa = new Data.Pessoa
                            {
                                idPessoa = _data.funcionario.funcionarioEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                nomeRazaoSocial = _data.funcionario.funcionarioEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                            }
                        };
                        ((Data.Contrato)_base).contratoTipo = new Data.ContratoTipo
                        {
                            categoriaTitulo = new Data.CategoriaTitulo
                            {
                                idCategoriaTitulo = _data.contratoTipo.categoriaTitulo.idCategoriaTitulo.value,
                                descricao = _data.contratoTipo.categoriaTitulo.descricao.value
                            },
                            departamento = new Data.Departamento
                            {
                                idEmpresa = _data.contratoTipo.departamento.idEmpresa.value,
                                descricao = _data.contratoTipo.departamento.descricao.value,
                                idDepartamento = _data.contratoTipo.departamento.idDepartamento.value
                            },
                            naturezaOperacao = new Data.NaturezaOperacao
                            {
                                idNaturezaOperacao = _data.contratoTipo.naturezaOperacao.idNaturezaOperacao.value,
                                descricao = _data.contratoTipo.naturezaOperacao.descricao.value
                            },
                            descricao = _data.contratoTipo.descricao.value,
                            idContratoTipo = _data.contratoTipo.idContratoTipo.value,
                            contratoTipoRecorrencia = new Data.ContratoTipoRecorrencia
                            {
                                idContratoTipoRecorrencia = _data.contratoTipo.contratoTipoRecorrencia.idContratoTipoRecorrencia.value,
                                descricao = _data.contratoTipo.contratoTipoRecorrencia.descricao.value,
                            },
                            diaVencimento = _data.contratoTipo.diaVencimento.value,
                            valorBase = _data.contratoTipo.valorBase.value
                        };
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Contrato(), _data, level);


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
