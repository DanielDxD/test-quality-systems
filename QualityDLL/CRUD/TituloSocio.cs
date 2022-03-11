using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace WS.CRUD
{
    public class TituloSocio : WS.CRUD.Base
    {
        public TituloSocio(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloSocio input = (Data.TituloSocio)parametros["Key"];
            Tables.TituloSocio bd =
            (
                parametros["Return"] != null ?
                (Tables.TituloSocio)parametros["Return"] :
                new Tables.TituloSocio()
            );

            //Incluir/Alterar EmpresaRelacionamento
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.titularEmpresaRelacionamento);
                _parametros.Add("Return", bd.titularEmpresaRelacionamento);

                input.titularEmpresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            //Incluir/Alterar Titulo
            {
                input.titulo.idEmpresa = input.titularEmpresaRelacionamento.idEmpresa;

                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.titulo);
                _parametros.Add("Return", bd.titulo);

                input.titulo = (Data.Titulo)(new WS.CRUD.Titulo(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.idTituloSocio.isNull = true;

            if (input.titulo != null)
                bd.titulo.idTitulo.value = input.titulo.idTitulo;
            else { }

            if (input.categoriaTitulo != null)
                bd.categoriaTitulo.idCategoriaTitulo.value = input.categoriaTitulo.idCategoriaTitulo;
            else { }
            bd.dataContrato.value = input.dataContrato;

            bd.dataInicioTitulo.value = input.dataInicioTitulo;
            bd.dataFimTitulo.value = input.dataFimTitulo;
            bd.dataCadastramento.value = input.dataCadastramento;
            bd.usuarioCadastramento.value = input.usuarioCadastramento;
            bd.dataAlteracao.value = input.dataAlteracao;
            bd.usuarioAlteracao.value = input.usuarioAlteracao;
            bd.agencia.value = input.agencia;
            bd.conta.value = input.conta;

            if (input.banco != null && input.banco.idBanco > 0)
                bd.banco.idBanco.value = input.banco.idBanco;
            else
                bd.banco.idBanco.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.TituloSocio)parametros["Key"]).idTituloSocio = (int)bd.idTituloSocio.value;

            if (input.dependente)
            {

                Data.TituloSocioDependente tsd = new Data.TituloSocioDependente();
                Tables.TituloSocioDependente ttsd = new Tables.TituloSocioDependente();
                tsd.tituloSocio = input;
                tsd.tipoRelacionamento = input.tipoRelacionamento;
                tsd.operacao = ENum.eOperacao.INCLUIR;

                {
                    System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                    _parametros.Add("Key", tsd);
                    _parametros.Add("Return", ttsd);

                    tsd = (Data.TituloSocioDependente)(new WS.CRUD.TituloSocioDependente(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                    _parametros.Clear();
                    _parametros = null;
                    tsd = null;
                    ttsd = null;
                }
            }
            else { }

            //Processa TituloSocioLancamentoContabil
            if (input.tituloSocioLancamentoContabils != null)
            {
                WS.CRUD.TituloSocioLancamentoContabil tituloSocioLancamentoContabilCRUD = new WS.CRUD.TituloSocioLancamentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocioLancamentoContabils.Length; i++)
                {
                    input.tituloSocioLancamentoContabils[i].tituloSocio = new Data.TituloSocio();
                    input.tituloSocioLancamentoContabils[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.tituloSocioLancamentoContabils[i]);
                    tituloSocioLancamentoContabilCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioLancamentoContabilCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa Convite
            if (input.convite != null)
            {
                WS.CRUD.Convite conviteCRUD = new WS.CRUD.Convite(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.convite.Length; i++)
                {
                    input.convite[i].tituloSocio = new Data.TituloSocio();
                    input.convite[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.convite[i]);
                    conviteCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                conviteCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.tituloSocioSituacao != null)
            {
                WS.CRUD.TituloSocioSituacao tituloSocioSituacaoCRUD = new WS.CRUD.TituloSocioSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocioSituacao.Length; i++)
                {
                    input.tituloSocioSituacao[i].tituloSocio = new Data.TituloSocio();
                    input.tituloSocioSituacao[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.tituloSocioSituacao[i]);
                    tituloSocioSituacaoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioSituacaoCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.tituloSocioVinculo != null)
            {
                WS.CRUD.TituloSocioVinculo tituloSocioVinculoCRUD = new WS.CRUD.TituloSocioVinculo(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocioVinculo.Length; i++)
                {
                    input.tituloSocioVinculo[i].tituloSocio = new Data.TituloSocio();
                    input.tituloSocioVinculo[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.tituloSocioVinculo[i]);
                    tituloSocioVinculoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioVinculoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {

            Data.TituloSocio input = (Data.TituloSocio)parametros["Key"];
            Tables.TituloSocio bd = (Tables.TituloSocio)this.m_EntityManager.find
            (
                typeof(Tables.TituloSocio),
                new Object[]
                {
                    input.idTituloSocio
                }
            );

            //Incluir/Alterar EmpresaRelacionamento
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.titularEmpresaRelacionamento);
                _parametros.Add("Return", bd.titularEmpresaRelacionamento);

                input.titularEmpresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            if (input.titulo != null && input.titulo.idTitulo > 0)
                bd.titulo.idTitulo.value = input.titulo.idTitulo;
            else { }

            if (input.titularEmpresaRelacionamento != null && input.titularEmpresaRelacionamento.idEmpresaRelacionamento > 0)
                bd.titularEmpresaRelacionamento.idEmpresaRelacionamento.value = input.titularEmpresaRelacionamento.idEmpresaRelacionamento;
            else { }

            if (input.categoriaTitulo != null)
                bd.categoriaTitulo.idCategoriaTitulo.value = input.categoriaTitulo.idCategoriaTitulo;
            else { }
            bd.dataContrato.value = input.dataContrato;

            bd.dataInicioTitulo.value = input.dataInicioTitulo;
            bd.dataFimTitulo.value = input.dataFimTitulo;
            bd.dataCadastramento.value = input.dataCadastramento;
            bd.usuarioCadastramento.value = input.usuarioCadastramento;
            bd.dataAlteracao.value = input.dataAlteracao;
            bd.usuarioAlteracao.value = input.usuarioAlteracao;
            bd.agencia.value = input.agencia;
            bd.conta.value = input.conta;

            if (input.banco != null && input.banco.idBanco > 0)
                bd.banco.idBanco.value = input.banco.idBanco;
            else
                bd.banco.idBanco.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa TituloSocioLancamentoContabil
            if (input.contasAReceber != null)
            {
                WS.CRUD.ContasAReceber contasAReceberCRUD = new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceber.Length; i++)
                {
                    _parameters.Add("Key", input.contasAReceber[i]);
                    if (input.contasAReceber[i].operacao == ENum.eOperacao.NONE)
                        input.contasAReceber[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contasAReceberCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                contasAReceberCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa convite
            if (input.convite != null)
            {
                WS.CRUD.Convite conviteCRUD = new WS.CRUD.Convite(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.convite.Length; i++)
                {
                    input.convite[i].tituloSocio = new Data.TituloSocio();
                    input.convite[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.convite[i]);
                    if (input.convite[i].operacao == ENum.eOperacao.NONE)
                        input.convite[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    conviteCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                conviteCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.tituloSocioSituacao != null)
            {
                WS.CRUD.TituloSocioSituacao tituloSocioSituacaoCRUD = new WS.CRUD.TituloSocioSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocioSituacao.Length; i++)
                {
                    input.tituloSocioSituacao[i].tituloSocio = new Data.TituloSocio();
                    input.tituloSocioSituacao[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.tituloSocioSituacao[i]);
                    if (input.tituloSocioSituacao[i].operacao == ENum.eOperacao.NONE)
                        input.tituloSocioSituacao[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloSocioSituacaoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioSituacaoCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.tituloSocioVinculo != null)
            {
                WS.CRUD.TituloSocioVinculo tituloSocioVinculoCRUD = new WS.CRUD.TituloSocioVinculo(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocioVinculo.Length; i++)
                {
                    input.tituloSocioVinculo[i].tituloSocio = new Data.TituloSocio();
                    input.tituloSocioVinculo[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.tituloSocioVinculo[i]);
                    if (input.tituloSocioVinculo[i].operacao == ENum.eOperacao.NONE)
                        input.tituloSocioVinculo[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloSocioVinculoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioVinculoCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.tituloSocioLancamentoContabils != null)
            {
                WS.CRUD.TituloSocioLancamentoContabil tituloSocioLancamentoContabilCRUD = new WS.CRUD.TituloSocioLancamentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocioLancamentoContabils.Length; i++)
                {
                    input.tituloSocioLancamentoContabils[i].tituloSocio = new Data.TituloSocio();
                    input.tituloSocioLancamentoContabils[i].tituloSocio.idTituloSocio = bd.idTituloSocio.value;
                    _parameters.Add("Key", input.tituloSocioLancamentoContabils[i]);
                    if (input.tituloSocioLancamentoContabils[i].operacao == ENum.eOperacao.NONE)
                        input.tituloSocioLancamentoContabils[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloSocioLancamentoContabilCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioLancamentoContabilCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloSocio bd = new Tables.TituloSocio();

            bd.idTituloSocio.value = ((Data.TituloSocio)parametros["Key"]).idTituloSocio;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloSocio)bd).idTituloSocio.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloSocio)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloSocio)input).idTituloSocio = ((Tables.TituloSocio)bd).idTituloSocio.value;
                    ((Data.TituloSocio)input).titulo = (Data.Titulo)(new WS.CRUD.Titulo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Titulo(),
                        ((Tables.TituloSocio)bd).titulo,
                        level + 1
                    );
                    ((Data.TituloSocio)input).titularEmpresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.TituloSocio)bd).titularEmpresaRelacionamento,
                        level + 1
                    );
                    ((Data.TituloSocio)input).categoriaTitulo = (Data.CategoriaTitulo)(new WS.CRUD.CategoriaTitulo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CategoriaTitulo(),
                        ((Tables.TituloSocio)bd).categoriaTitulo,
                        level + 1
                    );
                    ((Data.TituloSocio)input).banco = (Data.Banco)(new WS.CRUD.Banco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Banco(),
                        ((Tables.TituloSocio)bd).banco,
                        level + 1
                    );
                    ((Data.TituloSocio)input).dataContrato = ((Tables.TituloSocio)bd).dataContrato.value;
                    ((Data.TituloSocio)input).dataInicioTitulo = ((Tables.TituloSocio)bd).dataInicioTitulo.value;
                    ((Data.TituloSocio)input).dataFimTitulo = ((Tables.TituloSocio)bd).dataFimTitulo.value;
                    ((Data.TituloSocio)input).dataCadastramento = ((Tables.TituloSocio)bd).dataCadastramento.value;
                    ((Data.TituloSocio)input).usuarioCadastramento = ((Tables.TituloSocio)bd).usuarioCadastramento.value;
                    ((Data.TituloSocio)input).dataAlteracao = ((Tables.TituloSocio)bd).dataAlteracao.value;
                    ((Data.TituloSocio)input).usuarioAlteracao = ((Tables.TituloSocio)bd).usuarioAlteracao.value;
                    ((Data.TituloSocio)input).dependente = ((Tables.TituloSocio)bd).titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo.value == "SD";
                    ((Data.TituloSocio)input).tipo = ((Tables.TituloSocio)bd).titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.descricao.value;
                    ((Data.TituloSocio)input).agencia = ((Tables.TituloSocio)bd).agencia.value;
                    ((Data.TituloSocio)input).conta = ((Tables.TituloSocio)bd).conta.value;
                    ((Data.TituloSocio)input).ativo =
                        (
                            ((Tables.TituloSocio)bd).dataFimTitulo.value.Ticks == 0 ||
                            (
                                ((Tables.TituloSocio)bd).dataFimTitulo.value.Ticks > 0 &&
                                (((Tables.TituloSocio)bd).dataFimTitulo.value.Date - DateTime.Now.Date).Days > 0
                            ) &&
                            ((Tables.TituloSocio)bd).titularEmpresaRelacionamento.dataTermino.value.Ticks == 0 ||
                            (
                                ((Tables.TituloSocio)bd).titularEmpresaRelacionamento.dataTermino.value.Ticks > 0 &&
                                (((Tables.TituloSocio)bd).titularEmpresaRelacionamento.dataTermino.value.Date - DateTime.Now.Date).Days > 0
                            )
                        );
                }
                else { }

                if (level < 1)
                {


                    if (((Data.TituloSocio)input).dependente)
                    {
                        List<NameValue> _params = new List<NameValue>
                        {
                            new NameValue{name = "Mode", value = "Roll" }
                        };
                        Data.TituloSocio key = new Data.TituloSocio
                        {
                            titularEmpresaRelacionamento = new Data.EmpresaRelacionamento
                            {
                                idEmpresaRelacionamento = ((Data.TituloSocio)input).titularEmpresaRelacionamento.pessoaRelacionadaEmpresa.idEmpresaRelacionamento
                            }
                        };
                        try
                        {
                            Data.TituloSocioDependente dep = new Data.TituloSocioDependente
                            {
                                tituloSocio = new Data.TituloSocio
                                {
                                    idTituloSocio = ((Data.TituloSocio)input).idTituloSocio
                                }
                            };
                            try
                            {
                                dep = (Data.TituloSocioDependente)Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, dep, 1, _params)[0];
                                ((Data.TituloSocio)input).tipoRelacionamento = new Data.TipoRelacionamento
                                {
                                    idTipoRelacionamento = dep.tipoRelacionamento.idTipoRelacionamento,
                                    descricao = dep.tipoRelacionamento.descricao
                                };
                            }
                            catch { }

                            ((Data.TituloSocio)input).titular = (Data.TituloSocio)Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, key, 1, _params)[0];
                            ((Data.TituloSocio)input).titular.titularEmpresaRelacionamento.pessoa = (Data.Pessoa)Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, ((Data.TituloSocio)input).titular.titularEmpresaRelacionamento.pessoa, 1, null)[0];
                        }
                        catch { }
                    }

                    /* Listando Dependentes */
                    ((Data.TituloSocio)input).dependentes = null;
                    List<Data.Base> result = new List<Data.Base>();
                    List<Data.TituloSocioDependente> listDep = new List<Data.TituloSocioDependente>();
                    result.AddRange(Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, new Data.TituloSocioDependente { tituloSocio = new Data.TituloSocio { titularEmpresaRelacionamento = new Data.EmpresaRelacionamento { pessoaRelacionadaEmpresa = new Data.EmpresaRelacionamento { idEmpresaRelacionamento = ((Data.TituloSocio)input).titularEmpresaRelacionamento.idEmpresaRelacionamento } } } }, 0));
                    if (result != null)
                        foreach (Data.TituloSocioDependente tsd in result)
                            listDep.Add(tsd);
                    else { }
                    ((Data.TituloSocio)input).dependentes = listDep.ToArray();

                    /* Pegando sócio pai caso houver */
                    {
                        Data.TituloSocioVinculo tsv = new Data.TituloSocioVinculo
                        {
                            tituloSocioVinculado = new Data.TituloSocio
                            {
                                idTituloSocio = ((Data.TituloSocio)input).idTituloSocio
                            },
                            status = Data.TituloSocioVinculo.Status.Ativo
                        };
                        try
                        {
                            tsv = (Data.TituloSocioVinculo)Utils.Utils.listaDados((long)this.m_IdEmpresaCorrente, tsv, 0, null)[0];
                            ((Data.TituloSocio)input).meuVinculo = tsv;
                            ((Data.TituloSocio)input).vinculado = true;
                        }
                        catch
                        {
                            ((Data.TituloSocio)input).meuVinculo = null;
                            ((Data.TituloSocio)input).vinculado = false;
                        }
                    }


                    //Preencher TituloSocioLancamentoContabils
                    if (((Tables.TituloSocio)bd).tituloSocioLancamentoContabils != null)
                    {
                        System.Collections.Generic.List<Data.TituloSocioLancamentoContabil> _list = new System.Collections.Generic.List<Data.TituloSocioLancamentoContabil>();

                        foreach (Tables.TituloSocioLancamentoContabil _item in ((Tables.TituloSocio)bd).tituloSocioLancamentoContabils)
                        {
                            _list.Add
                            (
                                (Data.TituloSocioLancamentoContabil)
                                (new WS.CRUD.TituloSocioLancamentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloSocioLancamentoContabil(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.TituloSocio)input).tituloSocioLancamentoContabils = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.TituloSocio)input).tituloSocioLancamentoContabils != null)
                        {
                            System.Collections.Generic.List<Data.TituloSocioLancamentoContabil> _list = new System.Collections.Generic.List<Data.TituloSocioLancamentoContabil>();

                            foreach (Data.TituloSocioLancamentoContabil _item in ((Data.TituloSocio)input).tituloSocioLancamentoContabils)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.TituloSocio)input).tituloSocioLancamentoContabils = _list.ToArray();
                            else
                                ((Data.TituloSocio)input).tituloSocioLancamentoContabils = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                    //Preencher convite
                    if (((Tables.TituloSocio)bd).convite != null)
                    {
                        System.Collections.Generic.List<Data.Convite> _list = new System.Collections.Generic.List<Data.Convite>();

                        foreach (Tables.Convite _item in ((Tables.TituloSocio)bd).convite)
                        {
                            _list.Add
                            (
                                (Data.Convite)
                                (new WS.CRUD.Convite(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.Convite(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.TituloSocio)input).convite = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.TituloSocio)input).convite != null)
                        {
                            System.Collections.Generic.List<Data.Convite> _list = new System.Collections.Generic.List<Data.Convite>();

                            foreach (Data.Convite _item in ((Data.TituloSocio)input).convite)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.TituloSocio)input).convite = _list.ToArray();
                            else
                                ((Data.TituloSocio)input).convite = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }

                    if (((Tables.TituloSocio)bd).tituloSocioSituacao != null)
                    {
                        System.Collections.Generic.List<Data.TituloSocioSituacao> _list = new System.Collections.Generic.List<Data.TituloSocioSituacao>();

                        foreach (Tables.TituloSocioSituacao _item in ((Tables.TituloSocio)bd).tituloSocioSituacao)
                        {
                            _list.Add
                            (
                                (Data.TituloSocioSituacao)
                                (new WS.CRUD.TituloSocioSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloSocioSituacao(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.TituloSocio)input).tituloSocioSituacao = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.TituloSocio)input).tituloSocioSituacao != null)
                        {
                            System.Collections.Generic.List<Data.TituloSocioSituacao> _list = new System.Collections.Generic.List<Data.TituloSocioSituacao>();

                            foreach (Data.TituloSocioSituacao _item in ((Data.TituloSocio)input).tituloSocioSituacao)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.TituloSocio)input).tituloSocioSituacao = _list.ToArray();
                            else
                                ((Data.TituloSocio)input).tituloSocioSituacao = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }

                    if (((Tables.TituloSocio)bd).tituloSocioVinculo != null)
                    {
                        System.Collections.Generic.List<Data.TituloSocioVinculo> _list = new System.Collections.Generic.List<Data.TituloSocioVinculo>();

                        foreach (Tables.TituloSocioVinculo _item in ((Tables.TituloSocio)bd).tituloSocioVinculo)
                        {
                            _list.Add
                            (
                                (Data.TituloSocioVinculo)
                                (new WS.CRUD.TituloSocioVinculo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloSocioVinculo(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.TituloSocio)input).tituloSocioVinculo = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.TituloSocio)input).tituloSocioVinculo != null)
                        {
                            System.Collections.Generic.List<Data.TituloSocioVinculo> _list = new System.Collections.Generic.List<Data.TituloSocioVinculo>();

                            foreach (Data.TituloSocioVinculo _item in ((Data.TituloSocio)input).tituloSocioVinculo)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.TituloSocio)input).tituloSocioVinculo = _list.ToArray();
                            else
                                ((Data.TituloSocio)input).tituloSocioVinculo = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }

                if (((Data.TituloSocio)input).tituloSocioSituacao != null)
                {
                    Data.TituloSocioSituacao[] atual = ((Data.TituloSocio)input).tituloSocioSituacao.Where(X => X.dataFim.Ticks == 0).OrderByDescending(X => X.idTituloSocioSituacao).ToArray();
                    if (atual.Length > 0)
                        ((Data.TituloSocio)input).situacaoAtual = atual[0];
                    else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocio result = (Data.TituloSocio)parametros["Key"];

            try
            {
                result = (Data.TituloSocio)this.preencher
                (
                    new Data.TituloSocio(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloSocio),
                        new Object[]
                        {
                            result.idTituloSocio
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

            Data.TituloSocio _input = (Data.TituloSocio)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTituloSocio > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocio.idTituloSocio = @idTituloSocio");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocio", _input.idTituloSocio));
                    if (!sqlOrderBy.Contains("tituloSocio.idTituloSocio"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocio.idTituloSocio");
                    else { }
                }
                else { }

                if (_input.categoriaTitulo != null)
                {
                    if (_input.categoriaTitulo.idCategoriaTitulo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocio.idCategoriaTitulo = @idCategoriaTitulo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCategoriaTitulo", _input.categoriaTitulo.idCategoriaTitulo));
                        if (!sqlOrderBy.Contains("tituloSocio.idCategoriaTitulo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocio.idCategoriaTitulo");
                        else { }
                    }
                    else { }
                }
                else { }


                if (_input.titulo != null)
                {
                    if (_input.titulo.numero > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "titulo.numero = @numero");
                        fieldKeys.Add(new EJB.TableBase.TFieldBigInteger("numero", _input.titulo.numero));
                        if (!sqlOrderBy.Contains("titulo.numero"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "titulo.numero");
                        else { }
                    }
                    else { }

                    if (_input.titulo.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "titulo.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.titulo.idEmpresa));
                        if (!sqlOrderBy.Contains("titulo.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "titulo.idEmpresa");
                        else { }
                    }
                    else { }
                }
                else { }

                bool
                    procurarCartao = false;

                if (_input.titularEmpresaRelacionamento != null)
                {
                    if (_input.titularEmpresaRelacionamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.titularEmpresaRelacionamento.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.titularEmpresaRelacionamento.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocio.idEmpresaRelacionamentoTitular = @idEmpresaRelacionamentoTitular");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoTitular", _input.titularEmpresaRelacionamento.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("tituloSocio.idEmpresaRelacionamentoTitular"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocio.idEmpresaRelacionamentoTitular");
                        else { }
                    }
                    else { }

                    if (_input.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa != null)
                    {
                        if (!String.IsNullOrEmpty(_input.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamentoEmpresa.tipo = @tipoRelacionamentoEmpresa");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("tipoRelacionamentoEmpresa", _input.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo));
                            if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.tipo"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.tipo");
                            else { }
                        }
                        else { }

                        if (_input.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = @idTipoRelacionamentoEmpresa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoRelacionamentoEmpresa", _input.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa));
                            if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresaidTipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa");
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if (_input.titularEmpresaRelacionamento.pessoa != null)
                    {
                        if (_input.titularEmpresaRelacionamento.pessoa.idPessoa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.titularEmpresaRelacionamento.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if ((_input.titularEmpresaRelacionamento.pessoa.cpfCnpj != null) && (_input.titularEmpresaRelacionamento.pessoa.cpfCnpj.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.titularEmpresaRelacionamento.pessoa.cpfCnpj + '%'));
                            if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                            else { }
                        }
                        else { }

                        if ((_input.titularEmpresaRelacionamento.pessoa.nomeRazaoSocial != null) && (_input.titularEmpresaRelacionamento.pessoa.nomeRazaoSocial.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", "%" + _input.titularEmpresaRelacionamento.pessoa.nomeRazaoSocial + '%'));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }

                    }
                    else { }

                    if (_input.titularEmpresaRelacionamento.cartoes != null && _input.titularEmpresaRelacionamento.cartoes.Length > 0)
                    {
                        string condicaoCartao = "";
                        int i = 0;
                        foreach (Data.Cartao item in _input.titularEmpresaRelacionamento.cartoes)
                        {
                            if (!String.IsNullOrEmpty(item.numeroCartao))
                            {
                                condicaoCartao += condicaoCartao.Length == 0 ? " AND (" : null;
                                string term = item.numeroCartao.ToString();
                                condicaoCartao += (i > 0 ? " OR " : null) + "(cartao.numeroCartao = '" + term + "' OR cartao.codigoBarras = '" + term + "' OR cartao.numeroRFID = '" + term + "' OR (cartao.numeroCartao = right(replicate('0',12) + convert(VARCHAR,'" + term + "'),12) OR cartao.codigoBarras = right(replicate('0',12) + convert(VARCHAR,'" + term + "'),12))) AND cartao.ativo = 's' AND cartao.dataCancelamento IS NULL";
                                i++;
                            }
                        }
                        condicaoCartao += i > 0 ? ")" : null;
                        procurarCartao = true;
                        sqlWhere += condicaoCartao;
                    }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "tituloSocio.* ") +
                    "from " +
                    @"  tituloSocio 
		                inner join categoriaTitulo
			                on	categoriaTitulo.idCategoriaTitulo = tituloSocio.idCategoriaTitulo
		                inner join titulo
			                on	titulo.idTitulo = tituloSocio.idTitulo
		                inner join empresaRelacionamento
			                on	empresaRelacionamento.idEmpresaRelacionamento = tituloSocio.idEmpresaRelacionamentoTitular
		                inner join tipoRelacionamentoEmpresa
			                on	tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = empresaRelacionamento.idTipoRelacionamentoEmpresa
                        inner join pessoa pessoa
	                        on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
		                left join pessoaJuridica
			                on	pessoaJuridica.idPessoaJuridica = pessoa.idPessoa
		                left join pessoaFisica
			                on	pessoaFisica.idPessoaFisica = pessoa.idPessoa
		                left join empresaRelacionamento empresaRelacionamentoPai
			                on	empresaRelacionamentoPai.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionadaEmpresa" +
                        (
                            procurarCartao ?
                            @"left join cartao on cartao.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionamento" :
                            null
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
            Data.TituloSocio input = (Data.TituloSocio)parametros["Key"];
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
                    typeof(Tables.TituloSocio),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloSocio _data in
                    (System.Collections.Generic.List<Tables.TituloSocio>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloSocio),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = new Data.TituloSocio();
                    switch (mode)
                    {
                        default:
                            {
                                _base = (Data.Base)this.preencher(new Data.TituloSocio(), _data, level);
                                break;
                            }
                        case "Roll":
                            {


                                ((Data.TituloSocio)_base).idTituloSocio = _data.idTituloSocio.value;
                                ((Data.TituloSocio)_base).agencia = _data.agencia.value;
                                ((Data.TituloSocio)_base).conta = _data.conta.value;

                                if (_data.banco.idBanco.value > 0)
                                    ((Data.TituloSocio)_base).banco = new Data.Banco
                                    {
                                        idBanco = _data.banco.idBanco.value,
                                        descricao = _data.banco.descricao.value
                                    };
                                ((Data.TituloSocio)_base).titularEmpresaRelacionamento = new Data.EmpresaRelacionamento();
                                ((Data.TituloSocio)_base).titularEmpresaRelacionamento.limitePosPago = _data.titularEmpresaRelacionamento.limitePosPago.value;
                                ((Data.TituloSocio)_base).titularEmpresaRelacionamento.idEmpresaRelacionamento = _data.titularEmpresaRelacionamento.idEmpresaRelacionamento.value;
                                ((Data.TituloSocio)_base).titularEmpresaRelacionamento.tipoRelacionamentoEmpresa = new Data.TipoRelacionamentoEmpresa
                                {
                                    idTipoRelacionamentoEmpresa = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa.value,
                                    tipo = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo.value,
                                    descricao = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.descricao.value
                                };
                                if (_data.titularEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa = new Data.PessoaFisica
                                    {
                                        idPessoa = _data.titularEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                        nomeRazaoSocial = _data.titularEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                                    };
                                else
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa = new Data.PessoaJuridica
                                    {
                                        idPessoa = _data.titularEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                        nomeRazaoSocial = _data.titularEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                                    };

                                if (_data.titularEmpresaRelacionamento.cartoes != null && _data.titularEmpresaRelacionamento.cartoes.Count > 0)
                                {
                                    List<Data.Cartao> _cartoes = new List<Data.Cartao>();
                                    foreach (Tables.Cartao item in _data.titularEmpresaRelacionamento.cartoes)
                                    {
                                        try
                                        {
                                            _cartoes.Add(new Data.Cartao
                                            {
                                                ativo = item.ativo.value,
                                                cancelado = item.dataCancelamento.value.Ticks > 0,
                                                codigoBarras = item.codigoBarras.value,
                                                dataCancelamento = item.dataCancelamento.value,
                                                dataEmissao = item.dataEmissao.value,
                                                dataValidade = item.dataValidade.value,
                                                idCartao = item.idCartao.value,
                                                numeroCartao = item.numeroCartao.value,
                                                numeroRFID = item.numeroRFID.value,
                                                empresaRelacionamento = new Data.EmpresaRelacionamento
                                                {
                                                    idEmpresaRelacionamento = item.empresaRelacionamento.idEmpresaRelacionamento.value
                                                }
                                            });
                                        }
                                        catch (Exception e)
                                        {
                                            throw e;
                                        }
                                    }
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.cartoes = _cartoes.ToArray();
                                }
                                else { }


                                if (_data.convite != null && _data.convite.Count > 0)
                                {
                                    List<Data.Convite> _convite = new List<Data.Convite>();
                                    foreach (Tables.Convite item in _data.convite)
                                    {
                                        try
                                        {
                                            _convite.Add(new Data.Convite
                                            {
                                                idConvite = item.idConvite.value,
                                                tipoConvite = new Data.TipoConvite
                                                {
                                                    idTipoConvite = item.tipoConvite.idTipoConvite.value
                                                },
                                                tituloSocio = new Data.TituloSocio
                                                {
                                                    idTituloSocio = item.tituloSocio.idTituloSocio.value
                                                },
                                                dataCriacaoConvite = item.dataCriacaoConvite.value,
                                                dataVencimentoFinal = item.dataVencimentoFinal.value,
                                                dataVencimentoInicial = item.dataVencimentoInicial.value,
                                                convidado = new Data.Convidado
                                                {
                                                    idEmpresaRelacionamento = item.convidado.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value,
                                                    pessoa = new Data.Pessoa
                                                    {
                                                        nomeRazaoSocial = item.convidado.convidadoEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value,
                                                        idPessoa = item.convidado.convidadoEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                                        cpfCnpj = item.convidado.convidadoEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value
                                                    }
                                                },
                                                funcionario = new Data.Funcionario
                                                {
                                                    idEmpresaRelacionamento = item.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value
                                                },
                                                metodoCriacao = item.metodoCriacao.value
                                            });
                                        }
                                        catch (Exception e)
                                        {
                                            throw e;
                                        }
                                    }
                                    ((Data.TituloSocio)_base).convite = _convite.ToArray();
                                }
                                else { }

                                ((Data.TituloSocio)_base).ativo =
                                (
                                    (_data.dataFimTitulo.value.Ticks == 0 ||
                                    (
                                        _data.dataFimTitulo.value.Ticks > 0 &&
                                        (_data.dataFimTitulo.value.Date - DateTime.Now.Date).Days > 0
                                    )) &&
                                    (_data.titularEmpresaRelacionamento.dataTermino.value.Ticks == 0 ||
                                    (
                                        _data.titularEmpresaRelacionamento.dataTermino.value.Ticks > 0 &&
                                        (_data.titularEmpresaRelacionamento.dataTermino.value.Date - DateTime.Now.Date).Days > 0
                                    ))
                                );

                                ((Data.TituloSocio)_base).categoriaTitulo = new Data.CategoriaTitulo
                                {
                                    idCategoriaTitulo = _data.categoriaTitulo.idCategoriaTitulo.value
                                };

                                ((Data.TituloSocio)_base).categoriaView = _data.categoriaTitulo.idCategoriaTitulo.value + " - " + _data.categoriaTitulo.descricao.value;
                                ((Data.TituloSocio)_base).titulo = new Data.Titulo
                                {
                                    numero = _data.titulo.numero.value
                                };

                                if (_data.titularEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.titularEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                                else
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.titularEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");

                                ((Data.TituloSocio)_base).cpfCnpj = ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa.cpfCnpjFormatado;
                                ((Data.TituloSocio)_base).dependente = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo.value == "SD";
                                ((Data.TituloSocio)_base).tipo = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.descricao.value;

                                break;
                            }
                        case "AutoComplete":
                            {
                                ((Data.TituloSocio)_base).idTituloSocio = _data.idTituloSocio.value;
                                ((Data.TituloSocio)_base).titularEmpresaRelacionamento = new Data.EmpresaRelacionamento();
                                ((Data.TituloSocio)_base).titularEmpresaRelacionamento.idEmpresaRelacionamento = _data.titularEmpresaRelacionamento.idEmpresaRelacionamento.value;
                                if (_data.titularEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa = new Data.PessoaFisica
                                    {
                                        idPessoa = _data.titularEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                        nomeRazaoSocial = _data.titularEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                                    };
                                else
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa = new Data.PessoaJuridica
                                    {
                                        idPessoa = _data.titularEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                        nomeRazaoSocial = _data.titularEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                                    };

                                if (_data.titularEmpresaRelacionamento.pessoaRelacionamento.pfpj.value == "F")
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.titularEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"000\.000\.000\-00");
                                else
                                    ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa.cpfCnpjFormatado = Convert.ToUInt64(_data.titularEmpresaRelacionamento.pessoaRelacionamento.cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");

                                ((Data.TituloSocio)_base).cpfCnpj = ((Data.TituloSocio)_base).titularEmpresaRelacionamento.pessoa.cpfCnpjFormatado;
                                ((Data.TituloSocio)_base).dependente = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo.value == "SD";
                                ((Data.TituloSocio)_base).tipo = _data.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.descricao.value;

                                break;
                            }
                    }

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
