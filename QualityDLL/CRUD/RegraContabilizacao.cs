using System;

namespace WS.CRUD
{
    public class RegraContabilizacao : WS.CRUD.Base
    {
        public RegraContabilizacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacao input = (Data.RegraContabilizacao)parametros["Key"];
            Tables.RegraContabilizacao bd = new Tables.RegraContabilizacao();

            bd.idRegraContabilizacao.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipoAgrupamento.value = input.tipoAgrupamento;

            this.m_EntityManager.persist(bd);

            ((Data.RegraContabilizacao)parametros["Key"]).idRegraContabilizacao = (int)bd.idRegraContabilizacao.value;

            //Processa RegraContabilizacaoLancamento
            if (input.regraContabilizacaoLancamentos != null)
            {
                WS.CRUD.RegraContabilizacaoLancamento regraContabilizacaoLancamentoCRUD = new WS.CRUD.RegraContabilizacaoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.regraContabilizacaoLancamentos.Length; i++)
                {
                    input.regraContabilizacaoLancamentos[i].regraContabilizacaoPrimaria = new Data.RegraContabilizacao();
                    input.regraContabilizacaoLancamentos[i].regraContabilizacaoPrimaria.idRegraContabilizacao = bd.idRegraContabilizacao.value;
                    _parameters.Add("Key", input.regraContabilizacaoLancamentos[i]);
                    regraContabilizacaoLancamentoCRUD.atualizar(_parameters);
                    if (input.regraContabilizacaoLancamentos[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.regraContabilizacaoLancamentos[i] = (Data.RegraContabilizacaoLancamento)regraContabilizacaoLancamentoCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                regraContabilizacaoLancamentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacao input = (Data.RegraContabilizacao)parametros["Key"];
            Tables.RegraContabilizacao bd = (Tables.RegraContabilizacao)this.m_EntityManager.find
            (
                typeof(Tables.RegraContabilizacao),
                new Object[]
                {
                    input.idRegraContabilizacao
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipoAgrupamento.value = input.tipoAgrupamento;

            this.m_EntityManager.merge(bd);


            //Processa RegraContabilizacaoLancamento
            if (input.regraContabilizacaoLancamentos != null)
            {
                WS.CRUD.RegraContabilizacaoLancamento regraContabilizacaoLancamentoCRUD = new WS.CRUD.RegraContabilizacaoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.regraContabilizacaoLancamentos.Length; i++)
                {
                    input.regraContabilizacaoLancamentos[i].regraContabilizacaoPrimaria = new Data.RegraContabilizacao();
                    input.regraContabilizacaoLancamentos[i].regraContabilizacaoPrimaria.idRegraContabilizacao = bd.idRegraContabilizacao.value;
                    _parameters.Add("Key", input.regraContabilizacaoLancamentos[i]);
                    if (input.regraContabilizacaoLancamentos[i].operacao == ENum.eOperacao.NONE)
                        input.regraContabilizacaoLancamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    regraContabilizacaoLancamentoCRUD.atualizar(_parameters);
                    if (input.regraContabilizacaoLancamentos[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.regraContabilizacaoLancamentos[i] = (Data.RegraContabilizacaoLancamento)regraContabilizacaoLancamentoCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                regraContabilizacaoLancamentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RegraContabilizacao bd = new Tables.RegraContabilizacao();

            bd.idRegraContabilizacao.value = ((Data.RegraContabilizacao)parametros["Key"]).idRegraContabilizacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RegraContabilizacao)bd).idRegraContabilizacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RegraContabilizacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RegraContabilizacao)input).idRegraContabilizacao = ((Tables.RegraContabilizacao)bd).idRegraContabilizacao.value;
                    ((Data.RegraContabilizacao)input).descricao = ((Tables.RegraContabilizacao)bd).descricao.value;
                    ((Data.RegraContabilizacao)input).tipoAgrupamento = ((Tables.RegraContabilizacao)bd).tipoAgrupamento.value;
                }
                else { }
            }
            else { }

            if (level < 1)
            {
                //Preencher RegraContabilizacaoLancamentos
                if (((Tables.RegraContabilizacao)bd).regraContabilizacaoLancamentos != null)
                {
                    System.Collections.Generic.List<Data.RegraContabilizacaoLancamento> _list = new System.Collections.Generic.List<Data.RegraContabilizacaoLancamento>();

                    foreach (Tables.RegraContabilizacaoLancamento _item in ((Tables.RegraContabilizacao)bd).regraContabilizacaoLancamentos)
                    {
                        _list.Add
                        (
                            (Data.RegraContabilizacaoLancamento)
                            (new WS.CRUD.RegraContabilizacaoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.RegraContabilizacaoLancamento(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.RegraContabilizacao)input).regraContabilizacaoLancamentos = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.RegraContabilizacao)input).regraContabilizacaoLancamentos != null)
                    {
                        System.Collections.Generic.List<Data.RegraContabilizacaoLancamento> _list = new System.Collections.Generic.List<Data.RegraContabilizacaoLancamento>();

                        foreach (Data.RegraContabilizacaoLancamento _item in ((Data.RegraContabilizacao)input).regraContabilizacaoLancamentos)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.RegraContabilizacao)input).regraContabilizacaoLancamentos = _list.ToArray();
                        else
                            ((Data.RegraContabilizacao)input).regraContabilizacaoLancamentos = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacao result = (Data.RegraContabilizacao)parametros["Key"];

            try
            {
                result = (Data.RegraContabilizacao)this.preencher
                (
                    new Data.RegraContabilizacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RegraContabilizacao),
                        new Object[]
                        {
                            result.idRegraContabilizacao
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacao input = (Data.RegraContabilizacao)parametros["Key"];
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
                    typeof(Tables.RegraContabilizacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RegraContabilizacao _data in
                    (System.Collections.Generic.List<Tables.RegraContabilizacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.RegraContabilizacao),
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
                    _base = (Data.Base)this.preencher(new Data.RegraContabilizacao(), _data, level);

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
