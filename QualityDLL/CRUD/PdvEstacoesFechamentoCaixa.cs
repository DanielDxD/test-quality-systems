using System;

namespace WS.CRUD
{
    public class PdvEstacoesFechamentoCaixa : WS.CRUD.Base
    {
        public PdvEstacoesFechamentoCaixa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesFechamentoCaixa input = (Data.PdvEstacoesFechamentoCaixa)parametros["Key"];
            Tables.PdvEstacoesFechamentoCaixa bd = new Tables.PdvEstacoesFechamentoCaixa();

            bd.idPdvEstacaoFechamentoCaixa.isNull = true;
            if ((input.pdvEstacao != null) && (input.pdvEstacao.idPdvEstacao > 0))
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if ((input.funcionario != null) && (input.funcionario.idEmpresaRelacionamento > 0))
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            if ((input.pdvEstacaoAberturaCaixa != null) && (input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa > 0))
                bd.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa.value = input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa;
            else { }

            bd.valorTotal.value = input.valorTotal;
            bd.dataFechamento.value = input.dataFechamento;

            this.m_EntityManager.persist(bd);

            ((Data.PdvEstacoesFechamentoCaixa)parametros["Key"]).idPdvEstacaoFechamentoCaixa = (int)bd.idPdvEstacaoFechamentoCaixa.value;

