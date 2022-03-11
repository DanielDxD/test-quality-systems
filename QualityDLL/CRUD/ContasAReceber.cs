using System;

namespace WS.CRUD
{
    public class ContasAReceber : WS.CRUD.Base
    {
        public ContasAReceber(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceber input = (Data.ContasAReceber)parametros["Key"];
            Tables.ContasAReceber bd = new Tables.ContasAReceber();

            bd.idContasAReceber.isNull = true;
            /*if(input.pessoa != null)
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else
                bd.pessoa.idPessoa.value = input.empresaRelacionamento.pessoa.idPessoa;
                */

            bd.dataLancamento.value = input.dataLancamento;
            bd.dataVencimento.value = input.dataVencimento;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.desconto.value = input.desconto;
            bd.idEmpresa.value = input.idEmpresa;
            bd.parcela.value = input.parcela;

            if (!String.IsNullOrEmpty(input.emAberto))
                bd.emAberto.value = input.emAberto.ToLower() == "s" || input.emAberto == "1";
            else { }

            if (input.dataLancamentoEfetivo.Ticks > 0)
                bd.dataLancamentoEfetivo.value = input.dataLancamentoEfetivo;
            else
                bd.dataLancamentoEfetivo.isNull = true;

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }

            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }
            if (String.IsNullOrEmpty(input.numeroDocumento))
                bd.numeroDocumento.isNull = true;
            else
                bd.numeroDocumento.value = input.numeroDocumento;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAReceber)parametros["Key"]).idContasAReceber = (int)bd.idContasAReceber.value;

            //Processa BoletoItem
            if (input.boletoItems != null)
            {
                WS.CRUD.BoletoItem boletoItemCRUD = new WS.CRUD.BoletoItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.boletoItems.Length; i++)
                {
                    input.boletoItems[i].contasAReceber = new Data.ContasAReceber();
                    input.boletoItems[i].contasAReceber.idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.boletoItems[i]);
                    boletoItemCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                boletoItemCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa CaixaMovimentoLancamento
            if (input.caixaMovimentoLancamentos != null)
            {
                WS.CRUD.CaixaMovimentoLancamento caixaMovimentoLancamentoCRUD = new WS.CRUD.CaixaMovimentoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentoLancamentos.Length; i++)
                {
                    input.caixaMovimentoLancamentos[i].contasAReceber = new Data.ContasAReceber();
                    input.caixaMovimentoLancamentos[i].contasAReceber.idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.caixaMovimentoLancamentos[i]);
                    caixaMovimentoLancamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                caixaMovimentoLancamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ContasAReceberPagamento
            if (!input.ignorarBaixa && input.contasAReceberPagamentos != null)
            {
                WS.CRUD.ContasAReceberPagamento contasAReceberPagamentoCRUD = new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberPagamentos.Length; i++)
                {
                    input.contasAReceberPagamentos[i].idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.contasAReceberPagamentos[i]);
                    contasAReceberPagamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                contasAReceberPagamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa NotaFiscalSItem
            if (input.notaFiscalSItems != null)
            {
                WS.CRUD.NotaFiscalSItem notaFiscalSItemCRUD = new WS.CRUD.NotaFiscalSItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.notaFiscalSItems.Length; i++)
                {
                    input.notaFiscalSItems[i].contasAReceber = new Data.ContasAReceber();
                    input.notaFiscalSItems[i].contasAReceber.idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.notaFiscalSItems[i]);
                    notaFiscalSItemCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                notaFiscalSItemCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.contasAReceberItems != null)
            {
                WS.CRUD.ContasAReceberItem contasAReceberItemCRUD = new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberItems.Length; i++)
                {
                    input.contasAReceberItems[i].idContasAReceber = new Data.ContasAReceber { idContasAReceber = bd.idContasAReceber.value };
                    _parameters.Add("Key", input.contasAReceberItems[i]);
                    contasAReceberItemCRUD.atualizar(_parameters);
                    if (input.contasAReceberItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAReceberItems[i] = (Data.ContasAReceberItem)contasAReceberItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                contasAReceberItemCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceber input = (Data.ContasAReceber)parametros["Key"];
            Tables.ContasAReceber bd = (Tables.ContasAReceber)this.m_EntityManager.find
            (
                typeof(Tables.ContasAReceber),
                new Object[]
                {
                    input.idContasAReceber
                }
            );

            /*if (input.pessoa != null)
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else
                bd.pessoa.idPessoa.value = input.empresaRelacionamento.pessoa.idPessoa;
                */
            bd.dataLancamento.value = input.dataLancamento;
            bd.dataVencimento.value = input.dataVencimento;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.desconto.value = input.desconto;
            bd.idEmpresa.value = input.idEmpresa;
            bd.parcela.value = input.parcela;
            bd.valorRecebido.value = input.valorRecebido;

            if (!String.IsNullOrEmpty(input.emAberto))
                bd.emAberto.value = input.emAberto.ToLower() == "s" || input.emAberto == "1";
            else { }

            if (input.dataLancamentoEfetivo.Ticks > 0)
                bd.dataLancamentoEfetivo.value = input.dataLancamentoEfetivo;
            else
                bd.dataLancamentoEfetivo.isNull = true;

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            if (String.IsNullOrEmpty(input.numeroDocumento))
                bd.numeroDocumento.isNull = true;
            else
                bd.numeroDocumento.value = input.numeroDocumento;

            this.m_EntityManager.merge(bd);

            if (input.contasAReceberItems != null)
            {
                WS.CRUD.ContasAReceberItem contasAReceberItemCRUD = new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberItems.Length; i++)
                {
                    input.contasAReceberItems[i].idContasAReceber = new Data.ContasAReceber { idContasAReceber = bd.idContasAReceber.value };
                    _parameters.Add("Key", input.contasAReceberItems[i]);
                    if (input.contasAReceberItems[i].operacao == ENum.eOperacao.NONE)
                        input.contasAReceberItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contasAReceberItemCRUD.atualizar(_parameters);
                    if (input.contasAReceberItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAReceberItems[i] = (Data.ContasAReceberItem)contasAReceberItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                contasAReceberItemCRUD = null;
            }

            //Processa BoletoItem
            if (input.boletoItems != null)
            {
                WS.CRUD.BoletoItem boletoItemCRUD = new WS.CRUD.BoletoItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.boletoItems.Length; i++)
                {
                    input.boletoItems[i].contasAReceber = new Data.ContasAReceber();
                    input.boletoItems[i].contasAReceber.idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.boletoItems[i]);
                    if (input.boletoItems[i].operacao == ENum.eOperacao.NONE)
                        input.boletoItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    boletoItemCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                boletoItemCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa CaixaMovimentoLancamento
            if (input.caixaMovimentoLancamentos != null)
            {
                WS.CRUD.CaixaMovimentoLancamento caixaMovimentoLancamentoCRUD = new WS.CRUD.CaixaMovimentoLancamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentoLancamentos.Length; i++)
                {
                    input.caixaMovimentoLancamentos[i].contasAReceber = new Data.ContasAReceber();
                    input.caixaMovimentoLancamentos[i].contasAReceber.idContasAReceber = bd.idContasAReceber.value;
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

            //Processa ContasAReceberPagamento
            if (!input.ignorarBaixa && input.contasAReceberPagamentos != null)
            {
                WS.CRUD.ContasAReceberPagamento contasAReceberPagamentoCRUD = new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberPagamentos.Length; i++)
                {
                    input.contasAReceberPagamentos[i].idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.contasAReceberPagamentos[i]);
                    if (input.contasAReceberPagamentos[i].operacao == ENum.eOperacao.NONE)
                        input.contasAReceberPagamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contasAReceberPagamentoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                contasAReceberPagamentoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa NotaFiscalSItem
            if (input.notaFiscalSItems != null)
            {
                WS.CRUD.NotaFiscalSItem notaFiscalSItemCRUD = new WS.CRUD.NotaFiscalSItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.notaFiscalSItems.Length; i++)
                {
                    input.notaFiscalSItems[i].contasAReceber = new Data.ContasAReceber();
                    input.notaFiscalSItems[i].contasAReceber.idContasAReceber = bd.idContasAReceber.value;
                    _parameters.Add("Key", input.notaFiscalSItems[i]);
                    if (input.notaFiscalSItems[i].operacao == ENum.eOperacao.NONE)
                        input.notaFiscalSItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    notaFiscalSItemCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                notaFiscalSItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAReceber bd = new Tables.ContasAReceber();

            bd.idContasAReceber.value = ((Data.ContasAReceber)parametros["Key"]).idContasAReceber;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAReceber)bd).idContasAReceber.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAReceber)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAReceber)input).idContasAReceber = ((Tables.ContasAReceber)bd).idContasAReceber.value;
                    ((Data.ContasAReceber)input).numeroDocumento = ((Tables.ContasAReceber)bd).numeroDocumento.value;
                    /*if (((Tables.ContasAReceber)bd).pessoa.pfpj.value == "F")
                        ((Data.ContasAReceber)input).pessoa = (Data.Pessoa)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PessoaFisica(),
                            this.m_EntityManager.find(typeof(Tables.PessoaFisica), new object[]{((Tables.ContasAReceber)bd).pessoa.idPessoa.value }),
                            level + 1
                        );
                    else
                        ((Data.ContasAReceber)input).pessoa = (Data.Pessoa)(new WS.CRUD.PessoaJuridica(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PessoaJuridica(),
                            this.m_EntityManager.find(typeof(Tables.PessoaJuridica), new object[] { ((Tables.ContasAReceber)bd).pessoa.idPessoa.value }),
                            level + 1
                        );*/


                    ((Data.ContasAReceber)input).dataLancamento = ((Tables.ContasAReceber)bd).dataLancamento.value;
                    ((Data.ContasAReceber)input).dataCancelamento = ((Tables.ContasAReceber)bd).dataCancelamento.value;
                    ((Data.ContasAReceber)input).dataLancamentoEfetivo = ((Tables.ContasAReceber)bd).dataLancamentoEfetivo.value;
                    ((Data.ContasAReceber)input).dataVencimento = ((Tables.ContasAReceber)bd).dataVencimento.value;
                    ((Data.ContasAReceber)input).descricao = ((Tables.ContasAReceber)bd).descricao.value;
                    ((Data.ContasAReceber)input).valor = ((Tables.ContasAReceber)bd).valor.value;
                    ((Data.ContasAReceber)input).iss = ((Tables.ContasAReceber)bd).iss.value;
                    ((Data.ContasAReceber)input).desconto = ((Tables.ContasAReceber)bd).desconto.value;
                    ((Data.ContasAReceber)input).parcela = ((Tables.ContasAReceber)bd).parcela.value;
                    if (!((Tables.ContasAReceber)bd).valorRecebido.isNull)
                    {
                        ((Data.ContasAReceber)input).valorRecebido = ((Tables.ContasAReceber)bd).valorRecebido.value;
                        ((Data.ContasAReceber)input).dataUltimoRecebimento = ((Tables.ContasAReceber)bd).dataUltimoRecebimento.value;
                    }
                    else { }
                    ((Data.ContasAReceber)input).emAberto = ((Tables.ContasAReceber)bd).emAberto.value ? "S" : "N";

                    ((Data.ContasAReceber)input).idEmpresa = ((Tables.ContasAReceber)bd).idEmpresa.value;
                    ((Data.ContasAReceber)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.ContasAReceber)bd).tipoMovimentoContabil,
                        level + 1
                    );

                    /*switch(((Tables.ContasAReceber)bd).empresaRelacionamento.tipoRelacionamentoEmpresa.tipo.value)
                    {
                        case "EC":*/
                    ((Data.ContasAReceber)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                     (
                         new Data.EmpresaRelacionamento(),
                         ((Tables.ContasAReceber)bd).empresaRelacionamento,
                         level + 1
                     );/*
                        break;
                        
                        case "EF":
                        ((Data.ContasAReceber)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                         (
                             new Data.Fornecedor(),
                             ((Tables.ContasAReceber)bd).empresaRelacionamento,
                             level + 1
                         );
                        break;

                        case "ST":
                        ((Data.ContasAReceber)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                         (
                             new Data.TituloSocio(),
                             ((Tables.ContasAReceber)bd).empresaRelacionamento,
                             level + 1
                         );
                        break;
                    }*/
                }
                else { }


                if (level < 1)
                {
                    //Preencher ContasAReceberItem
                    if (((Tables.ContasAReceber)bd).contasAReceberItems != null)
                    {
                        System.Collections.Generic.List<Data.ContasAReceberItem> _list = new System.Collections.Generic.List<Data.ContasAReceberItem>();

                        foreach (Tables.ContasAReceberItem _item in ((Tables.ContasAReceber)bd).contasAReceberItems)
                        {
                            _list.Add
                            (
                                (Data.ContasAReceberItem)
                                (new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.ContasAReceberItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ContasAReceber)input).contasAReceberItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ContasAReceber)input).contasAReceberItems != null)
                        {
                            System.Collections.Generic.List<Data.ContasAReceberItem> _list = new System.Collections.Generic.List<Data.ContasAReceberItem>();

                            foreach (Data.ContasAReceberItem _item in ((Data.ContasAReceber)input).contasAReceberItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ContasAReceber)input).contasAReceberItems = _list.ToArray();
                            else
                                ((Data.ContasAReceber)input).contasAReceberItems = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }


                if (level < 1)
                {
                    //Preencher BoletoItems
                    if (((Tables.ContasAReceber)bd).boletoItems != null)
                    {
                        System.Collections.Generic.List<Data.BoletoItem> _list = new System.Collections.Generic.List<Data.BoletoItem>();

                        foreach (Tables.BoletoItem _item in ((Tables.ContasAReceber)bd).boletoItems)
                        {
                            _list.Add
                            (
                                (Data.BoletoItem)
                                (new WS.CRUD.BoletoItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.BoletoItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ContasAReceber)input).boletoItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ContasAReceber)input).boletoItems != null)
                        {
                            System.Collections.Generic.List<Data.BoletoItem> _list = new System.Collections.Generic.List<Data.BoletoItem>();

                            foreach (Data.BoletoItem _item in ((Data.ContasAReceber)input).boletoItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ContasAReceber)input).boletoItems = _list.ToArray();
                            else
                                ((Data.ContasAReceber)input).boletoItems = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher CaixaMovimentoLancamentos
                    if (((Tables.ContasAReceber)bd).caixaMovimentoLancamentos != null)
                    {
                        System.Collections.Generic.List<Data.CaixaMovimentoLancamento> _list = new System.Collections.Generic.List<Data.CaixaMovimentoLancamento>();

                        foreach (Tables.CaixaMovimentoLancamento _item in ((Tables.ContasAReceber)bd).caixaMovimentoLancamentos)
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

                        ((Data.ContasAReceber)input).caixaMovimentoLancamentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ContasAReceber)input).caixaMovimentoLancamentos != null)
                        {
                            System.Collections.Generic.List<Data.CaixaMovimentoLancamento> _list = new System.Collections.Generic.List<Data.CaixaMovimentoLancamento>();

                            foreach (Data.CaixaMovimentoLancamento _item in ((Data.ContasAReceber)input).caixaMovimentoLancamentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ContasAReceber)input).caixaMovimentoLancamentos = _list.ToArray();
                            else
                                ((Data.ContasAReceber)input).caixaMovimentoLancamentos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher ContasAReceberPagamentos
                    if (((Tables.ContasAReceber)bd).contasAReceberPagamentos != null)
                    {
                        System.Collections.Generic.List<Data.ContasAReceberPagamento> _list = new System.Collections.Generic.List<Data.ContasAReceberPagamento>();

                        foreach (Tables.ContasAReceberPagamento _item in ((Tables.ContasAReceber)bd).contasAReceberPagamentos)
                        {
                            _list.Add
                            (
                                (Data.ContasAReceberPagamento)
                                (new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.ContasAReceberPagamento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ContasAReceber)input).contasAReceberPagamentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ContasAReceber)input).contasAReceberPagamentos != null)
                        {
                            System.Collections.Generic.List<Data.ContasAReceberPagamento> _list = new System.Collections.Generic.List<Data.ContasAReceberPagamento>();

                            foreach (Data.ContasAReceberPagamento _item in ((Data.ContasAReceber)input).contasAReceberPagamentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ContasAReceber)input).contasAReceberPagamentos = _list.ToArray();
                            else
                                ((Data.ContasAReceber)input).contasAReceberPagamentos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher NotaFiscalSItems
                    if (((Tables.ContasAReceber)bd).notaFiscalSItems != null)
                    {
                        System.Collections.Generic.List<Data.NotaFiscalSItem> _list = new System.Collections.Generic.List<Data.NotaFiscalSItem>();

                        foreach (Tables.NotaFiscalSItem _item in ((Tables.ContasAReceber)bd).notaFiscalSItems)
                        {
                            _list.Add
                            (
                                (Data.NotaFiscalSItem)
                                (new WS.CRUD.NotaFiscalSItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.NotaFiscalSItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ContasAReceber)input).notaFiscalSItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ContasAReceber)input).notaFiscalSItems != null)
                        {
                            System.Collections.Generic.List<Data.NotaFiscalSItem> _list = new System.Collections.Generic.List<Data.NotaFiscalSItem>();

                            foreach (Data.NotaFiscalSItem _item in ((Data.ContasAReceber)input).notaFiscalSItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ContasAReceber)input).notaFiscalSItems = _list.ToArray();
                            else
                                ((Data.ContasAReceber)input).notaFiscalSItems = null;

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
            Data.ContasAReceber result = (Data.ContasAReceber)parametros["Key"];

            try
            {
                result = (Data.ContasAReceber)this.preencher
                (
                    new Data.ContasAReceber(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceber),
                        new Object[]
                        {
                            result.idContasAReceber
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

            Data.ContasAReceber _input = (Data.ContasAReceber)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAReceber > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.idContasAReceber = @idContasAReceber");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", _input.idContasAReceber));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.idContasAReceber");
                }
                else { }

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.idEmpresa");
                }
                else { }

                if (_input.valor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.valor = @valor");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valor", _input.valor));
                    if (!sqlOrderBy.Contains("contasAReceber.valor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.valor");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.emAberto))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.emAberto = @emAberto");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("emAberto", _input.emAberto.ToUpper() == "S"));
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroDocumento))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.numeroDocumento = @numeroDocumento");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroDocumento", _input.numeroDocumento));
                }
                else { }

                if (_input.empresaRelacionamento != null)
                {
                    if ((_input.empresaRelacionamento.idEmpresa > 0) && (_input.idEmpresa == 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.empresaRelacionamento.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.empresaRelacionamento.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.pessoa != null)
                    {
                        if ((_input.empresaRelacionamento.pessoa != null) && (_input.empresaRelacionamento.pessoa.idPessoa > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.empresaRelacionamento.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if ((_input.empresaRelacionamento.pessoa.cpfCnpj != null) && (_input.empresaRelacionamento.pessoa.cpfCnpj.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.empresaRelacionamento.pessoa.cpfCnpj + '%'));
                            if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                            else { }
                        }
                        else { }

                        if ((_input.empresaRelacionamento.pessoa.nomeRazaoSocial != null) && (_input.empresaRelacionamento.pessoa.nomeRazaoSocial.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.empresaRelacionamento.pessoa.nomeRazaoSocial + '%'));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }


                /*if (_input.pessoa != null)
                {
                    if ((_input.pessoa != null) && (_input.pessoa.idPessoa > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.pessoa.idPessoa));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                    }
                    else { }

                    if ((_input.pessoa.cpfCnpj != null) && (_input.pessoa.cpfCnpj.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.pessoa.cpfCnpj + '%'));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                    }
                    else { }

                    if ((_input.pessoa.nomeRazaoSocial != null) && (_input.pessoa.nomeRazaoSocial.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.pessoa.nomeRazaoSocial + '%'));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                    }
                    else { }
                }
                else { }*/

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contasAReceber.* ") +
                    "from " +
                    (
                        "   contasAReceber contasAReceber " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on empresaRelacionamento.idEmpresaRelacionamento = contasAReceber.idEmpresaRelacionamento" +
                        "       LEFT join pessoa pessoa " +
                        "           on pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                        "       left join " +
                        "       ( " +
                        "           select " +
                        "               idContasAReceber, " +
                        "               MAX(idDocumentoRecebimento) idDocumentoRecebimentoContas " +
                        "           from " +
                        "               documentoRecebimentoContasAReceber " +
                        "           group by " +
                        "               idContasAReceber " +
                        "       ) documentoRecebimentoContasAReceber " +
                        "           on	documentoRecebimentoContasAReceber.idContasAReceber = contasAReceber.idContasAReceber "
                    ) +
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
            Data.ContasAReceber input = (Data.ContasAReceber)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);
            bool telaSocio = (bool)(parametros["TelaSocio"] == null ? false : parametros["TelaSocio"]);

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
                    typeof(Tables.ContasAReceber),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAReceber _data in
                    (System.Collections.Generic.List<Tables.ContasAReceber>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAReceber),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.ContasAReceber();

                        ((Data.ContasAReceber)_base).idContasAReceber = _data.idContasAReceber.value;
                        ((Data.ContasAReceber)_base).idEmpresa = _data.idEmpresa.value;
                        ((Data.ContasAReceber)_base).empresaRelacionamento = new Data.EmpresaRelacionamento { idEmpresaRelacionamento = _data.empresaRelacionamento.idEmpresaRelacionamento.value, pessoa = new Data.Pessoa { nomeRazaoSocial = _data.empresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };
                        ((Data.ContasAReceber)_base).valor = _data.valor.value;
                        ((Data.ContasAReceber)_base).desconto = (_data.desconto.isNull ? 0.0 : _data.desconto.value);
                        ((Data.ContasAReceber)_base).valorRecebido = (_data.valorRecebido.isNull ? 0.0 : _data.valorRecebido.value);
                        ((Data.ContasAReceber)_base).dataVencimento = _data.dataVencimento.value;
                        ((Data.ContasAReceber)_base).parcela = _data.parcela.value;
                        ((Data.ContasAReceber)_base).numeroDocumento = _data.numeroDocumento.value;
                        ((Data.ContasAReceber)_base).descricao = _data.descricao.value;
                        ((Data.ContasAReceber)_base).emAberto = _data.emAberto.value ? "s" : "n";
                        ((Data.ContasAReceber)_base).dataCancelamento = _data.dataCancelamento.value;
                        ((Data.ContasAReceber)_base).dataLancamento = _data.dataLancamento.value;
                        ((Data.ContasAReceber)_base).dataUltimoRecebimento = _data.dataUltimoRecebimento.value;


                        if (telaSocio)
                        {
                            if (_data.contasAReceberItems != null)
                            {
                                System.Collections.Generic.List<Data.ContasAReceberItem> _list = new System.Collections.Generic.List<Data.ContasAReceberItem>();

                                foreach (Tables.ContasAReceberItem _item in _data.contasAReceberItems)
                                {
                                    _list.Add
                                    (
                                        (Data.ContasAReceberItem)
                                        (new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                        (
                                            new Data.ContasAReceberItem(),
                                            _item,
                                            level + 1
                                        )
                                    );
                                }

                                ((Data.ContasAReceber)_base).contasAReceberItems = _list.ToArray();
                                _list.Clear();
                                _list = null;
                            }
                        }
                        else { }

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContasAReceber(), _data, level);

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
