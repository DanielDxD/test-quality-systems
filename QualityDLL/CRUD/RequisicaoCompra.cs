using System;

namespace WS.CRUD
{
    public class RequisicaoCompra : WS.CRUD.Base
    {
        public RequisicaoCompra(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompra input = (Data.RequisicaoCompra)parametros["Key"];
            Tables.RequisicaoCompra bd = new Tables.RequisicaoCompra();

            bd.idRequisicaoCompra.isNull = true;
            bd.descricao.value = input.descricao;
            bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            bd.dataRequisicao.value = input.dataRequisicao;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoCompra)parametros["Key"]).idRequisicaoCompra = (int)bd.idRequisicaoCompra.value;

            //Processa RequisicaoCompraSituacao
            if (input.requisicaoCompraSituacaos != null)
            {
                WS.CRUD.RequisicaoCompraSituacao requisicaoCompraSituacaoCRUD = new WS.CRUD.RequisicaoCompraSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCompraSituacaos.Length; i++)
                {
                    input.requisicaoCompraSituacaos[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.requisicaoCompraSituacaos[i]);
                    requisicaoCompraSituacaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCompraSituacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa RequisicaoCompraProdutoServico
            if (input.requisicaoCompraProdutoServicos != null)
            {
                WS.CRUD.RequisicaoCompraProdutoServico requisicaoCompraProdutoServicoCRUD = new WS.CRUD.RequisicaoCompraProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCompraProdutoServicos.Length; i++)
                {
                    input.requisicaoCompraProdutoServicos[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.requisicaoCompraProdutoServicos[i]);
                    requisicaoCompraProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCompraProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa RequisicaoCotacao
            if (input.requisicaoCotacaos != null)
            {
                WS.CRUD.RequisicaoCotacao requisicaoCotacaoCRUD = new WS.CRUD.RequisicaoCotacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCotacaos.Length; i++)
                {
                    input.requisicaoCotacaos[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.requisicaoCotacaos[i]);
                    requisicaoCotacaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCotacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa PedidoCompra
            if (input.pedidoCompras != null)
            {
                WS.CRUD.PedidoCompra pedidoCompraCRUD = new WS.CRUD.PedidoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pedidoCompras.Length; i++)
                {
                    input.pedidoCompras[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.pedidoCompras[i]);
                    pedidoCompraCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pedidoCompraCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompra input = (Data.RequisicaoCompra)parametros["Key"];
            Tables.RequisicaoCompra bd = (Tables.RequisicaoCompra)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoCompra),
                new Object[]
                {
                    input.idRequisicaoCompra
                }
            );

            bd.descricao.value = input.descricao;
            bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            bd.dataRequisicao.value = input.dataRequisicao;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            //Processa RequisicaoCompraSituacao
            if (input.requisicaoCompraSituacaos != null)
            {
                WS.CRUD.RequisicaoCompraSituacao requisicaoCompraSituacaoCRUD = new WS.CRUD.RequisicaoCompraSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCompraSituacaos.Length; i++)
                {
                    input.requisicaoCompraSituacaos[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.requisicaoCompraSituacaos[i]);
                    if (input.requisicaoCompraSituacaos[i].operacao == ENum.eOperacao.NONE)
                        input.requisicaoCompraSituacaos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    requisicaoCompraSituacaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCompraSituacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa RequisicaoCompraProdutoServico
            if (input.requisicaoCompraProdutoServicos != null)
            {
                WS.CRUD.RequisicaoCompraProdutoServico requisicaoCompraProdutoServicoCRUD = new WS.CRUD.RequisicaoCompraProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCompraProdutoServicos.Length; i++)
                {
                    input.requisicaoCompraProdutoServicos[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.requisicaoCompraProdutoServicos[i]);
                    if (input.requisicaoCompraProdutoServicos[i].operacao == ENum.eOperacao.NONE)
                        input.requisicaoCompraProdutoServicos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    requisicaoCompraProdutoServicoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCompraProdutoServicoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa RequisicaoCotacao
            if (input.requisicaoCotacaos != null)
            {
                WS.CRUD.RequisicaoCotacao requisicaoCotacaoCRUD = new WS.CRUD.RequisicaoCotacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.requisicaoCotacaos.Length; i++)
                {
                    input.requisicaoCotacaos[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.requisicaoCotacaos[i]);
                    if (input.requisicaoCotacaos[i].operacao == ENum.eOperacao.NONE)
                        input.requisicaoCotacaos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    requisicaoCotacaoCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                requisicaoCotacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa PedidoCompra
            if (input.pedidoCompras != null)
            {
                WS.CRUD.PedidoCompra pedidoCompraCRUD = new WS.CRUD.PedidoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pedidoCompras.Length; i++)
                {
                    input.pedidoCompras[i].idRequisicaoCompra = bd.idRequisicaoCompra.value;
                    _parameters.Add("Key", input.pedidoCompras[i]);
                    if (input.pedidoCompras[i].operacao == ENum.eOperacao.NONE)
                        input.pedidoCompras[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pedidoCompraCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pedidoCompraCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            this.m_EntityManager.execute
            (
                "delete from requisicaoCompra where idRequisicaoCompra = @idRequisicaoCompra",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger("idRequisicaoCompra", ((Data.RequisicaoCompra)parametros["Key"]).idRequisicaoCompra)
                }
            );
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoCompra)bd).idRequisicaoCompra.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoCompra)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoCompra)input).idRequisicaoCompra = ((Tables.RequisicaoCompra)bd).idRequisicaoCompra.value;
                    ((Data.RequisicaoCompra)input).descricao = ((Tables.RequisicaoCompra)bd).descricao.value;
                    ((Data.RequisicaoCompra)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.RequisicaoCompra)bd).departamento,
                        level + 1
                    );
                    ((Data.RequisicaoCompra)input).dataRequisicao = ((Tables.RequisicaoCompra)bd).dataRequisicao.value;
                    ((Data.RequisicaoCompra)input).observacao = ((Tables.RequisicaoCompra)bd).observacao.value;
                }
                else { }

                //Usuario
                ((Data.RequisicaoCompra)input).usuarioRequisicao = "";

                if (level < 1)
                {
                    //Preencher RequisicaoCompraSituacaos
                    if (((Tables.RequisicaoCompra)bd).requisicaoCompraSituacaos != null)
                    {
                        System.Collections.Generic.List<Data.RequisicaoCompraSituacao> _list = new System.Collections.Generic.List<Data.RequisicaoCompraSituacao>();

                        foreach (Tables.RequisicaoCompraSituacao _item in ((Tables.RequisicaoCompra)bd).requisicaoCompraSituacaos)
                        {
                            _list.Add
                            (
                                (Data.RequisicaoCompraSituacao)
                                (new WS.CRUD.RequisicaoCompraSituacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.RequisicaoCompraSituacao(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.RequisicaoCompra)input).requisicaoCompraSituacaos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoCompra)input).requisicaoCompraSituacaos != null)
                        {
                            System.Collections.Generic.List<Data.RequisicaoCompraSituacao> _list = new System.Collections.Generic.List<Data.RequisicaoCompraSituacao>();

                            foreach (Data.RequisicaoCompraSituacao _item in ((Data.RequisicaoCompra)input).requisicaoCompraSituacaos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoCompra)input).requisicaoCompraSituacaos = _list.ToArray();
                            else
                                ((Data.RequisicaoCompra)input).requisicaoCompraSituacaos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher RequisicaoCompraProdutoServicos
                    if (((Tables.RequisicaoCompra)bd).requisicaoCompraProdutoServicos != null)
                    {
                        System.Collections.Generic.List<Data.RequisicaoCompraProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoCompraProdutoServico>();

                        foreach (Tables.RequisicaoCompraProdutoServico _item in ((Tables.RequisicaoCompra)bd).requisicaoCompraProdutoServicos)
                        {
                            _list.Add
                            (
                                (Data.RequisicaoCompraProdutoServico)
                                (new WS.CRUD.RequisicaoCompraProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.RequisicaoCompraProdutoServico(),
                                    _item,
                                    level
                                )
                            );
                        }

                        ((Data.RequisicaoCompra)input).requisicaoCompraProdutoServicos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoCompra)input).requisicaoCompraProdutoServicos != null)
                        {
                            System.Collections.Generic.List<Data.RequisicaoCompraProdutoServico> _list = new System.Collections.Generic.List<Data.RequisicaoCompraProdutoServico>();

                            foreach (Data.RequisicaoCompraProdutoServico _item in ((Data.RequisicaoCompra)input).requisicaoCompraProdutoServicos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoCompra)input).requisicaoCompraProdutoServicos = _list.ToArray();
                            else
                                ((Data.RequisicaoCompra)input).requisicaoCompraProdutoServicos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher RequisicaoCotacaos
                    if (((Tables.RequisicaoCompra)bd).requisicaoCotacaos != null)
                    {
                        System.Collections.Generic.List<Data.RequisicaoCotacao> _list = new System.Collections.Generic.List<Data.RequisicaoCotacao>();

                        foreach (Tables.RequisicaoCotacao _item in ((Tables.RequisicaoCompra)bd).requisicaoCotacaos)
                        {
                            _list.Add
                            (
                                (Data.RequisicaoCotacao)
                                (new WS.CRUD.RequisicaoCotacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.RequisicaoCotacao(),
                                    _item,
                                    level
                                )
                            );
                        }

                        ((Data.RequisicaoCompra)input).requisicaoCotacaos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoCompra)input).requisicaoCotacaos != null)
                        {
                            System.Collections.Generic.List<Data.RequisicaoCotacao> _list = new System.Collections.Generic.List<Data.RequisicaoCotacao>();

                            foreach (Data.RequisicaoCotacao _item in ((Data.RequisicaoCompra)input).requisicaoCotacaos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoCompra)input).requisicaoCotacaos = _list.ToArray();
                            else
                                ((Data.RequisicaoCompra)input).requisicaoCotacaos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher PedidoCompras
                    if (((Tables.RequisicaoCompra)bd).pedidoCompras != null)
                    {
                        System.Collections.Generic.List<Data.PedidoCompra> _list = new System.Collections.Generic.List<Data.PedidoCompra>();

                        foreach (Tables.PedidoCompra _item in ((Tables.RequisicaoCompra)bd).pedidoCompras)
                        {
                            _list.Add
                            (
                                (Data.PedidoCompra)
                                (new WS.CRUD.PedidoCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PedidoCompra(),
                                    _item,
                                    level
                                )
                            );
                        }

                        ((Data.RequisicaoCompra)input).pedidoCompras = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.RequisicaoCompra)input).pedidoCompras != null)
                        {
                            System.Collections.Generic.List<Data.PedidoCompra> _list = new System.Collections.Generic.List<Data.PedidoCompra>();

                            foreach (Data.PedidoCompra _item in ((Data.RequisicaoCompra)input).pedidoCompras)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.RequisicaoCompra)input).pedidoCompras = _list.ToArray();
                            else
                                ((Data.RequisicaoCompra)input).pedidoCompras = null;

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
            Data.RequisicaoCompra result = (Data.RequisicaoCompra)parametros["Key"];

            try
            {
                result = (Data.RequisicaoCompra)this.preencher
                (
                    new Data.RequisicaoCompra(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoCompra),
                        new Object[]
                        {
                            result.idRequisicaoCompra
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
                sqlJoinFornecedor = "",
                sqlJoinSituacao = "",
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

            Data.RequisicaoCompra _input = (Data.RequisicaoCompra)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if ((_input.departamento != null) && (_input.departamento.idEmpresa > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   departamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.departamento.idEmpresa));
                    if (!sqlOrderBy.Contains("departamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idRequisicaoCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   requisicaoCompra.idRequisicaoCompra = @idRequisicaoCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoCompra", _input.idRequisicaoCompra));
                    if (!sqlOrderBy.Contains("requisicaoCompra.idRequisicaoCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoCompra.idRequisicaoCompra");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   requisicaoCompra.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("requisicaoCompra.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoCompra.descricao");
                    else { }
                }
                else { }

                if
                (
                    (_input.pedidoCompras != null) &&
                    (_input.pedidoCompras.Length == 1)
                )
                {
                    if
                    (
                        (_input.pedidoCompras[0].fornecedor != null) &&
                        (_input.pedidoCompras[0].fornecedor.pessoa != null) &&
                        !String.IsNullOrEmpty(_input.pedidoCompras[0].fornecedor.pessoa.nomeRazaoSocial)
                    )
                        sqlJoinFornecedor =
                        (
                            "       inner join\n" +
                            "       (\n" +
                            "           select\n" +
                            "               requisicaoCotacao.idRequisicaoCompra,\n" +
                            "               pessoa.nomeRazaoSocial\n" +
                            "           from\n" +
                            "               requisicaoCotacao requisicaoCotacao\n" +
                            "                   inner join fornecedor fornecedor\n" +
                            "                       on	fornecedor.idFornecedor = requisicaoCotacao.idFornecedor\n" +
                            "                   inner join empresaRelacionamento empresaRelacionamento\n" +
                            "                       on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor\n" +
                            "                   inner join pessoa pessoa\n" +
                            "                       on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n" +
                            "       ) fornecedor\n" +
                            "           on	fornecedor.idRequisicaoCompra = requisicaoCOmpra.idRequisicaoCompra and\n" +
                            "               fornecedor.nomeRazaoSocial like '" + _input.pedidoCompras[0].fornecedor.pessoa.nomeRazaoSocial + "%'\n"
                        );
                    else
                    {
                        if (_input.pedidoCompras[0].idPedidoCompra > 0)
                            sqlWhere +=
                            (
                                (sqlWhere.Length > 0 ? " and\n" : "") +
                                "   (\n" +
                                "       pedidoCompraServico.idPedidoCompra is null or\n" +
                                "       (pedidoCompraServico.idPedidoCompra = " + _input.pedidoCompras[0].idPedidoCompra.ToString() + ")\n" +
                                "   )\n"
                            );
                        else { }
                    }
                }
                else { }
                //sqlWhere += (sqlWhere.Length > 0 ? " and\n" : "") + "       pedidoCompraServico.idPedidoCompra is null\n";


                if
                (
                    (_input.requisicaoCotacaos != null) &&
                    (_input.requisicaoCotacaos.Length == 1)
                )
                {
                    if
                    (
                        (_input.requisicaoCotacaos[0].fornecedor != null) &&
                        (_input.requisicaoCotacaos[0].fornecedor.idEmpresaRelacionamento > 0)
                    )
                        sqlJoinFornecedor +=
                        (
                            "       inner join\n" +
                            "           " +
                            "       (\n" +
                            "           select\n" +
                            "               requisicaoCotacao.idRequisicaoCompra,\n" +
                            "               pessoa.nomeRazaoSocial,\n" +
                            "               fornecedor.idFornecedor" +
                            "           from\n" +
                            "               requisicaoCotacao requisicaoCotacao\n" +
                            "                   inner join fornecedor fornecedor\n" +
                            "                       on	fornecedor.idFornecedor = requisicaoCotacao.idFornecedor\n" +
                            "                   inner join empresaRelacionamento empresaRelacionamento\n" +
                            "                       on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor\n" +
                            "                   inner join pessoa pessoa\n" +
                            "                       on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n" +
                            "       ) fornecedor\n" +
                            "           on  fornecedor.idFornecedor = " + _input.requisicaoCotacaos[0].fornecedor.idEmpresaRelacionamento + "\n" +
                            "               and fornecedor.idRequisicaoCompra = requisicaoCompra.idRequisicaoCompra\n"
                        );
                    else
                    {
                        if (_input.pedidoCompras[0].idPedidoCompra > 0)
                            sqlWhere +=
                            (
                                (sqlWhere.Length > 0 ? " and\n" : "") +
                                "   (\n" +
                                "       pedidoCompraServico.idPedidoCompra is null or\n" +
                                "       (pedidoCompraServico.idPedidoCompra = " + _input.pedidoCompras[0].idPedidoCompra.ToString() + ")\n" +
                                "   )\n"
                            );
                        else { }
                    }
                }
                else { }
                //sqlWhere += (sqlWhere.Length > 0 ? " and\n" : "") + "       pedidoCompraServico.idPedidoCompra is null\n";


                if
                (
                    (_input.requisicaoCompraSituacaos != null) &&
                    (_input.requisicaoCompraSituacaos.Length == 1) &&
                    !String.IsNullOrEmpty(_input.requisicaoCompraSituacaos[0].situacao)
                )
                {
                    sqlJoinSituacao =
                    (
                        "       inner join\n" +
                        "       (\n" +
                        "           select\n" +
                        "               idRequisicaoCompra,\n" +
                        "               max(idRequisicaoCompraSituacao) idRequisicaoCompraSituacao\n" +
                        "           from\n" +
                        "               requisicaoCompraSituacao\n" +
                        "           group by\n" +
                        "               idRequisicaoCompra\n" +
                        "       ) requisicaoCompraSituacaoCorrente\n" +
                        "           on	requisicaoCompraSituacaoCorrente.idRequisicaoCompra = requisicaoCompra.idRequisicaoCompra and \n" +
                        "               requisicaoCompraSituacao.idRequisicaoCompraSituacao = requisicaoCompraSituacaoCorrente.idRequisicaoCompraSituacao and\n" +
                        "               requisicaoCompraSituacao.situacao = '" + _input.requisicaoCompraSituacaos[0].situacao + "'\n"
                    );
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "requisicaoCompra.*, departamento.alcada\n") +
                    "from \n" + 
                    (
                        @"
                           requisicaoCompra requisicaoCompra
	                            inner join departamento departamento
		                            on	departamento.idDepartamento = requisicaoCompra.idDepartamento
		                        inner join
			                        (
				                        select
					                        idRequisicaoCompra,
					                        MAX(idRequisicaoCompraSituacao) idRequisicaoCompraSituacao
				                        from
					                        requisicaoCompraSituacao
				                        group by
					                        idRequisicaoCompra
			                        ) requisicaoCompraSituacaoAtual
				                        on	requisicaoCompraSituacaoAtual.idRequisicaoCompra = requisicaoCompra.idRequisicaoCompra
		                        inner join requisicaoCompraSituacao requisicaoCompraSituacao
			                        on	requisicaoCompraSituacao.idRequisicaoCompraSituacao = requisicaoCompraSituacaoAtual.idRequisicaoCompraSituacao
                               left join
                               (
                                   select
                                       idPedidoCompra,
                                       idRequisicaoCompra,
                                       idFornecedor
                                   from
                                       pedidoCompraServico
                               ) pedidoCompraServico
                                   on	pedidoCompraServico.idRequisicaoCompra = requisicaoCompra.idRequisicaoCompra
                        "

                    ) +
                    sqlJoinFornecedor +
                    sqlJoinSituacao +
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
            Data.RequisicaoCompra input = (Data.RequisicaoCompra)parametros["Key"];
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
                    typeof(Tables.RequisicaoCompra),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoCompra _data in
                    (System.Collections.Generic.List<Tables.RequisicaoCompra>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoCompra),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.RequisicaoCompra();
                        ((Data.RequisicaoCompra)_base).idRequisicaoCompra = _data.idRequisicaoCompra.value;
                        ((Data.RequisicaoCompra)_base).descricao = _data.descricao.value;
                        ((Data.RequisicaoCompra)_base).dataRequisicao = _data.dataRequisicao.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.RequisicaoCompra(), _data, level);


                    ((Data.RequisicaoCompra)_base).usuarioRequisicao = (String)this.m_EntityManager.executeScalar
                    (
                        @"
                            select
	                            pessoa.nomeRazaoSocial
                            from
	                            requisicaoCompraSituacao
		                            inner join funcionario
			                            on	funcionario.idFuncionario = requisicaoCompraSituacao.idFuncionario
		                            inner join empresaRelacionamento
			                            on	empresaRelacionamento.idEmpresaRelacionamento = funcionario.idFuncionario
		                            inner join pessoa
			                            on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento
                            where
	                            requisicaoCompraSituacao.idRequisicaoCompraSituacao =
	                            (
		                            select
			                            max(requisicaoCompraSituacao.idRequisicaoCompraSituacao) idRequisicaoCompraSituacao
		                            from
			                            requisicaoCompraSituacao
		                            where
			                            requisicaoCompraSituacao.idRequisicaoCompra = @idRequisicaoCompra
	                            )
                        ",
                        new EJB.TableBase.TField[] { new EJB.TableBase.TField { name = "idRequisicaoCompra", value = ((Data.RequisicaoCompra)_base).idRequisicaoCompra } }
                    );

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
