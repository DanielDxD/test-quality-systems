using System;

namespace WS.CRUD
{
    public class Atendimento : WS.CRUD.Base
    {
        public Atendimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Atendimento input = (Data.Atendimento)parametros["Key"];
            Tables.Atendimento bd = new Tables.Atendimento();

            bd.idAtendimento.isNull = true;
            bd.dataAtendimento.value = input.dataAtendimento;
            if (input.pontoAtendimento != null)
                bd.pontoAtendimento.idPontoAtendimento.value = input.pontoAtendimento.idPontoAtendimento;
            else { }
            if (input.atendente != null)
                bd.atendente.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.atendente.idEmpresaRelacionamento;
            else { }
            bd.numeroComanda.value = input.numeroComanda;

            this.m_EntityManager.persist(bd);

            ((Data.Atendimento)parametros["Key"]).idAtendimento = (int)bd.idAtendimento.value;

            //Processa AtendimentoProdutoServico
            if (input.atendimentoProdutoServicos != null)
            {
                WS.CRUD.AtendimentoProdutoServico atendimentoProdutoServicoCRUD = new WS.CRUD.AtendimentoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.atendimentoProdutoServicos.Length; i++)
                {
                    input.atendimentoProdutoServicos[i].atendimento = new Data.Atendimento();
                    input.atendimentoProdutoServicos[i].atendimento.idAtendimento = bd.idAtendimento.value;
                    _parameters.Add("Key", input.atendimentoProdutoServicos[i]);
                    atendimentoProdutoServicoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                atendimentoProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa AtendimentoPagamento
            if (input.atendimentoPagamentos != null)
            {
                WS.CRUD.AtendimentoPagamento atendimentoPagamentoCRUD = new WS.CRUD.AtendimentoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.atendimentoPagamentos.Length; i++)
                {
                    input.atendimentoPagamentos[i].atendimento = new Data.Atendimento();
                    input.atendimentoPagamentos[i].atendimento.idAtendimento = bd.idAtendimento.value;
                    _parameters.Add("Key", input.atendimentoPagamentos[i]);
                    atendimentoPagamentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                atendimentoPagamentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Atendimento input = (Data.Atendimento)parametros["Key"];
            Tables.Atendimento bd = (Tables.Atendimento)this.m_EntityManager.find
            (
                typeof(Tables.Atendimento),
                new Object[]
                {
                    input.idAtendimento
                }
            );

            bd.dataAtendimento.value = input.dataAtendimento;
            if (input.pontoAtendimento != null)
                bd.pontoAtendimento.idPontoAtendimento.value = input.pontoAtendimento.idPontoAtendimento;
            else { }
            if (input.atendente != null)
                bd.atendente.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.atendente.idEmpresaRelacionamento;
            else { }
            bd.numeroComanda.value = input.numeroComanda;

            this.m_EntityManager.merge(bd);

            //Processa AtendimentoProdutoServico
            if (input.atendimentoProdutoServicos != null)
            {
                WS.CRUD.AtendimentoProdutoServico atendimentoProdutoServicoCRUD = new WS.CRUD.AtendimentoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.atendimentoProdutoServicos.Length; i++)
                {
                    input.atendimentoProdutoServicos[i].atendimento = new Data.Atendimento();
                    input.atendimentoProdutoServicos[i].atendimento.idAtendimento = bd.idAtendimento.value;
                    _parameters.Add("Key", input.atendimentoProdutoServicos[i]);
                    if (input.atendimentoProdutoServicos[i].operacao == ENum.eOperacao.NONE)
                        input.atendimentoProdutoServicos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    atendimentoProdutoServicoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                atendimentoProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa AtendimentoPagamento
            if (input.atendimentoPagamentos != null)
            {
                WS.CRUD.AtendimentoPagamento atendimentoPagamentoCRUD = new WS.CRUD.AtendimentoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.atendimentoPagamentos.Length; i++)
                {
                    input.atendimentoPagamentos[i].atendimento = new Data.Atendimento();
                    input.atendimentoPagamentos[i].atendimento.idAtendimento = bd.idAtendimento.value;
                    _parameters.Add("Key", input.atendimentoPagamentos[i]);
                    if (input.atendimentoPagamentos[i].operacao == ENum.eOperacao.NONE)
                        input.atendimentoPagamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    atendimentoPagamentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                atendimentoPagamentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Atendimento bd = new Tables.Atendimento();

            bd.idAtendimento.value = ((Data.Atendimento)parametros["Key"]).idAtendimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Atendimento)bd).idAtendimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Atendimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Atendimento)input).idAtendimento = ((Tables.Atendimento)bd).idAtendimento.value;
                    ((Data.Atendimento)input).dataAtendimento = ((Tables.Atendimento)bd).dataAtendimento.value;
                    ((Data.Atendimento)input).pontoAtendimento = (Data.PontoAtendimento)(new WS.CRUD.PontoAtendimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PontoAtendimento(),
                        ((Tables.Atendimento)bd).pontoAtendimento,
                        level + 1
                    );
                    ((Data.Atendimento)input).atendente = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.Atendimento)bd).atendente,
                        level + 1
                    );
                    ((Data.Atendimento)input).numeroComanda = ((Tables.Atendimento)bd).numeroComanda.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher AtendimentoProdutoServicos
                    if (((Tables.Atendimento)bd).atendimentoProdutoServicos != null)
                    {
                        System.Collections.Generic.List<Data.AtendimentoProdutoServico> _list = new System.Collections.Generic.List<Data.AtendimentoProdutoServico>();

                        foreach (Tables.AtendimentoProdutoServico _item in ((Tables.Atendimento)bd).atendimentoProdutoServicos)
                        {
                            _list.Add
                            (
                                (Data.AtendimentoProdutoServico)
                                (new WS.CRUD.AtendimentoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.AtendimentoProdutoServico(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.Atendimento)input).atendimentoProdutoServicos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.Atendimento)input).atendimentoProdutoServicos != null)
                        {
                            System.Collections.Generic.List<Data.AtendimentoProdutoServico> _list = new System.Collections.Generic.List<Data.AtendimentoProdutoServico>();

                            foreach (Data.AtendimentoProdutoServico _item in ((Data.Atendimento)input).atendimentoProdutoServicos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.Atendimento)input).atendimentoProdutoServicos = _list.ToArray();
                            else
                                ((Data.Atendimento)input).atendimentoProdutoServicos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }

                if (level < 1)
                {
                    //Preencher AtendimentoPagamentos
                    if (((Tables.Atendimento)bd).atendimentoPagamentos != null)
                    {
                        System.Collections.Generic.List<Data.AtendimentoPagamento> _list = new System.Collections.Generic.List<Data.AtendimentoPagamento>();

                        foreach (Tables.AtendimentoPagamento _item in ((Tables.Atendimento)bd).atendimentoPagamentos)
                        {
                            _list.Add
                            (
                                (Data.AtendimentoPagamento)
                                (new WS.CRUD.AtendimentoPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.AtendimentoPagamento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.Atendimento)input).atendimentoPagamentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.Atendimento)input).atendimentoPagamentos != null)
                        {
                            System.Collections.Generic.List<Data.AtendimentoPagamento> _list = new System.Collections.Generic.List<Data.AtendimentoPagamento>();

                            foreach (Data.AtendimentoPagamento _item in ((Data.Atendimento)input).atendimentoPagamentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.Atendimento)input).atendimentoPagamentos = _list.ToArray();
                            else
                                ((Data.Atendimento)input).atendimentoPagamentos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Atendimento result = (Data.Atendimento)parametros["Key"];

            try
            {
                result = (Data.Atendimento)this.preencher
                (
                    new Data.Atendimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Atendimento),
                        new Object[]
                        {
                            result.idAtendimento
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Atendimento input = (Data.Atendimento)parametros["Key"];
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
                    typeof(Tables.Atendimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Atendimento _data in
                    (System.Collections.Generic.List<Tables.Atendimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.Atendimento),
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
                    _base = (Data.Base)this.preencher(new Data.Atendimento(), _data, level);

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
