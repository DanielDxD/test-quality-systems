using System;

namespace WS.CRUD
{
    public class EmpresaRelacionamento : WS.CRUD.Base
    {
        public EmpresaRelacionamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EmpresaRelacionamento input = (Data.EmpresaRelacionamento)parametros["Key"];
            Tables.EmpresaRelacionamento bd =
            (
                parametros["Return"] != null ?
                (Tables.EmpresaRelacionamento)parametros["Return"] :
                 new Tables.EmpresaRelacionamento()
            );

            //Incluir/Alterar Pessoa
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();

                if (input.pessoa != null)
                {
                    _parametros.Add("Key", input.pessoa);

                    if (input.pessoa.idPessoa <= 0)
                        if (input.pessoa.pfpj.ToLower() == "f")
                            input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parametros);
                        else
                            input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parametros);
                    else
                    if (input.pessoa.operacao == ENum.eOperacao.ALTERAR)
                    {
                        if (input.pessoa.pfpj.ToLower() == "f")
                            input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);
                        else
                            input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);
                    }
                }
                else { }

                _parametros.Clear();
                _parametros = null;
            }

            bd.idEmpresaRelacionamento.isNull = true;
            bd.pessoaRelacionamento.idPessoa.value = input.pessoa.idPessoa;
            if (input.tipoRelacionamentoEmpresa != null)
                bd.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa.value = input.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa;
            else { }
            bd.idEmpresa.value = input.idEmpresa;
            bd.limitePosPago.value = input.limitePosPago;
            bd.senha.value = input.senha;
            if ((input.pessoaRelacionadaEmpresa != null) && (input.pessoaRelacionadaEmpresa.idEmpresaRelacionamento > 0))
                bd.pessoaRelacionadaEmpresa.idEmpresaRelacionamento.value = input.pessoaRelacionadaEmpresa.idEmpresaRelacionamento;
            else
                bd.pessoaRelacionadaEmpresa.idEmpresaRelacionamento.isNull = true;
            bd.dataInicio.value = input.dataInicio;
            if (input.dataTermino.Ticks > 0)
                bd.dataTermino.value = input.dataTermino;
            else
                bd.dataTermino.isNull = true;

            bd.codigoExportacao.isNull = true;
            if (!String.IsNullOrEmpty(input.codigoExportacao))
                bd.codigoExportacao.value = input.codigoExportacao;
            else { }

            bd.dadosBancarios.value = input.dadosBancarios;
            this.m_EntityManager.persist(bd);

            ((Data.EmpresaRelacionamento)parametros["Key"]).idEmpresaRelacionamento = (int)bd.idEmpresaRelacionamento.value;

            //Processa EmpresaRelacionamento
            if (input.empresaRelacionamentos != null)
            {
                WS.CRUD.EmpresaRelacionamento empresaRelacionamentoCRUD = new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.empresaRelacionamentos.Length; i++)
                {
                    input.empresaRelacionamentos[i] = new Data.EmpresaRelacionamento();
                    input.empresaRelacionamentos[i].idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.empresaRelacionamentos[i]);
                    empresaRelacionamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                empresaRelacionamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa EmpresaRelacionamentoCartao
            if (input.comandas != null)
            {
                WS.CRUD.EmpresaRelacionamentoCartao empresaRelacionamentoCartaoCRUD = new WS.CRUD.EmpresaRelacionamentoCartao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.comandas.Length; i++)
                {
                    input.comandas[i].empresaRelacionamento = new Data.EmpresaRelacionamento();
                    input.comandas[i].empresaRelacionamento.idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.comandas[i]);
                    empresaRelacionamentoCartaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                empresaRelacionamentoCartaoCRUD = null;
                _parameters = null;
            }
            else
            {
                Data.TipoRelacionamentoEmpresa tre = new Data.TipoRelacionamentoEmpresa
                {
                    idTipoRelacionamentoEmpresa = input.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa
                };
                System.Collections.Hashtable _parametersConsulta = new System.Collections.Hashtable();
                _parametersConsulta.Add("Key", tre);
                tre = (Data.TipoRelacionamentoEmpresa)(new WS.CRUD.TipoRelacionamentoEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parametersConsulta);
                switch (tre.tipo)
                {
                    case "ST":
                    case "SD":
                    case "SC":
                    case "SE":
                    case "EC":
                    case "CC":
                        {

                            Data.EmpresaRelacionamentoCartao erc = new Data.EmpresaRelacionamentoCartao
                            {
                                empresaRelacionamento = new Data.EmpresaRelacionamento
                                {
                                    idEmpresaRelacionamento = input.idEmpresaRelacionamento,
                                },
                                saldoAtual = 0,
                                operacao = ENum.eOperacao.INCLUIR
                            };
                            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();
                            _parameters.Add("Key", erc);
                            System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao> comandas = new System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao>();
                            erc = (Data.EmpresaRelacionamentoCartao)(new WS.CRUD.EmpresaRelacionamentoCartao(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parameters);
                            comandas.Add(erc);
                            input.comandas = comandas.ToArray();
                            break;
                        }
                }
            }

            //Processa ExameEmpresaRelacionamento
            if (input.exameEmpresaRelacionamentos != null)
            {
                WS.CRUD.ExameEmpresaRelacionamento exameEmpresaRelacionamentoCRUD = new WS.CRUD.ExameEmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.exameEmpresaRelacionamentos.Length; i++)
                {
                    input.exameEmpresaRelacionamentos[i].empresaRelacionamento = new Data.EmpresaRelacionamento();
                    input.exameEmpresaRelacionamentos[i].empresaRelacionamento.idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.exameEmpresaRelacionamentos[i]);
                    exameEmpresaRelacionamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                exameEmpresaRelacionamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa Cartoes
            if (input.cartoes != null)
            {
                WS.CRUD.Cartao cartoesCRUD = new WS.CRUD.Cartao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.cartoes.Length; i++)
                {
                    input.cartoes[i].empresaRelacionamento = new Data.EmpresaRelacionamento();
                    input.cartoes[i].empresaRelacionamento.idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.cartoes[i]);
                    cartoesCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                cartoesCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EmpresaRelacionamento input = (Data.EmpresaRelacionamento)parametros["Key"];
            Tables.EmpresaRelacionamento bd =
            (
                parametros["Return"] != null ?
                (Tables.EmpresaRelacionamento)parametros["Return"] :
                (Tables.EmpresaRelacionamento)this.m_EntityManager.find
                (
                    typeof(Tables.EmpresaRelacionamento),
                    new Object[]
                    {
                        input.idEmpresaRelacionamento
                    }
                )
            );

            //Alterar Pessoa
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.pessoa);

                if (input.pessoa.pfpj.ToLower() == "f")
                    input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);
                else
                    input.pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.pessoaRelacionamento.idPessoa.value = input.pessoa.idPessoa;
            if (input.tipoRelacionamentoEmpresa != null)
                bd.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa.value = input.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa;
            else { }
            bd.limitePosPago.value = input.limitePosPago;
            bd.senha.value = input.senha;
            bd.idEmpresa.value = input.idEmpresa;
            if ((input.pessoaRelacionadaEmpresa != null) && (input.pessoaRelacionadaEmpresa.idEmpresaRelacionamento > 0))
                bd.pessoaRelacionadaEmpresa.idEmpresaRelacionamento.value = input.pessoaRelacionadaEmpresa.idEmpresaRelacionamento;
            else
                bd.pessoaRelacionadaEmpresa.idEmpresaRelacionamento.isNull = true;
            bd.dataInicio.value = input.dataInicio;
            if (input.dataTermino.Ticks > 0)
                bd.dataTermino.value = input.dataTermino;
            else
                bd.dataTermino.isNull = true;

            bd.codigoExportacao.isNull = true;
            if (!String.IsNullOrEmpty(input.codigoExportacao))
                bd.codigoExportacao.value = input.codigoExportacao;
            else { }
            bd.dadosBancarios.value = input.dadosBancarios;
            if (input.idEmpresaRelacionamento > 0)
                bd.idEmpresaRelacionamento.value = input.idEmpresaRelacionamento;
            else { }
            this.m_EntityManager.merge(bd);

            //Processa EmpresaRelacionamento
            if (input.empresaRelacionamentos != null)
            {
                WS.CRUD.EmpresaRelacionamento empresaRelacionamentoCRUD = new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.empresaRelacionamentos.Length; i++)
                {
                    if (input.empresaRelacionamentos[i] == null)
                    {
                        input.empresaRelacionamentos[i] = new Data.EmpresaRelacionamento();
                        input.empresaRelacionamentos[i].idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    }
                    _parameters.Add("Key", input.empresaRelacionamentos[i]);
                    if (input.empresaRelacionamentos[i].operacao == ENum.eOperacao.NONE)
                        input.empresaRelacionamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    empresaRelacionamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                empresaRelacionamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa EmpresaRelacionamentoCartao
            if (input.comandas != null)
            {
                WS.CRUD.EmpresaRelacionamentoCartao empresaRelacionamentoCartaoCRUD = new WS.CRUD.EmpresaRelacionamentoCartao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.comandas.Length; i++)
                {
                    input.comandas[i].empresaRelacionamento = new Data.EmpresaRelacionamento();
                    input.comandas[i].empresaRelacionamento.idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.comandas[i]);
                    if (input.comandas[i].operacao == ENum.eOperacao.NONE)
                        input.comandas[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    empresaRelacionamentoCartaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                empresaRelacionamentoCartaoCRUD = null;
                _parameters = null;
            }
            else
            {
                switch (input.tipoRelacionamentoEmpresa.tipo)
                {
                    case "ST":
                    case "SD":
                    case "SC":
                    case "SE":
                    case "EC":
                    case "CC":
                        {

                            Data.EmpresaRelacionamentoCartao erc = new Data.EmpresaRelacionamentoCartao
                            {
                                empresaRelacionamento = new Data.EmpresaRelacionamento
                                {
                                    idEmpresaRelacionamento = input.idEmpresaRelacionamento,
                                },
                                saldoAtual = 0,
                                operacao = ENum.eOperacao.INCLUIR
                            };
                            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();
                            _parameters.Add("Key", erc);
                            System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao> comandas = new System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao>();
                            erc = (Data.EmpresaRelacionamentoCartao)(new WS.CRUD.EmpresaRelacionamentoCartao(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parameters);
                            comandas.Add(erc);
                            input.comandas = comandas.ToArray();
                            break;
                        }
                }
            }

            //Processa ExameEmpresaRelacionamento
            if (input.exameEmpresaRelacionamentos != null)
            {
                WS.CRUD.ExameEmpresaRelacionamento exameEmpresaRelacionamentoCRUD = new WS.CRUD.ExameEmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.exameEmpresaRelacionamentos.Length; i++)
                {
                    input.exameEmpresaRelacionamentos[i].empresaRelacionamento = new Data.EmpresaRelacionamento();
                    input.exameEmpresaRelacionamentos[i].empresaRelacionamento.idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.exameEmpresaRelacionamentos[i]);
                    if (input.exameEmpresaRelacionamentos[i].operacao == ENum.eOperacao.NONE)
                        input.exameEmpresaRelacionamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    exameEmpresaRelacionamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                exameEmpresaRelacionamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa Cartoes
            if (input.cartoes != null)
            {
                WS.CRUD.Cartao cartoesCRUD = new WS.CRUD.Cartao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.cartoes.Length; i++)
                {
                    input.cartoes[i].empresaRelacionamento = new Data.EmpresaRelacionamento();
                    input.cartoes[i].empresaRelacionamento.idEmpresaRelacionamento = bd.idEmpresaRelacionamento.value;
                    _parameters.Add("Key", input.cartoes[i]);
                    if (input.cartoes[i].operacao == ENum.eOperacao.NONE)
                        input.cartoes[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    cartoesCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                cartoesCRUD = null;
                _parameters = null;
            }
            else { }
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EmpresaRelacionamento bd = new Tables.EmpresaRelacionamento();

            bd.idEmpresaRelacionamento.value = ((Data.EmpresaRelacionamento)parametros["Key"]).idEmpresaRelacionamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EmpresaRelacionamento)bd).idEmpresaRelacionamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EmpresaRelacionamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EmpresaRelacionamento)input).idEmpresaRelacionamento = ((Tables.EmpresaRelacionamento)bd).idEmpresaRelacionamento.value;
                    ((Data.EmpresaRelacionamento)input).limitePosPago = ((Tables.EmpresaRelacionamento)bd).limitePosPago.value;
                    ((Data.EmpresaRelacionamento)input).tipoRelacionamentoEmpresa = (Data.TipoRelacionamentoEmpresa)(new WS.CRUD.TipoRelacionamentoEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoRelacionamentoEmpresa(),
                        ((Tables.EmpresaRelacionamento)bd).tipoRelacionamentoEmpresa,
                        level + 1
                    );
                    ((Data.EmpresaRelacionamento)input).idEmpresa = ((Tables.EmpresaRelacionamento)bd).idEmpresa.value;

                    {
                        System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                        if (((Tables.EmpresaRelacionamento)bd).pessoaRelacionamento.pfpj.value == "F")
                        {
                            ((Data.EmpresaRelacionamento)input).pessoa = new Data.PessoaFisica();
                            ((Data.EmpresaRelacionamento)input).pessoa.idPessoa = ((Tables.EmpresaRelacionamento)bd).pessoaRelacionamento.idPessoa.value;
                            _parameters.Add("Key", ((Data.EmpresaRelacionamento)input).pessoa);
                            ((Data.EmpresaRelacionamento)input).pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parameters);
                        }
                        else
                        {
                            ((Data.EmpresaRelacionamento)input).pessoa = new Data.PessoaJuridica();
                            ((Data.EmpresaRelacionamento)input).pessoa.idPessoa = ((Tables.EmpresaRelacionamento)bd).pessoaRelacionamento.idPessoa.value;
                            _parameters.Add("Key", ((Data.EmpresaRelacionamento)input).pessoa);
                            ((Data.EmpresaRelacionamento)input).pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(_parameters);
                        }

                        _parameters.Clear();
                        _parameters = null;
                    }

                    ((Data.EmpresaRelacionamento)input).pessoaRelacionadaEmpresa = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.EmpresaRelacionamento)bd).pessoaRelacionadaEmpresa,
                        level + 1
                    );

                    ((Data.EmpresaRelacionamento)input).dataInicio = ((Tables.EmpresaRelacionamento)bd).dataInicio.value;
                    ((Data.EmpresaRelacionamento)input).dataTermino = ((Tables.EmpresaRelacionamento)bd).dataTermino.value;
                    ((Data.EmpresaRelacionamento)input).dadosBancarios = ((Tables.EmpresaRelacionamento)bd).dadosBancarios.value;

                    if (level < 1)
                    {

                        //Preencher Exportação Contábil
                        if (((Tables.EmpresaRelacionamento)bd).exportacaoContabil != null)
                        {
                            System.Collections.Generic.List<Data.ExportacaoContabil> _list = new System.Collections.Generic.List<Data.ExportacaoContabil>();

                            foreach (Tables.ExportacaoContabil _item in ((Tables.EmpresaRelacionamento)bd).exportacaoContabil)
                            {
                                _list.Add
                                (
                                    (Data.ExportacaoContabil)
                                    (new WS.CRUD.ExportacaoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.ExportacaoContabil(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            if (_list.Count > 0)
                                ((Data.EmpresaRelacionamento)input).exportacaoContabil = _list[0];
                            else { }

                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            ((Data.EmpresaRelacionamento)input).exportacaoContabil = new Data.ExportacaoContabil();
                        }

                        //Preencher EmpresaRelacionamentos
                        if (((Tables.EmpresaRelacionamento)bd).empresaRelacionamentos != null)
                        {
                            System.Collections.Generic.List<Data.EmpresaRelacionamento> _list = new System.Collections.Generic.List<Data.EmpresaRelacionamento>();

                            foreach (Tables.EmpresaRelacionamento _item in ((Tables.EmpresaRelacionamento)bd).empresaRelacionamentos)
                            {
                                _list.Add
                                (
                                    (Data.EmpresaRelacionamento)
                                    (new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.EmpresaRelacionamento(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.EmpresaRelacionamento)input).empresaRelacionamentos = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.EmpresaRelacionamento)input).empresaRelacionamentos != null)
                            {
                                System.Collections.Generic.List<Data.EmpresaRelacionamento> _list = new System.Collections.Generic.List<Data.EmpresaRelacionamento>();

                                foreach (Data.EmpresaRelacionamento _item in ((Data.EmpresaRelacionamento)input).empresaRelacionamentos)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.EmpresaRelacionamento)input).empresaRelacionamentos = _list.ToArray();
                                else
                                    ((Data.EmpresaRelacionamento)input).empresaRelacionamentos = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher comandas
                        if (((Tables.EmpresaRelacionamento)bd).comandas != null)
                        {
                            System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao> _list = new System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao>();

                            foreach (Tables.EmpresaRelacionamentoCartao _item in ((Tables.EmpresaRelacionamento)bd).comandas)
                            {
                                _list.Add
                                (
                                    (Data.EmpresaRelacionamentoCartao)
                                    (new WS.CRUD.EmpresaRelacionamentoCartao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.EmpresaRelacionamentoCartao(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.EmpresaRelacionamento)input).comandas = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.EmpresaRelacionamento)input).comandas != null)
                            {
                                System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao> _list = new System.Collections.Generic.List<Data.EmpresaRelacionamentoCartao>();

                                foreach (Data.EmpresaRelacionamentoCartao _item in ((Data.EmpresaRelacionamento)input).comandas)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.EmpresaRelacionamento)input).comandas = _list.ToArray();
                                else
                                    ((Data.EmpresaRelacionamento)input).comandas = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher cartoes
                        if (((Tables.EmpresaRelacionamento)bd).cartoes != null)
                        {
                            System.Collections.Generic.List<Data.Cartao> _list = new System.Collections.Generic.List<Data.Cartao>();

                            foreach (Tables.Cartao _item in ((Tables.EmpresaRelacionamento)bd).cartoes)
                            {
                                _list.Add
                                (
                                    (Data.Cartao)
                                    (new WS.CRUD.Cartao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.Cartao(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.EmpresaRelacionamento)input).cartoes = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.EmpresaRelacionamento)input).cartoes != null)
                            {
                                System.Collections.Generic.List<Data.Cartao> _list = new System.Collections.Generic.List<Data.Cartao>();

                                foreach (Data.Cartao _item in ((Data.EmpresaRelacionamento)input).cartoes)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.EmpresaRelacionamento)input).cartoes = _list.ToArray();
                                else
                                    ((Data.EmpresaRelacionamento)input).cartoes = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher ExameEmpresaRelacionamentos
                        if (((Tables.EmpresaRelacionamento)bd).exameEmpresaRelacionamentos != null)
                        {
                            System.Collections.Generic.List<Data.ExameEmpresaRelacionamento> _list = new System.Collections.Generic.List<Data.ExameEmpresaRelacionamento>();

                            foreach (Tables.ExameEmpresaRelacionamento _item in ((Tables.EmpresaRelacionamento)bd).exameEmpresaRelacionamentos)
                            {
                                _list.Add
                                (
                                    (Data.ExameEmpresaRelacionamento)
                                    (new WS.CRUD.ExameEmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.ExameEmpresaRelacionamento(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.EmpresaRelacionamento)input).exameEmpresaRelacionamentos = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.EmpresaRelacionamento)input).exameEmpresaRelacionamentos != null)
                            {
                                System.Collections.Generic.List<Data.ExameEmpresaRelacionamento> _list = new System.Collections.Generic.List<Data.ExameEmpresaRelacionamento>();

                                foreach (Data.ExameEmpresaRelacionamento _item in ((Data.EmpresaRelacionamento)input).exameEmpresaRelacionamentos)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.EmpresaRelacionamento)input).exameEmpresaRelacionamentos = _list.ToArray();
                                else
                                    ((Data.EmpresaRelacionamento)input).exameEmpresaRelacionamentos = null;

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
            Data.EmpresaRelacionamento result = (Data.EmpresaRelacionamento)parametros["Key"];

            try
            {
                result = (Data.EmpresaRelacionamento)this.preencher
                (
                    new Data.EmpresaRelacionamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EmpresaRelacionamento),
                        new Object[]
                        {
                            result.idEmpresaRelacionamento
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

            Data.EmpresaRelacionamento _input = (Data.EmpresaRelacionamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idEmpresaRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresaRelacionamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresaRelacionamento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoExportacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.codigoExportacao = @codigoExportacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoExportacao", _input.codigoExportacao));
                    if (!sqlOrderBy.Contains("empresaRelacionamento.codigoExportacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.codigoExportacao");
                    else { }
                }
                else { }

                if (_input.pessoa != null)
                {
                    if (_input.pessoa.idPessoa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.pessoa.idPessoa));
                        if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                        else { }
                    }
                    else { }

                    if ((_input.pessoa.cpfCnpj != null) && (_input.pessoa.cpfCnpj.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.pessoa.cpfCnpj + '%'));
                        if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                        else { }
                    }
                    else { }


                    if ((_input.pessoa.nomeRazaoSocial != null) && (_input.pessoa.nomeRazaoSocial.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.pessoa.nomeRazaoSocial + '%'));
                        if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                        else { }
                    }
                    else { }

                    if (_input.pessoaRelacionadaEmpresa != null && _input.pessoaRelacionadaEmpresa.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idPessoaRelacionadaEmpresa = @idPessoaRelacionadaEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoaRelacionadaEmpresa", _input.pessoaRelacionadaEmpresa.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idPessoaRelacionadaEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idPessoaRelacionadaEmpresa");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   empresaRelacionamento.* " +
                    "from " +
                    @"   empresaRelacionamento 
                        inner join tipoRelacionamentoEmpresa tipoRelacionamentoEmpresa
	                        on	tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = empresaRelacionamento.idTipoRelacionamentoEmpresa 
                        inner join pessoa pessoa
	                        on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
		                left join pessoaJuridica
			                on	pessoaJuridica.idPessoaJuridica = pessoa.idPessoa
		                left join pessoaFisica
			                on	pessoaFisica.idPessoaFisica = pessoa.idPessoa
		                left join exportacaoContabil
			                on	exportacaoContabil.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionamento
                        LEFT JOIN
                        (
	                        select 
		                        idPessoa, 
		                        pessoaContatoAcesso.informacao 
	                        from pessoaContatoAcesso
	                        INNER JOIN pessoaEnderecoContato ON pessoaEnderecoContato.idPessoaEnderecoContato = pessoaContatoAcesso.idPessoaContatoAcesso
	                        INNER JOIN tipoAcessoContato ON tipoAcessoContato.idTipoAcessoContato = pessoaContatoAcesso.idTipoAcessoContato
	                        WHERE
		                        tipoAcessoContato.tipo = 'E'
                        ) email ON email.idPessoa = pessoa.idPessoa " +
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
            Data.EmpresaRelacionamento input = (Data.EmpresaRelacionamento)parametros["Key"];
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
                    typeof(Tables.EmpresaRelacionamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.EmpresaRelacionamento _data in
                    (System.Collections.Generic.List<Tables.EmpresaRelacionamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.EmpresaRelacionamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.EmpresaRelacionamento();
                        ((Data.EmpresaRelacionamento)_base).idEmpresaRelacionamento = _data.idEmpresaRelacionamento.value;
                        ((Data.EmpresaRelacionamento)_base).limitePosPago = _data.limitePosPago.value;
                        ((Data.EmpresaRelacionamento)_base).pessoa = new Data.Pessoa { nomeRazaoSocial = _data.pessoaRelacionamento.nomeRazaoSocial.value };
                        ((Data.EmpresaRelacionamento)_base).pessoa.idPessoa = _data.pessoaRelacionamento.idPessoa.value;
                        ((Data.EmpresaRelacionamento)_base).pessoa.cpfCnpj = _data.pessoaRelacionamento.cpfCnpj.value;
                        ((Data.EmpresaRelacionamento)_base).pessoa.pfpj = _data.pessoaRelacionamento.pfpj.value;

                        if (!String.IsNullOrEmpty(_data.pessoaRelacionamento.cpfCnpj.value))
                            if (((Data.EmpresaRelacionamento)_base).pessoa.pfpj == "F")
                                ((Data.EmpresaRelacionamento)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                            else
                                ((Data.EmpresaRelacionamento)_base).pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");
                        else { }
                        ((Data.EmpresaRelacionamento)_base).codigoExportacao = _data.codigoExportacao.value;
                        ((Data.EmpresaRelacionamento)_base).dadosBancarios = _data.dadosBancarios.value;
                        ((Data.EmpresaRelacionamento)_base).tipoRelacionamentoEmpresa = new Data.TipoRelacionamentoEmpresa
                        {
                            tipo = _data.tipoRelacionamentoEmpresa.tipo.value,
                            descricao = _data.tipoRelacionamentoEmpresa.descricao.value,
                            idTipoRelacionamentoEmpresa = _data.idEmpresaRelacionamento.value
                        };

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.EmpresaRelacionamento(), _data, level);

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