            //Processa PDVEstacoesFechamentoDetalhe
            if (input.pdvEstacoesFechamentoCaixaDetalhe != null)
            {
                WS.CRUD.PdvEstacoesFechamentoCaixaDetalhe pdvEstacoesFechamentoCaixaDetalheCRUD = new WS.CRUD.PdvEstacoesFechamentoCaixaDetalhe(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvEstacoesFechamentoCaixaDetalhe.Length; i++)
                {
                    input.pdvEstacoesFechamentoCaixaDetalhe[i].pdvEstacaoFechamentoCaixa = new Data.PdvEstacoesFechamentoCaixa
                    {
                        idPdvEstacaoFechamentoCaixa = bd.idPdvEstacaoFechamentoCaixa.value
                    };
                    _parameters.Add("Key", input.pdvEstacoesFechamentoCaixaDetalhe[i]);
                    pdvEstacoesFechamentoCaixaDetalheCRUD.atualizar(_parameters);
                    if (input.pdvEstacoesFechamentoCaixaDetalhe[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pdvEstacoesFechamentoCaixaDetalhe[i] = (Data.PdvEstacoesFechamentoCaixaDetalhe)pdvEstacoesFechamentoCaixaDetalheCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                pdvEstacoesFechamentoCaixaDetalheCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesFechamentoCaixa input = (Data.PdvEstacoesFechamentoCaixa)parametros["Key"];
            Tables.PdvEstacoesFechamentoCaixa bd = (Tables.PdvEstacoesFechamentoCaixa)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacoesFechamentoCaixa),
                new Object[]
                {
                    input.idPdvEstacaoFechamentoCaixa
                }
            );

            if ((input.pdvEstacao != null) && (input.pdvEstacao.idPdvEstacao > 0))
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if ((input.funcionario != null) && (input.funcionario.idEmpresaRelacionamento > 0))
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            if ((input.pdvEstacaoAberturaCaixa != null) && (input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa > 0))
                bd.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa.value = input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa;
            else { }

            bd.valorTotal.value = input.valorTotal;
            bd.dataFechamento.value = input.dataFechamento;

            this.m_EntityManager.merge(bd);

            //Processa PDVEstacoesFechamentoDetalhe
            if (input.pdvEstacoesFechamentoCaixaDetalhe != null)
            {
                WS.CRUD.PdvEstacoesFechamentoCaixaDetalhe pdvEstacoesFechamentoCaixaDetalheCRUD = new WS.CRUD.PdvEstacoesFechamentoCaixaDetalhe(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvEstacoesFechamentoCaixaDetalhe.Length; i++)
                {
                    input.pdvEstacoesFechamentoCaixaDetalhe[i].pdvEstacaoFechamentoCaixa = new Data.PdvEstacoesFechamentoCaixa
                    {
                        idPdvEstacaoFechamentoCaixa = bd.idPdvEstacaoFechamentoCaixa.value
                    };
                    _parameters.Add("Key", input.pdvEstacoesFechamentoCaixaDetalhe[i]);
                    if (input.pdvEstacoesFechamentoCaixaDetalhe[i].operacao == ENum.eOperacao.NONE)
                        input.pdvEstacoesFechamentoCaixaDetalhe[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pdvEstacoesFechamentoCaixaDetalheCRUD.atualizar(_parameters);
                    if (input.pdvEstacoesFechamentoCaixaDetalhe[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pdvEstacoesFechamentoCaixaDetalhe[i] = (Data.PdvEstacoesFechamentoCaixaDetalhe)pdvEstacoesFechamentoCaixaDetalheCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                pdvEstacoesFechamentoCaixaDetalheCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacoesFechamentoCaixa bd = new Tables.PdvEstacoesFechamentoCaixa();

            bd.idPdvEstacaoFechamentoCaixa.value = ((Data.PdvEstacoesFechamentoCaixa)parametros["Key"]).idPdvEstacaoFechamentoCaixa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacoesFechamentoCaixa)bd).idPdvEstacaoFechamentoCaixa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacoesFechamentoCaixa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacoesFechamentoCaixa)input).idPdvEstacaoFechamentoCaixa = ((Tables.PdvEstacoesFechamentoCaixa)bd).idPdvEstacaoFechamentoCaixa.value;
                    ((Data.PdvEstacoesFechamentoCaixa)input).valorTotal = ((Tables.PdvEstacoesFechamentoCaixa)bd).valorTotal.value;
                    ((Data.PdvEstacoesFechamentoCaixa)input).dataFechamento = ((Tables.PdvEstacoesFechamentoCaixa)bd).dataFechamento.value;

                    if (level < 1)
                    {

                        ((Data.PdvEstacoesFechamentoCaixa)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.Funcionario(),
                            ((Tables.PdvEstacoesFechamentoCaixa)bd).funcionario,
                            level + 1
                        );

                        ((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacao(),
                            ((Tables.PdvEstacoesFechamentoCaixa)bd).pdvEstacao,
                            level + 1
                        );

                        ((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacaoAberturaCaixa = (Data.PdvEstacoesAberturaCaixa)(new WS.CRUD.PdvEstacoesAberturaCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacoesAberturaCaixa(),
                            ((Tables.PdvEstacoesFechamentoCaixa)bd).pdvEstacaoAberturaCaixa,
                            level + 1
                        );


                        if (((Tables.PdvEstacoesFechamentoCaixa)bd).pdvEstacoesFechamentoCaixaDetalhe != null)
                        {
                            System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixaDetalhe> _list = new System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixaDetalhe>();

                            foreach (Tables.PdvEstacoesFechamentoCaixaDetalhe _item in ((Tables.PdvEstacoesFechamentoCaixa)bd).pdvEstacoesFechamentoCaixaDetalhe)
                            {
                                _list.Add
                                (
                                    (Data.PdvEstacoesFechamentoCaixaDetalhe)
                                    (new WS.CRUD.PdvEstacoesFechamentoCaixaDetalhe(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvEstacoesFechamentoCaixaDetalhe(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacoesFechamentoCaixaDetalhe = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacoesFechamentoCaixaDetalhe != null)
                            {
                                System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixaDetalhe> _list = new System.Collections.Generic.List<Data.PdvEstacoesFechamentoCaixaDetalhe>();

                                foreach (Data.PdvEstacoesFechamentoCaixaDetalhe _item in ((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacoesFechamentoCaixaDetalhe)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacoesFechamentoCaixaDetalhe = _list.ToArray();
                                else
                                    ((Data.PdvEstacoesFechamentoCaixa)input).pdvEstacoesFechamentoCaixaDetalhe = null;

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
            Data.PdvEstacoesFechamentoCaixa result = (Data.PdvEstacoesFechamentoCaixa)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.idPdvEstacaoFechamentoCaixa > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixa", result.idPdvEstacaoFechamentoCaixa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa = @idPdvEstacaoFechamentoCaixa";
                }
                else { }

                if ((result.pdvEstacao != null && result.pdvEstacao.idPdvEstacao > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", result.pdvEstacao.idPdvEstacao));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacao = @idPdvEstacao";
                }
                else { }

                if ((result.funcionario != null && result.funcionario.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", result.funcionario.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idFuncionario = @idFuncionario";
                }
                else { }

                if (String.IsNullOrEmpty(whereKeys))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixa", result.idPdvEstacaoFechamentoCaixa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacoesFechamentoCaixa = @idPdvEstacaoFechamentoCaixa";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" + 
                    "    pdvEstacoesFechamentoCaixa pdvEstacoesFechamentoCaixa\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    )
                );

                foreach
                (
                    Tables.PdvEstacoesFechamentoCaixa _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesFechamentoCaixa>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesFechamentoCaixa),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvEstacoesFechamentoCaixa)this.preencher
                    (
                        new Data.PdvEstacoesFechamentoCaixa(),
                        _data,
                        0
                    );
                }
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

            Data.PdvEstacoesFechamentoCaixa _input = (Data.PdvEstacoesFechamentoCaixa)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if ((_input.idPdvEstacaoFechamentoCaixa > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixa", _input.idPdvEstacaoFechamentoCaixa));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa = @idPdvEstacaoFechamentoCaixa";
                    if (!sqlOrderBy.Contains("pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa");
                    else { }
                }
                else { }

                if ((_input.pdvEstacao != null && _input.pdvEstacao.idPdvEstacao > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacao = @idPdvEstacao";
                    if (!sqlOrderBy.Contains("pdvEstacoesFechamentoCaixa.idPdvEstacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesFechamentoCaixa.idPdvEstacao");
                    else { }
                }
                else { }

                if ((_input.funcionario != null && _input.funcionario.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.funcionario.idEmpresaRelacionamento));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixa.idFuncionario = @idFuncionario";
                    if (!sqlOrderBy.Contains("pdvEstacoesFechamentoCaixa.idFuncionario"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesFechamentoCaixa.idFuncionario");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "* ") +
                    "from " +
                    "   pdvEstacoesFechamentoCaixa pdvEstacoesFechamentoCaixa " +
                    "   inner join pdvEstacoes pdvEstacoes\n" +
                    "       on pdvEstacoes.idPdvEstacao = pdvEstacoesFechamentoCaixa.idPdvEstacao\n" +
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
            Data.PdvEstacoesFechamentoCaixa input = (Data.PdvEstacoesFechamentoCaixa)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            Report.Base report = (Report.Base)parametros["Report"];

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.PdvEstacoesFechamentoCaixa),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.PdvEstacoesFechamentoCaixa _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesFechamentoCaixa>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesFechamentoCaixa),
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
                    _base = (Data.Base)this.preencher(new Data.PdvEstacoesFechamentoCaixa(), _data, level);

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
