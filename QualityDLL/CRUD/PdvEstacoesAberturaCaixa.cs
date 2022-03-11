using System;

namespace WS.CRUD
{
    public class PdvEstacoesAberturaCaixa : WS.CRUD.Base
    {
        public PdvEstacoesAberturaCaixa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesAberturaCaixa input = (Data.PdvEstacoesAberturaCaixa)parametros["Key"];
            Tables.PdvEstacoesAberturaCaixa bd = new Tables.PdvEstacoesAberturaCaixa();

            bd.idPdvEstacaoAberturaCaixa.isNull = true;
            if ((input.pdvEstacao != null) && (input.pdvEstacao.idPdvEstacao > 0))
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if ((input.funcionario != null) && (input.funcionario.idEmpresaRelacionamento > 0))
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            if ((input.pdvEstacaoFechamentoCaixa != null) && (input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa > 0))
                bd.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa.value = input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa;
            else { }

            bd.valorTotal.value = input.valorTotal;
            bd.dataAbertura.value = input.dataAbertura;

            this.m_EntityManager.persist(bd);

            ((Data.PdvEstacoesAberturaCaixa)parametros["Key"]).idPdvEstacaoAberturaCaixa = (int)bd.idPdvEstacaoAberturaCaixa.value;

            //Processa PDVEstacoesAberturaDetalhe
            if (input.pdvEstacoesAberturaCaixaDetalhe != null)
            {
                WS.CRUD.PdvEstacoesAberturaCaixaDetalhe pdvEstacoesAberturaCaixaDetalheCRUD = new WS.CRUD.PdvEstacoesAberturaCaixaDetalhe(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvEstacoesAberturaCaixaDetalhe.Length; i++)
                {
                    input.pdvEstacoesAberturaCaixaDetalhe[i].pdvEstacaoAberturaCaixa = new Data.PdvEstacoesAberturaCaixa
                    {
                        idPdvEstacaoAberturaCaixa = bd.idPdvEstacaoAberturaCaixa.value
                    };
                    _parameters.Add("Key", input.pdvEstacoesAberturaCaixaDetalhe[i]);
                    pdvEstacoesAberturaCaixaDetalheCRUD.atualizar(_parameters);
                    if (input.pdvEstacoesAberturaCaixaDetalhe[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pdvEstacoesAberturaCaixaDetalhe[i] = (Data.PdvEstacoesAberturaCaixaDetalhe)pdvEstacoesAberturaCaixaDetalheCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                pdvEstacoesAberturaCaixaDetalheCRUD = null;
            }
            else { }

            /* Atualizando abertura estação */
            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
            {
                WS.CRUD.PdvEstacao pdvEstacaoCRUD = new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();
                input.pdvEstacao.operacao = ENum.eOperacao.ALTERAR;
                input.pdvEstacao.aberturaCaixaAtual = input;
                _parameters.Add("Key", input.pdvEstacao);
                pdvEstacaoCRUD.atualizar(_parameters);
                _parameters.Clear();
                _parameters = null;
                pdvEstacaoCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesAberturaCaixa input = (Data.PdvEstacoesAberturaCaixa)parametros["Key"];
            Tables.PdvEstacoesAberturaCaixa bd = (Tables.PdvEstacoesAberturaCaixa)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacoesAberturaCaixa),
                new Object[]
                {
                    input.idPdvEstacaoAberturaCaixa
                }
            );

            if ((input.pdvEstacao != null) && (input.pdvEstacao.idPdvEstacao > 0))
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if ((input.funcionario != null) && (input.funcionario.idEmpresaRelacionamento > 0))
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            if ((input.pdvEstacaoFechamentoCaixa != null) && (input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa > 0))
                bd.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa.value = input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa;
            else { }

            bd.valorTotal.value = input.valorTotal;
            bd.dataAbertura.value = input.dataAbertura;

            this.m_EntityManager.merge(bd);

            //Processa PDVEstacoesAberturaDetalhe
            if (input.pdvEstacoesAberturaCaixaDetalhe != null)
            {
                WS.CRUD.PdvEstacoesAberturaCaixaDetalhe pdvEstacoesAberturaCaixaDetalheCRUD = new WS.CRUD.PdvEstacoesAberturaCaixaDetalhe(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvEstacoesAberturaCaixaDetalhe.Length; i++)
                {
                    input.pdvEstacoesAberturaCaixaDetalhe[i].pdvEstacaoAberturaCaixa = new Data.PdvEstacoesAberturaCaixa
                    {
                        idPdvEstacaoAberturaCaixa = bd.idPdvEstacaoAberturaCaixa.value
                    };
                    _parameters.Add("Key", input.pdvEstacoesAberturaCaixaDetalhe[i]);
                    if (input.pdvEstacoesAberturaCaixaDetalhe[i].operacao == ENum.eOperacao.NONE)
                        input.pdvEstacoesAberturaCaixaDetalhe[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pdvEstacoesAberturaCaixaDetalheCRUD.atualizar(_parameters);
                    if (input.pdvEstacoesAberturaCaixaDetalhe[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.pdvEstacoesAberturaCaixaDetalhe[i] = (Data.PdvEstacoesAberturaCaixaDetalhe)pdvEstacoesAberturaCaixaDetalheCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                pdvEstacoesAberturaCaixaDetalheCRUD = null;
            }
            else { }

            /* Atualizando abertura estação */
            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
            {
                WS.CRUD.PdvEstacao pdvEstacaoCRUD = new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();
                input.pdvEstacao.operacao = ENum.eOperacao.ALTERAR;
                input.pdvEstacao.aberturaCaixaAtual = input;
                _parameters.Add("Key", input.pdvEstacao);
                pdvEstacaoCRUD.atualizar(_parameters);
                _parameters.Clear();
                _parameters = null;
                pdvEstacaoCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacoesAberturaCaixa bd = new Tables.PdvEstacoesAberturaCaixa();

            bd.idPdvEstacaoAberturaCaixa.value = ((Data.PdvEstacoesAberturaCaixa)parametros["Key"]).idPdvEstacaoAberturaCaixa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacoesAberturaCaixa)bd).idPdvEstacaoAberturaCaixa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacoesAberturaCaixa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacoesAberturaCaixa)input).idPdvEstacaoAberturaCaixa = ((Tables.PdvEstacoesAberturaCaixa)bd).idPdvEstacaoAberturaCaixa.value;
                    ((Data.PdvEstacoesAberturaCaixa)input).valorTotal = ((Tables.PdvEstacoesAberturaCaixa)bd).valorTotal.value;
                    ((Data.PdvEstacoesAberturaCaixa)input).dataAbertura = ((Tables.PdvEstacoesAberturaCaixa)bd).dataAbertura.value;



                    ((Data.PdvEstacoesAberturaCaixa)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.PdvEstacoesAberturaCaixa)bd).funcionario,
                        level + 1
                    );

                    ((Data.PdvEstacoesAberturaCaixa)input).pdvEstacaoFechamentoCaixa = (Data.PdvEstacoesFechamentoCaixa)(new WS.CRUD.PdvEstacoesFechamentoCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacoesFechamentoCaixa(),
                        ((Tables.PdvEstacoesAberturaCaixa)bd).pdvEstacaoFechamentoCaixa,
                        level + 1
                    );


                    if (((Tables.PdvEstacoesAberturaCaixa)bd).pdvEstacoesAberturaCaixaDetalhe != null)
                    {
                        System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixaDetalhe> _list = new System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixaDetalhe>();

                        foreach (Tables.PdvEstacoesAberturaCaixaDetalhe _item in ((Tables.PdvEstacoesAberturaCaixa)bd).pdvEstacoesAberturaCaixaDetalhe)
                        {
                            _list.Add
                            (
                                (Data.PdvEstacoesAberturaCaixaDetalhe)
                                (new WS.CRUD.PdvEstacoesAberturaCaixaDetalhe(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PdvEstacoesAberturaCaixaDetalhe(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                         ((Data.PdvEstacoesAberturaCaixa)input).pdvEstacoesAberturaCaixaDetalhe = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.PdvEstacoesAberturaCaixa)input).pdvEstacoesAberturaCaixaDetalhe != null)
                        {
                            System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixaDetalhe> _list = new System.Collections.Generic.List<Data.PdvEstacoesAberturaCaixaDetalhe>();

                            foreach (Data.PdvEstacoesAberturaCaixaDetalhe _item in ((Data.PdvEstacoesAberturaCaixa)input).pdvEstacoesAberturaCaixaDetalhe)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.PdvEstacoesAberturaCaixa)input).pdvEstacoesAberturaCaixaDetalhe = _list.ToArray();
                            else
                                ((Data.PdvEstacoesAberturaCaixa)input).pdvEstacoesAberturaCaixaDetalhe = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }

                    if (level > 1)
                    {
                        ((Data.PdvEstacoesAberturaCaixa)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacao(),
                            ((Tables.PdvEstacoesAberturaCaixa)bd).pdvEstacao,
                            level + 1
                        );
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
            Data.PdvEstacoesAberturaCaixa result = (Data.PdvEstacoesAberturaCaixa)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.idPdvEstacaoAberturaCaixa > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixa", result.idPdvEstacaoAberturaCaixa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacaoAberturaCaixa = @idPdvEstacaoAberturaCaixa";
                }
                else { }

                if ((result.pdvEstacao != null && result.pdvEstacao.idPdvEstacao > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", result.pdvEstacao.idPdvEstacao));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacao = @idPdvEstacao";
                }
                else { }

                if ((result.funcionario != null && result.funcionario.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", result.funcionario.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idFuncionario = @idFuncionario";
                }
                else { }

                if (String.IsNullOrEmpty(whereKeys))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixa", result.idPdvEstacaoAberturaCaixa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacoesAberturaCaixa = @idPdvEstacaoAberturaCaixa";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" + 
                    "    pdvEstacoesAberturaCaixa pdvEstacoesAberturaCaixa\n" +
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
                    Tables.PdvEstacoesAberturaCaixa _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesAberturaCaixa>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesAberturaCaixa),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvEstacoesAberturaCaixa)this.preencher
                    (
                        new Data.PdvEstacoesAberturaCaixa(),
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

            Data.PdvEstacoesAberturaCaixa _input = (Data.PdvEstacoesAberturaCaixa)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if ((_input.idPdvEstacaoAberturaCaixa > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixa", _input.idPdvEstacaoAberturaCaixa));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacaoAberturaCaixa = @idPdvEstacaoAberturaCaixa";
                    if (!sqlOrderBy.Contains("pdvEstacoesAberturaCaixa.idPdvEstacaoAberturaCaixa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacaoAberturaCaixa");
                    else { }
                }
                else { }

                if ((_input.pdvEstacao != null && _input.pdvEstacao.idPdvEstacao > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacao = @idPdvEstacao";
                    if (!sqlOrderBy.Contains("pdvEstacoesAberturaCaixa.idPdvEstacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesAberturaCaixa.idPdvEstacao");
                    else { }
                }
                else { }

                if ((_input.funcionario != null && _input.funcionario.idEmpresaRelacionamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.funcionario.idEmpresaRelacionamento));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixa.idFuncionario = @idFuncionario";
                    if (!sqlOrderBy.Contains("pdvEstacoesAberturaCaixa.idFuncionario"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesAberturaCaixa.idFuncionario");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "* ") +
                    "from " +
                    "   pdvEstacoesAberturaCaixa pdvEstacoesAberturaCaixa " +
                    "   inner join pdvEstacoes pdvEstacoes\n" +
                    "       on pdvEstacoes.idPdvEstacao = pdvEstacoesAberturaCaixa.idPdvEstacao\n" +
                    "   left join pdvEstacoesFechamentoCaixa pdvEstacoesFechamentoCaixa\n" +
                    "       on pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa = pdvEstacoesAberturaCaixa.idPdvEstacaoFechamentoCaixa\n" +
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
            Data.PdvEstacoesAberturaCaixa input = (Data.PdvEstacoesAberturaCaixa)parametros["Key"];
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
                    typeof(Tables.PdvEstacoesAberturaCaixa),
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
                    Tables.PdvEstacoesAberturaCaixa _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesAberturaCaixa>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesAberturaCaixa),
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
                    _base = (Data.Base)this.preencher(new Data.PdvEstacoesAberturaCaixa(), _data, level);

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
