using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WS.CRUD
{
    public class ProdutoServico : WS.CRUD.Base
    {
        public ProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServico input = (Data.ProdutoServico)parametros["Key"];
            Tables.ProdutoServico bd = new Tables.ProdutoServico();

            bd.idProdutoServico.isNull = true;
            bd.descricao.value = input.descricao;
            bd.marcaModelo.value = input.marcaModelo;
            bd.cest.value = input.cest;
            bd.extIpi.value = input.extIpi;
            bd.taxaServico.value = input.taxaServico == "s";


            if ((input.unidadeProdutoServico != null) && (input.unidadeProdutoServico.idUnidadeProdutoServico > 0))
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }
            bd.perecivel.value = input.perecivel;
            bd.estocavel.value = input.estocavel;
            if (input.ncm != null && input.ncm.idNcm > 0)
                bd.ncm.idNcm.value = input.ncm.idNcm;
            else
                bd.ncm.idNcm.isNull = true;
            if (!String.IsNullOrEmpty(input.EAN))
                bd.EAN.value = input.EAN;
            else
                bd.EAN.isNull = true;

            bd.departamento.idDepartamento.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if ((input.regraContabilizacao != null) && (input.regraContabilizacao.idRegraContabilizacao > 0))
                bd.regraContabilizacao.idRegraContabilizacao.value = input.regraContabilizacao.idRegraContabilizacao;
            else { }
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServico)parametros["Key"]).idProdutoServico = (int)bd.idProdutoServico.value;

            //Process ProdutoServicoEmpresa
            if (input.produtoServicoEmpresas != null)
            {
                WS.CRUD.ProdutoServicoEmpresa produtoServicoEmpresaCRUD = new WS.CRUD.ProdutoServicoEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoEmpresas.Length; i++)
                {
                    input.produtoServicoEmpresas[i].idProdutoServico = bd.idProdutoServico.value;
                    _parameters.Add("Key", input.produtoServicoEmpresas[i]);
                    produtoServicoEmpresaCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                produtoServicoEmpresaCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ProdutoServicoComposicao
            if (input.produtoServicoComposicaos != null)
            {
                WS.CRUD.ProdutoServicoComposicao produtoServicoComposicaoCRUD = new WS.CRUD.ProdutoServicoComposicao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoComposicaos.Length; i++)
                {
                    if (input.produtoServicoComposicaos[i].idProdutoServicoComposicao != 0)
                    {
                        input.produtoServicoComposicaos[i].idProdutoServico = bd.idProdutoServico.value;
                        _parameters.Add("Key", input.produtoServicoComposicaos[i]);
                        produtoServicoComposicaoCRUD.atualizar(_parameters);
                        _parameters.Clear();
                    }
                    else { }
                }

                produtoServicoComposicaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ProdutoServicoFornecedor
            if (input.produtoServicoFornecedors != null)
            {
                WS.CRUD.ProdutoServicoFornecedor produtoServicoFornecedorCRUD = new WS.CRUD.ProdutoServicoFornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoFornecedors.Length; i++)
                {
                    if (input.produtoServicoFornecedors[i].idProdutoServicoFornecedor != 0)
                    {
                        input.produtoServicoFornecedors[i].idProdutoServico = bd.idProdutoServico.value;
                        _parameters.Add("Key", input.produtoServicoFornecedors[i]);
                        produtoServicoFornecedorCRUD.atualizar(_parameters);
                        _parameters.Clear();
                    }
                    else { }
                }

                produtoServicoFornecedorCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.produtoServicoUnidades != null)
            {
                WS.CRUD.ProdutoServicoUnidade produtoServicoUnidadeCRUD = new WS.CRUD.ProdutoServicoUnidade(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoUnidades.Length; i++)
                {
                    input.produtoServicoUnidades[i].idProdutoServico = bd.idProdutoServico.value;
                    _parameters.Add("Key", input.produtoServicoUnidades[i]);
                    produtoServicoUnidadeCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                produtoServicoUnidadeCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.produtoServicoEstoques != null)
            {
                WS.CRUD.ProdutoServicoEstoque produtoServicoEstoqueCRUD = new WS.CRUD.ProdutoServicoEstoque(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoEstoques.Length; i++)
                {
                    input.produtoServicoEstoques[i].idProdutoServico = bd.idProdutoServico.value;
                    _parameters.Add("Key", input.produtoServicoEstoques[i]);
                    produtoServicoEstoqueCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                produtoServicoEstoqueCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServico input = (Data.ProdutoServico)parametros["Key"];
            Tables.ProdutoServico bd = (Tables.ProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServico),
                new Object[]
                {
                    input.idProdutoServico
                }
            );

            bd.descricao.value = input.descricao;
            bd.marcaModelo.value = input.marcaModelo;
            bd.cest.value = input.cest;
            bd.taxaServico.value = input.taxaServico == "s";
            bd.extIpi.value = input.extIpi;
            if ((input.unidadeProdutoServico != null) && (input.unidadeProdutoServico.idUnidadeProdutoServico > 0))
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }
            bd.perecivel.value = input.perecivel;
            bd.estocavel.value = input.estocavel;
            if (input.ncm != null && input.ncm.idNcm > 0)
                bd.ncm.idNcm.value = input.ncm.idNcm;
            else
                bd.ncm.idNcm.isNull = true;
            if (!String.IsNullOrEmpty(input.EAN))
                bd.EAN.value = input.EAN;
            else
                bd.EAN.isNull = true;

            bd.departamento.idDepartamento.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if ((input.regraContabilizacao != null) && (input.regraContabilizacao.idRegraContabilizacao > 0))
                bd.regraContabilizacao.idRegraContabilizacao.value = input.regraContabilizacao.idRegraContabilizacao;
            else { }
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.merge(bd);

            //Process ProdutoServicoEmpresa
            if (input.produtoServicoEmpresas != null)
            {
                WS.CRUD.ProdutoServicoEmpresa produtoServicoEmpresaCRUD = new WS.CRUD.ProdutoServicoEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoEmpresas.Length; i++)
                {
                    input.produtoServicoEmpresas[i].idProdutoServico = bd.idProdutoServico.value;
                    _parameters.Add("Key", input.produtoServicoEmpresas[i]);
                    produtoServicoEmpresaCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                produtoServicoEmpresaCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ProdutoServicoComposicao
            if (input.produtoServicoComposicaos != null)
            {
                WS.CRUD.ProdutoServicoComposicao produtoServicoComposicaoCRUD = new WS.CRUD.ProdutoServicoComposicao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoComposicaos.Length; i++)
                {
                    if (input.produtoServicoComposicaos[i].idProdutoServicoComposicao != 0)
                    {
                        input.produtoServicoComposicaos[i].idProdutoServico = bd.idProdutoServico.value;
                        _parameters.Add("Key", input.produtoServicoComposicaos[i]);
                        if (input.produtoServicoComposicaos[i].operacao == ENum.eOperacao.NONE)
                            input.produtoServicoComposicaos[i].operacao = ENum.eOperacao.ALTERAR;
                        else { }
                        produtoServicoComposicaoCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }
                    else { }
                }

                produtoServicoComposicaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ProdutoServicoFornecedor
            if (input.produtoServicoFornecedors != null)
            {
                WS.CRUD.ProdutoServicoFornecedor produtoServicoFornecedorCRUD = new WS.CRUD.ProdutoServicoFornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoFornecedors.Length; i++)
                {
                    if (input.produtoServicoFornecedors[i].idProdutoServicoFornecedor != 0)
                    {
                        input.produtoServicoFornecedors[i].idProdutoServico = bd.idProdutoServico.value;
                        _parameters.Add("Key", input.produtoServicoFornecedors[i]);
                        if (input.produtoServicoFornecedors[i].operacao == ENum.eOperacao.NONE)
                            input.produtoServicoFornecedors[i].operacao = ENum.eOperacao.ALTERAR;
                        else { }
                        produtoServicoFornecedorCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }
                    else { }
                }

                produtoServicoFornecedorCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ProdutoServicoUnidade
            if (input.produtoServicoUnidades != null)
            {
                WS.CRUD.ProdutoServicoUnidade produtoServicoUnidadeCRUD = new WS.CRUD.ProdutoServicoUnidade(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.produtoServicoUnidades.Length; i++)
                {
                    if (
                        (input.produtoServicoUnidades[i].operacao == ENum.eOperacao.ALTERAR && input.produtoServicoUnidades[i].idProdutoServicoUnidade != 0 && input.produtoServicoUnidades[i].unidadeProdutoServico.idUnidadeProdutoServico != 0) ||
                        input.produtoServicoUnidades[i].operacao == ENum.eOperacao.INCLUIR ||
                        input.produtoServicoUnidades[i].operacao == ENum.eOperacao.EXCLUIR
                        )
                    {
                        input.produtoServicoUnidades[i].idProdutoServico = bd.idProdutoServico.value;
                        _parameters.Add("Key", input.produtoServicoUnidades[i]);
                        if (input.produtoServicoUnidades[i].operacao == ENum.eOperacao.NONE)
                            input.produtoServicoUnidades[i].operacao = ENum.eOperacao.ALTERAR;
                        else { }
                        produtoServicoUnidadeCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }
                    else { }
                }

                produtoServicoUnidadeCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServico bd = new Tables.ProdutoServico();

            bd.idProdutoServico.value = ((Data.ProdutoServico)parametros["Key"]).idProdutoServico;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServico)bd).idProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServico)input).operacao = ENum.eOperacao.NONE;
                    ((Data.ProdutoServico)input).saldo = 0;
                    ((Data.ProdutoServico)input).idProdutoServico = ((Tables.ProdutoServico)bd).idProdutoServico.value;
                    ((Data.ProdutoServico)input).descricao = ((Tables.ProdutoServico)bd).descricao.value;
                    ((Data.ProdutoServico)input).marcaModelo = ((Tables.ProdutoServico)bd).marcaModelo.value;
                    ((Data.ProdutoServico)input).cest = ((Tables.ProdutoServico)bd).cest.value;
                    ((Data.ProdutoServico)input).taxaServico = ((Tables.ProdutoServico)bd).taxaServico.value ? "s" : "n";
                    ((Data.ProdutoServico)input).extIpi = ((Tables.ProdutoServico)bd).extIpi.value;
                    ((Data.ProdutoServico)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.ProdutoServico)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.ProdutoServico)input).perecivel = ((Tables.ProdutoServico)bd).perecivel.value;
                    ((Data.ProdutoServico)input).estocavel = ((Tables.ProdutoServico)bd).estocavel.value;
                    ((Data.ProdutoServico)input).ncm = (Data.Ncm)(new WS.CRUD.Ncm(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Ncm(),
                        ((Tables.ProdutoServico)bd).ncm,
                        level + 1
                    );

                    if (!((Tables.ProdutoServico)bd).EAN.isNull)
                        ((Data.ProdutoServico)input).EAN = ((Tables.ProdutoServico)bd).EAN.value;
                    else { }

                    ((Data.ProdutoServico)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ProdutoServico)bd).departamento,
                        level + 1
                    );

                    //if(((Data.ProdutoServico)input).planoContas != null) {

                    ((Data.ProdutoServico)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.ProdutoServico)bd).planoContas,
                        level + 1
                    );
                    //}
                    if (((Data.ProdutoServico)input).regraContabilizacao != null)
                    {
                        ((Data.ProdutoServico)input).regraContabilizacao = (Data.RegraContabilizacao)(new WS.CRUD.RegraContabilizacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.RegraContabilizacao(),
                            ((Tables.ProdutoServico)bd).regraContabilizacao,
                            level + 1
                        );
                    }
                    if (((Data.ProdutoServico)input).tipoMovimentoContabil != null)
                    {
                        ((Data.ProdutoServico)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.TipoMovimentoContabil(),
                            ((Tables.ProdutoServico)bd).tipoMovimentoContabil,
                            level + 1
                        );
                    }

                    if (level < 1)
                    {
                        ((Data.ProdutoServico)input).valorUltimaCompra = new Data.ProdutoServico
                        {
                            idProdutoServico = ((Tables.ProdutoServico)bd).idProdutoServico.value
                        }.valorRateado();


                        //Preencher ProdutoServicoEmpresas
                        if (((Tables.ProdutoServico)bd).produtoServicoEmpresas != null)
                        {
                            System.Collections.Generic.List<Data.ProdutoServicoEmpresa> _list = new System.Collections.Generic.List<Data.ProdutoServicoEmpresa>();

                            foreach (Tables.ProdutoServicoEmpresa _item in ((Tables.ProdutoServico)bd).produtoServicoEmpresas)
                            {
                                if (_item.idEmpresa.value == this.m_IdEmpresaCorrente)
                                {
                                    ((Data.ProdutoServico)input).saldo += _item.quantidade.value;
                                    _list.Add
                                    (
                                        (Data.ProdutoServicoEmpresa)
                                        (new WS.CRUD.ProdutoServicoEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.ProdutoServicoEmpresa(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }
                                else { }
                            }

                            ((Data.ProdutoServico)input).produtoServicoEmpresas = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ProdutoServico)input).produtoServicoEmpresas != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoEmpresa> _list = new System.Collections.Generic.List<Data.ProdutoServicoEmpresa>();

                                foreach (Data.ProdutoServicoEmpresa _item in ((Data.ProdutoServico)input).produtoServicoEmpresas)
                                {
                                    if (_item.idEmpresa == this.m_IdEmpresaCorrente)
                                    {
                                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                        {
                                            _item.operacao = ENum.eOperacao.NONE;
                                            _list.Add(_item);
                                        }
                                        else { }
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ProdutoServico)input).produtoServicoEmpresas = _list.ToArray();
                                else
                                    ((Data.ProdutoServico)input).produtoServicoEmpresas = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher ProdutoServicoComposicaos
                        if (((Tables.ProdutoServico)bd).produtoServicoComposicaos != null)
                        {
                            System.Collections.Generic.List<Data.ProdutoServicoComposicao> _list = new System.Collections.Generic.List<Data.ProdutoServicoComposicao>();

                            foreach (Tables.ProdutoServicoComposicao _item in ((Tables.ProdutoServico)bd).produtoServicoComposicaos)
                            {
                                _list.Add
                                (
                                    (Data.ProdutoServicoComposicao)
                                    (new WS.CRUD.ProdutoServicoComposicao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.ProdutoServicoComposicao(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.ProdutoServico)input).produtoServicoComposicaos = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ProdutoServico)input).produtoServicoComposicaos != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoComposicao> _list = new System.Collections.Generic.List<Data.ProdutoServicoComposicao>();

                                foreach (Data.ProdutoServicoComposicao _item in ((Data.ProdutoServico)input).produtoServicoComposicaos)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ProdutoServico)input).produtoServicoComposicaos = _list.ToArray();
                                else
                                    ((Data.ProdutoServico)input).produtoServicoComposicaos = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher ProdutoServicoEstoques
                        if (((Tables.ProdutoServico)bd).produtoServicoEstoques != null)
                        {
                            System.Collections.Generic.List<Data.ProdutoServicoEstoque> _list = new System.Collections.Generic.List<Data.ProdutoServicoEstoque>();
                            System.Collections.Generic.List<int> _departamentos = new System.Collections.Generic.List<int>();

                            System.Collections.Hashtable _param = new System.Collections.Hashtable();
                            _param.Add("Key", new Data.Departamento { idEmpresa = (int)this.m_IdEmpresaCorrente });

                            try
                            {
                                foreach (Data.Departamento _base in (Data.Base[])(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).listar(_param))
                                {
                                    _departamentos.Add(_base.idDepartamento);
                                }
                            }
                            catch { }

                            _param.Clear();
                            _param = null;

                            foreach (Tables.ProdutoServicoEstoque _item in ((Tables.ProdutoServico)bd).produtoServicoEstoques)
                            {
                                if (_departamentos.Contains(_item.idDepartamento.value))
                                {
                                    _list.Add
                                    (
                                        (Data.ProdutoServicoEstoque)
                                        (new WS.CRUD.ProdutoServicoEstoque(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.ProdutoServicoEstoque(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }
                                else { }
                            }

                            _departamentos.Clear();
                            _departamentos = null;

                            ((Data.ProdutoServico)input).produtoServicoEstoques = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ProdutoServico)input).produtoServicoEstoques != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoEstoque> _list = new System.Collections.Generic.List<Data.ProdutoServicoEstoque>();

                                foreach (Data.ProdutoServicoEstoque _item in ((Data.ProdutoServico)input).produtoServicoEstoques)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ProdutoServico)input).produtoServicoEstoques = _list.ToArray();
                                else
                                    ((Data.ProdutoServico)input).produtoServicoEstoques = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher ProdutoServicoFornecedors
                        if (((Tables.ProdutoServico)bd).produtoServicoFornecedors != null)
                        {
                            System.Collections.Generic.List<Data.ProdutoServicoFornecedor> _list = new System.Collections.Generic.List<Data.ProdutoServicoFornecedor>();

                            foreach (Tables.ProdutoServicoFornecedor _item in ((Tables.ProdutoServico)bd).produtoServicoFornecedors)
                            {
                                if (_item.fornecedor.fornecedorEmpresaRelacionamento.idEmpresa.value == this.m_IdEmpresaCorrente)
                                {
                                    _list.Add
                                    (
                                        (Data.ProdutoServicoFornecedor)
                                        (new WS.CRUD.ProdutoServicoFornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.ProdutoServicoFornecedor(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }
                                else { }
                            }

                            ((Data.ProdutoServico)input).produtoServicoFornecedors = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ProdutoServico)input).produtoServicoFornecedors != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoFornecedor> _list = new System.Collections.Generic.List<Data.ProdutoServicoFornecedor>();

                                foreach (Data.ProdutoServicoFornecedor _item in ((Data.ProdutoServico)input).produtoServicoFornecedors)
                                {
                                    if (_item.fornecedor.idEmpresa == this.m_IdEmpresaCorrente)
                                    {
                                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                        {
                                            _item.operacao = ENum.eOperacao.NONE;
                                            _list.Add(_item);
                                        }
                                        else { }
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ProdutoServico)input).produtoServicoFornecedors = _list.ToArray();
                                else
                                    ((Data.ProdutoServico)input).produtoServicoFornecedors = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                        //Preencher ProdutoServicoUnidades
                        if (((Tables.ProdutoServico)bd).produtoServicoUnidades != null)
                        {
                            System.Collections.Generic.List<Data.ProdutoServicoUnidade> _list = new System.Collections.Generic.List<Data.ProdutoServicoUnidade>();

                            foreach (Tables.ProdutoServicoUnidade _item in ((Tables.ProdutoServico)bd).produtoServicoUnidades)
                            {
                                _list.Add
                                (
                                    (Data.ProdutoServicoUnidade)
                                    (new WS.CRUD.ProdutoServicoUnidade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.ProdutoServicoUnidade(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.ProdutoServico)input).produtoServicoUnidades = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ProdutoServico)input).produtoServicoUnidades != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoUnidade> _list = new System.Collections.Generic.List<Data.ProdutoServicoUnidade>();

                                foreach (Data.ProdutoServicoUnidade _item in ((Data.ProdutoServico)input).produtoServicoUnidades)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ProdutoServico)input).produtoServicoUnidades = _list.ToArray();
                                else
                                    ((Data.ProdutoServico)input).produtoServicoUnidades = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        if (((Tables.ProdutoServico)bd).produtoServicoPatrimonio != null)
                        {
                            System.Collections.Generic.List<Data.ProdutoServicoPatrimonio> _list = new System.Collections.Generic.List<Data.ProdutoServicoPatrimonio>();

                            foreach (Tables.ProdutoServicoPatrimonio _item in ((Tables.ProdutoServico)bd).produtoServicoPatrimonio)
                            {
                                if (_item.empresa.idEmpresa.value == this.m_IdEmpresaCorrente)
                                {
                                    _list.Add
                                    (
                                        (Data.ProdutoServicoPatrimonio)
                                        (new WS.CRUD.ProdutoServicoPatrimonio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.ProdutoServicoPatrimonio(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }
                                else { }
                            }

                                ((Data.ProdutoServico)input).produtoServicoPatrimonio = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ProdutoServico)input).produtoServicoPatrimonio != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoPatrimonio> _list = new System.Collections.Generic.List<Data.ProdutoServicoPatrimonio>();

                                foreach (Data.ProdutoServicoPatrimonio _item in ((Data.ProdutoServico)input).produtoServicoPatrimonio)
                                {
                                    if (_item.produtoServicoEmpresa != null && _item.produtoServicoEmpresa.idEmpresa == this.m_IdEmpresaCorrente)
                                    {
                                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                        {
                                            _item.operacao = ENum.eOperacao.NONE;
                                            _list.Add(_item);
                                        }
                                        else { }
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ProdutoServico)input).produtoServicoPatrimonio = _list.ToArray();
                                else
                                    ((Data.ProdutoServico)input).produtoServicoPatrimonio = null;

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
            Data.ProdutoServico result = (Data.ProdutoServico)parametros["Key"];

            try
            {
                result = (Data.ProdutoServico)this.preencher
                (
                    new Data.ProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServico),
                        new Object[]
                        {
                            result.idProdutoServico
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
                sqlInner = "",
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

            Data.ProdutoServico _input = (Data.ProdutoServico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServico.idProdutoServico = @idProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.idProdutoServico));
                    if (!sqlOrderBy.Contains("produtoServico.idProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.idProdutoServico");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.EAN))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServico.EAN = @ean");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("ean", _input.EAN));
                    if (!sqlOrderBy.Contains("produtoServico.ean"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.ean");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServico.descricao COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("produtoServico.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.marcaModelo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServico.marcaModelo COLLATE Latin1_General_CI_AI like @marcaModelo COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("marcaModelo", "%" + _input.marcaModelo + "%"));
                    if (!sqlOrderBy.Contains("produtoServico.marcaModelo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.marcaModelo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.taxaServico))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServico.taxaServico = @taxaServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("taxaServico", _input.taxaServico == "s"));
                    if (!sqlOrderBy.Contains("produtoServico.taxaServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.taxaServico");
                    else { }
                }
                else { }

                if (_input.estocavel)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServico.estocavel = @estocavel");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("estocavel", _input.estocavel));
                    if (!sqlOrderBy.Contains("produtoServico.estocavel"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.estocavel");
                    else { }
                }
                else { }

                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServico.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("produtoServico.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.idDepartamento");
                        else { }
                    }
                    else { }
                }
                else { }

                if
                (
                    (_input.produtoServicoFornecedors != null) &&
                    (_input.produtoServicoFornecedors.Length > 0) &&
                    (_input.produtoServicoFornecedors[0].fornecedor != null)
                )
                {
                    sqlInner +=
                    (
                        " inner join produtoServicoFornecedor" +
                        "  on  produtoServicoFornecedor.idProdutoServico = produtoServico.idProdutoServico and" +
                        "      produtoServicoFornecedor.idFornecedor = " + _input.produtoServicoFornecedors[0].fornecedor.idEmpresaRelacionamento.ToString()
                    );
                }
                else { }

                if
                (
                    (_input.produtoServicoEmpresas != null) &&
                    (_input.produtoServicoEmpresas.Length > 0)

                )
                {

                    if (!String.IsNullOrEmpty(_input.produtoServicoEmpresas[0].aplicarTaxaServico))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServicoEmpresa.aplicarTaxaServico = @aplicarTaxaServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldBoolean("aplicarTaxaServico", _input.produtoServicoEmpresas[0].aplicarTaxaServico == "s"));
                        if (!sqlOrderBy.Contains("produtoServicoEmpresa.aplicarTaxaServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.aplicarTaxaServico");
                        else { }
                    }

                    string sqlInnerEmpresa =
                    (
                        " inner join produtoServicoEmpresa" +
                        "  on  produtoServicoEmpresa.idProdutoServico = produtoServico.idProdutoServico"
                    );

                    if (_input.produtoServicoEmpresas[0].idEmpresa > 0)
                    {
                        sqlInnerEmpresa += (sqlInnerEmpresa.Length > 0 ? " AND " : null) +
                        (
                            " produtoServicoEmpresa.idEmpresa = " + _input.produtoServicoEmpresas[0].idEmpresa.ToString()
                        );
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.produtoServicoEmpresas[0].codigoProduto))
                    {
                        sqlInnerEmpresa += (sqlInnerEmpresa.Length > 0 ? " AND " : null) +
                        (
                            " produtoServicoEmpresa.codigoProduto = '" + _input.produtoServicoEmpresas[0].codigoProduto + "'"
                        );
                    }
                    else { }

                    sqlInner += sqlInnerEmpresa;
                }
                else { }

                if
                (
                    (_input.produtoServicoEstoques != null) &&
                    (_input.produtoServicoEstoques.Length > 0) &&
                    (_input.produtoServicoEstoques[0].idDepartamento > 0)
                )
                {
                    sqlInner +=
                    (
                        " left join produtoServicoEstoque" +
                        "  on  produtoServicoEstoque.idProdutoServico = produtoServico.idProdutoServico and" +
                        "      produtoServicoEstoque.idDepartamento = " + _input.produtoServicoEstoques[0].idDepartamento.ToString()
                    );
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "produtoServico.* ") +
                    "from " +
                    "   produtoServico " +
                    (sqlInner.Length > 0 ? sqlInner : "") +
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
            Data.ProdutoServico input = (Data.ProdutoServico)parametros["Key"];
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
                    typeof(Tables.ProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServico _data in
                    (System.Collections.Generic.List<Tables.ProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServico),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        List<int>
                            idEstoquesRequeridos = new List<int>(),
                            idEstoquesProduto = new List<int>();

                        if (input.produtoServicoEstoques != null && input.produtoServicoEstoques.Length > 0)
                            foreach (Data.ProdutoServicoEstoque item in input.produtoServicoEstoques)
                                idEstoquesRequeridos.Add(item.idDepartamento);
                        else { }

                        if (_data.produtoServicoEstoques != null)
                            foreach (Tables.ProdutoServicoEstoque item in _data.produtoServicoEstoques)
                                idEstoquesProduto.Add(item.idDepartamento.value);
                        else { }

                        List<int> intersect = idEstoquesRequeridos.Intersect(idEstoquesProduto).ToList();

                        if (
                            idEstoquesRequeridos.Count == 0 ||
                            !_data.estocavel.value ||
                            (
                                _data.estocavel.value &&
                                intersect.Count >= 0)
                            )
                        {

                            List<Data.ProdutoServicoEmpresa> listEmpresas = new List<Data.ProdutoServicoEmpresa>();
                            List<Data.ProdutoServicoEstoque> listEstoques = new List<Data.ProdutoServicoEstoque>();
                            _base = new Data.ProdutoServico();
                            ((Data.ProdutoServico)_base).idProdutoServico = _data.idProdutoServico.value;
                            ((Data.ProdutoServico)_base).descricao = _data.descricao.value;
                            ((Data.ProdutoServico)_base).marcaModelo = _data.marcaModelo.value;
                            ((Data.ProdutoServico)_base).cest = _data.cest.value;
                            ((Data.ProdutoServico)_base).extIpi = _data.extIpi.value;
                            ((Data.ProdutoServico)_base).estocavel = _data.estocavel.value;
                            ((Data.ProdutoServico)_base).taxaServico = _data.taxaServico.value ? "s" : "n";
                            ((Data.ProdutoServico)_base).saldo = 0;
                            ((Data.ProdutoServico)_base).EAN = _data.EAN.value;
                            ((Data.ProdutoServico)_base).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.UnidadeProdutoServico(),
                                ((Tables.ProdutoServico)_data).unidadeProdutoServico,
                                level + 1
                            );

                            ((Data.ProdutoServico)_base).ncm = (Data.Ncm)(new WS.CRUD.Ncm(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.Ncm(),
                                ((Tables.ProdutoServico)_data).ncm,
                                level + 1
                            );

                            if (_data.produtoServicoEmpresas != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoEmpresa> _list = new System.Collections.Generic.List<Data.ProdutoServicoEmpresa>();
                                foreach (Tables.ProdutoServicoEmpresa _item in _data.produtoServicoEmpresas)
                                {

                                    double custoUltimaEntrada = 0;
                                    try
                                    {
                                        System.Data.DataTable resultBd = this.m_EntityManager.executeData(String.Format("SELECT dbo.getCustoMedio({0}, {1}, 0)", _item.idProdutoServico.value, _item.idEmpresa.value), null);
                                        custoUltimaEntrada = Convert.ToDouble(resultBd.Rows[0][0]);
                                    }
                                    catch { }

                                    Data.ProdutoServicoEmpresa _key = new Data.ProdutoServicoEmpresa
                                    {
                                        aliquotaIcms = _item.aliquotaIcms.value,
                                        codigoProduto = _item.codigoProduto.value,
                                        custo = _item.custo.value,
                                        custoUltimaEntrada = custoUltimaEntrada,
                                        dataUltimaCompra = _item.dataUltimaCompra.value,
                                        estoqueMaximo = _item.estoqueMaximo.value,
                                        estoqueMinimo = _item.estoqueMinimo.value,
                                        idEmpresa = _item.idEmpresa.value,
                                        idProdutoServico = _item.idProdutoServico.value,
                                        idTipoProdutoServico = _item.tipoProdutoServico.idTipoProdutoServico.value,
                                        preco = _item.preco.value,
                                        quantidade = _item.quantidade.value,
                                        aplicarTaxaServico = _item.aplicarTaxaServico.value ? "s" : "n",
                                        tipoProdutoServico = new Data.TipoProdutoServico
                                        {
                                            idTipoProdutoServico = _item.tipoProdutoServico.idTipoProdutoServico.value,
                                            descricao = _item.tipoProdutoServico.descricao.value,
                                            tipo = _item.tipoProdutoServico.tipo.value
                                        }
                                    };
                                    listEmpresas.Add(_key);
                                    ((Data.ProdutoServico)_base).saldo += _item.quantidade.value;
                                }
                                ((Data.ProdutoServico)_base).produtoServicoEmpresas = listEmpresas.ToArray();
                            }
                            else { }

                            if (_data.produtoServicoEstoques != null)
                            {
                                System.Collections.Generic.List<Data.ProdutoServicoEstoque> _list = new System.Collections.Generic.List<Data.ProdutoServicoEstoque>();
                                foreach (Tables.ProdutoServicoEstoque _item in _data.produtoServicoEstoques)
                                {
                                    Data.ProdutoServicoEstoque _key = new Data.ProdutoServicoEstoque
                                    {
                                        dataFabricacao = _item.dataFabricacao.value,
                                        dataValidade = _item.dataValidade.value,
                                        idDepartamento = _item.idDepartamento.value,
                                        idProdutoServico = _item.idProdutoServico.value,
                                        idProdutoServicoEstoque = _item.idProdutoServicoEstoque.value,
                                        numeroLote = _item.numeroLote.value,
                                        operacao = ENum.eOperacao.NONE,
                                        patrimonio = _item.patrimonio.value,
                                        produtoServico = new Data.ProdutoServico
                                        {
                                            idProdutoServico = _item.produtoServico.idProdutoServico.value,
                                            descricao = _item.produtoServico.descricao.value,
                                            unidadeProdutoServico = new Data.UnidadeProdutoServico
                                            {
                                                idUnidadeProdutoServico = _item.produtoServico.unidadeProdutoServico.idUnidadeProdutoServico.value,
                                                sigla = _item.produtoServico.unidadeProdutoServico.sigla.value,
                                                descricao = _item.produtoServico.unidadeProdutoServico.descricao.value
                                            }
                                        },
                                        quantidade = _item.quantidade.value
                                    };
                                    listEstoques.Add(_key);
                                }
                                ((Data.ProdutoServico)_base).produtoServicoEstoques = listEstoques.ToArray();
                            }
                            else { }
                        }
                        else { }

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ProdutoServico(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else if (_base != null)
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
