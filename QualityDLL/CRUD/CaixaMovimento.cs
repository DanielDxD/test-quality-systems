using System;

namespace WS.CRUD
{
    public class CaixaMovimento : WS.CRUD.Base
    {
        public CaixaMovimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimento input = (Data.CaixaMovimento)parametros["Key"];
            Tables.CaixaMovimento bd = new Tables.CaixaMovimento();

            bd.idCaixaMovimento.isNull = true;
            if (input.caixa != null)
                bd.caixa.idCaixa.value = input.caixa.idCaixa;
            else { }
            bd.dataMovimento.value = input.dataMovimento;
            bd.recebimentoPagamento.value = input.recebimentoPagamento;
            bd.valor.value = input.valor;
            bd.formaPagamento.value = input.formaPagamento;
            if (input.cliente != null)
                bd.cliente.idEmpresaRelacionamento.value = input.cliente.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.CaixaMovimento)parametros["Key"]).idCaixaMovimento = (int)bd.idCaixaMovimento.value;

            //Processa CaixaMovimentoLancamento
            if (input.caixaMovimentoLancamentos != null)
            {
                WS.CRUD.CaixaMovimentoLancamento caixaMovimentoLancamentoCRUD = new WS.CRUD.CaixaMovimentoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentoLancamentos.Length; i++)
                {
                    input.caixaMovimentoLancamentos[i].caixaMovimento = new Data.CaixaMovimento();
                    input.caixaMovimentoLancamentos[i].caixaMovimento.idCaixaMovimento = bd.idCaixaMovimento.value;
                    _parameters.Add("Key", input.caixaMovimentoLancamentos[i]);
                    caixaMovimentoLancamentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                caixaMovimentoLancamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa CaixaMovimentoAtendimento
            if (input.caixaMovimentoAtendimentos != null)
            {
                WS.CRUD.CaixaMovimentoAtendimento caixaMovimentoAtendimentoCRUD = new WS.CRUD.CaixaMovimentoAtendimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentoAtendimentos.Length; i++)
                {
                    input.caixaMovimentoAtendimentos[i].caixaMovimento = new Data.CaixaMovimento();
                    input.caixaMovimentoAtendimentos[i].caixaMovimento.idCaixaMovimento = bd.idCaixaMovimento.value;
                    _parameters.Add("Key", input.caixaMovimentoAtendimentos[i]);
                    caixaMovimentoAtendimentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                caixaMovimentoAtendimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimento input = (Data.CaixaMovimento)parametros["Key"];
            Tables.CaixaMovimento bd = (Tables.CaixaMovimento)this.m_EntityManager.find
            (
                typeof(Tables.CaixaMovimento),
                new Object[]
                {
                    input.idCaixaMovimento
                }
            );

            if (input.caixa != null)
                bd.caixa.idCaixa.value = input.caixa.idCaixa;
            else { }
            bd.dataMovimento.value = input.dataMovimento;
            bd.recebimentoPagamento.value = input.recebimentoPagamento;
            bd.valor.value = input.valor;
            bd.formaPagamento.value = input.formaPagamento;
            if (input.cliente != null)
                bd.cliente.idEmpresaRelacionamento.value = input.cliente.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.merge(bd);

            //Processa CaixaMovimentoLancamento
            if (input.caixaMovimentoLancamentos != null)
            {
                WS.CRUD.CaixaMovimentoLancamento caixaMovimentoLancamentoCRUD = new WS.CRUD.CaixaMovimentoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentoLancamentos.Length; i++)
                {
                    input.caixaMovimentoLancamentos[i].caixaMovimento = new Data.CaixaMovimento();
                    input.caixaMovimentoLancamentos[i].caixaMovimento.idCaixaMovimento = bd.idCaixaMovimento.value;
                    _parameters.Add("Key", input.caixaMovimentoLancamentos[i]);
                    if (input.caixaMovimentoLancamentos[i].operacao == ENum.eOperacao.NONE)
                        input.caixaMovimentoLancamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    caixaMovimentoLancamentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                caixaMovimentoLancamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa CaixaMovimentoAtendimento
            if (input.caixaMovimentoAtendimentos != null)
            {
                WS.CRUD.CaixaMovimentoAtendimento caixaMovimentoAtendimentoCRUD = new WS.CRUD.CaixaMovimentoAtendimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentoAtendimentos.Length; i++)
                {
                    input.caixaMovimentoAtendimentos[i].caixaMovimento = new Data.CaixaMovimento();
                    input.caixaMovimentoAtendimentos[i].caixaMovimento.idCaixaMovimento = bd.idCaixaMovimento.value;
                    _parameters.Add("Key", input.caixaMovimentoAtendimentos[i]);
                    if (input.caixaMovimentoAtendimentos[i].operacao == ENum.eOperacao.NONE)
                        input.caixaMovimentoAtendimentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    caixaMovimentoAtendimentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                caixaMovimentoAtendimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CaixaMovimento bd = new Tables.CaixaMovimento();

            bd.idCaixaMovimento.value = ((Data.CaixaMovimento)parametros["Key"]).idCaixaMovimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CaixaMovimento)bd).idCaixaMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CaixaMovimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CaixaMovimento)input).idCaixaMovimento = ((Tables.CaixaMovimento)bd).idCaixaMovimento.value;
                    ((Data.CaixaMovimento)input).caixa = (Data.Caixa)(new WS.CRUD.Caixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Caixa(),
                        ((Tables.CaixaMovimento)bd).caixa,
                        level + 1
                    );
                    ((Data.CaixaMovimento)input).dataMovimento = ((Tables.CaixaMovimento)bd).dataMovimento.value;
                    ((Data.CaixaMovimento)input).recebimentoPagamento = ((Tables.CaixaMovimento)bd).recebimentoPagamento.value;
                    ((Data.CaixaMovimento)input).valor = ((Tables.CaixaMovimento)bd).valor.value;
                    ((Data.CaixaMovimento)input).formaPagamento = ((Tables.CaixaMovimento)bd).formaPagamento.value;
                    ((Data.CaixaMovimento)input).cliente = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.CaixaMovimento)bd).cliente,
                        level + 1
                    );
                }
                else { }

                if (level < 1)
                {
                    //Preencher CaixaMovimentoLancamentos
                    if (((Tables.CaixaMovimento)bd).caixaMovimentoLancamentos != null)
                    {
                        System.Collections.Generic.List<Data.CaixaMovimentoLancamento> _list = new System.Collections.Generic.List<Data.CaixaMovimentoLancamento>();

                        foreach (Tables.CaixaMovimentoLancamento _item in ((Tables.CaixaMovimento)bd).caixaMovimentoLancamentos)
                        {
                            _list.Add
                            (
                                (Data.CaixaMovimentoLancamento)
                                (new WS.CRUD.CaixaMovimentoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.CaixaMovimentoLancamento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.CaixaMovimento)input).caixaMovimentoLancamentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.CaixaMovimento)input).caixaMovimentoLancamentos != null)
                        {
                            System.Collections.Generic.List<Data.CaixaMovimentoLancamento> _list = new System.Collections.Generic.List<Data.CaixaMovimentoLancamento>();

                            foreach (Data.CaixaMovimentoLancamento _item in ((Data.CaixaMovimento)input).caixaMovimentoLancamentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.CaixaMovimento)input).caixaMovimentoLancamentos = _list.ToArray();
                            else
                                ((Data.CaixaMovimento)input).caixaMovimentoLancamentos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher CaixaMovimentoAtendimentos
                    if (((Tables.CaixaMovimento)bd).caixaMovimentoAtendimentos != null)
                    {
                        System.Collections.Generic.List<Data.CaixaMovimentoAtendimento> _list = new System.Collections.Generic.List<Data.CaixaMovimentoAtendimento>();

                        foreach (Tables.CaixaMovimentoAtendimento _item in ((Tables.CaixaMovimento)bd).caixaMovimentoAtendimentos)
                        {
                            _list.Add
                            (
                                (Data.CaixaMovimentoAtendimento)
                                (new WS.CRUD.CaixaMovimentoAtendimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.CaixaMovimentoAtendimento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.CaixaMovimento)input).caixaMovimentoAtendimentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.CaixaMovimento)input).caixaMovimentoAtendimentos != null)
                        {
                            System.Collections.Generic.List<Data.CaixaMovimentoAtendimento> _list = new System.Collections.Generic.List<Data.CaixaMovimentoAtendimento>();

                            foreach (Data.CaixaMovimentoAtendimento _item in ((Data.CaixaMovimento)input).caixaMovimentoAtendimentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.CaixaMovimento)input).caixaMovimentoAtendimentos = _list.ToArray();
                            else
                                ((Data.CaixaMovimento)input).caixaMovimentoAtendimentos = null;

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
            Data.CaixaMovimento result = (Data.CaixaMovimento)parametros["Key"];

            try
            {
                result = (Data.CaixaMovimento)this.preencher
                (
                    new Data.CaixaMovimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CaixaMovimento),
                        new Object[]
                        {
                            result.idCaixaMovimento
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
            Data.CaixaMovimento input = (Data.CaixaMovimento)parametros["Key"];
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
                    typeof(Tables.CaixaMovimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CaixaMovimento _data in
                    (System.Collections.Generic.List<Tables.CaixaMovimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.CaixaMovimento),
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
                    _base = (Data.Base)this.preencher(new Data.CaixaMovimento(), _data, level);

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
